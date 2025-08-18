namespace FerreteriaElCosito
{
    partial class Facturar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Facturar));
            this.dgvfacturacion = new System.Windows.Forms.DataGridView();
            this.lblfecha = new System.Windows.Forms.Label();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.lblcodigo = new System.Windows.Forms.Label();
            this.lblnombre = new System.Windows.Forms.Label();
            this.btnagregar = new System.Windows.Forms.Button();
            this.btneliminar = new System.Windows.Forms.Button();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.lbltotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnatras = new System.Windows.Forms.Button();
            this.lbldni = new System.Windows.Forms.Label();
            this.txtdni = new System.Windows.Forms.TextBox();
            this.cbconsumidorfinal = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cmbnombre = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfacturacion)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvfacturacion
            // 
            this.dgvfacturacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvfacturacion.Location = new System.Drawing.Point(393, 57);
            this.dgvfacturacion.Margin = new System.Windows.Forms.Padding(4);
            this.dgvfacturacion.Name = "dgvfacturacion";
            this.dgvfacturacion.RowHeadersWidth = 51;
            this.dgvfacturacion.Size = new System.Drawing.Size(608, 450);
            this.dgvfacturacion.TabIndex = 0;
            this.dgvfacturacion.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvfacturacion_CellEndEdit);
            this.dgvfacturacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvfacturacion_KeyDown);
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.Location = new System.Drawing.Point(857, 22);
            this.lblfecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(126, 16);
            this.lblfecha.TabIndex = 1;
            this.lblfecha.Text = "hora y fecha : 1 2 3 4";
            // 
            // txtcodigo
            // 
            this.txtcodigo.Location = new System.Drawing.Point(168, 123);
            this.txtcodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(183, 22);
            this.txtcodigo.TabIndex = 2;
            this.txtcodigo.Text = "40";
            this.txtcodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcodigo_KeyDown);
            // 
            // lblcodigo
            // 
            this.lblcodigo.AutoSize = true;
            this.lblcodigo.Location = new System.Drawing.Point(89, 126);
            this.lblcodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblcodigo.Name = "lblcodigo";
            this.lblcodigo.Size = new System.Drawing.Size(65, 16);
            this.lblcodigo.TabIndex = 3;
            this.lblcodigo.Text = "CÓDIGO :";
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.Location = new System.Drawing.Point(89, 158);
            this.lblnombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(72, 16);
            this.lblnombre.TabIndex = 5;
            this.lblnombre.Text = "NOMBRE :";
            // 
            // btnagregar
            // 
            this.btnagregar.Location = new System.Drawing.Point(93, 202);
            this.btnagregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(100, 28);
            this.btnagregar.TabIndex = 6;
            this.btnagregar.Text = "AGREGAR";
            this.btnagregar.UseVisualStyleBackColor = true;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // btneliminar
            // 
            this.btneliminar.Location = new System.Drawing.Point(255, 202);
            this.btneliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(100, 28);
            this.btneliminar.TabIndex = 7;
            this.btneliminar.Text = "ELIMINAR";
            this.btneliminar.UseVisualStyleBackColor = true;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // txttotal
            // 
            this.txttotal.Location = new System.Drawing.Point(868, 514);
            this.txttotal.Margin = new System.Windows.Forms.Padding(4);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(132, 22);
            this.txttotal.TabIndex = 8;
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Location = new System.Drawing.Point(796, 523);
            this.lbltotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(57, 16);
            this.lbltotal.TabIndex = 9;
            this.lbltotal.Text = "TOTAL :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(135, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "FERRETERIA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(135, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 29);
            this.label2.TabIndex = 11;
            this.label2.Text = "\" EL COSITO \"";
            // 
            // btnatras
            // 
            this.btnatras.Location = new System.Drawing.Point(32, 511);
            this.btnatras.Margin = new System.Windows.Forms.Padding(4);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(100, 28);
            this.btnatras.TabIndex = 12;
            this.btnatras.Text = "ATRAS";
            this.btnatras.UseVisualStyleBackColor = true;
            this.btnatras.Click += new System.EventHandler(this.btnatras_Click);
            // 
            // lbldni
            // 
            this.lbldni.AutoSize = true;
            this.lbldni.Location = new System.Drawing.Point(89, 268);
            this.lbldni.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldni.Name = "lbldni";
            this.lbldni.Size = new System.Drawing.Size(36, 16);
            this.lbldni.TabIndex = 13;
            this.lbldni.Text = "DNI :";
            // 
            // txtdni
            // 
            this.txtdni.Location = new System.Drawing.Point(171, 260);
            this.txtdni.Margin = new System.Windows.Forms.Padding(4);
            this.txtdni.Name = "txtdni";
            this.txtdni.Size = new System.Drawing.Size(183, 22);
            this.txtdni.TabIndex = 14;
            // 
            // cbconsumidorfinal
            // 
            this.cbconsumidorfinal.AutoSize = true;
            this.cbconsumidorfinal.Location = new System.Drawing.Point(93, 292);
            this.cbconsumidorfinal.Margin = new System.Windows.Forms.Padding(4);
            this.cbconsumidorfinal.Name = "cbconsumidorfinal";
            this.cbconsumidorfinal.Size = new System.Drawing.Size(161, 20);
            this.cbconsumidorfinal.TabIndex = 15;
            this.cbconsumidorfinal.Text = "CONSUMIDOR FINAL";
            this.cbconsumidorfinal.UseVisualStyleBackColor = true;
            // 
            // cmbnombre
            // 
            this.cmbnombre.FormattingEnabled = true;
            this.cmbnombre.Location = new System.Drawing.Point(168, 155);
            this.cmbnombre.Name = "cmbnombre";
            this.cmbnombre.Size = new System.Drawing.Size(183, 24);
            this.cmbnombre.TabIndex = 16;
            this.cmbnombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbnombre_KeyDown);
            // 
            // Facturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.cmbnombre);
            this.Controls.Add(this.cbconsumidorfinal);
            this.Controls.Add(this.txtdni);
            this.Controls.Add(this.lbldni);
            this.Controls.Add(this.btnatras);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbltotal);
            this.Controls.Add(this.txttotal);
            this.Controls.Add(this.btneliminar);
            this.Controls.Add(this.btnagregar);
            this.Controls.Add(this.lblnombre);
            this.Controls.Add(this.lblcodigo);
            this.Controls.Add(this.txtcodigo);
            this.Controls.Add(this.lblfecha);
            this.Controls.Add(this.dgvfacturacion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Facturar";
            this.Text = "Facturar";
            this.Load += new System.EventHandler(this.Facturar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvfacturacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvfacturacion;
        private System.Windows.Forms.Label lblfecha;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.Label lblcodigo;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnatras;
        private System.Windows.Forms.Label lbldni;
        private System.Windows.Forms.TextBox txtdni;
        private System.Windows.Forms.CheckBox cbconsumidorfinal;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cmbnombre;
    }
}