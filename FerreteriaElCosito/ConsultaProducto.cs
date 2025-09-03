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
    public partial class ConsultaProducto : Form
    {
        // Propiedades para almacenar el producto seleccionado
        public int IdProductoSeleccionado { get; private set; }
        public string NombreProductoSeleccionado { get; private set; }

        public ConsultaProducto()
        {
            InitializeComponent();

            // Suscribe los eventos a los métodos
            btnatras.Click += btnatras_Click;
            btnlimpiar.Click += btnlimpiar_Click;
            btnconsultarproducto.Click += btnconsultarproducto_Click;
            dgvproducto.CellDoubleClick += dgvproductos_CellDoubleClick;
        }

        private void ConsultaProducto_Load(object sender, EventArgs e)
        {
            // Configura el DataGridView al cargar el formulario
            dgvproducto.ReadOnly = true;
            dgvproducto.AllowUserToAddRows = false;
            dgvproducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            IdProductoSeleccionado = -1;
            NombreProductoSeleccionado = string.Empty;
        }

        // ================== BOTÓN ATRÁS ==================
        private void btnatras_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ================== BOTÓN LIMPIAR ==================
        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtIdProducto.Clear();
            txtproducto.Clear();
            txtCategoria.Clear();
            txtProveedor.Clear();

            if (dgvproducto.DataSource is DataTable dt)
            {
                dt.Clear();
            }
        }

        // ================== BOTÓN CONSULTAR PRODUCTO ==================
        private void btnconsultarproducto_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }

        // ================== MÉTODO DE BÚSQUEDA ==================
        private void CargarProductos()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    StringBuilder queryBuilder = new StringBuilder();
                    queryBuilder.Append(@"
                        SELECT
                            p.IdProducto,
                            p.NombreProducto,
                            cp.Descripcion AS Categoria,
                            pr.Nombre AS Proveedor,
                            p.UnidadMedida,
                            p.PrecioUnitario
                        FROM productos p
                        INNER JOIN categoriaproductos cp ON p.IdCategoria = cp.idCategoria
                        INNER JOIN proveedores pr ON p.IdProveedor = pr.IdProveedor
                        WHERE 1=1");

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    if (!string.IsNullOrEmpty(txtIdProducto.Text))
                    {
                        queryBuilder.Append(" AND p.IdProducto = @idProducto");
                        cmd.Parameters.AddWithValue("@idProducto", txtIdProducto.Text);
                    }
                    if (!string.IsNullOrEmpty(txtproducto.Text))
                    {
                        queryBuilder.Append(" AND LOWER(p.NombreProducto) LIKE @producto");
                        cmd.Parameters.AddWithValue("@producto", $"%{txtproducto.Text.ToLower()}%");
                    }
                    if (!string.IsNullOrEmpty(txtCategoria.Text))
                    {
                        queryBuilder.Append(" AND LOWER(cp.Descripcion) LIKE @categoria");
                        cmd.Parameters.AddWithValue("@categoria", $"%{txtCategoria.Text.ToLower()}%");
                    }
                    if (!string.IsNullOrEmpty(txtProveedor.Text))
                    {
                        queryBuilder.Append(" AND LOWER(pr.Nombre) LIKE @proveedor");
                        cmd.Parameters.AddWithValue("@proveedor", $"%{txtProveedor.Text.ToLower()}%");
                    }

                    cmd.CommandText = queryBuilder.ToString();

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvproducto.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron productos con los criterios de búsqueda.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar productos: " + ex.Message, "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================== EVENTO DOBLE CLIC EN EL DATAGRIDVIEW ==================
        private void dgvproductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvproducto.Rows[e.RowIndex];
                object idObj = fila.Cells["IdProducto"].Value;
                object nombreObj = fila.Cells["NombreProducto"].Value;

                if (idObj != null && int.TryParse(idObj.ToString(), out int id))
                {
                    IdProductoSeleccionado = id;
                    NombreProductoSeleccionado = nombreObj?.ToString() ?? string.Empty;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el ID del producto seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
