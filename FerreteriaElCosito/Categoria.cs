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
    public partial class frmcategoria : Form
    {
        private DataTable dtCategorias; // Tabla global para sincronizar

        public frmcategoria()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Frmcategoria_Load);
        }

        private void Frmcategoria_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCategorias();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar el formulario: " + ex.Message);
            }
        }

        /// <summary>
        /// Carga las categorías desde la base de datos y configura los ComboBox.
        /// </summary>
        private void CargarCategorias()
        {
            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = "SELECT idCategoria, Descripcion FROM Categoria ORDER BY Descripcion";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    dtCategorias = new DataTable();
                    da.Fill(dtCategorias);

                    // Desuscribimos eventos mientras cargamos
                    cbidcategoria.SelectedIndexChanged -= cbidcategoria_SelectedIndexChanged;
                    cbcategoria.SelectedIndexChanged -= cbcategoria_SelectedIndexChanged;

                    // Configuramos ComboBoxes
                    cbidcategoria.DataSource = dtCategorias.Copy();
                    cbidcategoria.DisplayMember = "idCategoria";
                    cbidcategoria.ValueMember = "idCategoria";
                    cbidcategoria.SelectedIndex = -1;

                    cbcategoria.DataSource = dtCategorias.Copy();
                    cbcategoria.DisplayMember = "Descripcion";
                    cbcategoria.ValueMember = "idCategoria";
                    cbcategoria.SelectedIndex = -1;

                    // Volvemos a suscribir eventos
                    cbidcategoria.SelectedIndexChanged += cbidcategoria_SelectedIndexChanged;
                    cbcategoria.SelectedIndexChanged += cbcategoria_SelectedIndexChanged;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al consultar categorías: " + ex.Message);
            }
        }

        /// <summary>
        /// Permite seleccionar una categoría desde otro formulario pasando su ID.
        /// </summary>
        public void SeleccionarCategoria(int idCategoria)
        {
            if (dtCategorias == null || dtCategorias.Rows.Count == 0)
            {
                CargarCategorias();
            }

            // Asignamos SelectedValue y se sincronizan ambos ComboBox
            cbidcategoria.SelectedValue = idCategoria;
            cbcategoria.SelectedValue = idCategoria;
        }

        /// <summary>
        /// Limpia los campos y resetea los ComboBox.
        /// </summary>
        private void LimpiarCampos()
        {
            cbidcategoria.SelectedIndexChanged -= cbidcategoria_SelectedIndexChanged;
            cbcategoria.SelectedIndexChanged -= cbcategoria_SelectedIndexChanged;

            cbidcategoria.SelectedIndex = -1;
            cbidcategoria.Text = "";
            cbcategoria.SelectedIndex = -1;
            cbcategoria.Text = "";

            cbidcategoria.SelectedIndexChanged += cbidcategoria_SelectedIndexChanged;
            cbcategoria.SelectedIndexChanged += cbcategoria_SelectedIndexChanged;
        }

        private void cbidcategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbidcategoria.SelectedValue != null && int.TryParse(cbidcategoria.SelectedValue.ToString(), out int valor))
            {
                cbcategoria.SelectedValue = valor;
            }
        }

        private void cbcategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbcategoria.SelectedValue != null && int.TryParse(cbcategoria.SelectedValue.ToString(), out int valor))
            {
                cbidcategoria.SelectedValue = valor;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            CargarCategorias();
            LimpiarCampos();
        }

        private void btnAlta_Click_1(object sender, EventArgs e)
        {

        }

        private void btnBaja_Click(object sender, EventArgs e)
        {

        }

        private void btnModificacion_Click(object sender, EventArgs e)
        {
            if (cbidcategoria.SelectedValue == null || string.IsNullOrWhiteSpace(cbcategoria.Text))
            {
                MessageBox.Show("Debe seleccionar una categoría y escribir una descripción.");
                return;
            }

            try
            {
                using (var conn = ConexionBD.ObtenerConexion())
                {
                    string query = "UPDATE Categoria SET Descripcion = @desc WHERE idCategoria = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@desc", cbcategoria.Text);
                    cmd.Parameters.AddWithValue("@id", cbidcategoria.SelectedValue);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Categoría actualizada.");
                CargarCategorias();
                LimpiarCampos();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al actualizar la categoría: " + ex.Message);
            }
        }

        private void btnAtras_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}