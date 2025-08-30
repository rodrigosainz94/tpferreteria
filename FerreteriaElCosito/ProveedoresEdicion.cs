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
    public partial class ProveedoresEdicion : Form
    {
        public ProveedoresEdicion()
        {
            InitializeComponent();
        }

        public int IdProveedor
        {
            get => string.IsNullOrWhiteSpace(txtidprov.Text) ? 0 : Convert.ToInt32(txtidprov.Text);
            set => txtidprov.Text = value.ToString();
        }

        public string Nombre
        {
            get => txtNombre.Text;
            set => txtNombre.Text = value;
        }

        public string Apellido
        {
            get => txtapellido.Text;
            set => txtapellido.Text = value;
        }

        public string Email
        {
            get => txtemail.Text;
            set => txtemail.Text = value;
        }

        public string Telefono
        {
            get => txttelefono.Text;
            set => txttelefono.Text = value;
        }

        public string CUIT
        {
            get => txtcuit.Text;
            set => txtcuit.Text = value;
        }

        public string Calle
        {
            get => txtcallenum.Text;
            set => txtcallenum.Text = value;
        }

        public int IdLocalidad
        {
            get => Convert.ToInt32(txtidlocalidad.SelectedValue);
            set => txtidlocalidad.SelectedValue = value;
        }

        public int IdProvincia
        {
            get => Convert.ToInt32(txtidprovincia.SelectedValue);
            set => txtidprovincia.SelectedValue = value;
        }

        public int IdCategoria
        {
            get => Convert.ToInt32(txtidcategoria.SelectedValue);
            set => txtidcategoria.SelectedValue = value;
        }

        public DateTime FechaAlta
        {
            get => dtpfechaalta.Value;
            set => dtpfechaalta.Value = value;
        }


        private void ProveedoresEdicion_Load(object sender, EventArgs e)
        {
            txtidprov.Enabled = false;
            CargarLocalidades();
            CargarProvincias();
            CargarCategoriasIVA();
        }

        private void CargarLocalidades()
        {
            using (var conexion = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT IdLocalidad, NombreLocalidad FROM localidades";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                txtidlocalidad.DataSource = dt;       // tu ComboBox
                txtidlocalidad.DisplayMember = "NombreLocalidad";   // lo que se muestra al usuario
                txtidlocalidad.ValueMember = "IdLocalidad"; // el valor interno
            }
        }


        private void CargarProvincias()
        {
            using (var conexion = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT IdProvincia, NombreProvincia FROM provincias";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                txtidprovincia.DataSource = dt;          // tu ComboBox
                txtidprovincia.DisplayMember = "NombreProvincia";   // lo que ve el usuario
                txtidprovincia.ValueMember = "IdProvincia"; // valor interno
            }
        }


        private void CargarCategoriasIVA()
        {
            using (var conexion = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT IdCatIVA, DescripcionIVA FROM categoriaiva"; // traemos ambas columnas
                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                txtidcategoria.DataSource = dt;
                txtidcategoria.DisplayMember = "DescripcionIVA"; // lo que se muestra al usuario
                txtidcategoria.ValueMember = "IdCatIVA";         // el valor interno
            }
        }






        private void btnguardar_Click(object sender, EventArgs e)
        {
            // ✅ Validación: ningún campo vacío
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtapellido.Text) ||
                string.IsNullOrWhiteSpace(txtemail.Text) ||
                string.IsNullOrWhiteSpace(txttelefono.Text) ||
                string.IsNullOrWhiteSpace(txtcuit.Text) ||
                string.IsNullOrWhiteSpace(txtcallenum.Text) ||
                string.IsNullOrWhiteSpace(txtidlocalidad.Text) ||
                string.IsNullOrWhiteSpace(txtidprovincia.Text) ||
                string.IsNullOrWhiteSpace(txtidcategoria.Text))
            {
                MessageBox.Show("Por favor complete todos los campos antes de guardar.");
                return;
            }

            try
            {
                using (var conexion = ConexionBD.ObtenerConexion())
                {
                    int idProveedor;
                    bool esNuevo = false;

                    // Determinar si es nuevo o edición
                    if (string.IsNullOrWhiteSpace(txtidprov.Text))
                    {
                        // Generar ID automático
                        string queryMax = "SELECT MAX(IdProveedor) FROM proveedores";
                        MySqlCommand cmdMax = new MySqlCommand(queryMax, conexion);
                        object result = cmdMax.ExecuteScalar();
                        idProveedor = (result != DBNull.Value) ? Convert.ToInt32(result) + 1 : 1;
                        esNuevo = true;
                    }
                    else
                    {
                        idProveedor = Convert.ToInt32(txtidprov.Text);
                    }

                    string query;
                    if (esNuevo)
                    {
                        // INSERT
                        query = @"INSERT INTO proveedores
                    (IdProveedor, Nombre, Apellido, Email, Telefono, CUIT_CUIL, Callenumero, IdLocalidad, IdProvincia, FechaAlta, IdCatIVA)
                    VALUES (@IdProveedor, @Nombre, @Apellido, @Email, @Telefono, @CUIT, @Calle, @IdLocalidad, @IdProvincia, @FechaAlta, @IdCatIVA)";
                    }
                    else
                    {
                        // UPDATE
                        query = @"UPDATE proveedores SET
                            Nombre = @Nombre,
                            Apellido = @Apellido,
                            Email = @Email,
                            Telefono = @Telefono,
                            CUIT_CUIL = @CUIT,
                            Callenumero = @Calle,
                            IdLocalidad = @IdLocalidad,
                            IdProvincia = @IdProvincia,
                            FechaAlta = @FechaAlta,
                            IdCatIVA = @IdCatIVA
                          WHERE IdProveedor = @IdProveedor";
                    }

                    using (var cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Apellido", txtapellido.Text);
                        cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                        cmd.Parameters.AddWithValue("@Telefono", txttelefono.Text);
                        cmd.Parameters.AddWithValue("@CUIT", txtcuit.Text);
                        cmd.Parameters.AddWithValue("@Calle", txtcallenum.Text);
                        cmd.Parameters.AddWithValue("@IdLocalidad", txtidlocalidad.SelectedValue);
                        cmd.Parameters.AddWithValue("@IdProvincia", txtidprovincia.SelectedValue);
                        cmd.Parameters.AddWithValue("@FechaAlta", dtpfechaalta.Value);
                        cmd.Parameters.AddWithValue("@IdCatIVA", txtidcategoria.SelectedValue);

                        cmd.ExecuteNonQuery();
                    }

                    string mensaje = esNuevo ?
                        $"Proveedor agregado correctamente con ID {idProveedor}" :
                        $"Proveedor actualizado correctamente con ID {idProveedor}";

                    MessageBox.Show(mensaje);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
    

