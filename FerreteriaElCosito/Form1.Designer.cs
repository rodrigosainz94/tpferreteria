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
            this.lblalta = new System.Windows.Forms.Label();
            this.lblbaja = new System.Windows.Forms.Label();
            this.lblmodificacion = new System.Windows.Forms.Label();
            this.lblconsulta = new System.Windows.Forms.Label();
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
            // lblalta
            // 
            this.lblalta.AutoSize = true;
            this.lblalta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblalta.Location = new System.Drawing.Point(149, 329);
            this.lblalta.Name = "lblalta";
            this.lblalta.Size = new System.Drawing.Size(41, 22);
            this.lblalta.TabIndex = 36;
            this.lblalta.Text = "Alta";
            // 
            // lblbaja
            // 
            this.lblbaja.AutoSize = true;
            this.lblbaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbaja.Location = new System.Drawing.Point(230, 329);
            this.lblbaja.Name = "lblbaja";
            this.lblbaja.Size = new System.Drawing.Size(46, 22);
            this.lblbaja.TabIndex = 35;
            this.lblbaja.Text = "Baja";
            // 
            // lblmodificacion
            // 
            this.lblmodificacion.AutoSize = true;
            this.lblmodificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmodificacion.Location = new System.Drawing.Point(338, 329);
            this.lblmodificacion.Name = "lblmodificacion";
            this.lblmodificacion.Size = new System.Drawing.Size(109, 22);
            this.lblmodificacion.TabIndex = 34;
            this.lblmodificacion.Text = "Modificacion";
            // 
            // lblconsulta
            // 
            this.lblconsulta.AutoSize = true;
            this.lblconsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblconsulta.Location = new System.Drawing.Point(35, 329);
            this.lblconsulta.Name = "lblconsulta";
            this.lblconsulta.Size = new System.Drawing.Size(81, 22);
            this.lblconsulta.TabIndex = 33;
            this.lblconsulta.Text = "Consulta";
            // 
            // Provincia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblvolveralinicio);
            this.Controls.Add(this.lblalta);
            this.Controls.Add(this.lblbaja);
            this.Controls.Add(this.lblmodificacion);
            this.Controls.Add(this.lblconsulta);
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
        private System.Windows.Forms.Label lblalta;
        private System.Windows.Forms.Label lblbaja;
        private System.Windows.Forms.Label lblmodificacion;
        private System.Windows.Forms.Label lblconsulta;
    }
}