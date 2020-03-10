namespace Halley.Presentacion.Almacen.Reportes
{
    partial class RequerimientosEstado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequerimientosEstado));
            this.TdgEstadoRequerimientos = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.btnGenerar = new C1.Win.C1Input.C1Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboFechaFin = new C1.Win.C1Input.C1DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.cboFechaInicio = new C1.Win.C1Input.C1DateEdit();
            this.ChkCabecera = new System.Windows.Forms.CheckBox();
            this.TdgDetalleGuias = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.BtnAnular = new C1.Win.C1Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)(this.TdgEstadoRequerimientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgDetalleGuias)).BeginInit();
            this.SuspendLayout();
            // 
            // TdgEstadoRequerimientos
            // 
            this.TdgEstadoRequerimientos.AllowUpdate = false;
            this.TdgEstadoRequerimientos.CaptionHeight = 19;
            this.TdgEstadoRequerimientos.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy;
            this.TdgEstadoRequerimientos.EmptyRows = true;
            this.TdgEstadoRequerimientos.FilterBar = true;
            this.TdgEstadoRequerimientos.GroupByAreaVisible = false;
            this.TdgEstadoRequerimientos.GroupByCaption = "Arrastre la cabecera de columna para agrupar";
            this.TdgEstadoRequerimientos.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgEstadoRequerimientos.Images"))));
            this.TdgEstadoRequerimientos.LinesPerRow = 2;
            this.TdgEstadoRequerimientos.Location = new System.Drawing.Point(29, 53);
            this.TdgEstadoRequerimientos.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgEstadoRequerimientos.Name = "TdgEstadoRequerimientos";
            this.TdgEstadoRequerimientos.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgEstadoRequerimientos.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgEstadoRequerimientos.PreviewInfo.ZoomFactor = 75D;
            this.TdgEstadoRequerimientos.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgEstadoRequerimientos.PrintInfo.PageSettings")));
            this.TdgEstadoRequerimientos.RowHeight = 18;
            this.TdgEstadoRequerimientos.Size = new System.Drawing.Size(1178, 295);
            this.TdgEstadoRequerimientos.TabIndex = 17;
            this.TdgEstadoRequerimientos.TabStop = false;
            this.TdgEstadoRequerimientos.Text = "c1TrueDBGrid1";
            this.TdgEstadoRequerimientos.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.TdgEstadoRequerimientos_RowColChange);
            this.TdgEstadoRequerimientos.FetchCellStyle += new C1.Win.C1TrueDBGrid.FetchCellStyleEventHandler(this.TdgEstadoRequerimientos_FetchCellStyle);
            this.TdgEstadoRequerimientos.PropBag = resources.GetString("TdgEstadoRequerimientos.PropBag");
            // 
            // btnGenerar
            // 
            this.btnGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerar.Image")));
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(525, 15);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(82, 23);
            this.btnGenerar.TabIndex = 237;
            this.btnGenerar.Text = "Consultar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 236;
            this.label2.Text = "Fecha Fin:";
            // 
            // cboFechaFin
            // 
            // 
            // 
            // 
            this.cboFechaFin.Calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFechaFin.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.cboFechaFin.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
                        | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.cboFechaFin.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.cboFechaFin.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
                        | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.cboFechaFin.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDateShortTime;
            this.cboFechaFin.Location = new System.Drawing.Point(373, 15);
            this.cboFechaFin.Name = "cboFechaFin";
            this.cboFechaFin.Size = new System.Drawing.Size(146, 22);
            this.cboFechaFin.TabIndex = 235;
            this.cboFechaFin.Tag = null;
            this.cboFechaFin.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 234;
            this.label1.Text = "Fecha Inicio:";
            // 
            // cboFechaInicio
            // 
            // 
            // 
            // 
            this.cboFechaInicio.Calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFechaInicio.Culture = 10250;
            this.cboFechaInicio.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.cboFechaInicio.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
                        | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.cboFechaInicio.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.cboFechaInicio.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
                        | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.cboFechaInicio.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDateShortTime;
            this.cboFechaInicio.Location = new System.Drawing.Point(103, 15);
            this.cboFechaInicio.Name = "cboFechaInicio";
            this.cboFechaInicio.Size = new System.Drawing.Size(146, 22);
            this.cboFechaInicio.TabIndex = 233;
            this.cboFechaInicio.Tag = null;
            this.cboFechaInicio.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown;
            // 
            // ChkCabecera
            // 
            this.ChkCabecera.AutoSize = true;
            this.ChkCabecera.Location = new System.Drawing.Point(635, 18);
            this.ChkCabecera.Name = "ChkCabecera";
            this.ChkCabecera.Size = new System.Drawing.Size(91, 17);
            this.ChkCabecera.TabIndex = 238;
            this.ChkCabecera.Text = "Ver cabecera";
            this.ChkCabecera.UseVisualStyleBackColor = true;
            this.ChkCabecera.CheckedChanged += new System.EventHandler(this.ChkCabecera_CheckedChanged);
            // 
            // TdgDetalleGuias
            // 
            this.TdgDetalleGuias.AllowUpdate = false;
            this.TdgDetalleGuias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.TdgDetalleGuias.CaptionHeight = 19;
            this.TdgDetalleGuias.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.MultipleLines;
            this.TdgDetalleGuias.EmptyRows = true;
            this.TdgDetalleGuias.GroupByAreaVisible = false;
            this.TdgDetalleGuias.GroupByCaption = "Arrastre la cabecera de columna para agrupar";
            this.TdgDetalleGuias.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgDetalleGuias.Images"))));
            this.TdgDetalleGuias.LinesPerRow = 1;
            this.TdgDetalleGuias.Location = new System.Drawing.Point(29, 354);
            this.TdgDetalleGuias.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgDetalleGuias.Name = "TdgDetalleGuias";
            this.TdgDetalleGuias.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgDetalleGuias.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgDetalleGuias.PreviewInfo.ZoomFactor = 75D;
            this.TdgDetalleGuias.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgDetalleGuias.PrintInfo.PageSettings")));
            this.TdgDetalleGuias.RowHeight = 18;
            this.TdgDetalleGuias.Size = new System.Drawing.Size(1178, 189);
            this.TdgDetalleGuias.TabIndex = 17;
            this.TdgDetalleGuias.TabStop = false;
            this.TdgDetalleGuias.Text = "c1TrueDBGrid1";
            this.TdgDetalleGuias.FetchCellStyle += new C1.Win.C1TrueDBGrid.FetchCellStyleEventHandler(this.TdgEstadoRequerimientos_FetchCellStyle);
            this.TdgDetalleGuias.PropBag = resources.GetString("TdgDetalleGuias.PropBag");
            // 
            // BtnAnular
            // 
            this.BtnAnular.Image = ((System.Drawing.Image)(resources.GetObject("BtnAnular.Image")));
            this.BtnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAnular.Location = new System.Drawing.Point(1125, 18);
            this.BtnAnular.Name = "BtnAnular";
            this.BtnAnular.Size = new System.Drawing.Size(82, 23);
            this.BtnAnular.TabIndex = 241;
            this.BtnAnular.Text = "Anular";
            this.BtnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAnular.UseVisualStyleBackColor = true;
            this.BtnAnular.Click += new System.EventHandler(this.BtnAnular_Click);
            // 
            // RequerimientosEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TdgEstadoRequerimientos);
            this.Controls.Add(this.BtnAnular);
            this.Controls.Add(this.ChkCabecera);
            this.Controls.Add(this.TdgDetalleGuias);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboFechaFin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboFechaInicio);
            this.Name = "RequerimientosEstado";
            this.Size = new System.Drawing.Size(1323, 571);
            this.Load += new System.EventHandler(this.RequerimientosEstado_Load);
            this.Controls.SetChildIndex(this.cboFechaInicio, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboFechaFin, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnGenerar, 0);
            this.Controls.SetChildIndex(this.TdgDetalleGuias, 0);
            this.Controls.SetChildIndex(this.ChkCabecera, 0);
            this.Controls.SetChildIndex(this.BtnAnular, 0);
            this.Controls.SetChildIndex(this.TdgEstadoRequerimientos, 0);
            ((System.ComponentModel.ISupportInitialize)(this.TdgEstadoRequerimientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgDetalleGuias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgEstadoRequerimientos;
        private C1.Win.C1Input.C1Button btnGenerar;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1DateEdit cboFechaFin;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1DateEdit cboFechaInicio;
        private System.Windows.Forms.CheckBox ChkCabecera;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgDetalleGuias;
        private C1.Win.C1Input.C1Button BtnAnular;
    }
}
