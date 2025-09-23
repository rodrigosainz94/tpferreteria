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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            this.Load += Usuarios_Load; // nos aseguramos de que se ejecute al cargar
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            try
            {
                using (var conexion = new MySqlConnection(ConexionBD.cadenaConexion))
                {
                    conexion.Open();
                    string query = "SELECT * FROM usuarios";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando proveedores: " + ex.Message);
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            UsuariosAgregar nuevoFormulario = new UsuariosAgregar();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            UsuariosAgregar nuevoFormulario = new UsuariosAgregar();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
