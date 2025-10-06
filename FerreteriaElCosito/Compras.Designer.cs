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
            this.btnconsultanp = new System.Windows.Forms.Button();
            this.btnconsultaproveedor = new System.Windows.Forms.Button();
            this.btnconsultaproducto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnagregar
            // 
            this.btnagregar.Location = new System.Drawing.Point(738, 82);
            this.btnagregar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(87, 32);
            this.btnagregar.TabIndex = 1;
            this.btnagregar.Text = "Agregar";
            this.btnagregar.UseVisualStyleBackColor = true;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // lblproveedor
            // 
            this.lblproveedor.AutoSize = true;
            this.lblproveedor.Location = new System.Drawing.Point(320, 108);
            this.lblproveedor.Name = "lblproveedor";
            this.lblproveedor.Size = new System.Drawing.Size(62, 13);
            this.lblproveedor.TabIndex = 6;
            this.lblproveedor.Text = "Proveedor :";
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.Location = new System.Drawing.Point(626, 31);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(43, 13);
            this.lblfecha.TabIndex = 7;
            this.lblfecha.Text = "Fecha: ";
            // 
            // btnhacerpedido
            // 
            this.btnhacerpedido.Location = new System.Drawing.Point(307, 429);
            this.btnhacerpedido.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnhacerpedido.Name = "btnhacerpedido";
            this.btnhacerpedido.Size = new System.Drawing.Size(171, 23);
            this.btnhacerpedido.TabIndex = 9;
            this.btnhacerpedido.Text = "EMITIR NOTA DE PEDIDO";
            this.btnhacerpedido.UseVisualStyleBackColor = true;
            this.btnhacerpedido.Click += new System.EventHandler(this.btnhacerpedido_Click);
            // 
            // btnquitar
            // 
            this.btnquitar.Location = new System.Drawing.Point(738, 156);
            this.btnquitar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnquitar.Name = "btnquitar";
            this.btnquitar.Size = new System.Drawing.Size(87, 32);
            this.btnquitar.TabIndex = 10;
            this.btnquitar.Text = "Quitar";
            this.btnquitar.UseVisualStyleBackColor = true;
            this.btnquitar.Click += new System.EventHandler(this.btnquitar_Click);
            // 
            // btnatras
            // 
            this.btnatras.Location = new System.Drawing.Point(738, 419);
            this.btnatras.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(94, 42);
            this.btnatras.TabIndex = 13;
            this.btnatras.Text = "Atras";
            this.btnatras.UseVisualStyleBackColor = true;
            this.btnatras.Click += new System.EventHandler(this.btnatras_Click);
            // 
            // cbproveedor
            // 
            this.cbproveedor.FormattingEnabled = true;
            this.cbproveedor.Location = new System.Drawing.Point(384, 105);
            this.cbproveedor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbproveedor.Name = "cbproveedor";
            this.cbproveedor.Size = new System.Drawing.Size(201, 21);
            this.cbproveedor.TabIndex = 14;
            // 
            // cbidproveedor
            // 
            this.cbidproveedor.FormattingEnabled = true;
            this.cbidproveedor.Location = new System.Drawing.Point(124, 110);
            this.cbidproveedor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbidproveedor.Name = "cbidproveedor";
            this.cbidproveedor.Size = new System.Drawing.Size(104, 21);
            this.cbidproveedor.TabIndex = 16;
            // 
            // lblidproveedor
            // 
            this.lblidproveedor.AutoSize = true;
            this.lblidproveedor.Location = new System.Drawing.Point(43, 118);
            this.lblidproveedor.Name = "lblidproveedor";
            this.lblidproveedor.Size = new System.Drawing.Size(76, 13);
            this.lblidproveedor.TabIndex = 15;
            this.lblidproveedor.Text = "ID Proveedor :";
            // 
            // dtpfecha
            // 
            this.dtpfecha.Location = new System.Drawing.Point(674, 29);
            this.dtpfecha.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpfecha.Name = "dtpfecha";
            this.dtpfecha.Size = new System.Drawing.Size(151, 20);
            this.dtpfecha.TabIndex = 17;
            // 
            // cbtcomprobante
            // 
            this.cbtcomprobante.FormattingEnabled = true;
            this.cbtcomprobante.Location = new System.Drawing.Point(124, 31);
            this.cbtcomprobante.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbtcomprobante.Name = "cbtcomprobante";
            this.cbtcomprobante.Size = new System.Drawing.Size(104, 21);
            this.cbtcomprobante.TabIndex = 20;
            // 
            // lbltcomprobante
            // 
            this.lbltcomprobante.AutoSize = true;
            this.lbltcomprobante.Location = new System.Drawing.Point(40, 31);
            this.lbltcomprobante.Name = "lbltcomprobante";
            this.lbltcomprobante.Size = new System.Drawing.Size(79, 13);
            this.lbltcomprobante.TabIndex = 19;
            this.lbltcomprobante.Text = "Tipo Comprob :";
            // 
            // lblnrocomprobante
            // 
            this.lblnrocomprobante.AutoSize = true;
            this.lblnrocomprobante.Location = new System.Drawing.Point(288, 35);
            this.lblnrocomprobante.Name = "lblnrocomprobante";
            this.lblnrocomprobante.Size = new System.Drawing.Size(93, 13);
            this.lblnrocomprobante.TabIndex = 18;
            this.lblnrocomprobante.Text = "Nro Comprobante:";
            this.lblnrocomprobante.Click += new System.EventHandler(this.lblnrocomprobante_Click);
            // 
            // txtnrocomprobante
            // 
            this.txtnrocomprobante.Location = new System.Drawing.Point(384, 35);
            this.txtnrocomprobante.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtnrocomprobante.Name = "txtnrocomprobante";
            this.txtnrocomprobante.Size = new System.Drawing.Size(94, 20);
            this.txtnrocomprobante.TabIndex = 21;
            this.txtnrocomprobante.TextChanged += new System.EventHandler(this.txtnrocomprobante_TextChanged);
            // 
            // cbempleado
            // 
            this.cbempleado.FormattingEnabled = true;
            this.cbempleado.Location = new System.Drawing.Point(384, 74);
            this.cbempleado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbempleado.Name = "cbempleado";
            this.cbempleado.Size = new System.Drawing.Size(201, 21);
            this.cbempleado.TabIndex = 23;
            this.cbempleado.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblempleado
            // 
            this.lblempleado.AutoSize = true;
            this.lblempleado.Location = new System.Drawing.Point(322, 74);
            this.lblempleado.Name = "lblempleado";
            this.lblempleado.Size = new System.Drawing.Size(60, 13);
            this.lblempleado.TabIndex = 22;
            this.lblempleado.Text = "Empleado :";
            // 
            // cbproducto
            // 
            this.cbproducto.FormattingEnabled = true;
            this.cbproducto.Location = new System.Drawing.Point(384, 143);
            this.cbproducto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbproducto.Name = "cbproducto";
            this.cbproducto.Size = new System.Drawing.Size(201, 21);
            this.cbproducto.TabIndex = 27;
            // 
            // lblproducto
            // 
            this.lblproducto.AutoSize = true;
            this.lblproducto.Location = new System.Drawing.Point(322, 147);
            this.lblproducto.Name = "lblproducto";
            this.lblproducto.Size = new System.Drawing.Size(56, 13);
            this.lblproducto.TabIndex = 26;
            this.lblproducto.Text = "Producto :";
            this.lblproducto.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbidproducto
            // 
            this.cbidproducto.FormattingEnabled = true;
            this.cbidproducto.Location = new System.Drawing.Point(124, 148);
            this.cbidproducto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbidproducto.Name = "cbidproducto";
            this.cbidproducto.Size = new System.Drawing.Size(104, 21);
            this.cbidproducto.TabIndex = 25;
            // 
            // lblidproducto
            // 
            this.lblidproducto.AutoSize = true;
            this.lblidproducto.Location = new System.Drawing.Point(49, 151);
            this.lblidproducto.Name = "lblidproducto";
            this.lblidproducto.Size = new System.Drawing.Size(70, 13);
            this.lblidproducto.TabIndex = 24;
            this.lblidproducto.Text = "ID Producto :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 203);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(814, 205);
            this.dataGridView1.TabIndex = 28;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cbidempleado
            // 
            this.cbidempleado.FormattingEnabled = true;
            this.cbidempleado.Location = new System.Drawing.Point(124, 76);
            this.cbidempleado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbidempleado.Name = "cbidempleado";
            this.cbidempleado.Size = new System.Drawing.Size(104, 21);
            this.cbidempleado.TabIndex = 30;
            // 
            // lblidempl
            // 
            this.lblidempl.AutoSize = true;
            this.lblidempl.Location = new System.Drawing.Point(50, 82);
            this.lblidempl.Name = "lblidempl";
            this.lblidempl.Size = new System.Drawing.Size(72, 13);
            this.lblidempl.TabIndex = 29;
            this.lblidempl.Text = "Id Empleado :";
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.Location = new System.Drawing.Point(738, 118);
            this.btnlimpiar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(87, 34);
            this.btnlimpiar.TabIndex = 31;
            this.btnlimpiar.Text = "Limpiar";
            this.btnlimpiar.UseVisualStyleBackColor = true;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // btnconsultanp
            // 
            this.btnconsultanp.Location = new System.Drawing.Point(482, 35);
            this.btnconsultanp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnconsultanp.Name = "btnconsultanp";
            this.btnconsultanp.Size = new System.Drawing.Size(106, 19);
            this.btnconsultanp.TabIndex = 32;
            this.btnconsultanp.Text = "Consulta NP";
            this.btnconsultanp.UseVisualStyleBackColor = true;
            this.btnconsultanp.Click += new System.EventHandler(this.btnconsultanp_Click);
            // 
            // btnconsultaproveedor
            // 
            this.btnconsultaproveedor.Location = new System.Drawing.Point(589, 105);
            this.btnconsultaproveedor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnconsultaproveedor.Name = "btnconsultaproveedor";
            this.btnconsultaproveedor.Size = new System.Drawing.Size(85, 19);
            this.btnconsultaproveedor.TabIndex = 33;
            this.btnconsultaproveedor.Text = "Consulta Prov.";
            this.btnconsultaproveedor.UseVisualStyleBackColor = true;
            this.btnconsultaproveedor.Click += new System.EventHandler(this.btnconsultaproveedor_Click);
            // 
            // btnconsultaproducto
            // 
            this.btnconsultaproducto.Location = new System.Drawing.Point(589, 143);
            this.btnconsultaproducto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnconsultaproducto.Name = "btnconsultaproducto";
            this.btnconsultaproducto.Size = new System.Drawing.Size(85, 19);
            this.btnconsultaproducto.TabIndex = 34;
            this.btnconsultaproducto.Text = "Consulta Prod.";
            this.btnconsultaproducto.UseVisualStyleBackColor = true;
            this.btnconsultaproducto.Click += new System.EventHandler(this.btnconsultaproducto_Click);
            // 
            // Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(857, 481);
            this.Controls.Add(this.btnconsultaproducto);
            this.Controls.Add(this.btnconsultaproveedor);
            this.Controls.Add(this.btnconsultanp);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Button btnconsultanp;
        private System.Windows.Forms.Button btnconsultaproveedor;
        private System.Windows.Forms.Button btnconsultaproducto;
    }
}