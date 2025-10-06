using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FerreteriaElCosito
{
    public partial class Facturar : Form
    {
        private DataTable dtFacturaItems = new DataTable();
        private int? idClienteSeleccionado = null;
        private bool _isCalculatingDiscount = false;

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

            dtFacturaItems.Columns.Add("Descuento", typeof(decimal));
            dtFacturaItems.Columns["Descuento"].DefaultValue = 0;

            dtFacturaItems.Columns.Add("Precio cantidad", typeof(decimal), "[Precio unidad] * Cantidad");
            dtFacturaItems.Columns.Add("Precio con descuento", typeof(decimal), "([Precio unidad] * Cantidad) * (1 - Descuento / 100)");

            dgvfacturacion.DataSource = dtFacturaItems;

            if (dgvfacturacion.Columns.Count == 0)
            {
                var colNombre = new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Nombre", DataPropertyName = "Nombre", ReadOnly = true, Width = 200 };
                var colCantidad = new DataGridViewTextBoxColumn { Name = "Cantidad", HeaderText = "Cantidad", DataPropertyName = "Cantidad", ReadOnly = false };
                var colMedida = new DataGridViewTextBoxColumn { Name = "Medida", HeaderText = "Medida", DataPropertyName = "Medida", ReadOnly = true, Width = 80 };
                var colPrecioUnidad = new DataGridViewTextBoxColumn { Name = "PrecioUnidad", HeaderText = "Precio Unidad", DataPropertyName = "Precio unidad", ReadOnly = true, DefaultCellStyle = { Format = "C" } };
                var colDescuento = new DataGridViewTextBoxColumn { Name = "Descuento", HeaderText = "Descuento %", DataPropertyName = "Descuento", ReadOnly = true, DefaultCellStyle = { Format = "N2" } };
                var colPrecioDescuento = new DataGridViewTextBoxColumn { Name = "PrecioConDescuento", HeaderText = "Precio Final", DataPropertyName = "Precio con descuento", ReadOnly = true, DefaultCellStyle = { Format = "C" } };
                dgvfacturacion.Columns.AddRange(new DataGridViewColumn[] { colNombre, colCantidad, colMedida, colPrecioUnidad, colDescuento, colPrecioDescuento });
            }
            dgvfacturacion.AllowUserToAddRows = false;
        }

        public void CargarComboProductos()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = @"SELECT 
                                        IdProducto, 
                                        CONCAT(NombreProducto, ' - Stock: ', Cantidad) AS DisplayNombre 
                                     FROM productos 
                                     WHERE Cantidad > 0 
                                     ORDER BY NombreProducto";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dtProductos = new DataTable();
                    da.Fill(dtProductos);
                    cmbnombre.DataSource = dtProductos;
                    cmbnombre.DisplayMember = "DisplayNombre";
                    cmbnombre.ValueMember = "IdProducto";
                    AjustarAnchoDropDown(cmbnombre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de productos: " + ex.Message);
            }
        }

        public void LimpiarParaNuevaVenta()
        {
            dtFacturaItems.Clear();
            CalcularTotal();
            txtdni.Clear();
            lblnombrecliente.Text = "Nombre cliente";
            this.idClienteSeleccionado = null;
            cbconsumidorfinal.Checked = false;
            CargarComboProductos();
            txtcodigo.Focus();
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
                        string query = "SELECT NombreProducto, UnidadMedida, PrecioUnitario, PorcentajeDto FROM productos WHERE IdProducto = @id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", idProductoBuscado);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DataRow nuevaFila = dtFacturaItems.NewRow();
                                nuevaFila["IdProducto"] = idProductoBuscado;
                                nuevaFila["Nombre"] = reader["NombreProducto"].ToString();
                                nuevaFila["Cantidad"] = 1;
                                nuevaFila["Medida"] = reader["UnidadMedida"].ToString();
                                nuevaFila["Precio unidad"] = Convert.ToDecimal(reader["PrecioUnitario"]);

                                if (reader["PorcentajeDto"] != DBNull.Value)
                                {
                                    nuevaFila["Descuento"] = Convert.ToDecimal(reader["PorcentajeDto"]);
                                }

                                dtFacturaItems.Rows.Add(nuevaFila);
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
            MoverFocoACantidad();
        }

        private void btnfacturar_Click(object sender, EventArgs e)
        {
            if (dtFacturaItems.Rows.Count == 0)
            {
                MessageBox.Show("No se puede generar una factura sin productos.", "Factura Vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.idClienteSeleccionado == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente antes de facturar.", "Falta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = Convert.ToDecimal(dtFacturaItems.Compute("SUM([Precio con descuento])", string.Empty));
            FacturaPreview formularioPreview = new FacturaPreview(this.idClienteSeleccionado, dtFacturaItems.Copy(), total, this);
            formularioPreview.ShowDialog();
        }

        private void btncliente_Click(object sender, EventArgs e)
        {
            using (ClientesAgregar formAgregarCliente = new ClientesAgregar())
            {
                if (formAgregarCliente.ShowDialog() == DialogResult.OK)
                {
                    string nuevoCuit = formAgregarCliente.CuitNuevoCliente;
                    txtdni.Text = nuevoCuit;
                    BuscarClientePorCuit();
                }
            }
        }

        private void BuscarClientePorCuit()
        {
            if (!txtdni.MaskCompleted) return;
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
                            this.idClienteSeleccionado = Convert.ToInt32(reader["IdCliente"]);
                            lblnombrecliente.Text = $"{reader["Nombre"]} {reader["Apellido"]}";
                        }
                        else
                        {
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

        private void txtdni_TextChanged(object sender, EventArgs e)
        {
            if (txtdni.MaskCompleted)
            {
                BuscarClientePorCuit();
            }
        }

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
                CalcularTotal();
                e.Handled = true;
                txtcodigo.Focus();
            }
        }

        private void dgvfacturacion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalcularTotal();
        }

        private void txtdni_Click(object sender, EventArgs e)
        {
            if (!txtdni.Text.Any(char.IsDigit))
            {
                txtdni.SelectionStart = 0;
            }
        }

        private void cbconsumidorfinal_CheckedChanged(object sender, EventArgs e)
        {
            if (cbconsumidorfinal.Checked)
            {
                txtdni.Enabled = false;
                txtdni.Clear();
                lblnombrecliente.Text = "Consumidor Final";
                this.idClienteSeleccionado = 76;
            }
            else
            {
                txtdni.Enabled = true;
                lblnombrecliente.Text = "Nombre cliente";
                this.idClienteSeleccionado = null;
                txtdni.Focus();
            }
        }

        private void dgvfacturacion_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvfacturacion.CurrentRow != null && dgvfacturacion.CurrentRow.DataBoundItem != null)
            {
                _isCalculatingDiscount = true;

                DataRowView drv = (DataRowView)dgvfacturacion.CurrentRow.DataBoundItem;

                // --- INICIO DE CORRECCIÓN DBNull ---
                decimal descuento = drv["Descuento"] != DBNull.Value ? Convert.ToDecimal(drv["Descuento"]) : 0;
                decimal precioConDescuento = drv["Precio con descuento"] != DBNull.Value ? Convert.ToDecimal(drv["Precio con descuento"]) : 0;
                int cantidad = drv["Cantidad"] != DBNull.Value ? Convert.ToInt32(drv["Cantidad"]) : 0;
                // --- FIN DE CORRECCIÓN DBNull ---

                txtDescuento.Text = descuento.ToString("F2");

                if (cantidad > 0)
                {
                    txtNuevoPrecio.Text = (precioConDescuento / cantidad).ToString("F2");
                }
                else
                {
                    txtNuevoPrecio.Clear();
                }

                _isCalculatingDiscount = false;
            }
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            if (_isCalculatingDiscount || dgvfacturacion.CurrentRow == null) return;
            _isCalculatingDiscount = true;

            if (decimal.TryParse(txtDescuento.Text, out decimal porcentaje) && porcentaje >= 0 && porcentaje <= 100)
            {
                DataRowView drv = (DataRowView)dgvfacturacion.CurrentRow.DataBoundItem;
                decimal precioOriginal = Convert.ToDecimal(drv["Precio unidad"]);
                decimal nuevoPrecio = precioOriginal * (1 - (porcentaje / 100));
                txtNuevoPrecio.Text = nuevoPrecio.ToString("F2");
            }
            else
            {
                txtNuevoPrecio.Clear();
            }
            _isCalculatingDiscount = false;
        }

        private void txtNuevoPrecio_TextChanged(object sender, EventArgs e)
        {
            if (_isCalculatingDiscount || dgvfacturacion.CurrentRow == null) return;
            _isCalculatingDiscount = true;

            if (decimal.TryParse(txtNuevoPrecio.Text, out decimal nuevoPrecio))
            {
                DataRowView drv = (DataRowView)dgvfacturacion.CurrentRow.DataBoundItem;
                decimal precioOriginal = Convert.ToDecimal(drv["Precio unidad"]);
                if (precioOriginal > 0 && nuevoPrecio <= precioOriginal)
                {
                    decimal porcentaje = (1 - (nuevoPrecio / precioOriginal)) * 100;
                    txtDescuento.Text = porcentaje.ToString("F2");
                }
                else
                {
                    txtDescuento.Clear();
                }
            }
            else
            {
                txtDescuento.Clear();
            }
            _isCalculatingDiscount = false;
        }

        private void AplicarDescuento()
        {
            if (dgvfacturacion.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un producto de la lista.");
                return;
            }
            if (!decimal.TryParse(txtDescuento.Text, out decimal porcentaje))
            {
                MessageBox.Show("El valor del descuento no es válido.");
                return;
            }
            DataRowView drv = (DataRowView)dgvfacturacion.CurrentRow.DataBoundItem;
            drv.Row["Descuento"] = porcentaje;

            txtDescuento.Clear();
            txtNuevoPrecio.Clear();
            CalcularTotal();
            txtcodigo.Focus();
        }

        private void txtDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AplicarDescuento();
            }
        }

        private void txtNuevoPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AplicarDescuento();
            }
        }

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
                total = Convert.ToDecimal(dtFacturaItems.Compute("SUM([Precio con descuento])", string.Empty));
            }
            txttotal.Text = total.ToString("C");
        }

        private void AjustarAnchoDropDown(ComboBox combo)
        {
            if (combo.DataSource == null) return;
            DataTable dt = (DataTable)combo.DataSource;
            Graphics g = combo.CreateGraphics();
            float maxWidth = 0;
            foreach (DataRow row in dt.Rows)
            {
                float currentWidth = g.MeasureString(row[combo.DisplayMember].ToString(), combo.Font).Width;
                if (currentWidth > maxWidth)
                {
                    maxWidth = currentWidth;
                }
            }
            combo.DropDownWidth = (int)maxWidth + 20;
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

