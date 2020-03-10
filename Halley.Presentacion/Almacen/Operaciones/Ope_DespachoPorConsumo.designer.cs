namespace Halley.Presentacion.Almacen.Operaciones
{
    partial class Ope_DespachoPorConsumo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ope_DespachoPorConsumo));
            this.label2 = new System.Windows.Forms.Label();
            this.CbAlmacen = new C1.Win.C1List.C1Combo();
            this.c1TdgConsumo = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.C1TdbgProducto = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.btnCancelar = new C1.Win.C1Input.C1Button();
            this.btnAceptar = new C1.Win.C1Input.C1Button();
            this.c1NumericEdit1 = new C1.Win.C1Input.C1NumericEdit();
            ((System.ComponentModel.ISupportInitialize)(this.CbAlmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TdgConsumo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.C1TdbgProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1NumericEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 74;
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
            this.CbAlmacen.Location = new System.Drawing.Point(81, 8);
            this.CbAlmacen.MatchEntryTimeout = ((long)(2000));
            this.CbAlmacen.MaxDropDownItems = ((short)(5));
            this.CbAlmacen.MaxLength = 32767;
            this.CbAlmacen.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CbAlmacen.Name = "CbAlmacen";
            this.CbAlmacen.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CbAlmacen.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CbAlmacen.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CbAlmacen.Size = new System.Drawing.Size(248, 23);
            this.CbAlmacen.TabIndex = 73;
            this.CbAlmacen.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.CbAlmacen.SelectedValueChanged += new System.EventHandler(this.CbAlmacen_SelectedValueChanged);
            this.CbAlmacen.PropBag = resources.GetString("CbAlmacen.PropBag");
            // 
            // c1TdgConsumo
            // 
            this.c1TdgConsumo.AllowDelete = true;
            this.c1TdgConsumo.CaptionHeight = 17;
            this.c1TdgConsumo.CausesValidation = false;
            this.c1TdgConsumo.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveUp;
            this.c1TdgConsumo.EmptyRows = true;
            this.c1TdgConsumo.ExtendRightColumn = true;
            this.c1TdgConsumo.GroupByCaption = "Drag a column header here to group by that column";
            this.c1TdgConsumo.Images.Add(((System.Drawing.Image)(resources.GetObject("c1TdgConsumo.Images"))));
            this.c1TdgConsumo.Location = new System.Drawing.Point(21, 384);
            this.c1TdgConsumo.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.c1TdgConsumo.Name = "c1TdgConsumo";
            this.c1TdgConsumo.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.c1TdgConsumo.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.c1TdgConsumo.PreviewInfo.ZoomFactor = 75D;
            this.c1TdgConsumo.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("c1TdgConsumo.PrintInfo.PageSettings")));
            this.c1TdgConsumo.RowHeight = 18;
            this.c1TdgConsumo.Size = new System.Drawing.Size(1335, 217);
            this.c1TdgConsumo.TabIndex = 76;
            this.c1TdgConsumo.Text = "Productos Genéricos";
            this.c1TdgConsumo.AfterDelete += new System.EventHandler(this.c1TdgConsumo_AfterDelete);
            this.c1TdgConsumo.PropBag = resources.GetString("c1TdgConsumo.PropBag");
            // 
            // C1TdbgProducto
            // 
            this.C1TdbgProducto.AllowUpdate = false;
            this.C1TdbgProducto.CaptionHeight = 17;
            this.C1TdbgProducto.CausesValidation = false;
            this.C1TdbgProducto.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveUp;
            this.C1TdbgProducto.EmptyRows = true;
            this.C1TdbgProducto.ExtendRightColumn = true;
            this.C1TdbgProducto.FilterBar = true;
            this.C1TdbgProducto.GroupByCaption = "Drag a column header here to group by that column";
            this.C1TdbgProducto.Images.Add(((System.Drawing.Image)(resources.GetObject("C1TdbgProducto.Images"))));
            this.C1TdbgProducto.Location = new System.Drawing.Point(21, 37);
            this.C1TdbgProducto.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.C1TdbgProducto.Name = "C1TdbgProducto";
            this.C1TdbgProducto.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.C1TdbgProducto.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.C1TdbgProducto.PreviewInfo.ZoomFactor = 75D;
            this.C1TdbgProducto.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("C1TdbgProducto.PrintInfo.PageSettings")));
            this.C1TdbgProducto.RowHeight = 18;
            this.C1TdbgProducto.Size = new System.Drawing.Size(1335, 341);
            this.C1TdbgProducto.TabIndex = 75;
            this.C1TdbgProducto.Text = "Productos Genéricos";
            this.C1TdbgProducto.FetchCellStyle += new C1.Win.C1TrueDBGrid.FetchCellStyleEventHandler(this.C1TdbgProducto_FetchCellStyle);
            this.C1TdbgProducto.DoubleClick += new System.EventHandler(this.C1TdbgProducto_DoubleClick);
            this.C1TdbgProducto.PropBag = resources.GetString("C1TdbgProducto.PropBag");
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = global::Halley.Presentacion.Properties.Resources.Cancelar_16x16;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(1284, 605);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(72, 23);
            this.btnCancelar.TabIndex = 80;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(1207, 605);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(72, 23);
            this.btnAceptar.TabIndex = 79;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // c1NumericEdit1
            // 
            this.c1NumericEdit1.Location = new System.Drawing.Point(1037, 607);
            this.c1NumericEdit1.Name = "c1NumericEdit1";
            this.c1NumericEdit1.Size = new System.Drawing.Size(94, 22);
            this.c1NumericEdit1.TabIndex = 82;
            this.c1NumericEdit1.Tag = null;
            this.c1NumericEdit1.Visible = false;
            this.c1NumericEdit1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None;
            // 
            // Ope_DespachoPorConsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.c1NumericEdit1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.c1TdgConsumo);
            this.Controls.Add(this.C1TdbgProducto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CbAlmacen);
            this.Name = "Ope_DespachoPorConsumo";
            this.Size = new System.Drawing.Size(1371, 664);
            this.Load += new System.EventHandler(this.Ope_DespachoPorConsumo_Load);
            this.Controls.SetChildIndex(this.CbAlmacen, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.C1TdbgProducto, 0);
            this.Controls.SetChildIndex(this.c1TdgConsumo, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.c1NumericEdit1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.CbAlmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TdgConsumo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.C1TdbgProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1NumericEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1TrueDBGrid.C1TrueDBGrid c1TdgConsumo;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid C1TdbgProducto;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1List.C1Combo CbAlmacen;
        private C1.Win.C1Input.C1Button btnCancelar;
        private C1.Win.C1Input.C1Button btnAceptar;
        private C1.Win.C1Input.C1NumericEdit c1NumericEdit1;
    }
}
