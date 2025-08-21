namespace FerreteriaElCosito
{
    partial class frmcategoria
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            this.cbcategoria = new System.Windows.Forms.ComboBox();
            this.cbidcategoria = new System.Windows.Forms.ComboBox();
            this.btnConculta = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnModificacion = new System.Windows.Forms.Button();
            this.lblcategoria = new System.Windows.Forms.Label();
            this.lblIDProvincia = new System.Windows.Forms.Label();
            this.lblidcategoria = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbcategoria
            // 
            this.cbcategoria.FormattingEnabled = true;
            this.cbcategoria.Location = new System.Drawing.Point(95, 144);
            this.cbcategoria.Name = "cbcategoria";
            this.cbcategoria.Size = new System.Drawing.Size(452, 24);
            this.cbcategoria.TabIndex = 17;
            // 
            // cbidcategoria
            // 
            this.cbidcategoria.FormattingEnabled = true;
            this.cbidcategoria.Location = new System.Drawing.Point(95, 75);
            this.cbidcategoria.Name = "cbidcategoria";
            this.cbidcategoria.Size = new System.Drawing.Size(121, 24);
            this.cbidcategoria.TabIndex = 16;
            // 
            // btnConculta
            // 
            this.btnConculta.Location = new System.Drawing.Point(15, 332);
            this.btnConculta.Name = "btnConculta";
            this.btnConculta.Size = new System.Drawing.Size(100, 28);
            this.btnConculta.TabIndex = 12;
            this.btnConculta.Text = "Consulta";
            this.btnConculta.UseVisualStyleBackColor = true;
            this.btnConculta.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(123, 332);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(100, 28);
            this.btnAlta.TabIndex = 13;
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click_1);
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(240, 332);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(100, 28);
            this.btnBaja.TabIndex = 14;
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnModificacion
            // 
            this.btnModificacion.Location = new System.Drawing.Point(358, 332);
            this.btnModificacion.Name = "btnModificacion";
            this.btnModificacion.Size = new System.Drawing.Size(100, 28);
            this.btnModificacion.TabIndex = 15;
            this.btnModificacion.Text = "Modifica";
            this.btnModificacion.UseVisualStyleBackColor = true;
            this.btnModificacion.Click += new System.EventHandler(this.btnModificacion_Click);
            // 
            // lblcategoria
            // 
            this.lblcategoria.AutoSize = true;
            this.lblcategoria.Location = new System.Drawing.Point(3, 144);
            this.lblcategoria.Name = "lblcategoria";
            this.lblcategoria.Size = new System.Drawing.Size(66, 16);
            this.lblcategoria.TabIndex = 10;
            this.lblcategoria.Text = "Categoria";
            // 
            // lblIDProvincia
            // 
            this.lblIDProvincia.AutoSize = true;
            this.lblIDProvincia.Location = new System.Drawing.Point(-25, -16);
            this.lblIDProvincia.Name = "lblIDProvincia";
            this.lblIDProvincia.Size = new System.Drawing.Size(79, 16);
            this.lblIDProvincia.TabIndex = 9;
            this.lblIDProvincia.Text = "ID Provincia";
            // 
            // lblidcategoria
            // 
            this.lblidcategoria.AutoSize = true;
            this.lblidcategoria.Location = new System.Drawing.Point(3, 78);
            this.lblidcategoria.Name = "lblidcategoria";
            this.lblidcategoria.Size = new System.Drawing.Size(82, 16);
            this.lblidcategoria.TabIndex = 18;
            this.lblidcategoria.Text = "ID Categoria";
            // 
            // btnAtras
            // 
            this.btnAtras.AutoSize = true;
            this.btnAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnAtras.Location = new System.Drawing.Point(535, 338);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(41, 17);
            this.btnAtras.TabIndex = 19;
            this.btnAtras.Text = "Atrás";
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click_1);
            // 
            // frmcategoria
            // 
            this.ClientSize = new System.Drawing.Size(626, 394);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.lblidcategoria);
            this.Controls.Add(this.cbcategoria);
            this.Controls.Add(this.cbidcategoria);
            this.Controls.Add(this.btnConculta);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnModificacion);
            this.Controls.Add(this.lblcategoria);
            this.Controls.Add(this.lblIDProvincia);
            this.Name = "frmcategoria";
            this.Text = "Categoria";
            this.Load += new System.EventHandler(this.Frmcategoria_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox cbcategoria;
        private System.Windows.Forms.ComboBox cbidcategoria;
        private System.Windows.Forms.Button btnConculta;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnModificacion;
        private System.Windows.Forms.Label lblcategoria;
        private System.Windows.Forms.Label lblIDProvincia;
        private System.Windows.Forms.Label lblidcategoria;
        private System.Windows.Forms.Label btnAtras;
    }
}