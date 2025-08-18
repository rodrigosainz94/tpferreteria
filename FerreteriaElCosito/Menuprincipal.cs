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
            // Habilitamos todos los botones por defecto al cargar el formulario
            btnfacturar.Enabled = true;
            btncompras.Enabled = true;
            btnproveedores.Enabled = true;
            btnproductos.Enabled = true;
            btnclientes.Enabled = true;
            btnusuarios.Enabled = true;
            btncaja.Enabled = true;
            btnempleados.Enabled = true;

            // Ahora, deshabilitamos según el rol específico del usuario
            switch (this.idRolUsuario)
            {
                case 1: // Administrador
                        // No hacemos nada, el admin puede ver todo.
                    break;

                case 2: // Vendedor
                    btnempleados.Enabled = false;
                    btnusuarios.Enabled = false;
                    btnproveedores.Enabled = false;
                    btncompras.Enabled = false;
                    break;

                case 3: // Depósito
                    btnfacturar.Enabled = false;
                    btnclientes.Enabled = false;
                    btnusuarios.Enabled = false;
                    btncaja.Enabled = false;
                    break;

                default:
                    // Si el rol es desconocido, por seguridad deshabilitamos todo.
                    btnfacturar.Enabled = false;
                    btncompras.Enabled = false;
                    btnproveedores.Enabled = false;
                    btnproductos.Enabled = false;
                    btnclientes.Enabled = false;
                    btnusuarios.Enabled = false;
                    btncaja.Enabled = false;
                    btnempleados.Enabled = false;
                    break;
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