using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FerreteriaElCosito
{
    public partial class Facturar : Form
    {
        private DataTable dtFacturaItems = new DataTable();

        public Facturar()
        {
            InitializeComponent();
        }

        private void Facturar_Load(object sender, EventArgs e)
        {
            ConfigurarGrillaFactura();
            CargarComboProductos(); // Cargamos el nuevo ComboBox

            // Dejamos los campos de entrada listos
            lblfecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            cmbnombre.SelectedIndex = -1;
            this.ActiveControl = txtcodigo;
        }

        private void ConfigurarGrillaFactura()
        {
            dgvfacturacion.AutoGenerateColumns = false;

            dtFacturaItems.Columns.Add("IdProducto", typeof(int));
            dtFacturaItems.Columns.Add("Nombre", typeof(string));
            dtFacturaItems.Columns.Add("Cantidad", typeof(int));
            dtFacturaItems.Columns.Add("Medida", typeof(string));
            dtFacturaItems.Columns.Add("Precio unidad", typeof(decimal));
            dtFacturaItems.Columns.Add("Precio cantidad", typeof(decimal), "[Precio unidad] * Cantidad");

            dgvfacturacion.DataSource = dtFacturaItems;

            if (dgvfacturacion.Columns.Count == 0)
            {
                var colNombre = new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Nombre", DataPropertyName = "Nombre", ReadOnly = true, Width = 200 };
                var colCantidad = new DataGridViewTextBoxColumn { Name = "Cantidad", HeaderText = "Cantidad", DataPropertyName = "Cantidad", ReadOnly = false };
                var colMedida = new DataGridViewTextBoxColumn { Name = "Medida", HeaderText = "Medida", DataPropertyName = "Medida", ReadOnly = true, Width = 80 };
                var colPrecioUnidad = new DataGridViewTextBoxColumn { Name = "PrecioUnidad", HeaderText = "Precio Unidad", DataPropertyName = "Precio unidad", ReadOnly = true, DefaultCellStyle = { Format = "C" } };
                var colPrecioCantidad = new DataGridViewTextBoxColumn { Name = "PrecioCantidad", HeaderText = "Precio Cantidad", DataPropertyName = "Precio cantidad", ReadOnly = true, DefaultCellStyle = { Format = "C" } };

                dgvfacturacion.Columns.AddRange(new DataGridViewColumn[] { colNombre, colCantidad, colMedida, colPrecioUnidad, colPrecioCantidad });
            }

            dgvfacturacion.AllowUserToAddRows = false;
        }

        /// <summary>
        /// NUEVO: Carga los productos en el ComboBox de nombres.
        /// </summary>
        private void CargarComboProductos()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT IdProducto, NombreProducto FROM productos ORDER BY NombreProducto";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dtProductos = new DataTable();
                    da.Fill(dtProductos);

                    cmbnombre.DataSource = dtProductos;
                    cmbnombre.DisplayMember = "NombreProducto";
                    cmbnombre.ValueMember = "IdProducto";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de productos: " + ex.Message);
            }
        }

        /// <summary>
        /// MODIFICADO: Ahora maneja tanto el código como el ComboBox.
        /// </summary>
        private void btnagregar_Click(object sender, EventArgs e)
        {
            int idProductoBuscado = 0;

            if (!string.IsNullOrWhiteSpace(txtcodigo.Text))
            {
                if (!int.TryParse(txtcodigo.Text, out idProductoBuscado))
                {
                    MessageBox.Show("El código de producto debe ser un número válido.");
                    return;
                }
            }
            else if (cmbnombre.SelectedValue != null)
            {
                idProductoBuscado = Convert.ToInt32(cmbnombre.SelectedValue);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un código o seleccione un producto de la lista.");
                return;
            }

            DataRow filaExistente = dtFacturaItems.AsEnumerable().FirstOrDefault(row => (int)row["IdProducto"] == idProductoBuscado);
            if (filaExistente != null)
            {
                filaExistente["Cantidad"] = (int)filaExistente["Cantidad"] + 1;
            }
            else
            {
                try
                {
                    using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                    {
                        string query = "SELECT NombreProducto, UnidadMedida, PrecioUnitario FROM productos WHERE IdProducto = @id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", idProductoBuscado);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                dtFacturaItems.Rows.Add(idProductoBuscado, reader["NombreProducto"].ToString(), 1, reader["UnidadMedida"].ToString(), Convert.ToDecimal(reader["PrecioUnitario"]));
                            }
                            else
                            {
                                MessageBox.Show("Producto no encontrado.");
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar producto: " + ex.Message);
                    return;
                }
            }

            CalcularTotal();
            txtcodigo.Clear();
            cmbnombre.SelectedIndex = -1;
            txtcodigo.Focus();
        }

        // --- MANEJO DE TECLADO ---

        private void txtcodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnagregar.PerformClick();
            }
        }

        /// <summary>
        /// NUEVO: Maneja la tecla Enter para el ComboBox.
        /// </summary>
        private void cmbnombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnagregar.PerformClick();
            }
        }

        private void dgvfacturacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgvfacturacion.CurrentCell != null && dgvfacturacion.CurrentCell.OwningColumn.Name == "Cantidad")
            {
                dgvfacturacion.EndEdit();
                e.Handled = true;
                txtcodigo.Focus();
            }
        }

        private void dgvfacturacion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalcularTotal();
        }

        // --- MÉTODOS AUXILIARES Y OTROS BOTONES ---

        private void CalcularTotal()
        {
            decimal total = 0;
            if (dtFacturaItems.Rows.Count > 0)
            {
                total = Convert.ToDecimal(dtFacturaItems.Compute("SUM([Precio cantidad])", string.Empty));
            }
            txttotal.Text = total.ToString("C");
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dgvfacturacion.CurrentRow != null && !dgvfacturacion.CurrentRow.IsNewRow)
            {
                dgvfacturacion.Rows.Remove(dgvfacturacion.CurrentRow);
                CalcularTotal();
            }
            else
            {
                MessageBox.Show("Seleccione un producto de la lista para eliminar.");
            }
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}