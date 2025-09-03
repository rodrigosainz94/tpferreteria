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
    public partial class frmcosultaproveedor : Form
    {
        public int IdProveedorSeleccionado { get; private set; }
        public string NombreProveedorSeleccionado { get; private set; }

        public frmcosultaproveedor()
        {
            InitializeComponent();

            btnatras.Click += btnatras_Click;
            btnlimpiar.Click += btnlimpiar_Click;
            btnconsultarproveedor.Click += btnconsultarproveedor_Click;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
        }

        private void frmcosultaproveedor_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            IdProveedorSeleccionado = -1;
            NombreProveedorSeleccionado = string.Empty;
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtidproveedor.Clear();
            txtNombre.Clear();
            txtapellido.Clear();
            txtlocalidad.Clear();
            txtprovincia.Clear();

            if (dataGridView1.DataSource is DataTable dt)
            {
                dt.Clear();
            }
        }

        private void btnconsultarproveedor_Click(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    StringBuilder queryBuilder = new StringBuilder();
                    queryBuilder.Append(@"
                        SELECT
                            p.IdProveedor,
                            p.Nombre,
                            p.Apellido,
                            l.NombreLocalidad AS Localidad,
                            pr.NombreProvincia AS Provincia
                        FROM proveedores p
                        INNER JOIN localidades l ON p.IdLocalidad = l.IdLocalidad
                        INNER JOIN provincias pr ON p.IdProvincia = pr.IdProvincia
                        WHERE 1=1");

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    if (!string.IsNullOrEmpty(txtidproveedor.Text))
                    {
                        queryBuilder.Append(" AND p.IdProveedor = @idProveedor");
                        cmd.Parameters.AddWithValue("@idProveedor", txtidproveedor.Text);
                    }
                    if (!string.IsNullOrEmpty(txtNombre.Text))
                    {
                        queryBuilder.Append(" AND LOWER(p.Nombre) LIKE @nombre");
                        cmd.Parameters.AddWithValue("@nombre", $"%{txtNombre.Text.ToLower()}%");
                    }
                    if (!string.IsNullOrEmpty(txtapellido.Text))
                    {
                        queryBuilder.Append(" AND LOWER(p.Apellido) LIKE @apellido");
                        cmd.Parameters.AddWithValue("@apellido", $"%{txtapellido.Text.ToLower()}%");
                    }
                    if (!string.IsNullOrEmpty(txtlocalidad.Text))
                    {
                        queryBuilder.Append(" AND LOWER(l.NombreLocalidad) LIKE @localidad");
                        cmd.Parameters.AddWithValue("@localidad", $"%{txtlocalidad.Text.ToLower()}%");
                    }
                    if (!string.IsNullOrEmpty(txtprovincia.Text))
                    {
                        queryBuilder.Append(" AND LOWER(pr.NombreProvincia) LIKE @provincia");
                        cmd.Parameters.AddWithValue("@provincia", $"%{txtprovincia.Text.ToLower()}%");
                    }

                    cmd.CommandText = queryBuilder.ToString();

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron proveedores con los criterios de búsqueda.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar proveedores: " + ex.Message, "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
                object idObj = fila.Cells["IdProveedor"].Value;
                object nombreObj = fila.Cells["Nombre"].Value;

                if (idObj != null && int.TryParse(idObj.ToString(), out int id))
                {
                    IdProveedorSeleccionado = id;
                    NombreProveedorSeleccionado = nombreObj?.ToString() ?? string.Empty;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el ID del proveedor seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}