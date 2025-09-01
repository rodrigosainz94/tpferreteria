using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FerreteriaElCosito
{
    public partial class FacturaPreview : Form
    {
        // Variables para recibir los datos desde el otro formulario
        private string nombreCliente;
        private string cuitCliente;
        private DataTable itemsFactura;
        private decimal totalFactura;

        // Creamos un constructor especial que acepta los datos de la factura
        public FacturaPreview(string nombreCliente, string cuitCliente, DataTable items, decimal total)
        {
            InitializeComponent();

            // Guardamos los datos recibidos
            this.nombreCliente = nombreCliente;
            this.cuitCliente = cuitCliente;
            this.itemsFactura = items;
            this.totalFactura = total;
        }

        private void FacturaPreview_Load(object sender, EventArgs e)
        {
            // Cuando el formulario carga, mostramos los datos en los controles
            lblNombreCliente.Text = $"Cliente: {this.nombreCliente}";
            lblCuitCliente.Text = $"CUIT: {this.cuitCliente}";
            lblFecha.Text = $"Fecha: {DateTime.Now.ToString("dd/MM/yyyy")}";

            // Le damos formato al total para que se vea como dinero
            lblTotal.Text = $"TOTAL: {this.totalFactura:C}";

            // Mostramos la lista de productos en la grilla
            dgvItems.DataSource = this.itemsFactura;
            // Ajustamos el tamaño de las columnas para que se vea bien
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            CargarMetodosDePago();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // Simplemente cerramos la ventana de vista previa
            this.Close();
        }

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            // 1. Definir dónde guardar el archivo y con qué nombre
            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string nombreArchivo = $"Factura_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            string rutaCompleta = Path.Combine(downloadsPath, nombreArchivo);

            try
            {
                // 2. Crear el documento PDF
                Document doc = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaCompleta, FileMode.Create));

                doc.Open();

                // --- Contenido del PDF ---

                // Título
                Paragraph titulo = new Paragraph("FERRETERIA 'EL COSITO'", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD));
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);
                doc.Add(Chunk.NEWLINE);

                // Datos del Cliente y Factura
                doc.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy}"));
                doc.Add(new Paragraph($"Cliente: {this.nombreCliente}"));
                doc.Add(new Paragraph($"CUIT: {this.cuitCliente}"));
                doc.Add(Chunk.NEWLINE);

                // Tabla con los productos
                PdfPTable tabla = new PdfPTable(itemsFactura.Columns.Count);
                tabla.WidthPercentage = 100;

                // Encabezados de la tabla
                foreach (DataColumn columna in itemsFactura.Columns)
                {
                    PdfPCell header = new PdfPCell(new Phrase(columna.ColumnName));
                    header.BackgroundColor = BaseColor.LIGHT_GRAY;
                    header.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabla.AddCell(header);
                }

                // Filas de datos
                foreach (DataRow fila in itemsFactura.Rows)
                {
                    foreach (object item in fila.ItemArray)
                    {
                        tabla.AddCell(new Phrase(item.ToString()));
                    }
                }

                doc.Add(tabla);
                doc.Add(Chunk.NEWLINE);

                // Total
                Paragraph total = new Paragraph($"TOTAL: {this.totalFactura:C}", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD));
                total.Alignment = Element.ALIGN_RIGHT;
                doc.Add(total);

                // --- Fin del Contenido ---

                doc.Close();
                writer.Close();

                // 3. Abrir el PDF generado
                MessageBox.Show($"PDF de la factura generado con éxito en:\n{rutaCompleta}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(rutaCompleta); // Abre el archivo con el visor de PDF predeterminado

                // Cerramos la vista previa después de generar el PDF
                this.DialogResult = DialogResult.OK; // Opcional: para indicar que la operación fue exitosa
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarMetodosDePago()
        {
            try
            {
                // No creamos una instancia. Llamamos al método directamente desde la clase.
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT IdFormaPago, Descripcion FROM formapago ORDER BY Descripcion";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dtFormasPago = new DataTable();
                    da.Fill(dtFormasPago);

                    cmbMetPago.DataSource = dtFormasPago;
                    cmbMetPago.DisplayMember = "Descripcion";
                    cmbMetPago.ValueMember = "IdFormaPago";
                    cmbMetPago.SelectedIndex = -1; // Inicia sin selección
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los métodos de pago: " + ex.Message);
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            // Validamos que se haya seleccionado un método de pago
            if (cmbMetPago.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un método de pago.", "Falta Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mostramos el mensaje de confirmación
            MessageBox.Show("Pago confirmado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Deshabilitamos los controles correspondientes
            cmbMetPago.Enabled = false;
            btnPagar.Enabled = false; // Deshabilitamos el propio botón para evitar un doble pago
        }
    }
}