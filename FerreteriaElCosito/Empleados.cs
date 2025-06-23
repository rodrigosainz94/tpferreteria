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

            CargarProvincias();
            CargarLocalidades();
            CargarCategorias();
            CargarDepositos();
            CargarRoles();

            CargarIds();
            CargarNombres();
            CargarApellidos();

            cbidempleado.SelectedIndex = -1;
            cbnombre.SelectedIndex = -1;
            cbapellido.SelectedIndex = -1;

            cargandoCombos = false;
        }

        private void CargarIds()
        {
            ConexionBD conexionBD = new ConexionBD();
            MySqlConnection conn = conexionBD.AbrirConexion();

            try
            {
                string query = "SELECT idEmpleado FROM empleado";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbidempleado.DataSource = dt;
                cbidempleado.DisplayMember = "idEmpleado";
                cbidempleado.ValueMember = "idEmpleado";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar IDs: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
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
            if (cargandoCombos || cbidempleado.SelectedValue == null || cbidempleado.SelectedValue is DataRowView)
                return;

            cargandoCombos = true;
            var id = Convert.ToInt32(cbidempleado.SelectedValue);
            cbnombre.SelectedValue = id;
            cbapellido.SelectedValue = id;
            CargarDatosEmpleado(id);
            cargandoCombos = false;
        }

        private void cbnombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoCombos || cbnombre.SelectedValue == null || cbnombre.SelectedValue is DataRowView)
                return;

            if (int.TryParse(cbnombre.SelectedValue.ToString(), out int idEmpleado))
            {
                cargandoCombos = true;

                cbidempleado.SelectedValue = idEmpleado;

                // Obtener apellido por ese ID para cargar sólo apellidos que coincidan
                string apellido = ObtenerApellidoPorId(idEmpleado);
                CargarApellidos(cbnombre.Text);  // Filtro por nombre actual

                cbapellido.SelectedIndex = cbapellido.FindStringExact(apellido);

                CargarDatosEmpleado(idEmpleado);
                cargandoCombos = false;
            }
        }

        private void cbapellido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoCombos || cbapellido.SelectedValue == null || cbapellido.SelectedValue is DataRowView)
                return;

            if (int.TryParse(cbapellido.SelectedValue.ToString(), out int idEmpleado))
            {
                cargandoCombos = true;

                cbidempleado.SelectedValue = idEmpleado;

                // Obtener nombre por ese ID para cargar sólo nombres que coincidan
                string nombre = ObtenerNombrePorId(idEmpleado);
                CargarNombres(cbapellido.Text);  // Filtro por apellido actual

                cbnombre.SelectedIndex = cbnombre.FindStringExact(nombre);

                CargarDatosEmpleado(idEmpleado);
                cargandoCombos = false;
            }
        }


        private void CargarProvincias()
        {
            ConexionBD conexionBD = new ConexionBD();
            MySqlConnection conn = conexionBD.AbrirConexion();

            try
            {
                string query = "SELECT idProvincia, nombreProvincia FROM provincias";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // CORREGIDA: expresión compatible con C#
                dt.Columns.Add("Display", typeof(string), "Convert(idProvincia, 'System.String') + ' - ' + nombreProvincia");

                cbprovincia.DataSource = dt;
                cbprovincia.DisplayMember = "Display";
                cbprovincia.ValueMember = "idProvincia";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar provincias: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        private void CargarLocalidades()
        {
            ConexionBD conexionBD = new ConexionBD();
            MySqlConnection conn = conexionBD.AbrirConexion();

            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar localidades: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }
        private void CargarCategorias()
        {
            ConexionBD conexionBD = new ConexionBD();
            MySqlConnection conn = conexionBD.AbrirConexion();

            try
            {
                string query = "SELECT idCategoria, Descripcion FROM Categoria";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dt.Columns.Add("Display", typeof(string), "Convert(idCategoria, 'System.String') + ' - ' + Descripcion");

                cbcategoria.DataSource = dt;
                cbcategoria.DisplayMember = "Display";
                cbcategoria.ValueMember = "idCategoria";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }
        private void CargarDepositos()
        {
            ConexionBD conexionBD = new ConexionBD();
            MySqlConnection conn = conexionBD.AbrirConexion();

            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar depósitos: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        private void CargarRoles()
        {
            ConexionBD conexionBD = new ConexionBD();
            MySqlConnection conn = conexionBD.AbrirConexion();

            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }
        private void CargarDatosEmpleado(int idEmpleado)
        {
            ConexionBD conexionBD = new ConexionBD();
            MySqlConnection conn = conexionBD.AbrirConexion();

            try
            {
                string query = "SELECT * FROM empleado WHERE idEmpleado = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idEmpleado);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtmail.Text = reader["email"].ToString();
                    txttelefono.Text = reader["telefono"].ToString();
                    txtcuil.Text = reader["cuit_cuil"].ToString();
                    txtcallenro.Text = reader["callenumero"].ToString();
                    cblocalidad.SelectedValue = Convert.ToInt32(reader["idlocalidad"]);
                    cbprovincia.SelectedValue = Convert.ToInt32(reader["idprovincia"]);
                    dtalta.Value = Convert.ToDateTime(reader["fechaalta"]);

                    if (int.TryParse(reader["categoria"].ToString(), out int categoriaId))
                        cbcategoria.SelectedValue = categoriaId;
                    else
                        cbcategoria.SelectedIndex = -1;

                    if (int.TryParse(reader["idDeposito"].ToString(), out int depositoId))
                        cbiddeposito.SelectedValue = depositoId;
                    else
                        cbiddeposito.SelectedIndex = -1;

                    if (int.TryParse(reader["idRol"].ToString(), out int rolId))
                        cbidrol.SelectedValue = rolId;
                    else
                        cbidrol.SelectedIndex = -1;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del empleado: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        private void CargarNombres(string apellidoFiltro = "")
        {
            ConexionBD conexionBD = new ConexionBD();
            MySqlConnection conn = conexionBD.AbrirConexion();

            try
            {
                string query = "SELECT idEmpleado, nombre FROM empleado";
                if (!string.IsNullOrWhiteSpace(apellidoFiltro))
                {
                    query += " WHERE apellido = @apellido";
                }

                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (!string.IsNullOrWhiteSpace(apellidoFiltro))
                {
                    cmd.Parameters.AddWithValue("@apellido", apellidoFiltro);
                }

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbnombre.DataSource = dt;
                cbnombre.DisplayMember = "nombre";
                cbnombre.ValueMember = "idEmpleado";
                cbnombre.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar nombres: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        private void CargarApellidos(string nombreFiltro = "")
        {
            ConexionBD conexionBD = new ConexionBD();
            MySqlConnection conn = conexionBD.AbrirConexion();

            try
            {
                string query = "SELECT idEmpleado, apellido FROM empleado";
                if (!string.IsNullOrWhiteSpace(nombreFiltro))
                {
                    query += " WHERE nombre = @nombre";
                }

                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (!string.IsNullOrWhiteSpace(nombreFiltro))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombreFiltro);
                }

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbapellido.DataSource = dt;
                cbapellido.DisplayMember = "apellido";
                cbapellido.ValueMember = "idEmpleado";
                cbapellido.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar apellidos: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        private string ObtenerApellidoPorId(int idEmpleado)
        {
            ConexionBD conexionBD = new ConexionBD();
            MySqlConnection conn = conexionBD.AbrirConexion();
            string apellido = "";

            try
            {
                string query = "SELECT apellido FROM empleado WHERE idEmpleado = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idEmpleado);
                apellido = cmd.ExecuteScalar()?.ToString();
            }
            catch { }
            finally
            {
                conexionBD.CerrarConexion();
            }

            return apellido;
        }

        private string ObtenerNombrePorId(int idEmpleado)
        {
            ConexionBD conexionBD = new ConexionBD();
            MySqlConnection conn = conexionBD.AbrirConexion();
            string nombre = "";

            try
            {
                string query = "SELECT nombre FROM empleado WHERE idEmpleado = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idEmpleado);
                nombre = cmd.ExecuteScalar()?.ToString();
            }
            catch { }
            finally
            {
                conexionBD.CerrarConexion();
            }

            return nombre;
        }

        private void btnconsulta_Click(object sender, EventArgs e)
        {
        }
        private void btnConsulta_Click(object sender, EventArgs e)
        {
            cargandoCombos = true;

            if (int.TryParse(cbidempleado.Text, out int idEmpleado))
            {
                CargarDatosEmpleado(idEmpleado);
                string nombre = ObtenerNombrePorId(idEmpleado);
                string apellido = ObtenerApellidoPorId(idEmpleado);

                CargarNombres(apellido);
                CargarApellidos(nombre);

                cbnombre.SelectedIndex = cbnombre.FindStringExact(nombre);
                cbapellido.SelectedIndex = cbapellido.FindStringExact(apellido);

                cbidempleado.SelectedValue = idEmpleado;

                cargandoCombos = false;
                return;
            }

            if (!string.IsNullOrWhiteSpace(cbnombre.Text))
            {
                CargarApellidos(cbnombre.Text);
            }

            if (!string.IsNullOrWhiteSpace(cbapellido.Text))
            {
                CargarNombres(cbapellido.Text);
            }

            cargandoCombos = false;
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            cargandoCombos = true;

            // Limpiar combos
            cbidempleado.SelectedIndex = -1;
            cbnombre.SelectedIndex = -1;
            cbapellido.SelectedIndex = -1;

            // Limpiar campos de texto
            txtmail.Clear();
            txttelefono.Clear();
            txtcuil.Clear();
            txtcallenro.Clear();

            // Resetear combos de provincia, localidad, categoría, depósito y rol
            cbprovincia.SelectedIndex = -1;
            cblocalidad.SelectedIndex = -1;
            cbcategoria.SelectedIndex = -1;
            cbiddeposito.SelectedIndex = -1;
            cbidrol.SelectedIndex = -1;

            // Resetear fecha
            dtalta.Value = DateTime.Today;

            // Recargar combos con todos los datos
            CargarIds();
            CargarNombres();
            CargarApellidos();

            cargandoCombos = false;
        }
    }
}
