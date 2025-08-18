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
    public partial class Localidad : Form
    {
        private DataTable dtLocalidades; // Para almacenar localidades
        private DataTable dtProvincias;  // Para almacenar provincias

        public Localidad()
        {
            InitializeComponent();
        }

        private void Localidad_Load(object sender, EventArgs e)
        {
            CargarProvincias();
            CargarLocalidades();
        }

        // ===================== PROVINCIAS =====================
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

                    cbidprovincia.SelectedIndexChanged -= cbidprovincia_SelectedIndexChanged;
                    cbnombreprovincia.SelectedIndexChanged -= cbnombreprovincia_SelectedIndexChanged;

                    cbidprovincia.DataSource = dtProvincias.Copy();
                    cbidprovincia.DisplayMember = "IDProvincia";
                    cbidprovincia.ValueMember = "IDProvincia";
                    cbidprovincia.SelectedIndex = -1;

                    cbnombreprovincia.DataSource = dtProvincias;
                    cbnombreprovincia.DisplayMember = "nombreProvincia";
                    cbnombreprovincia.ValueMember = "IDProvincia";
                    cbnombreprovincia.SelectedIndex = -1;

                    cbidprovincia.SelectedIndexChanged += cbidprovincia_SelectedIndexChanged;
                    cbnombreprovincia.SelectedIndexChanged += cbnombreprovincia_SelectedIndexChanged;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al consultar provincias: " + ex.Message);
            }
        }

        private void cbidprovincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbidprovincia.SelectedValue != null && cbidprovincia.SelectedIndex != -1)
                cbnombreprovincia.SelectedValue = cbidprovincia.SelectedValue;
        }

        private void cbnombreprovincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbnombreprovincia.SelectedValue != null && cbnombreprovincia.SelectedIndex != -1)
                cbidprovincia.SelectedValue = cbnombreprovincia.SelectedValue;
        }

        // ===================== LOCALIDADES =====================
        private void CargarLocalidades()
        {
            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT IDLocalidad, nombreLocalidad, idProvincia FROM localidades ORDER BY nombreLocalidad";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    dtLocalidades = new DataTable();
                    da.Fill(dtLocalidades);

                    cbidlocalidad.SelectedIndexChanged -= cbidlocalidad_SelectedIndexChanged;
                    cbnombrelocalidad.SelectedIndexChanged -= cbnombrelocalidad_SelectedIndexChanged;

                    cbidlocalidad.DataSource = dtLocalidades.Copy();
                    cbidlocalidad.DisplayMember = "IDLocalidad";
                    cbidlocalidad.ValueMember = "IDLocalidad";
                    cbidlocalidad.SelectedIndex = -1;

                    cbnombrelocalidad.DataSource = dtLocalidades;
                    cbnombrelocalidad.DisplayMember = "nombreLocalidad";
                    cbnombrelocalidad.ValueMember = "IDLocalidad";
                    cbnombrelocalidad.SelectedIndex = -1;

                    cbidlocalidad.SelectedIndexChanged += cbidlocalidad_SelectedIndexChanged;
                    cbnombrelocalidad.SelectedIndexChanged += cbnombrelocalidad_SelectedIndexChanged;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al consultar localidades: " + ex.Message);
            }
        }

        private void cbidlocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbidlocalidad.SelectedValue != null && cbidlocalidad.SelectedIndex != -1)
            {
                cbnombrelocalidad.SelectedValue = cbidlocalidad.SelectedValue;

                // Cargar la provincia correspondiente
                DataRow[] rows = dtLocalidades.Select("IDLocalidad = " + cbidlocalidad.SelectedValue);
                if (rows.Length > 0)
                {
                    cbidprovincia.SelectedValue = rows[0]["idProvincia"];
                }
            }
        }

        private void cbnombrelocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbnombrelocalidad.SelectedValue != null && cbnombrelocalidad.SelectedIndex != -1)
                cbidlocalidad.SelectedValue = cbnombrelocalidad.SelectedValue;
        }

        // ===================== BOTONES =====================
        private void btnalta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbnombrelocalidad.Text) || cbidprovincia.SelectedIndex == -1)
            {
                MessageBox.Show("Debe ingresar un nombre de localidad y seleccionar una provincia.");
                return;
            }

            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = "INSERT INTO localidades (nombreLocalidad, idProvincia) VALUES (@nombre, @idProv)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", cbnombrelocalidad.Text.Trim());
                    cmd.Parameters.AddWithValue("@idProv", cbidprovincia.SelectedValue);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Localidad agregada correctamente.");
                CargarLocalidades();
                LimpiarCampos();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al agregar localidad: " + ex.Message);
            }
        }

        private void btnmodificacion_Click(object sender, EventArgs e)
        {
            if (cbidlocalidad.SelectedValue == null || string.IsNullOrWhiteSpace(cbnombrelocalidad.Text) || cbidprovincia.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una localidad, escribir un nombre y elegir una provincia.");
                return;
            }

            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = "UPDATE localidades SET nombreLocalidad = @nombre, idProvincia = @idProv WHERE IDLocalidad = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", cbnombrelocalidad.Text.Trim());
                    cmd.Parameters.AddWithValue("@idProv", cbidprovincia.SelectedValue);
                    cmd.Parameters.AddWithValue("@id", cbidlocalidad.SelectedValue);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Localidad actualizada.");
                CargarLocalidades();
                LimpiarCampos();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al actualizar la localidad: " + ex.Message);
            }
        }

        private void btnbaja_Click(object sender, EventArgs e)
        {
            if (cbidlocalidad.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una localidad.");
                return;
            }

            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = "DELETE FROM localidades WHERE IDLocalidad = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", cbidlocalidad.SelectedValue);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Localidad eliminada.");
                CargarLocalidades();
                LimpiarCampos();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al eliminar la localidad: " + ex.Message);
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ===================== LIMPIAR CAMPOS =====================
        private void LimpiarCampos()
        {
            // Localidades
            cbidlocalidad.SelectedIndexChanged -= cbidlocalidad_SelectedIndexChanged;
            cbnombrelocalidad.SelectedIndexChanged -= cbnombrelocalidad_SelectedIndexChanged;
            cbidlocalidad.SelectedIndex = -1;
            cbnombrelocalidad.SelectedIndex = -1;
            cbidlocalidad.SelectedIndexChanged += cbidlocalidad_SelectedIndexChanged;
            cbnombrelocalidad.SelectedIndexChanged += cbnombrelocalidad_SelectedIndexChanged;

            // Provincias
            cbidprovincia.SelectedIndexChanged -= cbidprovincia_SelectedIndexChanged;
            cbnombreprovincia.SelectedIndexChanged -= cbnombreprovincia_SelectedIndexChanged;
            cbidprovincia.SelectedIndex = -1;
            cbnombreprovincia.SelectedIndex = -1;
            cbidprovincia.SelectedIndexChanged += cbidprovincia_SelectedIndexChanged;
            cbnombreprovincia.SelectedIndexChanged += cbnombreprovincia_SelectedIndexChanged;
        }
    }
}