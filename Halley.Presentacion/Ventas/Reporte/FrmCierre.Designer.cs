namespace Halley.Presentacion.Ventas.Reporte
{
    partial class FrmCierre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCierre));
            this.TxtTexto = new C1.Win.C1Input.C1TextBox();
            this.BtnCerrar = new C1.Win.C1Input.C1Button();
            this.Imprimir = new C1.Win.C1Input.C1Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTexto)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtTexto
            // 
            this.TxtTexto.AcceptsReturn = true;
            this.TxtTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTexto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtTexto.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTexto.Location = new System.Drawing.Point(12, 12);
            this.TxtTexto.MaxLength = 17;
            this.TxtTexto.Multiline = true;
            this.TxtTexto.Name = "TxtTexto";
            this.TxtTexto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtTexto.Size = new System.Drawing.Size(262, 471);
            this.TxtTexto.TabIndex = 371;
            this.TxtTexto.Tag = null;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCerrar.Image = global::Halley.Presentacion.Properties.Resources.cerrar_16x16;
            this.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCerrar.Location = new System.Drawing.Point(38, 489);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(80, 25);
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
            this.Imprimir.Location = new System.Drawing.Point(158, 489);
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Size = new System.Drawing.Size(80, 25);
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
            // FrmCierre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 526);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.Imprimir);
            this.Controls.Add(this.TxtTexto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmCierre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cierre almacenado";
            this.Load += new System.EventHandler(this.FrmCierre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtTexto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1Input.C1TextBox TxtTexto;
        private C1.Win.C1Input.C1Button BtnCerrar;
        private C1.Win.C1Input.C1Button Imprimir;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}