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
    public partial class Productos : Form
    {
        // Lista para almacenar productos en memoria
        private List<Producto> productos = new List<Producto>();

        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;

            // Opcional: cargar categorías y proveedores de prueba
            cbcategoria.Items.AddRange(new string[] { "Ferretería", "Electricidad", "Pintura" });
            cbproveedor.Items.AddRange(new string[] { "Proveedor A", "Proveedor B", "Proveedor C" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validar por texto en lugar de SelectedItem
            if (string.IsNullOrWhiteSpace(txtnombreproducto.Text) ||
                string.IsNullOrWhiteSpace(txtprecio.Text) ||
                string.IsNullOrWhiteSpace(txtcodigobarra.Text) ||
                string.IsNullOrWhiteSpace(cbcategoria.Text) ||
                string.IsNullOrWhiteSpace(cbproveedor.Text))
            {
                MessageBox.Show("Por favor complete todos los campos.");
                return;
            }

            try
            {
                Producto nuevo = new Producto()
                {
                    Nombre = txtnombreproducto.Text,
                    Precio = decimal.Parse(txtprecio.Text),
                    CodigoBarra = txtcodigobarra.Text,
                    Categoria = cbcategoria.Text,   // toma texto del combo
                    Proveedor = cbproveedor.Text    // toma texto del combo
                };

                productos.Add(nuevo);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = productos;

                txtnombreproducto.Clear();
                txtprecio.Clear();
                txtcodigobarra.Clear();
                cbcategoria.Text = "";
                cbproveedor.Text = "";

                MessageBox.Show("Producto agregado correctamente.");
            }
            catch (FormatException)
            {
                MessageBox.Show("El precio debe ser un número válido.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            Menuprincipal nuevoFormulario = new Menuprincipal();
            nuevoFormulario.Show();
            this.Hide();
        }

        // Métodos vacíos para que compile sin problemas
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void txtnombreproducto_TextChanged(object sender, EventArgs e) { }
        private void cbcategoria_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cbproveedor_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtprecio_TextChanged(object sender, EventArgs e) { }
        private void txtcodigobarra_TextChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }

    // Clase producto para almacenar datos
    public class Producto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string CodigoBarra { get; set; }
        public string Categoria { get; set; }
        public string Proveedor { get; set; }
    }
}
