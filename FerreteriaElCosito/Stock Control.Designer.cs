namespace FerreteriaElCosito
{
    partial class frmControlStock
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
            this.dtpfecha = new System.Windows.Forms.DateTimePicker();
            this.lblfecha = new System.Windows.Forms.Label();
            this.btnimprimir = new System.Windows.Forms.Button();
            this.btnatras = new System.Windows.Forms.Button();
            this.dgvmovimientosstock = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmovimientosstock)).BeginInit();
            this.SuspendLayout();
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.Location = new System.Drawing.Point(836, 447);
            this.btnlimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(100, 28);
            this.btnlimpiar.TabIndex = 66;
            this.btnlimpiar.Text = "Limpiar";
            this.btnlimpiar.UseVisualStyleBackColor = true;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click_1);
            // 
            // dtpfecha
            // 
            this.dtpfecha.Location = new System.Drawing.Point(120, 48);
            this.dtpfecha.Name = "dtpfecha";
            this.dtpfecha.Size = new System.Drawing.Size(167, 22);
            this.dtpfecha.TabIndex = 65;
            this.dtpfecha.ValueChanged += new System.EventHandler(this.dtpfecha_ValueChanged_1);
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.Location = new System.Drawing.Point(62, 53);
            this.lblfecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(51, 16);
            this.lblfecha.TabIndex = 64;
            this.lblfecha.Text = "Fecha: ";
            // 
            // btnimprimir
            // 
            this.btnimprimir.Location = new System.Drawing.Point(1072, 447);
            this.btnimprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnimprimir.Name = "btnimprimir";
            this.btnimprimir.Size = new System.Drawing.Size(100, 28);
            this.btnimprimir.TabIndex = 56;
            this.btnimprimir.Text = "Imprimir";
            this.btnimprimir.UseVisualStyleBackColor = true;
            this.btnimprimir.Click += new System.EventHandler(this.btnimprimir_Click_1);
            // 
            // btnatras
            // 
            this.btnatras.Location = new System.Drawing.Point(944, 447);
            this.btnatras.Margin = new System.Windows.Forms.Padding(4);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(100, 28);
            this.btnatras.TabIndex = 55;
            this.btnatras.Text = "Atras";
            this.btnatras.UseVisualStyleBackColor = true;
            this.btnatras.Click += new System.EventHandler(this.btnatras_Click_1);
            // 
            // dgvmovimientosstock
            // 
            this.dgvmovimientosstock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmovimientosstock.Location = new System.Drawing.Point(65, 81);
            this.dgvmovimientosstock.Margin = new System.Windows.Forms.Padding(4);
            this.dgvmovimientosstock.Name = "dgvmovimientosstock";
            this.dgvmovimientosstock.RowHeadersWidth = 51;
            this.dgvmovimientosstock.Size = new System.Drawing.Size(1107, 298);
            this.dgvmovimientosstock.TabIndex = 54;
            // 
            // frmControlStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 497);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.dtpfecha);
            this.Controls.Add(this.lblfecha);
            this.Controls.Add(this.btnimprimir);
            this.Controls.Add(this.btnatras);
            this.Controls.Add(this.dgvmovimientosstock);
            this.Name = "frmControlStock";
            this.Text = "Stock_Control";
            ((System.ComponentModel.ISupportInitialize)(this.dgvmovimientosstock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnlimpiar;
        private System.Windows.Forms.DateTimePicker dtpfecha;
        private System.Windows.Forms.Label lblfecha;
        private System.Windows.Forms.Button btnimprimir;
        private System.Windows.Forms.Button btnatras;
        private System.Windows.Forms.DataGridView dgvmovimientosstock;
    }
}