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
        private DataTable tablaDetalle;
        private bool cargandoCombos = false;

        private DataTable dtProveedores;
        private DataTable dtEmpleados;
        private DataTable dtProductos;

        public Compras()
        {
            InitializeComponent();
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
        }

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
            dataGridView1.Columns["PrecioUnitario"].ReadOnly = false;
            dataGridView1.Columns["Cantidad"].ReadOnly = false;
            dataGridView1.Columns["Subtotal"].ReadOnly = true;

            // Cargar combos
            CargarProveedores();
            CargarEmpleados();
            CargarProductos();
            CargarTiposComprobantes();

            // Generar número de comprobante automático
            int idTipo = ObtenerIdTipoComprobante("Nota de pedido");
            txtnrocomprobante.Text = GenerarNumeroComprobante(idTipo).ToString();
        }

        // ================= METODOS AUXILIARES (con gestión de conexión propia) =================
        private int ObtenerIdTipoComprobante(string denominacion)
        {
            int idTipo = 0;
            using (var conn = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT IdTipoComprobante FROM tipocomprobante WHERE DenominacionComprobante = @denominacion";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@denominacion", denominacion);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        idTipo = Convert.ToInt32(result);
                }
            }
            return idTipo;
        }

        private int GenerarNumeroComprobante(int idTipoComprobante)
        {
            int numero = 0;
            using (var conn = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT IFNULL(MAX(NroComprobante),0) FROM compras WHERE IdTipoComprobante=@idTipoComprobante";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idTipoComprobante", idTipoComprobante);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        numero = Convert.ToInt32(result) + 1;
                    }
                    else
                    {
                        numero = 1;
                    }
                }
            }
            return numero;
        }

        // Métodos auxiliares para la carga de comprobantes (utilizan una conexión abierta)
        private int ObtenerIdTipoComprobanteConexion(string denominacion, MySqlConnection conn)
        {
            int idTipo = 0;
            string query = "SELECT IdTipoComprobante FROM tipocomprobante WHERE DenominacionComprobante = @denominacion";
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@denominacion", denominacion);
                object result = cmd.ExecuteScalar();
                if (result != null) idTipo = Convert.ToInt32(result);
            }
            return idTipo;
        }

        private int GenerarNumeroComprobanteConexion(int idTipoComprobante, MySqlConnection conn)
        {
            int numero = 0;
            string query = "SELECT IFNULL(MAX(NroComprobante),0) FROM compras WHERE IdTipoComprobante=@idTipoComprobante";
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@idTipoComprobante", idTipoComprobante);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    numero = Convert.ToInt32(result) + 1;
                }
                else
                {
                    numero = 1;
                }
            }
            return numero;
        }

        // ================= CARGAR COMBOS (con gestión de conexión propia) =================
        private void CargarProveedores()
        {
            cargandoCombos = true;
            using (var conn = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT IdProveedor, CONCAT(Nombre, ' ', Apellido) AS NombreCompleto FROM proveedores";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                dtProveedores = new DataTable();
                da.Fill(dtProveedores);

                cbproveedor.DataSource = dtProveedores;
                cbproveedor.DisplayMember = "NombreCompleto";
                cbproveedor.ValueMember = "IdProveedor";
                cbproveedor.SelectedIndex = -1;

                cbidproveedor.DataSource = dtProveedores;
                cbidproveedor.DisplayMember = "IdProveedor";
                cbidproveedor.ValueMember = "IdProveedor";
                cbidproveedor.SelectedIndex = -1;
            }
            cargandoCombos = false;
        }

        private void CargarEmpleados()
        {
            cargandoCombos = true;
            using (var conn = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT IdEmpleado, CONCAT(Nombre, ' ', Apellido) AS NombreCompleto FROM empleado";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                dtEmpleados = new DataTable();
                da.Fill(dtEmpleados);

                cbempleado.DataSource = dtEmpleados;
                cbempleado.DisplayMember = "NombreCompleto";
                cbempleado.ValueMember = "IdEmpleado";
                cbempleado.SelectedIndex = -1;

                cbidempleado.DataSource = dtEmpleados;
                cbidempleado.DisplayMember = "IdEmpleado";
                cbidempleado.ValueMember = "IdEmpleado";
                cbidempleado.SelectedIndex = -1;
            }
            cargandoCombos = false;
        }

        private void CargarProductos()
        {
            cargandoCombos = true;
            using (var conn = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT IdProducto, NombreProducto, IFNULL(PrecioUnitario, 0) AS PrecioUnitario FROM productos";
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

        private void CargarTiposComprobantes()
        {
            cargandoCombos = true;
            using (var conn = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT IdTipoComprobante, DenominacionComprobante FROM tipocomprobante WHERE DenominacionComprobante = 'Nota de pedido'";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbtcomprobante.DataSource = dt;
                cbtcomprobante.DisplayMember = "DenominacionComprobante";
                cbtcomprobante.ValueMember = "IdTipoComprobante";

                if (dt.Rows.Count > 0)
                    cbtcomprobante.SelectedIndex = 0;
            }
            cargandoCombos = false;
        }

        // ================= EVENTOS DE SELECCION DE COMBOS =================
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

        // ================= DETALLE =================
        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (cbproducto.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView drv = (DataRowView)cbproducto.SelectedItem;

            // Validaciones al agregar
            if (drv["IdProducto"] == DBNull.Value || drv["IdProducto"] == null)
            {
                MessageBox.Show("El producto seleccionado tiene un IdProducto no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idProducto = Convert.ToInt32(drv["IdProducto"]);

            string nombre = drv["NombreProducto"]?.ToString() ?? "Producto sin nombre";

            if (!decimal.TryParse(drv["PrecioUnitario"]?.ToString(), out decimal precio))
            {
                MessageBox.Show("El precio del producto seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (row.Cells["PrecioUnitario"].Value == null || row.Cells["Cantidad"].Value == null)
                {
                    row.Cells["Subtotal"].Value = 0m;
                    return;
                }

                if (decimal.TryParse(row.Cells["PrecioUnitario"].Value.ToString(), out decimal precio) &&
                    int.TryParse(row.Cells["Cantidad"].Value.ToString(), out int cantidad))
                {
                    row.Cells["Subtotal"].Value = precio * cantidad;
                }
                else
                {
                    MessageBox.Show("Los valores ingresados para Precio Unitario o Cantidad no son válidos. Se restablecerán a 0.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    row.Cells["PrecioUnitario"].Value = 0m;
                    row.Cells["Cantidad"].Value = 0;
                    row.Cells["Subtotal"].Value = 0m;
                }
            }
        }

        // ================= GUARDAR COMPRA (AHORA NOTA DE PEDIDO) =================
        private void btnhacerpedido_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0 || (dataGridView1.Rows.Count == 1 && dataGridView1.Rows[0].IsNewRow))
            {
                MessageBox.Show("No hay productos cargados en la nota de pedido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbidproveedor.SelectedIndex == -1 || cbidproveedor.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor válido para generar la nota de pedido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbidempleado.SelectedIndex == -1 || cbidempleado.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un empleado válido para generar la nota de pedido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCompra = 0;
            MySqlConnection conn = null;
            MySqlTransaction transaction = null;

            try
            {
                conn = ConexionBD.ObtenerConexion();

                // Usamos el objeto de conexión devuelto que ya está abierto
                transaction = conn.BeginTransaction();

                int idTipoComprobante = Convert.ToInt32(cbtcomprobante.SelectedValue);
                string nombreTipoComprobante = cbtcomprobante.Text;
                int nuevoNumero = GenerarNumeroComprobanteConexion(idTipoComprobante, conn);
                txtnrocomprobante.Text = nuevoNumero.ToString();

                // --- CONSULTA CORREGIDA: Incluye explícitamente la columna ESTADO como 'Pendiente' ---
                string queryInsert = @"INSERT INTO compras 
                    (IdProveedor, IdEmpleado, IdTipoComprobante, TipoComprobante, NroComprobante, NumeroComprobante, FechaCompra, Total, Estado) 
                    VALUES (@IdProveedor, @IdEmpleado, @IdTipoComprobante, @TipoComprobante, @NroComprobante, @NumeroComprobante, @FechaCompra, @Total, 'Pendiente');
                    SELECT LAST_INSERT_ID();";

                using (MySqlCommand cmdCompra = new MySqlCommand(queryInsert, conn, transaction))
                {
                    cmdCompra.Parameters.AddWithValue("@IdProveedor", cbidproveedor.SelectedValue);
                    cmdCompra.Parameters.AddWithValue("@IdEmpleado", cbidempleado.SelectedValue);
                    cmdCompra.Parameters.AddWithValue("@IdTipoComprobante", idTipoComprobante);
                    cmdCompra.Parameters.AddWithValue("@TipoComprobante", nombreTipoComprobante);
                    cmdCompra.Parameters.AddWithValue("@NroComprobante", nuevoNumero);
                    cmdCompra.Parameters.AddWithValue("@NumeroComprobante", nuevoNumero.ToString());
                    cmdCompra.Parameters.AddWithValue("@FechaCompra", dtpfecha.Value);

                    decimal total = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow && row.Cells["Subtotal"].Value != null && decimal.TryParse(row.Cells["Subtotal"].Value.ToString(), out decimal subtotal))
                        {
                            total += subtotal;
                        }
                    }
                    cmdCompra.Parameters.AddWithValue("@Total", total);

                    object result = cmdCompra.ExecuteScalar();
                    if (result != null && result != DBNull.Value && int.TryParse(result.ToString(), out idCompra))
                    {
                        // Inserción de la cabecera exitosa
                    }
                    else
                    {
                        throw new Exception("No se pudo obtener el ID de la compra. La inserción de cabecera falló.");
                    }
                }

                // Inserción del detalle de la compra
                string queryDetalle = @"INSERT INTO detallecompra 
                    (IdCompra, IdProducto, Cantidad, PrecioUnitario, Subtotal) 
                    VALUES (@IdCompra, @IdProducto, @Cantidad, @PrecioUnitario, @Subtotal)";

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        using (MySqlCommand cmdDetalle = new MySqlCommand(queryDetalle, conn, transaction))
                        {
                            if (row.Cells["IdProducto"].Value == null || !int.TryParse(row.Cells["IdProducto"].Value.ToString(), out int idProducto) ||
                                row.Cells["Cantidad"].Value == null || !int.TryParse(row.Cells["Cantidad"].Value.ToString(), out int cantidad) ||
                                row.Cells["PrecioUnitario"].Value == null || !decimal.TryParse(row.Cells["PrecioUnitario"].Value.ToString(), out decimal precio) ||
                                row.Cells["Subtotal"].Value == null || !decimal.TryParse(row.Cells["Subtotal"].Value.ToString(), out decimal subtotalValue))
                            {
                                throw new Exception("Error de dato en el detalle: Verifique que todos los campos sean válidos.");
                            }

                            cmdDetalle.Parameters.AddWithValue("@IdCompra", idCompra);
                            cmdDetalle.Parameters.AddWithValue("@IdProducto", idProducto);
                            cmdDetalle.Parameters.AddWithValue("@Cantidad", cantidad);
                            cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", precio);
                            cmdDetalle.Parameters.AddWithValue("@Subtotal", subtotalValue);
                            cmdDetalle.ExecuteNonQuery();
                        }
                    }
                }

                transaction.Commit();

                MessageBox.Show("Nota de pedido generada correctamente con número: " + nuevoNumero, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir el formulario de visualización de NP
                frmnotadepedido frm = new frmnotadepedido(idCompra);
                frm.Show();

                // Limpiar y preparar para una nueva NP
                tablaDetalle.Clear();
                int idTipoRefresh = ObtenerIdTipoComprobante("Nota de pedido");
                txtnrocomprobante.Text = GenerarNumeroComprobante(idTipoRefresh).ToString();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("Error al generar la nota de pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn?.Close();
            }
        }

        // ================= LIMPIAR FORMULARIO =================
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

            int idTipo = ObtenerIdTipoComprobante("Nota de pedido");
            txtnrocomprobante.Text = GenerarNumeroComprobante(idTipo).ToString();
            cargandoCombos = false;
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ================= OTROS EVENTOS Y LÓGICA =================
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void btnconsultanp_Click(object sender, EventArgs e) { }
        private void btnconsultaproveedor_Click(object sender, EventArgs e) { }
        private void btnconsultaproducto_Click(object sender, EventArgs e) { }
        private void lblnrocomprobante_Click(object sender, EventArgs e) { }
        private void txtnrocomprobante_TextChanged(object sender, EventArgs e) { }
    }
}