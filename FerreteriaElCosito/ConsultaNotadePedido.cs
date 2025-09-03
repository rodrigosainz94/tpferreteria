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
    public partial class ConsultaNotadePedido : Form
    {
        public ConsultaNotadePedido()
        {
            InitializeComponent();

            // Conecta el evento de doble clic para abrir el formulario de detalle
            dgvdetallenp.CellDoubleClick += dgvdetallenp_CellDoubleClick;

            // Conecta los eventos click a sus métodos correspondientes
            btnlimpiar.Click += btnlimpiar_Click_1;
            btnatras.Click += btnatras_Click_1;
            btnbuscarnp.Click += btnbuscarnp_Click_1;
        }

        private void ConsultaNotadePedido_Load(object sender, EventArgs e)
        {
            // Configura el DataGridView al cargar el formulario
            dgvdetallenp.ReadOnly = true;
            dgvdetallenp.AllowUserToAddRows = false;
            dgvdetallenp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnlimpiar_Click_1(object sender, EventArgs e)
        {
            // Borra todos los campos de texto
            txtnrocomprobante.Clear();
            txtfecha.Clear();
            txtproveedor.Clear();
            txtproducto.Clear();

            // Limpia los datos del DataGridView
            if (dgvdetallenp.DataSource is DataTable dt)
            {
                dt.Clear();
            }
        }

        private void btnatras_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnbuscarnp_Click_1(object sender, EventArgs e)
        {
            CargarNotasDePedido();
        }

        private void CargarNotasDePedido()
        {
            try
            {
                // Revisa si todos los campos de búsqueda están vacíos
                if (string.IsNullOrEmpty(txtnrocomprobante.Text) &&
                    string.IsNullOrEmpty(txtfecha.Text) &&
                    string.IsNullOrEmpty(txtproveedor.Text) &&
                    string.IsNullOrEmpty(txtproducto.Text))
                {
                    MessageBox.Show("Debe ingresar al menos un criterio de búsqueda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    StringBuilder queryBuilder = new StringBuilder();
                    queryBuilder.Append(@"
                        SELECT
                            c.IdCompra, c.FechaCompra,
                            t.DenominacionComprobante AS 'Tipo Comprobante',
                            c.NumeroComprobante AS 'Nro Comprobante',
                            p.Nombre AS Proveedor,
                            e.Nombre AS Empleado,
                            c.Total
                        FROM compras c
                        INNER JOIN proveedores p ON c.IdProveedor = p.IdProveedor
                        INNER JOIN empleado e ON c.IdEmpleado = e.IdEmpleado
                        INNER JOIN tipocomprobante t ON c.IdTipoComprobante = t.IdTipoComprobante
                        WHERE 1=1 ");

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    // Añade condiciones según los campos llenados
                    if (!string.IsNullOrEmpty(txtnrocomprobante.Text))
                    {
                        queryBuilder.Append(" AND c.NumeroComprobante LIKE @nroComprobante ");
                        cmd.Parameters.AddWithValue("@nroComprobante", $"%{txtnrocomprobante.Text}%");
                    }

                    if (!string.IsNullOrEmpty(txtfecha.Text))
                    {
                        queryBuilder.Append(" AND DATE(c.FechaCompra) = @fecha ");
                        cmd.Parameters.AddWithValue("@fecha", txtfecha.Text);
                    }

                    if (!string.IsNullOrEmpty(txtproveedor.Text))
                    {
                        queryBuilder.Append(" AND LOWER(p.Nombre) LIKE @proveedor ");
                        cmd.Parameters.AddWithValue("@proveedor", $"%{txtproveedor.Text.ToLower()}%");
                    }

                    if (!string.IsNullOrEmpty(txtproducto.Text))
                    {
                        queryBuilder.Append(@" AND c.IdCompra IN (
                            SELECT IdCompra FROM detallecompra d
                            INNER JOIN productos pr ON d.IdProducto = pr.IdProducto
                            WHERE LOWER(pr.NombreProducto) LIKE @producto
                        )");
                        cmd.Parameters.AddWithValue("@producto", $"%{txtproducto.Text.ToLower()}%");
                    }

                    queryBuilder.Append(" ORDER BY c.FechaCompra DESC");

                    cmd.CommandText = queryBuilder.ToString();

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvdetallenp.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron resultados para los criterios de búsqueda.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la búsqueda: " + ex.Message, "Error de búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvdetallenp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvdetallenp.Rows[e.RowIndex];
                object idCompraObj = filaSeleccionada.Cells["IdCompra"].Value;

                if (idCompraObj != null && int.TryParse(idCompraObj.ToString(), out int idCompra))
                {
                    frmnotadepedido frmDetalle = new frmnotadepedido(idCompra);
                    frmDetalle.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el ID de la nota de pedido.", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
