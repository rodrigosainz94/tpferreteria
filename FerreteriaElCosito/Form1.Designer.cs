namespace FerreteriaElCosito
{
    partial class formvs
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
            this.btnprovincias = new System.Windows.Forms.Button();
            this.btnlocalidades = new System.Windows.Forms.Button();
            this.btncativa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnprovincias
            // 
            this.btnprovincias.Location = new System.Drawing.Point(100, 30);
            this.btnprovincias.Name = "btnprovincias";
            this.btnprovincias.Size = new System.Drawing.Size(112, 39);
            this.btnprovincias.TabIndex = 0;
            this.btnprovincias.Text = "Provincias";
            this.btnprovincias.UseVisualStyleBackColor = true;
            // 
            // btnlocalidades
            // 
            this.btnlocalidades.Location = new System.Drawing.Point(100, 96);
            this.btnlocalidades.Name = "btnlocalidades";
            this.btnlocalidades.Size = new System.Drawing.Size(112, 39);
            this.btnlocalidades.TabIndex = 1;
            this.btnlocalidades.Text = "Localidades";
            this.btnlocalidades.UseVisualStyleBackColor = true;
            // 
            // btncativa
            // 
            this.btncativa.Location = new System.Drawing.Point(100, 166);
            this.btncativa.Name = "btncativa";
            this.btncativa.Size = new System.Drawing.Size(112, 39);
            this.btncativa.TabIndex = 2;
            this.btncativa.Text = "Cat. IVA";
            this.btncativa.UseVisualStyleBackColor = true;
            // 
            // formvs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btncativa);
            this.Controls.Add(this.btnlocalidades);
            this.Controls.Add(this.btnprovincias);
            this.Name = "formvs";
            this.Text = "Form Vs";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnprovincias;
        private System.Windows.Forms.Button btnlocalidades;
        private System.Windows.Forms.Button btncativa;
    }
}