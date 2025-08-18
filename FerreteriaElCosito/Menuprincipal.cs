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
        // Variables para guardar los datos del usuario que inició sesión
        private int idUsuarioLogueado;
        private int idRolUsuario;

        // Constructor que recibe los datos desde el formulario de Inicio
        public Menuprincipal(int idEmpleado, int idRol)
        {
            InitializeComponent(); // Esta línea es fundamental, siempre debe estar

            // Guardamos los datos recibidos en nuestras variables
            this.idUsuarioLogueado = idEmpleado;
            this.idRolUsuario = idRol;
        }

        private void Menuprincipal_Load(object sender, EventArgs e)
        {
            // Ahora que el formulario "sabe" el rol del usuario,
            // aquí es donde va la lógica para habilitar o deshabilitar botones.
            // Ejemplo:
            if (this.idRolUsuario == 2) // Asumiendo que el rol 2 es 'Vendedor'
            {
                btnempleados.Enabled = false; // El vendedor no puede gestionar empleados
                btnusuarios.Enabled = false;  // Tampoco puede gestionar usuarios
                btnproveedores.Enabled = false; // Y tampoco proveedores
                // ... y así con los demás botones que no le correspondan.
            }
        }

        // --- NAVEGACIÓN A OTROS FORMULARIOS ---
        // Este es el patrón correcto para abrir una ventana y volver al menú cuando se cierra

        private void btnfacturar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Facturar nuevoFormulario = new Facturar();
            nuevoFormulario.Show();
            nuevoFormulario.FormClosed += (s, args) => this.Show();
        }

        private void btnempleados_Click(object sender, EventArgs e)
        {
            this.Hide();
            Empleados formularioEmpleados = new Empleados();
            formularioEmpleados.Show();
            formularioEmpleados.FormClosed += (s, args) => this.Show();
        }

        private void btncompras_Click(object sender, EventArgs e)
        {
            this.Hide();
            Compras nuevoFormulario = new Compras();
            nuevoFormulario.Show();
            nuevoFormulario.FormClosed += (s, args) => this.Show();
        }

        private void btnproveedores_Click(object sender, EventArgs e)
        {
            this.Hide();
            Proveedores nuevoFormulario = new Proveedores();
            nuevoFormulario.Show();
            nuevoFormulario.FormClosed += (s, args) => this.Show();
        }

        private void btnproductos_Click(object sender, EventArgs e)
        {
            this.Hide();
            Productos nuevoFormulario = new Productos();
            nuevoFormulario.Show();
            nuevoFormulario.FormClosed += (s, args) => this.Show();
        }

        private void btnclientes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Clientes nuevoFormulario = new Clientes();
            nuevoFormulario.Show();
            nuevoFormulario.FormClosed += (s, args) => this.Show();
        }

        private void btnusuarios_Click(object sender, EventArgs e)
        {
            this.Hide();
            Usuarios nuevoFormulario = new Usuarios();
            nuevoFormulario.Show();
            nuevoFormulario.FormClosed += (s, args) => this.Show();
        }

        private void btncaja_Click(object sender, EventArgs e)
        {
            this.Hide();
            Caja nuevoFormulario = new Caja();
            nuevoFormulario.Show();
            nuevoFormulario.FormClosed += (s, args) => this.Show();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}