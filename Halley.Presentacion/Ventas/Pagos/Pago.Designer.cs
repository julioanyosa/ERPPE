namespace Halley.Presentacion.Ventas.Pagos
{
    partial class Pago
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pago));
            this.LstComprobantes = new C1.Win.C1List.C1List();
            this.LstCreditos = new C1.Win.C1List.C1List();
            this.c1cboCia = new C1.Win.C1List.C1Combo();
            this.label14 = new System.Windows.Forms.Label();
            this.TxtComprobante = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnConsultar = new C1.Win.C1Input.C1Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbComprobante = new C1.Win.C1List.C1Combo();
            this.TdgPagosRealizados = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtDeudaTotal = new C1.Win.C1Input.C1TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtTotalPagado = new C1.Win.C1Input.C1TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtPorPagar = new C1.Win.C1Input.C1TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFormaPago = new C1.Win.C1List.C1Combo();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtObservacion = new C1.Win.C1Input.C1TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtPagar = new C1.Win.C1Input.C1TextBox();
            this.BtnPagar = new C1.Win.C1Input.C1Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtFechaEmision = new C1.Win.C1Input.C1TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtPorPagarComprobante = new C1.Win.C1Input.C1TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtImporteComprobante = new C1.Win.C1Input.C1TextBox();
            this.fff = new System.Windows.Forms.Label();
            this.TxtPagadoComprobante = new C1.Win.C1Input.C1TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.useCliente1 = new Halley.Presentacion.Ventas.UseCliente();
            this.RbCampanha = new System.Windows.Forms.RadioButton();
            this.RbComprobante = new System.Windows.Forms.RadioButton();
            this.PnCampanha = new System.Windows.Forms.Panel();
            this.BtnMultiplesPagos = new C1.Win.C1Input.C1Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PnComprobante = new System.Windows.Forms.Panel();
            this.BtnBuscar = new C1.Win.C1Input.C1Button();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.BtnImpresora = new C1.Win.C1Input.C1Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.LblCaja = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.ChkImprimir = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.LstComprobantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LstCreditos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgPagosRealizados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDeudaTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotalPagado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPorPagar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFormaPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtObservacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPagar)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFechaEmision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPorPagarComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtImporteComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPagadoComprobante)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.PnCampanha.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.PnComprobante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // LstComprobantes
            // 
            this.LstComprobantes.AddItemSeparator = ';';
            this.LstComprobantes.Caption = "Comprobantes";
            this.LstComprobantes.CaptionHeight = 17;
            this.LstComprobantes.ColumnCaptionHeight = 17;
            this.LstComprobantes.ColumnFooterHeight = 17;
            this.LstComprobantes.DeadAreaBackColor = System.Drawing.Color.White;
            this.LstComprobantes.EmptyRows = true;
            this.LstComprobantes.Images.Add(((System.Drawing.Image)(resources.GetObject("LstComprobantes.Images"))));
            this.LstComprobantes.ItemHeight = 15;
            this.LstComprobantes.Location = new System.Drawing.Point(345, 149);
            this.LstComprobantes.MatchEntryTimeout = ((long)(2000));
            this.LstComprobantes.Name = "LstComprobantes";
            this.LstComprobantes.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.LstComprobantes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.LstComprobantes.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.LstComprobantes.Size = new System.Drawing.Size(597, 105);
            this.LstComprobantes.TabIndex = 1;
            this.LstComprobantes.Text = "c1List2";
            this.LstComprobantes.DoubleClick += new System.EventHandler(this.LstComprobantes_DoubleClick);
            this.LstComprobantes.PropBag = resources.GetString("LstComprobantes.PropBag");
            // 
            // LstCreditos
            // 
            this.LstCreditos.AddItemSeparator = ';';
            this.LstCreditos.Caption = "Créditos";
            this.LstCreditos.CaptionHeight = 17;
            this.LstCreditos.ColumnCaptionHeight = 17;
            this.LstCreditos.ColumnFooterHeight = 17;
            this.LstCreditos.DeadAreaBackColor = System.Drawing.Color.White;
            this.LstCreditos.EmptyRows = true;
            this.LstCreditos.Images.Add(((System.Drawing.Image)(resources.GetObject("LstCreditos.Images"))));
            this.LstCreditos.ItemHeight = 15;
            this.LstCreditos.Location = new System.Drawing.Point(5, 149);
            this.LstCreditos.MatchEntryTimeout = ((long)(2000));
            this.LstCreditos.Name = "LstCreditos";
            this.LstCreditos.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.LstCreditos.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.LstCreditos.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.LstCreditos.Size = new System.Drawing.Size(339, 105);
            this.LstCreditos.TabIndex = 0;
            this.LstCreditos.DoubleClick += new System.EventHandler(this.LstCreditos_DoubleClick);
            this.LstCreditos.PropBag = resources.GetString("LstCreditos.PropBag");
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
            this.c1cboCia.ContentHeight = 17;
            this.c1cboCia.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.c1cboCia.DisplayMember = "NomEmpresa";
            this.c1cboCia.EditorBackColor = System.Drawing.SystemColors.Window;
            this.c1cboCia.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1cboCia.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.c1cboCia.EditorHeight = 17;
            this.c1cboCia.Images.Add(((System.Drawing.Image)(resources.GetObject("c1cboCia.Images"))));
            this.c1cboCia.ItemHeight = 15;
            this.c1cboCia.Location = new System.Drawing.Point(137, 16);
            this.c1cboCia.MatchEntryTimeout = ((long)(2000));
            this.c1cboCia.MaxDropDownItems = ((short)(10));
            this.c1cboCia.MaxLength = 32767;
            this.c1cboCia.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.c1cboCia.Name = "c1cboCia";
            this.c1cboCia.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.c1cboCia.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1cboCia.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1cboCia.Size = new System.Drawing.Size(230, 23);
            this.c1cboCia.TabIndex = 386;
            this.c1cboCia.ValueMember = "EmpresaID";
            this.c1cboCia.PropBag = resources.GetString("c1cboCia.PropBag");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(69, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 387;
            this.label14.Text = "Empresa:";
            // 
            // TxtComprobante
            // 
            this.TxtComprobante.Location = new System.Drawing.Point(137, 91);
            this.TxtComprobante.MaxLength = 11;
            this.TxtComprobante.Name = "TxtComprobante";
            this.TxtComprobante.Size = new System.Drawing.Size(142, 22);
            this.TxtComprobante.TabIndex = 390;
            this.TxtComprobante.Tag = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 391;
            this.label1.Text = "Nro Comprobante :";
            // 
            // BtnConsultar
            // 
            this.BtnConsultar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.BtnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnConsultar.Location = new System.Drawing.Point(285, 91);
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.Size = new System.Drawing.Size(82, 23);
            this.BtnConsultar.TabIndex = 20;
            this.BtnConsultar.Text = "Consultar";
            this.BtnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnConsultar.UseVisualStyleBackColor = true;
            this.BtnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 392;
            this.label4.Text = "Comprobante :";
            // 
            // cbComprobante
            // 
            this.cbComprobante.AddItemSeparator = ';';
            this.cbComprobante.Caption = "";
            this.cbComprobante.CaptionHeight = 17;
            this.cbComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbComprobante.ColumnCaptionHeight = 17;
            this.cbComprobante.ColumnFooterHeight = 17;
            this.cbComprobante.ColumnHeaders = false;
            this.cbComprobante.ColumnWidth = 100;
            this.cbComprobante.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cbComprobante.ContentHeight = 17;
            this.cbComprobante.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbComprobante.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbComprobante.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbComprobante.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbComprobante.EditorHeight = 17;
            this.cbComprobante.ExtendRightColumn = true;
            this.cbComprobante.Images.Add(((System.Drawing.Image)(resources.GetObject("cbComprobante.Images"))));
            this.cbComprobante.ItemHeight = 15;
            this.cbComprobante.Location = new System.Drawing.Point(137, 55);
            this.cbComprobante.MatchEntryTimeout = ((long)(2000));
            this.cbComprobante.MaxDropDownItems = ((short)(5));
            this.cbComprobante.MaxLength = 32767;
            this.cbComprobante.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbComprobante.Name = "cbComprobante";
            this.cbComprobante.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cbComprobante.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cbComprobante.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbComprobante.Size = new System.Drawing.Size(230, 23);
            this.cbComprobante.TabIndex = 393;
            this.cbComprobante.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.cbComprobante.PropBag = resources.GetString("cbComprobante.PropBag");
            // 
            // TdgPagosRealizados
            // 
            this.TdgPagosRealizados.AllowUpdate = false;
            this.TdgPagosRealizados.CaptionHeight = 17;
            this.TdgPagosRealizados.EmptyRows = true;
            this.TdgPagosRealizados.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgPagosRealizados.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgPagosRealizados.Images"))));
            this.TdgPagosRealizados.Location = new System.Drawing.Point(11, 27);
            this.TdgPagosRealizados.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgPagosRealizados.Name = "TdgPagosRealizados";
            this.TdgPagosRealizados.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgPagosRealizados.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgPagosRealizados.PreviewInfo.ZoomFactor = 75D;
            this.TdgPagosRealizados.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgPagosRealizados.PrintInfo.PageSettings")));
            this.TdgPagosRealizados.RowHeight = 18;
            this.TdgPagosRealizados.Size = new System.Drawing.Size(776, 100);
            this.TdgPagosRealizados.TabIndex = 394;
            this.TdgPagosRealizados.Text = "c1TrueDBGrid1";
            this.TdgPagosRealizados.PropBag = resources.GetString("TdgPagosRealizados.PropBag");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 396;
            this.label2.Text = "Deuda total:";
            // 
            // TxtDeudaTotal
            // 
            this.TxtDeudaTotal.Location = new System.Drawing.Point(163, 16);
            this.TxtDeudaTotal.Name = "TxtDeudaTotal";
            this.TxtDeudaTotal.Size = new System.Drawing.Size(107, 22);
            this.TxtDeudaTotal.TabIndex = 395;
            this.TxtDeudaTotal.Tag = null;
            this.TxtDeudaTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 398;
            this.label3.Text = "Total pagado :";
            // 
            // TxtTotalPagado
            // 
            this.TxtTotalPagado.Location = new System.Drawing.Point(163, 46);
            this.TxtTotalPagado.Name = "TxtTotalPagado";
            this.TxtTotalPagado.Size = new System.Drawing.Size(107, 22);
            this.TxtTotalPagado.TabIndex = 397;
            this.TxtTotalPagado.Tag = null;
            this.TxtTotalPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 400;
            this.label5.Text = "Por pagar :";
            // 
            // TxtPorPagar
            // 
            this.TxtPorPagar.Location = new System.Drawing.Point(163, 78);
            this.TxtPorPagar.Name = "TxtPorPagar";
            this.TxtPorPagar.Size = new System.Drawing.Size(107, 22);
            this.TxtPorPagar.TabIndex = 399;
            this.TxtPorPagar.Tag = null;
            this.TxtPorPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 401;
            this.label6.Text = "Forma Pago :";
            // 
            // cbFormaPago
            // 
            this.cbFormaPago.AddItemSeparator = ';';
            this.cbFormaPago.Caption = "";
            this.cbFormaPago.CaptionHeight = 17;
            this.cbFormaPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbFormaPago.ColumnCaptionHeight = 17;
            this.cbFormaPago.ColumnFooterHeight = 17;
            this.cbFormaPago.ColumnHeaders = false;
            this.cbFormaPago.ColumnWidth = 100;
            this.cbFormaPago.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cbFormaPago.ContentHeight = 17;
            this.cbFormaPago.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbFormaPago.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbFormaPago.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFormaPago.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbFormaPago.EditorHeight = 17;
            this.cbFormaPago.ExtendRightColumn = true;
            this.cbFormaPago.Images.Add(((System.Drawing.Image)(resources.GetObject("cbFormaPago.Images"))));
            this.cbFormaPago.ItemHeight = 15;
            this.cbFormaPago.Location = new System.Drawing.Point(149, 29);
            this.cbFormaPago.MatchEntryTimeout = ((long)(2000));
            this.cbFormaPago.MaxDropDownItems = ((short)(5));
            this.cbFormaPago.MaxLength = 32767;
            this.cbFormaPago.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbFormaPago.Name = "cbFormaPago";
            this.cbFormaPago.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cbFormaPago.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cbFormaPago.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbFormaPago.Size = new System.Drawing.Size(185, 23);
            this.cbFormaPago.TabIndex = 402;
            this.cbFormaPago.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.cbFormaPago.PropBag = resources.GetString("cbFormaPago.PropBag");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 404;
            this.label7.Text = "Observación:";
            // 
            // TxtObservacion
            // 
            this.TxtObservacion.Location = new System.Drawing.Point(14, 108);
            this.TxtObservacion.MaxLength = 200;
            this.TxtObservacion.Multiline = true;
            this.TxtObservacion.Name = "TxtObservacion";
            this.TxtObservacion.Size = new System.Drawing.Size(332, 63);
            this.TxtObservacion.TabIndex = 403;
            this.TxtObservacion.Tag = null;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 13);
            this.label8.TabIndex = 406;
            this.label8.Text = "Ingrese monto a pagar :";
            // 
            // TxtPagar
            // 
            this.TxtPagar.Location = new System.Drawing.Point(149, 58);
            this.TxtPagar.Name = "TxtPagar";
            this.TxtPagar.Size = new System.Drawing.Size(160, 22);
            this.TxtPagar.TabIndex = 405;
            this.TxtPagar.Tag = null;
            this.TxtPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtPagar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPagar_KeyPress);
            // 
            // BtnPagar
            // 
            this.BtnPagar.Image = global::Halley.Presentacion.Properties.Resources.agregar_16x16;
            this.BtnPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPagar.Location = new System.Drawing.Point(265, 189);
            this.BtnPagar.Name = "BtnPagar";
            this.BtnPagar.Size = new System.Drawing.Size(82, 23);
            this.BtnPagar.TabIndex = 407;
            this.BtnPagar.Text = "Registrar";
            this.BtnPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPagar.UseVisualStyleBackColor = true;
            this.BtnPagar.Click += new System.EventHandler(this.BtnPagar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.TxtFechaEmision);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.TxtPorPagarComprobante);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.TxtImporteComprobante);
            this.groupBox3.Controls.Add(this.fff);
            this.groupBox3.Controls.Add(this.TxtPagadoComprobante);
            this.groupBox3.Controls.Add(this.TdgPagosRealizados);
            this.groupBox3.Location = new System.Drawing.Point(3, 292);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(793, 220);
            this.groupBox3.TabIndex = 408;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pagos realizados";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(243, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 13);
            this.label11.TabIndex = 414;
            this.label11.Text = "Fecha de emisión:";
            // 
            // TxtFechaEmision
            // 
            this.TxtFechaEmision.Location = new System.Drawing.Point(348, 137);
            this.TxtFechaEmision.Name = "TxtFechaEmision";
            this.TxtFechaEmision.Size = new System.Drawing.Size(163, 22);
            this.TxtFechaEmision.TabIndex = 413;
            this.TxtFechaEmision.Tag = null;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(578, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 412;
            this.label10.Text = "Monto a Pagar:";
            // 
            // TxtPorPagarComprobante
            // 
            this.TxtPorPagarComprobante.Location = new System.Drawing.Point(672, 193);
            this.TxtPorPagarComprobante.Name = "TxtPorPagarComprobante";
            this.TxtPorPagarComprobante.Size = new System.Drawing.Size(115, 22);
            this.TxtPorPagarComprobante.TabIndex = 411;
            this.TxtPorPagarComprobante.Tag = null;
            this.TxtPorPagarComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(536, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 13);
            this.label9.TabIndex = 410;
            this.label9.Text = "Total por comprobante:";
            // 
            // TxtImporteComprobante
            // 
            this.TxtImporteComprobante.Location = new System.Drawing.Point(672, 137);
            this.TxtImporteComprobante.Name = "TxtImporteComprobante";
            this.TxtImporteComprobante.Size = new System.Drawing.Size(115, 22);
            this.TxtImporteComprobante.TabIndex = 409;
            this.TxtImporteComprobante.Tag = null;
            this.TxtImporteComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // fff
            // 
            this.fff.AutoSize = true;
            this.fff.Location = new System.Drawing.Point(587, 170);
            this.fff.Name = "fff";
            this.fff.Size = new System.Drawing.Size(77, 13);
            this.fff.TabIndex = 408;
            this.fff.Text = "total pagado:";
            // 
            // TxtPagadoComprobante
            // 
            this.TxtPagadoComprobante.Location = new System.Drawing.Point(672, 166);
            this.TxtPagadoComprobante.Name = "TxtPagadoComprobante";
            this.TxtPagadoComprobante.Size = new System.Drawing.Size(115, 22);
            this.TxtPagadoComprobante.TabIndex = 407;
            this.TxtPagadoComprobante.Tag = null;
            this.TxtPagadoComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ChkImprimir);
            this.groupBox4.Controls.Add(this.BtnPagar);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.TxtPagar);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.TxtObservacion);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.cbFormaPago);
            this.groupBox4.Location = new System.Drawing.Point(802, 291);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(353, 221);
            this.groupBox4.TabIndex = 409;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pago";
            // 
            // useCliente1
            // 
            this.useCliente1.Location = new System.Drawing.Point(9, 14);
            this.useCliente1.Name = "useCliente1";
            this.useCliente1.Size = new System.Drawing.Size(554, 129);
            this.useCliente1.TabIndex = 410;
            this.useCliente1.ComboValueChange += new Halley.Presentacion.Ventas.UseCliente.Del(this.useCliente1_ComboValueChange);
            // 
            // RbCampanha
            // 
            this.RbCampanha.AutoSize = true;
            this.RbCampanha.Checked = true;
            this.RbCampanha.Location = new System.Drawing.Point(14, 8);
            this.RbCampanha.Name = "RbCampanha";
            this.RbCampanha.Size = new System.Drawing.Size(73, 17);
            this.RbCampanha.TabIndex = 412;
            this.RbCampanha.TabStop = true;
            this.RbCampanha.Text = "Campaña";
            this.RbCampanha.UseVisualStyleBackColor = true;
            this.RbCampanha.CheckedChanged += new System.EventHandler(this.RbCampanha_CheckedChanged);
            // 
            // RbComprobante
            // 
            this.RbComprobante.AutoSize = true;
            this.RbComprobante.Location = new System.Drawing.Point(114, 8);
            this.RbComprobante.Name = "RbComprobante";
            this.RbComprobante.Size = new System.Drawing.Size(96, 17);
            this.RbComprobante.TabIndex = 413;
            this.RbComprobante.Text = "Comprobante";
            this.RbComprobante.UseVisualStyleBackColor = true;
            this.RbComprobante.CheckedChanged += new System.EventHandler(this.RbCampanha_CheckedChanged);
            // 
            // PnCampanha
            // 
            this.PnCampanha.Controls.Add(this.BtnMultiplesPagos);
            this.PnCampanha.Controls.Add(this.groupBox1);
            this.PnCampanha.Controls.Add(this.LstComprobantes);
            this.PnCampanha.Controls.Add(this.useCliente1);
            this.PnCampanha.Controls.Add(this.LstCreditos);
            this.PnCampanha.Location = new System.Drawing.Point(5, 26);
            this.PnCampanha.Name = "PnCampanha";
            this.PnCampanha.Size = new System.Drawing.Size(1075, 258);
            this.PnCampanha.TabIndex = 414;
            // 
            // BtnMultiplesPagos
            // 
            this.BtnMultiplesPagos.Image = global::Halley.Presentacion.Properties.Resources.PagoVarios_32x32;
            this.BtnMultiplesPagos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMultiplesPagos.Location = new System.Drawing.Point(974, 214);
            this.BtnMultiplesPagos.Name = "BtnMultiplesPagos";
            this.BtnMultiplesPagos.Size = new System.Drawing.Size(98, 40);
            this.BtnMultiplesPagos.TabIndex = 416;
            this.BtnMultiplesPagos.Text = "Multiples\r\npagos";
            this.BtnMultiplesPagos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnMultiplesPagos.UseVisualStyleBackColor = true;
            this.BtnMultiplesPagos.Click += new System.EventHandler(this.BtnMultiplesPagos_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtDeudaTotal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtTotalPagado);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TxtPorPagar);
            this.groupBox1.Location = new System.Drawing.Point(569, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 117);
            this.groupBox1.TabIndex = 411;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deuda total del Cliente";
            // 
            // PnComprobante
            // 
            this.PnComprobante.Controls.Add(this.BtnBuscar);
            this.PnComprobante.Controls.Add(this.label4);
            this.PnComprobante.Controls.Add(this.BtnConsultar);
            this.PnComprobante.Controls.Add(this.cbComprobante);
            this.PnComprobante.Controls.Add(this.TxtComprobante);
            this.PnComprobante.Controls.Add(this.label1);
            this.PnComprobante.Controls.Add(this.c1cboCia);
            this.PnComprobante.Controls.Add(this.label14);
            this.PnComprobante.Location = new System.Drawing.Point(3, 35);
            this.PnComprobante.Name = "PnComprobante";
            this.PnComprobante.Size = new System.Drawing.Size(538, 127);
            this.PnComprobante.TabIndex = 415;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Image = global::Halley.Presentacion.Properties.Resources.find_16x16;
            this.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBuscar.Location = new System.Drawing.Point(429, 92);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(82, 23);
            this.BtnBuscar.TabIndex = 395;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // BtnImpresora
            // 
            this.BtnImpresora.Image = global::Halley.Presentacion.Properties.Resources.printView_16x16;
            this.BtnImpresora.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImpresora.Location = new System.Drawing.Point(453, 6);
            this.BtnImpresora.Name = "BtnImpresora";
            this.BtnImpresora.Size = new System.Drawing.Size(82, 23);
            this.BtnImpresora.TabIndex = 418;
            this.BtnImpresora.Text = "Impresora";
            this.BtnImpresora.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnImpresora.UseVisualStyleBackColor = true;
            this.BtnImpresora.Click += new System.EventHandler(this.BtnImpresora_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // LblCaja
            // 
            this.LblCaja.BackColor = System.Drawing.Color.White;
            this.LblCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblCaja.Location = new System.Drawing.Point(268, 7);
            this.LblCaja.Name = "LblCaja";
            this.LblCaja.Size = new System.Drawing.Size(179, 21);
            this.LblCaja.TabIndex = 419;
            this.LblCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(227, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 420;
            this.label16.Text = "Caja :";
            // 
            // ChkImprimir
            // 
            this.ChkImprimir.AutoSize = true;
            this.ChkImprimir.Checked = true;
            this.ChkImprimir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkImprimir.Location = new System.Drawing.Point(14, 189);
            this.ChkImprimir.Name = "ChkImprimir";
            this.ChkImprimir.Size = new System.Drawing.Size(99, 17);
            this.ChkImprimir.TabIndex = 408;
            this.ChkImprimir.Text = "Imprimir ticket";
            this.ChkImprimir.UseVisualStyleBackColor = true;
            // 
            // Pago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LblCaja);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.BtnImpresora);
            this.Controls.Add(this.PnComprobante);
            this.Controls.Add(this.RbComprobante);
            this.Controls.Add(this.RbCampanha);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.PnCampanha);
            this.Controls.Add(this.groupBox3);
            this.Name = "Pago";
            this.Size = new System.Drawing.Size(1158, 601);
            this.Load += new System.EventHandler(this.Pago_Load);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.PnCampanha, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.RbCampanha, 0);
            this.Controls.SetChildIndex(this.RbComprobante, 0);
            this.Controls.SetChildIndex(this.PnComprobante, 0);
            this.Controls.SetChildIndex(this.BtnImpresora, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.LblCaja, 0);
            ((System.ComponentModel.ISupportInitialize)(this.LstComprobantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LstCreditos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgPagosRealizados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDeudaTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotalPagado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPorPagar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFormaPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtObservacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPagar)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFechaEmision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPorPagarComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtImporteComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPagadoComprobante)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.PnCampanha.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.PnComprobante.ResumeLayout(false);
            this.PnComprobante.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1List.C1List LstComprobantes;
        private C1.Win.C1List.C1List LstCreditos;
        private C1.Win.C1List.C1Combo c1cboCia;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox TxtComprobante;
        private C1.Win.C1Input.C1Button BtnConsultar;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgPagosRealizados;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1TextBox TxtDeudaTotal;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1TextBox TxtTotalPagado;
        private System.Windows.Forms.Label label5;
        private C1.Win.C1Input.C1TextBox TxtPorPagar;
        private System.Windows.Forms.Label label6;
        private C1.Win.C1List.C1Combo cbFormaPago;
        private System.Windows.Forms.Label label7;
        private C1.Win.C1Input.C1TextBox TxtObservacion;
        private System.Windows.Forms.Label label8;
        private C1.Win.C1Input.C1TextBox TxtPagar;
        private C1.Win.C1Input.C1Button BtnPagar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1List.C1Combo cbComprobante;
        private UseCliente useCliente1;
        private System.Windows.Forms.Label fff;
        private C1.Win.C1Input.C1TextBox TxtPagadoComprobante;
        private System.Windows.Forms.RadioButton RbCampanha;
        private System.Windows.Forms.RadioButton RbComprobante;
        private System.Windows.Forms.Label label10;
        private C1.Win.C1Input.C1TextBox TxtPorPagarComprobante;
        private System.Windows.Forms.Label label9;
        private C1.Win.C1Input.C1TextBox TxtImporteComprobante;
        private System.Windows.Forms.Label label11;
        private C1.Win.C1Input.C1TextBox TxtFechaEmision;
        private System.Windows.Forms.Panel PnCampanha;
        private System.Windows.Forms.Panel PnComprobante;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ErrorProvider ErrProvider;
        private C1.Win.C1Input.C1Button BtnMultiplesPagos;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private C1.Win.C1Input.C1Button BtnImpresora;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Label LblCaja;
        private System.Windows.Forms.Label label16;
        private C1.Win.C1Input.C1Button BtnBuscar;
        private System.Windows.Forms.CheckBox ChkImprimir;
    }
}
