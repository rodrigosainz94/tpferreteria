namespace FerreteriaElCosito
{
    partial class Caja
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
            this.dgvmovimientoscaja = new System.Windows.Forms.DataGridView();
            this.btnatras = new System.Windows.Forms.Button();
            this.btnimprimir = new System.Windows.Forms.Button();
            this.txtsdofinalteorico = new System.Windows.Forms.TextBox();
            this.lblsdoteorico = new System.Windows.Forms.Label();
            this.lblsaldoinicial = new System.Windows.Forms.Label();
            this.cbtotalegresos = new System.Windows.Forms.ComboBox();
            this.lbltotalegresos = new System.Windows.Forms.Label();
            this.cbtotalingresos = new System.Windows.Forms.ComboBox();
            this.lbltotalingresos = new System.Windows.Forms.Label();
            this.dtpfecha = new System.Windows.Forms.DateTimePicker();
            this.lblfecha = new System.Windows.Forms.Label();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.btnlimpiar = new System.Windows.Forms.Button();
            this.lbldiferencia = new System.Windows.Forms.Label();
            this.txtdiferencia = new System.Windows.Forms.TextBox();
            this.lblarqueo = new System.Windows.Forms.Label();
            this.txtarqueo = new System.Windows.Forms.TextBox();
            this.txtsdoinicial = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmovimientoscaja)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvmovimientoscaja
            // 
            this.dgvmovimientoscaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmovimientoscaja.Location = new System.Drawing.Point(13, 56);
            this.dgvmovimientoscaja.Margin = new System.Windows.Forms.Padding(4);
            this.dgvmovimientoscaja.Name = "dgvmovimientoscaja";
            this.dgvmovimientoscaja.RowHeadersWidth = 51;
            this.dgvmovimientoscaja.Size = new System.Drawing.Size(967, 298);
            this.dgvmovimientoscaja.TabIndex = 0;
            this.dgvmovimientoscaja.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnatras
            // 
            this.btnatras.Location = new System.Drawing.Point(895, 412);
            this.btnatras.Margin = new System.Windows.Forms.Padding(4);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(100, 28);
            this.btnatras.TabIndex = 1;
            this.btnatras.Text = "Atras";
            this.btnatras.UseVisualStyleBackColor = true;
            this.btnatras.Click += new System.EventHandler(this.btnatras_Click);
            // 
            // btnimprimir
            // 
            this.btnimprimir.Location = new System.Drawing.Point(844, 376);
            this.btnimprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnimprimir.Name = "btnimprimir";
            this.btnimprimir.Size = new System.Drawing.Size(100, 28);
            this.btnimprimir.TabIndex = 2;
            this.btnimprimir.Text = "Imprimir";
            this.btnimprimir.UseVisualStyleBackColor = true;
            this.btnimprimir.Click += new System.EventHandler(this.btnimprimir_Click);
            // 
            // txtsdofinalteorico
            // 
            this.txtsdofinalteorico.Location = new System.Drawing.Point(122, 382);
            this.txtsdofinalteorico.Margin = new System.Windows.Forms.Padding(4);
            this.txtsdofinalteorico.Name = "txtsdofinalteorico";
            this.txtsdofinalteorico.Size = new System.Drawing.Size(132, 22);
            this.txtsdofinalteorico.TabIndex = 3;
            this.txtsdofinalteorico.TextChanged += new System.EventHandler(this.txtsdofinalteorico_TextChanged);
            // 
            // lblsdoteorico
            // 
            this.lblsdoteorico.AutoSize = true;
            this.lblsdoteorico.Location = new System.Drawing.Point(18, 385);
            this.lblsdoteorico.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblsdoteorico.Name = "lblsdoteorico";
            this.lblsdoteorico.Size = new System.Drawing.Size(96, 16);
            this.lblsdoteorico.TabIndex = 4;
            this.lblsdoteorico.Text = "Saldo Teórico:";
            // 
            // lblsaldoinicial
            // 
            this.lblsaldoinicial.AutoSize = true;
            this.lblsaldoinicial.Location = new System.Drawing.Point(274, 19);
            this.lblsaldoinicial.Name = "lblsaldoinicial";
            this.lblsaldoinicial.Size = new System.Drawing.Size(80, 16);
            this.lblsaldoinicial.TabIndex = 5;
            this.lblsaldoinicial.Text = "Saldo Inicial";
            this.lblsaldoinicial.Click += new System.EventHandler(this.lblsaldoinicial_Click);
            // 
            // cbtotalegresos
            // 
            this.cbtotalegresos.FormattingEnabled = true;
            this.cbtotalegresos.Location = new System.Drawing.Point(863, 15);
            this.cbtotalegresos.Name = "cbtotalegresos";
            this.cbtotalegresos.Size = new System.Drawing.Size(132, 24);
            this.cbtotalegresos.TabIndex = 8;
            this.cbtotalegresos.SelectedIndexChanged += new System.EventHandler(this.cbtotalegresos_SelectedIndexChanged);
            // 
            // lbltotalegresos
            // 
            this.lbltotalegresos.AutoSize = true;
            this.lbltotalegresos.Location = new System.Drawing.Point(765, 18);
            this.lbltotalegresos.Name = "lbltotalegresos";
            this.lbltotalegresos.Size = new System.Drawing.Size(92, 16);
            this.lbltotalegresos.TabIndex = 7;
            this.lbltotalegresos.Text = "Total Egresos";
            // 
            // cbtotalingresos
            // 
            this.cbtotalingresos.FormattingEnabled = true;
            this.cbtotalingresos.Location = new System.Drawing.Point(615, 15);
            this.cbtotalingresos.Name = "cbtotalingresos";
            this.cbtotalingresos.Size = new System.Drawing.Size(133, 24);
            this.cbtotalingresos.TabIndex = 10;
            this.cbtotalingresos.SelectedIndexChanged += new System.EventHandler(this.cbtotalingresos_SelectedIndexChanged);
            // 
            // lbltotalingresos
            // 
            this.lbltotalingresos.AutoSize = true;
            this.lbltotalingresos.Location = new System.Drawing.Point(513, 18);
            this.lbltotalingresos.Name = "lbltotalingresos";
            this.lbltotalingresos.Size = new System.Drawing.Size(96, 16);
            this.lbltotalingresos.TabIndex = 9;
            this.lbltotalingresos.Text = "Total Ingresos:";
            // 
            // dtpfecha
            // 
            this.dtpfecha.Location = new System.Drawing.Point(71, 13);
            this.dtpfecha.Name = "dtpfecha";
            this.dtpfecha.Size = new System.Drawing.Size(167, 22);
            this.dtpfecha.TabIndex = 46;
            this.dtpfecha.ValueChanged += new System.EventHandler(this.dtpfecha_ValueChanged);
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.Location = new System.Drawing.Point(13, 18);
            this.lblfecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(51, 16);
            this.lblfecha.TabIndex = 45;
            this.lblfecha.Text = "Fecha: ";
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.Location = new System.Drawing.Point(787, 412);
            this.btnlimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(100, 28);
            this.btnlimpiar.TabIndex = 47;
            this.btnlimpiar.Text = "Limpiar";
            this.btnlimpiar.UseVisualStyleBackColor = true;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // lbldiferencia
            // 
            this.lbldiferencia.AutoSize = true;
            this.lbldiferencia.Location = new System.Drawing.Point(513, 385);
            this.lbldiferencia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldiferencia.Name = "lbldiferencia";
            this.lbldiferencia.Size = new System.Drawing.Size(71, 16);
            this.lbldiferencia.TabIndex = 49;
            this.lbldiferencia.Text = "Diferencia:";
            // 
            // txtdiferencia
            // 
            this.txtdiferencia.Location = new System.Drawing.Point(603, 382);
            this.txtdiferencia.Margin = new System.Windows.Forms.Padding(4);
            this.txtdiferencia.Name = "txtdiferencia";
            this.txtdiferencia.Size = new System.Drawing.Size(132, 22);
            this.txtdiferencia.TabIndex = 48;
            this.txtdiferencia.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // lblarqueo
            // 
            this.lblarqueo.AutoSize = true;
            this.lblarqueo.Location = new System.Drawing.Point(295, 385);
            this.lblarqueo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblarqueo.Name = "lblarqueo";
            this.lblarqueo.Size = new System.Drawing.Size(54, 16);
            this.lblarqueo.TabIndex = 51;
            this.lblarqueo.Text = "Arqueo:";
            // 
            // txtarqueo
            // 
            this.txtarqueo.Location = new System.Drawing.Point(360, 382);
            this.txtarqueo.Margin = new System.Windows.Forms.Padding(4);
            this.txtarqueo.Name = "txtarqueo";
            this.txtarqueo.Size = new System.Drawing.Size(132, 22);
            this.txtarqueo.TabIndex = 50;
            this.txtarqueo.TextChanged += new System.EventHandler(this.txtarqueo_TextChanged);
            // 
            // txtsdoinicial
            // 
            this.txtsdoinicial.Location = new System.Drawing.Point(361, 15);
            this.txtsdoinicial.Name = "txtsdoinicial";
            this.txtsdoinicial.Size = new System.Drawing.Size(100, 22);
            this.txtsdoinicial.TabIndex = 52;
            // 
            // Caja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 453);
            this.Controls.Add(this.txtsdoinicial);
            this.Controls.Add(this.lblarqueo);
            this.Controls.Add(this.txtarqueo);
            this.Controls.Add(this.lbldiferencia);
            this.Controls.Add(this.txtdiferencia);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.dtpfecha);
            this.Controls.Add(this.lblfecha);
            this.Controls.Add(this.cbtotalingresos);
            this.Controls.Add(this.lbltotalingresos);
            this.Controls.Add(this.cbtotalegresos);
            this.Controls.Add(this.lbltotalegresos);
            this.Controls.Add(this.lblsaldoinicial);
            this.Controls.Add(this.lblsdoteorico);
            this.Controls.Add(this.txtsdofinalteorico);
            this.Controls.Add(this.btnimprimir);
            this.Controls.Add(this.btnatras);
            this.Controls.Add(this.dgvmovimientoscaja);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Caja";
            this.Text = "Caja";
            this.Load += new System.EventHandler(this.Caja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvmovimientoscaja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvmovimientoscaja;
        private System.Windows.Forms.Button btnatras;
        private System.Windows.Forms.Button btnimprimir;
        private System.Windows.Forms.TextBox txtsdofinalteorico;
        private System.Windows.Forms.Label lblsdoteorico;
        private System.Windows.Forms.Label lblsaldoinicial;
        private System.Windows.Forms.ComboBox cbtotalegresos;
        private System.Windows.Forms.Label lbltotalegresos;
        private System.Windows.Forms.ComboBox cbtotalingresos;
        private System.Windows.Forms.Label lbltotalingresos;
        private System.Windows.Forms.DateTimePicker dtpfecha;
        private System.Windows.Forms.Label lblfecha;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.Button btnlimpiar;
        private System.Windows.Forms.Label lbldiferencia;
        private System.Windows.Forms.TextBox txtdiferencia;
        private System.Windows.Forms.Label lblarqueo;
        private System.Windows.Forms.TextBox txtarqueo;
        private System.Windows.Forms.TextBox txtsdoinicial;
    }
}