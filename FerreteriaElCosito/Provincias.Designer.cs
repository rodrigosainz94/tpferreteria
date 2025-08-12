namespace FerreteriaElCosito
{
    partial class Provincias
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
            this.lblidprovincia = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnatras = new System.Windows.Forms.Label();
            this.btnconsulta = new System.Windows.Forms.Button();
            this.btnalta = new System.Windows.Forms.Button();
            this.btnbaja = new System.Windows.Forms.Button();
            this.btnmodificacion = new System.Windows.Forms.Button();
            this.cbidprovincia = new System.Windows.Forms.ComboBox();
            this.cbnombreprovincia = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblidprovincia
            // 
            this.lblidprovincia.AutoSize = true;
            this.lblidprovincia.Location = new System.Drawing.Point(55, 31);
            this.lblidprovincia.Name = "lblidprovincia";
            this.lblidprovincia.Size = new System.Drawing.Size(79, 16);
            this.lblidprovincia.TabIndex = 0;
            this.lblidprovincia.Text = "ID Provincia";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(55, 85);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(56, 16);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";
            // 
            // btnatras
            // 
            this.btnatras.AutoSize = true;
            this.btnatras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnatras.Location = new System.Drawing.Point(700, 400);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(41, 17);
            this.btnatras.TabIndex = 38;
            this.btnatras.Text = "Atras";
            // 
            // btnconsulta
            // 
            this.btnconsulta.Location = new System.Drawing.Point(26, 400);
            this.btnconsulta.Margin = new System.Windows.Forms.Padding(4);
            this.btnconsulta.Name = "btnconsulta";
            this.btnconsulta.Size = new System.Drawing.Size(100, 28);
            this.btnconsulta.TabIndex = 74;
            this.btnconsulta.Text = "Consulta";
            this.btnconsulta.UseVisualStyleBackColor = true;
            // 
            // btnalta
            // 
            this.btnalta.Location = new System.Drawing.Point(134, 400);
            this.btnalta.Margin = new System.Windows.Forms.Padding(4);
            this.btnalta.Name = "btnalta";
            this.btnalta.Size = new System.Drawing.Size(100, 28);
            this.btnalta.TabIndex = 73;
            this.btnalta.Text = "Alta";
            this.btnalta.UseVisualStyleBackColor = true;
            // 
            // btnbaja
            // 
            this.btnbaja.Location = new System.Drawing.Point(251, 400);
            this.btnbaja.Margin = new System.Windows.Forms.Padding(4);
            this.btnbaja.Name = "btnbaja";
            this.btnbaja.Size = new System.Drawing.Size(100, 28);
            this.btnbaja.TabIndex = 72;
            this.btnbaja.Text = "Baja";
            this.btnbaja.UseVisualStyleBackColor = true;
            // 
            // btnmodificacion
            // 
            this.btnmodificacion.Location = new System.Drawing.Point(369, 400);
            this.btnmodificacion.Margin = new System.Windows.Forms.Padding(4);
            this.btnmodificacion.Name = "btnmodificacion";
            this.btnmodificacion.Size = new System.Drawing.Size(100, 28);
            this.btnmodificacion.TabIndex = 71;
            this.btnmodificacion.Text = "Modificacion";
            this.btnmodificacion.UseVisualStyleBackColor = true;
            // 
            // cbidprovincia
            // 
            this.cbidprovincia.FormattingEnabled = true;
            this.cbidprovincia.Location = new System.Drawing.Point(175, 31);
            this.cbidprovincia.Name = "cbidprovincia";
            this.cbidprovincia.Size = new System.Drawing.Size(121, 24);
            this.cbidprovincia.TabIndex = 75;
            // 
            // cbnombreprovincia
            // 
            this.cbnombreprovincia.FormattingEnabled = true;
            this.cbnombreprovincia.Location = new System.Drawing.Point(175, 77);
            this.cbnombreprovincia.Name = "cbnombreprovincia";
            this.cbnombreprovincia.Size = new System.Drawing.Size(452, 24);
            this.cbnombreprovincia.TabIndex = 76;
            // 
            // Provincias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbnombreprovincia);
            this.Controls.Add(this.cbidprovincia);
            this.Controls.Add(this.btnconsulta);
            this.Controls.Add(this.btnalta);
            this.Controls.Add(this.btnbaja);
            this.Controls.Add(this.btnmodificacion);
            this.Controls.Add(this.btnatras);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblidprovincia);
            this.Name = "Provincias";
            this.Text = "Provincias";
            this.Load += new System.EventHandler(this.frmprovincia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblidprovincia;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label btnatras;
        private System.Windows.Forms.Button btnconsulta;
        private System.Windows.Forms.Button btnalta;
        private System.Windows.Forms.Button btnbaja;
        private System.Windows.Forms.Button btnmodificacion;
        private System.Windows.Forms.ComboBox cbidprovincia;
        private System.Windows.Forms.ComboBox cbnombreprovincia;
    }
}