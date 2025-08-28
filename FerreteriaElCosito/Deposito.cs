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
    public partial class frmdeposito : Form
    {
        private DataTable dtdeposito; // Tabla global para sincronizar

        public frmdeposito()
        {
            InitializeComponent();
        }

        private void frmdeposito_Load(object sender, EventArgs e)
        {
            CargarDeposito();
            LimpiarCampos();

            cbiddeposito.SelectedIndexChanged += cbiddeposito_SelectedIndexChanged;
            cbnombredeposito.SelectedIndexChanged += cbnombredeposito_SelectedIndexChanged;
        }

        // ================== MÉTODO PÚBLICO PARA SELECCIONAR DEPÓSITO ==================
        public void Seleccionardeposito(int iddeposito)
        {
            // Refrescar lista de depósitos
            CargarDeposito();

            if (dtdeposito != null && dtdeposito.Rows.Count > 0)
            {
                // Buscar el depósito por ID
                DataRow[] rows = dtdeposito.Select("IdDeposito = " + iddeposito);
                if (rows.Length > 0)
                {
                    cbiddeposito.SelectedValue = iddeposito;
                    cbnombredeposito.SelectedValue = iddeposito;
                }
                else
                {
                    MessageBox.Show("No se encontró el depósito con ID " + iddeposito);
                }
            }
        }
        private void CargarDeposito()
        {
            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT IdDeposito, NombreDeposito FROM deposito ORDER BY NombreDeposito";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    dtdeposito = new DataTable();
                    da.Fill(dtdeposito);

                    cbiddeposito.SelectedIndexChanged -= cbiddeposito_SelectedIndexChanged;
                    cbnombredeposito.SelectedIndexChanged -= cbnombredeposito_SelectedIndexChanged;

                    cbiddeposito.DataSource = null;
                    cbnombredeposito.DataSource = null;

                    cbiddeposito.DataSource = dtdeposito;
                    cbiddeposito.DisplayMember = "IdDeposito";
                    cbiddeposito.ValueMember = "IdDeposito";
                    cbiddeposito.SelectedIndex = -1;

                    cbnombredeposito.DataSource = dtdeposito;
                    cbnombredeposito.DisplayMember = "NombreDeposito";
                    cbnombredeposito.ValueMember = "IdDeposito";
                    cbnombredeposito.SelectedIndex = -1;

                    cbiddeposito.SelectedIndexChanged += cbiddeposito_SelectedIndexChanged;
                    cbnombredeposito.SelectedIndexChanged += cbnombredeposito_SelectedIndexChanged;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al consultar depósitos: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            cbiddeposito.SelectedIndexChanged -= cbiddeposito_SelectedIndexChanged;
            cbnombredeposito.SelectedIndexChanged -= cbnombredeposito_SelectedIndexChanged;

            cbiddeposito.SelectedIndex = -1;
            cbiddeposito.Text = "";
            cbnombredeposito.SelectedIndex = -1;
            cbnombredeposito.Text = "";

            cbiddeposito.SelectedIndexChanged += cbiddeposito_SelectedIndexChanged;
            cbnombredeposito.SelectedIndexChanged += cbnombredeposito_SelectedIndexChanged;
        }

        private void cbiddeposito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbiddeposito.SelectedValue != null && cbiddeposito.SelectedIndex != -1)
            {
                cbnombredeposito.SelectedValue = cbiddeposito.SelectedValue;
            }
        }

        private void cbnombredeposito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbnombredeposito.SelectedValue != null && cbnombredeposito.SelectedIndex != -1)
            {
                cbiddeposito.SelectedValue = cbnombredeposito.SelectedValue;
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            CargarDeposito();
            LimpiarCampos();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            string nombre = cbnombredeposito.Text.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Debe ingresar un nombre de depósito.");
                return;
            }

            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = "INSERT INTO deposito (NombreDeposito) VALUES (@nombre)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Depósito agregado correctamente.");
                CargarDeposito();
                LimpiarCampos();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al agregar depósito: " + ex.Message);
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (cbiddeposito.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un depósito.");
                return;
            }

            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = "DELETE FROM deposito WHERE IdDeposito = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", cbiddeposito.SelectedValue);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Depósito eliminado.");
                CargarDeposito();
                LimpiarCampos();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al eliminar el depósito: " + ex.Message);
            }
        }

        private void btnModificacion_Click(object sender, EventArgs e)
        {
            if (cbiddeposito.SelectedValue == null || string.IsNullOrWhiteSpace(cbnombredeposito.Text))
            {
                MessageBox.Show("Debe seleccionar un depósito y escribir un nombre.");
                return;
            }

            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = "UPDATE deposito SET NombreDeposito = @nombre WHERE IdDeposito = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", cbnombredeposito.Text);
                    cmd.Parameters.AddWithValue("@id", cbiddeposito.SelectedValue);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Depósito actualizado.");
                CargarDeposito();
                LimpiarCampos();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al actualizar el depósito: " + ex.Message);
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}