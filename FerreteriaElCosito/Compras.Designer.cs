namespace FerreteriaElCosito
{
    partial class Compras
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
            this.btnagregar = new System.Windows.Forms.Button();
            this.lblproveedor = new System.Windows.Forms.Label();
            this.lblfecha = new System.Windows.Forms.Label();
            this.btnhacerpedido = new System.Windows.Forms.Button();
            this.btnquitar = new System.Windows.Forms.Button();
            this.btnatras = new System.Windows.Forms.Button();
            this.cbproveedor = new System.Windows.Forms.ComboBox();
            this.cbidproveedor = new System.Windows.Forms.ComboBox();
            this.lblidproveedor = new System.Windows.Forms.Label();
            this.dtpfecha = new System.Windows.Forms.DateTimePicker();
            this.cbtcomprobante = new System.Windows.Forms.ComboBox();
            this.lbltcomprobante = new System.Windows.Forms.Label();
            this.lblnrocomprobante = new System.Windows.Forms.Label();
            this.txtnrocomprobante = new System.Windows.Forms.TextBox();
            this.cbempleado = new System.Windows.Forms.ComboBox();
            this.lblempleado = new System.Windows.Forms.Label();
            this.cbproducto = new System.Windows.Forms.ComboBox();
            this.lblproducto = new System.Windows.Forms.Label();
            this.cbidproducto = new System.Windows.Forms.ComboBox();
            this.lblidproducto = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbidempleado = new System.Windows.Forms.ComboBox();
            this.lblidempl = new System.Windows.Forms.Label();
            this.btnlimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnagregar
            // 
            this.btnagregar.Location = new System.Drawing.Point(600, 105);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(100, 28);
            this.btnagregar.TabIndex = 1;
            this.btnagregar.Text = "Agregar";
            this.btnagregar.UseVisualStyleBackColor = true;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // lblproveedor
            // 
            this.lblproveedor.AutoSize = true;
            this.lblproveedor.Location = new System.Drawing.Point(223, 73);
            this.lblproveedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblproveedor.Name = "lblproveedor";
            this.lblproveedor.Size = new System.Drawing.Size(77, 16);
            this.lblproveedor.TabIndex = 6;
            this.lblproveedor.Text = "Proveedor :";
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.Location = new System.Drawing.Point(526, 25);
            this.lblfecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(51, 16);
            this.lblfecha.TabIndex = 7;
            this.lblfecha.Text = "Fecha: ";
            // 
            // btnhacerpedido
            // 
            this.btnhacerpedido.Location = new System.Drawing.Point(619, 148);
            this.btnhacerpedido.Name = "btnhacerpedido";
            this.btnhacerpedido.Size = new System.Drawing.Size(187, 28);
            this.btnhacerpedido.TabIndex = 9;
            this.btnhacerpedido.Text = "EMITIR NOTA DE PEDIDO";
            this.btnhacerpedido.UseVisualStyleBackColor = true;
            this.btnhacerpedido.Click += new System.EventHandler(this.btnhacerpedido_Click);
            // 
            // btnquitar
            // 
            this.btnquitar.Location = new System.Drawing.Point(706, 106);
            this.btnquitar.Name = "btnquitar";
            this.btnquitar.Size = new System.Drawing.Size(100, 28);
            this.btnquitar.TabIndex = 10;
            this.btnquitar.Text = "Quitar";
            this.btnquitar.UseVisualStyleBackColor = true;
            this.btnquitar.Click += new System.EventHandler(this.btnquitar_Click);
            // 
            // btnatras
            // 
            this.btnatras.Location = new System.Drawing.Point(706, 457);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(100, 28);
            this.btnatras.TabIndex = 13;
            this.btnatras.Text = "Atras";
            this.btnatras.UseVisualStyleBackColor = true;
            this.btnatras.Click += new System.EventHandler(this.btnatras_Click);
            // 
            // cbproveedor
            // 
            this.cbproveedor.FormattingEnabled = true;
            this.cbproveedor.Location = new System.Drawing.Point(308, 70);
            this.cbproveedor.Name = "cbproveedor";
            this.cbproveedor.Size = new System.Drawing.Size(200, 24);
            this.cbproveedor.TabIndex = 14;
            // 
            // cbidproveedor
            // 
            this.cbidproveedor.FormattingEnabled = true;
            this.cbidproveedor.Location = new System.Drawing.Point(106, 71);
            this.cbidproveedor.Name = "cbidproveedor";
            this.cbidproveedor.Size = new System.Drawing.Size(97, 24);
            this.cbidproveedor.TabIndex = 16;
            // 
            // lblidproveedor
            // 
            this.lblidproveedor.AutoSize = true;
            this.lblidproveedor.Location = new System.Drawing.Point(21, 74);
            this.lblidproveedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblidproveedor.Name = "lblidproveedor";
            this.lblidproveedor.Size = new System.Drawing.Size(93, 16);
            this.lblidproveedor.TabIndex = 15;
            this.lblidproveedor.Text = "ID Proveedor :";
            // 
            // dtpfecha
            // 
            this.dtpfecha.Location = new System.Drawing.Point(584, 21);
            this.dtpfecha.Name = "dtpfecha";
            this.dtpfecha.Size = new System.Drawing.Size(200, 22);
            this.dtpfecha.TabIndex = 17;
            // 
            // cbtcomprobante
            // 
            this.cbtcomprobante.FormattingEnabled = true;
            this.cbtcomprobante.Location = new System.Drawing.Point(119, 29);
            this.cbtcomprobante.Name = "cbtcomprobante";
            this.cbtcomprobante.Size = new System.Drawing.Size(84, 24);
            this.cbtcomprobante.TabIndex = 20;
            // 
            // lbltcomprobante
            // 
            this.lbltcomprobante.AutoSize = true;
            this.lbltcomprobante.Location = new System.Drawing.Point(21, 33);
            this.lbltcomprobante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltcomprobante.Name = "lbltcomprobante";
            this.lbltcomprobante.Size = new System.Drawing.Size(100, 16);
            this.lbltcomprobante.TabIndex = 19;
            this.lbltcomprobante.Text = "Tipo Comprob :";
            // 
            // lblnrocomprobante
            // 
            this.lblnrocomprobante.AutoSize = true;
            this.lblnrocomprobante.Location = new System.Drawing.Point(223, 29);
            this.lblnrocomprobante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnrocomprobante.Name = "lblnrocomprobante";
            this.lblnrocomprobante.Size = new System.Drawing.Size(114, 16);
            this.lblnrocomprobante.TabIndex = 18;
            this.lblnrocomprobante.Text = "Nro Comprobante";
            // 
            // txtnrocomprobante
            // 
            this.txtnrocomprobante.Location = new System.Drawing.Point(351, 23);
            this.txtnrocomprobante.Name = "txtnrocomprobante";
            this.txtnrocomprobante.Size = new System.Drawing.Size(157, 22);
            this.txtnrocomprobante.TabIndex = 21;
            // 
            // cbempleado
            // 
            this.cbempleado.FormattingEnabled = true;
            this.cbempleado.Location = new System.Drawing.Point(308, 113);
            this.cbempleado.Name = "cbempleado";
            this.cbempleado.Size = new System.Drawing.Size(200, 24);
            this.cbempleado.TabIndex = 23;
            this.cbempleado.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblempleado
            // 
            this.lblempleado.AutoSize = true;
            this.lblempleado.Location = new System.Drawing.Point(225, 113);
            this.lblempleado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblempleado.Name = "lblempleado";
            this.lblempleado.Size = new System.Drawing.Size(76, 16);
            this.lblempleado.TabIndex = 22;
            this.lblempleado.Text = "Empleado :";
            // 
            // cbproducto
            // 
            this.cbproducto.FormattingEnabled = true;
            this.cbproducto.Location = new System.Drawing.Point(308, 151);
            this.cbproducto.Name = "cbproducto";
            this.cbproducto.Size = new System.Drawing.Size(269, 24);
            this.cbproducto.TabIndex = 27;
            // 
            // lblproducto
            // 
            this.lblproducto.AutoSize = true;
            this.lblproducto.Location = new System.Drawing.Point(225, 156);
            this.lblproducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblproducto.Name = "lblproducto";
            this.lblproducto.Size = new System.Drawing.Size(67, 16);
            this.lblproducto.TabIndex = 26;
            this.lblproducto.Text = "Producto :";
            this.lblproducto.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbidproducto
            // 
            this.cbidproducto.FormattingEnabled = true;
            this.cbidproducto.Location = new System.Drawing.Point(106, 152);
            this.cbidproducto.Name = "cbidproducto";
            this.cbidproducto.Size = new System.Drawing.Size(97, 24);
            this.cbidproducto.TabIndex = 25;
            // 
            // lblidproducto
            // 
            this.lblidproducto.AutoSize = true;
            this.lblidproducto.Location = new System.Drawing.Point(21, 155);
            this.lblidproducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblidproducto.Name = "lblidproducto";
            this.lblidproducto.Size = new System.Drawing.Size(83, 16);
            this.lblidproducto.TabIndex = 24;
            this.lblidproducto.Text = "ID Producto :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 193);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(821, 246);
            this.dataGridView1.TabIndex = 28;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cbidempleado
            // 
            this.cbidempleado.FormattingEnabled = true;
            this.cbidempleado.Location = new System.Drawing.Point(106, 110);
            this.cbidempleado.Name = "cbidempleado";
            this.cbidempleado.Size = new System.Drawing.Size(97, 24);
            this.cbidempleado.TabIndex = 30;
            // 
            // lblidempl
            // 
            this.lblidempl.AutoSize = true;
            this.lblidempl.Location = new System.Drawing.Point(23, 117);
            this.lblidempl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblidempl.Name = "lblidempl";
            this.lblidempl.Size = new System.Drawing.Size(90, 16);
            this.lblidempl.TabIndex = 29;
            this.lblidempl.Text = "Id Empleado :";
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.Location = new System.Drawing.Point(584, 457);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(100, 28);
            this.btnlimpiar.TabIndex = 31;
            this.btnlimpiar.Text = "Limpiar";
            this.btnlimpiar.UseVisualStyleBackColor = true;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(857, 497);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.cbidempleado);
            this.Controls.Add(this.lblidempl);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbproducto);
            this.Controls.Add(this.lblproducto);
            this.Controls.Add(this.cbidproducto);
            this.Controls.Add(this.lblidproducto);
            this.Controls.Add(this.cbempleado);
            this.Controls.Add(this.lblempleado);
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
            this.Controls.Add(this.btnhacerpedido);
            this.Controls.Add(this.lblfecha);
            this.Controls.Add(this.lblproveedor);
            this.Controls.Add(this.btnagregar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Compras";
            this.Text = "Compras";
            this.Load += new System.EventHandler(this.Compras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.Button btnhacerpedido;
        private System.Windows.Forms.Button btnquitar;
        private System.Windows.Forms.Button btnatras;
        private System.Windows.Forms.Label lblproveedor;
        private System.Windows.Forms.Label lblfecha;
        private System.Windows.Forms.ComboBox cbproveedor;
        private System.Windows.Forms.ComboBox cbidproveedor;
        private System.Windows.Forms.Label lblidproveedor;
        private System.Windows.Forms.DateTimePicker dtpfecha;
        private System.Windows.Forms.ComboBox cbtcomprobante;
        private System.Windows.Forms.Label lbltcomprobante;
        private System.Windows.Forms.Label lblnrocomprobante;
        private System.Windows.Forms.TextBox txtnrocomprobante;
        private System.Windows.Forms.ComboBox cbempleado;
        private System.Windows.Forms.Label lblempleado;
        private System.Windows.Forms.ComboBox cbproducto;
        private System.Windows.Forms.Label lblproducto;
        private System.Windows.Forms.ComboBox cbidproducto;
        private System.Windows.Forms.Label lblidproducto;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbidempleado;
        private System.Windows.Forms.Label lblidempl;
        private System.Windows.Forms.Button btnlimpiar;
    }
}