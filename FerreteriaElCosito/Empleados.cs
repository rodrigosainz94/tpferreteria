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
        public Empleados()
        {
            InitializeComponent();
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

        private void lblconsulta_Click(object sender, EventArgs e)
        {

        }

        private void lblbaja_Click(object sender, EventArgs e)
        {

        }

        private void Empleados_Load(object sender, EventArgs e)
        {

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
    }
}
