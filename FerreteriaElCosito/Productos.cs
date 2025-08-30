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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                using (var conexion = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT * FROM productos"; // selecciona toda la tabla
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvProductos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                // Obtenemos los datos de la fila seleccionada
                int idProducto = Convert.ToInt32(dgvProductos.CurrentRow.Cells["IdProducto"].Value);
                string nombreProducto = dgvProductos.CurrentRow.Cells["NombreProducto"].Value.ToString();

                // Confirmación
                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el producto \"{nombreProducto}\"?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        using (var conexion = ConexionBD.ObtenerConexion())
                        {
                            string query = "DELETE FROM productos WHERE IdProducto = @IdProducto";
                            using (var cmd = new MySqlCommand(query, conexion))
                            {
                                cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show($"Producto \"{nombreProducto}\" eliminado correctamente.");

                        // Recargar DataGridView automáticamente
                        CargarProductos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto para eliminar.");
            }
        }
    }
}
