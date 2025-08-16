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
    public partial class Provincias : Form
    {
        private DataTable dtProvincias; // Tabla global para sincronizar

        public Provincias()
        {
            InitializeComponent();
        }

        private void frmprovincia_Load(object sender, EventArgs e)
        {
            CargarProvincias();

            // Limpiar campos al iniciar
            LimpiarCampos();

            // Asociar eventos para sincronización
            cbidprovincia.SelectedIndexChanged += cbidprovincia_SelectedIndexChanged;
            cbnombreprovincia.SelectedIndexChanged += cbnombreprovincia_SelectedIndexChanged;
        }

        private void CargarProvincias()
        {
            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT IDProvincia, nombreProvincia FROM provincias ORDER BY nombreProvincia";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    dtProvincias = new DataTable();
                    da.Fill(dtProvincias);

                    // Desactivar eventos temporalmente
                    cbidprovincia.SelectedIndexChanged -= cbidprovincia_SelectedIndexChanged;
                    cbnombreprovincia.SelectedIndexChanged -= cbnombreprovincia_SelectedIndexChanged;

                    // Limpiar ComboBoxes antes de asignar DataSource
                    cbidprovincia.DataSource = null;
                    cbnombreprovincia.DataSource = null;

                    // Asignar DataSource
                    cbidprovincia.DataSource = dtProvincias;
                    cbidprovincia.DisplayMember = "IDProvincia";
                    cbidprovincia.ValueMember = "IDProvincia";
                    cbidprovincia.SelectedIndex = -1;

                    cbnombreprovincia.DataSource = dtProvincias;
                    cbnombreprovincia.DisplayMember = "nombreProvincia";
                    cbnombreprovincia.ValueMember = "IDProvincia";
                    cbnombreprovincia.SelectedIndex = -1;

                    // Reactivar eventos
                    cbidprovincia.SelectedIndexChanged += cbidprovincia_SelectedIndexChanged;
                    cbnombreprovincia.SelectedIndexChanged += cbnombreprovincia_SelectedIndexChanged;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al consultar provincias: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            // Desactivar eventos temporalmente
            cbidprovincia.SelectedIndexChanged -= cbidprovincia_SelectedIndexChanged;
            cbnombreprovincia.SelectedIndexChanged -= cbnombreprovincia_SelectedIndexChanged;

            // Solo limpiar selección y texto
            cbidprovincia.SelectedIndex = -1;
            cbidprovincia.Text = "";
            cbnombreprovincia.SelectedIndex = -1;
            cbnombreprovincia.Text = "";

            // Reactivar eventos
            cbidprovincia.SelectedIndexChanged += cbidprovincia_SelectedIndexChanged;
            cbnombreprovincia.SelectedIndexChanged += cbnombreprovincia_SelectedIndexChanged;
        }


        private void cbidprovincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbidprovincia.SelectedValue != null && cbidprovincia.SelectedIndex != -1)
            {
                cbnombreprovincia.SelectedValue = cbidprovincia.SelectedValue;
            }
        }

        private void cbnombreprovincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbnombreprovincia.SelectedValue != null && cbnombreprovincia.SelectedIndex != -1)
            {
                cbidprovincia.SelectedValue = cbnombreprovincia.SelectedValue;
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            CargarProvincias();
            LimpiarCampos();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            string nombre = cbnombreprovincia.Text.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Debe ingresar un nombre de provincia.");
                return;
            }

            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = "INSERT INTO provincias (nombreProvincia) VALUES (@nombre)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Provincia agregada correctamente.");
                CargarProvincias();
                LimpiarCampos();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al agregar provincia: " + ex.Message);
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (cbidprovincia.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una provincia.");
                return;
            }

            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = "DELETE FROM provincias WHERE IDProvincia = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", cbidprovincia.SelectedValue);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Provincia eliminada.");
                CargarProvincias();
                LimpiarCampos();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al eliminar la provincia: " + ex.Message);
            }
        }

        private void btnModificacion_Click(object sender, EventArgs e)
        {
            if (cbidprovincia.SelectedValue == null || string.IsNullOrWhiteSpace(cbnombreprovincia.Text))
            {
                MessageBox.Show("Debe seleccionar una provincia y escribir un nombre.");
                return;
            }

            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = "UPDATE provincias SET nombreProvincia = @nombre WHERE IDProvincia = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", cbnombreprovincia.Text);
                    cmd.Parameters.AddWithValue("@id", cbidprovincia.SelectedValue);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Provincia actualizada.");
                CargarProvincias();
                LimpiarCampos();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al actualizar la provincia: " + ex.Message);
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}