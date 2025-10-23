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
            // Establecer el formato de fecha para la visualización
            dtpfecha.Format = DateTimePickerFormat.Custom;
            dtpfecha.CustomFormat = "dd/MM/yyyy";

            CargarDatosParaFecha(dtpfecha.Value);
            if (txtarqueo != null)
            {
                txtarqueo.TextChanged += txtarqueo_TextChanged;
            }
            if (txtsdoinicial != null)
            {
                txtsdoinicial.TextChanged += txtsdoinicial_TextChanged;
            }
            // Conexión del evento Click para el botón de Cierre de Caja
            this.btncierrecaja.Click += new System.EventHandler(this.btnCerrarCaja_Click);
        }

        private void VerificarEstadoDeCaja(DateTime fecha)
        {
            bool cajaCerrada = _comprasManager.VerificarCajaCerrada(fecha);
            if (cajaCerrada)
            {
                MessageBox.Show("La caja para esta fecha ya fue cerrada. Los datos no son editables.", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btncierrecaja.Enabled = false;
                txtsdoinicial.ReadOnly = true;
                txtarqueo.ReadOnly = true;
            }
            else
            {
                btncierrecaja.Enabled = true;
                txtsdoinicial.ReadOnly = false;
                txtarqueo.ReadOnly = false;
            }
        }

        private void CargarDatosParaFecha(DateTime fecha)
        {
            try
            {
                VerificarEstadoDeCaja(fecha);

                // Si la caja ya está cerrada, cargamos los valores históricos guardados
                if (_comprasManager.VerificarCajaCerrada(fecha))
                {
                    DataTable dtCajaCerrada = _comprasManager.ObtenerDatosCajaCerrada(fecha);
                    if (dtCajaCerrada.Rows.Count > 0)
                    {
                        DataRow row = dtCajaCerrada.Rows[0];
                        // Muestra el Saldo Inicial guardado para ese día
                        _saldoInicial = Convert.ToDecimal(row["SaldoInicial"]);
                        txtsdoinicial.Text = _saldoInicial.ToString("N2");
                        // Muestra el Saldo Final guardado como el Arqueo
                        txtarqueo.Text = Convert.ToDecimal(row["SaldoFinal"]).ToString("N2");
                    }
                }
                // Si la caja está abierta o no tiene registro para hoy, cargamos el saldo inicial del día anterior
                else
                {
                    // Si el usuario ya lo modificó manualmente, lo conservamos. Si no, se trae de la BD.
                    if (!decimal.TryParse(txtsdoinicial.Text, out _saldoInicial))
                    {
                        _saldoInicial = _comprasManager.ObtenerSaldoInicialDelDia(fecha);
                        txtsdoinicial.Text = _saldoInicial.ToString("N2");
                    }
                    txtarqueo.Text = "0.00"; // Borrar el arqueo si está abierto
                }

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
            else
            {
                _saldoInicial = 0;
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

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtsdofinalteorico.Text, out decimal saldoFinalTeorico) &&
                decimal.TryParse(txtarqueo.Text, out decimal saldoFinalContado) &&
                decimal.TryParse(txtsdoinicial.Text, out decimal saldoInicialCargado))
            {
                if (_comprasManager.VerificarCajaCerrada(dtpfecha.Value))
                {
                    MessageBox.Show("La caja para esta fecha ya fue cerrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CierreDeCaja cierre = new CierreDeCaja
                {
                    Fecha = dtpfecha.Value,
                    SaldoInicial = saldoInicialCargado,
                    SaldoFinal = saldoFinalContado,
                    Observaciones = $"Arqueo del día con Sdo Teórico: {saldoFinalTeorico:N2}. Diferencia: {saldoFinalContado - saldoFinalTeorico:N2}",
                    IdEmpleado = 1
                };

                try
                {
                    _comprasManager.GuardarCierreDeCaja(cierre);
                    MessageBox.Show("Caja del día cerrada y registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Actualiza la interfaz después del cierre
                    VerificarEstadoDeCaja(dtpfecha.Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cerrar la caja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, verifique que los campos 'Saldo Inicial' y 'Arqueo' contengan valores numéricos válidos.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        

        // Métodos de eventos que no necesitan código adicional
        private void lblsaldoinicial_Click(object sender, EventArgs e) { }
        private void cbtotalingresos_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cbtotalegresos_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dgvmovimientoscaja_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtsdofinalteorico_TextChanged(object sender, EventArgs e) { }
    }
}