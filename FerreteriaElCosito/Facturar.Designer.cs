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
            this.lblcuilcuit = new System.Windows.Forms.Label();
            this.cbconsumidorfinal = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cmbnombre = new System.Windows.Forms.ComboBox();
            this.btnfacturar = new System.Windows.Forms.Button();
            this.lblcliente = new System.Windows.Forms.Label();
            this.btncliente = new System.Windows.Forms.Button();
            this.lblnombrecliente = new System.Windows.Forms.Label();
            this.txtdni = new System.Windows.Forms.MaskedTextBox();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblNuevoPrecio = new System.Windows.Forms.Label();
            this.txtNuevoPrecio = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfacturacion)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvfacturacion
            // 
            this.dgvfacturacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvfacturacion.Location = new System.Drawing.Point(295, 46);
            this.dgvfacturacion.Name = "dgvfacturacion";
            this.dgvfacturacion.RowHeadersWidth = 51;
            this.dgvfacturacion.Size = new System.Drawing.Size(876, 366);
            this.dgvfacturacion.TabIndex = 0;
            this.dgvfacturacion.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvfacturacion_CellEndEdit);
            this.dgvfacturacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvfacturacion_KeyDown);
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.Location = new System.Drawing.Point(1063, 24);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(108, 13);
            this.lblfecha.TabIndex = 1;
            this.lblfecha.Text = "hora y fecha : 1 2 3 4";
            this.lblfecha.Click += new System.EventHandler(this.lblfecha_Click);
            // 
            // txtcodigo
            // 
            this.txtcodigo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtcodigo.Location = new System.Drawing.Point(126, 100);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(139, 20);
            this.txtcodigo.TabIndex = 2;
            this.txtcodigo.TextChanged += new System.EventHandler(this.txtcodigo_TextChanged);
            this.txtcodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcodigo_KeyDown);
            // 
            // lblcodigo
            // 
            this.lblcodigo.AutoSize = true;
            this.lblcodigo.Location = new System.Drawing.Point(67, 102);
            this.lblcodigo.Name = "lblcodigo";
            this.lblcodigo.Size = new System.Drawing.Size(55, 13);
            this.lblcodigo.TabIndex = 3;
            this.lblcodigo.Text = "CÓDIGO :";
            this.lblcodigo.Click += new System.EventHandler(this.lblcodigo_Click);
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.Location = new System.Drawing.Point(67, 128);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(60, 13);
            this.lblnombre.TabIndex = 5;
            this.lblnombre.Text = "NOMBRE :";
            // 
            // btnagregar
            // 
            this.btnagregar.BackColor = System.Drawing.Color.GreenYellow;
            this.btnagregar.Location = new System.Drawing.Point(70, 164);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(75, 41);
            this.btnagregar.TabIndex = 6;
            this.btnagregar.Text = "AGREGAR";
            this.btnagregar.UseVisualStyleBackColor = false;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // btneliminar
            // 
            this.btneliminar.BackColor = System.Drawing.Color.Salmon;
            this.btneliminar.Location = new System.Drawing.Point(191, 164);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(75, 41);
            this.btneliminar.TabIndex = 7;
            this.btneliminar.Text = "ELIMINAR";
            this.btneliminar.UseVisualStyleBackColor = false;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // txttotal
            // 
            this.txttotal.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txttotal.Location = new System.Drawing.Point(1071, 425);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(100, 20);
            this.txttotal.TabIndex = 8;
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Location = new System.Drawing.Point(1017, 428);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(48, 13);
            this.lbltotal.TabIndex = 9;
            this.lbltotal.Text = "TOTAL :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(101, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "FERRETERIA";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(101, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 22);
            this.label2.TabIndex = 11;
            this.label2.Text = "\" EL COSITO \"";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnatras
            // 
            this.btnatras.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnatras.Location = new System.Drawing.Point(69, 404);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(75, 41);
            this.btnatras.TabIndex = 12;
            this.btnatras.Text = "ATRAS";
            this.btnatras.UseVisualStyleBackColor = false;
            this.btnatras.Click += new System.EventHandler(this.btnatras_Click);
            // 
            // lblcuilcuit
            // 
            this.lblcuilcuit.AutoSize = true;
            this.lblcuilcuit.Location = new System.Drawing.Point(67, 247);
            this.lblcuilcuit.Name = "lblcuilcuit";
            this.lblcuilcuit.Size = new System.Drawing.Size(70, 13);
            this.lblcuilcuit.TabIndex = 13;
            this.lblcuilcuit.Text = "CUIL / CUIT:";
            // 
            // cbconsumidorfinal
            // 
            this.cbconsumidorfinal.AutoSize = true;
            this.cbconsumidorfinal.Location = new System.Drawing.Point(70, 275);
            this.cbconsumidorfinal.Name = "cbconsumidorfinal";
            this.cbconsumidorfinal.Size = new System.Drawing.Size(133, 17);
            this.cbconsumidorfinal.TabIndex = 15;
            this.cbconsumidorfinal.Text = "CONSUMIDOR FINAL";
            this.cbconsumidorfinal.UseVisualStyleBackColor = true;
            this.cbconsumidorfinal.CheckedChanged += new System.EventHandler(this.cbconsumidorfinal_CheckedChanged);
            // 
            // cmbnombre
            // 
            this.cmbnombre.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbnombre.FormattingEnabled = true;
            this.cmbnombre.Location = new System.Drawing.Point(126, 126);
            this.cmbnombre.Margin = new System.Windows.Forms.Padding(2);
            this.cmbnombre.Name = "cmbnombre";
            this.cmbnombre.Size = new System.Drawing.Size(138, 21);
            this.cmbnombre.TabIndex = 16;
            this.cmbnombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbnombre_KeyDown);
            // 
            // btnfacturar
            // 
            this.btnfacturar.Location = new System.Drawing.Point(148, 404);
            this.btnfacturar.Name = "btnfacturar";
            this.btnfacturar.Size = new System.Drawing.Size(118, 41);
            this.btnfacturar.TabIndex = 17;
            this.btnfacturar.Text = "FACTURAR";
            this.btnfacturar.UseVisualStyleBackColor = true;
            this.btnfacturar.Click += new System.EventHandler(this.btnfacturar_Click);
            // 
            // lblcliente
            // 
            this.lblcliente.AutoSize = true;
            this.lblcliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcliente.Location = new System.Drawing.Point(68, 221);
            this.lblcliente.Name = "lblcliente";
            this.lblcliente.Size = new System.Drawing.Size(55, 17);
            this.lblcliente.TabIndex = 18;
            this.lblcliente.Text = "Cliente:";
            // 
            // btncliente
            // 
            this.btncliente.Location = new System.Drawing.Point(69, 297);
            this.btncliente.Name = "btncliente";
            this.btncliente.Size = new System.Drawing.Size(196, 46);
            this.btncliente.TabIndex = 19;
            this.btncliente.Text = "Nuevo cliente";
            this.btncliente.UseVisualStyleBackColor = true;
            this.btncliente.Click += new System.EventHandler(this.btncliente_Click);
            // 
            // lblnombrecliente
            // 
            this.lblnombrecliente.AutoSize = true;
            this.lblnombrecliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombrecliente.Location = new System.Drawing.Point(160, 221);
            this.lblnombrecliente.Name = "lblnombrecliente";
            this.lblnombrecliente.Size = new System.Drawing.Size(103, 17);
            this.lblnombrecliente.TabIndex = 20;
            this.lblnombrecliente.Text = "Nombre cliente";
            // 
            // txtdni
            // 
            this.txtdni.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtdni.Location = new System.Drawing.Point(145, 244);
            this.txtdni.Margin = new System.Windows.Forms.Padding(2);
            this.txtdni.Mask = "00-00000000-0";
            this.txtdni.Name = "txtdni";
            this.txtdni.PromptChar = ' ';
            this.txtdni.Size = new System.Drawing.Size(132, 20);
            this.txtdni.TabIndex = 21;
            this.txtdni.Click += new System.EventHandler(this.txtdni_Click);
            this.txtdni.TextChanged += new System.EventHandler(this.txtdni_TextChanged);
            // 
            // txtDescuento
            // 
            this.txtDescuento.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDescuento.Location = new System.Drawing.Point(144, 348);
            this.txtDescuento.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(120, 20);
            this.txtDescuento.TabIndex = 22;
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            this.txtDescuento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescuento_KeyDown);
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.Location = new System.Drawing.Point(68, 348);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(80, 17);
            this.lblDescuento.TabIndex = 23;
            this.lblDescuento.Text = "Descuento:";
            // 
            // lblNuevoPrecio
            // 
            this.lblNuevoPrecio.AutoSize = true;
            this.lblNuevoPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevoPrecio.Location = new System.Drawing.Point(68, 375);
            this.lblNuevoPrecio.Name = "lblNuevoPrecio";
            this.lblNuevoPrecio.Size = new System.Drawing.Size(82, 15);
            this.lblNuevoPrecio.TabIndex = 24;
            this.lblNuevoPrecio.Text = "Nuevo precio:";
            // 
            // txtNuevoPrecio
            // 
            this.txtNuevoPrecio.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNuevoPrecio.Location = new System.Drawing.Point(145, 375);
            this.txtNuevoPrecio.Margin = new System.Windows.Forms.Padding(2);
            this.txtNuevoPrecio.Name = "txtNuevoPrecio";
            this.txtNuevoPrecio.Size = new System.Drawing.Size(120, 20);
            this.txtNuevoPrecio.TabIndex = 25;
            this.txtNuevoPrecio.TextChanged += new System.EventHandler(this.txtNuevoPrecio_TextChanged);
            this.txtNuevoPrecio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNuevoPrecio_KeyDown);
            // 
            // Facturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1213, 559);
            this.Controls.Add(this.txtNuevoPrecio);
            this.Controls.Add(this.lblNuevoPrecio);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.txtdni);
            this.Controls.Add(this.lblnombrecliente);
            this.Controls.Add(this.btncliente);
            this.Controls.Add(this.lblcliente);
            this.Controls.Add(this.btnfacturar);
            this.Controls.Add(this.cmbnombre);
            this.Controls.Add(this.cbconsumidorfinal);
            this.Controls.Add(this.lblcuilcuit);
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
        private System.Windows.Forms.Label lblcuilcuit;
        private System.Windows.Forms.CheckBox cbconsumidorfinal;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cmbnombre;
        private System.Windows.Forms.Button btnfacturar;
        private System.Windows.Forms.Label lblcliente;
        private System.Windows.Forms.Button btncliente;
        private System.Windows.Forms.Label lblnombrecliente;
        private System.Windows.Forms.MaskedTextBox txtdni;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblNuevoPrecio;
        private System.Windows.Forms.TextBox txtNuevoPrecio;
    }
}