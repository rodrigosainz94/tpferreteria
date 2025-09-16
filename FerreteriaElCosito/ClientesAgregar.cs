using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace FerreteriaElCosito
{
    public partial class ClientesAgregar : Form
    {
        private int? idClienteParaEditar = null;
        public string CuitNuevoCliente { get; private set; }

        public ClientesAgregar()
        {
            InitializeComponent();
            this.Text = "Agregar Nuevo Cliente";
            txtIdCliente.Enabled = false;
        }

        public ClientesAgregar(int idCliente)
        {
            InitializeComponent();
            this.idClienteParaEditar = idCliente;
            this.Text = "Editar Cliente";
            txtIdCliente.Enabled = false;
        }

        private void ClientesAgregar_Load(object sender, EventArgs e)
        {
            // Cargamos los datos de los ComboBox que son independientes
            CargarProvincias();
            CargarCategoriasIva();

            // El ComboBox de localidades empieza deshabilitado
            cbLocalidad.Enabled = false;

            if (idClienteParaEditar.HasValue)
            {
                // Si estamos editando, cargamos los datos del cliente
                CargarDatosDelCliente();
            }
        }

        private void CargarDatosDelCliente()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT * FROM clientes WHERE IdCliente = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", this.idClienteParaEditar);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtIdCliente.Text = reader["IdCliente"].ToString();
                            txtNombre.Text = reader["Nombre"].ToString();
                            txtApellido.Text = reader["Apellido"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                            txtTelefono.Text = reader["Telefono"].ToString();
                            txtCuil.Text = reader["CUIT_CUIL"].ToString();
                            txtDireccion.Text = reader["CalleNumero"].ToString();
                            dtpFechaAlta.Value = Convert.ToDateTime(reader["FechaAlta"]);

                            cbProvincia.SelectedValue = reader["IdProvincia"];
                            cbLocalidad.SelectedValue = reader["IdLocalidad"];
                            cbCategoriaIva.SelectedValue = reader["IdCatIVA"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del cliente: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Aquí deberías agregar una validación de campos vacíos

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "";
                    if (idClienteParaEditar.HasValue)
                    {
                        query = @"UPDATE clientes SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Telefono = @Telefono, 
                                  CUIT_CUIL = @Cuit, CalleNumero = @Direccion, IdLocalidad = @IdLocalidad, 
                                  IdProvincia = @IdProvincia, IdCatIVA = @IdCatIva, FechaAlta = @FechaAlta 
                                  WHERE IdCliente = @IdCliente";
                    }
                    else
                    {
                        query = @"INSERT INTO clientes (Nombre, Apellido, Email, Telefono, CUIT_CUIL, CalleNumero, IdLocalidad, IdProvincia, IdCatIVA, FechaAlta) 
                                  VALUES (@Nombre, @Apellido, @Email, @Telefono, @Cuit, @Direccion, @IdLocalidad, @IdProvincia, @IdCatIva, @FechaAlta)";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@Cuit", txtCuil.Text);
                    cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@IdLocalidad", cbLocalidad.SelectedValue);
                    cmd.Parameters.AddWithValue("@IdProvincia", cbProvincia.SelectedValue);
                    cmd.Parameters.AddWithValue("@IdCatIva", cbCategoriaIva.SelectedValue);
                    cmd.Parameters.AddWithValue("@FechaAlta", dtpFechaAlta.Value);

                    if (idClienteParaEditar.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@IdCliente", idClienteParaEditar.Value);
                    }

                    cmd.ExecuteNonQuery();

                    this.CuitNuevoCliente = txtCuil.Text;
                    MessageBox.Show("Cliente guardado exitosamente.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el cliente: " + ex.Message);
            }
        }

        // --- MÉTODOS PARA CARGAR LOS COMBOBOX ---

        private void CargarProvincias()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT IdProvincia, NombreProvincia FROM provincias ORDER BY NombreProvincia";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbProvincia.DataSource = dt;
                    cbProvincia.DisplayMember = "NombreProvincia"; // El texto que se muestra
                    cbProvincia.ValueMember = "IdProvincia";       // El valor interno (ID)
                    cbProvincia.SelectedIndex = -1;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar provincias: " + ex.Message); }
        }

        private void CargarLocalidades(int idProvincia)
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    // La consulta ahora filtra por el IdProvincia
                    string query = "SELECT IdLocalidad, NombreLocalidad FROM localidades WHERE IdProvincia = @idProvincia ORDER BY NombreLocalidad";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idProvincia", idProvincia);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbLocalidad.DataSource = dt;
                    cbLocalidad.DisplayMember = "NombreLocalidad";
                    cbLocalidad.ValueMember = "IdLocalidad";
                    cbLocalidad.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar localidades: " + ex.Message);
            }
        }

        private void cbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificamos si se ha seleccionado una provincia válida
            if (cbProvincia.SelectedValue != null && cbProvincia.SelectedValue is int)
            {
                // Habilitamos el ComboBox de localidades
                cbLocalidad.Enabled = true;

                // Obtenemos el ID de la provincia seleccionada
                int idProvinciaSeleccionada = (int)cbProvincia.SelectedValue;

                // Cargamos las localidades correspondientes a esa provincia
                CargarLocalidades(idProvinciaSeleccionada);
            }
            else
            {
                // Si no hay provincia seleccionada, limpiamos y deshabilitamos el ComboBox de localidades
                cbLocalidad.DataSource = null;
                cbLocalidad.Enabled = false;
            }
        }

        private void CargarCategoriasIva()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT IdCatIVA, DescripcionIVA FROM categoriaiva ORDER BY DescripcionIVA";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbCategoriaIva.DataSource = dt;
                    cbCategoriaIva.DisplayMember = "DescripcionIVA";
                    cbCategoriaIva.ValueMember = "IdCatIVA";
                    cbCategoriaIva.SelectedIndex = -1;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar categorías de IVA: " + ex.Message); }
        }
    }
}