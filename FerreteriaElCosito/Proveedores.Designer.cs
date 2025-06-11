namespace FerreteriaElCosito
{
    partial class Proveedores
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
            this.dgvproveedores = new System.Windows.Forms.DataGridView();
            this.btnagregar = new System.Windows.Forms.Button();
            this.btneditar = new System.Windows.Forms.Button();
            this.btneliminar = new System.Windows.Forms.Button();
            this.btnatras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvproveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvproveedores
            // 
            this.dgvproveedores.ColumnHeadersHeight = 29;
            this.dgvproveedores.Location = new System.Drawing.Point(12, 14);
            this.dgvproveedores.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvproveedores.Name = "dgvproveedores";
            this.dgvproveedores.RowHeadersWidth = 51;
            this.dgvproveedores.Size = new System.Drawing.Size(485, 332);
            this.dgvproveedores.TabIndex = 0;
            // 
            // btnagregar
            // 
            this.btnagregar.Location = new System.Drawing.Point(512, 14);
            this.btnagregar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(77, 22);
            this.btnagregar.TabIndex = 1;
            this.btnagregar.Text = "Agregar";
            this.btnagregar.UseVisualStyleBackColor = true;
            // 
            // btneditar
            // 
            this.btneditar.Location = new System.Drawing.Point(512, 49);
            this.btneditar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btneditar.Name = "btneditar";
            this.btneditar.Size = new System.Drawing.Size(77, 22);
            this.btneditar.TabIndex = 2;
            this.btneditar.Text = "Editar";
            this.btneditar.UseVisualStyleBackColor = true;
            this.btneditar.Click += new System.EventHandler(this.btneditar_Click);
            // 
            // btneliminar
            // 
            this.btneliminar.Location = new System.Drawing.Point(512, 84);
            this.btneliminar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(77, 22);
            this.btneliminar.TabIndex = 3;
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.UseVisualStyleBackColor = true;
            // 
            // btnatras
            // 
            this.btnatras.Location = new System.Drawing.Point(512, 323);
            this.btnatras.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(77, 22);
            this.btnatras.TabIndex = 4;
            this.btnatras.Text = "Atras";
            this.btnatras.UseVisualStyleBackColor = true;
            this.btnatras.Click += new System.EventHandler(this.btnatras_Click);
            // 
            // Proveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnatras);
            this.Controls.Add(this.btneliminar);
            this.Controls.Add(this.btneditar);
            this.Controls.Add(this.btnagregar);
            this.Controls.Add(this.dgvproveedores);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Proveedores";
            this.Text = "Proveedores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvproveedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvproveedores;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.Button btneditar;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.Button btnatras;
    }
}