using System;
using System.Data;
using System.Windows.Forms;

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
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // Simplemente cerramos la ventana de vista previa
            this.Close();
        }
    }
}