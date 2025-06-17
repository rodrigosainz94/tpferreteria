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

        private void Menuprincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnproveedores_Click(object sender, EventArgs e)
        {
            Proveedores nuevoFormulario = new Proveedores();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btnproductos_Click(object sender, EventArgs e)
        {
            Productos nuevoFormulario = new Productos();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btnclientes_Click(object sender, EventArgs e)
        {
            Clientes nuevoFormulario = new Clientes();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btnusuarios_Click(object sender, EventArgs e)
        {
            Usuarios nuevoFormulario = new Usuarios();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btncaja_Click(object sender, EventArgs e)
        {
            Caja nuevoFormulario = new Caja();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
