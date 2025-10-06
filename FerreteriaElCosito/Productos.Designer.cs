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
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnatras
            // 
            this.btnatras.Location = new System.Drawing.Point(308, 427);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(94, 32);
            this.btnatras.TabIndex = 30;
            this.btnatras.Text = "ATRÁS";
            this.btnatras.UseVisualStyleBackColor = true;
            this.btnatras.Click += new System.EventHandler(this.btnatras_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(286, 8);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.Size = new System.Drawing.Size(556, 400);
            this.dgvProductos.TabIndex = 29;
            // 
            // btnguardar
            // 
            this.btnguardar.Location = new System.Drawing.Point(727, 427);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(115, 32);
            this.btnguardar.TabIndex = 28;
            this.btnguardar.Text = "GUARDAR";
            this.btnguardar.UseVisualStyleBackColor = true;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Precio:";
            // 
            // txtprecio
            // 
            this.txtprecio.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtprecio.Location = new System.Drawing.Point(114, 241);
            this.txtprecio.Name = "txtprecio";
            this.txtprecio.Size = new System.Drawing.Size(157, 20);
            this.txtprecio.TabIndex = 24;
            // 
            // cbproveedor
            // 
            this.cbproveedor.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbproveedor.FormattingEnabled = true;
            this.cbproveedor.Location = new System.Drawing.Point(114, 167);
            this.cbproveedor.Name = "cbproveedor";
            this.cbproveedor.Size = new System.Drawing.Size(121, 21);
            this.cbproveedor.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Proveedor:";
            // 
            // cbcategoria
            // 
            this.cbcategoria.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbcategoria.FormattingEnabled = true;
            this.cbcategoria.Location = new System.Drawing.Point(114, 133);
            this.cbcategoria.Name = "cbcategoria";
            this.cbcategoria.Size = new System.Drawing.Size(121, 21);
            this.cbcategoria.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Categoria:";
            // 
            // txtdescripcionprod
            // 
            this.txtdescripcionprod.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtdescripcionprod.Location = new System.Drawing.Point(114, 97);
            this.txtdescripcionprod.Name = "txtdescripcionprod";
            this.txtdescripcionprod.Size = new System.Drawing.Size(157, 20);
            this.txtdescripcionprod.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Descripción:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Nombre Producto:";
            // 
            // txtnombreproducto
            // 
            this.txtnombreproducto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtnombreproducto.Location = new System.Drawing.Point(114, 58);
            this.txtnombreproducto.Name = "txtnombreproducto";
            this.txtnombreproducto.Size = new System.Drawing.Size(157, 20);
            this.txtnombreproducto.TabIndex = 16;
            // 
            // btneditar
            // 
            this.btneditar.Location = new System.Drawing.Point(577, 427);
            this.btneditar.Name = "btneditar";
            this.btneditar.Size = new System.Drawing.Size(106, 32);
            this.btneditar.TabIndex = 31;
            this.btneditar.Text = "EDITAR";
            this.btneditar.UseVisualStyleBackColor = true;
            this.btneditar.Click += new System.EventHandler(this.btneditar_Click);
            // 
            // btneliminar
            // 
            this.btneliminar.Location = new System.Drawing.Point(445, 427);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(95, 32);
            this.btneliminar.TabIndex = 32;
            this.btneliminar.Text = "ELIMINAR";
            this.btneliminar.UseVisualStyleBackColor = true;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // cbUnidadMedida
            // 
            this.cbUnidadMedida.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbUnidadMedida.FormattingEnabled = true;
            this.cbUnidadMedida.Location = new System.Drawing.Point(114, 204);
            this.cbUnidadMedida.Name = "cbUnidadMedida";
            this.cbUnidadMedida.Size = new System.Drawing.Size(121, 21);
            this.cbUnidadMedida.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Unidad de Medida:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Cantidad:";
            // 
            // txtcantidad
            // 
            this.txtcantidad.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtcantidad.Location = new System.Drawing.Point(115, 279);
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(157, 20);
            this.txtcantidad.TabIndex = 35;
            // 
            // lbldescuento
            // 
            this.lbldescuento.AutoSize = true;
            this.lbldescuento.Location = new System.Drawing.Point(41, 362);
            this.lbldescuento.Name = "lbldescuento";
            this.lbldescuento.Size = new System.Drawing.Size(62, 13);
            this.lbldescuento.TabIndex = 38;
            this.lbldescuento.Text = "Descuento:";
            // 
            // txtdescuento
            // 
            this.txtdescuento.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtdescuento.Location = new System.Drawing.Point(115, 355);
            this.txtdescuento.Name = "txtdescuento";
            this.txtdescuento.Size = new System.Drawing.Size(157, 20);
            this.txtdescuento.TabIndex = 37;
            // 
            // lblstockcritico
            // 
            this.lblstockcritico.AutoSize = true;
            this.lblstockcritico.Location = new System.Drawing.Point(37, 323);
            this.lblstockcritico.Name = "lblstockcritico";
            this.lblstockcritico.Size = new System.Drawing.Size(69, 13);
            this.lblstockcritico.TabIndex = 40;
            this.lblstockcritico.Text = "Stock critico:";
            // 
            // txtstockcritico
            // 
            this.txtstockcritico.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtstockcritico.Location = new System.Drawing.Point(115, 316);
            this.txtstockcritico.Name = "txtstockcritico";
            this.txtstockcritico.Size = new System.Drawing.Size(157, 20);
            this.txtstockcritico.TabIndex = 39;
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(854, 484);
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
    }
}