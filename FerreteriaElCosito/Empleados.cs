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
        private bool fechaBajaSeleccionada = false;

        public Empleados()
        {
            InitializeComponent();

            cbidempleado.SelectedIndexChanged += cbidempleado_SelectedIndexChanged;
            cbnombre.SelectedIndexChanged += cbnombre_SelectedIndexChanged;
            cbapellido.SelectedIndexChanged += cbapellido_SelectedIndexChanged;
            dtfechabaja.ValueChanged += dtfechabaja_ValueChanged;
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

            // ✅ Fecha de alta: hoy por defecto
            dtalta.Format = DateTimePickerFormat.Short;
            dtalta.Value = DateTime.Today;
            dtalta.Enabled = true;

            // ✅ Fecha de baja: vacía pero funcional
            dtfechabaja.Format = DateTimePickerFormat.Custom;
            dtfechabaja.CustomFormat = " ";
            dtfechabaja.Value = DateTime.Today; // necesario aunque se oculte
            dtfechabaja.Enabled = true;

            cargandoCombos = false;
        }

        private void CargarIds()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
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

        private void CargarProvincias()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT idProvincia, nombreProvincia FROM provincias ORDER BY nombreProvincia";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbprovincia.DataSource = dt;
                    cbprovincia.DisplayMember = "nombreProvincia";
                    cbprovincia.ValueMember = "idProvincia";
                    cbprovincia.SelectedIndex = -1; // Sin selección inicial
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar provincias: " + ex.Message);
            }
        }
        private void btneditarprov_Click(object sender, EventArgs e)
        {
            Provincias frm = new Provincias();
            frm.ShowDialog();
            CargarProvincias(); // recarga el combo de provincias en Empleados
        }
        private void CargarLocalidades()
        {
            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT idLocalidad, nombreLocalidad FROM localidades";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dt.Columns.Add("Display", typeof(string), "Convert(idLocalidad,'System.String') + ' - ' + nombreLocalidad");
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
        private void btneditarloc_Click_1(object sender, EventArgs e)
        {
            // Instancia del formulario Localidad
            Localidad frm = new Localidad();
            frm.ShowDialog(); // abre como ventana modal

            // Recarga el combo de localidades después de cerrar
            CargarLocalidades();
        }

        private void CargarCategorias()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
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

        private void btneditarcat_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbcategoria.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione una categoría primero.");
                    return;
                }

                // Asegurarse que sea entero
                if (!int.TryParse(cbcategoria.SelectedValue.ToString(), out int idCategoria))
                {
                    MessageBox.Show("El valor seleccionado no es válido.");
                    return;
                }

                frmcategoria frmCat = new frmcategoria();
                frmCat.SeleccionarCategoria(idCategoria);
                frmCat.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir Categorías: " + ex.Message);
            }
        }

        private void CargarDepositos()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
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
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbiddeposito.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un depósito primero.");
                    return;
                }

                if (!int.TryParse(cbiddeposito.SelectedValue.ToString(), out int iddeposito))
                {
                    MessageBox.Show("El valor seleccionado no es válido.");
                    return;
                }

                frmdeposito frm = new frmdeposito();
                frm.Seleccionardeposito(iddeposito); // 👈 acá entra el método nuevo
                frm.ShowDialog();

                // Refrescar la lista de depósitos en empleados después de editar
                CargarDepositos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir Depósito: " + ex.Message);
            }
        }


        private void CargarRoles()
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
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

        private void btneditarrol_Click(object sender, EventArgs e)
        {
            // Instancia del formulario Localidad
            Roles formularioRoles = new Roles();
            formularioRoles.Show();  // abre como ventana modal

            // Recarga el combo de localidades después de cerrar
            CargarRoles();
        }

        private void cbidempleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoCombos) return;
            if (!int.TryParse(cbidempleado.SelectedValue?.ToString(), out int idEmpleado)) return;

            try
            {
                cargandoCombos = true;
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
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
            if (cargandoCombos) return;
            if (!int.TryParse(cbnombre.SelectedValue?.ToString(), out int idEmpleado)) return;

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
            if (!int.TryParse(cbapellido.SelectedValue?.ToString(), out int idEmpleado)) return;

            cargandoCombos = true;
            try
            {
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

        private void CargarDatosEmpleado(int idEmpleado)
        {
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = @"SELECT Email, Telefono, CUIT_CUIL, CalleNumero, IdLocalidad, IdProvincia, FechaAlta,
                            Categoria, IdDeposito, IdRol, FechaBaja 
                            FROM empleado WHERE IdEmpleado = @id";

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

                                if (reader["FechaBaja"] != DBNull.Value)
                                {
                                    dtfechabaja.Format = DateTimePickerFormat.Short;
                                    dtfechabaja.Value = Convert.ToDateTime(reader["FechaBaja"]);
                                    fechaBajaSeleccionada = true;
                                }
                                else
                                {
                                    dtfechabaja.Format = DateTimePickerFormat.Custom;
                                    dtfechabaja.CustomFormat = " ";
                                    fechaBajaSeleccionada = false;
                                }
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
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT idEmpleado, nombre FROM empleado";
                    if (!string.IsNullOrWhiteSpace(apellidoFiltro))
                        query += " WHERE apellido = @apellido";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(apellidoFiltro))
                            cmd.Parameters.AddWithValue("@apellido", apellidoFiltro);

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
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT idEmpleado, apellido FROM empleado";
                    if (!string.IsNullOrWhiteSpace(nombreFiltro))
                        query += " WHERE nombre = @nombre";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(nombreFiltro))
                            cmd.Parameters.AddWithValue("@nombre", nombreFiltro);

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
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT apellido FROM empleado WHERE idEmpleado = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idEmpleado);
                        apellido = cmd.ExecuteScalar()?.ToString();
                    }
                }
            }
            catch { }
            return apellido;
        }

        private string ObtenerNombrePorId(int idEmpleado)
        {
            string nombre = "";
            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT nombre FROM empleado WHERE idEmpleado = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idEmpleado);
                        nombre = cmd.ExecuteScalar()?.ToString();
                    }
                }
            }
            catch { }
            return nombre;
        }

        private void btnconsulta_Click(object sender, EventArgs e)
        {
            using (var selector = new SeleccionarEmpleado())
            {
                if (selector.ShowDialog() == DialogResult.OK)
                {
                    cbidempleado.SelectedValue = selector.IdSeleccionado;
                }
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            cargandoCombos = true;

            cbidempleado.SelectedIndexChanged -= cbidempleado_SelectedIndexChanged;
            cbnombre.SelectedIndexChanged -= cbnombre_SelectedIndexChanged;
            cbapellido.SelectedIndexChanged -= cbapellido_SelectedIndexChanged;

            txtmail.Clear();
            txttelefono.Clear();
            txtcuil.Clear();
            txtcallenro.Clear();

            // Limpiar combos y también su texto
            cbidempleado.SelectedIndex = -1;
            cbidempleado.Text = "";

            cbnombre.SelectedIndex = -1;
            cbnombre.Text = "";  // Limpiar texto editable

            cbapellido.SelectedIndex = -1;
            cbapellido.Text = ""; // Limpiar texto editable

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

            // Fecha Alta: setear a hoy
            dtalta.Format = DateTimePickerFormat.Short;
            dtalta.Value = DateTime.Today;

            // Fecha Baja: dejar vacía con formato personalizado
            dtfechabaja.Format = DateTimePickerFormat.Custom;
            dtfechabaja.CustomFormat = " ";
            fechaBajaSeleccionada = false;

            cbidempleado.SelectedIndexChanged += cbidempleado_SelectedIndexChanged;
            cbnombre.SelectedIndexChanged += cbnombre_SelectedIndexChanged;
            cbapellido.SelectedIndexChanged += cbapellido_SelectedIndexChanged;

            cargandoCombos = false;
        }



        private void dtalta_ValueChanged(object sender, EventArgs e)
        {
            dtalta.Format = DateTimePickerFormat.Short;
        }

        private void btnalta_Click(object sender, EventArgs e)
        {
            // 1. Validaciones (estas ya las tenías y están perfectas)
            if (string.IsNullOrWhiteSpace(cbnombre.Text) ||
                string.IsNullOrWhiteSpace(cbapellido.Text) ||
                string.IsNullOrWhiteSpace(txtmail.Text) ||
                string.IsNullOrWhiteSpace(txttelefono.Text) ||
                string.IsNullOrWhiteSpace(txtcuil.Text) ||
                string.IsNullOrWhiteSpace(txtcallenro.Text) ||
                cbprovincia.SelectedIndex < 0 ||
                cblocalidad.SelectedIndex < 0 ||
                cbcategoria.SelectedIndex < 0 ||
                cbiddeposito.SelectedIndex < 0 ||
                cbidrol.SelectedIndex < 0)
            {
                MessageBox.Show("Todos los campos son obligatorios. Por favor, completalos antes de continuar.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MySqlConnection conn = null;
            MySqlTransaction transaction = null;

            try
            {
                conn = ConexionBD.ObtenerConexion();
                transaction = conn.BeginTransaction(); // <-- Iniciamos la transacción

                // --- PASO A: Crear el Empleado ---
                string queryEmpleado = @"INSERT INTO empleado 
                                (nombre, apellido, email, telefono, cuit_cuil, callenumero, idlocalidad, idprovincia, fechaalta, categoria, idDeposito, idRol) 
                                VALUES 
                                (@Nombre, @Apellido, @Email, @Telefono, @CUIL, @CalleNro, @Localidad, @Provincia, @FechaAlta, @Categoria, @Deposito, @Rol);
                                SELECT LAST_INSERT_ID();"; // Obtenemos el ID del nuevo empleado

                MySqlCommand cmdEmpleado = new MySqlCommand(queryEmpleado, conn, transaction); // Usamos la transacción
                cmdEmpleado.Parameters.AddWithValue("@Nombre", cbnombre.Text.Trim());
                cmdEmpleado.Parameters.AddWithValue("@Apellido", cbapellido.Text.Trim());
                cmdEmpleado.Parameters.AddWithValue("@Email", txtmail.Text.Trim());
                cmdEmpleado.Parameters.AddWithValue("@Telefono", txttelefono.Text.Trim());
                cmdEmpleado.Parameters.AddWithValue("@CUIL", txtcuil.Text.Trim());
                cmdEmpleado.Parameters.AddWithValue("@CalleNro", txtcallenro.Text.Trim());
                cmdEmpleado.Parameters.AddWithValue("@Localidad", cblocalidad.SelectedValue);
                cmdEmpleado.Parameters.AddWithValue("@Provincia", cbprovincia.SelectedValue);
                cmdEmpleado.Parameters.AddWithValue("@FechaAlta", dtalta.Value.Date);
                cmdEmpleado.Parameters.AddWithValue("@Categoria", cbcategoria.SelectedValue);
                cmdEmpleado.Parameters.AddWithValue("@Deposito", cbiddeposito.SelectedValue);
                cmdEmpleado.Parameters.AddWithValue("@Rol", cbidrol.SelectedValue);

                // Ejecutamos y guardamos el nuevo ID de empleado
                object newIdEmpleado = cmdEmpleado.ExecuteScalar();

                if (newIdEmpleado == null)
                {
                    throw new Exception("No se pudo obtener el ID del nuevo empleado.");
                }

                // --- PASO B: Crear el Usuario asociado ---
                string queryUsuario = @"INSERT INTO usuarios (NombreUsuario, Clave, IdEmpleado) 
                                VALUES (@NombreUsuario, @Clave, @IdEmpleado)";

                MySqlCommand cmdUsuario = new MySqlCommand(queryUsuario, conn, transaction); // Usamos la misma transacción
                cmdUsuario.Parameters.AddWithValue("@NombreUsuario", txtcuil.Text.Trim());
                cmdUsuario.Parameters.AddWithValue("@Clave", txtcuil.Text.Trim()); // Usando CUIT como clave temporal
                cmdUsuario.Parameters.AddWithValue("@IdEmpleado", newIdEmpleado);
                cmdUsuario.ExecuteNonQuery();

                // Si todo salió bien, confirmamos todos los cambios en la base de datos
                transaction.Commit(); // <-- Confirmamos la transacción

                MessageBox.Show("Empleado y usuario creados correctamente. ID de Empleado: " + newIdEmpleado.ToString(), "Alta Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cargandoCombos = true;
                CargarIds();
                cargandoCombos = false;

                btnlimpiar_Click(null, null);
            }
            catch (Exception ex)
            {
                // Si algo falla, revertimos todos los cambios
                transaction?.Rollback(); // <-- Revertimos la transacción
                MessageBox.Show("Error al agregar empleado y usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cerramos la conexión
                conn?.Close();
            }
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnmodificacion_Click(object sender, EventArgs e)
        {
            if (cbidempleado.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccioná un empleado para modificar.");
                return;
            }

            // Validación: no dejar campos vacíos al modificar
            if (string.IsNullOrWhiteSpace(cbnombre.Text) ||
                string.IsNullOrWhiteSpace(cbapellido.Text) ||
                string.IsNullOrWhiteSpace(txtmail.Text) ||
                string.IsNullOrWhiteSpace(txttelefono.Text) ||
                string.IsNullOrWhiteSpace(txtcuil.Text) ||
                string.IsNullOrWhiteSpace(txtcallenro.Text) ||
                cbprovincia.SelectedIndex < 0 ||
                cblocalidad.SelectedIndex < 0 ||
                cbcategoria.SelectedIndex < 0 ||
                cbiddeposito.SelectedIndex < 0 ||
                cbidrol.SelectedIndex < 0)
            {
                MessageBox.Show("Todos los campos son obligatorios para modificar un empleado.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    string query = @"UPDATE empleado SET 
                        nombre = @Nombre,
                        apellido = @Apellido,
                        email = @Email,
                        telefono = @Telefono,
                        cuit_cuil = @CUIL,
                        callenumero = @CalleNro,
                        idlocalidad = @Localidad,
                        idprovincia = @Provincia,
                        fechaalta = @FechaAlta,
                        categoria = @Categoria,
                        idDeposito = @Deposito,
                        idRol = @Rol
                     WHERE idEmpleado = @IdEmpleado";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", cbnombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@Apellido", cbapellido.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Telefono", txttelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@CUIL", txtcuil.Text.Trim());
                        cmd.Parameters.AddWithValue("@CalleNro", txtcallenro.Text.Trim());
                        cmd.Parameters.AddWithValue("@Localidad", cblocalidad.SelectedValue);
                        cmd.Parameters.AddWithValue("@Provincia", cbprovincia.SelectedValue);
                        cmd.Parameters.AddWithValue("@FechaAlta", dtalta.Value.Date);
                        cmd.Parameters.AddWithValue("@Categoria", cbcategoria.SelectedValue);
                        cmd.Parameters.AddWithValue("@Deposito", cbiddeposito.SelectedValue);
                        cmd.Parameters.AddWithValue("@Rol", cbidrol.SelectedValue);
                        cmd.Parameters.AddWithValue("@IdEmpleado", cbidempleado.SelectedValue);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Empleado modificado correctamente.");
                            btnlimpiar_Click(null, null); // 👉 Esto limpia todo el formulario
                        }
                        else
                        {
                            MessageBox.Show("No se pudo modificar el empleado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar empleado: " + ex.Message);
            }
        }

        private void btnbaja_Click(object sender, EventArgs e)
        {
            if (cbidempleado.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccioná un empleado para dar de baja.");
                return;
            }

            int idEmpleado = Convert.ToInt32(cbidempleado.SelectedValue);

            var confirm = MessageBox.Show(
                "¿Estás segura de que querés dar de baja este empleado?",
                "Confirmar baja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    DateTime fechaBaja = fechaBajaSeleccionada
                        ? dtfechabaja.Value.Date
                        : DateTime.Now.Date;

                    string query = "UPDATE empleado SET Activo = 0, FechaBaja = @FechaBaja WHERE idEmpleado = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idEmpleado);
                        cmd.Parameters.AddWithValue("@FechaBaja", fechaBaja);

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Empleado dado de baja correctamente.");
                            btnlimpiar_Click(null, null);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo dar de baja al empleado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al dar de baja: " + ex.Message);
            }
        }
        private void dtfechabaja_ValueChanged(object sender, EventArgs e)
        {
            dtfechabaja.Format = DateTimePickerFormat.Short;
            fechaBajaSeleccionada = true;
        }
    }
}