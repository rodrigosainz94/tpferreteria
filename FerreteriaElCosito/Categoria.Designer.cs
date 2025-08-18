namespace FerreteriaElCosito
{
    partial class Frmcategoria
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
            this.cbcategoria = new System.Windows.Forms.ComboBox();
            this.cbidcategoria = new System.Windows.Forms.ComboBox();
            this.lblcategoria = new System.Windows.Forms.Label();
            this.lblidcategoria = new System.Windows.Forms.Label();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnModificacion = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbcategoria
            // 
            this.cbcategoria.FormattingEnabled = true;
            this.cbcategoria.Location = new System.Drawing.Point(185, 78);
            this.cbcategoria.Name = "cbcategoria";
            this.cbcategoria.Size = new System.Drawing.Size(452, 24);
            this.cbcategoria.TabIndex = 12;
            // 
            // cbidcategoria
            // 
            this.cbidcategoria.FormattingEnabled = true;
            this.cbidcategoria.Location = new System.Drawing.Point(185, 32);
            this.cbidcategoria.Name = "cbidcategoria";
            this.cbidcategoria.Size = new System.Drawing.Size(121, 24);
            this.cbidcategoria.TabIndex = 11;
            // 
            // lblcategoria
            // 
            this.lblcategoria.AutoSize = true;
            this.lblcategoria.Location = new System.Drawing.Point(65, 86);
            this.lblcategoria.Name = "lblcategoria";
            this.lblcategoria.Size = new System.Drawing.Size(66, 16);
            this.lblcategoria.TabIndex = 10;
            this.lblcategoria.Text = "Categoria";
            // 
            // lblidcategoria
            // 
            this.lblidcategoria.AutoSize = true;
            this.lblidcategoria.Location = new System.Drawing.Point(65, 32);
            this.lblidcategoria.Name = "lblidcategoria";
            this.lblidcategoria.Size = new System.Drawing.Size(82, 16);
            this.lblidcategoria.TabIndex = 9;
            this.lblidcategoria.Text = "ID Categoria";
            // 
            // btnConsulta
            // 
            this.btnConsulta.Location = new System.Drawing.Point(32, 397);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(100, 28);
            this.btnConsulta.TabIndex = 14;
            this.btnConsulta.Text = "Consulta";
            this.btnConsulta.UseVisualStyleBackColor = true;
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(140, 397);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(100, 28);
            this.btnAlta.TabIndex = 15;
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(257, 397);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(100, 28);
            this.btnBaja.TabIndex = 16;
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            // 
            // btnModificacion
            // 
            this.btnModificacion.Location = new System.Drawing.Point(375, 397);
            this.btnModificacion.Name = "btnModificacion";
            this.btnModificacion.Size = new System.Drawing.Size(100, 28);
            this.btnModificacion.TabIndex = 17;
            this.btnModificacion.Text = "Modifica";
            this.btnModificacion.UseVisualStyleBackColor = true;
            // 
            // btnAtras
            // 
            this.btnAtras.AutoSize = true;
            this.btnAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnAtras.Location = new System.Drawing.Point(706, 397);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(41, 17);
            this.btnAtras.TabIndex = 13;
            this.btnAtras.Text = "Atrás";
            // 
            // Frmcategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnModificacion);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.cbcategoria);
            this.Controls.Add(this.cbidcategoria);
            this.Controls.Add(this.lblcategoria);
            this.Controls.Add(this.lblidcategoria);
            this.Name = "Frmcategoria";
            this.Text = "Categoria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbcategoria;
        private System.Windows.Forms.ComboBox cbidcategoria;
        private System.Windows.Forms.Label lblcategoria;
        private System.Windows.Forms.Label lblidcategoria;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnModificacion;
        private System.Windows.Forms.Label btnAtras;
    }
}