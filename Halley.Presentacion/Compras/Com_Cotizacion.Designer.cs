namespace Halley.Presentacion.Compras
{
    partial class Com_Cotizacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Com_Cotizacion));
            this.BtnCotizar = new C1.Win.C1Input.C1Button();
            this.tdbgCotizacion = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.CbProveedor = new C1.Win.C1List.C1Combo();
            this.C1TdbgRequerimiento = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.PdfCotizacion = new C1.C1Pdf.C1PdfDocument();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgCotizacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.C1TdbgRequerimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCotizar
            // 
            this.BtnCotizar.Image = global::Halley.Presentacion.Properties.Resources.money_16x16;
            this.BtnCotizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCotizar.Location = new System.Drawing.Point(402, 268);
            this.BtnCotizar.Name = "BtnCotizar";
            this.BtnCotizar.Size = new System.Drawing.Size(62, 22);
            this.BtnCotizar.TabIndex = 83;
            this.BtnCotizar.Text = "Enviar ";
            this.BtnCotizar.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.BtnCotizar.UseVisualStyleBackColor = true;
            this.BtnCotizar.Click += new System.EventHandler(this.BtnCotizar_Click);
            // 
            // tdbgCotizacion
            // 
            this.tdbgCotizacion.AllowDelete = true;
            this.tdbgCotizacion.AllowUpdate = false;
            this.tdbgCotizacion.CaptionHeight = 17;
            this.tdbgCotizacion.CausesValidation = false;
            this.tdbgCotizacion.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveUp;
            this.tdbgCotizacion.EmptyRows = true;
            this.tdbgCotizacion.ExtendRightColumn = true;
            this.tdbgCotizacion.GroupByCaption = "Drag a column header here to group by that column";
            this.tdbgCotizacion.Images.Add(((System.Drawing.Image)(resources.GetObject("tdbgCotizacion.Images"))));
            this.tdbgCotizacion.Location = new System.Drawing.Point(15, 295);
            this.tdbgCotizacion.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.tdbgCotizacion.Name = "tdbgCotizacion";
            this.tdbgCotizacion.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdbgCotizacion.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdbgCotizacion.PreviewInfo.ZoomFactor = 75D;
            this.tdbgCotizacion.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdbgCotizacion.PrintInfo.PageSettings")));
            this.tdbgCotizacion.RowHeight = 18;
            this.tdbgCotizacion.Size = new System.Drawing.Size(799, 253);
            this.tdbgCotizacion.TabIndex = 82;
            this.tdbgCotizacion.Text = "Productos Genéricos";
            this.tdbgCotizacion.AfterDelete += new System.EventHandler(this.tdbgCotizacion_AfterDelete);
            this.tdbgCotizacion.PropBag = resources.GetString("tdbgCotizacion.PropBag");
            // 
            // CbProveedor
            // 
            this.CbProveedor.AddItemSeparator = ';';
            this.CbProveedor.Caption = "";
            this.CbProveedor.CaptionHeight = 17;
            this.CbProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CbProveedor.ColumnCaptionHeight = 17;
            this.CbProveedor.ColumnFooterHeight = 17;
            this.CbProveedor.ColumnHeaders = false;
            this.CbProveedor.ColumnWidth = 100;
            this.CbProveedor.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.CbProveedor.ContentHeight = 17;
            this.CbProveedor.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CbProveedor.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CbProveedor.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbProveedor.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CbProveedor.EditorHeight = 17;
            this.CbProveedor.ExtendRightColumn = true;
            this.CbProveedor.Images.Add(((System.Drawing.Image)(resources.GetObject("CbProveedor.Images"))));
            this.CbProveedor.ItemHeight = 15;
            this.CbProveedor.Location = new System.Drawing.Point(92, 267);
            this.CbProveedor.MatchEntryTimeout = ((long)(2000));
            this.CbProveedor.MaxDropDownItems = ((short)(5));
            this.CbProveedor.MaxLength = 32767;
            this.CbProveedor.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CbProveedor.Name = "CbProveedor";
            this.CbProveedor.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CbProveedor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CbProveedor.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CbProveedor.Size = new System.Drawing.Size(304, 23);
            this.CbProveedor.TabIndex = 81;
            this.CbProveedor.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.CbProveedor.PropBag = resources.GetString("CbProveedor.PropBag");
            // 
            // C1TdbgRequerimiento
            // 
            this.C1TdbgRequerimiento.AllowUpdate = false;
            this.C1TdbgRequerimiento.CaptionHeight = 17;
            this.C1TdbgRequerimiento.CausesValidation = false;
            this.C1TdbgRequerimiento.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveUp;
            this.C1TdbgRequerimiento.EmptyRows = true;
            this.C1TdbgRequerimiento.ExtendRightColumn = true;
            this.C1TdbgRequerimiento.GroupByCaption = "Drag a column header here to group by that column";
            this.C1TdbgRequerimiento.Images.Add(((System.Drawing.Image)(resources.GetObject("C1TdbgRequerimiento.Images"))));
            this.C1TdbgRequerimiento.Location = new System.Drawing.Point(15, 12);
            this.C1TdbgRequerimiento.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.C1TdbgRequerimiento.Name = "C1TdbgRequerimiento";
            this.C1TdbgRequerimiento.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.C1TdbgRequerimiento.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.C1TdbgRequerimiento.PreviewInfo.ZoomFactor = 75D;
            this.C1TdbgRequerimiento.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("C1TdbgRequerimiento.PrintInfo.PageSettings")));
            this.C1TdbgRequerimiento.RowHeight = 18;
            this.C1TdbgRequerimiento.Size = new System.Drawing.Size(1316, 248);
            this.C1TdbgRequerimiento.TabIndex = 80;
            this.C1TdbgRequerimiento.Text = "Productos Genéricos";
            this.C1TdbgRequerimiento.DoubleClick += new System.EventHandler(this.C1TdbgRequerimiento_DoubleClick);
            this.C1TdbgRequerimiento.PropBag = resources.GetString("C1TdbgRequerimiento.PropBag");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "Proveedor :";
            // 
            // PdfCotizacion
            // 
            this.PdfCotizacion.ImageQuality = C1.C1Pdf.ImageQualityEnum.High;
            // 
            // Com_Cotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCotizar);
            this.Controls.Add(this.tdbgCotizacion);
            this.Controls.Add(this.CbProveedor);
            this.Controls.Add(this.C1TdbgRequerimiento);
            this.Name = "Com_Cotizacion";
            this.Size = new System.Drawing.Size(1366, 573);
            this.Load += new System.EventHandler(this.Com_Cotizacion_Load);
            this.Controls.SetChildIndex(this.C1TdbgRequerimiento, 0);
            this.Controls.SetChildIndex(this.CbProveedor, 0);
            this.Controls.SetChildIndex(this.tdbgCotizacion, 0);
            this.Controls.SetChildIndex(this.BtnCotizar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tdbgCotizacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.C1TdbgRequerimiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1Button BtnCotizar;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdbgCotizacion;
        private C1.Win.C1List.C1Combo CbProveedor;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid C1TdbgRequerimiento;
        private System.Windows.Forms.Label label1;
        private C1.C1Pdf.C1PdfDocument PdfCotizacion;

    }
}
