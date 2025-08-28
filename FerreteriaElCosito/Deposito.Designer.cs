namespace FerreteriaElCosito
{
    partial class frmdeposito
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.cbnombredeposito = new System.Windows.Forms.ComboBox();
            this.cbiddeposito = new System.Windows.Forms.ComboBox();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnModificacion = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.lblnombredeposito = new System.Windows.Forms.Label();
            this.lbliddeposito = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbnombredeposito
            // 
            this.cbnombredeposito.FormattingEnabled = true;
            this.cbnombredeposito.Location = new System.Drawing.Point(192, 73);
            this.cbnombredeposito.Name = "cbnombredeposito";
            this.cbnombredeposito.Size = new System.Drawing.Size(452, 24);
            this.cbnombredeposito.TabIndex = 17;
            // 
            // cbiddeposito
            // 
            this.cbiddeposito.FormattingEnabled = true;
            this.cbiddeposito.Location = new System.Drawing.Point(192, 27);
            this.cbiddeposito.Name = "cbiddeposito";
            this.cbiddeposito.Size = new System.Drawing.Size(121, 24);
            this.cbiddeposito.TabIndex = 16;
            // 
            // btnConsulta
            // 
            this.btnConsulta.Location = new System.Drawing.Point(43, 396);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(100, 28);
            this.btnConsulta.TabIndex = 12;
            this.btnConsulta.Text = "Consulta";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(151, 396);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(100, 28);
            this.btnAlta.TabIndex = 13;
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(268, 396);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(100, 28);
            this.btnBaja.TabIndex = 14;
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnModificacion
            // 
            this.btnModificacion.Location = new System.Drawing.Point(386, 396);
            this.btnModificacion.Name = "btnModificacion";
            this.btnModificacion.Size = new System.Drawing.Size(100, 28);
            this.btnModificacion.TabIndex = 15;
            this.btnModificacion.Text = "Modificar";
            this.btnModificacion.UseVisualStyleBackColor = true;
            this.btnModificacion.Click += new System.EventHandler(this.btnModificacion_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(717, 396);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(100, 28);
            this.btnAtras.TabIndex = 11;
            this.btnAtras.Text = "Atrás";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // lblnombredeposito
            // 
            this.lblnombredeposito.AutoSize = true;
            this.lblnombredeposito.Location = new System.Drawing.Point(72, 81);
            this.lblnombredeposito.Name = "lblnombredeposito";
            this.lblnombredeposito.Size = new System.Drawing.Size(114, 16);
            this.lblnombredeposito.TabIndex = 10;
            this.lblnombredeposito.Text = "Nombre Depósito";
            // 
            // lbliddeposito
            // 
            this.lbliddeposito.AutoSize = true;
            this.lbliddeposito.Location = new System.Drawing.Point(72, 27);
            this.lbliddeposito.Name = "lbliddeposito";
            this.lbliddeposito.Size = new System.Drawing.Size(78, 16);
            this.lbliddeposito.TabIndex = 9;
            this.lbliddeposito.Text = "ID Depósito";
            // 
            // frmdeposito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 450);
            this.Controls.Add(this.cbnombredeposito);
            this.Controls.Add(this.cbiddeposito);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnModificacion);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.lblnombredeposito);
            this.Controls.Add(this.lbliddeposito);
            this.Name = "frmdeposito";
            this.Text = "Depósitos";
            this.Load += new System.EventHandler(this.frmdeposito_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cbnombredeposito;
        private System.Windows.Forms.ComboBox cbiddeposito;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnModificacion;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label lblnombredeposito;
        private System.Windows.Forms.Label lbliddeposito;
    }
}