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
    public partial class frmbuscarproducto : Form
    {
        // Propiedad pública para almacenar el producto seleccionado.
        // Se usa para pasar datos de este formulario al formulario principal.
        public ProductoSeleccionado ProductoSeleccionado { get; private set; }

        public frmbuscarproducto()
        {
            InitializeComponent();
        }

        private void frmbuscarproducto_Load(object sender, EventArgs e)
        {
            // Cargar todos los productos al iniciar el formulario.
            CargarProductos("");
        }

        // Método para cargar productos desde la base de datos.
        private void CargarProductos(string filtro)
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT IdProducto, NombreProducto, PrecioUnitario FROM productos WHERE NombreProducto LIKE @filtro";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvProductos.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            // Cada vez que el texto en el campo de búsqueda cambia, se filtran los productos.
            CargarProductos(txtbuscar.Text);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                // Obtiene la fila seleccionada del DataGridView.
                DataGridViewRow selectedRow = dgvProductos.SelectedRows[0];

                // Crea el objeto con la información del producto seleccionado.
                ProductoSeleccionado = new ProductoSeleccionado
                {
                    IdProducto = Convert.ToInt32(selectedRow.Cells["IdProducto"].Value),
                    NombreProducto = selectedRow.Cells["NombreProducto"].Value.ToString(),
                    PrecioUnitario = Convert.ToDecimal(selectedRow.Cells["PrecioUnitario"].Value)
                };

                // Establece el resultado del diálogo en OK y cierra este formulario.
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto de la lista.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCrearNuevo_Click(object sender, EventArgs e)
        {
            // Llama a tu formulario de gestión de productos que ya tienes.
            Productos productosForm = new Productos();
            productosForm.ShowDialog();

            // Después de cerrar el formulario de gestión, recarga la lista de productos
            // para que el nuevo producto aparezca en el DataGridView.
            CargarProductos("");
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            // Limpia el campo de búsqueda y recarga todos los productos.
            txtbuscar.Clear();
            CargarProductos("");
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            // Cierra el formulario sin seleccionar nada.
            this.Close();
        }

        // Métodos vacíos que no necesitan código adicional.
        private void lblbuscar_Click(object sender, EventArgs e) { }
        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }

    // La clase ProductoSeleccionado se declara fuera de la clase parcial,
    // pero dentro del mismo namespace para evitar el error de duplicación.
    public class ProductoSeleccionado
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}