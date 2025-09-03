namespace FerreteriaElCosito
{
    partial class ConsultaNotadePedido
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
            this.txtproveedor = new System.Windows.Forms.TextBox();
            this.txtfecha = new System.Windows.Forms.TextBox();
            this.txtnrocomprobante = new System.Windows.Forms.TextBox();
            this.lblnrocomprobante = new System.Windows.Forms.Label();
            this.lblfecha = new System.Windows.Forms.Label();
            this.lblproveedor = new System.Windows.Forms.Label();
            this.lblproducto = new System.Windows.Forms.Label();
            this.dgvdetallenp = new System.Windows.Forms.DataGridView();
            this.btnlimpiar = new System.Windows.Forms.Button();
            this.btnatras = new System.Windows.Forms.Button();
            this.txtproducto = new System.Windows.Forms.TextBox();
            this.btnbuscarnp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdetallenp)).BeginInit();
            this.SuspendLayout();
            // 
            // txtproveedor
            // 
            this.txtproveedor.Location = new System.Drawing.Point(121, 65);
            this.txtproveedor.Name = "txtproveedor";
            this.txtproveedor.Size = new System.Drawing.Size(157, 22);
            this.txtproveedor.TabIndex = 72;
            // 
            // txtfecha
            // 
            this.txtfecha.Location = new System.Drawing.Point(389, 21);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.Size = new System.Drawing.Size(157, 22);
            this.txtfecha.TabIndex = 70;
            // 
            // txtnrocomprobante
            // 
            this.txtnrocomprobante.Location = new System.Drawing.Point(156, 21);
            this.txtnrocomprobante.Name = "txtnrocomprobante";
            this.txtnrocomprobante.Size = new System.Drawing.Size(157, 22);
            this.txtnrocomprobante.TabIndex = 68;
            // 
            // lblnrocomprobante
            // 
            this.lblnrocomprobante.AutoSize = true;
            this.lblnrocomprobante.Location = new System.Drawing.Point(28, 27);
            this.lblnrocomprobante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnrocomprobante.Name = "lblnrocomprobante";
            this.lblnrocomprobante.Size = new System.Drawing.Size(114, 16);
            this.lblnrocomprobante.TabIndex = 67;
            this.lblnrocomprobante.Text = "Nro Comprobante";
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.Location = new System.Drawing.Point(331, 23);
            this.lblfecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(51, 16);
            this.lblfecha.TabIndex = 66;
            this.lblfecha.Text = "Fecha: ";
            // 
            // lblproveedor
            // 
            this.lblproveedor.AutoSize = true;
            this.lblproveedor.Location = new System.Drawing.Point(28, 71);
            this.lblproveedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblproveedor.Name = "lblproveedor";
            this.lblproveedor.Size = new System.Drawing.Size(77, 16);
            this.lblproveedor.TabIndex = 65;
            this.lblproveedor.Text = "Proveedor :";
            // 
            // lblproducto
            // 
            this.lblproducto.AutoSize = true;
            this.lblproducto.Location = new System.Drawing.Point(306, 73);
            this.lblproducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblproducto.Name = "lblproducto";
            this.lblproducto.Size = new System.Drawing.Size(67, 16);
            this.lblproducto.TabIndex = 73;
            this.lblproducto.Text = "Producto :";
            // 
            // dgvdetallenp
            // 
            this.dgvdetallenp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdetallenp.Location = new System.Drawing.Point(31, 113);
            this.dgvdetallenp.Name = "dgvdetallenp";
            this.dgvdetallenp.RowHeadersWidth = 51;
            this.dgvdetallenp.RowTemplate.Height = 24;
            this.dgvdetallenp.Size = new System.Drawing.Size(740, 263);
            this.dgvdetallenp.TabIndex = 75;
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.Location = new System.Drawing.Point(547, 394);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(100, 28);
            this.btnlimpiar.TabIndex = 77;
            this.btnlimpiar.Text = "Limpiar";
            this.btnlimpiar.UseVisualStyleBackColor = true;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click_1);
            // 
            // btnatras
            // 
            this.btnatras.Location = new System.Drawing.Point(667, 394);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(100, 28);
            this.btnatras.TabIndex = 76;
            this.btnatras.Text = "Atras";
            this.btnatras.UseVisualStyleBackColor = true;
            this.btnatras.Click += new System.EventHandler(this.btnatras_Click_1);
            // 
            // txtproducto
            // 
            this.txtproducto.Location = new System.Drawing.Point(389, 73);
            this.txtproducto.Name = "txtproducto";
            this.txtproducto.Size = new System.Drawing.Size(319, 22);
            this.txtproducto.TabIndex = 78;
            // 
            // btnbuscarnp
            // 
            this.btnbuscarnp.Location = new System.Drawing.Point(571, 21);
            this.btnbuscarnp.Name = "btnbuscarnp";
            this.btnbuscarnp.Size = new System.Drawing.Size(200, 23);
            this.btnbuscarnp.TabIndex = 79;
            this.btnbuscarnp.Text = "BUSCAR NOTA DE PEDIDO";
            this.btnbuscarnp.UseVisualStyleBackColor = true;
            this.btnbuscarnp.Click += new System.EventHandler(this.btnbuscarnp_Click_1);
            // 
            // ConsultaNotadePedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnbuscarnp);
            this.Controls.Add(this.txtproducto);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.btnatras);
            this.Controls.Add(this.dgvdetallenp);
            this.Controls.Add(this.lblproducto);
            this.Controls.Add(this.txtproveedor);
            this.Controls.Add(this.txtfecha);
            this.Controls.Add(this.txtnrocomprobante);
            this.Controls.Add(this.lblnrocomprobante);
            this.Controls.Add(this.lblfecha);
            this.Controls.Add(this.lblproveedor);
            this.Name = "ConsultaNotadePedido";
            this.Text = "ConsultaNotadePedido";
            this.Load += new System.EventHandler(this.ConsultaNotadePedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdetallenp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtproveedor;
        private System.Windows.Forms.TextBox txtfecha;
        private System.Windows.Forms.TextBox txtnrocomprobante;
        private System.Windows.Forms.Label lblnrocomprobante;
        private System.Windows.Forms.Label lblfecha;
        private System.Windows.Forms.Label lblproveedor;
        private System.Windows.Forms.Label lblproducto;
        private System.Windows.Forms.DataGridView dgvdetallenp;
        private System.Windows.Forms.Button btnlimpiar;
        private System.Windows.Forms.Button btnatras;
        private System.Windows.Forms.TextBox txtproducto;
        private System.Windows.Forms.Button btnbuscarnp;
    }
}