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
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = @"SELECT u.idUsuario,
                                    CONCAT(e.Nombre, ' ', e.Apellido) AS Usuario,
                                    u.Clave,
                                    u.idEmpleado
                             FROM usuarios u
                             INNER JOIN empleado e ON u.idEmpleado = e.idEmpleado";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Asegurarse que idEmpleado quede al final (opcional, normalmente ya lo será si lo pediste al final en el SELECT)
                    if (dt.Columns.Contains("idEmpleado"))
                        dt.Columns["idEmpleado"].SetOrdinal(dt.Columns.Count - 1);

                    dataGridView1.DataSource = dt;

                    // Opcional: ajustar encabezados legibles
                    if (dataGridView1.Columns["Usuario"] != null)
                        dataGridView1.Columns["Usuario"].HeaderText = "Nombre y Apellido";
                    if (dataGridView1.Columns["idEmpleado"] != null)
                        dataGridView1.Columns["idEmpleado"].HeaderText = "Id Empleado";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }


        private void btnagregar_Click(object sender, EventArgs e)
        {
            UsuariosAgregar nuevoFormulario = new UsuariosAgregar();
            nuevoFormulario.Show();
            this.Hide();
        }





        private void btnatras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            UsuariosAgregar nuevoFormulario = new UsuariosAgregar();
            nuevoFormulario.Show();
            this.Hide();
        }
    }
}
