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
    public partial class Compras : Form
    {
        private int idCompraGenerado;
        private DataTable tablaDetalle;
        private bool cargandoCombos = false;

        private DataTable dtProveedores;
        private DataTable dtEmpleados;
        private DataTable dtProductos;

        public Compras()
        {
            InitializeComponent();

            // Suscribir evento de edición de celdas en el DataGridView
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
        }

        // ================= NUMERO DE COMPROBANTE AUTOMÁTICO =================
        private void GenerarNumeroComprobante()
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT IFNULL(MAX(NumeroComprobante),0) FROM compras";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                object result = cmd.ExecuteScalar();
                int ultimoNumero = Convert.ToInt32(result);
                txtnrocomprobante.Text = (ultimoNumero + 1).ToString();
            }
        }

        // ================= CARGAR FORMULARIO =================
        private void Compras_Load(object sender, EventArgs e)
        {
            // Crear tabla de detalle
            tablaDetalle = new DataTable();
            tablaDetalle.Columns.Add("IdProducto", typeof(int));
            tablaDetalle.Columns.Add("Producto", typeof(string));
            tablaDetalle.Columns.Add("Cantidad", typeof(int));
            tablaDetalle.Columns.Add("PrecioUnitario", typeof(decimal));
            tablaDetalle.Columns.Add("Subtotal", typeof(decimal));

            dataGridView1.DataSource = tablaDetalle;

            // Permitir editar solo PrecioUnitario y Cantidad
            dataGridView1.Columns["PrecioUnitario"].ReadOnly = false;
            dataGridView1.Columns["Cantidad"].ReadOnly = false;
            dataGridView1.Columns["Subtotal"].ReadOnly = true;

            // Cargar combos
            CargarProveedores();
            CargarEmpleados();
            CargarProductos();
            CargarTiposComprobantes();

            // Generar número de comprobante automático
            GenerarNumeroComprobante();
        }

        // ================= PROVEEDORES =================
        private void CargarProveedores()
        {
            cargandoCombos = true;
            using (var conn = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT IdProveedor, Nombre FROM proveedores";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                dtProveedores = new DataTable();
                da.Fill(dtProveedores);

                cbproveedor.DataSource = dtProveedores;
                cbproveedor.DisplayMember = "Nombre";
                cbproveedor.ValueMember = "IdProveedor";
                cbproveedor.SelectedIndex = -1;

                cbidproveedor.DataSource = dtProveedores;
                cbidproveedor.DisplayMember = "IdProveedor";
                cbidproveedor.ValueMember = "IdProveedor";
                cbidproveedor.SelectedIndex = -1;
            }
            cargandoCombos = false;
        }

        private void cbidproveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoCombos) return;
            cargandoCombos = true;
            if (cbidproveedor.SelectedIndex >= 0)
                cbproveedor.SelectedValue = cbidproveedor.SelectedValue;
            else
                cbproveedor.SelectedIndex = -1;
            cargandoCombos = false;
        }

        private void cbproveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoCombos) return;
            cargandoCombos = true;
            if (cbproveedor.SelectedIndex >= 0)
                cbidproveedor.SelectedValue = cbproveedor.SelectedValue;
            else
                cbidproveedor.SelectedIndex = -1;
            cargandoCombos = false;
        }

        // ================= EMPLEADOS =================
        private void CargarEmpleados()
        {
            cargandoCombos = true;
            using (var conn = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT IdEmpleado, Nombre FROM empleado";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                dtEmpleados = new DataTable();
                da.Fill(dtEmpleados);

                cbempleado.DataSource = dtEmpleados;
                cbempleado.DisplayMember = "Nombre";
                cbempleado.ValueMember = "IdEmpleado";
                cbempleado.SelectedIndex = -1;

                cbidempleado.DataSource = dtEmpleados;
                cbidempleado.DisplayMember = "IdEmpleado";
                cbidempleado.ValueMember = "IdEmpleado";
                cbidempleado.SelectedIndex = -1;
            }
            cargandoCombos = false;
        }

        private void cbidempleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoCombos) return;
            cargandoCombos = true;
            if (cbidempleado.SelectedIndex >= 0)
                cbempleado.SelectedValue = cbidempleado.SelectedValue;
            else
                cbempleado.SelectedIndex = -1;
            cargandoCombos = false;
        }

        private void cbempleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoCombos) return;
            cargandoCombos = true;
            if (cbempleado.SelectedIndex >= 0)
                cbidempleado.SelectedValue = cbempleado.SelectedValue;
            else
                cbidempleado.SelectedIndex = -1;
            cargandoCombos = false;
        }

        // ================= PRODUCTOS =================
        private void CargarProductos()
        {
            cargandoCombos = true;
            using (var conn = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT IdProducto, NombreProducto, PrecioUnitario FROM productos";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                dtProductos = new DataTable();
                da.Fill(dtProductos);

                cbproducto.DataSource = dtProductos;
                cbproducto.DisplayMember = "NombreProducto";
                cbproducto.ValueMember = "IdProducto";
                cbproducto.SelectedIndex = -1;

                cbidproducto.DataSource = dtProductos;
                cbidproducto.DisplayMember = "IdProducto";
                cbidproducto.ValueMember = "IdProducto";
                cbidproducto.SelectedIndex = -1;
            }
            cargandoCombos = false;
        }

        private void cbidproducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoCombos) return;
            cargandoCombos = true;
            if (cbidproducto.SelectedIndex >= 0)
                cbproducto.SelectedValue = cbidproducto.SelectedValue;
            else
                cbproducto.SelectedIndex = -1;
            cargandoCombos = false;
        }

        private void cbproducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoCombos) return;
            cargandoCombos = true;
            if (cbproducto.SelectedIndex >= 0)
                cbidproducto.SelectedValue = cbproducto.SelectedValue;
            else
                cbidproducto.SelectedIndex = -1;
            cargandoCombos = false;
        }

        // ================= TIPOS DE COMPROBANTES =================
        private void CargarTiposComprobantes()
        {
            cargandoCombos = true;
            using (var conn = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT IdTipoComprobante, DenominacionComprobante FROM tipocomprobante";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbtcomprobante.DataSource = dt;
                cbtcomprobante.DisplayMember = "DenominacionComprobante";
                cbtcomprobante.ValueMember = "IdTipoComprobante";
                cbtcomprobante.SelectedIndex = -1;
            }
            cargandoCombos = false;
        }

        // ================= DETALLE DE COMPRA =================
        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (cbproducto.SelectedIndex < 0) return;

            DataRowView drv = (DataRowView)cbproducto.SelectedItem;
            int idProducto = Convert.ToInt32(drv["IdProducto"]);
            string nombre = drv["NombreProducto"].ToString();
            decimal precio = Convert.ToDecimal(drv["PrecioUnitario"]);

            string inputCantidad = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la cantidad:", "Cantidad", "1");

            if (int.TryParse(inputCantidad, out int cantidad))
                tablaDetalle.Rows.Add(idProducto, nombre, cantidad, precio, cantidad * precio);
            else
                MessageBox.Show("Cantidad inválida.");
        }

        private void btnquitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }

        // ================= GUARDAR COMPRA =================
        private void btnhacerpedido_Click(object sender, EventArgs e)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string queryCompra = @"INSERT INTO compras 
                        (FechaCompra, IdProveedor, IdEmpleado, IdTipoComprobante, NumeroComprobante, Total) 
                        VALUES (@FechaCompra, @IdProveedor, @IdEmpleado, @IdTipoComprobante, @NumeroComprobante, @Total);
                        SELECT LAST_INSERT_ID();";

                    MySqlCommand cmdCompra = new MySqlCommand(queryCompra, conn, transaction);
                    cmdCompra.Parameters.AddWithValue("@FechaCompra", dtpfecha.Value);
                    cmdCompra.Parameters.AddWithValue("@IdProveedor", cbproveedor.SelectedValue);
                    cmdCompra.Parameters.AddWithValue("@IdEmpleado", cbempleado.SelectedValue);
                    cmdCompra.Parameters.AddWithValue("@IdTipoComprobante", cbtcomprobante.SelectedValue);
                    cmdCompra.Parameters.AddWithValue("@NumeroComprobante", txtnrocomprobante.Text);
                    cmdCompra.Parameters.AddWithValue("@Total", CalcularTotal());

                    idCompraGenerado = Convert.ToInt32(cmdCompra.ExecuteScalar());

                    foreach (DataRow row in tablaDetalle.Rows)
                    {
                        string queryDetalle = @"INSERT INTO detallecompra 
                            (IdCompra, IdProducto, Cantidad, PrecioUnitario, Subtotal) 
                            VALUES (@IdCompra, @IdProducto, @Cantidad, @PrecioUnitario, @Subtotal)";

                        MySqlCommand cmdDetalle = new MySqlCommand(queryDetalle, conn, transaction);
                        cmdDetalle.Parameters.AddWithValue("@IdCompra", idCompraGenerado);
                        cmdDetalle.Parameters.AddWithValue("@IdProducto", row["IdProducto"]);
                        cmdDetalle.Parameters.AddWithValue("@Cantidad", row["Cantidad"]);
                        cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", row["PrecioUnitario"]);
                        cmdDetalle.Parameters.AddWithValue("@Subtotal", row["Subtotal"]);
                        cmdDetalle.ExecuteNonQuery();

                        // Actualizar stock
                        string queryStock = "UPDATE productos SET Cantidad = Cantidad + @Cantidad WHERE IdProducto = @IdProducto";
                        MySqlCommand cmdStock = new MySqlCommand(queryStock, conn, transaction);
                        cmdStock.Parameters.AddWithValue("@Cantidad", row["Cantidad"]);
                        cmdStock.Parameters.AddWithValue("@IdProducto", row["IdProducto"]);
                        cmdStock.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Compra registrada con éxito.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error al guardar la compra: " + ex.Message);
                }
            }
        }

        private decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (DataRow row in tablaDetalle.Rows)
                total += Convert.ToDecimal(row["Subtotal"]);
            return total;
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ================= BOTÓN LIMPIAR =================
        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            cargandoCombos = true;

            cbproveedor.SelectedIndex = -1;
            cbidproveedor.SelectedIndex = -1;
            cbempleado.SelectedIndex = -1;
            cbidempleado.SelectedIndex = -1;
            cbproducto.SelectedIndex = -1;
            cbidproducto.SelectedIndex = -1;
            cbtcomprobante.SelectedIndex = -1;
            dtpfecha.Value = DateTime.Now;

            tablaDetalle.Clear();
            GenerarNumeroComprobante();

            cargandoCombos = false;
        }

        // ================= RECALCULAR SUBTOTAL AL EDITAR =================
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (decimal.TryParse(row.Cells["PrecioUnitario"].Value.ToString(), out decimal precio) &&
                    int.TryParse(row.Cells["Cantidad"].Value.ToString(), out int cantidad))
                {
                    row.Cells["Subtotal"].Value = precio * cantidad;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Puedes dejarlo vacío o cargar datos según tu necesidad
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Normalmente no se usa el Click de una etiqueta
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Captura clic en DataGridView si necesitas
        }
    }
}