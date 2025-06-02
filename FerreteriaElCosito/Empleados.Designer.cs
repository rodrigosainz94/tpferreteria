namespace FerreteriaElCosito
{
    partial class Empleados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblidempleado = new System.Windows.Forms.Label();
            this.txtidempleado = new System.Windows.Forms.TextBox();
            this.txtapellido = new System.Windows.Forms.TextBox();
            this.lblapellido = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.lblnombre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblidempleado
            // 
            this.lblidempleado.AutoSize = true;
            this.lblidempleado.Location = new System.Drawing.Point(13, 13);
            this.lblidempleado.Name = "lblidempleado";
            this.lblidempleado.Size = new System.Drawing.Size(84, 16);
            this.lblidempleado.TabIndex = 0;
            this.lblidempleado.Text = "Id Empleado";
            // 
            // txtidempleado
            // 
            this.txtidempleado.Location = new System.Drawing.Point(124, 6);
            this.txtidempleado.Name = "txtidempleado";
            this.txtidempleado.Size = new System.Drawing.Size(100, 22);
            this.txtidempleado.TabIndex = 1;
            // 
            // txtapellido
            // 
            this.txtapellido.Location = new System.Drawing.Point(438, 42);
            this.txtapellido.Name = "txtapellido";
            this.txtapellido.Size = new System.Drawing.Size(279, 22);
            this.txtapellido.TabIndex = 3;
            // 
            // lblapellido
            // 
            this.lblapellido.AutoSize = true;
            this.lblapellido.Location = new System.Drawing.Point(365, 45);
            this.lblapellido.Name = "lblapellido";
            this.lblapellido.Size = new System.Drawing.Size(57, 16);
            this.lblapellido.TabIndex = 2;
            this.lblapellido.Text = "Apellido";
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(75, 39);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(250, 22);
            this.txtnombre.TabIndex = 5;
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.Location = new System.Drawing.Point(13, 45);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(56, 16);
            this.lblnombre.TabIndex = 4;
            this.lblnombre.Text = "Nombre";
            // 
            // Empleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.lblnombre);
            this.Controls.Add(this.txtapellido);
            this.Controls.Add(this.lblapellido);
            this.Controls.Add(this.txtidempleado);
            this.Controls.Add(this.lblidempleado);
            this.Name = "Empleados";
            this.Text = "Empleados";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblidempleado;
        private System.Windows.Forms.TextBox txtidempleado;
        private System.Windows.Forms.TextBox txtapellido;
        private System.Windows.Forms.Label lblapellido;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label lblnombre;
    }
}