namespace Halley.Presentacion.Ventas
{
    partial class FrmEgreso
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEgreso));
            this.label7 = new System.Windows.Forms.Label();
            this.TxtConcepto = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtCantidad = new C1.Win.C1Input.C1TextBox();
            this.LblCantidad = new System.Windows.Forms.Label();
            this.BtnIngresar = new C1.Win.C1Input.C1Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.LblEmpresa = new System.Windows.Forms.Label();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TxtConcepto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 406;
            this.label7.Text = "Concepto:";
            // 
            // TxtConcepto
            // 
            this.TxtConcepto.Location = new System.Drawing.Point(12, 138);
            this.TxtConcepto.MaxLength = 200;
            this.TxtConcepto.Multiline = true;
            this.TxtConcepto.Name = "TxtConcepto";
            this.TxtConcepto.Size = new System.Drawing.Size(332, 63);
            this.TxtConcepto.TabIndex = 1;
            this.TxtConcepto.Tag = null;
            this.TxtConcepto.Value = "Por concepto de";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 410;
            this.label1.Text = "Egreso de caja";
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.Location = new System.Drawing.Point(157, 94);
            this.TxtCantidad.MaxLength = 17;
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(97, 22);
            this.TxtCantidad.TabIndex = 0;
            this.TxtCantidad.Tag = null;
            this.TxtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCantidad_KeyPress);
            // 
            // LblCantidad
            // 
            this.LblCantidad.AutoSize = true;
            this.LblCantidad.Location = new System.Drawing.Point(56, 99);
            this.LblCantidad.Name = "LblCantidad";
            this.LblCantidad.Size = new System.Drawing.Size(98, 13);
            this.LblCantidad.TabIndex = 408;
            this.LblCantidad.Text = "Cantidad a emitir:";
            // 
            // BtnIngresar
            // 
            this.BtnIngresar.Image = global::Halley.Presentacion.Properties.Resources.Egreso16x16;
            this.BtnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnIngresar.Location = new System.Drawing.Point(264, 91);
            this.BtnIngresar.Name = "BtnIngresar";
            this.BtnIngresar.Size = new System.Drawing.Size(80, 25);
            this.BtnIngresar.TabIndex = 2;
            this.BtnIngresar.Text = "Registrar";
            this.BtnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnIngresar.UseVisualStyleBackColor = true;
            this.BtnIngresar.Click += new System.EventHandler(this.BtnIngresar_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // LblEmpresa
            // 
            this.LblEmpresa.AutoSize = true;
            this.LblEmpresa.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEmpresa.ForeColor = System.Drawing.Color.SteelBlue;
            this.LblEmpresa.Location = new System.Drawing.Point(7, 44);
            this.LblEmpresa.Name = "LblEmpresa";
            this.LblEmpresa.Size = new System.Drawing.Size(69, 20);
            this.LblEmpresa.TabIndex = 411;
            this.LblEmpresa.Text = "Empresa";
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // FrmEgreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 221);
            this.Controls.Add(this.LblEmpresa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtCantidad);
            this.Controls.Add(this.LblCantidad);
            this.Controls.Add(this.BtnIngresar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtConcepto);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmEgreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Salida de dinero";
            this.Load += new System.EventHandler(this.FrmEgreso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtConcepto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private C1.Win.C1Input.C1TextBox TxtConcepto;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox TxtCantidad;
        private System.Windows.Forms.Label LblCantidad;
        private C1.Win.C1Input.C1Button BtnIngresar;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label LblEmpresa;
        private System.Windows.Forms.ErrorProvider ErrProvider;
    }
}