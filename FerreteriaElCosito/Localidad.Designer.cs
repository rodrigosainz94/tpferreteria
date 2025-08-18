using System.Windows.Forms;

namespace FerreteriaElCosito
{
    partial class Localidad
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

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lbllocalidad = new System.Windows.Forms.Label();
            this.btnatras = new System.Windows.Forms.Button();
            this.btnmodificacion = new System.Windows.Forms.Button();
            this.btnbaja = new System.Windows.Forms.Button();
            this.btnalta = new System.Windows.Forms.Button();
            this.btnlimpiar = new System.Windows.Forms.Button();
            this.cbnombrelocalidad = new System.Windows.Forms.ComboBox();
            this.cbidlocalidad = new System.Windows.Forms.ComboBox();
            this.cbnombreprovincia = new System.Windows.Forms.ComboBox();
            this.cbidprovincia = new System.Windows.Forms.ComboBox();
            this.lblNombrePcia = new System.Windows.Forms.Label();
            this.lblIDProvincia = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 45;
            this.label1.Text = "Nombre Localidad";
            // 
            // lbllocalidad
            // 
            this.lbllocalidad.AutoSize = true;
            this.lbllocalidad.Location = new System.Drawing.Point(54, 39);
            this.lbllocalidad.Name = "lbllocalidad";
            this.lbllocalidad.Size = new System.Drawing.Size(83, 16);
            this.lbllocalidad.TabIndex = 43;
            this.lbllocalidad.Text = "ID Localidad";
            // 
            // btnatras
            // 
            this.btnatras.Location = new System.Drawing.Point(687, 409);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(100, 28);
            this.btnatras.TabIndex = 66;
            this.btnatras.Text = "ATRAS";
            this.btnatras.UseVisualStyleBackColor = true;
            this.btnatras.Click += new System.EventHandler(this.btnatras_Click);
            // 
            // btnmodificacion
            // 
            this.btnmodificacion.Location = new System.Drawing.Point(363, 398);
            this.btnmodificacion.Name = "btnmodificacion";
            this.btnmodificacion.Size = new System.Drawing.Size(100, 28);
            this.btnmodificacion.TabIndex = 67;
            this.btnmodificacion.Text = "Modificación";
            this.btnmodificacion.UseVisualStyleBackColor = true;
            this.btnmodificacion.Click += new System.EventHandler(this.btnmodificacion_Click);
            // 
            // btnbaja
            // 
            this.btnbaja.Location = new System.Drawing.Point(245, 398);
            this.btnbaja.Name = "btnbaja";
            this.btnbaja.Size = new System.Drawing.Size(100, 28);
            this.btnbaja.TabIndex = 68;
            this.btnbaja.Text = "Baja";
            this.btnbaja.UseVisualStyleBackColor = true;
            this.btnbaja.Click += new System.EventHandler(this.btnbaja_Click);
            // 
            // btnalta
            // 
            this.btnalta.Location = new System.Drawing.Point(128, 398);
            this.btnalta.Name = "btnalta";
            this.btnalta.Size = new System.Drawing.Size(100, 28);
            this.btnalta.TabIndex = 69;
            this.btnalta.Text = "Alta";
            this.btnalta.UseVisualStyleBackColor = true;
            this.btnalta.Click += new System.EventHandler(this.btnalta_Click);
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.Location = new System.Drawing.Point(20, 398);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(100, 28);
            this.btnlimpiar.TabIndex = 70;
            this.btnlimpiar.Text = "Limpiar";
            this.btnlimpiar.UseVisualStyleBackColor = true;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // cbnombrelocalidad
            // 
            this.cbnombrelocalidad.FormattingEnabled = true;
            this.cbnombrelocalidad.Location = new System.Drawing.Point(174, 85);
            this.cbnombrelocalidad.Name = "cbnombrelocalidad";
            this.cbnombrelocalidad.Size = new System.Drawing.Size(452, 24);
            this.cbnombrelocalidad.TabIndex = 78;
            this.cbnombrelocalidad.SelectedIndexChanged += new System.EventHandler(this.cbnombrelocalidad_SelectedIndexChanged);
            // 
            // cbidlocalidad
            // 
            this.cbidlocalidad.FormattingEnabled = true;
            this.cbidlocalidad.Location = new System.Drawing.Point(174, 39);
            this.cbidlocalidad.Name = "cbidlocalidad";
            this.cbidlocalidad.Size = new System.Drawing.Size(121, 24);
            this.cbidlocalidad.TabIndex = 77;
            this.cbidlocalidad.SelectedIndexChanged += new System.EventHandler(this.cbidlocalidad_SelectedIndexChanged);
            // 
            // cbnombreprovincia
            // 
            this.cbnombreprovincia.FormattingEnabled = true;
            this.cbnombreprovincia.Location = new System.Drawing.Point(174, 212);
            this.cbnombreprovincia.Name = "cbnombreprovincia";
            this.cbnombreprovincia.Size = new System.Drawing.Size(452, 24);
            this.cbnombreprovincia.TabIndex = 82;
            // 
            // cbidprovincia
            // 
            this.cbidprovincia.FormattingEnabled = true;
            this.cbidprovincia.Location = new System.Drawing.Point(174, 166);
            this.cbidprovincia.Name = "cbidprovincia";
            this.cbidprovincia.Size = new System.Drawing.Size(121, 24);
            this.cbidprovincia.TabIndex = 81;
            // 
            // lblNombrePcia
            // 
            this.lblNombrePcia.AutoSize = true;
            this.lblNombrePcia.Location = new System.Drawing.Point(54, 220);
            this.lblNombrePcia.Name = "lblNombrePcia";
            this.lblNombrePcia.Size = new System.Drawing.Size(86, 16);
            this.lblNombrePcia.TabIndex = 80;
            this.lblNombrePcia.Text = "Nombre Pcia";
            // 
            // lblIDProvincia
            // 
            this.lblIDProvincia.AutoSize = true;
            this.lblIDProvincia.Location = new System.Drawing.Point(54, 166);
            this.lblIDProvincia.Name = "lblIDProvincia";
            this.lblIDProvincia.Size = new System.Drawing.Size(79, 16);
            this.lblIDProvincia.TabIndex = 79;
            this.lblIDProvincia.Text = "ID Provincia";
            // 
            // Localidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbnombreprovincia);
            this.Controls.Add(this.cbidprovincia);
            this.Controls.Add(this.lblNombrePcia);
            this.Controls.Add(this.lblIDProvincia);
            this.Controls.Add(this.cbnombrelocalidad);
            this.Controls.Add(this.cbidlocalidad);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.btnalta);
            this.Controls.Add(this.btnbaja);
            this.Controls.Add(this.btnmodificacion);
            this.Controls.Add(this.btnatras);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbllocalidad);
            this.Name = "Localidad";
            this.Text = "Localidad";
            this.Load += new System.EventHandler(this.Localidad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbllocalidad;
        private System.Windows.Forms.Button btnatras;
        private System.Windows.Forms.Button btnmodificacion;
        private System.Windows.Forms.Button btnbaja;
        private System.Windows.Forms.Button btnalta;
        private System.Windows.Forms.Button btnlimpiar;
        private System.Windows.Forms.ComboBox cbnombrelocalidad;
        private System.Windows.Forms.ComboBox cbidlocalidad;
        private ComboBox cbnombreprovincia;
        private ComboBox cbidprovincia;
        private Label lblNombrePcia;
        private Label lblIDProvincia;
    }
}