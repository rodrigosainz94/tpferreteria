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
    public partial class ClientesAgregar : Form
    {
        // 1. NUEVO: Agregá esta propiedad pública
        public string CuitNuevoCliente { get; private set; }

        public ClientesAgregar()
        {
            InitializeComponent();
        }

        //private void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    // ... todo tu código de validación y conexión ...

        //    // Dentro del try-catch, después de ejecutar el INSERT
        //    // y confirmar que se guardó correctamente:
        //    if (idClienteParaEditar.HasValue) // Si es una edición
        //    {
        //        // ... tu lógica de UPDATE ...
        //    }
        //    else // Si es un ALTA NUEVA
        //    {
        //        // ... tu lógica de INSERT ...

        //        // 2. NUEVO: Justo antes de mostrar el MessageBox de éxito, guardamos el CUIT ingresado
        //        this.CuitNuevoCliente = txtCuil.Text;

        //        MessageBox.Show("Cliente guardado exitosamente.");
        //        this.DialogResult = DialogResult.OK; // <-- MUY IMPORTANTE: Indica que la operación fue exitosa
        //        this.Close();
        //    }
        //}
    }
}
