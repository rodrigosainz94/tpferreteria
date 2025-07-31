using MySql.Data.MySqlClient;
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
    public partial class SeleccionarEmpleado : Form
    {
        public int IdSeleccionado { get; private set; } = -1;

        public SeleccionarEmpleado()
        {
            InitializeComponent();
            CargarEmpleados();
        }

        private void CargarEmpleados()
        {
            ConexionBD conexionBD = new ConexionBD();
            MySqlConnection conn = conexionBD.AbrirConexion();

            try
            {
                string query = "SELECT idEmpleado AS 'ID', apellido AS 'Apellido', nombre AS 'Nombre' FROM empleado ORDER BY apellido, nombre";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvEmpleados.DataSource = dt;
                dgvEmpleados.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                IdSeleccionado = Convert.ToInt32(dgvEmpleados.SelectedRows[0].Cells["ID"].Value);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Seleccioná un empleado de la lista.");
            }
        }

        private void dgvEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                IdSeleccionado = Convert.ToInt32(dgvEmpleados.Rows[e.RowIndex].Cells["ID"].Value);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
