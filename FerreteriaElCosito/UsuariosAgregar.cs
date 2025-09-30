using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace FerreteriaElCosito
{
    public partial class UsuariosAgregar : Form
    {
        private int? idUsuarioParaEditar = null;

        public UsuariosAgregar()
        {
            InitializeComponent();
            this.Text = "Agregar Nuevo Usuario";
            txtIdUsuario.Enabled = false;
        }

        public UsuariosAgregar(int idUsuario)
        {
            InitializeComponent();
            this.idUsuarioParaEditar = idUsuario;
            this.Text = "Editar Usuario";
            txtIdUsuario.Enabled = false;
        }

        private void UsuariosAgregar_Load(object sender, EventArgs e)
        {
            // --- LÓGICA DE PERMISOS ---
            // El empleado asociado a un usuario no se puede cambiar.
            cmbEmpleado.Enabled = false;

            // Si el usuario no es Administrador (rol != 1), no puede cambiar su nombre de usuario.
            if (SesionUsuario.IdRol != 1)
            {
                txtNombreUsuario.Enabled = false;
            }
            // --- FIN LÓGICA DE PERMISOS ---

            if (idUsuarioParaEditar.HasValue)
            {
                CargarTodosLosEmpleados();
                CargarDatosDelUsuario();
            }
            else
            {
                CargarEmpleadosSinUsuario();
                // Si estamos creando un usuario, el admin sí puede elegir el empleado.
                if (SesionUsuario.IdRol == 1)
                {
                    cmbEmpleado.Enabled = true;
                }
            }
        }

        private void CargarDatosDelUsuario()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT NombreUsuario, IdEmpleado FROM usuarios WHERE IdUsuario = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", this.idUsuarioParaEditar);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtIdUsuario.Text = this.idUsuarioParaEditar.ToString();
                            txtNombreUsuario.Text = reader["NombreUsuario"].ToString();
                            txtContraseña.Text = "";
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
                    string query = "SELECT IdEmpleado, CONCAT(Nombre, ' ', Apellido) AS NombreCompleto FROM empleado ORDER BY Apellido, Nombre";
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
                        // Construimos la consulta dinámicamente según los permisos y los campos llenos
                        string setClause = "";
                        if (txtNombreUsuario.Enabled)
                            setClause += "NombreUsuario = @Nombre, ";
                        if (cmbEmpleado.Enabled)
                            setClause += "IdEmpleado = @IdEmpleado, ";
                        if (!string.IsNullOrWhiteSpace(txtContraseña.Text))
                            setClause += "Clave = @Clave, ";

                        if (!string.IsNullOrEmpty(setClause))
                        {
                            setClause = setClause.TrimEnd(',', ' '); // Quitamos la última coma
                            query = $"UPDATE usuarios SET {setClause} WHERE IdUsuario = @IdUsuario";
                        }
                        else
                        {
                            MessageBox.Show("No hay cambios para guardar.");
                            return;
                        }
                    }
                    else // MODO ALTA
                    {
                        query = "INSERT INTO usuarios (NombreUsuario, Clave, IdEmpleado) VALUES (@Nombre, @Clave, @IdEmpleado)";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (txtNombreUsuario.Enabled)
                        cmd.Parameters.AddWithValue("@Nombre", txtNombreUsuario.Text);
                    if (cmbEmpleado.Enabled)
                        cmd.Parameters.AddWithValue("@IdEmpleado", cmbEmpleado.SelectedValue);

                    if (!string.IsNullOrWhiteSpace(txtContraseña.Text))
                    {
                        cmd.Parameters.AddWithValue("@Clave", txtContraseña.Text);
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

