namespace FerreteriaElCosito
{
    partial class Productos
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
            this.btnatras = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.btnguardar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtprecio = new System.Windows.Forms.TextBox();
            this.cbproveedor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbcategoria = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdescripcionprod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtnombreproducto = new System.Windows.Forms.TextBox();
            this.btneditar = new System.Windows.Forms.Button();
            this.btneliminar = new System.Windows.Forms.Button();
            this.cbUnidadMedida = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcantidad = new System.Windows.Forms.TextBox();
            this.lbldescuento = new System.Windows.Forms.Label();
            this.txtdescuento = new System.Windows.Forms.TextBox();
            this.lblstockcritico = new System.Windows.Forms.Label();
            this.txtstockcritico = new System.Windows.Forms.TextBox();
            this.btnlimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnatras
            // 
            this.btnatras.Location = new System.Drawing.Point(22, 526);
            this.btnatras.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(125, 39);
            this.btnatras.TabIndex = 30;
            this.btnatras.Text = "ATRÁS";
            this.btnatras.UseVisualStyleBackColor = true;
            this.btnatras.Click += new System.EventHandler(this.btnatras_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(381, 10);
            this.dgvProductos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.Size = new System.Drawing.Size(1218, 492);
            this.dgvProductos.TabIndex = 29;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);
            // 
            // btnguardar
            // 
            this.btnguardar.Location = new System.Drawing.Point(1446, 526);
            this.btnguardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(153, 39);
            this.btnguardar.TabIndex = 28;
            this.btnguardar.Text = "GUARDAR";
            this.btnguardar.UseVisualStyleBackColor = true;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(95, 305);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "Precio:";
            // 
            // txtprecio
            // 
            this.txtprecio.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtprecio.Location = new System.Drawing.Point(152, 297);
            this.txtprecio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtprecio.Name = "txtprecio";
            this.txtprecio.Size = new System.Drawing.Size(208, 22);
            this.txtprecio.TabIndex = 24;
            // 
            // cbproveedor
            // 
            this.cbproveedor.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbproveedor.FormattingEnabled = true;
            this.cbproveedor.Location = new System.Drawing.Point(152, 206);
            this.cbproveedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbproveedor.Name = "cbproveedor";
            this.cbproveedor.Size = new System.Drawing.Size(208, 24);
            this.cbproveedor.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 215);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "Proveedor:";
            // 
            // cbcategoria
            // 
            this.cbcategoria.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbcategoria.FormattingEnabled = true;
            this.cbcategoria.Location = new System.Drawing.Point(152, 164);
            this.cbcategoria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbcategoria.Name = "cbcategoria";
            this.cbcategoria.Size = new System.Drawing.Size(208, 24);
            this.cbcategoria.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 174);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Categoria:";
            // 
            // txtdescripcionprod
            // 
            this.txtdescripcionprod.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtdescripcionprod.Location = new System.Drawing.Point(152, 119);
            this.txtdescripcionprod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtdescripcionprod.Name = "txtdescripcionprod";
            this.txtdescripcionprod.Size = new System.Drawing.Size(208, 22);
            this.txtdescripcionprod.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Descripción:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Nombre Producto:";
            // 
            // txtnombreproducto
            // 
            this.txtnombreproducto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtnombreproducto.Location = new System.Drawing.Point(152, 71);
            this.txtnombreproducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtnombreproducto.Name = "txtnombreproducto";
            this.txtnombreproducto.Size = new System.Drawing.Size(208, 22);
            this.txtnombreproducto.TabIndex = 16;
            // 
            // btneditar
            // 
            this.btneditar.Location = new System.Drawing.Point(1249, 526);
            this.btneditar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btneditar.Name = "btneditar";
            this.btneditar.Size = new System.Drawing.Size(141, 39);
            this.btneditar.TabIndex = 31;
            this.btneditar.Text = "EDITAR";
            this.btneditar.UseVisualStyleBackColor = true;
            this.btneditar.Click += new System.EventHandler(this.btneditar_Click);
            // 
            // btneliminar
            // 
            this.btneliminar.Location = new System.Drawing.Point(1070, 526);
            this.btneliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(127, 39);
            this.btneliminar.TabIndex = 32;
            this.btneliminar.Text = "ELIMINAR";
            this.btneliminar.UseVisualStyleBackColor = true;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // cbUnidadMedida
            // 
            this.cbUnidadMedida.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbUnidadMedida.FormattingEnabled = true;
            this.cbUnidadMedida.Location = new System.Drawing.Point(152, 251);
            this.cbUnidadMedida.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbUnidadMedida.Name = "cbUnidadMedida";
            this.cbUnidadMedida.Size = new System.Drawing.Size(208, 24);
            this.cbUnidadMedida.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 261);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 16);
            this.label6.TabIndex = 33;
            this.label6.Text = "Unidad de Medida:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(73, 352);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 36;
            this.label7.Text = "Cantidad:";
            // 
            // txtcantidad
            // 
            this.txtcantidad.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtcantidad.Location = new System.Drawing.Point(153, 343);
            this.txtcantidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(208, 22);
            this.txtcantidad.TabIndex = 35;
            // 
            // lbldescuento
            // 
            this.lbldescuento.AutoSize = true;
            this.lbldescuento.Location = new System.Drawing.Point(55, 446);
            this.lbldescuento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldescuento.Name = "lbldescuento";
            this.lbldescuento.Size = new System.Drawing.Size(75, 16);
            this.lbldescuento.TabIndex = 38;
            this.lbldescuento.Text = "Descuento:";
            // 
            // txtdescuento
            // 
            this.txtdescuento.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtdescuento.Location = new System.Drawing.Point(153, 437);
            this.txtdescuento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtdescuento.Name = "txtdescuento";
            this.txtdescuento.Size = new System.Drawing.Size(208, 22);
            this.txtdescuento.TabIndex = 37;
            // 
            // lblstockcritico
            // 
            this.lblstockcritico.AutoSize = true;
            this.lblstockcritico.Location = new System.Drawing.Point(49, 398);
            this.lblstockcritico.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblstockcritico.Name = "lblstockcritico";
            this.lblstockcritico.Size = new System.Drawing.Size(82, 16);
            this.lblstockcritico.TabIndex = 40;
            this.lblstockcritico.Text = "Stock critico:";
            // 
            // txtstockcritico
            // 
            this.txtstockcritico.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtstockcritico.Location = new System.Drawing.Point(153, 389);
            this.txtstockcritico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtstockcritico.Name = "txtstockcritico";
            this.txtstockcritico.Size = new System.Drawing.Size(208, 22);
            this.txtstockcritico.TabIndex = 39;
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.Location = new System.Drawing.Point(201, 474);
            this.btnlimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(100, 28);
            this.btnlimpiar.TabIndex = 41;
            this.btnlimpiar.Text = "LIMPIAR";
            this.btnlimpiar.UseVisualStyleBackColor = true;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1612, 596);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.lblstockcritico);
            this.Controls.Add(this.txtstockcritico);
            this.Controls.Add(this.lbldescuento);
            this.Controls.Add(this.txtdescuento);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtcantidad);
            this.Controls.Add(this.cbUnidadMedida);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btneliminar);
            this.Controls.Add(this.btneditar);
            this.Controls.Add(this.btnatras);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtprecio);
            this.Controls.Add(this.cbproveedor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbcategoria);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtdescripcionprod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtnombreproducto);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Productos";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnatras;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtprecio;
        private System.Windows.Forms.ComboBox cbproveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbcategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtdescripcionprod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtnombreproducto;
        private System.Windows.Forms.Button btneditar;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.ComboBox cbUnidadMedida;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtcantidad;
        private System.Windows.Forms.Label lbldescuento;
        private System.Windows.Forms.TextBox txtdescuento;
        private System.Windows.Forms.Label lblstockcritico;
        private System.Windows.Forms.TextBox txtstockcritico;
        private System.Windows.Forms.Button btnlimpiar;
    }
}