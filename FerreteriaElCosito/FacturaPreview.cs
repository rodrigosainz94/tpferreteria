using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FerreteriaElCosito
{
    public partial class FacturaPreview : Form
    {
        // Clase interna para guardar los datos completos del cliente
        private class ClienteFactura
        {
            public string NombreCompleto { get; set; }
            public string CUIT { get; set; }
            public string Direccion { get; set; }
            public string CondicionIVA { get; set; }
        }

        // Variables para los datos de la factura
        private int? idCliente;
        private DataTable itemsFactura;
        private decimal totalFactura;
        private ClienteFactura cliente = new ClienteFactura();

        public FacturaPreview(int? idCliente, DataTable items, decimal total)
        {
            InitializeComponent();
            this.idCliente = idCliente;
            this.itemsFactura = items;
            this.totalFactura = total;
        }

        private void FacturaPreview_Load(object sender, EventArgs e)
        {
            CargarDatosCliente();

            lblNombreCliente.Text = $"Cliente: {cliente.NombreCompleto}";
            lblCuitCliente.Text = $"CUIT: {cliente.CUIT}";
            lblFecha.Text = $"Fecha: {DateTime.Now:dd/MM/yyyy}";
            lblTotal.Text = $"TOTAL: {this.totalFactura:C}";

            dgvItems.DataSource = this.itemsFactura;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            CargarMetodosDePago();
        }

        private void CargarDatosCliente()
        {
            if (this.idCliente == null) return;

            if (this.idCliente == 76) // ID de Consumidor Final
            {
                cliente.NombreCompleto = "Consumidor Final";
                cliente.CUIT = "XX-XXXXXXXX-X";
                cliente.Direccion = "-";
                cliente.CondicionIVA = "Consumidor Final";
                return;
            }

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = @"SELECT c.Nombre, c.Apellido, c.CUIT_CUIL, c.CalleNumero, 
                                            l.NombreLocalidad, p.NombreProvincia, iva.DescripcionIVA
                                     FROM clientes c
                                     LEFT JOIN localidades l ON c.IdLocalidad = l.IdLocalidad
                                     LEFT JOIN provincias p ON c.IdProvincia = p.IdProvincia
                                     LEFT JOIN categoriaiva iva ON c.IdCatIVA = iva.IdCatIVA
                                     WHERE c.IdCliente = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", this.idCliente);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente.NombreCompleto = $"{reader["Nombre"]} {reader["Apellido"]}";
                            cliente.CUIT = reader["CUIT_CUIL"].ToString();
                            cliente.Direccion = $"{reader["CalleNumero"]}, {reader["NombreLocalidad"]}, {reader["NombreProvincia"]}";
                            cliente.CondicionIVA = "Factura A"; // Ajustado según requerimiento
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del cliente: " + ex.Message);
            }
        }

        private void CargarMetodosDePago()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT IdFormaPago, Descripcion FROM formapago ORDER BY Descripcion";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dtFormasPago = new DataTable();
                    da.Fill(dtFormasPago);
                    cmbMetPago.DataSource = dtFormasPago;
                    cmbMetPago.DisplayMember = "Descripcion";
                    cmbMetPago.ValueMember = "IdFormaPago";
                    cmbMetPago.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los métodos de pago: " + ex.Message);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            long nuevaVentaId = -1;
            MySqlConnection conn = null;
            MySqlTransaction transaction = null;

            try
            {
                conn = ConexionBD.ObtenerConexion();
                transaction = conn.BeginTransaction();
                int idTipoComprobante = (this.idCliente == 76) ? 8 : 1;
                string queryVenta = @"INSERT INTO ventas (FechaVenta, IdCliente, IdEmpleado, IdTipoComprobante, Total) 
                                      VALUES (@fecha, @idCliente, @idEmpleado, @idTipoComprobante, @total);
                                      SELECT LAST_INSERT_ID();";
                MySqlCommand cmdVenta = new MySqlCommand(queryVenta, conn, transaction);
                cmdVenta.Parameters.AddWithValue("@fecha", DateTime.Now);
                cmdVenta.Parameters.AddWithValue("@idCliente", this.idCliente);
                cmdVenta.Parameters.AddWithValue("@idEmpleado", SesionUsuario.IdEmpleado);
                cmdVenta.Parameters.AddWithValue("@idTipoComprobante", idTipoComprobante);
                cmdVenta.Parameters.AddWithValue("@total", this.totalFactura);
                nuevaVentaId = Convert.ToInt64(cmdVenta.ExecuteScalar());

                string queryUpdate = "UPDATE ventas SET NumeroComprobante = @num WHERE IdVenta = @id";
                MySqlCommand cmdUpdate = new MySqlCommand(queryUpdate, conn, transaction);
                cmdUpdate.Parameters.AddWithValue("@num", nuevaVentaId);
                cmdUpdate.Parameters.AddWithValue("@id", nuevaVentaId);
                cmdUpdate.ExecuteNonQuery();

                // Aquí iría la lógica para guardar el detalle de la venta (itemsFactura)

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("Error al guardar la venta en la base de datos: " + ex.Message);
                return;
            }
            finally
            {
                conn?.Close();
            }

            if (nuevaVentaId != -1)
            {
                GenerarPdf(nuevaVentaId);
            }
        }

        private void GenerarPdf(long numeroFactura)
        {
            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string nombreArchivo = $"Factura_{numeroFactura}.pdf";
            string rutaCompleta = Path.Combine(downloadsPath, nombreArchivo);

            try
            {
                Document doc = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaCompleta, FileMode.Create));
                doc.Open();

                Paragraph datosFerreteria = new Paragraph();
                datosFerreteria.Alignment = Element.ALIGN_LEFT;
                datosFerreteria.Add(new Chunk("FERRETERIA 'EL COSITO'\n", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD)));
                datosFerreteria.Add("Dirección: Av. Corrientes 1234, CABA\n");
                datosFerreteria.Add("Teléfono: (011) 4555-5555\n");
                datosFerreteria.Add("Email: ventas@elcosito.com.ar\n");
                datosFerreteria.Add("CUIT: 30-12345678-9\n");
                doc.Add(datosFerreteria);

                Paragraph titulo = new Paragraph($"FACTURA N°: {numeroFactura:D8}", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD));
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);
                doc.Add(Chunk.NEWLINE);

                doc.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy}"));
                doc.Add(new Paragraph($"Cliente: {cliente.NombreCompleto}"));
                doc.Add(new Paragraph($"CUIT: {cliente.CUIT}"));
                doc.Add(new Paragraph($"Dirección: {cliente.Direccion}"));
                doc.Add(new Paragraph($"Condición frente al IVA: {cliente.CondicionIVA}"));
                doc.Add(Chunk.NEWLINE);

                PdfPTable tabla = new PdfPTable(itemsFactura.Columns.Count);
                tabla.WidthPercentage = 100;
                foreach (DataColumn columna in itemsFactura.Columns)
                {
                    PdfPCell header = new PdfPCell(new Phrase(columna.ColumnName));
                    header.BackgroundColor = BaseColor.LIGHT_GRAY;
                    header.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabla.AddCell(header);
                }
                foreach (DataRow fila in itemsFactura.Rows)
                {
                    foreach (object item in fila.ItemArray)
                    {
                        tabla.AddCell(new Phrase(item.ToString()));
                    }
                }
                doc.Add(tabla);
                doc.Add(Chunk.NEWLINE);

                Paragraph total = new Paragraph($"TOTAL: {this.totalFactura:C}", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD));
                total.Alignment = Element.ALIGN_RIGHT;
                doc.Add(total);

                doc.Close();
                writer.Close();

                MessageBox.Show($"Venta registrada y PDF generado con éxito:\n{rutaCompleta}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(rutaCompleta);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message);
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (cmbMetPago.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un método de pago.", "Falta Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Intentamos registrar la salida de stock
            if (RegistrarMovimientoDeStock())
            {
                // Si el stock se actualizó con éxito, mostramos el mensaje y deshabilitamos
                MessageBox.Show("Pago confirmado y stock actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmbMetPago.Enabled = false;
                btnPagar.Enabled = false;
            }
        }

        /// <summary>
        /// NUEVO: Registra la salida de stock para cada item de la factura.
        /// </summary>
        private bool RegistrarMovimientoDeStock()
        {
            MySqlConnection conn = null;
            MySqlTransaction transaction = null;

            try
            {
                conn = ConexionBD.ObtenerConexion();
                transaction = conn.BeginTransaction();
                string query = @"INSERT INTO movimientostock 
                               (IdProducto, IdTipoMovimiento, Cantidad, FechaMovimiento, DetalleMovimiento, IdDeposito, IdEmpleado)
                               VALUES 
                               (@IdProducto, @IdTipoMovimiento, @Cantidad, @Fecha, @Detalle, @IdDeposito, @IdEmpleado)";

                foreach (DataRow fila in this.itemsFactura.Rows)
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn, transaction);
                    cmd.Parameters.AddWithValue("@IdProducto", fila["IdProducto"]);
                    cmd.Parameters.AddWithValue("@IdTipoMovimiento", 2); // 2 = Egreso
                    cmd.Parameters.AddWithValue("@Cantidad", fila["Cantidad"]);
                    cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Detalle", "-");
                    cmd.Parameters.AddWithValue("@IdDeposito", 1);
                    cmd.Parameters.AddWithValue("@IdEmpleado", SesionUsuario.IdEmpleado);
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("Error crítico al actualizar el stock: " + ex.Message, "Error de Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conn?.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}