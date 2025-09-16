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
    public partial class frmfacturaproveedor : Form
    {
        private ComprasManager _comprasManager = new ComprasManager();
        private decimal subtotal = 0;
        private decimal iva = 0;
        private decimal total = 0;

        public frmfacturaproveedor()
        {
            InitializeComponent();
            dataGridView1.CellEndEdit += dgvProductos_CellEndEdit;
        }

        private void frmfacturaproveedor_Load(object sender, EventArgs e)
        {
            dtpfecha.Value = DateTime.Now;
            LlenarCombosIniciales();
            ConfigurarDataGridView();
        }

        private void LlenarCombosIniciales()
        {
            try
            {
                // Llenar combo de tipos de comprobante
                DataTable dtTiposComprobante = _comprasManager.ObtenerTiposComprobante();
                cbtcomprobante.DataSource = dtTiposComprobante;
                cbtcomprobante.DisplayMember = "DenominacionComprobante";
                cbtcomprobante.ValueMember = "IdTipoComprobante";
                cbtcomprobante.SelectedIndex = -1;

                // Llenar combo de proveedores (nombre completo)
                DataTable dtProveedores = _comprasManager.ObtenerProveedores();
                cbproveedor.DataSource = dtProveedores;
                cbproveedor.DisplayMember = "NombreCompleto";
                cbproveedor.ValueMember = "IdProveedor";

                // Llenar el ComboBox de ID de proveedor
                DataTable dtProveedoresSoloNombre = _comprasManager.ObtenerProveedoresSoloNombre();
                cbidproveedor.DataSource = dtProveedoresSoloNombre;
                cbidproveedor.DisplayMember = "IdProveedor";
                cbidproveedor.ValueMember = "IdProveedor";

                // Llenar el ComboBox de forma de pago
                DataTable dtFormaPago = _comprasManager.ObtenerFormasDePago();
                cbformadepago.DataSource = dtFormaPago;
                cbformadepago.DisplayMember = "Descripcion";
                cbformadepago.ValueMember = "IdFormaPago";

                // Llenar el ComboBox de tipo de egreso
                DataTable dtTipoMovCaja = _comprasManager.ObtenerTiposMovimientoCaja();
                cbtipoegreso.DataSource = dtTipoMovCaja;
                cbtipoegreso.DisplayMember = "Descripcion";
                cbtipoegreso.ValueMember = "IdTipoMovimientoCaja";

                // Llenar combo de notas de pedido
                DataTable dtNP = _comprasManager.ObtenerNotasDePedido();
                cbnotadepedido.DataSource = dtNP;
                cbnotadepedido.DisplayMember = "NumeroComprobante";
                cbnotadepedido.ValueMember = "IdCompra";

                cbidproveedor.SelectedIndex = -1;
                cbproveedor.SelectedIndex = -1;
                cbnotadepedido.SelectedIndex = -1;
                cbformadepago.SelectedIndex = -1;
                cbtipoegreso.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("IdProducto", "ID Producto");
            dataGridView1.Columns.Add("Producto", "Producto");
            dataGridView1.Columns.Add("Cantidad", "Cantidad");
            dataGridView1.Columns.Add("PrecioUnitario", "Precio Unitario");
            dataGridView1.Columns.Add("Subtotal", "Subtotal");

            dataGridView1.Columns["Cantidad"].ReadOnly = false;
            dataGridView1.Columns["PrecioUnitario"].ReadOnly = false;
            dataGridView1.Columns["IdProducto"].Visible = false;
        }

        private void cbnotadepedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbnotadepedido.SelectedValue != null && cbnotadepedido.SelectedValue is int)
            {
                try
                {
                    int idNotaDePedido = (int)cbnotadepedido.SelectedValue;

                    DataTable dtProveedorNP = _comprasManager.ObtenerProveedorPorNotaDePedido(idNotaDePedido);
                    if (dtProveedorNP != null && dtProveedorNP.Rows.Count > 0)
                    {
                        int idProveedor = Convert.ToInt32(dtProveedorNP.Rows[0]["IdProveedor"]);
                        cbidproveedor.SelectedValue = idProveedor;
                        cbproveedor.SelectedValue = idProveedor;
                    }

                    DataTable dtProductosNP = _comprasManager.ObtenerDetalleNotaDePedido(idNotaDePedido);
                    dataGridView1.Rows.Clear();

                    foreach (DataRow row in dtProductosNP.Rows)
                    {
                        dataGridView1.Rows.Add(
                            Convert.ToInt32(row["IdProducto"]),
                            row["NombreProducto"].ToString(),
                            Convert.ToInt32(row["Cantidad"]),
                            Convert.ToDecimal(row["PrecioUnitario"]),
                            Convert.ToDecimal(row["Subtotal"])
                        );
                    }
                    CalcularTotales();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la nota de pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            frmbuscarproducto buscarProductoForm = new frmbuscarproducto();
            if (buscarProductoForm.ShowDialog() == DialogResult.OK)
            {
                ProductoSeleccionado producto = buscarProductoForm.ProductoSeleccionado;
                dataGridView1.Rows.Add(
                    producto.IdProducto,
                    producto.NombreProducto,
                    1,
                    producto.PrecioUnitario,
                    producto.PrecioUnitario
                );
                CalcularTotales();
            }
        }

        private void btnquitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                CalcularTotales();
            }
        }

        private void dgvProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Cantidad"].Index || e.ColumnIndex == dataGridView1.Columns["PrecioUnitario"].Index)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int cantidad;
                decimal precio;
                if (row.Cells["Cantidad"].Value != null && row.Cells["PrecioUnitario"].Value != null &&
                    int.TryParse(row.Cells["Cantidad"].Value.ToString(), out cantidad) &&
                    decimal.TryParse(row.Cells["PrecioUnitario"].Value.ToString(), out precio))
                {
                    row.Cells["Subtotal"].Value = cantidad * precio;
                    CalcularTotales();
                }
            }
        }

        private void CalcularTotales()
        {
            subtotal = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["Subtotal"].Value != null)
                {
                    subtotal += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                }
            }
            iva = subtotal * 0.21m;
            total = subtotal + iva;
            txtsubtotal.Text = subtotal.ToString("N2");
            txtiva.Text = iva.ToString("N2");
            txttotal.Text = total.ToString("N2");
            txtiibb.Text = "0.00";
        }

        private void btnregistrarfc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtnrocomprobante.Text) || dataGridView1.Rows.Count <= 1)
            {
                MessageBox.Show("Por favor, complete el número de comprobante y agregue al menos un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbformadepago.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione una forma de pago.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbtipoegreso.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione el tipo de egreso.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                List<DetalleCompra> detalles = new List<DetalleCompra>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (row.Cells["IdProducto"].Value == null || string.IsNullOrEmpty(row.Cells["IdProducto"].Value.ToString()))
                    {
                        MessageBox.Show("No se puede registrar la factura. Hay una fila con un ID de producto vacío.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DetalleCompra detalle = new DetalleCompra
                    {
                        IdProducto = Convert.ToInt32(row.Cells["IdProducto"].Value),
                        Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value),
                        PrecioUnitario = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value),
                        Subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value)
                    };
                    detalles.Add(detalle);
                }

                Compra nuevaCompra = new Compra
                {
                    FechaCompra = dtpfecha.Value,
                    IdTipoComprobante = (int)cbtcomprobante.SelectedValue,
                    NumeroComprobante = txtnrocomprobante.Text,
                    IdProveedor = (int)cbidproveedor.SelectedValue,
                    IdEmpleado = 1,
                    Total = Convert.ToDecimal(txttotal.Text)
                };

                int idFormaPago = (int)cbformadepago.SelectedValue;
                int idTipoEgreso = (int)cbtipoegreso.SelectedValue;
                decimal montoPagado = Convert.ToDecimal(txttotal.Text);
                string concepto = cbtipoegreso.Text + " - " + txtnrocomprobante.Text;

                _comprasManager.GuardarFactura(nuevaCompra, detalles, idFormaPago, montoPagado, idTipoEgreso, concepto);

                MessageBox.Show($"Factura registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarFormulario()
        {
            txtnrocomprobante.Clear();
            dataGridView1.Rows.Clear();
            txtsubtotal.Clear();
            txtiva.Clear();
            txtiibb.Clear();
            txttotal.Clear();
            subtotal = 0;
            iva = 0;
            total = 0;
            cbidproveedor.SelectedIndex = -1;
            cbproveedor.SelectedIndex = -1;
            cbnotadepedido.SelectedIndex = -1;
            cbformadepago.SelectedIndex = -1;
            cbtipoegreso.SelectedIndex = -1;
        }

        private void cbtcomprobante_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtnrocomprobante_TextChanged(object sender, EventArgs e) { }
        private void cbidproveedor_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cbproveedor_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtsubtotal_TextChanged(object sender, EventArgs e) { }
        private void txtiva_TextChanged(object sender, EventArgs e) { }
        private void txtiibb_TextChanged(object sender, EventArgs e) { }
        private void txttotal_TextChanged(object sender, EventArgs e) { }
        private void dtpfecha_ValueChanged(object sender, EventArgs e) { }
    }
}
