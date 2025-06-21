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
    public partial class Facturar : Form
    {
        public Facturar()
        {
            InitializeComponent();
        }

        ConexionBD miConexion = new ConexionBD();

        private void CargarDatos()
        {
            try
            {
                MySqlConnection conn = miConexion.AbrirConexion();

                string query = "SELECT * FROM clientes";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvfacturacion.DataSource = dt;

                miConexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            Menuprincipal nuevoFormulario = new Menuprincipal();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void dgvfacturacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Opcional: código si querés hacer algo al hacer clic en una celda
        }

        private void Facturar_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}