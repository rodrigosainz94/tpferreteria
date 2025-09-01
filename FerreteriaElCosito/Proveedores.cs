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
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvproveedores.CurrentRow != null)
            {
                // Obtenemos los datos de la fila seleccionada
                int idProveedor = Convert.ToInt32(dgvproveedores.CurrentRow.Cells["IdProveedor"].Value);
                string nombreProveedor = dgvproveedores.CurrentRow.Cells["Nombre"].Value.ToString();

                // Mensaje de confirmación
                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro que desea eliminar al proveedor \"{nombreProveedor}\"?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        using (var conexion = ConexionBD.ObtenerConexion())
                        {
                            string query = "DELETE FROM proveedores WHERE IdProveedor = @IdProveedor";
                            using (var cmd = new MySqlCommand(query, conexion))
                            {
                                cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show($"Proveedor \"{nombreProveedor}\" eliminado correctamente.");

                        // Recargar DataGridView
                        CargarProveedores();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor para eliminar.");
            }
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
        private void Proveedores_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            var frm = new ProveedoresEdicion();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarProveedores(); // 🔄 recarga la tabla al volver del form de edición
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (dgvproveedores.CurrentRow != null)
            {
                // Obtenemos los valores de la fila seleccionada
                int idProveedor = Convert.ToInt32(dgvproveedores.CurrentRow.Cells["IdProveedor"].Value);
                string nombre = dgvproveedores.CurrentRow.Cells["Nombre"].Value.ToString();
                string apellido = dgvproveedores.CurrentRow.Cells["Apellido"].Value.ToString();
                string email = dgvproveedores.CurrentRow.Cells["Email"].Value.ToString();
                string telefono = dgvproveedores.CurrentRow.Cells["Telefono"].Value.ToString();
                string cuit = dgvproveedores.CurrentRow.Cells["CUIT_CUIL"].Value.ToString();
                string calle = dgvproveedores.CurrentRow.Cells["Callenumero"].Value.ToString();
                int idLocalidad = Convert.ToInt32(dgvproveedores.CurrentRow.Cells["IdLocalidad"].Value);
                int idProvincia = Convert.ToInt32(dgvproveedores.CurrentRow.Cells["IdProvincia"].Value);
                int idCatIVA = Convert.ToInt32(dgvproveedores.CurrentRow.Cells["IdCatIVA"].Value);
                DateTime fechaAlta = Convert.ToDateTime(dgvproveedores.CurrentRow.Cells["FechaAlta"].Value);

                // Creamos el formulario de edición
                ProveedoresEdicion formEdicion = new ProveedoresEdicion();

                // **Usamos las propiedades públicas, NO los controles directamente**
                formEdicion.IdProveedor = idProveedor;
                formEdicion.Nombre = nombre;
                formEdicion.Apellido = apellido;
                formEdicion.Email = email;
                formEdicion.Telefono = telefono;
                formEdicion.CUIT = cuit;
                formEdicion.Calle = calle;
                formEdicion.IdLocalidad = idLocalidad;
                formEdicion.IdProvincia = idProvincia;
                formEdicion.IdCategoria = idCatIVA;
                formEdicion.FechaAlta = fechaAlta;

                // Mostramos el formulario
                formEdicion.ShowDialog();

                // Recargar el DataGridView después de cerrar
                CargarProveedores();
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor para editar.");
            }
        }

        

        private void btnatras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
