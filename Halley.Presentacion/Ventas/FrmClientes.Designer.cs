namespace Halley.Presentacion.Ventas
{
    partial class FrmClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClientes));
            this.useCliente1 = new Halley.Presentacion.Ventas.UseCliente();
            this.BtnSeleccionar = new C1.Win.C1Input.C1Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // useCliente1
            // 
            this.useCliente1.Location = new System.Drawing.Point(-1, 44);
            this.useCliente1.Name = "useCliente1";
            this.useCliente1.Size = new System.Drawing.Size(554, 129);
            this.useCliente1.TabIndex = 0;
            // 
            // BtnSeleccionar
            // 
            this.BtnSeleccionar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.BtnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSeleccionar.Location = new System.Drawing.Point(454, 13);
            this.BtnSeleccionar.Name = "BtnSeleccionar";
            this.BtnSeleccionar.Size = new System.Drawing.Size(88, 25);
            this.BtnSeleccionar.TabIndex = 417;
            this.BtnSeleccionar.Text = "Seleccionar";
            this.BtnSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSeleccionar.UseVisualStyleBackColor = true;
            this.BtnSeleccionar.Click += new System.EventHandler(this.BtnSeleccionar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 21);
            this.label1.TabIndex = 418;
            this.label1.Text = "Lista de clientes";
            // 
            // FrmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 178);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSeleccionar);
            this.Controls.Add(this.useCliente1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmClientes";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.FrmClientes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UseCliente useCliente1;
        private C1.Win.C1Input.C1Button BtnSeleccionar;
        private System.Windows.Forms.Label label1;
    }
}