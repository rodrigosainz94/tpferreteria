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
    public partial class Roles : Form
    {
        public Roles()
        {
            InitializeComponent();
        }

        private void Roles_Load(object sender, EventArgs e)
        {

        }

        private void lblvolveralinicio_Click(object sender, EventArgs e)
        {

        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario actual
            Empleados Empleados = new Empleados(); // Crea una instancia del formulario de empleados
            Empleados.Show(); // Muestra el formulario de empleados
        }

        private void btnalta_Click(object sender, EventArgs e)
        {

        }
    }
}
