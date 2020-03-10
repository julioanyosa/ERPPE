namespace Halley.Presentacion.Ventas.Administracion
{
    partial class FrmPreciosBuscados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPreciosBuscados));
            this.TdgPreciosBuscados = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            ((System.ComponentModel.ISupportInitialize)(this.TdgPreciosBuscados)).BeginInit();
            this.SuspendLayout();
            // 
            // TdgPreciosBuscados
            // 
            this.TdgPreciosBuscados.AllowUpdate = false;
            this.TdgPreciosBuscados.Caption = "PRECIOS ENCONTRADOS CON ESE CRITERIO";
            this.TdgPreciosBuscados.CaptionHeight = 17;
            this.TdgPreciosBuscados.CausesValidation = false;
            this.TdgPreciosBuscados.ColumnFooters = true;
            this.TdgPreciosBuscados.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveUp;
            this.TdgPreciosBuscados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TdgPreciosBuscados.EmptyRows = true;
            this.TdgPreciosBuscados.ExtendRightColumn = true;
            this.TdgPreciosBuscados.FilterBar = true;
            this.TdgPreciosBuscados.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgPreciosBuscados.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgPreciosBuscados.Images"))));
            this.TdgPreciosBuscados.Location = new System.Drawing.Point(0, 0);
            this.TdgPreciosBuscados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TdgPreciosBuscados.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgPreciosBuscados.Name = "TdgPreciosBuscados";
            this.TdgPreciosBuscados.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgPreciosBuscados.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgPreciosBuscados.PreviewInfo.ZoomFactor = 75D;
            this.TdgPreciosBuscados.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgPreciosBuscados.PrintInfo.PageSettings")));
            this.TdgPreciosBuscados.RowHeight = 18;
            this.TdgPreciosBuscados.Size = new System.Drawing.Size(1251, 322);
            this.TdgPreciosBuscados.TabIndex = 420;
            this.TdgPreciosBuscados.Text = "Productos Genéricos";
            this.TdgPreciosBuscados.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2007Blue;
            this.TdgPreciosBuscados.DoubleClick += new System.EventHandler(this.TdgPreciosBuscados_DoubleClick);
            this.TdgPreciosBuscados.PropBag = resources.GetString("TdgPreciosBuscados.PropBag");
            // 
            // FrmPreciosBuscados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 322);
            this.Controls.Add(this.TdgPreciosBuscados);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmPreciosBuscados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Precios Buscados con ese criterio";
            this.Load += new System.EventHandler(this.FrmPreciosBuscados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TdgPreciosBuscados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgPreciosBuscados;
    }
}