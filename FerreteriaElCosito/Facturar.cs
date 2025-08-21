using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Linq;

namespace FerreteriaElCosito
{
    public partial class Facturar : Form
    {
        private DataTable dtFacturaItems = new DataTable();
        private int? idClienteSeleccionado = null;

        public Facturar()
        {
            InitializeComponent();
        }

        private void Facturar_Load(object sender, EventArgs e)
        {
            ConfigurarGrillaFactura();
            CargarComboProductos();

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
            // Llamamos al método para mover el foco y editar
            MoverFocoACantidad();
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
            dgvfacturacion.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dgvfacturacion.EndEdit();
            dtFacturaItems.AcceptChanges();
            CalcularTotal();
            txtcodigo.Focus();
        }


        // --- MÉTODOS AUXILIARES Y OTROS BOTONES ---

        /// <summary>
        /// MÉTODO REINCORPORADO: Mueve el foco a la celda de Cantidad de la última fila.
        /// </summary>
        private void MoverFocoACantidad()
        {
            int ultimaFila = dgvfacturacion.Rows.Count - 1;
            if (ultimaFila >= 0)
            {
                var celdaCantidad = dgvfacturacion.Rows[ultimaFila].Cells["Cantidad"];
                dgvfacturacion.CurrentCell = celdaCantidad;
                dgvfacturacion.BeginEdit(true);
            }
        }

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

        private void txtdni_KeyDown(object sender, KeyEventArgs e)
        {
            // Verificamos si se presionó Enter y si el campo está lleno
            if (e.KeyCode == Keys.Enter && txtdni.MaskCompleted)
            {
                try
                {
                    using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                    {
                        string query = "SELECT IdCliente, Nombre, Apellido FROM clientes WHERE CUIT_CUIL = @cuit";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@cuit", txtdni.Text);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Si encontramos al cliente, guardamos su ID y mostramos su nombre
                                this.idClienteSeleccionado = Convert.ToInt32(reader["IdCliente"]);
                                string nombreCompleto = $"{reader["Nombre"]} {reader["Apellido"]}";
                                lblnombrecliente.Text = nombreCompleto;
                            }
                            else
                            {
                                // Si no se encuentra, lo indicamos y limpiamos los datos
                                this.idClienteSeleccionado = null;
                                lblnombrecliente.Text = "Cliente no encontrado";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el cliente: " + ex.Message);
                }
            }
        }

        private void txtdni_Click(object sender, EventArgs e)
        {
            // Esta condición revisa si el campo todavía no tiene ningún número ingresado.
            // Usamos .Any() de LINQ para verificar si existe al menos un dígito en el texto.
            if (!txtdni.Text.Any(char.IsDigit))
            {
                // Si está "vacío" (solo tiene espacios y guiones), 
                // movemos el cursor (el punto de inserción) al principio del control.
                txtdni.SelectionStart = 0;
            }
        }

        private void cbconsumidorfinal_CheckedChanged(object sender, EventArgs e)
        {
            if (cbconsumidorfinal.Checked)
            {
                // Si se marca "Consumidor Final"
                txtdni.Enabled = false;
                txtdni.Clear();
                lblnombrecliente.Text = "Consumidor Final";
                // Es una buena práctica tener un cliente genérico en la BD, por ejemplo con ID = 1
                this.idClienteSeleccionado = 1;
            }
            else
            {
                // Si se desmarca
                txtdni.Enabled = true;
                lblnombrecliente.Text = "Nombre cliente"; // Volvemos al texto original
                this.idClienteSeleccionado = null;
                txtdni.Focus();
            }
        }

        private void btnfacturar_Click(object sender, EventArgs e)
        {
            // --- VALIDACIONES ---
            // 1. Validamos que haya productos en la grilla
            if (dtFacturaItems.Rows.Count == 0)
            {
                MessageBox.Show("No se puede generar una factura sin productos.", "Factura Vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validamos que se haya seleccionado un cliente
            if (this.idClienteSeleccionado == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente antes de facturar.", "Falta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- RECOLECCIÓN DE DATOS ---
            string nombreCliente = lblnombrecliente.Text;
            string cuitCliente = txtdni.Text;
            decimal total = Convert.ToDecimal(dtFacturaItems.Compute("SUM([Precio cantidad])", string.Empty));

            // --- LLAMADA A LA VISTA PREVIA ---
            // Creamos una instancia del nuevo formulario y le pasamos todos los datos
            FacturaPreview formularioPreview = new FacturaPreview(nombreCliente, cuitCliente, dtFacturaItems, total);

            // Usamos ShowDialog() para que el formulario de facturación quede en espera
            formularioPreview.ShowDialog();

            // (Opcional) Una vez que se cierra la vista previa, podrías limpiar el formulario de facturación
            // para empezar una nueva venta.
            // LimpiarFactura();
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvfacturacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}