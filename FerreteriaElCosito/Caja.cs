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
    public partial class Caja : Form
    {
        private ComprasManager _comprasManager = new ComprasManager();
        private decimal _saldoInicial = 0;
        private DataTable _movimientosDiarios;

        public Caja()
        {
            InitializeComponent();
        }

        private void Caja_Load(object sender, EventArgs e)
        {
            CargarDatosParaFecha(dtpfecha.Value);
            if (txtarqueo != null)
            {
                txtarqueo.TextChanged += txtarqueo_TextChanged;
            }
            if (txtsdoinicial != null)
            {
                txtsdoinicial.TextChanged += txtsdoinicial_TextChanged;
            }
        }

        private void CargarDatosParaFecha(DateTime fecha)
        {
            try
            {
                _saldoInicial = _comprasManager.ObtenerSaldoInicialDelDia(fecha);
                txtsdoinicial.Text = _saldoInicial.ToString("N2");

                _movimientosDiarios = _comprasManager.ObtenerMovimientosDeCajaDiarios(fecha);
                dgvmovimientoscaja.DataSource = _movimientosDiarios;

                CalcularArqueo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de caja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularArqueo()
        {
            if (decimal.TryParse(txtsdoinicial.Text, out decimal saldoInicialManual))
            {
                _saldoInicial = saldoInicialManual;
            }

            if (_movimientosDiarios == null) return;

            decimal totalIngresos = 0;
            decimal totalEgresos = 0;

            foreach (DataRow row in _movimientosDiarios.Rows)
            {
                string tipo = row["Descripcion"].ToString();
                decimal monto = Convert.ToDecimal(row["Monto"]);

                if (tipo.ToLower().Contains("ingreso"))
                {
                    totalIngresos += monto;
                }
                else if (tipo.ToLower().Contains("egreso"))
                {
                    totalEgresos += monto;
                }
            }

            decimal saldoFinalTeorico = _saldoInicial + totalIngresos - totalEgresos;

            cbtotalingresos.Text = totalIngresos.ToString("N2");
            cbtotalegresos.Text = totalEgresos.ToString("N2");
            txtsdofinalteorico.Text = saldoFinalTeorico.ToString("N2");

            if (decimal.TryParse(txtarqueo.Text, out decimal saldoFinalContado))
            {
                decimal diferencia = saldoFinalContado - saldoFinalTeorico;
                txtdiferencia.Text = diferencia.ToString("N2");
            }
            else
            {
                txtdiferencia.Text = "0.00";
            }
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reporte de arqueo de caja listo para imprimir.", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtarqueo.Clear();
            txtdiferencia.Clear();
        }

        private void txtarqueo_TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();
        }

        private void txtsdoinicial_TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();
        }

        private void dtpfecha_ValueChanged(object sender, EventArgs e)
        {
            CargarDatosParaFecha(dtpfecha.Value);
        }


        private void lblsaldoinicial_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void cbsaldoinicial_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cbtotalingresos_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cbtotalegresos_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtsdofinalteorico_TextChanged(object sender, EventArgs e) { }

        private void btnstock_Click_1(object sender, EventArgs e)
        {
            frmControlStock stockForm = new frmControlStock();
            stockForm.ShowDialog();

        }
    }
}