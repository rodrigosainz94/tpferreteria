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
            CargarCategorias();
            CargarProveedores();
            CargarUnidadMedida();

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

        private void CargarUnidadMedida()
        {
            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT DISTINCT UnidadMedida FROM productos";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cbUnidadMedida.DataSource = dt;
                    cbUnidadMedida.DisplayMember = "UnidadMedida"; // se muestra en el combo
                    cbUnidadMedida.ValueMember = "UnidadMedida";   // también se usa como valor
                    cbUnidadMedida.SelectedIndex = -1;             // sin selección inicial
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar unidades de medida: " + ex.Message);
            }
        }



        private void CargarCategorias()
        {
            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT idCategoria, Descripcion FROM categoriaproductos";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cbcategoria.DataSource = dt;
                    cbcategoria.DisplayMember = "Descripcion";  // Texto visible
                    cbcategoria.ValueMember = "idCategoria";  // Valor real
                    cbcategoria.SelectedIndex = -1; // No selecciona nada al inicio
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message);
            }
        }

        private void CargarProveedores()
        {
            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    // Concatenamos Nombre y Apellido en una columna llamada "ProveedorCompleto"
                    string query = "SELECT idProveedor, CONCAT(Nombre, ' ', Apellido) AS ProveedorCompleto FROM proveedores";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cbproveedor.DataSource = dt;
                    cbproveedor.DisplayMember = "ProveedorCompleto";  // Mostramos Nombre + Apellido
                    cbproveedor.ValueMember = "idProveedor";          // Valor real
                    cbproveedor.SelectedIndex = -1;                   // No selecciona nada al inicio
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message);
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

        private void btnatras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                int idProducto = Convert.ToInt32(dgvProductos.CurrentRow.Cells["IdProducto"].Value);

                // Abrimos el form de edición pasando el ID
                ProductosEdicion frm = new ProductosEdicion(idProducto);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarProductos(); // refresca el grid después de guardar
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto para editar.");
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que todos los campos estén completos
                if (string.IsNullOrWhiteSpace(txtnombreproducto.Text) ||
                    string.IsNullOrWhiteSpace(txtdescripcionprod.Text) ||
                    cbcategoria.SelectedIndex == -1 ||
                    cbproveedor.SelectedIndex == -1 ||
                    cbUnidadMedida.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtprecio.Text) ||
                    string.IsNullOrWhiteSpace(txtcantidad.Text))
                {
                    MessageBox.Show("⚠️ Complete todos los campos antes de guardar.");
                    return;
                }

                using (var conexion = ConexionBD.ObtenerConexion())
                {
                    string query = @"INSERT INTO productos 
                             (NombreProducto, Descripcion, idCategoria, idProveedor, UnidadMedida, PrecioUnitario, Cantidad)
                             VALUES (@NombreProducto, @Descripcion, @idCategoria, @idProveedor, @UnidadMedida, @Precio, @Cantidad)";

                    using (var cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@NombreProducto", txtnombreproducto.Text);
                        cmd.Parameters.AddWithValue("@Descripcion", txtdescripcionprod.Text);
                        cmd.Parameters.AddWithValue("@idCategoria", cbcategoria.SelectedValue);
                        cmd.Parameters.AddWithValue("@idProveedor", cbproveedor.SelectedValue);
                        cmd.Parameters.AddWithValue("@UnidadMedida", cbUnidadMedida.SelectedValue);
                        cmd.Parameters.AddWithValue("@Precio", Convert.ToDecimal(txtprecio.Text));
                        cmd.Parameters.AddWithValue("@Cantidad", Convert.ToInt32(txtcantidad.Text));

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("✅ Producto guardado correctamente.");

                // Refrescar el DataGridView
                CargarProductos();

                // Limpiar los campos
                txtnombreproducto.Clear();
                txtdescripcionprod.Clear();
                txtprecio.Clear();
                txtcantidad.Clear();
                cbcategoria.SelectedIndex = -1;
                cbproveedor.SelectedIndex = -1;
                cbUnidadMedida.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }


    }
}
