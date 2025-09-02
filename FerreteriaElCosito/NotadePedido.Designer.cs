namespace FerreteriaElCosito
{
    partial class frmnotadepedido
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
            this.lblidempl = new System.Windows.Forms.Label();
            this.lblempleado = new System.Windows.Forms.Label();
            this.txtnrocomprobante = new System.Windows.Forms.TextBox();
            this.lbltcomprobante = new System.Windows.Forms.Label();
            this.lblnrocomprobante = new System.Windows.Forms.Label();
            this.lblidproveedor = new System.Windows.Forms.Label();
            this.btnatras = new System.Windows.Forms.Button();
            this.btnimprimirpedido = new System.Windows.Forms.Button();
            this.lblfecha = new System.Windows.Forms.Label();
            this.lblproveedor = new System.Windows.Forms.Label();
            this.lbltipocomprobante = new System.Windows.Forms.Label();
            this.txttipocomprobante = new System.Windows.Forms.TextBox();
            this.txtidempleado = new System.Windows.Forms.TextBox();
            this.txtidproveedor = new System.Windows.Forms.TextBox();
            this.txtfecha = new System.Windows.Forms.TextBox();
            this.txtempleado = new System.Windows.Forms.TextBox();
            this.txtproveedor = new System.Windows.Forms.TextBox();
            this.dgvdetalleprod = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdetalleprod)).BeginInit();
            this.SuspendLayout();
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.Location = new System.Drawing.Point(637, 465);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(100, 28);
            this.btnlimpiar.TabIndex = 55;
            this.btnlimpiar.Text = "Limpiar";
            this.btnlimpiar.UseVisualStyleBackColor = true;
            // 
            // lblidempl
            // 
            this.lblidempl.AutoSize = true;
            this.lblidempl.Location = new System.Drawing.Point(76, 125);
            this.lblidempl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblidempl.Name = "lblidempl";
            this.lblidempl.Size = new System.Drawing.Size(90, 16);
            this.lblidempl.TabIndex = 53;
            this.lblidempl.Text = "Id Empleado :";
            // 
            // lblempleado
            // 
            this.lblempleado.AutoSize = true;
            this.lblempleado.Location = new System.Drawing.Point(278, 121);
            this.lblempleado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblempleado.Name = "lblempleado";
            this.lblempleado.Size = new System.Drawing.Size(76, 16);
            this.lblempleado.TabIndex = 46;
            this.lblempleado.Text = "Empleado :";
            // 
            // txtnrocomprobante
            // 
            this.txtnrocomprobante.Location = new System.Drawing.Point(404, 31);
            this.txtnrocomprobante.Name = "txtnrocomprobante";
            this.txtnrocomprobante.Size = new System.Drawing.Size(157, 22);
            this.txtnrocomprobante.TabIndex = 45;
            // 
            // lbltcomprobante
            // 
            this.lbltcomprobante.AutoSize = true;
            this.lbltcomprobante.Location = new System.Drawing.Point(74, 41);
            this.lbltcomprobante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltcomprobante.Name = "lbltcomprobante";
            this.lbltcomprobante.Size = new System.Drawing.Size(100, 16);
            this.lbltcomprobante.TabIndex = 43;
            this.lbltcomprobante.Text = "Tipo Comprob :";
            // 
            // lblnrocomprobante
            // 
            this.lblnrocomprobante.AutoSize = true;
            this.lblnrocomprobante.Location = new System.Drawing.Point(276, 37);
            this.lblnrocomprobante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnrocomprobante.Name = "lblnrocomprobante";
            this.lblnrocomprobante.Size = new System.Drawing.Size(114, 16);
            this.lblnrocomprobante.TabIndex = 42;
            this.lblnrocomprobante.Text = "Nro Comprobante";
            // 
            // lblidproveedor
            // 
            this.lblidproveedor.AutoSize = true;
            this.lblidproveedor.Location = new System.Drawing.Point(74, 82);
            this.lblidproveedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblidproveedor.Name = "lblidproveedor";
            this.lblidproveedor.Size = new System.Drawing.Size(93, 16);
            this.lblidproveedor.TabIndex = 39;
            this.lblidproveedor.Text = "ID Proveedor :";
            // 
            // btnatras
            // 
            this.btnatras.Location = new System.Drawing.Point(759, 465);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(100, 28);
            this.btnatras.TabIndex = 37;
            this.btnatras.Text = "Atras";
            this.btnatras.UseVisualStyleBackColor = true;
            this.btnatras.Click += new System.EventHandler(this.btnatras_Click_1);
            // 
            // btnimprimirpedido
            // 
            this.btnimprimirpedido.Location = new System.Drawing.Point(358, 465);
            this.btnimprimirpedido.Name = "btnimprimirpedido";
            this.btnimprimirpedido.Size = new System.Drawing.Size(257, 28);
            this.btnimprimirpedido.TabIndex = 35;
            this.btnimprimirpedido.Text = "IMPRIMIR NOTA DE PEDIDO";
            this.btnimprimirpedido.UseVisualStyleBackColor = true;
            this.btnimprimirpedido.Click += new System.EventHandler(this.btnimprimirpedido_Click_1);
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.Location = new System.Drawing.Point(579, 33);
            this.lblfecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(51, 16);
            this.lblfecha.TabIndex = 34;
            this.lblfecha.Text = "Fecha: ";
            // 
            // lblproveedor
            // 
            this.lblproveedor.AutoSize = true;
            this.lblproveedor.Location = new System.Drawing.Point(276, 81);
            this.lblproveedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblproveedor.Name = "lblproveedor";
            this.lblproveedor.Size = new System.Drawing.Size(77, 16);
            this.lblproveedor.TabIndex = 33;
            this.lblproveedor.Text = "Proveedor :";
            // 
            // lbltipocomprobante
            // 
            this.lbltipocomprobante.AutoSize = true;
            this.lbltipocomprobante.Location = new System.Drawing.Point(181, 41);
            this.lbltipocomprobante.Name = "lbltipocomprobante";
            this.lbltipocomprobante.Size = new System.Drawing.Size(0, 16);
            this.lbltipocomprobante.TabIndex = 56;
            // 
            // txttipocomprobante
            // 
            this.txttipocomprobante.Location = new System.Drawing.Point(169, 35);
            this.txttipocomprobante.Name = "txttipocomprobante";
            this.txttipocomprobante.Size = new System.Drawing.Size(100, 22);
            this.txttipocomprobante.TabIndex = 57;
            // 
            // txtidempleado
            // 
            this.txtidempleado.Location = new System.Drawing.Point(169, 116);
            this.txtidempleado.Name = "txtidempleado";
            this.txtidempleado.Size = new System.Drawing.Size(100, 22);
            this.txtidempleado.TabIndex = 59;
            // 
            // txtidproveedor
            // 
            this.txtidproveedor.Location = new System.Drawing.Point(169, 79);
            this.txtidproveedor.Name = "txtidproveedor";
            this.txtidproveedor.Size = new System.Drawing.Size(100, 22);
            this.txtidproveedor.TabIndex = 60;
            // 
            // txtfecha
            // 
            this.txtfecha.Location = new System.Drawing.Point(637, 31);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.Size = new System.Drawing.Size(157, 22);
            this.txtfecha.TabIndex = 61;
            // 
            // txtempleado
            // 
            this.txtempleado.Location = new System.Drawing.Point(369, 116);
            this.txtempleado.Name = "txtempleado";
            this.txtempleado.Size = new System.Drawing.Size(157, 22);
            this.txtempleado.TabIndex = 63;
            // 
            // txtproveedor
            // 
            this.txtproveedor.Location = new System.Drawing.Point(369, 75);
            this.txtproveedor.Name = "txtproveedor";
            this.txtproveedor.Size = new System.Drawing.Size(157, 22);
            this.txtproveedor.TabIndex = 64;
            // 
            // dgvdetalleprod
            // 
            this.dgvdetalleprod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdetalleprod.Location = new System.Drawing.Point(77, 167);
            this.dgvdetalleprod.Name = "dgvdetalleprod";
            this.dgvdetalleprod.RowHeadersWidth = 51;
            this.dgvdetalleprod.RowTemplate.Height = 24;
            this.dgvdetalleprod.Size = new System.Drawing.Size(821, 280);
            this.dgvdetalleprod.TabIndex = 52;
            // 
            // frmnotadepedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 522);
            this.Controls.Add(this.txtproveedor);
            this.Controls.Add(this.txtempleado);
            this.Controls.Add(this.txtfecha);
            this.Controls.Add(this.txtidproveedor);
            this.Controls.Add(this.txtidempleado);
            this.Controls.Add(this.txttipocomprobante);
            this.Controls.Add(this.lbltipocomprobante);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.lblidempl);
            this.Controls.Add(this.dgvdetalleprod);
            this.Controls.Add(this.lblempleado);
            this.Controls.Add(this.txtnrocomprobante);
            this.Controls.Add(this.lbltcomprobante);
            this.Controls.Add(this.lblnrocomprobante);
            this.Controls.Add(this.lblidproveedor);
            this.Controls.Add(this.btnatras);
            this.Controls.Add(this.btnimprimirpedido);
            this.Controls.Add(this.lblfecha);
            this.Controls.Add(this.lblproveedor);
            this.Name = "frmnotadepedido";
            this.Text = "Nota de Pedido";
            this.Load += new System.EventHandler(this.frmnotadepedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdetalleprod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnlimpiar;
        private System.Windows.Forms.Label lblidempl;
        private System.Windows.Forms.Label lblempleado;
        private System.Windows.Forms.TextBox txtnrocomprobante;
        private System.Windows.Forms.Label lbltcomprobante;
        private System.Windows.Forms.Label lblnrocomprobante;
        private System.Windows.Forms.Label lblidproveedor;
        private System.Windows.Forms.Button btnatras;
        private System.Windows.Forms.Button btnimprimirpedido;
        private System.Windows.Forms.Label lblfecha;
        private System.Windows.Forms.Label lblproveedor;
        private System.Windows.Forms.Label lbltipocomprobante;
        private System.Windows.Forms.TextBox txttipocomprobante;
        private System.Windows.Forms.TextBox txtidempleado;
        private System.Windows.Forms.TextBox txtidproveedor;
        private System.Windows.Forms.TextBox txtfecha;
        private System.Windows.Forms.TextBox txtempleado;
        private System.Windows.Forms.TextBox txtproveedor;
        private System.Windows.Forms.DataGridView dgvdetalleprod;
    }
}