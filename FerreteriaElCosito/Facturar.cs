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

        public class ConexionBD
        {


            private string cadenaConexion = "server=bkqymy1borojhlsillq3-mysql.services.clever-cloud.com;port=3306;user=uuoe1ny0zqkumerf;password=dTZa3XPyebjXff9xkfmj;database=bkqymy1borojhlsillq3;SslMode=none;";
            private MySqlConnection conexion;

            public ConexionBD()
            {
                conexion = new MySqlConnection(cadenaConexion);
            }

            public MySqlConnection AbrirConexion()
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open();
                }
                return conexion;
            }

            public void CerrarConexion()
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
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
            
        }

        private void Facturar_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
