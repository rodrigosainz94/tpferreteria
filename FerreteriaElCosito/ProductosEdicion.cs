using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace FerreteriaElCosito
{
    public partial class ProductosEdicion : Form
    {
        private int _idProducto;  // Guardamos el ID del producto a editar

        public ProductosEdicion(int idProducto)
        {
            InitializeComponent();
            _idProducto = idProducto;
        }

        private void ProductosEdicion_Load(object sender, EventArgs e)
        {
            // Mostramos el ID del producto en un TextBox bloqueado
            txtIdProducto.Text = _idProducto.ToString();
            txtIdProducto.ReadOnly = true; // No se puede editar

            CargarDatosProducto();
        }


        private void CargarDatosProducto()
        {
            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = @"SELECT NombreProducto, Descripcion, IdCategoria, IdProveedor, UnidadMedida, PrecioUnitario
                                     FROM productos WHERE IdProducto = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", _idProducto);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtNombre.Text = reader["NombreProducto"].ToString();
                            txtDescripcion.Text = reader["Descripcion"].ToString();
                            txtIdCategoria.Text = reader["IdCategoria"].ToString();
                            txtIdProveedor.Text = reader["IdProveedor"].ToString();
                            txtUnidadMedida.Text = reader["UnidadMedida"].ToString();
                            txtPrecioUnitario.Text = reader["PrecioUnitario"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar producto: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = @"UPDATE productos SET 
                                        NombreProducto=@nombre, 
                                        Descripcion=@desc, 
                                        IdCategoria=@idCat, 
                                        IdProveedor=@idProv,
                                        UnidadMedida=@unidad,
                                        PrecioUnitario=@precio
                                     WHERE IdProducto=@id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@desc", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@idCat", Convert.ToInt32(txtIdCategoria.Text));
                    cmd.Parameters.AddWithValue("@idProv", Convert.ToInt32(txtIdProveedor.Text));
                    cmd.Parameters.AddWithValue("@unidad", txtUnidadMedida.Text);
                    cmd.Parameters.AddWithValue("@precio", Convert.ToDecimal(txtPrecioUnitario.Text));
                    cmd.Parameters.AddWithValue("@id", _idProducto);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Producto actualizado correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK; // Para refrescar el DataGridView
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra sin guardar
        }
    }
}

