using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace FerreteriaElCosito
{
    public partial class UsuariosAgregar : Form
    {
        private int? idUsuarioParaEditar = null;

        // Constructor para MODO ALTA
        public UsuariosAgregar()
        {
            InitializeComponent();
            this.Text = "Agregar Nuevo Usuario";
            txtIdUsuario.Enabled = false;
        }

        // Constructor para MODO EDICIÓN
        public UsuariosAgregar(int idUsuario)
        {
            InitializeComponent();
            this.idUsuarioParaEditar = idUsuario;
            this.Text = "Editar Usuario";
            txtIdUsuario.Enabled = false;
        }

        private void UsuariosAgregar_Load(object sender, EventArgs e)
        {
            if (idUsuarioParaEditar.HasValue)
            {
                // Si estamos editando, cargamos todos los empleados para poder seleccionar
                CargarTodosLosEmpleados();
                CargarDatosDelUsuario();
            }
            else
            {
                // Si estamos dando de alta, solo cargamos empleados que aún no tienen usuario
                CargarEmpleadosSinUsuario();
            }
        }

        private void CargarDatosDelUsuario()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT * FROM usuarios WHERE IdUsuario = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", this.idUsuarioParaEditar);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtIdUsuario.Text = reader["IdUsuario"].ToString();
                            txtNombreUsuario.Text = reader["NombreUsuario"].ToString();
                            txtContraseña.Text = ""; // La contraseña nunca se muestra, solo se puede cambiar
                            cmbEmpleado.SelectedValue = reader["IdEmpleado"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del usuario: " + ex.Message);
                this.Close();
            }
        }

        private void CargarEmpleadosSinUsuario()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    // Trae solo empleados que no están en la tabla de usuarios
                    string query = @"SELECT e.IdEmpleado, CONCAT(e.Nombre, ' ', e.Apellido) AS NombreCompleto
                                     FROM empleado e
                                     WHERE e.IdEmpleado NOT IN (SELECT u.IdEmpleado FROM usuarios u)";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbEmpleado.DataSource = dt;
                    cmbEmpleado.DisplayMember = "NombreCompleto";
                    cmbEmpleado.ValueMember = "IdEmpleado";
                    cmbEmpleado.SelectedIndex = -1;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar empleados disponibles: " + ex.Message); }
        }

        private void CargarTodosLosEmpleados()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT IdEmpleado, CONCAT(Nombre, ' ', Apellido) AS NombreCompleto FROM empleado";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbEmpleado.DataSource = dt;
                    cmbEmpleado.DisplayMember = "NombreCompleto";
                    cmbEmpleado.ValueMember = "IdEmpleado";
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar la lista de empleados: " + ex.Message); }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) || cmbEmpleado.SelectedValue == null)
            {
                MessageBox.Show("El nombre de usuario y el empleado son obligatorios.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!idUsuarioParaEditar.HasValue && string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("La contraseña es obligatoria al crear un nuevo usuario.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "";
                    if (idUsuarioParaEditar.HasValue) // MODO EDICIÓN
                    {
                        // Si el campo contraseña tiene texto, la actualizamos. Si no, la dejamos como estaba.
                        if (!string.IsNullOrWhiteSpace(txtContraseña.Text))
                        {
                            query = "UPDATE usuarios SET NombreUsuario = @Nombre, Clave = @Clave, IdEmpleado = @IdEmpleado WHERE IdUsuario = @IdUsuario";
                        }
                        else
                        {
                            query = "UPDATE usuarios SET NombreUsuario = @Nombre, IdEmpleado = @IdEmpleado WHERE IdUsuario = @IdUsuario";
                        }
                    }
                    else // MODO ALTA
                    {
                        query = "INSERT INTO usuarios (NombreUsuario, Clave, IdEmpleado) VALUES (@Nombre, @Clave, @IdEmpleado)";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombreUsuario.Text);
                    cmd.Parameters.AddWithValue("@IdEmpleado", cmbEmpleado.SelectedValue);

                    if (!string.IsNullOrWhiteSpace(txtContraseña.Text))
                    {
                        // Aquí deberías usar el Hashing que implementamos antes
                        // cmd.Parameters.AddWithValue("@Clave", PasswordHasher.HashPassword(txtContraseña.Text));
                        cmd.Parameters.AddWithValue("@Clave", txtContraseña.Text); // Usando texto plano por ahora
                    }

                    if (idUsuarioParaEditar.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@IdUsuario", this.idUsuarioParaEditar.Value);
                    }

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Usuario guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el usuario: " + ex.Message);
            }
        }
    }
}