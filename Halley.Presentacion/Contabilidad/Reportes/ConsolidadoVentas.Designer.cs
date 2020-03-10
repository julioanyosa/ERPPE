namespace Halley.Presentacion.Contabilidad.Reportes
{
    partial class ConsolidadoVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsolidadoVentas));
            this.CboAnno = new C1.Win.C1List.C1Combo();
            this.label11 = new System.Windows.Forms.Label();
            this.CboPeriodo = new C1.Win.C1List.C1Combo();
            this.label10 = new System.Windows.Forms.Label();
            this.c1cboCia = new C1.Win.C1List.C1Combo();
            this.label14 = new System.Windows.Forms.Label();
            this.btnConsultar = new C1.Win.C1Input.C1Button();
            this.CrvConsolidadoVentas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.CboTipoComprobante = new C1.Win.C1List.C1Combo();
            this.label9 = new System.Windows.Forms.Label();
            this.cboSeries = new C1.Win.C1List.C1Combo();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnFiltrar = new C1.Win.C1Input.C1Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnExcel = new C1.Win.C1Input.C1Button();
            this.RbKardex = new System.Windows.Forms.RadioButton();
            this.RbContable = new System.Windows.Forms.RadioButton();
            this.DtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.DtpFechaIni = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.TcContenedor = new System.Windows.Forms.TabControl();
            this.TpReporte = new System.Windows.Forms.TabPage();
            this.TpListado = new System.Windows.Forms.TabPage();
            this.CboTipoComprobanteListado = new C1.Win.C1List.C1Combo();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnConsultarListado = new C1.Win.C1Input.C1Button();
            this.DtpFechaFinListado = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.DtpFechaIniListado = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnImprimir = new C1.Win.C1Input.C1Button();
            this.TdgComprobantes = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BtnProductos = new C1.Win.C1Input.C1Button();
            this.BtnExcelClientes = new C1.Win.C1Input.C1Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.TxtFormato = new C1.Win.C1Input.C1TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CboAnno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSeries)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.TcContenedor.SuspendLayout();
            this.TpReporte.SuspendLayout();
            this.TpListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoComprobanteListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgComprobantes)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFormato)).BeginInit();
            this.SuspendLayout();
            // 
            // CboAnno
            // 
            this.CboAnno.AddItemSeparator = ';';
            this.CboAnno.Caption = "";
            this.CboAnno.CaptionHeight = 17;
            this.CboAnno.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboAnno.ColumnCaptionHeight = 17;
            this.CboAnno.ColumnFooterHeight = 17;
            this.CboAnno.ColumnWidth = 54;
            this.CboAnno.ContentHeight = 21;
            this.CboAnno.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboAnno.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboAnno.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboAnno.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboAnno.EditorHeight = 21;
            this.CboAnno.Images.Add(((System.Drawing.Image)(resources.GetObject("CboAnno.Images"))));
            this.CboAnno.ItemHeight = 15;
            this.CboAnno.Location = new System.Drawing.Point(504, 7);
            this.CboAnno.Margin = new System.Windows.Forms.Padding(4);
            this.CboAnno.MatchEntryTimeout = ((long)(2000));
            this.CboAnno.MaxDropDownItems = ((short)(5));
            this.CboAnno.MaxLength = 32767;
            this.CboAnno.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboAnno.Name = "CboAnno";
            this.CboAnno.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboAnno.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboAnno.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboAnno.Size = new System.Drawing.Size(109, 27);
            this.CboAnno.TabIndex = 401;
            this.CboAnno.PropBag = resources.GetString("CboAnno.PropBag");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(428, 14);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 19);
            this.label11.TabIndex = 400;
            this.label11.Text = "Año:";
            // 
            // CboPeriodo
            // 
            this.CboPeriodo.AddItemSeparator = ';';
            this.CboPeriodo.Caption = "";
            this.CboPeriodo.CaptionHeight = 17;
            this.CboPeriodo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboPeriodo.ColumnCaptionHeight = 17;
            this.CboPeriodo.ColumnFooterHeight = 17;
            this.CboPeriodo.ContentHeight = 21;
            this.CboPeriodo.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboPeriodo.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboPeriodo.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboPeriodo.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboPeriodo.EditorHeight = 21;
            this.CboPeriodo.Images.Add(((System.Drawing.Image)(resources.GetObject("CboPeriodo.Images"))));
            this.CboPeriodo.ItemHeight = 15;
            this.CboPeriodo.Location = new System.Drawing.Point(504, 41);
            this.CboPeriodo.Margin = new System.Windows.Forms.Padding(4);
            this.CboPeriodo.MatchEntryTimeout = ((long)(2000));
            this.CboPeriodo.MaxDropDownItems = ((short)(5));
            this.CboPeriodo.MaxLength = 32767;
            this.CboPeriodo.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboPeriodo.Name = "CboPeriodo";
            this.CboPeriodo.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboPeriodo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboPeriodo.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboPeriodo.Size = new System.Drawing.Size(213, 27);
            this.CboPeriodo.TabIndex = 399;
            this.CboPeriodo.PropBag = resources.GetString("CboPeriodo.PropBag");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(428, 48);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 19);
            this.label10.TabIndex = 398;
            this.label10.Text = "Periodo:";
            // 
            // c1cboCia
            // 
            this.c1cboCia.AddItemSeparator = ';';
            this.c1cboCia.AutoCompletion = true;
            this.c1cboCia.AutoDropDown = true;
            this.c1cboCia.Caption = "";
            this.c1cboCia.CaptionHeight = 17;
            this.c1cboCia.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.c1cboCia.ColumnCaptionHeight = 17;
            this.c1cboCia.ColumnFooterHeight = 17;
            this.c1cboCia.ColumnHeaders = false;
            this.c1cboCia.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.c1cboCia.ContentHeight = 21;
            this.c1cboCia.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.c1cboCia.DisplayMember = "NomEmpresa";
            this.c1cboCia.EditorBackColor = System.Drawing.SystemColors.Window;
            this.c1cboCia.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1cboCia.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.c1cboCia.EditorHeight = 21;
            this.c1cboCia.Images.Add(((System.Drawing.Image)(resources.GetObject("c1cboCia.Images"))));
            this.c1cboCia.ItemHeight = 15;
            this.c1cboCia.Location = new System.Drawing.Point(490, 4);
            this.c1cboCia.Margin = new System.Windows.Forms.Padding(4);
            this.c1cboCia.MatchEntryTimeout = ((long)(2000));
            this.c1cboCia.MaxDropDownItems = ((short)(10));
            this.c1cboCia.MaxLength = 32767;
            this.c1cboCia.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.c1cboCia.Name = "c1cboCia";
            this.c1cboCia.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.c1cboCia.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1cboCia.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1cboCia.Size = new System.Drawing.Size(251, 27);
            this.c1cboCia.TabIndex = 417;
            this.c1cboCia.ValueMember = "EmpresaID";
            this.c1cboCia.SelectedValueChanged += new System.EventHandler(this.c1cboCia_SelectedValueChanged);
            this.c1cboCia.PropBag = resources.GetString("c1cboCia.PropBag");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(371, 12);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 19);
            this.label14.TabIndex = 418;
            this.label14.Text = "Empresa:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = global::Halley.Presentacion.Properties.Resources.printView_16x16;
            this.btnConsultar.Location = new System.Drawing.Point(823, 41);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(4);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(120, 34);
            this.btnConsultar.TabIndex = 419;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // CrvConsolidadoVentas
            // 
            this.CrvConsolidadoVentas.ActiveViewIndex = -1;
            this.CrvConsolidadoVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CrvConsolidadoVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrvConsolidadoVentas.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrvConsolidadoVentas.Location = new System.Drawing.Point(3, 80);
            this.CrvConsolidadoVentas.Margin = new System.Windows.Forms.Padding(4);
            this.CrvConsolidadoVentas.Name = "CrvConsolidadoVentas";
            this.CrvConsolidadoVentas.Size = new System.Drawing.Size(1088, 473);
            this.CrvConsolidadoVentas.TabIndex = 420;
            this.CrvConsolidadoVentas.ToolPanelWidth = 173;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 23);
            this.label1.TabIndex = 421;
            this.label1.Text = "Consolidado de ventas por periodo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CboTipoComprobante
            // 
            this.CboTipoComprobante.AddItemSeparator = ';';
            this.CboTipoComprobante.Caption = "";
            this.CboTipoComprobante.CaptionHeight = 17;
            this.CboTipoComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboTipoComprobante.ColumnCaptionHeight = 17;
            this.CboTipoComprobante.ColumnFooterHeight = 17;
            this.CboTipoComprobante.ColumnHeaders = false;
            this.CboTipoComprobante.ColumnWidth = 100;
            this.CboTipoComprobante.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.CboTipoComprobante.ContentHeight = 21;
            this.CboTipoComprobante.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboTipoComprobante.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboTipoComprobante.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTipoComprobante.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboTipoComprobante.EditorHeight = 21;
            this.CboTipoComprobante.ExtendRightColumn = true;
            this.CboTipoComprobante.Images.Add(((System.Drawing.Image)(resources.GetObject("CboTipoComprobante.Images"))));
            this.CboTipoComprobante.ItemHeight = 15;
            this.CboTipoComprobante.Location = new System.Drawing.Point(146, 41);
            this.CboTipoComprobante.Margin = new System.Windows.Forms.Padding(4);
            this.CboTipoComprobante.MatchEntryTimeout = ((long)(2000));
            this.CboTipoComprobante.MaxDropDownItems = ((short)(5));
            this.CboTipoComprobante.MaxLength = 32767;
            this.CboTipoComprobante.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboTipoComprobante.Name = "CboTipoComprobante";
            this.CboTipoComprobante.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboTipoComprobante.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboTipoComprobante.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboTipoComprobante.Size = new System.Drawing.Size(251, 27);
            this.CboTipoComprobante.TabIndex = 422;
            this.CboTipoComprobante.PropBag = resources.GetString("CboTipoComprobante.PropBag");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(27, 48);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 19);
            this.label9.TabIndex = 423;
            this.label9.Text = "Comprobante :";
            // 
            // cboSeries
            // 
            this.cboSeries.AddItemSeparator = ';';
            this.cboSeries.Caption = "";
            this.cboSeries.CaptionHeight = 17;
            this.cboSeries.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cboSeries.ColumnCaptionHeight = 17;
            this.cboSeries.ColumnFooterHeight = 17;
            this.cboSeries.ColumnWidth = 54;
            this.cboSeries.ContentHeight = 21;
            this.cboSeries.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cboSeries.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cboSeries.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSeries.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cboSeries.EditorHeight = 21;
            this.cboSeries.Images.Add(((System.Drawing.Image)(resources.GetObject("cboSeries.Images"))));
            this.cboSeries.ItemHeight = 15;
            this.cboSeries.Location = new System.Drawing.Point(796, 7);
            this.cboSeries.Margin = new System.Windows.Forms.Padding(4);
            this.cboSeries.MatchEntryTimeout = ((long)(2000));
            this.cboSeries.MaxDropDownItems = ((short)(5));
            this.cboSeries.MaxLength = 32767;
            this.cboSeries.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cboSeries.Name = "cboSeries";
            this.cboSeries.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cboSeries.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cboSeries.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cboSeries.Size = new System.Drawing.Size(109, 27);
            this.cboSeries.TabIndex = 425;
            this.cboSeries.PropBag = resources.GetString("cboSeries.PropBag");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(739, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 38);
            this.label2.TabIndex = 424;
            this.label2.Text = "Filtrar\r\nserie:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnFiltrar
            // 
            this.BtnFiltrar.Image = global::Halley.Presentacion.Properties.Resources.filter_16x16;
            this.BtnFiltrar.Location = new System.Drawing.Point(911, 0);
            this.BtnFiltrar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnFiltrar.Name = "BtnFiltrar";
            this.BtnFiltrar.Size = new System.Drawing.Size(32, 34);
            this.BtnFiltrar.TabIndex = 426;
            this.BtnFiltrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnFiltrar.UseVisualStyleBackColor = true;
            this.BtnFiltrar.Click += new System.EventHandler(this.BtnFiltrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnExcel);
            this.groupBox1.Controls.Add(this.RbKardex);
            this.groupBox1.Controls.Add(this.RbContable);
            this.groupBox1.Controls.Add(this.DtpFechaFin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DtpFechaIni);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(20, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1049, 88);
            this.groupBox1.TabIndex = 427;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exportar a Excel";
            // 
            // BtnExcel
            // 
            this.BtnExcel.Image = global::Halley.Presentacion.Properties.Resources.excel_16x16;
            this.BtnExcel.Location = new System.Drawing.Point(736, 37);
            this.BtnExcel.Margin = new System.Windows.Forms.Padding(4);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(120, 34);
            this.BtnExcel.TabIndex = 420;
            this.BtnExcel.Text = "Exportar";
            this.BtnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnExcel.UseVisualStyleBackColor = true;
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // RbKardex
            // 
            this.RbKardex.AutoSize = true;
            this.RbKardex.Location = new System.Drawing.Point(638, 37);
            this.RbKardex.Name = "RbKardex";
            this.RbKardex.Size = new System.Drawing.Size(71, 23);
            this.RbKardex.TabIndex = 411;
            this.RbKardex.Text = "Kardex";
            this.RbKardex.UseVisualStyleBackColor = true;
            // 
            // RbContable
            // 
            this.RbContable.AutoSize = true;
            this.RbContable.Checked = true;
            this.RbContable.Location = new System.Drawing.Point(526, 37);
            this.RbContable.Name = "RbContable";
            this.RbContable.Size = new System.Drawing.Size(85, 23);
            this.RbContable.TabIndex = 410;
            this.RbContable.TabStop = true;
            this.RbContable.Text = "Contable";
            this.RbContable.UseVisualStyleBackColor = true;
            // 
            // DtpFechaFin
            // 
            this.DtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaFin.Location = new System.Drawing.Point(392, 37);
            this.DtpFechaFin.Margin = new System.Windows.Forms.Padding(4);
            this.DtpFechaFin.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFechaFin.Name = "DtpFechaFin";
            this.DtpFechaFin.Size = new System.Drawing.Size(107, 26);
            this.DtpFechaFin.TabIndex = 408;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 409;
            this.label3.Text = "Fecha final:";
            // 
            // DtpFechaIni
            // 
            this.DtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaIni.Location = new System.Drawing.Point(155, 37);
            this.DtpFechaIni.Margin = new System.Windows.Forms.Padding(4);
            this.DtpFechaIni.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFechaIni.Name = "DtpFechaIni";
            this.DtpFechaIni.Size = new System.Drawing.Size(107, 26);
            this.DtpFechaIni.TabIndex = 406;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 19);
            this.label4.TabIndex = 407;
            this.label4.Text = "Fecha inicial:";
            // 
            // TcContenedor
            // 
            this.TcContenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TcContenedor.Controls.Add(this.TpReporte);
            this.TcContenedor.Controls.Add(this.TpListado);
            this.TcContenedor.Controls.Add(this.tabPage1);
            this.TcContenedor.Location = new System.Drawing.Point(8, 60);
            this.TcContenedor.Name = "TcContenedor";
            this.TcContenedor.SelectedIndex = 0;
            this.TcContenedor.Size = new System.Drawing.Size(1102, 604);
            this.TcContenedor.TabIndex = 428;
            // 
            // TpReporte
            // 
            this.TpReporte.Controls.Add(this.CrvConsolidadoVentas);
            this.TpReporte.Controls.Add(this.BtnFiltrar);
            this.TpReporte.Controls.Add(this.label10);
            this.TpReporte.Controls.Add(this.cboSeries);
            this.TpReporte.Controls.Add(this.CboPeriodo);
            this.TpReporte.Controls.Add(this.label2);
            this.TpReporte.Controls.Add(this.label11);
            this.TpReporte.Controls.Add(this.CboTipoComprobante);
            this.TpReporte.Controls.Add(this.CboAnno);
            this.TpReporte.Controls.Add(this.label9);
            this.TpReporte.Controls.Add(this.btnConsultar);
            this.TpReporte.Location = new System.Drawing.Point(4, 28);
            this.TpReporte.Name = "TpReporte";
            this.TpReporte.Padding = new System.Windows.Forms.Padding(3);
            this.TpReporte.Size = new System.Drawing.Size(1094, 572);
            this.TpReporte.TabIndex = 0;
            this.TpReporte.Text = "Reporte";
            this.TpReporte.UseVisualStyleBackColor = true;
            // 
            // TpListado
            // 
            this.TpListado.Controls.Add(this.CboTipoComprobanteListado);
            this.TpListado.Controls.Add(this.label7);
            this.TpListado.Controls.Add(this.BtnConsultarListado);
            this.TpListado.Controls.Add(this.DtpFechaFinListado);
            this.TpListado.Controls.Add(this.label5);
            this.TpListado.Controls.Add(this.DtpFechaIniListado);
            this.TpListado.Controls.Add(this.label6);
            this.TpListado.Controls.Add(this.BtnImprimir);
            this.TpListado.Controls.Add(this.TdgComprobantes);
            this.TpListado.Location = new System.Drawing.Point(4, 28);
            this.TpListado.Name = "TpListado";
            this.TpListado.Padding = new System.Windows.Forms.Padding(3);
            this.TpListado.Size = new System.Drawing.Size(1094, 572);
            this.TpListado.TabIndex = 1;
            this.TpListado.Text = "Listado";
            this.TpListado.UseVisualStyleBackColor = true;
            // 
            // CboTipoComprobanteListado
            // 
            this.CboTipoComprobanteListado.AddItemSeparator = ';';
            this.CboTipoComprobanteListado.Caption = "";
            this.CboTipoComprobanteListado.CaptionHeight = 17;
            this.CboTipoComprobanteListado.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboTipoComprobanteListado.ColumnCaptionHeight = 17;
            this.CboTipoComprobanteListado.ColumnFooterHeight = 17;
            this.CboTipoComprobanteListado.ColumnHeaders = false;
            this.CboTipoComprobanteListado.ColumnWidth = 100;
            this.CboTipoComprobanteListado.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.CboTipoComprobanteListado.ContentHeight = 21;
            this.CboTipoComprobanteListado.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboTipoComprobanteListado.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboTipoComprobanteListado.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTipoComprobanteListado.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboTipoComprobanteListado.EditorHeight = 21;
            this.CboTipoComprobanteListado.ExtendRightColumn = true;
            this.CboTipoComprobanteListado.Images.Add(((System.Drawing.Image)(resources.GetObject("CboTipoComprobanteListado.Images"))));
            this.CboTipoComprobanteListado.ItemHeight = 15;
            this.CboTipoComprobanteListado.Location = new System.Drawing.Point(147, 7);
            this.CboTipoComprobanteListado.Margin = new System.Windows.Forms.Padding(4);
            this.CboTipoComprobanteListado.MatchEntryTimeout = ((long)(2000));
            this.CboTipoComprobanteListado.MaxDropDownItems = ((short)(5));
            this.CboTipoComprobanteListado.MaxLength = 32767;
            this.CboTipoComprobanteListado.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboTipoComprobanteListado.Name = "CboTipoComprobanteListado";
            this.CboTipoComprobanteListado.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboTipoComprobanteListado.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboTipoComprobanteListado.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboTipoComprobanteListado.Size = new System.Drawing.Size(251, 27);
            this.CboTipoComprobanteListado.TabIndex = 435;
            this.CboTipoComprobanteListado.PropBag = resources.GetString("CboTipoComprobanteListado.PropBag");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 19);
            this.label7.TabIndex = 436;
            this.label7.Text = "Comprobante :";
            // 
            // BtnConsultarListado
            // 
            this.BtnConsultarListado.Image = global::Halley.Presentacion.Properties.Resources.printView_16x16;
            this.BtnConsultarListado.Location = new System.Drawing.Point(516, 53);
            this.BtnConsultarListado.Margin = new System.Windows.Forms.Padding(4);
            this.BtnConsultarListado.Name = "BtnConsultarListado";
            this.BtnConsultarListado.Size = new System.Drawing.Size(120, 34);
            this.BtnConsultarListado.TabIndex = 434;
            this.BtnConsultarListado.Text = "Consultar";
            this.BtnConsultarListado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnConsultarListado.UseVisualStyleBackColor = true;
            this.BtnConsultarListado.Click += new System.EventHandler(this.BtnConsultarListado_Click);
            // 
            // DtpFechaFinListado
            // 
            this.DtpFechaFinListado.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaFinListado.Location = new System.Drawing.Point(373, 53);
            this.DtpFechaFinListado.Margin = new System.Windows.Forms.Padding(4);
            this.DtpFechaFinListado.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFechaFinListado.Name = "DtpFechaFinListado";
            this.DtpFechaFinListado.Size = new System.Drawing.Size(107, 26);
            this.DtpFechaFinListado.TabIndex = 432;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(270, 53);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 19);
            this.label5.TabIndex = 433;
            this.label5.Text = "Fecha final:";
            // 
            // DtpFechaIniListado
            // 
            this.DtpFechaIniListado.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaIniListado.Location = new System.Drawing.Point(136, 53);
            this.DtpFechaIniListado.Margin = new System.Windows.Forms.Padding(4);
            this.DtpFechaIniListado.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFechaIniListado.Name = "DtpFechaIniListado";
            this.DtpFechaIniListado.Size = new System.Drawing.Size(107, 26);
            this.DtpFechaIniListado.TabIndex = 430;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 53);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 19);
            this.label6.TabIndex = 431;
            this.label6.Text = "Fecha inicial:";
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Image = global::Halley.Presentacion.Properties.Resources.print_16x16;
            this.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImprimir.Location = new System.Drawing.Point(970, 17);
            this.BtnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(107, 37);
            this.BtnImprimir.TabIndex = 429;
            this.BtnImprimir.Text = "Im&primir";
            this.BtnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnImprimir.UseVisualStyleBackColor = true;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // TdgComprobantes
            // 
            this.TdgComprobantes.AllowUpdate = false;
            this.TdgComprobantes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TdgComprobantes.CaptionHeight = 17;
            this.TdgComprobantes.FilterBar = true;
            this.TdgComprobantes.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgComprobantes.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgComprobantes.Images"))));
            this.TdgComprobantes.Location = new System.Drawing.Point(3, 95);
            this.TdgComprobantes.Margin = new System.Windows.Forms.Padding(4);
            this.TdgComprobantes.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell;
            this.TdgComprobantes.Name = "TdgComprobantes";
            this.TdgComprobantes.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgComprobantes.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgComprobantes.PreviewInfo.ZoomFactor = 75D;
            this.TdgComprobantes.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgComprobantes.PrintInfo.PageSettings")));
            this.TdgComprobantes.RowHeight = 27;
            this.TdgComprobantes.Size = new System.Drawing.Size(1088, 470);
            this.TdgComprobantes.TabIndex = 413;
            this.TdgComprobantes.Text = "c1TrueDBGrid1";
            this.TdgComprobantes.PropBag = resources.GetString("TdgComprobantes.PropBag");
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BtnProductos);
            this.tabPage1.Controls.Add(this.BtnExcelClientes);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1094, 572);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Exportar Excel";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BtnProductos
            // 
            this.BtnProductos.Image = global::Halley.Presentacion.Properties.Resources.excel_16x16;
            this.BtnProductos.Location = new System.Drawing.Point(148, 133);
            this.BtnProductos.Margin = new System.Windows.Forms.Padding(4);
            this.BtnProductos.Name = "BtnProductos";
            this.BtnProductos.Size = new System.Drawing.Size(120, 34);
            this.BtnProductos.TabIndex = 429;
            this.BtnProductos.Text = "Productos";
            this.BtnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnProductos.UseVisualStyleBackColor = true;
            this.BtnProductos.Click += new System.EventHandler(this.BtnProductos_Click);
            // 
            // BtnExcelClientes
            // 
            this.BtnExcelClientes.Image = global::Halley.Presentacion.Properties.Resources.excel_16x16;
            this.BtnExcelClientes.Location = new System.Drawing.Point(20, 133);
            this.BtnExcelClientes.Margin = new System.Windows.Forms.Padding(4);
            this.BtnExcelClientes.Name = "BtnExcelClientes";
            this.BtnExcelClientes.Size = new System.Drawing.Size(120, 34);
            this.BtnExcelClientes.TabIndex = 428;
            this.BtnExcelClientes.Text = "Clientes";
            this.BtnExcelClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExcelClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnExcelClientes.UseVisualStyleBackColor = true;
            this.BtnExcelClientes.Click += new System.EventHandler(this.BtnExcelClientes_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // TxtFormato
            // 
            this.TxtFormato.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFormato.Location = new System.Drawing.Point(962, 31);
            this.TxtFormato.Margin = new System.Windows.Forms.Padding(4);
            this.TxtFormato.MaxLength = 17;
            this.TxtFormato.Name = "TxtFormato";
            this.TxtFormato.Size = new System.Drawing.Size(105, 22);
            this.TxtFormato.TabIndex = 429;
            this.TxtFormato.Tag = null;
            this.TxtFormato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtFormato.Visible = false;
            // 
            // ConsolidadoVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TxtFormato);
            this.Controls.Add(this.c1cboCia);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.TcContenedor);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConsolidadoVentas";
            this.Size = new System.Drawing.Size(1132, 706);
            this.Load += new System.EventHandler(this.ConsolidadoVentas_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.TcContenedor, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.c1cboCia, 0);
            this.Controls.SetChildIndex(this.TxtFormato, 0);
            ((System.ComponentModel.ISupportInitialize)(this.CboAnno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSeries)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TcContenedor.ResumeLayout(false);
            this.TpReporte.ResumeLayout(false);
            this.TpReporte.PerformLayout();
            this.TpListado.ResumeLayout(false);
            this.TpListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoComprobanteListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgComprobantes)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TxtFormato)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1List.C1Combo CboAnno;
        private System.Windows.Forms.Label label11;
        private C1.Win.C1List.C1Combo CboPeriodo;
        private System.Windows.Forms.Label label10;
        private C1.Win.C1List.C1Combo c1cboCia;
        private System.Windows.Forms.Label label14;
        private C1.Win.C1Input.C1Button btnConsultar;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrvConsolidadoVentas;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1List.C1Combo CboTipoComprobante;
        private System.Windows.Forms.Label label9;
        private C1.Win.C1List.C1Combo cboSeries;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1Button BtnFiltrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private C1.Win.C1Input.C1Button BtnExcel;
        private System.Windows.Forms.RadioButton RbKardex;
        private System.Windows.Forms.RadioButton RbContable;
        private System.Windows.Forms.DateTimePicker DtpFechaFin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DtpFechaIni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl TcContenedor;
        private System.Windows.Forms.TabPage TpReporte;
        private System.Windows.Forms.TabPage TpListado;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgComprobantes;
        private C1.Win.C1Input.C1Button BtnImprimir;
        private System.Windows.Forms.TabPage tabPage1;
        private C1.Win.C1Input.C1Button BtnConsultarListado;
        private System.Windows.Forms.DateTimePicker DtpFechaFinListado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DtpFechaIniListado;
        private System.Windows.Forms.Label label6;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private C1.Win.C1Input.C1TextBox TxtFormato;
        private C1.Win.C1List.C1Combo CboTipoComprobanteListado;
        private System.Windows.Forms.Label label7;
        private C1.Win.C1Input.C1Button BtnProductos;
        private C1.Win.C1Input.C1Button BtnExcelClientes;
    }
}
