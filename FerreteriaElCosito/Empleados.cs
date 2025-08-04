using FerreteriaElCosito;
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
    public partial class Empleados : Form
    {
        private bool cargandoCombos = false;
        public Empleados()
        {
            InitializeComponent();

            cbidempleado.SelectedIndexChanged += cbidempleado_SelectedIndexChanged;
            cbnombre.SelectedIndexChanged += cbnombre_SelectedIndexChanged;
            cbapellido.SelectedIndexChanged += cbapellido_SelectedIndexChanged;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            cargandoCombos = true;

            // Cargar los datos de los combos (solo las listas, sin seleccionar)
            CargarProvincias();
            CargarLocalidades();
            CargarCategorias();
            CargarDepositos();
            CargarRoles();

            CargarIds();
            CargarNombres();
            CargarApellidos();

            // Limpiar selección de todos los combos
            cbidempleado.SelectedIndex = -1;
            cbidempleado.Text = "";

            cbnombre.SelectedIndex = -1;
            cbnombre.Text = "";

            cbapellido.SelectedIndex = -1;
            cbapellido.Text = "";

            cbprovincia.SelectedIndex = -1;
            cbprovincia.Text = "";

            cblocalidad.SelectedIndex = -1;
            cblocalidad.Text = "";

            cbcategoria.SelectedIndex = -1;
            cbcategoria.Text = "";

            cbiddeposito.SelectedIndex = -1;
            cbiddeposito.Text = "";

            cbidrol.SelectedIndex = -1;
            cbidrol.Text = "";

            // Configurar la fecha de alta con la fecha actual
            dtalta.Format = DateTimePickerFormat.Short;
            dtalta.Value = DateTime.Today;
            dtalta.Enabled = true;

            cargandoCombos = false;
        }

        private void CargarIds()
        {
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                using (MySqlConnection conn = conexionBD.AbrirConexion())
                {
                    string query = "SELECT idEmpleado FROM empleado ORDER BY idEmpleado";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbidempleado.DataSource = dt;
                    cbidempleado.DisplayMember = "idEmpleado";
                    cbidempleado.ValueMember = "idEmpleado";

                    cbidempleado.SelectedIndex = -1;
                    cbidempleado.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar IDs: " + ex.Message);
            }
        }


        private void btnatras_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario actual
            Menuprincipal menu = new Menuprincipal(); // Crear instancia del menú
            menu.Show(); // Mostrar el menú principal
        }

        private void btnrol_Click(object sender, EventArgs e)
        {
            Roles formularioRoles = new Roles(); // Crea una instancia del formulario Roles
            formularioRoles.Show();              // Muestra el formulario de Roles
            this.Hide();
        }

        private void lblhistorialaboral_Click(object sender, EventArgs e)
        {

        }

        private void cbidempleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoCombos) return;

            if (!int.TryParse(cbidempleado.SelectedValue?.ToString(), out int idEmpleado))
                return;

            ConexionBD conexionBD = new ConexionBD();
            try
            {
                cargandoCombos = true;

                using (MySqlConnection conn = conexionBD.AbrirConexion())
                {
                    string query = "SELECT * FROM empleado WHERE idEmpleado = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idEmpleado);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cbnombre.SelectedValue = idEmpleado;
                                cbapellido.SelectedValue = idEmpleado;

                                txtmail.Text = reader["Email"].ToString();
                                txttelefono.Text = reader["Telefono"].ToString();

                                if (int.TryParse(reader["Categoria"].ToString(), out int categoriaId))
                                    cbcategoria.SelectedValue = categoriaId;
                                else
                                    cbcategoria.SelectedIndex = -1;

                                CargarDatosEmpleado(idEmpleado);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleado: " + ex.Message);
            }
            finally
            {
                cargandoCombos = false;
            }
        }

        private void cbnombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoCombos) return;  // Evita loop

            if (!int.TryParse(cbnombre.SelectedValue?.ToString(), out int idEmpleado))
                return;

            cargandoCombos = true;
            try
            {
                cbidempleado.SelectedValue = idEmpleado;

                string apellido = ObtenerApellidoPorId(idEmpleado);
                CargarApellidos(cbnombre.Text);

                int index = cbapellido.FindStringExact(apellido);
                cbapellido.SelectedIndex = (index >= 0) ? index : -1;

                CargarDatosEmpleado(idEmpleado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar por nombre: " + ex.Message);
            }
            finally
            {
                cargandoCombos = false;
            }
        }

        private void cbapellido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoCombos) return;

            if (!int.TryParse(cbapellido.SelectedValue?.ToString(), out int idEmpleado))
                return;

            ConexionBD conexionBD = new ConexionBD();
            try
            {
                cargandoCombos = true;

                cbidempleado.SelectedValue = idEmpleado;

                string nombre = ObtenerNombrePorId(idEmpleado);
                CargarNombres(cbapellido.Text);

                int index = cbnombre.FindStringExact(nombre);
                cbnombre.SelectedIndex = (index >= 0) ? index : -1;

                CargarDatosEmpleado(idEmpleado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar por apellido: " + ex.Message);
            }
            finally
            {
                cargandoCombos = false;
            }
        }



        private void CargarProvincias()
        {
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                using (MySqlConnection conn = conexionBD.AbrirConexion())
                {
                    string query = "SELECT idProvincia, nombreProvincia FROM provincias";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dt.Columns.Add("Display", typeof(string), "Convert(idProvincia, 'System.String') + ' - ' + nombreProvincia");

                    cbprovincia.DataSource = dt;
                    cbprovincia.DisplayMember = "Display";
                    cbprovincia.ValueMember = "idProvincia";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar provincias: " + ex.Message);
            }
        }

        private void CargarLocalidades()
        {
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                using (MySqlConnection conn = conexionBD.AbrirConexion())
                {
                    string query = "SELECT idLocalidad, nombreLocalidad FROM localidades";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dt.Columns.Add("Display", typeof(string), "Convert(idLocalidad, 'System.String') + ' - ' + nombreLocalidad");

                    cblocalidad.DataSource = dt;
                    cblocalidad.DisplayMember = "Display";
                    cblocalidad.ValueMember = "idLocalidad";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar localidades: " + ex.Message);
            }
        }

        private void CargarCategorias()
        {
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                using (MySqlConnection conn = conexionBD.AbrirConexion())
                {
                    string query = "SELECT idCategoria, Descripcion FROM Categoria";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dt.Columns.Add("Display", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        row["Display"] = row["idCategoria"].ToString() + " - " + row["Descripcion"].ToString();
                    }

                    cbcategoria.DataSource = dt;
                    cbcategoria.DisplayMember = "Display";
                    cbcategoria.ValueMember = "idCategoria";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message);
            }
        }
        private void CargarDepositos()
        {
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                using (MySqlConnection conn = conexionBD.AbrirConexion())
                {
                    string query = "SELECT idDeposito, nombreDeposito FROM deposito";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dt.Columns.Add("Display", typeof(string), "Convert(idDeposito, 'System.String') + ' - ' + nombreDeposito");

                    cbiddeposito.DataSource = dt;
                    cbiddeposito.DisplayMember = "Display";
                    cbiddeposito.ValueMember = "idDeposito";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar depósitos: " + ex.Message);
            }
        }


        private void CargarRoles()
        {
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                using (MySqlConnection conn = conexionBD.AbrirConexion())
                {
                    string query = "SELECT idRol, nombreRol FROM roles";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dt.Columns.Add("Display", typeof(string), "Convert(idRol, 'System.String') + ' - ' + nombreRol");

                    cbidrol.DataSource = dt;
                    cbidrol.DisplayMember = "Display";
                    cbidrol.ValueMember = "idRol";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message);
            }
        }

        private void CargarDatosEmpleado(int idEmpleado)
        {
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                using (MySqlConnection conn = conexionBD.AbrirConexion())
                {
                    string query = @"
                SELECT Email, Telefono, CUIT_CUIL, CalleNumero, IdLocalidad, IdProvincia, FechaAlta,
                       Categoria, IdDeposito, IdRol 
                FROM empleado 
                WHERE IdEmpleado = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idEmpleado);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtmail.Text = reader["Email"].ToString();
                                txttelefono.Text = reader["Telefono"].ToString();
                                txtcuil.Text = reader["CUIT_CUIL"].ToString();
                                txtcallenro.Text = reader["CalleNumero"].ToString();

                                cblocalidad.SelectedValue = Convert.ToInt32(reader["IdLocalidad"]);
                                cbprovincia.SelectedValue = Convert.ToInt32(reader["IdProvincia"]);

                                if (reader["FechaAlta"] != DBNull.Value)
                                {
                                    dtalta.Format = DateTimePickerFormat.Short;
                                    dtalta.Value = Convert.ToDateTime(reader["FechaAlta"]);
                                }
                                else
                                {
                                    dtalta.Format = DateTimePickerFormat.Custom;
                                    dtalta.CustomFormat = " ";
                                }

                                if (int.TryParse(reader["Categoria"].ToString(), out int categoriaId))
                                    cbcategoria.SelectedValue = categoriaId;
                                else
                                    cbcategoria.SelectedIndex = -1;

                                if (int.TryParse(reader["IdDeposito"].ToString(), out int depositoId))
                                    cbiddeposito.SelectedValue = depositoId;
                                else
                                    cbiddeposito.SelectedIndex = -1;

                                if (int.TryParse(reader["IdRol"].ToString(), out int rolId))
                                    cbidrol.SelectedValue = rolId;
                                else
                                    cbidrol.SelectedIndex = -1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del empleado: " + ex.Message);
            }
        }

        private void CargarNombres(string apellidoFiltro = "")
        {
            cargandoCombos = true;

            try
            {
                ConexionBD conexionBD = new ConexionBD();

                using (MySqlConnection conn = conexionBD.AbrirConexion())
                {
                    string query = "SELECT idEmpleado, nombre FROM empleado";
                    if (!string.IsNullOrWhiteSpace(apellidoFiltro))
                    {
                        query += " WHERE apellido = @apellido";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(apellidoFiltro))
                        {
                            cmd.Parameters.AddWithValue("@apellido", apellidoFiltro);
                        }

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            cbnombre.DataSource = dt;
                            cbnombre.DisplayMember = "nombre";
                            cbnombre.ValueMember = "idEmpleado";
                            cbnombre.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar nombres: " + ex.Message);
            }
            finally
            {
                cargandoCombos = false;
            }
        }

        private void CargarApellidos(string nombreFiltro = "")
        {
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                using (MySqlConnection conn = conexionBD.AbrirConexion())
                {
                    string query = "SELECT idEmpleado, apellido FROM empleado";
                    if (!string.IsNullOrWhiteSpace(nombreFiltro))
                    {
                        query += " WHERE nombre = @nombre";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(nombreFiltro))
                        {
                            cmd.Parameters.AddWithValue("@nombre", nombreFiltro);
                        }

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            cbapellido.DataSource = dt;
                            cbapellido.DisplayMember = "apellido";
                            cbapellido.ValueMember = "idEmpleado";
                            cbapellido.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar apellidos: " + ex.Message);
            }
        }

        private string ObtenerApellidoPorId(int idEmpleado)
        {
            string apellido = "";
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                using (MySqlConnection conn = conexionBD.AbrirConexion())
                {
                    string query = "SELECT apellido FROM empleado WHERE idEmpleado = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idEmpleado);
                        apellido = cmd.ExecuteScalar()?.ToString();
                    }
                }
            }
            catch
            {
                // Puedes manejar el error aquí si querés
            }

            return apellido;
        }


        private string ObtenerNombrePorId(int idEmpleado)
        {
            string nombre = "";
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                using (MySqlConnection conn = conexionBD.AbrirConexion())
                {
                    string query = "SELECT nombre FROM empleado WHERE idEmpleado = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idEmpleado);
                        nombre = cmd.ExecuteScalar()?.ToString();
                    }
                }
            }
            catch
            {
                // Puedes manejar el error aquí si querés
            }

            return nombre;
        }
        private void btnconsulta_Click(object sender, EventArgs e)
        {
            using (var selector = new SeleccionarEmpleado())
            {
                if (selector.ShowDialog() == DialogResult.OK)
                {
                    int idSeleccionado = selector.IdSeleccionado;

                    // Cargar los datos del empleado con ese ID
                    cbidempleado.SelectedValue = idSeleccionado;

                    // Esto dispara cbidempleado_SelectedIndexChanged automáticamente
                }
            }
        }


        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            cargandoCombos = true;

            // Desconectar eventos para evitar loops
            cbidempleado.SelectedIndexChanged -= cbidempleado_SelectedIndexChanged;
            cbnombre.SelectedIndexChanged -= cbnombre_SelectedIndexChanged;
            cbapellido.SelectedIndexChanged -= cbapellido_SelectedIndexChanged;

            // Limpiar campos
            txtmail.Clear();
            txttelefono.Clear();
            txtcuil.Clear();
            txtcallenro.Clear();

            cbprovincia.SelectedIndex = -1;
            cblocalidad.SelectedIndex = -1;
            cbcategoria.SelectedIndex = -1;
            cbiddeposito.SelectedIndex = -1;
            cbidrol.SelectedIndex = -1;

            dtalta.Format = DateTimePickerFormat.Short;
            dtalta.Value = DateTime.Today;

            // Limpiar y recargar combos principales
            cbidempleado.DataSource = null;
            cbnombre.DataSource = null;
            cbapellido.DataSource = null;

            CargarIds();
            CargarNombres();
            CargarApellidos();

            // Volver a desconectar y limpiar selección
            cbidempleado.SelectedIndex = -1;
            cbnombre.SelectedIndex = -1;
            cbapellido.SelectedIndex = -1;

            // Reconectar eventos
            cbidempleado.SelectedIndexChanged += cbidempleado_SelectedIndexChanged;
            cbnombre.SelectedIndexChanged += cbnombre_SelectedIndexChanged;
            cbapellido.SelectedIndexChanged += cbapellido_SelectedIndexChanged;

            cargandoCombos = false;
        }

        private void dtalta_ValueChanged(object sender, EventArgs e)
        {
            dtalta.Format = DateTimePickerFormat.Short; // Restaura formato si el usuario elige fecha
        }

        private void btnalta_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que nombre y apellido no estén vacíos (puedes agregar más validaciones si querés)
                if (string.IsNullOrWhiteSpace(cbnombre.Text) || string.IsNullOrWhiteSpace(cbapellido.Text))
                {
                    MessageBox.Show("Por favor, ingresá nombre y apellido.");
                    return;
                }

                ConexionBD conexionBD = new ConexionBD();
                using (MySqlConnection conn = conexionBD.AbrirConexion())
                {
                    string query = @"INSERT INTO empleado 
                (nombre, apellido, email, telefono, cuit_cuil, callenumero, idlocalidad, idprovincia, fechaalta, categoria, idDeposito, idRol) 
                VALUES 
                (@Nombre, @Apellido, @Email, @Telefono, @CUIL, @CalleNro, @Localidad, @Provincia, @FechaAlta, @Categoria, @Deposito, @Rol)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", cbnombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@Apellido", cbapellido.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Telefono", txttelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@CUIL", txtcuil.Text.Trim());
                        cmd.Parameters.AddWithValue("@CalleNro", txtcallenro.Text.Trim());
                        cmd.Parameters.AddWithValue("@Localidad", cblocalidad.SelectedValue ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Provincia", cbprovincia.SelectedValue ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@FechaAlta", dtalta.Value.Date);
                        cmd.Parameters.AddWithValue("@Categoria", cbcategoria.SelectedValue ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Deposito", cbiddeposito.SelectedValue ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Rol", cbidrol.SelectedValue ?? DBNull.Value);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Empleado agregado correctamente.");
                            btnlimpiar_Click(null, null);  // Limpia el formulario
                            CargarIds();                    // Actualiza la lista de IDs
                        }
                        else
                        {
                            MessageBox.Show("No se pudo agregar el empleado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar empleado: " + ex.Message);
            }
        }
    }
   
}
