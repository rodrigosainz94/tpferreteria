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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.Location = new System.Drawing.Point(699, 531);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(100, 28);
            this.btnlimpiar.TabIndex = 58;
            this.btnlimpiar.Text = "Limpiar";
            this.btnlimpiar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(56, 146);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(863, 320);
            this.dataGridView1.TabIndex = 55;
            // 
            // txtnrocomprobante
            // 
            this.txtnrocomprobante.Location = new System.Drawing.Point(340, 32);
            this.txtnrocomprobante.Name = "txtnrocomprobante";
            this.txtnrocomprobante.Size = new System.Drawing.Size(124, 22);
            this.txtnrocomprobante.TabIndex = 48;
            // 
            // cbtcomprobante
            // 
            this.cbtcomprobante.FormattingEnabled = true;
            this.cbtcomprobante.Location = new System.Drawing.Point(119, 32);
            this.cbtcomprobante.Name = "cbtcomprobante";
            this.cbtcomprobante.Size = new System.Drawing.Size(84, 24);
            this.cbtcomprobante.TabIndex = 47;
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
            // 
            // cbidproveedor
            // 
            this.cbidproveedor.FormattingEnabled = true;
            this.cbidproveedor.Location = new System.Drawing.Point(138, 97);
            this.cbidproveedor.Name = "cbidproveedor";
            this.cbidproveedor.Size = new System.Drawing.Size(97, 24);
            this.cbidproveedor.TabIndex = 43;
            // 
            // lblidproveedor
            // 
            this.lblidproveedor.AutoSize = true;
            this.lblidproveedor.Location = new System.Drawing.Point(53, 100);
            this.lblidproveedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblidproveedor.Name = "lblidproveedor";
            this.lblidproveedor.Size = new System.Drawing.Size(93, 16);
            this.lblidproveedor.TabIndex = 42;
            this.lblidproveedor.Text = "ID Proveedor :";
            // 
            // cbproveedor
            // 
            this.cbproveedor.FormattingEnabled = true;
            this.cbproveedor.Location = new System.Drawing.Point(327, 96);
            this.cbproveedor.Name = "cbproveedor";
            this.cbproveedor.Size = new System.Drawing.Size(267, 24);
            this.cbproveedor.TabIndex = 41;
            // 
            // btnatras
            // 
            this.btnatras.Location = new System.Drawing.Point(819, 531);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(100, 28);
            this.btnatras.TabIndex = 40;
            this.btnatras.Text = "Atras";
            this.btnatras.UseVisualStyleBackColor = true;
            // 
            // btnquitar
            // 
            this.btnquitar.Location = new System.Drawing.Point(819, 97);
            this.btnquitar.Name = "btnquitar";
            this.btnquitar.Size = new System.Drawing.Size(100, 28);
            this.btnquitar.TabIndex = 39;
            this.btnquitar.Text = "Quitar";
            this.btnquitar.UseVisualStyleBackColor = true;
            // 
            // btnregistrarfc
            // 
            this.btnregistrarfc.Location = new System.Drawing.Point(56, 531);
            this.btnregistrarfc.Name = "btnregistrarfc";
            this.btnregistrarfc.Size = new System.Drawing.Size(187, 28);
            this.btnregistrarfc.TabIndex = 38;
            this.btnregistrarfc.Text = "REGISTRAR FACTURA";
            this.btnregistrarfc.UseVisualStyleBackColor = true;
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
            this.lblproveedor.Location = new System.Drawing.Point(242, 99);
            this.lblproveedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblproveedor.Name = "lblproveedor";
            this.lblproveedor.Size = new System.Drawing.Size(77, 16);
            this.lblproveedor.TabIndex = 36;
            this.lblproveedor.Text = "Proveedor :";
            // 
            // btnagregar
            // 
            this.btnagregar.Location = new System.Drawing.Point(699, 97);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(100, 28);
            this.btnagregar.TabIndex = 35;
            this.btnagregar.Text = "Agregar";
            this.btnagregar.UseVisualStyleBackColor = true;
            // 
            // lblsubtotal
            // 
            this.lblsubtotal.AutoSize = true;
            this.lblsubtotal.Location = new System.Drawing.Point(66, 491);
            this.lblsubtotal.Name = "lblsubtotal";
            this.lblsubtotal.Size = new System.Drawing.Size(56, 16);
            this.lblsubtotal.TabIndex = 60;
            this.lblsubtotal.Text = "Subtotal";
            // 
            // lbliva
            // 
            this.lbliva.AutoSize = true;
            this.lbliva.Location = new System.Drawing.Point(282, 483);
            this.lbliva.Name = "lbliva";
            this.lbliva.Size = new System.Drawing.Size(28, 16);
            this.lbliva.TabIndex = 61;
            this.lbliva.Text = "IVA";
            // 
            // lbliibb
            // 
            this.lbliibb.AutoSize = true;
            this.lbliibb.Location = new System.Drawing.Point(488, 484);
            this.lbliibb.Name = "lbliibb";
            this.lbliibb.Size = new System.Drawing.Size(31, 16);
            this.lbliibb.TabIndex = 62;
            this.lbliibb.Text = "IIBB";
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Location = new System.Drawing.Point(750, 490);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(51, 16);
            this.lbltotal.TabIndex = 63;
            this.lbltotal.Text = "TOTAL";
            // 
            // txtsubtotal
            // 
            this.txtsubtotal.Location = new System.Drawing.Point(139, 484);
            this.txtsubtotal.Name = "txtsubtotal";
            this.txtsubtotal.Size = new System.Drawing.Size(100, 22);
            this.txtsubtotal.TabIndex = 64;
            // 
            // txttotal
            // 
            this.txttotal.Location = new System.Drawing.Point(821, 484);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(100, 22);
            this.txttotal.TabIndex = 65;
            // 
            // txtiibb
            // 
            this.txtiibb.Location = new System.Drawing.Point(525, 481);
            this.txtiibb.Name = "txtiibb";
            this.txtiibb.Size = new System.Drawing.Size(100, 22);
            this.txtiibb.TabIndex = 66;
            // 
            // txtiva
            // 
            this.txtiva.Location = new System.Drawing.Point(352, 484);
            this.txtiva.Name = "txtiva";
            this.txtiva.Size = new System.Drawing.Size(100, 22);
            this.txtiva.TabIndex = 67;
            // 
            // cbnotadepedido
            // 
            this.cbnotadepedido.FormattingEnabled = true;
            this.cbnotadepedido.Location = new System.Drawing.Point(548, 32);
            this.cbnotadepedido.Name = "cbnotadepedido";
            this.cbnotadepedido.Size = new System.Drawing.Size(82, 24);
            this.cbnotadepedido.TabIndex = 68;
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
            // frmfacturaproveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 571);
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
    }
}