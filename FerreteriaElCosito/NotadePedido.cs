using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO; // Para FileStream

namespace FerreteriaElCosito
{
    public partial class frmnotadepedido : Form
    {
        // ================== VARIABLES ==================
        private int idCompra;

        // ================== CONSTRUCTORES ==================
        public frmnotadepedido()
        {
            InitializeComponent();
        }

        public frmnotadepedido(int idCompra) : this()
        {
            this.idCompra = idCompra;
        }

        // ================== LOAD ==================
        private void frmnotadepedido_Load(object sender, EventArgs e)
        {
            if (idCompra > 0)
            {
                CargarDatosCompra(idCompra);
                ConfigurarSoloLectura();
            }
        }

        // ================== CONFIGURAR SOLO LECTURA ==================
        private void ConfigurarSoloLectura()
        {
            // TextBox solo lectura
            txttipocomprobante.ReadOnly = true;
            txtnrocomprobante.ReadOnly = true;
            txtidproveedor.ReadOnly = true;
            txtproveedor.ReadOnly = true;
            txtidempleado.ReadOnly = true;
            txtempleado.ReadOnly = true;
            txtfecha.ReadOnly = true;

            // DataGridView solo lectura
            dgvdetalleprod.ReadOnly = true;
            dgvdetalleprod.AllowUserToAddRows = false;
            dgvdetalleprod.AllowUserToDeleteRows = false;
            dgvdetalleprod.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Botón limpiar opcionalmente oculto
            btnlimpiar.Visible = false;
        }

        // ================== CARGAR DATOS DE COMPRA ==================
        private void CargarDatosCompra(int idCompra)
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = @"
                        SELECT c.IdCompra, c.FechaCompra, 
                               t.DenominacionComprobante AS TipoComprobante,
                               c.NumeroComprobante AS NroComprobante,
                               p.IdProveedor, p.Nombre AS Proveedor, 
                               e.IdEmpleado, e.Nombre AS Empleado,
                               d.Cantidad, pr.NombreProducto, d.PrecioUnitario, d.Subtotal
                        FROM compras c
                        INNER JOIN proveedores p ON c.IdProveedor = p.IdProveedor
                        INNER JOIN empleado e ON c.IdEmpleado = e.IdEmpleado
                        INNER JOIN detallecompra d ON c.IdCompra = d.IdCompra
                        INNER JOIN productos pr ON d.IdProducto = pr.IdProducto
                        INNER JOIN tipocomprobante t ON c.IdTipoComprobante = t.IdTipoComprobante
                        WHERE c.IdCompra = @idCompra";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idCompra", idCompra);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        txttipocomprobante.Text = row["TipoComprobante"]?.ToString() ?? "";
                        txtnrocomprobante.Text = row["NroComprobante"]?.ToString() ?? "";
                        txtidproveedor.Text = row["IdProveedor"]?.ToString() ?? "";
                        txtproveedor.Text = row["Proveedor"]?.ToString() ?? "";
                        txtidempleado.Text = row["IdEmpleado"]?.ToString() ?? "";
                        txtempleado.Text = row["Empleado"]?.ToString() ?? "";
                        txtfecha.Text = row["FechaCompra"] != DBNull.Value
                                             ? Convert.ToDateTime(row["FechaCompra"]).ToString("dd/MM/yyyy")
                                             : "";

                        DataTable dtDetalle = dt.DefaultView.ToTable(false, "NombreProducto", "Cantidad", "PrecioUnitario", "Subtotal");
                        dgvdetalleprod.DataSource = dtDetalle;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron datos para esta compra.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la compra: " + ex.Message);
            }
        }

        //================== BOTÓN IMPRIMIR PDF SEGURO CON VERIFICACIÓN ==================
        private void btnimprimirpedido_Click_1(object sender, EventArgs e)
        {
            try
            {
                // === Validar que existan datos en el DataGridView ===
                if (dgvdetalleprod == null || dgvdetalleprod.Rows.Count == 0 || (dgvdetalleprod.Rows.Count == 1 && dgvdetalleprod.Rows[0].IsNewRow))
                {
                    MessageBox.Show("No hay datos para generar la nota de pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // === Seleccionar ruta de guardado ===
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF Files (*.pdf)|*.pdf",
                    FileName = $"NotaPedido_{idCompra}.pdf"
                };

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                string rutaCompleta = saveFileDialog.FileName;

                // === Crear PDF ===
                // La creación de doc y writer se mueve dentro del using para asegurar que fs no sea nulo.
                using (FileStream fs = new FileStream(rutaCompleta, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    // === Título ===
                    Paragraph titulo = new Paragraph("NOTA DE PEDIDO\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16));
                    titulo.Alignment = Element.ALIGN_CENTER;
                    doc.Add(titulo);

                    // === Datos del pedido ===
                    Paragraph infoPedido = new Paragraph(
                        $"Fecha: {txtfecha.Text}\n" +
                        $"Proveedor: {txtproveedor.Text}\n" +
                        $"Empleado: {txtempleado.Text}\n" +
                        $"Tipo Comprobante: {txttipocomprobante.Text}\n" +
                        $"N° Comprobante: {txtnrocomprobante.Text}\n\n",
                        FontFactory.GetFont(FontFactory.HELVETICA, 12)
                    );
                    doc.Add(infoPedido);

                    // === Tabla de productos ===
                    PdfPTable tabla = new PdfPTable(dgvdetalleprod.Columns.Count);
                    tabla.WidthPercentage = 100;

                    // Encabezado
                    foreach (DataGridViewColumn col in dgvdetalleprod.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(col.HeaderText, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        tabla.AddCell(cell);
                    }

                    // Filas
                    foreach (DataGridViewRow row in dgvdetalleprod.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                tabla.AddCell(new Phrase(cell.Value?.ToString() ?? "", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                            }
                        }
                    }

                    doc.Add(tabla);

                    // === Cerrar documento ===
                    doc.Close();
                    writer.Close(); // opcional
                }

                MessageBox.Show("PDF generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnatras_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}