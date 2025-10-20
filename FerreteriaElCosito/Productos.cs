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
                try
                {
                    int idProducto = Convert.ToInt32(dgvProductos.CurrentRow.Cells["IdProducto"].Value);

                    // Validar campos básicos antes de actualizar
                    if (string.IsNullOrWhiteSpace(txtnombreproducto.Text) ||
                        string.IsNullOrWhiteSpace(txtdescripcionprod.Text) ||
                        cbcategoria.SelectedIndex == -1 ||
                        cbproveedor.SelectedIndex == -1 ||
                        cbUnidadMedida.SelectedIndex == -1 ||
                        string.IsNullOrWhiteSpace(txtprecio.Text) ||
                        string.IsNullOrWhiteSpace(txtcantidad.Text) ||
                        string.IsNullOrWhiteSpace(txtstockcritico.Text))
                    {
                        MessageBox.Show("⚠️ Complete todos los campos antes de actualizar.");
                        return;
                    }

                    using (var conexion = ConexionBD.ObtenerConexion())
                    {
                        string query = @"UPDATE productos SET 
                                NombreProducto = @NombreProducto,
                                Descripcion = @Descripcion,
                                idCategoria = @idCategoria,
                                idProveedor = @idProveedor,
                                UnidadMedida = @UnidadMedida,
                                PrecioUnitario = @Precio,
                                Cantidad = @Cantidad,
                                StockCritico = @StockCritico,
                                PorcentajeDto = @PorcentajeDto
                                WHERE IdProducto = @IdProducto";

                        using (var cmd = new MySqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddWithValue("@NombreProducto", txtnombreproducto.Text);
                            cmd.Parameters.AddWithValue("@Descripcion", txtdescripcionprod.Text);
                            cmd.Parameters.AddWithValue("@idCategoria", cbcategoria.SelectedValue);
                            cmd.Parameters.AddWithValue("@idProveedor", cbproveedor.SelectedValue);
                            cmd.Parameters.AddWithValue("@UnidadMedida", cbUnidadMedida.SelectedValue);
                            cmd.Parameters.AddWithValue("@Precio", Convert.ToDecimal(txtprecio.Text));
                            cmd.Parameters.AddWithValue("@Cantidad", Convert.ToInt32(txtcantidad.Text));
                            cmd.Parameters.AddWithValue("@StockCritico", Convert.ToInt32(txtstockcritico.Text));

                            // Si el campo descuento está vacío, se guarda 0
                            decimal descuento = 0;
                            if (!string.IsNullOrWhiteSpace(txtdescuento.Text))
                                descuento = Convert.ToDecimal(txtdescuento.Text);

                            cmd.Parameters.AddWithValue("@PorcentajeDto", descuento);
                            cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("✅ Producto actualizado correctamente.");

                    // Refrescar la grilla
                    CargarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto de la lista para editar.");
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
                    string.IsNullOrWhiteSpace(txtcantidad.Text) ||
                    string.IsNullOrWhiteSpace(txtstockcritico.Text))
                {
                    MessageBox.Show("⚠️ Complete todos los campos antes de guardar.");
                    return;
                }

                using (var conexion = ConexionBD.ObtenerConexion())
                {
                    string query = @"INSERT INTO productos 
                             (NombreProducto, Descripcion, idCategoria, idProveedor, UnidadMedida, PrecioUnitario, Cantidad, StockCritico, PorcentajeDto)
                             VALUES (@NombreProducto, @Descripcion, @idCategoria, @idProveedor, @UnidadMedida, @Precio, @Cantidad, @StockCritico, @PorcentajeDto)";

                    using (var cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@NombreProducto", txtnombreproducto.Text);
                        cmd.Parameters.AddWithValue("@Descripcion", txtdescripcionprod.Text);
                        cmd.Parameters.AddWithValue("@idCategoria", cbcategoria.SelectedValue);
                        cmd.Parameters.AddWithValue("@idProveedor", cbproveedor.SelectedValue);
                        cmd.Parameters.AddWithValue("@UnidadMedida", cbUnidadMedida.SelectedValue);
                        cmd.Parameters.AddWithValue("@Precio", Convert.ToDecimal(txtprecio.Text));
                        cmd.Parameters.AddWithValue("@Cantidad", Convert.ToInt32(txtcantidad.Text));
                        cmd.Parameters.AddWithValue("@StockCritico", Convert.ToInt32(txtstockcritico.Text));
                        cmd.Parameters.AddWithValue("@PorcentajeDto", string.IsNullOrWhiteSpace(txtdescuento.Text) ? 0 : Convert.ToDecimal(txtdescuento.Text));

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
                txtstockcritico.Clear();
                txtdescuento.Clear();
                cbcategoria.SelectedIndex = -1;
                cbproveedor.SelectedIndex = -1;
                cbUnidadMedida.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

                txtnombreproducto.Text = fila.Cells["NombreProducto"].Value.ToString();
                txtdescripcionprod.Text = fila.Cells["Descripcion"].Value.ToString();
                txtprecio.Text = fila.Cells["PrecioUnitario"].Value.ToString();
                txtcantidad.Text = fila.Cells["Cantidad"].Value.ToString();
                txtstockcritico.Text = fila.Cells["StockCritico"].Value.ToString();
                txtdescuento.Text = fila.Cells["PorcentajeDto"].Value.ToString();

                // Si querés también seleccionar los combos correspondientes
                if (fila.Cells["idCategoria"].Value != DBNull.Value)
                    cbcategoria.SelectedValue = fila.Cells["idCategoria"].Value;

                if (fila.Cells["idProveedor"].Value != DBNull.Value)
                    cbproveedor.SelectedValue = fila.Cells["idProveedor"].Value;

                if (fila.Cells["UnidadMedida"].Value != DBNull.Value)
                    cbUnidadMedida.SelectedValue = fila.Cells["UnidadMedida"].Value;
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            // Recorre todos los controles del formulario
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    // Limpia el texto de los TextBox
                    control.Text = string.Empty;
                }
                else if (control is ComboBox combo)
                {
                    // Limpia la selección de los ComboBox
                    combo.SelectedIndex = -1;
                    combo.Text = string.Empty;
                }
            }

            // Limpia la selección del DataGridView (opcional)
            dgvProductos.ClearSelection();
        }

    }
}




