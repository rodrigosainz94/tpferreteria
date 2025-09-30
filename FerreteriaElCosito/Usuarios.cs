using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace FerreteriaElCosito
{
    public partial class Usuarios : Form
    {
        // Renombramos el control internamente para mayor claridad
        private DataGridView dgvUsuarios;

        public Usuarios()
        {
            InitializeComponent();
            // Asignamos la referencia del control del diseñador a nuestra variable
            this.dgvUsuarios = this.dataGridView1;
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
                    string query = @"SELECT 
                                u.IdUsuario AS 'ID Usuario', 
                                u.NombreUsuario AS 'Nombre de Usuario', 
                                CONCAT(e.Nombre, ' ', e.Apellido) AS 'Empleado Asociado',
                                r.NombreRol AS 'Rol'
                             FROM usuarios u
                             INNER JOIN empleado e ON u.IdEmpleado = e.IdEmpleado
                             LEFT JOIN roles r ON e.IdRol = r.IdRol";

                    MySqlCommand cmd = new MySqlCommand(); // Creamos el comando vacío

                    // --- LÓGICA DE PERMISOS ---
                    // Verificamos el rol del usuario que está logueado
                    if (SesionUsuario.IdRol == 2 || SesionUsuario.IdRol == 3) // Si es Vendedor o Depósito
                    {
                        // Agregamos un filtro WHERE a la consulta para que traiga solo su propio usuario
                        query += " WHERE u.IdEmpleado = @IdEmpleadoLogueado";
                        cmd.Parameters.AddWithValue("@IdEmpleadoLogueado", SesionUsuario.IdEmpleado);
                    }

                    cmd.Connection = conn;
                    cmd.CommandText = query;

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvUsuarios.DataSource = dt;

                    dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvUsuarios.ReadOnly = true;
                    dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un usuario para editar.", "Ningún usuario seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtenemos el ID del usuario de la fila seleccionada
            int idUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["ID Usuario"].Value);

            // Abrimos el formulario en modo "Editar", pasándole el ID
            using (UsuariosAgregar formEditar = new UsuariosAgregar(idUsuario))
            {
                if (formEditar.ShowDialog() == DialogResult.OK)
                {
                    CargarUsuarios(); // Refrescamos la grilla si se modificó el usuario
                }
            }
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

