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
            // Cargar los datos para la fecha inicial (la de hoy)
            CargarDatosParaFecha(dtpfecha.Value);

            // Asumiendo que el campo de saldo contado es txtarqueo
            if (txtarqueo != null)
            {
                txtarqueo.TextChanged += txtarqueo_TextChanged;
            }
            // Agrega el evento para el nuevo TextBox de Saldo Inicial
            if (txtsdoinicial != null)
            {
                txtsdoinicial.TextChanged += txtSaldoInicial_TextChanged;
            }
        }

        // Nuevo método para cargar datos de una fecha específica
        private void CargarDatosParaFecha(DateTime fecha)
        {
            try
            {
                // Cargar el saldo inicial de la caja y mostrarlo en el TextBox
                _saldoInicial = _comprasManager.ObtenerSaldoInicialDelDia(fecha);
                txtsdoinicial.Text = _saldoInicial.ToString("N2");

                // Cargar todos los movimientos del día en el DataGridView
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
            // Primero, actualiza el saldo inicial si el usuario lo cambió manualmente
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
            // Esto solo limpia el saldo contado, el saldo inicial lo trae de la BD.
        }

        private void txtarqueo_TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();
        }

        private void txtSaldoInicial_TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();
        }

        // --- MÉTODO AGREGADO ---
        private void dtpfecha_ValueChanged(object sender, EventArgs e)
        {
            // Cuando el usuario cambia la fecha, volvemos a cargar todos los datos
            CargarDatosParaFecha(dtpfecha.Value);
        }

        // Métodos de eventos que no necesitan código adicional
        private void lblsaldoinicial_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void cbsaldoinicial_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cbtotalingresos_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cbtotalegresos_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtsdofinalteorico_TextChanged(object sender, EventArgs e) { }
    }
}