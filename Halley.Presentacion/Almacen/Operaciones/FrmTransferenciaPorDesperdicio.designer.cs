namespace Halley.Presentacion.Almacen.Operaciones
{
    partial class FrmTransferenciaPorDesperdicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTransferenciaPorDesperdicio));
            this.label2 = new System.Windows.Forms.Label();
            this.CbAlmacen = new C1.Win.C1List.C1Combo();
            this.C1TdbgProducto = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.btnCancelar = new C1.Win.C1Input.C1Button();
            this.btnAceptar = new C1.Win.C1Input.C1Button();
            this.C1TdbgSalida = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.CbDesperdicio = new C1.Win.C1List.C1Combo();
            this.c1NumericEdit1 = new C1.Win.C1Input.C1NumericEdit();
            ((System.ComponentModel.ISupportInitialize)(this.CbAlmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.C1TdbgProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.C1TdbgSalida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbDesperdicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1NumericEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 58;
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
            this.CbAlmacen.Location = new System.Drawing.Point(94, 13);
            this.CbAlmacen.MatchEntryTimeout = ((long)(2000));
            this.CbAlmacen.MaxDropDownItems = ((short)(5));
            this.CbAlmacen.MaxLength = 32767;
            this.CbAlmacen.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CbAlmacen.Name = "CbAlmacen";
            this.CbAlmacen.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CbAlmacen.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CbAlmacen.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CbAlmacen.Size = new System.Drawing.Size(276, 23);
            this.CbAlmacen.TabIndex = 57;
            this.CbAlmacen.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.CbAlmacen.SelectedValueChanged += new System.EventHandler(this.CbAlmacen_SelectedValueChanged);
            this.CbAlmacen.PropBag = resources.GetString("CbAlmacen.PropBag");
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
            this.C1TdbgProducto.Location = new System.Drawing.Point(17, 42);
            this.C1TdbgProducto.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.C1TdbgProducto.Name = "C1TdbgProducto";
            this.C1TdbgProducto.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.C1TdbgProducto.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.C1TdbgProducto.PreviewInfo.ZoomFactor = 75D;
            this.C1TdbgProducto.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("C1TdbgProducto.PrintInfo.PageSettings")));
            this.C1TdbgProducto.RowHeight = 18;
            this.C1TdbgProducto.Size = new System.Drawing.Size(1202, 348);
            this.C1TdbgProducto.TabIndex = 59;
            this.C1TdbgProducto.Text = "Productos Genéricos";
            this.C1TdbgProducto.DoubleClick += new System.EventHandler(this.C1TdbgProducto_DoubleClick);
            this.C1TdbgProducto.PropBag = resources.GetString("C1TdbgProducto.PropBag");
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = global::Halley.Presentacion.Properties.Resources.Cancelar_16x16;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(1147, 620);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(72, 23);
            this.btnCancelar.TabIndex = 69;
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
            this.btnAceptar.Location = new System.Drawing.Point(1069, 620);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(72, 23);
            this.btnAceptar.TabIndex = 68;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // C1TdbgSalida
            // 
            this.C1TdbgSalida.AllowDelete = true;
            this.C1TdbgSalida.CaptionHeight = 17;
            this.C1TdbgSalida.CausesValidation = false;
            this.C1TdbgSalida.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveUp;
            this.C1TdbgSalida.EmptyRows = true;
            this.C1TdbgSalida.ExtendRightColumn = true;
            this.C1TdbgSalida.GroupByCaption = "Drag a column header here to group by that column";
            this.C1TdbgSalida.Images.Add(((System.Drawing.Image)(resources.GetObject("C1TdbgSalida.Images"))));
            this.C1TdbgSalida.Location = new System.Drawing.Point(17, 425);
            this.C1TdbgSalida.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.C1TdbgSalida.Name = "C1TdbgSalida";
            this.C1TdbgSalida.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.C1TdbgSalida.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.C1TdbgSalida.PreviewInfo.ZoomFactor = 75D;
            this.C1TdbgSalida.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("C1TdbgSalida.PrintInfo.PageSettings")));
            this.C1TdbgSalida.RowHeight = 18;
            this.C1TdbgSalida.Size = new System.Drawing.Size(1202, 189);
            this.C1TdbgSalida.TabIndex = 72;
            this.C1TdbgSalida.Text = "Productos Genéricos";
            this.C1TdbgSalida.AfterDelete += new System.EventHandler(this.C1TdbgSalida_AfterDelete);
            this.C1TdbgSalida.PropBag = resources.GetString("C1TdbgSalida.PropBag");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "Desperdicio :";
            // 
            // CbDesperdicio
            // 
            this.CbDesperdicio.AddItemSeparator = ';';
            this.CbDesperdicio.Caption = "";
            this.CbDesperdicio.CaptionHeight = 17;
            this.CbDesperdicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CbDesperdicio.ColumnCaptionHeight = 17;
            this.CbDesperdicio.ColumnFooterHeight = 17;
            this.CbDesperdicio.ColumnHeaders = false;
            this.CbDesperdicio.ColumnWidth = 100;
            this.CbDesperdicio.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.CbDesperdicio.ContentHeight = 17;
            this.CbDesperdicio.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CbDesperdicio.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CbDesperdicio.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbDesperdicio.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CbDesperdicio.EditorHeight = 17;
            this.CbDesperdicio.ExtendRightColumn = true;
            this.CbDesperdicio.Images.Add(((System.Drawing.Image)(resources.GetObject("CbDesperdicio.Images"))));
            this.CbDesperdicio.ItemHeight = 15;
            this.CbDesperdicio.Location = new System.Drawing.Point(94, 396);
            this.CbDesperdicio.MatchEntryTimeout = ((long)(2000));
            this.CbDesperdicio.MaxDropDownItems = ((short)(5));
            this.CbDesperdicio.MaxLength = 32767;
            this.CbDesperdicio.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CbDesperdicio.Name = "CbDesperdicio";
            this.CbDesperdicio.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CbDesperdicio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CbDesperdicio.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CbDesperdicio.Size = new System.Drawing.Size(276, 23);
            this.CbDesperdicio.TabIndex = 79;
            this.CbDesperdicio.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.CbDesperdicio.PropBag = resources.GetString("CbDesperdicio.PropBag");
            // 
            // c1NumericEdit1
            // 
            this.c1NumericEdit1.Location = new System.Drawing.Point(405, 396);
            this.c1NumericEdit1.Name = "c1NumericEdit1";
            this.c1NumericEdit1.Size = new System.Drawing.Size(94, 22);
            this.c1NumericEdit1.TabIndex = 81;
            this.c1NumericEdit1.Tag = null;
            this.c1NumericEdit1.Visible = false;
            this.c1NumericEdit1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None;
            // 
            // FrmTransferenciaPorDesperdicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.c1NumericEdit1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbDesperdicio);
            this.Controls.Add(this.C1TdbgSalida);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.C1TdbgProducto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CbAlmacen);
            this.Name = "FrmTransferenciaPorDesperdicio";
            this.Size = new System.Drawing.Size(1297, 682);
            this.Load += new System.EventHandler(this.FrmDespachoPorDesperdicio_Load);
            this.Controls.SetChildIndex(this.CbAlmacen, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.C1TdbgProducto, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.C1TdbgSalida, 0);
            this.Controls.SetChildIndex(this.CbDesperdicio, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.c1NumericEdit1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.CbAlmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.C1TdbgProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.C1TdbgSalida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbDesperdicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1NumericEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private C1.Win.C1List.C1Combo CbAlmacen;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid C1TdbgProducto;
        private C1.Win.C1Input.C1Button btnCancelar;
        private C1.Win.C1Input.C1Button btnAceptar;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid C1TdbgSalida;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1List.C1Combo CbDesperdicio;
        private C1.Win.C1Input.C1NumericEdit c1NumericEdit1;
    }
}
