using FerreteriaElCosito;
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
    public partial class Roles : Form
    {
        public class Rol
        {
            public int IdRol { get; set; }
            public string NombreRol { get; set; }
            public override string ToString() => NombreRol;
        }

        private List<Rol> roles = new List<Rol>();

        public Roles()
        {
            InitializeComponent();

            cbidrol.DropDownStyle = ComboBoxStyle.DropDownList;
            cbnombrerol.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir

            cbidrol.SelectedIndexChanged += Cbidrol_SelectedIndexChanged;
            cbnombrerol.SelectedIndexChanged += Cbnombrerol_SelectedIndexChanged;
        }

        private void Roles_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void CargarRoles()
        {
            try
            {
                roles.Clear();

                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT IdRol, NombreRol FROM roles ORDER BY IdRol";
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rol rol = new Rol
                            {
                                IdRol = reader.GetInt32("IdRol"),
                                NombreRol = reader.GetString("NombreRol")
                            };
                            roles.Add(rol);
                        }
                    }
                }

                cbidrol.Items.Clear();
                cbnombrerol.Items.Clear();

                foreach (var rol in roles)
                {
                    cbidrol.Items.Add(rol.IdRol);
                    cbnombrerol.Items.Add(rol.NombreRol);
                }

                cbidrol.SelectedIndex = -1;
                cbnombrerol.SelectedIndex = -1;
                txtDescripcion.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message);
            }
        }

        private void Cbidrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbidrol.SelectedIndex >= 0 && cbidrol.SelectedIndex < cbnombrerol.Items.Count)
            {
                cbnombrerol.SelectedIndex = cbidrol.SelectedIndex;
                int idSeleccionado = (int)cbidrol.SelectedItem;
                CargarDescripcion(idSeleccionado);
            }
        }

        private void Cbnombrerol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbnombrerol.SelectedIndex >= 0 && cbnombrerol.SelectedIndex < cbidrol.Items.Count)
            {
                cbidrol.SelectedIndex = cbnombrerol.SelectedIndex;
                int idSeleccionado = (int)cbidrol.SelectedItem;
                CargarDescripcion(idSeleccionado);
            }
        }

        private void CargarDescripcion(int idRol)
        {
            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT Descripcion FROM roles WHERE IdRol = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idRol);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion"))
                                    ? ""
                                    : reader.GetString("Descripcion");
                                txtDescripcion.Text = descripcion;
                            }
                            else
                            {
                                txtDescripcion.Clear();
                                MessageBox.Show("Rol no encontrado.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar descripción: " + ex.Message);
            }
        }

        private void btnconsulta_Click(object sender, EventArgs e)
        {
            if (cbidrol.SelectedIndex >= 0)
            {
                int idSeleccionado = (int)cbidrol.SelectedItem;
                CargarDescripcion(idSeleccionado);
            }
            else
            {
                MessageBox.Show("Seleccioná un rol.");
            }
        }

        private void btnalta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbnombrerol.Text) || string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Completá todos los campos para dar de alta un rol.");
                return;
            }

            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = "INSERT INTO roles (NombreRol, Descripcion) VALUES (@nombre, @descripcion)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", cbnombrerol.Text);
                        cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);

                        int resultado = cmd.ExecuteNonQuery();

                        if (resultado > 0)
                        {
                            MessageBox.Show("Rol registrado con éxito.");
                            CargarRoles();
                            cbnombrerol.SelectedIndex = -1;
                            cbidrol.SelectedIndex = -1;
                            txtDescripcion.Clear();
                            cbnombrerol.Focus();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo registrar el rol.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar rol: " + ex.Message);
            }
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            this.Hide();
            Empleados empleados = new Empleados();
            empleados.FormClosed += (s, args) => this.Close();
            empleados.Show();
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            cbnombrerol.Text = string.Empty;
            cbidrol.SelectedIndex = -1;
            cbnombrerol.SelectedIndex = -1;
            txtDescripcion.Clear();
            CargarRoles();
            cbnombrerol.Focus();
        }

        private void btnbaja_Click(object sender, EventArgs e)
        {
            if (cbidrol.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un rol a eliminar.");
                return;
            }

            int idSeleccionado;
            if (cbidrol.SelectedItem is int id)
                idSeleccionado = id;
            else if (!int.TryParse(cbidrol.SelectedItem.ToString(), out idSeleccionado))
            {
                MessageBox.Show("No se pudo obtener el ID del rol seleccionado.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "¿Estás segura que querés eliminar este rol?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string verificarUso = "SELECT COUNT(*) FROM empleado WHERE IdRol = @id";
                    using (var cmdVerificar = new MySqlCommand(verificarUso, conn))
                    {
                        cmdVerificar.Parameters.AddWithValue("@id", idSeleccionado);
                        int enUso = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                        if (enUso > 0)
                        {
                            MessageBox.Show("No se puede eliminar el rol porque está asignado a empleados.");
                            return;
                        }
                    }

                    string query = "DELETE FROM roles WHERE IdRol = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idSeleccionado);
                        int resultado = cmd.ExecuteNonQuery();

                        if (resultado > 0)
                        {
                            MessageBox.Show("Rol eliminado exitosamente.");
                            cbnombrerol.Text = "";
                            txtDescripcion.Clear();
                            cbidrol.SelectedIndex = -1;
                            cbnombrerol.SelectedIndex = -1;
                            CargarRoles();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el rol.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el rol:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnmodificacion_Click_1(object sender, EventArgs e)
        {
            if (cbidrol.SelectedIndex < 0
                || string.IsNullOrWhiteSpace(cbnombrerol.Text)
                || string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Completá todos los campos para modificar un rol.");
                return;
            }

            int idSeleccionado = (int)cbidrol.SelectedItem;

            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = "UPDATE roles SET NombreRol = @nombre, Descripcion = @desc WHERE IdRol = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", cbnombrerol.Text);
                        cmd.Parameters.AddWithValue("@desc", txtDescripcion.Text);
                        cmd.Parameters.AddWithValue("@id", idSeleccionado);

                        int resultado = cmd.ExecuteNonQuery();

                        if (resultado > 0)
                        {
                            MessageBox.Show("Rol modificado.");
                            CargarRoles();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo modificar el rol.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message);
            }
        }
    }
}










