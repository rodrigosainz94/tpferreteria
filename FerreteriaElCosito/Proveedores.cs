using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace FerreteriaElCosito
{
    // Clase que representa al proveedor
    public class Proveedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }

    // Clase para manejar la base de datos
    public static class ProveedorDAO
    {
        public static bool AgregarProveedor(Proveedor proveedor)
        {
            try
            {
                using (var conexion = new MySqlConnection(ConexionBD.cadenaConexion))
                {
                    conexion.Open();
                    string sql = "INSERT INTO proveedores (nombre, telefono, direccion) VALUES (@nombre, @telefono, @direccion)";
                    using (var cmd = new MySqlCommand(sql, conexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", proveedor.Nombre);
                        cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono);
                        cmd.Parameters.AddWithValue("@direccion", proveedor.Direccion);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar proveedor: " + ex.Message);
                return false;
            }
        }

        public static bool EditarProveedor(Proveedor proveedor)
        {
            try
            {
                using (var conexion = new MySqlConnection(ConexionBD.cadenaConexion))
                {
                    conexion.Open();
                    string sql = "UPDATE proveedores SET nombre=@nombre, telefono=@telefono, direccion=@direccion WHERE id=@id";
                    using (var cmd = new MySqlCommand(sql, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id", proveedor.Id);
                        cmd.Parameters.AddWithValue("@nombre", proveedor.Nombre);
                        cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono);
                        cmd.Parameters.AddWithValue("@direccion", proveedor.Direccion);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar proveedor: " + ex.Message);
                return false;
            }
        }

        public static bool EliminarProveedor(int id)
        {
            try
            {
                using (var conexion = new MySqlConnection(ConexionBD.cadenaConexion))
                {
                    conexion.Open();
                    string sql = "DELETE FROM proveedores WHERE id=@id";
                    using (var cmd = new MySqlCommand(sql, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar proveedor: " + ex.Message);
                return false;
            }
        }
    }

    // Formulario Proveedores
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            try
            {
                using (var conexion = new MySqlConnection(ConexionBD.cadenaConexion))
                {
                    conexion.Open();
                    string query = "SELECT * FROM proveedores";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvproveedores.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando proveedores: " + ex.Message);
            }
        }

        private void dgvproveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si no vas a usarlo, déjalo vacío
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            ProveedoresEdicion frm = new ProveedoresEdicion(); // Formulario para ingresar datos
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarProveedores(); // Refresca DataGridView
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (dgvproveedores.CurrentRow != null)
            {
               
                // Pasamos los datos directamente al constructor
                ProveedoresEdicion frm = new ProveedoresEdicion();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarProveedores(); // Refresca la grilla
                }
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor para editar.");
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dgvproveedores.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvproveedores.CurrentRow.Cells["id"].Value);
                if (MessageBox.Show("¿Desea eliminar este proveedor?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ProveedorDAO.EliminarProveedor(id))
                        CargarProveedores();
                }
            }
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}//rodri puto
