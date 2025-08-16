using FerreteriaElCosito;

namespace FerreteriaElCosito
{
    partial class Provincias
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
            this.lblIDProvincia = new System.Windows.Forms.Label();
            this.lblNombrePcia = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.Label();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnModificacion = new System.Windows.Forms.Button();
            this.cbidprovincia = new System.Windows.Forms.ComboBox();
            this.cbnombreprovincia = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblIDProvincia
            // 
            this.lblIDProvincia.AutoSize = true;
            this.lblIDProvincia.Location = new System.Drawing.Point(55, 31);
            this.lblIDProvincia.Name = "lblIDProvincia";
            this.lblIDProvincia.Size = new System.Drawing.Size(79, 16);
            this.lblIDProvincia.TabIndex = 0;
            this.lblIDProvincia.Text = "ID Provincia";
            // 
            // lblNombrePcia
            // 
            this.lblNombrePcia.AutoSize = true;
            this.lblNombrePcia.Location = new System.Drawing.Point(55, 85);
            this.lblNombrePcia.Name = "lblNombrePcia";
            this.lblNombrePcia.Size = new System.Drawing.Size(86, 16);
            this.lblNombrePcia.TabIndex = 1;
            this.lblNombrePcia.Text = "Nombre Pcia";
            // 
            // btnAtras
            // 
            this.btnAtras.AutoSize = true;
            this.btnAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnAtras.Location = new System.Drawing.Point(700, 400);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(41, 17);
            this.btnAtras.TabIndex = 2;
            this.btnAtras.Text = "Atrás";
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnConsulta
            // 
            this.btnConsulta.Location = new System.Drawing.Point(26, 400);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(100, 28);
            this.btnConsulta.TabIndex = 3;
            this.btnConsulta.Text = "Consulta";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(134, 400);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(100, 28);
            this.btnAlta.TabIndex = 4;
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(251, 400);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(100, 28);
            this.btnBaja.TabIndex = 5;
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnModificacion
            // 
            this.btnModificacion.Location = new System.Drawing.Point(369, 400);
            this.btnModificacion.Name = "btnModificacion";
            this.btnModificacion.Size = new System.Drawing.Size(100, 28);
            this.btnModificacion.TabIndex = 6;
            this.btnModificacion.Text = "Modifica";
            this.btnModificacion.UseVisualStyleBackColor = true;
            this.btnModificacion.Click += new System.EventHandler(this.btnModificacion_Click);
            // 
            // cbidprovincia
            // 
            this.cbidprovincia.FormattingEnabled = true;
            this.cbidprovincia.Location = new System.Drawing.Point(175, 31);
            this.cbidprovincia.Name = "cbidprovincia";
            this.cbidprovincia.Size = new System.Drawing.Size(121, 24);
            this.cbidprovincia.TabIndex = 7;
            // 
            // cbnombreprovincia
            // 
            this.cbnombreprovincia.FormattingEnabled = true;
            this.cbnombreprovincia.Location = new System.Drawing.Point(175, 77);
            this.cbnombreprovincia.Name = "cbnombreprovincia";
            this.cbnombreprovincia.Size = new System.Drawing.Size(452, 24);
            this.cbnombreprovincia.TabIndex = 8;
            // 
            // Provincias
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbnombreprovincia);
            this.Controls.Add(this.cbidprovincia);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnModificacion);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.lblNombrePcia);
            this.Controls.Add(this.lblIDProvincia);
            this.Name = "Provincias";
            this.Text = "Provincias";
            this.Load += new System.EventHandler(this.frmprovincia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIDProvincia;
        private System.Windows.Forms.Label lblNombrePcia;
        private System.Windows.Forms.Label btnAtras;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnModificacion;
        private System.Windows.Forms.ComboBox cbidprovincia;
        private System.Windows.Forms.ComboBox cbnombreprovincia;
    }
}
