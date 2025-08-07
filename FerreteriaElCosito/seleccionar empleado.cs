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
    public partial class SeleccionarEmpleado : Form
    {
        public int IdSeleccionado { get; private set; } = -1;

        public SeleccionarEmpleado()
        {
            InitializeComponent();

            // Suscribo el evento para ordenar cuando se clickea en encabezados
            dgvEmpleados.ColumnHeaderMouseClick += dgvEmpleados_ColumnHeaderMouseClick;

            // Cargo la lista inicialmente ordenada por apellido, nombre
            CargarEmpleados("apellido, nombre");
        }

        // Método para cargar empleados con orden dinámico
        private void CargarEmpleados(string orden)
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    // Consulta con ORDER BY variable
                    string query = $"SELECT idEmpleado AS 'ID', apellido AS 'Apellido', nombre AS 'Nombre' FROM empleado ORDER BY {orden}";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Uso DataView para que pueda ordenarse dinámicamente
                    DataView dv = dt.DefaultView;
                    dgvEmpleados.DataSource = dv;

                    dgvEmpleados.ClearSelection();

                    // Habilito el modo de ordenamiento manual para cada columna
                    foreach (DataGridViewColumn col in dgvEmpleados.Columns)
                    {
                        col.SortMode = DataGridViewColumnSortMode.Programmatic;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
            }
        }

        // Evento para ordenar al hacer clic en encabezado
        private void dgvEmpleados_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn columna = dgvEmpleados.Columns[e.ColumnIndex];
            string nombreColumna = columna.Name;

            // Tomo el DataView actual
            DataView dv = (DataView)dgvEmpleados.DataSource;

            // Determino dirección del orden
            string direccionOrden = "ASC";
            if (columna.HeaderCell.SortGlyphDirection == SortOrder.Ascending)
            {
                direccionOrden = "DESC";
            }

            // Cambio el orden en el DataView
            dv.Sort = $"{nombreColumna} {direccionOrden}";

            // Limpio las flechas de ordenamiento
            foreach (DataGridViewColumn c in dgvEmpleados.Columns)
            {
                c.HeaderCell.SortGlyphDirection = SortOrder.None;
            }

            // Pongo la flecha en la columna clickeada
            columna.HeaderCell.SortGlyphDirection = direccionOrden == "ASC" ? SortOrder.Ascending : SortOrder.Descending;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            SeleccionarEmpleadoDesdeFila();
        }

        private void dgvEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvEmpleados.Rows[e.RowIndex].Selected = true;
                SeleccionarEmpleadoDesdeFila();
            }
        }

        private void SeleccionarEmpleadoDesdeFila()
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                var fila = dgvEmpleados.SelectedRows[0];
                IdSeleccionado = Convert.ToInt32(fila.Cells["ID"].Value);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Seleccioná un empleado de la lista.");
            }
        }

        // Puedes eliminar si no usás este evento
        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}