namespace FerreteriaElCosito
{
    partial class frmfacturaproveedor
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
            this.btnlimpiar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtnrocomprobante = new System.Windows.Forms.TextBox();
            this.cbtcomprobante = new System.Windows.Forms.ComboBox();
            this.lbltcomprobante = new System.Windows.Forms.Label();
            this.lblnrocomprobante = new System.Windows.Forms.Label();
            this.dtpfecha = new System.Windows.Forms.DateTimePicker();
            this.cbidproveedor = new System.Windows.Forms.ComboBox();
            this.lblidproveedor = new System.Windows.Forms.Label();
            this.cbproveedor = new System.Windows.Forms.ComboBox();
            this.btnatras = new System.Windows.Forms.Button();
            this.btnquitar = new System.Windows.Forms.Button();
            this.btnregistrarfc = new System.Windows.Forms.Button();
            this.lblfecha = new System.Windows.Forms.Label();
            this.lblproveedor = new System.Windows.Forms.Label();
            this.btnagregar = new System.Windows.Forms.Button();
            this.lblsubtotal = new System.Windows.Forms.Label();
            this.lbliva = new System.Windows.Forms.Label();
            this.lbliibb = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            this.txtsubtotal = new System.Windows.Forms.TextBox();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.txtiibb = new System.Windows.Forms.TextBox();
            this.txtiva = new System.Windows.Forms.TextBox();
            this.cbnotadepedido = new System.Windows.Forms.ComboBox();
            this.lblnotadepedido = new System.Windows.Forms.Label();
            this.lblformadepago = new System.Windows.Forms.Label();
            this.cbformadepago = new System.Windows.Forms.ComboBox();
            this.cbtipoegreso = new System.Windows.Forms.ComboBox();
            this.lbltipodeegreso = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtivaporcentaje = new System.Windows.Forms.TextBox();
            this.txtiibbporcentaje = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.Location = new System.Drawing.Point(721, 531);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(86, 33);
            this.btnlimpiar.TabIndex = 58;
            this.btnlimpiar.Text = "Limpiar";
            this.btnlimpiar.UseVisualStyleBackColor = true;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(56, 112);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(863, 274);
            this.dataGridView1.TabIndex = 55;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtnrocomprobante
            // 
            this.txtnrocomprobante.Location = new System.Drawing.Point(340, 32);
            this.txtnrocomprobante.Name = "txtnrocomprobante";
            this.txtnrocomprobante.Size = new System.Drawing.Size(124, 22);
            this.txtnrocomprobante.TabIndex = 48;
            this.txtnrocomprobante.TextChanged += new System.EventHandler(this.txtnrocomprobante_TextChanged);
            // 
            // cbtcomprobante
            // 
            this.cbtcomprobante.FormattingEnabled = true;
            this.cbtcomprobante.Location = new System.Drawing.Point(119, 32);
            this.cbtcomprobante.Name = "cbtcomprobante";
            this.cbtcomprobante.Size = new System.Drawing.Size(84, 24);
            this.cbtcomprobante.TabIndex = 47;
            this.cbtcomprobante.SelectedIndexChanged += new System.EventHandler(this.cbtcomprobante_SelectedIndexChanged);
            // 
            // lbltcomprobante
            // 
            this.lbltcomprobante.AutoSize = true;
            this.lbltcomprobante.Location = new System.Drawing.Point(53, 40);
            this.lbltcomprobante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltcomprobante.Name = "lbltcomprobante";
            this.lbltcomprobante.Size = new System.Drawing.Size(69, 16);
            this.lbltcomprobante.TabIndex = 46;
            this.lbltcomprobante.Text = "Comprob :";
            // 
            // lblnrocomprobante
            // 
            this.lblnrocomprobante.AutoSize = true;
            this.lblnrocomprobante.Location = new System.Drawing.Point(210, 40);
            this.lblnrocomprobante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnrocomprobante.Name = "lblnrocomprobante";
            this.lblnrocomprobante.Size = new System.Drawing.Size(114, 16);
            this.lblnrocomprobante.TabIndex = 45;
            this.lblnrocomprobante.Text = "Nro Comprobante";
            // 
            // dtpfecha
            // 
            this.dtpfecha.Location = new System.Drawing.Point(719, 30);
            this.dtpfecha.Name = "dtpfecha";
            this.dtpfecha.Size = new System.Drawing.Size(200, 22);
            this.dtpfecha.TabIndex = 44;
            this.dtpfecha.ValueChanged += new System.EventHandler(this.dtpfecha_ValueChanged);
            // 
            // cbidproveedor
            // 
            this.cbidproveedor.FormattingEnabled = true;
            this.cbidproveedor.Location = new System.Drawing.Point(132, 75);
            this.cbidproveedor.Name = "cbidproveedor";
            this.cbidproveedor.Size = new System.Drawing.Size(97, 24);
            this.cbidproveedor.TabIndex = 43;
            this.cbidproveedor.SelectedIndexChanged += new System.EventHandler(this.cbidproveedor_SelectedIndexChanged);
            // 
            // lblidproveedor
            // 
            this.lblidproveedor.AutoSize = true;
            this.lblidproveedor.Location = new System.Drawing.Point(47, 78);
            this.lblidproveedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblidproveedor.Name = "lblidproveedor";
            this.lblidproveedor.Size = new System.Drawing.Size(93, 16);
            this.lblidproveedor.TabIndex = 42;
            this.lblidproveedor.Text = "ID Proveedor :";
            // 
            // cbproveedor
            // 
            this.cbproveedor.FormattingEnabled = true;
            this.cbproveedor.Location = new System.Drawing.Point(321, 74);
            this.cbproveedor.Name = "cbproveedor";
            this.cbproveedor.Size = new System.Drawing.Size(267, 24);
            this.cbproveedor.TabIndex = 41;
            this.cbproveedor.SelectedIndexChanged += new System.EventHandler(this.cbproveedor_SelectedIndexChanged);
            // 
            // btnatras
            // 
            this.btnatras.Location = new System.Drawing.Point(841, 531);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(78, 33);
            this.btnatras.TabIndex = 40;
            this.btnatras.Text = "Atras";
            this.btnatras.UseVisualStyleBackColor = true;
            this.btnatras.Click += new System.EventHandler(this.btnatras_Click);
            // 
            // btnquitar
            // 
            this.btnquitar.Location = new System.Drawing.Point(810, 78);
            this.btnquitar.Name = "btnquitar";
            this.btnquitar.Size = new System.Drawing.Size(100, 28);
            this.btnquitar.TabIndex = 39;
            this.btnquitar.Text = "Quitar";
            this.btnquitar.UseVisualStyleBackColor = true;
            this.btnquitar.Click += new System.EventHandler(this.btnquitar_Click);
            // 
            // btnregistrarfc
            // 
            this.btnregistrarfc.Location = new System.Drawing.Point(430, 485);
            this.btnregistrarfc.Name = "btnregistrarfc";
            this.btnregistrarfc.Size = new System.Drawing.Size(187, 28);
            this.btnregistrarfc.TabIndex = 38;
            this.btnregistrarfc.Text = "REGISTRAR FACTURA";
            this.btnregistrarfc.UseVisualStyleBackColor = true;
            this.btnregistrarfc.Click += new System.EventHandler(this.btnregistrarfc_Click);
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.Location = new System.Drawing.Point(661, 35);
            this.lblfecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(51, 16);
            this.lblfecha.TabIndex = 37;
            this.lblfecha.Text = "Fecha: ";
            // 
            // lblproveedor
            // 
            this.lblproveedor.AutoSize = true;
            this.lblproveedor.Location = new System.Drawing.Point(236, 77);
            this.lblproveedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblproveedor.Name = "lblproveedor";
            this.lblproveedor.Size = new System.Drawing.Size(77, 16);
            this.lblproveedor.TabIndex = 36;
            this.lblproveedor.Text = "Proveedor :";
            // 
            // btnagregar
            // 
            this.btnagregar.Location = new System.Drawing.Point(690, 78);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(100, 28);
            this.btnagregar.TabIndex = 35;
            this.btnagregar.Text = "Agregar";
            this.btnagregar.UseVisualStyleBackColor = true;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // lblsubtotal
            // 
            this.lblsubtotal.AutoSize = true;
            this.lblsubtotal.Location = new System.Drawing.Point(62, 463);
            this.lblsubtotal.Name = "lblsubtotal";
            this.lblsubtotal.Size = new System.Drawing.Size(56, 16);
            this.lblsubtotal.TabIndex = 60;
            this.lblsubtotal.Text = "Subtotal";
            // 
            // lbliva
            // 
            this.lbliva.AutoSize = true;
            this.lbliva.Location = new System.Drawing.Point(266, 426);
            this.lbliva.Name = "lbliva";
            this.lbliva.Size = new System.Drawing.Size(43, 16);
            this.lbliva.TabIndex = 61;
            this.lbliva.Text = "IVA %";
            // 
            // lbliibb
            // 
            this.lbliibb.AutoSize = true;
            this.lbliibb.Location = new System.Drawing.Point(488, 429);
            this.lbliibb.Name = "lbliibb";
            this.lbliibb.Size = new System.Drawing.Size(46, 16);
            this.lbliibb.TabIndex = 62;
            this.lbliibb.Text = "IIBB %";
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Location = new System.Drawing.Point(756, 423);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(51, 16);
            this.lbltotal.TabIndex = 63;
            this.lbltotal.Text = "TOTAL";
            // 
            // txtsubtotal
            // 
            this.txtsubtotal.Location = new System.Drawing.Point(160, 423);
            this.txtsubtotal.Name = "txtsubtotal";
            this.txtsubtotal.Size = new System.Drawing.Size(100, 22);
            this.txtsubtotal.TabIndex = 64;
            this.txtsubtotal.TextChanged += new System.EventHandler(this.txtsubtotal_TextChanged);
            // 
            // txttotal
            // 
            this.txttotal.Location = new System.Drawing.Point(813, 420);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(100, 22);
            this.txttotal.TabIndex = 65;
            this.txttotal.TextChanged += new System.EventHandler(this.txttotal_TextChanged);
            // 
            // txtiibb
            // 
            this.txtiibb.Location = new System.Drawing.Point(571, 423);
            this.txtiibb.Name = "txtiibb";
            this.txtiibb.Size = new System.Drawing.Size(100, 22);
            this.txtiibb.TabIndex = 66;
            this.txtiibb.TextChanged += new System.EventHandler(this.txtiibb_TextChanged);
            // 
            // txtiva
            // 
            this.txtiva.Location = new System.Drawing.Point(364, 423);
            this.txtiva.Name = "txtiva";
            this.txtiva.Size = new System.Drawing.Size(100, 22);
            this.txtiva.TabIndex = 67;
            this.txtiva.TextChanged += new System.EventHandler(this.txtiva_TextChanged);
            // 
            // cbnotadepedido
            // 
            this.cbnotadepedido.FormattingEnabled = true;
            this.cbnotadepedido.Location = new System.Drawing.Point(548, 32);
            this.cbnotadepedido.Name = "cbnotadepedido";
            this.cbnotadepedido.Size = new System.Drawing.Size(82, 24);
            this.cbnotadepedido.TabIndex = 68;
            this.cbnotadepedido.SelectedIndexChanged += new System.EventHandler(this.cbnotadepedido_SelectedIndexChanged);
            // 
            // lblnotadepedido
            // 
            this.lblnotadepedido.AutoSize = true;
            this.lblnotadepedido.Location = new System.Drawing.Point(488, 38);
            this.lblnotadepedido.Name = "lblnotadepedido";
            this.lblnotadepedido.Size = new System.Drawing.Size(54, 16);
            this.lblnotadepedido.TabIndex = 69;
            this.lblnotadepedido.Text = "NP Nro:";
            // 
            // lblformadepago
            // 
            this.lblformadepago.AutoSize = true;
            this.lblformadepago.Location = new System.Drawing.Point(54, 464);
            this.lblformadepago.Name = "lblformadepago";
            this.lblformadepago.Size = new System.Drawing.Size(100, 16);
            this.lblformadepago.TabIndex = 70;
            this.lblformadepago.Text = "Forma de pago";
            // 
            // cbformadepago
            // 
            this.cbformadepago.FormattingEnabled = true;
            this.cbformadepago.Location = new System.Drawing.Point(160, 464);
            this.cbformadepago.Name = "cbformadepago";
            this.cbformadepago.Size = new System.Drawing.Size(211, 24);
            this.cbformadepago.TabIndex = 71;
            // 
            // cbtipoegreso
            // 
            this.cbtipoegreso.FormattingEnabled = true;
            this.cbtipoegreso.Location = new System.Drawing.Point(160, 506);
            this.cbtipoegreso.Name = "cbtipoegreso";
            this.cbtipoegreso.Size = new System.Drawing.Size(211, 24);
            this.cbtipoegreso.TabIndex = 73;
            // 
            // lbltipodeegreso
            // 
            this.lbltipodeegreso.AutoSize = true;
            this.lbltipodeegreso.Location = new System.Drawing.Point(54, 506);
            this.lbltipodeegreso.Name = "lbltipodeegreso";
            this.lbltipodeegreso.Size = new System.Drawing.Size(103, 16);
            this.lbltipodeegreso.TabIndex = 72;
            this.lbltipodeegreso.Text = "Tipo  de egreso";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 426);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 74;
            this.label1.Text = "SUBTOTAL";
            // 
            // txtivaporcentaje
            // 
            this.txtivaporcentaje.Location = new System.Drawing.Point(315, 423);
            this.txtivaporcentaje.Name = "txtivaporcentaje";
            this.txtivaporcentaje.Size = new System.Drawing.Size(40, 22);
            this.txtivaporcentaje.TabIndex = 75;
            // 
            // txtiibbporcentaje
            // 
            this.txtiibbporcentaje.Location = new System.Drawing.Point(535, 423);
            this.txtiibbporcentaje.Name = "txtiibbporcentaje";
            this.txtiibbporcentaje.Size = new System.Drawing.Size(30, 22);
            this.txtiibbporcentaje.TabIndex = 76;
            // 
            // frmfacturaproveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 594);
            this.Controls.Add(this.txtiibbporcentaje);
            this.Controls.Add(this.txtivaporcentaje);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbtipoegreso);
            this.Controls.Add(this.lbltipodeegreso);
            this.Controls.Add(this.cbformadepago);
            this.Controls.Add(this.lblformadepago);
            this.Controls.Add(this.lblnotadepedido);
            this.Controls.Add(this.cbnotadepedido);
            this.Controls.Add(this.txtiva);
            this.Controls.Add(this.txtiibb);
            this.Controls.Add(this.txttotal);
            this.Controls.Add(this.txtsubtotal);
            this.Controls.Add(this.lbltotal);
            this.Controls.Add(this.lbliibb);
            this.Controls.Add(this.lbliva);
            this.Controls.Add(this.lblsubtotal);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtnrocomprobante);
            this.Controls.Add(this.cbtcomprobante);
            this.Controls.Add(this.lbltcomprobante);
            this.Controls.Add(this.lblnrocomprobante);
            this.Controls.Add(this.dtpfecha);
            this.Controls.Add(this.cbidproveedor);
            this.Controls.Add(this.lblidproveedor);
            this.Controls.Add(this.cbproveedor);
            this.Controls.Add(this.btnatras);
            this.Controls.Add(this.btnquitar);
            this.Controls.Add(this.btnregistrarfc);
            this.Controls.Add(this.lblfecha);
            this.Controls.Add(this.lblproveedor);
            this.Controls.Add(this.btnagregar);
            this.Name = "frmfacturaproveedor";
            this.Text = "Factura_Proveedor";
            this.Load += new System.EventHandler(this.frmfacturaproveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnlimpiar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtnrocomprobante;
        private System.Windows.Forms.ComboBox cbtcomprobante;
        private System.Windows.Forms.Label lbltcomprobante;
        private System.Windows.Forms.Label lblnrocomprobante;
        private System.Windows.Forms.DateTimePicker dtpfecha;
        private System.Windows.Forms.ComboBox cbidproveedor;
        private System.Windows.Forms.Label lblidproveedor;
        private System.Windows.Forms.ComboBox cbproveedor;
        private System.Windows.Forms.Button btnatras;
        private System.Windows.Forms.Button btnquitar;
        private System.Windows.Forms.Button btnregistrarfc;
        private System.Windows.Forms.Label lblfecha;
        private System.Windows.Forms.Label lblproveedor;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.Label lblsubtotal;
        private System.Windows.Forms.Label lbliva;
        private System.Windows.Forms.Label lbliibb;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.TextBox txtsubtotal;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.TextBox txtiibb;
        private System.Windows.Forms.TextBox txtiva;
        private System.Windows.Forms.ComboBox cbnotadepedido;
        private System.Windows.Forms.Label lblnotadepedido;
        private System.Windows.Forms.Label lblformadepago;
        private System.Windows.Forms.ComboBox cbformadepago;
        private System.Windows.Forms.ComboBox cbtipoegreso;
        private System.Windows.Forms.Label lbltipodeegreso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtivaporcentaje;
        private System.Windows.Forms.TextBox txtiibbporcentaje;
    }
}