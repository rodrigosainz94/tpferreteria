using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace FerreteriaElCosito
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = @"SELECT 
                                        c.IdCliente AS ID, 
                                        CONCAT(c.Nombre, ' ', c.Apellido) AS Cliente, 
                                        c.Email, 
                                        c.Telefono AS Teléfono, 
                                        c.CUIT_CUIL AS 'CUIT / CUIL', 
                                        c.CalleNumero AS Dirección, 
                                        l.nombreLocalidad AS Localidad, 
                                        p.nombreProvincia AS Provincia, 
                                        iva.DescripcionIVA AS 'Cat. IVA',
                                        c.FechaAlta AS 'Fecha de Alta'
                                     FROM clientes c
                                     LEFT JOIN localidades l ON c.IdLocalidad = l.IdLocalidad
                                     LEFT JOIN provincias p ON c.IdProvincia = p.IdProvincia
                                     LEFT JOIN categoriaiva iva ON c.IdCatIVA = iva.IdCatIVA";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvClientes.DataSource = dt;
                    dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    // *** LÍNEA AGREGADA ***
                    // Esto hace que la grilla sea de solo lectura para el usuario.
                    dgvClientes.ReadOnly = true;

                    dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los clientes: " + ex.Message);
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            using (ClientesAgregar formAgregar = new ClientesAgregar())
            {
                if (formAgregar.ShowDialog() == DialogResult.OK)
                {
                    CargarClientes();
                }
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente para editar.");
                return;
            }

            int idCliente = Convert.ToInt32(dgvClientes.CurrentRow.Cells["ID"].Value);

            using (ClientesAgregar formEditar = new ClientesAgregar(idCliente))
            {
                if (formEditar.ShowDialog() == DialogResult.OK)
                {
                    CargarClientes();
                }
            }
        }

        // Este es el método completo para el botón Eliminar
        private void btneliminar_Click(object sender, EventArgs e)
        {
            // 1. Verificamos que haya una fila seleccionada
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.", "Ningún cliente seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Pedimos confirmación al usuario
            if (MessageBox.Show("¿Está seguro de que desea eliminar este cliente? Esta acción no se puede deshacer.", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // 3. Obtenemos el ID del cliente de la celda "ID"
                int idCliente = Convert.ToInt32(dgvClientes.CurrentRow.Cells["ID"].Value);

                try
                {
                    // 4. Ejecutamos la consulta DELETE
                    using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                    {
                        string query = "DELETE FROM clientes WHERE IdCliente = @id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", idCliente);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Cliente eliminado exitosamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 5. Refrescamos la grilla para que se vea el cambio
                        CargarClientes();
                    }
                }
                catch (Exception ex)
                {
                    // Manejamos el error por si el cliente tiene facturas asociadas y no se puede borrar
                    MessageBox.Show("Error al eliminar el cliente. Es posible que tenga registros asociados.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}