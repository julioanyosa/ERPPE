namespace Halley.Presentacion.Almacen.Reportes
{
    partial class Rep_Producto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rep_Producto));
            this.C1TdbgProducto = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            ((System.ComponentModel.ISupportInitialize)(this.C1TdbgProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // C1TdbgProducto
            // 
            this.C1TdbgProducto.AllowUpdate = false;
            this.C1TdbgProducto.CaptionHeight = 17;
            this.C1TdbgProducto.CausesValidation = false;
            this.C1TdbgProducto.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveUp;
            this.C1TdbgProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.C1TdbgProducto.EmptyRows = true;
            this.C1TdbgProducto.ExtendRightColumn = true;
            this.C1TdbgProducto.FilterBar = true;
            this.C1TdbgProducto.GroupByCaption = "Drag a column header here to group by that column";
            this.C1TdbgProducto.Images.Add(((System.Drawing.Image)(resources.GetObject("C1TdbgProducto.Images"))));
            this.C1TdbgProducto.Location = new System.Drawing.Point(0, 0);
            this.C1TdbgProducto.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.C1TdbgProducto.Name = "C1TdbgProducto";
            this.C1TdbgProducto.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.C1TdbgProducto.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.C1TdbgProducto.PreviewInfo.ZoomFactor = 75D;
            this.C1TdbgProducto.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("C1TdbgProducto.PrintInfo.PageSettings")));
            this.C1TdbgProducto.RowHeight = 18;
            this.C1TdbgProducto.Size = new System.Drawing.Size(746, 434);
            this.C1TdbgProducto.TabIndex = 55;
            this.C1TdbgProducto.Text = "Productos Genéricos";
            this.C1TdbgProducto.DoubleClick += new System.EventHandler(this.C1TdbgProducto_DoubleClick);
            this.C1TdbgProducto.PropBag = resources.GetString("C1TdbgProducto.PropBag");
            // 
            // Rep_Producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 434);
            this.Controls.Add(this.C1TdbgProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Rep_Producto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Producto";
            ((System.ComponentModel.ISupportInitialize)(this.C1TdbgProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1TrueDBGrid.C1TrueDBGrid C1TdbgProducto;
    }
}