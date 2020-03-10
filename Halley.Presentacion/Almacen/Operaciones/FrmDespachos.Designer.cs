namespace Halley.Presentacion.Almacen
{
    partial class FrmDespachos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDespachos));
            this.TdgDespachos = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.BtnCancelar = new C1.Win.C1Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)(this.TdgDespachos)).BeginInit();
            this.SuspendLayout();
            // 
            // TdgDespachos
            // 
            this.TdgDespachos.AllowUpdate = false;
            this.TdgDespachos.CaptionHeight = 17;
            this.TdgDespachos.EmptyRows = true;
            this.TdgDespachos.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgDespachos.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgDespachos.Images"))));
            this.TdgDespachos.Location = new System.Drawing.Point(12, 43);
            this.TdgDespachos.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgDespachos.Name = "TdgDespachos";
            this.TdgDespachos.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgDespachos.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgDespachos.PreviewInfo.ZoomFactor = 75D;
            this.TdgDespachos.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgDespachos.PrintInfo.PageSettings")));
            this.TdgDespachos.RowHeight = 18;
            this.TdgDespachos.Size = new System.Drawing.Size(979, 413);
            this.TdgDespachos.TabIndex = 398;
            this.TdgDespachos.Text = "c1TrueDBGrid1";
            this.TdgDespachos.PropBag = resources.GetString("TdgDespachos.PropBag");
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Image = global::Halley.Presentacion.Properties.Resources.Cancelar_16x16;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(907, 14);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(84, 23);
            this.BtnCancelar.TabIndex = 413;
            this.BtnCancelar.Text = "&Cerrar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // FrmDespachos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 456);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.TdgDespachos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmDespachos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Despachos por comprobante";
            this.Load += new System.EventHandler(this.FrmDespachos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TdgDespachos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgDespachos;
        private C1.Win.C1Input.C1Button BtnCancelar;
    }
}