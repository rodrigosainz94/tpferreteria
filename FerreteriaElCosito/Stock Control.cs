using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerreteriaElCosito
{
    public partial class frmControlStock : Form
    {
        private ComprasManager _comprasManager = new ComprasManager();
        private DataTable _reporteStock;

        public frmControlStock()
        {
            InitializeComponent();
            dgvmovimientosstock.CellEndEdit += dgvStock_CellEndEdit;
        }

        private void frmControlStock_Load(object sender, EventArgs e)
        {
            dtpfecha.Value = DateTime.Now;
            dtpfecha.Format = DateTimePickerFormat.Custom;
            dtpfecha.CustomFormat = "dd/MM/yyyy";

            ConfigurarDataGridView();
            CargarReporteStock(dtpfecha.Value);
        }

        private void ConfigurarDataGridView()
        {
            dgvmovimientosstock.Columns.Clear();
            dgvmovimientosstock.Columns.Add("IdProducto", "ID Producto");
            dgvmovimientosstock.Columns.Add("NombreProducto", "Producto");
            dgvmovimientosstock.Columns.Add("SaldoInicial", "Saldo Inicial");
            dgvmovimientosstock.Columns.Add("Ingresos", "Ingresos");
            dgvmovimientosstock.Columns.Add("Egresos", "Egresos");
            dgvmovimientosstock.Columns.Add("SaldoTeorico", "Saldo Teórico");

            DataGridViewTextBoxColumn arqueoColumn = new DataGridViewTextBoxColumn();
            arqueoColumn.Name = "Arqueo";
            arqueoColumn.HeaderText = "Arqueo";
            dgvmovimientosstock.Columns.Add(arqueoColumn);

            DataGridViewTextBoxColumn diferenciaColumn = new DataGridViewTextBoxColumn();
            diferenciaColumn.Name = "Diferencia";
            diferenciaColumn.HeaderText = "Diferencia";
            diferenciaColumn.ReadOnly = true;
            dgvmovimientosstock.Columns.Add(diferenciaColumn);

            foreach (DataGridViewColumn col in dgvmovimientosstock.Columns)
            {
                if (col.Name != "Arqueo")
                {
                    col.ReadOnly = true;
                }
            }
        }

        private void CargarReporteStock(DateTime fecha)
        {
            try
            {
                _reporteStock = _comprasManager.ObtenerReporteDiarioStock(fecha);
                dgvmovimientosstock.DataSource = _reporteStock;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte de stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvmovimientosstock.Columns[e.ColumnIndex].Name == "Arqueo")
            {
                DataGridViewRow row = dgvmovimientosstock.Rows[e.RowIndex];
                if (row.Cells["SaldoTeorico"].Value != null && row.Cells["Arqueo"].Value != null)
                {
                    decimal saldoTeorico;
                    decimal arqueo;
                    if (decimal.TryParse(row.Cells["SaldoTeorico"].Value.ToString(), out saldoTeorico) &&
                        decimal.TryParse(row.Cells["Arqueo"].Value.ToString(), out arqueo))
                    {
                        decimal diferencia = arqueo - saldoTeorico;
                        row.Cells["Diferencia"].Value = diferencia.ToString("N2");
                    }
                }
            }
        }


        private void btnimprimir_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Reporte de stock listo para imprimir.", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnatras_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlimpiar_Click_1(object sender, EventArgs e)
        {
            dtpfecha.Value = DateTime.Now;
            CargarReporteStock(dtpfecha.Value);
        }

        private void dtpfecha_ValueChanged_1(object sender, EventArgs e)
        {
            CargarReporteStock(dtpfecha.Value);
        }
    }
}