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
        private class ClienteFactura
        {
            public string NombreCompleto { get; set; }
            public string CUIT { get; set; }
            public string Direccion { get; set; }
            public string CondicionIVA { get; set; }
        }

        private int? idCliente;
        private DataTable itemsFactura;
        private decimal totalFactura;
        private ClienteFactura cliente = new ClienteFactura();
        private Facturar formFacturarPrincipal;
        private long? idVentaGenerada = null; // Guardará el ID de la venta una vez pagada

        public FacturaPreview(int? idCliente, DataTable items, decimal total, Facturar ownerForm)
        {
            InitializeComponent();
            this.idCliente = idCliente;
            this.itemsFactura = items;
            this.totalFactura = total;
            this.formFacturarPrincipal = ownerForm;
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
            dgvItems.ReadOnly = true;

            if (dgvItems.Columns.Count > 0)
            {
                dgvItems.Columns["IdProducto"].DisplayIndex = 0;
                dgvItems.Columns["Nombre"].DisplayIndex = 1;
                dgvItems.Columns["Cantidad"].DisplayIndex = 2;
                dgvItems.Columns["Medida"].DisplayIndex = 3;
                dgvItems.Columns["Precio unidad"].DisplayIndex = 4;
                dgvItems.Columns["Precio cantidad"].DisplayIndex = 5;
                dgvItems.Columns["Descuento"].DisplayIndex = 6;
                dgvItems.Columns["Precio con descuento"].DisplayIndex = 7;
            }

            CargarMetodosDePago();

            // El botón de confirmar (generar PDF) empieza deshabilitado
            btnConfirmar.Enabled = false;
        }

        private void CargarDatosCliente()
        {
            if (this.idCliente == null) return;
            if (this.idCliente == 76)
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
                            cliente.CondicionIVA = "Factura A";
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

        /// <summary>
        /// Se encarga de guardar la venta, el detalle, actualizar stock y movimientos.
        /// </summary>
        private bool ProcesarVentaCompleta()
        {
            MySqlConnection conn = null;
            MySqlTransaction transaction = null;
            try
            {
                conn = ConexionBD.ObtenerConexion();

                // --- 1. Verificación de Stock ---
                foreach (DataRow fila in this.itemsFactura.Rows)
                {
                    string queryStock = "SELECT Cantidad, NombreProducto, StockCritico FROM productos WHERE IdProducto = @IdProducto FOR UPDATE";
                    MySqlCommand cmdStock = new MySqlCommand(queryStock, conn);
                    cmdStock.Parameters.AddWithValue("@IdProducto", fila["IdProducto"]);

                    string nombreProd = "";
                    int stockActual = 0;
                    int stockCritico = 0;

                    using (var reader = cmdStock.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            stockActual = reader.GetInt32("Cantidad");
                            nombreProd = reader.GetString("NombreProducto");
                            stockCritico = reader.GetInt32("StockCritico");
                        }
                    }

                    int cantidadPedida = Convert.ToInt32(fila["Cantidad"]);

                    // 🔹 Verificar stock insuficiente
                    if (stockActual < cantidadPedida)
                    {
                        MessageBox.Show($"Stock insuficiente para el producto '{nombreProd}'.\nStock disponible: {stockActual} | Cantidad solicitada: {cantidadPedida}",
                            "Error de Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    // 🔹 Calcular el nuevo stock luego de la venta
                    int nuevoStock = stockActual - cantidadPedida;

                    // 🔹 Mostrar advertencia si queda bajo de stock
                    if (nuevoStock <= stockCritico)
                    {
                        MessageBox.Show($"⚠ El producto '{nombreProd}' está BAJO DE STOCK.\n" +
                                        $"Stock actual: {stockActual}\n" +
                                        $"Stock crítico: {stockCritico}\n" +
                                        $"Debería reponerse pronto.",
                                        "Advertencia de Stock Bajo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                }


                // --- 2. Si hay stock, iniciamos la transacción ---
                transaction = conn.BeginTransaction();

                // Obtener el último IdCaja
                string queryGetCajaId = "SELECT IdCaja FROM caja ORDER BY IdCaja DESC LIMIT 1";
                MySqlCommand cmdGetCajaId = new MySqlCommand(queryGetCajaId, conn, transaction);
                object cajaIdResult = cmdGetCajaId.ExecuteScalar();
                int idCaja = (cajaIdResult != null) ? Convert.ToInt32(cajaIdResult) : 1; // Usar 1 si no hay cajas

                // Guardar Venta
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
                this.idVentaGenerada = Convert.ToInt64(cmdVenta.ExecuteScalar());

                // Registrar el ingreso en la caja
                string queryCaja = @"INSERT INTO movimientocaja 
                                   (IdCaja, FechaHoraMovimiento, IdTipoMovimientoCaja, Monto, Concepto, IdVenta) 
                                   VALUES 
                                   (@IdCaja, @Fecha, @IdTipo, @Monto, @Concepto, @IdVenta)";
                MySqlCommand cmdCaja = new MySqlCommand(queryCaja, conn, transaction);
                cmdCaja.Parameters.AddWithValue("@IdCaja", idCaja);
                cmdCaja.Parameters.AddWithValue("@Fecha", DateTime.Now);
                cmdCaja.Parameters.AddWithValue("@IdTipo", 1); // 1 = Ingreso por venta
                cmdCaja.Parameters.AddWithValue("@Monto", this.totalFactura);
                cmdCaja.Parameters.AddWithValue("@Concepto", "Ingreso por venta");
                cmdCaja.Parameters.AddWithValue("@IdVenta", this.idVentaGenerada);
                cmdCaja.ExecuteNonQuery();

                // Guardar Detalle y Actualizar Stock
                foreach (DataRow fila in this.itemsFactura.Rows)
                {
                    // Guardar detalle_venta
                    //string queryDetalle = @"INSERT INTO detalle_venta (IdVenta, IdProducto, Cantidad, PrecioUnitario, Descuento)
                    //                        VALUES (@IdVenta, @IdProducto, @Cantidad, @PrecioUnitario, @Descuento)";
                    //MySqlCommand cmdDetalle = new MySqlCommand(queryDetalle, conn, transaction);
                    //cmdDetalle.Parameters.AddWithValue("@IdVenta", this.idVentaGenerada);
                    //cmdDetalle.Parameters.AddWithValue("@IdProducto", fila["IdProducto"]);
                    //cmdDetalle.Parameters.AddWithValue("@Cantidad", fila["Cantidad"]);
                    //cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", fila["Precio unidad"]);
                    //cmdDetalle.Parameters.AddWithValue("@Descuento", fila["Descuento"]);
                    //cmdDetalle.ExecuteNonQuery();

                    // Insertar en movimientostock
                    string queryMovimiento = @"INSERT INTO movimientostock (IdProducto, IdTipoMovimiento, Cantidad, FechaMovimiento, DetalleMovimiento, IdDeposito, IdEmpleado)
                                               VALUES (@IdProducto, 2, @Cantidad, @Fecha, '-', 1, @IdEmpleado)";
                    MySqlCommand cmdMovimiento = new MySqlCommand(queryMovimiento, conn, transaction);
                    cmdMovimiento.Parameters.AddWithValue("@IdProducto", fila["IdProducto"]);
                    cmdMovimiento.Parameters.AddWithValue("@Cantidad", fila["Cantidad"]);
                    cmdMovimiento.Parameters.AddWithValue("@Fecha", DateTime.Now);
                    cmdMovimiento.Parameters.AddWithValue("@IdEmpleado", SesionUsuario.IdEmpleado);
                    cmdMovimiento.ExecuteNonQuery();

                    // Actualizar la tabla productos
                    string queryUpdateStock = "UPDATE productos SET Cantidad = Cantidad - @Cantidad WHERE IdProducto = @IdProducto";
                    MySqlCommand cmdUpdateStock = new MySqlCommand(queryUpdateStock, conn, transaction);
                    cmdUpdateStock.Parameters.AddWithValue("@Cantidad", fila["Cantidad"]);
                    cmdUpdateStock.Parameters.AddWithValue("@IdProducto", fila["IdProducto"]);
                    cmdUpdateStock.ExecuteNonQuery();
                }

                // Guardar Pago de la Venta
                string queryPago = @"INSERT INTO pagoventa (IdVenta, FechaPago, IdFormaPago, Monto)
                                     VALUES (@IdVenta, @FechaPago, @IdFormaPago, @Monto)";
                MySqlCommand cmdPago = new MySqlCommand(queryPago, conn, transaction);
                cmdPago.Parameters.AddWithValue("@IdVenta", this.idVentaGenerada);
                cmdPago.Parameters.AddWithValue("@FechaPago", DateTime.Now);
                cmdPago.Parameters.AddWithValue("@IdFormaPago", cmbMetPago.SelectedValue);
                cmdPago.Parameters.AddWithValue("@Monto", this.totalFactura);
                cmdPago.ExecuteNonQuery();

                // Actualizar NumeroComprobante
                string queryUpdate = "UPDATE ventas SET NumeroComprobante = @num WHERE IdVenta = @id";
                MySqlCommand cmdUpdate = new MySqlCommand(queryUpdate, conn, transaction);
                cmdUpdate.Parameters.AddWithValue("@num", this.idVentaGenerada);
                cmdUpdate.Parameters.AddWithValue("@id", this.idVentaGenerada);
                cmdUpdate.ExecuteNonQuery();

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("Error crítico al procesar la venta: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conn?.Close();
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (cmbMetPago.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un método de pago.", "Falta Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Llamamos a la función que hace TODO el trabajo en la BD
            if (ProcesarVentaCompleta())
            {
                MessageBox.Show("Pago confirmado. Venta registrada y stock actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Avisamos al formulario principal que debe limpiarse y recargar la lista de productos
                //this.formFacturarPrincipal.LimpiarParaNuevaVenta();

                // Deshabilitamos controles para evitar acciones duplicadas
                cmbMetPago.Enabled = false;
                btnPagar.Enabled = false;
                // Habilitamos el botón para generar el comprobante
                btnConfirmar.Enabled = true;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (this.idVentaGenerada.HasValue)
            {
                GenerarPdf(this.idVentaGenerada.Value);
            }
            else
            {
                MessageBox.Show("Debe confirmar el pago primero antes de generar el comprobante.", "Acción Requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                // --- Datos de la Ferretería y Encabezado de la Factura (esto sigue igual) ---
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

                // --- CONSTRUCCIÓN MANUAL DE LA TABLA DEL PDF ---

                // 1. Creamos la tabla con 7 columnas, no con las de la DataTable
                PdfPTable tabla = new PdfPTable(7);
                tabla.WidthPercentage = 100;

                // 2. Definimos los anchos relativos de las columnas (opcional, para mejor formato)
                tabla.SetWidths(new float[] { 4f, 1.5f, 1.5f, 2f, 2f, 2f, 2.5f });

                // 3. Agregamos los encabezados manualmente en el orden deseado
                string[] headers = { "Nombre", "Cantidad", "Medida", "Precio Unidad", "Precio Cantidad", "Descuento %", "Precio con Descuento" };
                foreach (string header in headers)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(header, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD)));
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabla.AddCell(cell);
                }

                // 4. Recorremos las filas y agregamos los datos celda por celda en el orden correcto
                foreach (DataRow fila in itemsFactura.Rows)
                {
                    tabla.AddCell(fila["Nombre"].ToString());
                    tabla.AddCell(fila["Cantidad"].ToString());
                    tabla.AddCell(fila["Medida"].ToString());
                    tabla.AddCell(Convert.ToDecimal(fila["Precio unidad"]).ToString("C"));
                    tabla.AddCell(Convert.ToDecimal(fila["Precio cantidad"]).ToString("C"));
                    tabla.AddCell(Convert.ToDecimal(fila["Descuento"]).ToString("N2"));
                    tabla.AddCell(Convert.ToDecimal(fila["Precio con descuento"]).ToString("C"));
                }

                doc.Add(tabla);
                doc.Add(Chunk.NEWLINE);

                // Total (esto sigue igual)
                Paragraph total = new Paragraph($"TOTAL: {this.totalFactura:C}", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD));
                total.Alignment = Element.ALIGN_RIGHT;
                doc.Add(total);

                doc.Close();
                writer.Close();

                MessageBox.Show($"PDF generado con éxito:\n{rutaCompleta}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(rutaCompleta);

                this.DialogResult = DialogResult.OK;
                this.formFacturarPrincipal.LimpiarParaNuevaVenta();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // Si el pago se realizó, el DialogResult ya está en OK
            // Si no, se cierra con Cancel
            if (this.DialogResult != DialogResult.OK)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            this.formFacturarPrincipal.LimpiarParaNuevaVenta();
            this.Close();
        }
    }
}

