namespace Halley.Presentacion.Ventas.ReporteNavideño
{
    partial class RepEntrega
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepEntrega));
            this.panel2 = new System.Windows.Forms.Panel();
            this.tdbgEntrega = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgEntrega)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tdbgEntrega);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1362, 556);
            this.panel2.TabIndex = 6;
            // 
            // tdbgEntrega
            // 
            this.tdbgEntrega.AllowUpdate = false;
            this.tdbgEntrega.Caption = "REGISTRO DE ENTREGA NAVIDEÑA";
            this.tdbgEntrega.CaptionHeight = 17;
            this.tdbgEntrega.CausesValidation = false;
            this.tdbgEntrega.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveUp;
            this.tdbgEntrega.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tdbgEntrega.EmptyRows = true;
            this.tdbgEntrega.ExtendRightColumn = true;
            this.tdbgEntrega.FilterBar = true;
            this.tdbgEntrega.GroupByCaption = "Drag a column header here to group by that column";
            this.tdbgEntrega.Images.Add(((System.Drawing.Image)(resources.GetObject("tdbgEntrega.Images"))));
            this.tdbgEntrega.Location = new System.Drawing.Point(0, 0);
            this.tdbgEntrega.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.tdbgEntrega.Name = "tdbgEntrega";
            this.tdbgEntrega.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdbgEntrega.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdbgEntrega.PreviewInfo.ZoomFactor = 75D;
            this.tdbgEntrega.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdbgEntrega.PrintInfo.PageSettings")));
            this.tdbgEntrega.RowHeight = 18;
            this.tdbgEntrega.Size = new System.Drawing.Size(1362, 556);
            this.tdbgEntrega.TabIndex = 6;
            this.tdbgEntrega.Text = "Productos Genéricos";
            this.tdbgEntrega.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2007Blue;
            this.tdbgEntrega.DoubleClick += new System.EventHandler(this.tdbgEntrega_DoubleClick);
            this.tdbgEntrega.PropBag = resources.GetString("tdbgEntrega.PropBag");
            // 
            // RepEntrega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "RepEntrega";
            this.Size = new System.Drawing.Size(1362, 581);
            this.RefreshClick += new Halley.Presentacion.UITemplateAccess.delegateRefreshClick(this.RepEntrega_RefreshClick);
            this.ExportClick += new Halley.Presentacion.UITemplateAccess.delegateExportExcel(this.RepEntrega_ExportClick);
            this.Load += new System.EventHandler(this.RepEntrega_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tdbgEntrega)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdbgEntrega;

    }
}
