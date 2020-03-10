namespace Halley.Presentacion.Ventas.Administracion
{
    partial class FrmImprimirPuntos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImprimirPuntos));
            this.BtnCerrar = new C1.Win.C1Input.C1Button();
            this.Imprimir = new C1.Win.C1Input.C1Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.TxtPuntosUsar = new C1.Win.C1Input.C1TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.LblRUC = new System.Windows.Forms.Label();
            this.LblEmpresa = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblNroDocumento = new System.Windows.Forms.Label();
            this.LblRazonSocial = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblPuntosDisponibles = new System.Windows.Forms.Label();
            this.TxtFormato = new C1.Win.C1Input.C1TextBox();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.TxtConcepto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPuntosUsar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFormato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCerrar.Image = global::Halley.Presentacion.Properties.Resources.cerrar_16x16;
            this.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCerrar.Location = new System.Drawing.Point(51, 483);
            this.BtnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(107, 31);
            this.BtnCerrar.TabIndex = 376;
            this.BtnCerrar.Text = "Cerrar";
            this.BtnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // Imprimir
            // 
            this.Imprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Imprimir.Image = global::Halley.Presentacion.Properties.Resources.print_16x16;
            this.Imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Imprimir.Location = new System.Drawing.Point(211, 483);
            this.Imprimir.Margin = new System.Windows.Forms.Padding(4);
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Size = new System.Drawing.Size(107, 31);
            this.Imprimir.TabIndex = 375;
            this.Imprimir.Text = "Imprimir";
            this.Imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Imprimir.UseVisualStyleBackColor = true;
            this.Imprimir.Click += new System.EventHandler(this.Imprimir_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // TxtPuntosUsar
            // 
            this.TxtPuntosUsar.Location = new System.Drawing.Point(150, 242);
            this.TxtPuntosUsar.Margin = new System.Windows.Forms.Padding(4);
            this.TxtPuntosUsar.Name = "TxtPuntosUsar";
            this.TxtPuntosUsar.Size = new System.Drawing.Size(143, 22);
            this.TxtPuntosUsar.TabIndex = 412;
            this.TxtPuntosUsar.Tag = null;
            this.TxtPuntosUsar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtPuntosUsar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPuntosUsar_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 242);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 19);
            this.label8.TabIndex = 413;
            this.label8.Text = "Puntos a usar:";
            // 
            // LblRUC
            // 
            this.LblRUC.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRUC.Location = new System.Drawing.Point(13, 9);
            this.LblRUC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblRUC.Name = "LblRUC";
            this.LblRUC.Size = new System.Drawing.Size(355, 19);
            this.LblRUC.TabIndex = 414;
            this.LblRUC.Text = "Crédito disponible:";
            this.LblRUC.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LblEmpresa
            // 
            this.LblEmpresa.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEmpresa.Location = new System.Drawing.Point(13, 45);
            this.LblEmpresa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblEmpresa.Name = "LblEmpresa";
            this.LblEmpresa.Size = new System.Drawing.Size(355, 18);
            this.LblEmpresa.TabIndex = 415;
            this.LblEmpresa.Text = "Crédito disponible:";
            this.LblEmpresa.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 19);
            this.label3.TabIndex = 416;
            this.label3.Text = "N° documento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 164);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 19);
            this.label4.TabIndex = 417;
            this.label4.Text = "Razon social:";
            // 
            // LblNroDocumento
            // 
            this.LblNroDocumento.AutoSize = true;
            this.LblNroDocumento.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNroDocumento.Location = new System.Drawing.Point(130, 119);
            this.LblNroDocumento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblNroDocumento.Name = "LblNroDocumento";
            this.LblNroDocumento.Size = new System.Drawing.Size(41, 19);
            this.LblNroDocumento.TabIndex = 418;
            this.LblNroDocumento.Text = "RUC:";
            // 
            // LblRazonSocial
            // 
            this.LblRazonSocial.AutoSize = true;
            this.LblRazonSocial.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRazonSocial.Location = new System.Drawing.Point(130, 164);
            this.LblRazonSocial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblRazonSocial.Name = "LblRazonSocial";
            this.LblRazonSocial.Size = new System.Drawing.Size(41, 19);
            this.LblRazonSocial.TabIndex = 419;
            this.LblRazonSocial.Text = "RUC:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 204);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 19);
            this.label5.TabIndex = 420;
            this.label5.Text = "Puntos disponibles:";
            // 
            // LblPuntosDisponibles
            // 
            this.LblPuntosDisponibles.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPuntosDisponibles.Location = new System.Drawing.Point(167, 204);
            this.LblPuntosDisponibles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblPuntosDisponibles.Name = "LblPuntosDisponibles";
            this.LblPuntosDisponibles.Size = new System.Drawing.Size(126, 19);
            this.LblPuntosDisponibles.TabIndex = 421;
            this.LblPuntosDisponibles.Text = "RUC:";
            this.LblPuntosDisponibles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtFormato
            // 
            this.TxtFormato.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFormato.Location = new System.Drawing.Point(238, 86);
            this.TxtFormato.Margin = new System.Windows.Forms.Padding(4);
            this.TxtFormato.MaxLength = 17;
            this.TxtFormato.Name = "TxtFormato";
            this.TxtFormato.Size = new System.Drawing.Size(105, 22);
            this.TxtFormato.TabIndex = 422;
            this.TxtFormato.Tag = null;
            this.TxtFormato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtFormato.Visible = false;
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 288);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 423;
            this.label1.Text = "Concepto:";
            // 
            // TxtConcepto
            // 
            this.TxtConcepto.Location = new System.Drawing.Point(25, 310);
            this.TxtConcepto.Multiline = true;
            this.TxtConcepto.Name = "TxtConcepto";
            this.TxtConcepto.Size = new System.Drawing.Size(331, 148);
            this.TxtConcepto.TabIndex = 424;
            // 
            // FrmImprimirPuntos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 528);
            this.Controls.Add(this.TxtConcepto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtFormato);
            this.Controls.Add(this.LblPuntosDisponibles);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LblRazonSocial);
            this.Controls.Add(this.LblNroDocumento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblEmpresa);
            this.Controls.Add(this.LblRUC);
            this.Controls.Add(this.TxtPuntosUsar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.Imprimir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmImprimirPuntos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Canjear puntos";
            this.Load += new System.EventHandler(this.FrmCierre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtPuntosUsar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFormato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1Button BtnCerrar;
        private C1.Win.C1Input.C1Button Imprimir;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private C1.Win.C1Input.C1TextBox TxtPuntosUsar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LblRUC;
        private System.Windows.Forms.Label LblEmpresa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblNroDocumento;
        private System.Windows.Forms.Label LblRazonSocial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblPuntosDisponibles;
        private C1.Win.C1Input.C1TextBox TxtFormato;
        private System.Windows.Forms.ErrorProvider ErrProvider;
        private System.Windows.Forms.TextBox TxtConcepto;
        private System.Windows.Forms.Label label1;
    }
}