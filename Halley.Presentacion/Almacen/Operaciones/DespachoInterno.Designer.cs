namespace Halley.Presentacion.Almacen.Operaciones
{
    partial class DespachoInterno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DespachoInterno));
            this.label2 = new System.Windows.Forms.Label();
            this.CbAlmacen = new C1.Win.C1List.C1Combo();
            this.tdgDespachoInterno = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.BtnDespachar = new C1.Win.C1Input.C1Button();
            this.BtnVer = new C1.Win.C1Input.C1Button();
            this.ChkSeleccionarTodo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.CbAlmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdgDespachoInterno)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 29);
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
            this.CbAlmacen.Location = new System.Drawing.Point(87, 25);
            this.CbAlmacen.MatchEntryTimeout = ((long)(2000));
            this.CbAlmacen.MaxDropDownItems = ((short)(5));
            this.CbAlmacen.MaxLength = 32767;
            this.CbAlmacen.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CbAlmacen.Name = "CbAlmacen";
            this.CbAlmacen.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CbAlmacen.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CbAlmacen.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CbAlmacen.Size = new System.Drawing.Size(323, 23);
            this.CbAlmacen.TabIndex = 57;
            this.CbAlmacen.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.CbAlmacen.SelectedValueChanged += new System.EventHandler(this.CbAlmacen_SelectedValueChanged);
            this.CbAlmacen.PropBag = resources.GetString("CbAlmacen.PropBag");
            // 
            // tdgDespachoInterno
            // 
            this.tdgDespachoInterno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tdgDespachoInterno.CaptionHeight = 17;
            this.tdgDespachoInterno.EmptyRows = true;
            this.tdgDespachoInterno.GroupByCaption = "Drag a column header here to group by that column";
            this.tdgDespachoInterno.Images.Add(((System.Drawing.Image)(resources.GetObject("tdgDespachoInterno.Images"))));
            this.tdgDespachoInterno.Location = new System.Drawing.Point(30, 63);
            this.tdgDespachoInterno.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell;
            this.tdgDespachoInterno.Name = "tdgDespachoInterno";
            this.tdgDespachoInterno.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdgDespachoInterno.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdgDespachoInterno.PreviewInfo.ZoomFactor = 75D;
            this.tdgDespachoInterno.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdgDespachoInterno.PrintInfo.PageSettings")));
            this.tdgDespachoInterno.RowHeight = 18;
            this.tdgDespachoInterno.Size = new System.Drawing.Size(990, 360);
            this.tdgDespachoInterno.TabIndex = 59;
            this.tdgDespachoInterno.Text = "c1TrueDBGrid1";
            this.tdgDespachoInterno.PropBag = resources.GetString("tdgDespachoInterno.PropBag");
            // 
            // BtnDespachar
            // 
            this.BtnDespachar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.BtnDespachar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDespachar.Location = new System.Drawing.Point(1026, 63);
            this.BtnDespachar.Name = "BtnDespachar";
            this.BtnDespachar.Size = new System.Drawing.Size(82, 23);
            this.BtnDespachar.TabIndex = 355;
            this.BtnDespachar.Text = "Despachar";
            this.BtnDespachar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDespachar.UseVisualStyleBackColor = true;
            this.BtnDespachar.Click += new System.EventHandler(this.BtnDespachar_Click);
            // 
            // BtnVer
            // 
            this.BtnVer.Image = global::Halley.Presentacion.Properties.Resources.printView_16x16;
            this.BtnVer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnVer.Location = new System.Drawing.Point(1026, 92);
            this.BtnVer.Name = "BtnVer";
            this.BtnVer.Size = new System.Drawing.Size(82, 24);
            this.BtnVer.TabIndex = 356;
            this.BtnVer.Text = "Ver";
            this.BtnVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnVer.UseVisualStyleBackColor = true;
            this.BtnVer.Click += new System.EventHandler(this.BtnVer_Click);
            // 
            // ChkSeleccionarTodo
            // 
            this.ChkSeleccionarTodo.AutoSize = true;
            this.ChkSeleccionarTodo.Location = new System.Drawing.Point(908, 40);
            this.ChkSeleccionarTodo.Name = "ChkSeleccionarTodo";
            this.ChkSeleccionarTodo.Size = new System.Drawing.Size(112, 17);
            this.ChkSeleccionarTodo.TabIndex = 357;
            this.ChkSeleccionarTodo.Text = "Seleccionar todo";
            this.ChkSeleccionarTodo.UseVisualStyleBackColor = true;
            this.ChkSeleccionarTodo.CheckedChanged += new System.EventHandler(this.ChkSeleccionarTodo_CheckedChanged);
            // 
            // DespachoInterno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ChkSeleccionarTodo);
            this.Controls.Add(this.BtnVer);
            this.Controls.Add(this.BtnDespachar);
            this.Controls.Add(this.tdgDespachoInterno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CbAlmacen);
            this.Name = "DespachoInterno";
            this.Size = new System.Drawing.Size(1143, 451);
            this.Load += new System.EventHandler(this.DespachoInterno_Load);
            this.Controls.SetChildIndex(this.CbAlmacen, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tdgDespachoInterno, 0);
            this.Controls.SetChildIndex(this.BtnDespachar, 0);
            this.Controls.SetChildIndex(this.BtnVer, 0);
            this.Controls.SetChildIndex(this.ChkSeleccionarTodo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.CbAlmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdgDespachoInterno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private C1.Win.C1List.C1Combo CbAlmacen;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdgDespachoInterno;
        private C1.Win.C1Input.C1Button BtnDespachar;
        private C1.Win.C1Input.C1Button BtnVer;
        private System.Windows.Forms.CheckBox ChkSeleccionarTodo;
    }
}
