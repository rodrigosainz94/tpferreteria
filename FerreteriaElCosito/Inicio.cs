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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            // Aseguramos que el campo de contraseña comience oculto.
            txtContraseña.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    // --- Paso 1: Buscamos al usuario por su nombre de usuario ---
                    string queryUsuario = "SELECT IdUsuario, Clave, IdEmpleado FROM usuarios WHERE NombreUsuario = @nombreUsuario";
                    MySqlCommand cmdUsuario = new MySqlCommand(queryUsuario, conn);
                    cmdUsuario.Parameters.AddWithValue("@nombreUsuario", txtUsuario.Text);

                    using (MySqlDataReader readerUsuario = cmdUsuario.ExecuteReader())
                    {
                        if (!readerUsuario.Read())
                        {
                            // Si el reader no devuelve ninguna fila, el usuario no existe.
                            MessageBox.Show("El usuario ingresado no existe.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Si el usuario existe, obtenemos su clave y su IdEmpleado
                        string claveGuardada = readerUsuario["Clave"].ToString();
                        int idEmpleado = Convert.ToInt32(readerUsuario["IdEmpleado"]);

                        // --- Paso 2: Verificamos la contraseña ---
                        // Recordá usar la comparación con HASH para mayor seguridad
                        if (claveGuardada != txtContraseña.Text)
                        {
                            MessageBox.Show("La contraseña es incorrecta.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Cerramos el primer reader para poder hacer una nueva consulta
                        readerUsuario.Close();

                        // --- Paso 3: Verificamos el estado del empleado asociado ---
                        string queryEmpleado = "SELECT IdRol, Activo, Nombre, Apellido FROM empleado WHERE IdEmpleado = @idEmpleado";
                        MySqlCommand cmdEmpleado = new MySqlCommand(queryEmpleado, conn);
                        cmdEmpleado.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                        using (MySqlDataReader readerEmpleado = cmdEmpleado.ExecuteReader())
                        {
                            if (readerEmpleado.Read())
                            {
                                bool estaActivo = Convert.ToBoolean(readerEmpleado["Activo"]);
                                if (!estaActivo)
                                {
                                    MessageBox.Show("Este usuario está inactivo y no puede ingresar al sistema.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }

                                // ¡ÉXITO! Todos los controles pasaron.
                                int idRol = Convert.ToInt32(readerEmpleado["IdRol"]);
                                string nombre = readerEmpleado["Nombre"].ToString();
                                string apellido = readerEmpleado["Apellido"].ToString();

                                // Guardamos los datos en nuestra clase de sesión estática
                                SesionUsuario.IniciarSesion(idEmpleado, idRol, nombre, apellido);

                                // Abrimos el menú principal pasándole los datos necesarios
                                Menuprincipal menu = new Menuprincipal(idEmpleado, idRol);
                                menu.Show();
                                this.Hide();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void chkMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            // Si la casilla está marcada, mostramos la contraseña.
            if (chkMostrarContraseña.Checked)
            {
                // Al poner UseSystemPasswordChar en false, el texto se vuelve visible.
                txtContraseña.UseSystemPasswordChar = false;
            }
            else
            {
                // Si no está marcada, la ocultamos.
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        /// <summary>
        /// NUEVO: Maneja el evento de presionar una tecla en el campo de contraseña.
        /// </summary>
        private void txtContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            // Verificamos si la tecla presionada fue "Enter"
            if (e.KeyCode == Keys.Enter)
            {
                // Esta línea evita el sonido "ding" de Windows al presionar Enter
                e.SuppressKeyPress = true;

                // Simulamos un clic en el botón de ingresar (asumiendo que se llama button1)
                button1.PerformClick();
            }
        }
    }
}