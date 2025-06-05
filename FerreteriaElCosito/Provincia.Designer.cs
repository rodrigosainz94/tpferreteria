namespace FerreteriaElCosito
{
    partial class Provincia
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
            this.txtidprovincia = new System.Windows.Forms.TextBox();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblvolveralinicio = new System.Windows.Forms.Label();
            this.btnconsulta = new System.Windows.Forms.Button();
            this.btnalta = new System.Windows.Forms.Button();
            this.btnbaja = new System.Windows.Forms.Button();
            this.btnmodificacion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblidprovincia
            // 
            this.lblidprovincia.AutoSize = true;
            this.lblidprovincia.Location = new System.Drawing.Point(55, 31);
            this.lblidprovincia.Name = "lblidprovincia";
            this.lblidprovincia.Size = new System.Drawing.Size(77, 16);
            this.lblidprovincia.TabIndex = 0;
            this.lblidprovincia.Text = "Id Provincia";
            // 
            // txtidprovincia
            // 
            this.txtidprovincia.Location = new System.Drawing.Point(175, 24);
            this.txtidprovincia.Name = "txtidprovincia";
            this.txtidprovincia.Size = new System.Drawing.Size(128, 22);
            this.txtidprovincia.TabIndex = 1;
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(175, 78);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(435, 22);
            this.txtnombre.TabIndex = 3;
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
            // lblvolveralinicio
            // 
            this.lblvolveralinicio.AutoSize = true;
            this.lblvolveralinicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblvolveralinicio.Location = new System.Drawing.Point(641, 386);
            this.lblvolveralinicio.Name = "lblvolveralinicio";
            this.lblvolveralinicio.Size = new System.Drawing.Size(134, 25);
            this.lblvolveralinicio.TabIndex = 38;
            this.lblvolveralinicio.Text = "Volver a Inicio";
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
            // Provincia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnconsulta);
            this.Controls.Add(this.btnalta);
            this.Controls.Add(this.btnbaja);
            this.Controls.Add(this.btnmodificacion);
            this.Controls.Add(this.lblvolveralinicio);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtidprovincia);
            this.Controls.Add(this.lblidprovincia);
            this.Name = "Provincia";
            this.Text = "Provincias";
            this.Load += new System.EventHandler(this.frmprovincia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblidprovincia;
        private System.Windows.Forms.TextBox txtidprovincia;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblvolveralinicio;
        private System.Windows.Forms.Button btnconsulta;
        private System.Windows.Forms.Button btnalta;
        private System.Windows.Forms.Button btnbaja;
        private System.Windows.Forms.Button btnmodificacion;
    }
}