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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            UsuariosAgregar nuevoFormulario = new UsuariosAgregar();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            UsuariosAgregar nuevoFormulario = new UsuariosAgregar();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            Menuprincipal nuevoFormulario = new Menuprincipal();
            nuevoFormulario.Show();
            this.Hide();
        }
    }
}
