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
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void CargarProveedores()
        {
            try
            {
                using (var conexion = new MySqlConnection(ConexionBD.cadenaConexion))
                {
                    conexion.Open();
                    string query = "SELECT * FROM proveedores";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvproveedores.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando proveedores: " + ex.Message);
            }
        }
        private void Proveedores_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            ProveedoresEdicion frm = new ProveedoresEdicion();

            // Mostrar el formulario nuevo
            frm.Show();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            ProveedoresEdicion frm = new ProveedoresEdicion();

            // Mostrar el formulario nuevo
            frm.Show();
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
