namespace Halley.Presentacion.Ventas.ReporteNavideño
{
    partial class RepStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepStock));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.CbAlmacen = new C1.Win.C1List.C1Combo();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tdbgStock = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CbAlmacen)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgStock)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CbAlmacen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 44);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Almacen :";
            // 
            // CbAlmacen
            // 
            this.CbAlmacen.AddItemSeparator = ';';
            this.CbAlmacen.Caption = "";
            this.CbAlmacen.CaptionHeight = 17;
            this.CbAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CbAlmacen.ColumnCaptionHeight = 17;
            this.CbAlmacen.ColumnFooterHeight = 17;
            this.CbAlmacen.ColumnHeaders = false;
            this.CbAlmacen.ColumnWidth = 100;
            this.CbAlmacen.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.CbAlmacen.ContentHeight = 17;
            this.CbAlmacen.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CbAlmacen.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CbAlmacen.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbAlmacen.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CbAlmacen.EditorHeight = 17;
            this.CbAlmacen.ExtendRightColumn = true;
            this.CbAlmacen.Images.Add(((System.Drawing.Image)(resources.GetObject("CbAlmacen.Images"))));
            this.CbAlmacen.ItemHeight = 15;
            this.CbAlmacen.Location = new System.Drawing.Point(78, 12);
            this.CbAlmacen.MatchEntryTimeout = ((long)(2000));
            this.CbAlmacen.MaxDropDownItems = ((short)(5));
            this.CbAlmacen.MaxLength = 32767;
            this.CbAlmacen.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CbAlmacen.Name = "CbAlmacen";
            this.CbAlmacen.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CbAlmacen.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CbAlmacen.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CbAlmacen.Size = new System.Drawing.Size(248, 23);
            this.CbAlmacen.TabIndex = 59;
            this.CbAlmacen.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.CbAlmacen.PropBag = resources.GetString("CbAlmacen.PropBag");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tdbgStock);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(796, 235);
            this.panel2.TabIndex = 1;
            // 
            // tdbgStock
            // 
            this.tdbgStock.AllowUpdate = false;
            this.tdbgStock.CaptionHeight = 17;
            this.tdbgStock.CausesValidation = false;
            this.tdbgStock.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveUp;
            this.tdbgStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tdbgStock.EmptyRows = true;
            this.tdbgStock.ExtendRightColumn = true;
            this.tdbgStock.GroupByCaption = "Drag a column header here to group by that column";
            this.tdbgStock.Images.Add(((System.Drawing.Image)(resources.GetObject("tdbgStock.Images"))));
            this.tdbgStock.Location = new System.Drawing.Point(0, 0);
            this.tdbgStock.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.tdbgStock.Name = "tdbgStock";
            this.tdbgStock.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdbgStock.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdbgStock.PreviewInfo.ZoomFactor = 75D;
            this.tdbgStock.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdbgStock.PrintInfo.PageSettings")));
            this.tdbgStock.RowHeight = 18;
            this.tdbgStock.Size = new System.Drawing.Size(796, 235);
            this.tdbgStock.TabIndex = 2;
            this.tdbgStock.Text = "Productos Genéricos";
            this.tdbgStock.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2007Blue;
            this.tdbgStock.PropBag = resources.GetString("tdbgStock.PropBag");
            // 
            // RepStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 279);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RepStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock de Productos Navideños";
            this.Load += new System.EventHandler(this.RepStock_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CbAlmacen)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tdbgStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdbgStock;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1List.C1Combo CbAlmacen;
    }
}