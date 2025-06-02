namespace FerreteriaElCosito
{
    partial class ProveedoresEdicion
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
            this.lblidprov = new System.Windows.Forms.Label();
            this.lblnombreprov = new System.Windows.Forms.Label();
            this.lblapellidoprov = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblidprov
            // 
            this.lblidprov.AutoSize = true;
            this.lblidprov.Location = new System.Drawing.Point(13, 13);
            this.lblidprov.Name = "lblidprov";
            this.lblidprov.Size = new System.Drawing.Size(90, 16);
            this.lblidprov.TabIndex = 0;
            this.lblidprov.Text = "ID Proveedor:";
            // 
            // lblnombreprov
            // 
            this.lblnombreprov.AutoSize = true;
            this.lblnombreprov.Location = new System.Drawing.Point(13, 38);
            this.lblnombreprov.Name = "lblnombreprov";
            this.lblnombreprov.Size = new System.Drawing.Size(59, 16);
            this.lblnombreprov.TabIndex = 1;
            this.lblnombreprov.Text = "Nombre:";
            // 
            // lblapellidoprov
            // 
            this.lblapellidoprov.AutoSize = true;
            this.lblapellidoprov.Location = new System.Drawing.Point(13, 64);
            this.lblapellidoprov.Name = "lblapellidoprov";
            this.lblapellidoprov.Size = new System.Drawing.Size(60, 16);
            this.lblapellidoprov.TabIndex = 2;
            this.lblapellidoprov.Text = "Apellido:";
            // 
            // ProveedoresEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblapellidoprov);
            this.Controls.Add(this.lblnombreprov);
            this.Controls.Add(this.lblidprov);
            this.Name = "ProveedoresEdicion";
            this.Text = "ProveedoresEdicion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblidprov;
        private System.Windows.Forms.Label lblnombreprov;
        private System.Windows.Forms.Label lblapellidoprov;
    }
}