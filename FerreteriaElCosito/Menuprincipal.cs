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
    public partial class Menuprincipal : Form
    {
        public Menuprincipal()
        {
            InitializeComponent();
        }

        private void btnfacturar_Click(object sender, EventArgs e)
        {
            Facturar nuevoFormulario = new Facturar();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Empleados formularioEmpleados = new Empleados();
            formularioEmpleados.Show();
            this.Hide();
        }

        private void btncompras_Click(object sender, EventArgs e)
        {
            Compras nuevoFormulario = new Compras();
            nuevoFormulario.Show();
            this.Hide();
        }
    }
}
