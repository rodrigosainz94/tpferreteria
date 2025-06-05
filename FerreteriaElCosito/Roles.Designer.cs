namespace FerreteriaElCosito
{
    partial class Roles
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
            this.txtnombrerol = new System.Windows.Forms.TextBox();
            this.lblnombrerol = new System.Windows.Forms.Label();
            this.txtdescripcioniva = new System.Windows.Forms.TextBox();
            this.lbldescripcionrol = new System.Windows.Forms.Label();
            this.txtidrol = new System.Windows.Forms.TextBox();
            this.lblidrol = new System.Windows.Forms.Label();
            this.btnatras = new System.Windows.Forms.Button();
            this.btnconsulta = new System.Windows.Forms.Button();
            this.btnalta = new System.Windows.Forms.Button();
            this.btnbaja = new System.Windows.Forms.Button();
            this.btnmodificacion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtnombrerol
            // 
            this.txtnombrerol.Location = new System.Drawing.Point(203, 109);
            this.txtnombrerol.Name = "txtnombrerol";
            this.txtnombrerol.Size = new System.Drawing.Size(128, 22);
            this.txtnombrerol.TabIndex = 63;
            // 
            // lblnombrerol
            // 
            this.lblnombrerol.AutoSize = true;
            this.lblnombrerol.Location = new System.Drawing.Point(83, 116);
            this.lblnombrerol.Name = "lblnombrerol";
            this.lblnombrerol.Size = new System.Drawing.Size(80, 16);
            this.lblnombrerol.TabIndex = 62;
            this.lblnombrerol.Text = "Nombre Rol";
            // 
            // txtdescripcioniva
            // 
            this.txtdescripcioniva.Location = new System.Drawing.Point(198, 158);
            this.txtdescripcioniva.Multiline = true;
            this.txtdescripcioniva.Name = "txtdescripcioniva";
            this.txtdescripcioniva.Size = new System.Drawing.Size(315, 144);
            this.txtdescripcioniva.TabIndex = 61;
            // 
            // lbldescripcionrol
            // 
            this.lbldescripcionrol.AutoSize = true;
            this.lbldescripcionrol.Location = new System.Drawing.Point(83, 172);
            this.lbldescripcionrol.Name = "lbldescripcionrol";
            this.lbldescripcionrol.Size = new System.Drawing.Size(103, 16);
            this.lbldescripcionrol.TabIndex = 60;
            this.lbldescripcionrol.Text = "Descripcion Rol";
            // 
            // txtidrol
            // 
            this.txtidrol.Location = new System.Drawing.Point(203, 59);
            this.txtidrol.Name = "txtidrol";
            this.txtidrol.Size = new System.Drawing.Size(128, 22);
            this.txtidrol.TabIndex = 59;
            // 
            // lblidrol
            // 
            this.lblidrol.AutoSize = true;
            this.lblidrol.Location = new System.Drawing.Point(83, 66);
            this.lblidrol.Name = "lblidrol";
            this.lblidrol.Size = new System.Drawing.Size(42, 16);
            this.lblidrol.TabIndex = 58;
            this.lblidrol.Text = "Id Rol";
            // 
            // btnatras
            // 
            this.btnatras.Location = new System.Drawing.Point(650, 397);
            this.btnatras.Margin = new System.Windows.Forms.Padding(4);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(100, 28);
            this.btnatras.TabIndex = 64;
            this.btnatras.Text = "ATRAS";
            this.btnatras.UseVisualStyleBackColor = true;
            this.btnatras.Click += new System.EventHandler(this.btnatras_Click);
            // 
            // btnconsulta
            // 
            this.btnconsulta.Location = new System.Drawing.Point(13, 383);
            this.btnconsulta.Margin = new System.Windows.Forms.Padding(4);
            this.btnconsulta.Name = "btnconsulta";
            this.btnconsulta.Size = new System.Drawing.Size(100, 28);
            this.btnconsulta.TabIndex = 74;
            this.btnconsulta.Text = "Consulta";
            this.btnconsulta.UseVisualStyleBackColor = true;
            // 
            // btnalta
            // 
            this.btnalta.Location = new System.Drawing.Point(121, 383);
            this.btnalta.Margin = new System.Windows.Forms.Padding(4);
            this.btnalta.Name = "btnalta";
            this.btnalta.Size = new System.Drawing.Size(100, 28);
            this.btnalta.TabIndex = 73;
            this.btnalta.Text = "Alta";
            this.btnalta.UseVisualStyleBackColor = true;
            this.btnalta.Click += new System.EventHandler(this.btnalta_Click);
            // 
            // btnbaja
            // 
            this.btnbaja.Location = new System.Drawing.Point(231, 383);
            this.btnbaja.Margin = new System.Windows.Forms.Padding(4);
            this.btnbaja.Name = "btnbaja";
            this.btnbaja.Size = new System.Drawing.Size(100, 28);
            this.btnbaja.TabIndex = 72;
            this.btnbaja.Text = "Baja";
            this.btnbaja.UseVisualStyleBackColor = true;
            // 
            // btnmodificacion
            // 
            this.btnmodificacion.Location = new System.Drawing.Point(339, 383);
            this.btnmodificacion.Margin = new System.Windows.Forms.Padding(4);
            this.btnmodificacion.Name = "btnmodificacion";
            this.btnmodificacion.Size = new System.Drawing.Size(100, 28);
            this.btnmodificacion.TabIndex = 71;
            this.btnmodificacion.Text = "Modificacion";
            this.btnmodificacion.UseVisualStyleBackColor = true;
            // 
            // Roles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnconsulta);
            this.Controls.Add(this.btnalta);
            this.Controls.Add(this.btnbaja);
            this.Controls.Add(this.btnmodificacion);
            this.Controls.Add(this.btnatras);
            this.Controls.Add(this.txtnombrerol);
            this.Controls.Add(this.lblnombrerol);
            this.Controls.Add(this.txtdescripcioniva);
            this.Controls.Add(this.lbldescripcionrol);
            this.Controls.Add(this.txtidrol);
            this.Controls.Add(this.lblidrol);
            this.Name = "Roles";
            this.Text = "Roles";
            this.Load += new System.EventHandler(this.Roles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtnombrerol;
        private System.Windows.Forms.Label lblnombrerol;
        private System.Windows.Forms.TextBox txtdescripcioniva;
        private System.Windows.Forms.Label lbldescripcionrol;
        private System.Windows.Forms.TextBox txtidrol;
        private System.Windows.Forms.Label lblidrol;
        private System.Windows.Forms.Button btnatras;
        private System.Windows.Forms.Button btnconsulta;
        private System.Windows.Forms.Button btnalta;
        private System.Windows.Forms.Button btnbaja;
        private System.Windows.Forms.Button btnmodificacion;
    }
}