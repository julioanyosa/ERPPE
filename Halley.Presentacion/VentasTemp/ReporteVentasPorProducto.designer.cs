namespace Halley.Presentacion.VentasTemp
{
    partial class ReporteVentasPorProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteVentasPorProducto));
            this.CrvResumenVentas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerar = new C1.Win.C1Input.C1Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboFechaFin = new C1.Win.C1Input.C1DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.cboFechaInicio = new C1.Win.C1Input.C1DateEdit();
            this.CboCaja = new C1.Win.C1List.C1Combo();
            this.label7 = new System.Windows.Forms.Label();
            this.TcSeleccion = new System.Windows.Forms.TabControl();
            this.TpVendedor = new System.Windows.Forms.TabPage();
            this.CboVendedores = new C1.Win.C1List.C1Combo();
            this.TpCaja = new System.Windows.Forms.TabPage();
            this.CboTipoComprobante = new C1.Win.C1List.C1Combo();
            this.label4 = new System.Windows.Forms.Label();
            this.CboProductosCodigo = new C1.Win.C1List.C1Combo();
            this.CboProductos = new C1.Win.C1List.C1Combo();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboCaja)).BeginInit();
            this.TcSeleccion.SuspendLayout();
            this.TpVendedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboVendedores)).BeginInit();
            this.TpCaja.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboProductosCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // CrvResumenVentas
            // 
            this.CrvResumenVentas.ActiveViewIndex = -1;
            this.CrvResumenVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CrvResumenVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrvResumenVentas.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrvResumenVentas.Location = new System.Drawing.Point(7, 110);
            this.CrvResumenVentas.Name = "CrvResumenVentas";
            this.CrvResumenVentas.Size = new System.Drawing.Size(863, 380);
            this.CrvResumenVentas.TabIndex = 5;
            this.CrvResumenVentas.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.CrvResumenVentas.Load += new System.EventHandler(this.CrvResumenVentas_Load);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 340;
            this.label3.Text = "Cajero:";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(557, 48);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(82, 23);
            this.btnGenerar.TabIndex = 347;
            this.btnGenerar.Text = "Consultar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(395, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 346;
            this.label2.Text = "Hasta:";
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
            this.cboFechaFin.Location = new System.Drawing.Point(440, 50);
            this.cboFechaFin.Name = "cboFechaFin";
            this.cboFechaFin.Size = new System.Drawing.Size(111, 22);
            this.cboFechaFin.TabIndex = 345;
            this.cboFechaFin.Tag = null;
            this.cboFechaFin.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 344;
            this.label1.Text = "Desde:";
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
            this.cboFechaInicio.Location = new System.Drawing.Point(440, 22);
            this.cboFechaInicio.Name = "cboFechaInicio";
            this.cboFechaInicio.Size = new System.Drawing.Size(111, 22);
            this.cboFechaInicio.TabIndex = 343;
            this.cboFechaInicio.Tag = null;
            this.cboFechaInicio.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown;
            // 
            // CboCaja
            // 
            this.CboCaja.AddItemSeparator = ';';
            this.CboCaja.AutoCompletion = true;
            this.CboCaja.AutoDropDown = true;
            this.CboCaja.Caption = "";
            this.CboCaja.CaptionHeight = 17;
            this.CboCaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboCaja.ColumnCaptionHeight = 17;
            this.CboCaja.ColumnFooterHeight = 17;
            this.CboCaja.ColumnHeaders = false;
            this.CboCaja.ContentHeight = 17;
            this.CboCaja.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboCaja.DisplayMember = "NomEmpresa";
            this.CboCaja.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboCaja.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboCaja.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboCaja.EditorHeight = 17;
            this.CboCaja.Images.Add(((System.Drawing.Image)(resources.GetObject("CboCaja.Images"))));
            this.CboCaja.ItemHeight = 15;
            this.CboCaja.Location = new System.Drawing.Point(66, 18);
            this.CboCaja.MatchEntryTimeout = ((long)(2000));
            this.CboCaja.MaxDropDownItems = ((short)(10));
            this.CboCaja.MaxLength = 32767;
            this.CboCaja.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboCaja.Name = "CboCaja";
            this.CboCaja.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboCaja.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboCaja.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboCaja.Size = new System.Drawing.Size(141, 23);
            this.CboCaja.TabIndex = 352;
            this.CboCaja.ValueMember = "EmpresaID";
            this.CboCaja.PropBag = resources.GetString("CboCaja.PropBag");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 351;
            this.label7.Text = "Caja:";
            // 
            // TcSeleccion
            // 
            this.TcSeleccion.Controls.Add(this.TpVendedor);
            this.TcSeleccion.Controls.Add(this.TpCaja);
            this.TcSeleccion.Location = new System.Drawing.Point(3, 6);
            this.TcSeleccion.Name = "TcSeleccion";
            this.TcSeleccion.SelectedIndex = 0;
            this.TcSeleccion.Size = new System.Drawing.Size(383, 73);
            this.TcSeleccion.TabIndex = 353;
            // 
            // TpVendedor
            // 
            this.TpVendedor.Controls.Add(this.CboVendedores);
            this.TpVendedor.Controls.Add(this.label3);
            this.TpVendedor.Location = new System.Drawing.Point(4, 22);
            this.TpVendedor.Name = "TpVendedor";
            this.TpVendedor.Padding = new System.Windows.Forms.Padding(3);
            this.TpVendedor.Size = new System.Drawing.Size(375, 47);
            this.TpVendedor.TabIndex = 0;
            this.TpVendedor.Text = "Por Cajero";
            this.TpVendedor.UseVisualStyleBackColor = true;
            // 
            // CboVendedores
            // 
            this.CboVendedores.AddItemSeparator = ';';
            this.CboVendedores.Caption = "";
            this.CboVendedores.CaptionHeight = 17;
            this.CboVendedores.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboVendedores.ColumnCaptionHeight = 17;
            this.CboVendedores.ColumnFooterHeight = 17;
            this.CboVendedores.ContentHeight = 17;
            this.CboVendedores.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboVendedores.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboVendedores.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboVendedores.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboVendedores.EditorHeight = 17;
            this.CboVendedores.Images.Add(((System.Drawing.Image)(resources.GetObject("CboVendedores.Images"))));
            this.CboVendedores.ItemHeight = 15;
            this.CboVendedores.Location = new System.Drawing.Point(73, 17);
            this.CboVendedores.MatchEntryTimeout = ((long)(2000));
            this.CboVendedores.MaxDropDownItems = ((short)(5));
            this.CboVendedores.MaxLength = 32767;
            this.CboVendedores.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboVendedores.Name = "CboVendedores";
            this.CboVendedores.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboVendedores.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboVendedores.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboVendedores.Size = new System.Drawing.Size(296, 23);
            this.CboVendedores.TabIndex = 341;
            this.CboVendedores.PropBag = resources.GetString("CboVendedores.PropBag");
            // 
            // TpCaja
            // 
            this.TpCaja.Controls.Add(this.CboCaja);
            this.TpCaja.Controls.Add(this.label7);
            this.TpCaja.Location = new System.Drawing.Point(4, 22);
            this.TpCaja.Name = "TpCaja";
            this.TpCaja.Padding = new System.Windows.Forms.Padding(3);
            this.TpCaja.Size = new System.Drawing.Size(375, 47);
            this.TpCaja.TabIndex = 1;
            this.TpCaja.Text = "Por Caja";
            this.TpCaja.UseVisualStyleBackColor = true;
            // 
            // CboTipoComprobante
            // 
            this.CboTipoComprobante.AddItemSeparator = ';';
            this.CboTipoComprobante.AutoCompletion = true;
            this.CboTipoComprobante.AutoDropDown = true;
            this.CboTipoComprobante.Caption = "";
            this.CboTipoComprobante.CaptionHeight = 17;
            this.CboTipoComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboTipoComprobante.ColumnCaptionHeight = 17;
            this.CboTipoComprobante.ColumnFooterHeight = 17;
            this.CboTipoComprobante.ColumnHeaders = false;
            this.CboTipoComprobante.ColumnWidth = 100;
            this.CboTipoComprobante.ContentHeight = 17;
            this.CboTipoComprobante.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboTipoComprobante.DisplayMember = "NomEmpresa";
            this.CboTipoComprobante.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboTipoComprobante.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTipoComprobante.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboTipoComprobante.EditorHeight = 17;
            this.CboTipoComprobante.Images.Add(((System.Drawing.Image)(resources.GetObject("CboTipoComprobante.Images"))));
            this.CboTipoComprobante.ItemHeight = 15;
            this.CboTipoComprobante.Location = new System.Drawing.Point(763, 81);
            this.CboTipoComprobante.MatchEntryTimeout = ((long)(2000));
            this.CboTipoComprobante.MaxDropDownItems = ((short)(10));
            this.CboTipoComprobante.MaxLength = 32767;
            this.CboTipoComprobante.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboTipoComprobante.Name = "CboTipoComprobante";
            this.CboTipoComprobante.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboTipoComprobante.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboTipoComprobante.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboTipoComprobante.Size = new System.Drawing.Size(107, 23);
            this.CboTipoComprobante.TabIndex = 355;
            this.CboTipoComprobante.ValueMember = "EmpresaID";
            this.CboTipoComprobante.SelectedValueChanged += new System.EventHandler(this.CboTipoComprobante_SelectedValueChanged);
            this.CboTipoComprobante.PropBag = resources.GetString("CboTipoComprobante.PropBag");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(696, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 354;
            this.label4.Text = "Filtrar por:";
            // 
            // CboProductosCodigo
            // 
            this.CboProductosCodigo.AddItemSeparator = ';';
            this.CboProductosCodigo.AutoSelect = true;
            this.CboProductosCodigo.Caption = "";
            this.CboProductosCodigo.CaptionHeight = 17;
            this.CboProductosCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboProductosCodigo.ColumnCaptionHeight = 17;
            this.CboProductosCodigo.ColumnFooterHeight = 17;
            this.CboProductosCodigo.ContentHeight = 17;
            this.CboProductosCodigo.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboProductosCodigo.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboProductosCodigo.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboProductosCodigo.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboProductosCodigo.EditorHeight = 17;
            this.CboProductosCodigo.Images.Add(((System.Drawing.Image)(resources.GetObject("CboProductosCodigo.Images"))));
            this.CboProductosCodigo.ItemHeight = 15;
            this.CboProductosCodigo.Location = new System.Drawing.Point(80, 81);
            this.CboProductosCodigo.MatchEntryTimeout = ((long)(2000));
            this.CboProductosCodigo.MaxDropDownItems = ((short)(5));
            this.CboProductosCodigo.MaxLength = 32767;
            this.CboProductosCodigo.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboProductosCodigo.Name = "CboProductosCodigo";
            this.CboProductosCodigo.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboProductosCodigo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboProductosCodigo.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboProductosCodigo.Size = new System.Drawing.Size(125, 23);
            this.CboProductosCodigo.TabIndex = 359;
            this.CboProductosCodigo.PropBag = resources.GetString("CboProductosCodigo.PropBag");
            // 
            // CboProductos
            // 
            this.CboProductos.AddItemSeparator = ';';
            this.CboProductos.AutoSelect = true;
            this.CboProductos.Caption = "";
            this.CboProductos.CaptionHeight = 17;
            this.CboProductos.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboProductos.ColumnCaptionHeight = 17;
            this.CboProductos.ColumnFooterHeight = 17;
            this.CboProductos.ContentHeight = 17;
            this.CboProductos.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboProductos.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboProductos.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboProductos.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboProductos.EditorHeight = 17;
            this.CboProductos.Images.Add(((System.Drawing.Image)(resources.GetObject("CboProductos.Images"))));
            this.CboProductos.ItemHeight = 15;
            this.CboProductos.Location = new System.Drawing.Point(218, 81);
            this.CboProductos.MatchEntryTimeout = ((long)(2000));
            this.CboProductos.MaxDropDownItems = ((short)(5));
            this.CboProductos.MaxLength = 32767;
            this.CboProductos.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboProductos.Name = "CboProductos";
            this.CboProductos.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboProductos.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboProductos.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboProductos.Size = new System.Drawing.Size(421, 23);
            this.CboProductos.TabIndex = 357;
            this.CboProductos.PropBag = resources.GetString("CboProductos.PropBag");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 356;
            this.label6.Text = "Producto:";
            // 
            // ReporteVentasPorProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CboProductosCodigo);
            this.Controls.Add(this.CboProductos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CboTipoComprobante);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CrvResumenVentas);
            this.Controls.Add(this.TcSeleccion);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboFechaInicio);
            this.Controls.Add(this.cboFechaFin);
            this.Name = "ReporteVentasPorProducto";
            this.Size = new System.Drawing.Size(883, 504);
            this.Load += new System.EventHandler(this.ReporteVentas_Load);
            this.Controls.SetChildIndex(this.cboFechaFin, 0);
            this.Controls.SetChildIndex(this.cboFechaInicio, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnGenerar, 0);
            this.Controls.SetChildIndex(this.TcSeleccion, 0);
            this.Controls.SetChildIndex(this.CrvResumenVentas, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.CboTipoComprobante, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.CboProductos, 0);
            this.Controls.SetChildIndex(this.CboProductosCodigo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboCaja)).EndInit();
            this.TcSeleccion.ResumeLayout(false);
            this.TpVendedor.ResumeLayout(false);
            this.TpVendedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboVendedores)).EndInit();
            this.TpCaja.ResumeLayout(false);
            this.TpCaja.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboProductosCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrvResumenVentas;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1Button btnGenerar;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1DateEdit cboFechaFin;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1DateEdit cboFechaInicio;
        private C1.Win.C1List.C1Combo CboCaja;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl TcSeleccion;
        private System.Windows.Forms.TabPage TpVendedor;
        private System.Windows.Forms.TabPage TpCaja;
        private C1.Win.C1List.C1Combo CboVendedores;
        private C1.Win.C1List.C1Combo CboTipoComprobante;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1List.C1Combo CboProductosCodigo;
        private C1.Win.C1List.C1Combo CboProductos;
        private System.Windows.Forms.Label label6;
    }
}
