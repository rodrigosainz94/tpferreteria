using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FerreteriaElCosito
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT * FROM clientes";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvClientes.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los clientes: " + ex.Message);
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            ClientesAgregar nuevoFormulario = new ClientesAgregar();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            Menuprincipal nuevoFormulario = new Menuprincipal();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            ClientesAgregar nuevoFormulario = new ClientesAgregar();
            nuevoFormulario.Show();
            this.Hide();
        }
    }
}