namespace Halley.Presentacion.Almacen.Reportes
{
    partial class Rep_Stock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rep_Stock));
            this.label2 = new System.Windows.Forms.Label();
            this.CbAlmacen = new C1.Win.C1List.C1Combo();
            this.label1 = new System.Windows.Forms.Label();
            this.CbProducto = new C1.Win.C1List.C1Combo();
            this.btnCancelar = new C1.Win.C1Input.C1Button();
            this.btnAceptar = new C1.Win.C1Input.C1Button();
            this.c1NumericEdit1 = new C1.Win.C1Input.C1NumericEdit();
            this.BtnProducto = new C1.Win.C1Input.C1Button();
            this.BtnMostrar = new C1.Win.C1Input.C1Button();
            this.C1TdbgProducto = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.c1TdgAlmacen = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.C1tdbDetalle = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.TcRequerimientos = new System.Windows.Forms.TabControl();
            this.TpTransferencia = new System.Windows.Forms.TabPage();
            this.TcCompras = new System.Windows.Forms.TabPage();
            this.TdgCompras = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            ((System.ComponentModel.ISupportInitialize)(this.CbAlmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1NumericEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.C1TdbgProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TdgAlmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.C1tdbDetalle)).BeginInit();
            this.TcRequerimientos.SuspendLayout();
            this.TpTransferencia.SuspendLayout();
            this.TcCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TdgCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(803, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 56;
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
            this.CbAlmacen.Location = new System.Drawing.Point(863, 8);
            this.CbAlmacen.MatchEntryTimeout = ((long)(2000));
            this.CbAlmacen.MaxDropDownItems = ((short)(5));
            this.CbAlmacen.MaxLength = 32767;
            this.CbAlmacen.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CbAlmacen.Name = "CbAlmacen";
            this.CbAlmacen.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CbAlmacen.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CbAlmacen.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CbAlmacen.Size = new System.Drawing.Size(248, 23);
            this.CbAlmacen.TabIndex = 55;
            this.CbAlmacen.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.CbAlmacen.PropBag = resources.GetString("CbAlmacen.PropBag");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Producto :";
            // 
            // CbProducto
            // 
            this.CbProducto.AddItemSeparator = ';';
            this.CbProducto.Caption = "";
            this.CbProducto.CaptionHeight = 17;
            this.CbProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CbProducto.ColumnCaptionHeight = 17;
            this.CbProducto.ColumnFooterHeight = 17;
            this.CbProducto.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.CbProducto.ContentHeight = 17;
            this.CbProducto.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CbProducto.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CbProducto.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbProducto.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CbProducto.EditorHeight = 17;
            this.CbProducto.Enabled = false;
            this.CbProducto.ExtendRightColumn = true;
            this.CbProducto.Images.Add(((System.Drawing.Image)(resources.GetObject("CbProducto.Images"))));
            this.CbProducto.ItemHeight = 15;
            this.CbProducto.Location = new System.Drawing.Point(81, 14);
            this.CbProducto.MatchEntryTimeout = ((long)(2000));
            this.CbProducto.MaxDropDownItems = ((short)(5));
            this.CbProducto.MaxLength = 32767;
            this.CbProducto.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CbProducto.Name = "CbProducto";
            this.CbProducto.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CbProducto.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CbProducto.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CbProducto.Size = new System.Drawing.Size(454, 23);
            this.CbProducto.TabIndex = 60;
            this.CbProducto.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.CbProducto.SelectedValueChanged += new System.EventHandler(this.CbProducto_SelectedValueChanged_1);
            this.CbProducto.PropBag = resources.GetString("CbProducto.PropBag");
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::Halley.Presentacion.Properties.Resources.Cancelar_16x16;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(1049, 152);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(72, 23);
            this.btnCancelar.TabIndex = 67;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(971, 152);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(72, 23);
            this.btnAceptar.TabIndex = 66;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // c1NumericEdit1
            // 
            this.c1NumericEdit1.Location = new System.Drawing.Point(799, 125);
            this.c1NumericEdit1.Name = "c1NumericEdit1";
            this.c1NumericEdit1.Size = new System.Drawing.Size(94, 22);
            this.c1NumericEdit1.TabIndex = 68;
            this.c1NumericEdit1.Tag = null;
            this.c1NumericEdit1.Visible = false;
            this.c1NumericEdit1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None;
            // 
            // BtnProducto
            // 
            this.BtnProducto.Image = global::Halley.Presentacion.Properties.Resources.find_16x16;
            this.BtnProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnProducto.Location = new System.Drawing.Point(799, 37);
            this.BtnProducto.Name = "BtnProducto";
            this.BtnProducto.Size = new System.Drawing.Size(113, 23);
            this.BtnProducto.TabIndex = 70;
            this.BtnProducto.Text = "Buscar Producto";
            this.BtnProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnProducto.UseVisualStyleBackColor = true;
            this.BtnProducto.Click += new System.EventHandler(this.BtnProducto_Click_1);
            // 
            // BtnMostrar
            // 
            this.BtnMostrar.Image = global::Halley.Presentacion.Properties.Resources.Egreso16x16;
            this.BtnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMostrar.Location = new System.Drawing.Point(1041, 37);
            this.BtnMostrar.Name = "BtnMostrar";
            this.BtnMostrar.Size = new System.Drawing.Size(70, 22);
            this.BtnMostrar.TabIndex = 71;
            this.BtnMostrar.Text = "Mostrar";
            this.BtnMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnMostrar.UseVisualStyleBackColor = true;
            this.BtnMostrar.Click += new System.EventHandler(this.BtnMostrar_Click);
            // 
            // C1TdbgProducto
            // 
            this.C1TdbgProducto.AllowUpdate = false;
            this.C1TdbgProducto.AlternatingRows = true;
            this.C1TdbgProducto.CaptionHeight = 17;
            this.C1TdbgProducto.EmptyRows = true;
            this.C1TdbgProducto.FilterBar = true;
            this.C1TdbgProducto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C1TdbgProducto.GroupByCaption = "Drag a column header here to group by that column";
            this.C1TdbgProducto.Images.Add(((System.Drawing.Image)(resources.GetObject("C1TdbgProducto.Images"))));
            this.C1TdbgProducto.LinesPerRow = 2;
            this.C1TdbgProducto.Location = new System.Drawing.Point(12, 8);
            this.C1TdbgProducto.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightCell;
            this.C1TdbgProducto.Name = "C1TdbgProducto";
            this.C1TdbgProducto.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.C1TdbgProducto.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.C1TdbgProducto.PreviewInfo.ZoomFactor = 75D;
            this.C1TdbgProducto.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("C1TdbgProducto.PrintInfo.PageSettings")));
            this.C1TdbgProducto.RowHeight = 15;
            this.C1TdbgProducto.Size = new System.Drawing.Size(768, 167);
            this.C1TdbgProducto.TabIndex = 76;
            this.C1TdbgProducto.Text = "c1TrueDBGrid1";
            this.C1TdbgProducto.FetchCellStyle += new C1.Win.C1TrueDBGrid.FetchCellStyleEventHandler(this.C1TdbgProducto_FetchCellStyle);
            this.C1TdbgProducto.DoubleClick += new System.EventHandler(this.C1TdbgProducto_DoubleClick);
            this.C1TdbgProducto.PropBag = resources.GetString("C1TdbgProducto.PropBag");
            // 
            // c1TdgAlmacen
            // 
            this.c1TdgAlmacen.AllowUpdate = false;
            this.c1TdgAlmacen.AlternatingRows = true;
            this.c1TdgAlmacen.CaptionHeight = 17;
            this.c1TdgAlmacen.EmptyRows = true;
            this.c1TdgAlmacen.FilterBar = true;
            this.c1TdgAlmacen.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1TdgAlmacen.GroupByCaption = "Drag a column header here to group by that column";
            this.c1TdgAlmacen.Images.Add(((System.Drawing.Image)(resources.GetObject("c1TdgAlmacen.Images"))));
            this.c1TdgAlmacen.LinesPerRow = 2;
            this.c1TdgAlmacen.Location = new System.Drawing.Point(19, 43);
            this.c1TdgAlmacen.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightCell;
            this.c1TdgAlmacen.Name = "c1TdgAlmacen";
            this.c1TdgAlmacen.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.c1TdgAlmacen.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.c1TdgAlmacen.PreviewInfo.ZoomFactor = 75D;
            this.c1TdgAlmacen.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("c1TdgAlmacen.PrintInfo.PageSettings")));
            this.c1TdgAlmacen.RowHeight = 15;
            this.c1TdgAlmacen.Size = new System.Drawing.Size(1019, 167);
            this.c1TdgAlmacen.TabIndex = 77;
            this.c1TdgAlmacen.Text = "c1TrueDBGrid1";
            this.c1TdgAlmacen.FetchCellStyle += new C1.Win.C1TrueDBGrid.FetchCellStyleEventHandler(this.c1TdgAlmacen_FetchCellStyle);
            this.c1TdgAlmacen.DoubleClick += new System.EventHandler(this.c1TdgAlmacen_DoubleClick);
            this.c1TdgAlmacen.PropBag = resources.GetString("c1TdgAlmacen.PropBag");
            // 
            // C1tdbDetalle
            // 
            this.C1tdbDetalle.AllowDelete = true;
            this.C1tdbDetalle.AlternatingRows = true;
            this.C1tdbDetalle.CaptionHeight = 17;
            this.C1tdbDetalle.EmptyRows = true;
            this.C1tdbDetalle.FilterBar = true;
            this.C1tdbDetalle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C1tdbDetalle.GroupByCaption = "Drag a column header here to group by that column";
            this.C1tdbDetalle.Images.Add(((System.Drawing.Image)(resources.GetObject("C1tdbDetalle.Images"))));
            this.C1tdbDetalle.LinesPerRow = 2;
            this.C1tdbDetalle.Location = new System.Drawing.Point(20, 216);
            this.C1tdbDetalle.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightCell;
            this.C1tdbDetalle.Name = "C1tdbDetalle";
            this.C1tdbDetalle.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.C1tdbDetalle.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.C1tdbDetalle.PreviewInfo.ZoomFactor = 75D;
            this.C1tdbDetalle.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("C1tdbDetalle.PrintInfo.PageSettings")));
            this.C1tdbDetalle.RowHeight = 15;
            this.C1tdbDetalle.Size = new System.Drawing.Size(1018, 181);
            this.C1tdbDetalle.TabIndex = 78;
            this.C1tdbDetalle.Text = "c1TrueDBGrid1";
            this.C1tdbDetalle.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.C1tdbDetalle_AfterColUpdate);
            this.C1tdbDetalle.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.C1tdbDetalle_BeforeColUpdate);
            this.C1tdbDetalle.PropBag = resources.GetString("C1tdbDetalle.PropBag");
            // 
            // TcRequerimientos
            // 
            this.TcRequerimientos.Controls.Add(this.TpTransferencia);
            this.TcRequerimientos.Controls.Add(this.TcCompras);
            this.TcRequerimientos.Location = new System.Drawing.Point(12, 181);
            this.TcRequerimientos.Name = "TcRequerimientos";
            this.TcRequerimientos.SelectedIndex = 0;
            this.TcRequerimientos.Size = new System.Drawing.Size(1109, 429);
            this.TcRequerimientos.TabIndex = 79;
            this.TcRequerimientos.SelectedIndexChanged += new System.EventHandler(this.TcRequerimientos_SelectedIndexChanged);
            // 
            // TpTransferencia
            // 
            this.TpTransferencia.Controls.Add(this.CbProducto);
            this.TpTransferencia.Controls.Add(this.c1TdgAlmacen);
            this.TpTransferencia.Controls.Add(this.label1);
            this.TpTransferencia.Controls.Add(this.C1tdbDetalle);
            this.TpTransferencia.Location = new System.Drawing.Point(4, 22);
            this.TpTransferencia.Name = "TpTransferencia";
            this.TpTransferencia.Padding = new System.Windows.Forms.Padding(3);
            this.TpTransferencia.Size = new System.Drawing.Size(1101, 403);
            this.TpTransferencia.TabIndex = 0;
            this.TpTransferencia.Text = "TRANSFERENCIA";
            this.TpTransferencia.UseVisualStyleBackColor = true;
            // 
            // TcCompras
            // 
            this.TcCompras.Controls.Add(this.TdgCompras);
            this.TcCompras.Location = new System.Drawing.Point(4, 22);
            this.TcCompras.Name = "TcCompras";
            this.TcCompras.Padding = new System.Windows.Forms.Padding(3);
            this.TcCompras.Size = new System.Drawing.Size(1101, 403);
            this.TcCompras.TabIndex = 1;
            this.TcCompras.Text = "COMPRAS";
            this.TcCompras.UseVisualStyleBackColor = true;
            // 
            // TdgCompras
            // 
            this.TdgCompras.AlternatingRows = true;
            this.TdgCompras.CaptionHeight = 17;
            this.TdgCompras.EmptyRows = true;
            this.TdgCompras.FilterBar = true;
            this.TdgCompras.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TdgCompras.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgCompras.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgCompras.Images"))));
            this.TdgCompras.LinesPerRow = 2;
            this.TdgCompras.Location = new System.Drawing.Point(6, 6);
            this.TdgCompras.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightCell;
            this.TdgCompras.Name = "TdgCompras";
            this.TdgCompras.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgCompras.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgCompras.PreviewInfo.ZoomFactor = 75D;
            this.TdgCompras.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgCompras.PrintInfo.PageSettings")));
            this.TdgCompras.RowHeight = 15;
            this.TdgCompras.Size = new System.Drawing.Size(1089, 391);
            this.TdgCompras.TabIndex = 79;
            this.TdgCompras.Text = "c1TrueDBGrid1";
            this.TdgCompras.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.TdgCompras_AfterColUpdate);
            this.TdgCompras.PropBag = resources.GetString("TdgCompras.PropBag");
            // 
            // Rep_Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TcRequerimientos);
            this.Controls.Add(this.C1TdbgProducto);
            this.Controls.Add(this.BtnMostrar);
            this.Controls.Add(this.BtnProducto);
            this.Controls.Add(this.c1NumericEdit1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CbAlmacen);
            this.Name = "Rep_Stock";
            this.Size = new System.Drawing.Size(1472, 739);
            this.Load += new System.EventHandler(this.Stock_Load);
            this.Controls.SetChildIndex(this.CbAlmacen, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.c1NumericEdit1, 0);
            this.Controls.SetChildIndex(this.BtnProducto, 0);
            this.Controls.SetChildIndex(this.BtnMostrar, 0);
            this.Controls.SetChildIndex(this.C1TdbgProducto, 0);
            this.Controls.SetChildIndex(this.TcRequerimientos, 0);
            ((System.ComponentModel.ISupportInitialize)(this.CbAlmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1NumericEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.C1TdbgProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TdgAlmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.C1tdbDetalle)).EndInit();
            this.TcRequerimientos.ResumeLayout(false);
            this.TpTransferencia.ResumeLayout(false);
            this.TpTransferencia.PerformLayout();
            this.TcCompras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TdgCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private C1.Win.C1List.C1Combo CbAlmacen;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1List.C1Combo CbProducto;
        private C1.Win.C1Input.C1Button btnCancelar;
        private C1.Win.C1Input.C1Button btnAceptar;
        private C1.Win.C1Input.C1NumericEdit c1NumericEdit1;
        private C1.Win.C1Input.C1Button BtnProducto;
        private C1.Win.C1Input.C1Button BtnMostrar;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid C1TdbgProducto;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid c1TdgAlmacen;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid C1tdbDetalle;
        private System.Windows.Forms.TabControl TcRequerimientos;
        private System.Windows.Forms.TabPage TpTransferencia;
        private System.Windows.Forms.TabPage TcCompras;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgCompras;




    }
}
