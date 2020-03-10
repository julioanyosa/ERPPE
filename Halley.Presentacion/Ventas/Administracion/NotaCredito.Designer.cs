namespace Halley.Presentacion.Ventas.Administracion
{
    partial class NotaCredito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotaCredito));
            this.BtnRegistrar = new C1.Win.C1Input.C1Button();
            this.LblRUC = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblEmpresa = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TdgDetalleComprobante = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.c1cboCia = new C1.Win.C1List.C1Combo();
            this.label9 = new System.Windows.Forms.Label();
            this.cbComprobante = new C1.Win.C1List.C1Combo();
            this.label27 = new System.Windows.Forms.Label();
            this.BtnBuscar = new C1.Win.C1Input.C1Button();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtNumComprobante = new C1.Win.C1Input.C1TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.TxtConcepto = new C1.Win.C1Input.C1TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDireccion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LblTipoDocumento = new System.Windows.Forms.Label();
            this.LblVendedor = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.LblAudCrea = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.c1NumericEdit1 = new C1.Win.C1Input.C1NumericEdit();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.LblDevolucion = new System.Windows.Forms.Label();
            this.LblCaja = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbOtros = new System.Windows.Forms.RadioButton();
            this.rbDescuentos = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TdgDetalleComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNumComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtConcepto)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1NumericEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Image = global::Halley.Presentacion.Properties.Resources.save_16x16;
            this.BtnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRegistrar.Location = new System.Drawing.Point(785, 284);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(84, 23);
            this.BtnRegistrar.TabIndex = 452;
            this.BtnRegistrar.Text = "&Registrar";
            this.BtnRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // LblRUC
            // 
            this.LblRUC.BackColor = System.Drawing.Color.White;
            this.LblRUC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblRUC.Location = new System.Drawing.Point(113, 249);
            this.LblRUC.Name = "LblRUC";
            this.LblRUC.Size = new System.Drawing.Size(110, 21);
            this.LblRUC.TabIndex = 451;
            this.LblRUC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 450;
            this.label3.Text = "RUC:";
            // 
            // LblEmpresa
            // 
            this.LblEmpresa.BackColor = System.Drawing.Color.White;
            this.LblEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblEmpresa.Location = new System.Drawing.Point(113, 217);
            this.LblEmpresa.Name = "LblEmpresa";
            this.LblEmpresa.Size = new System.Drawing.Size(341, 21);
            this.LblEmpresa.TabIndex = 449;
            this.LblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 448;
            this.label5.Text = "Empresa :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(529, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 447;
            this.label2.Text = "Importe de devolución:";
            // 
            // TdgDetalleComprobante
            // 
            this.TdgDetalleComprobante.CaptionHeight = 17;
            this.TdgDetalleComprobante.EmptyRows = true;
            this.TdgDetalleComprobante.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgDetalleComprobante.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgDetalleComprobante.Images"))));
            this.TdgDetalleComprobante.Location = new System.Drawing.Point(28, 313);
            this.TdgDetalleComprobante.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgDetalleComprobante.Name = "TdgDetalleComprobante";
            this.TdgDetalleComprobante.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgDetalleComprobante.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgDetalleComprobante.PreviewInfo.ZoomFactor = 75D;
            this.TdgDetalleComprobante.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgDetalleComprobante.PrintInfo.PageSettings")));
            this.TdgDetalleComprobante.RowHeight = 18;
            this.TdgDetalleComprobante.Size = new System.Drawing.Size(847, 217);
            this.TdgDetalleComprobante.TabIndex = 445;
            this.TdgDetalleComprobante.Text = "c1TrueDBGrid1";
            this.TdgDetalleComprobante.AfterUpdate += new System.EventHandler(this.TdgDetalleComprobante_AfterUpdate);
            this.TdgDetalleComprobante.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.TdgDetalleComprobante_BeforeColUpdate);
            this.TdgDetalleComprobante.PropBag = resources.GetString("TdgDetalleComprobante.PropBag");
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
            this.c1cboCia.Location = new System.Drawing.Point(113, 46);
            this.c1cboCia.MatchEntryTimeout = ((long)(2000));
            this.c1cboCia.MaxDropDownItems = ((short)(10));
            this.c1cboCia.MaxLength = 32767;
            this.c1cboCia.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.c1cboCia.Name = "c1cboCia";
            this.c1cboCia.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.c1cboCia.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1cboCia.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1cboCia.Size = new System.Drawing.Size(208, 23);
            this.c1cboCia.TabIndex = 443;
            this.c1cboCia.ValueMember = "EmpresaID";
            this.c1cboCia.PropBag = resources.GetString("c1cboCia.PropBag");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(56, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 444;
            this.label9.Text = "Empresa:";
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
            this.cbComprobante.Location = new System.Drawing.Point(113, 93);
            this.cbComprobante.MatchEntryTimeout = ((long)(2000));
            this.cbComprobante.MaxDropDownItems = ((short)(5));
            this.cbComprobante.MaxLength = 32767;
            this.cbComprobante.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbComprobante.Name = "cbComprobante";
            this.cbComprobante.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cbComprobante.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cbComprobante.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbComprobante.Size = new System.Drawing.Size(208, 23);
            this.cbComprobante.TabIndex = 441;
            this.cbComprobante.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.cbComprobante.PropBag = resources.GetString("cbComprobante.PropBag");
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(25, 98);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(84, 13);
            this.label27.TabIndex = 442;
            this.label27.Text = "Comprobante :";
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Image = global::Halley.Presentacion.Properties.Resources.Consultar_16x16;
            this.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBuscar.Location = new System.Drawing.Point(327, 93);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(62, 23);
            this.BtnBuscar.TabIndex = 440;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 439;
            this.label10.Text = "Documento :";
            // 
            // TxtNumComprobante
            // 
            this.TxtNumComprobante.BackColor = System.Drawing.Color.White;
            this.TxtNumComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNumComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNumComprobante.Location = new System.Drawing.Point(113, 71);
            this.TxtNumComprobante.MaxLength = 13;
            this.TxtNumComprobante.Name = "TxtNumComprobante";
            this.TxtNumComprobante.Size = new System.Drawing.Size(208, 20);
            this.TxtNumComprobante.TabIndex = 438;
            this.TxtNumComprobante.Tag = null;
            this.TxtNumComprobante.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtNumComprobante.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(493, 220);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(73, 26);
            this.lblNombre.TabIndex = 437;
            this.lblNombre.Text = "Concepto de\r\ndevolución:";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtConcepto
            // 
            this.TxtConcepto.Location = new System.Drawing.Point(579, 218);
            this.TxtConcepto.MaxLength = 200;
            this.TxtConcepto.Multiline = true;
            this.TxtConcepto.Name = "TxtConcepto";
            this.TxtConcepto.Size = new System.Drawing.Size(290, 56);
            this.TxtConcepto.TabIndex = 436;
            this.TxtConcepto.Tag = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 435;
            this.label7.Text = "Nota de Crédito";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDireccion);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.LblTipoDocumento);
            this.groupBox2.Controls.Add(this.LblVendedor);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.LblAudCrea);
            this.groupBox2.Controls.Add(this.lblCliente);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lblDocumento);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(23, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(855, 100);
            this.groupBox2.TabIndex = 434;
            this.groupBox2.TabStop = false;
            // 
            // lblDireccion
            // 
            this.lblDireccion.BackColor = System.Drawing.Color.White;
            this.lblDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDireccion.Location = new System.Drawing.Point(90, 72);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.ReadOnly = true;
            this.lblDireccion.Size = new System.Drawing.Size(341, 22);
            this.lblDireccion.TabIndex = 422;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(449, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 420;
            this.label4.Text = "Tipo documento:";
            // 
            // LblTipoDocumento
            // 
            this.LblTipoDocumento.BackColor = System.Drawing.Color.White;
            this.LblTipoDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblTipoDocumento.Location = new System.Drawing.Point(559, 73);
            this.LblTipoDocumento.Name = "LblTipoDocumento";
            this.LblTipoDocumento.Size = new System.Drawing.Size(110, 21);
            this.LblTipoDocumento.TabIndex = 421;
            this.LblTipoDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblVendedor
            // 
            this.LblVendedor.BackColor = System.Drawing.Color.White;
            this.LblVendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblVendedor.Location = new System.Drawing.Point(559, 44);
            this.LblVendedor.Name = "LblVendedor";
            this.LblVendedor.Size = new System.Drawing.Size(287, 21);
            this.LblVendedor.TabIndex = 419;
            this.LblVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(482, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 418;
            this.label6.Text = "Vendedor:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(444, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 13);
            this.label12.TabIndex = 416;
            this.label12.Text = "Fecha de emisión:";
            // 
            // LblAudCrea
            // 
            this.LblAudCrea.BackColor = System.Drawing.Color.White;
            this.LblAudCrea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblAudCrea.Location = new System.Drawing.Point(559, 15);
            this.LblAudCrea.Name = "LblAudCrea";
            this.LblAudCrea.Size = new System.Drawing.Size(110, 21);
            this.LblAudCrea.TabIndex = 417;
            this.LblAudCrea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCliente
            // 
            this.lblCliente.BackColor = System.Drawing.Color.White;
            this.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCliente.Location = new System.Drawing.Point(90, 16);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(341, 21);
            this.lblCliente.TabIndex = 122;
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 121;
            this.label1.Text = "Cliente :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(49, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 123;
            this.label11.Text = "Nro :";
            // 
            // lblDocumento
            // 
            this.lblDocumento.BackColor = System.Drawing.Color.White;
            this.lblDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDocumento.Location = new System.Drawing.Point(90, 42);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(181, 21);
            this.lblDocumento.TabIndex = 124;
            this.lblDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 125;
            this.label13.Text = "Dirección :";
            // 
            // c1NumericEdit1
            // 
            this.c1NumericEdit1.Location = new System.Drawing.Point(295, 441);
            this.c1NumericEdit1.Name = "c1NumericEdit1";
            this.c1NumericEdit1.Size = new System.Drawing.Size(94, 22);
            this.c1NumericEdit1.TabIndex = 453;
            this.c1NumericEdit1.Tag = null;
            this.c1NumericEdit1.Visible = false;
            this.c1NumericEdit1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None;
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // LblDevolucion
            // 
            this.LblDevolucion.BackColor = System.Drawing.Color.White;
            this.LblDevolucion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblDevolucion.Location = new System.Drawing.Point(661, 284);
            this.LblDevolucion.Name = "LblDevolucion";
            this.LblDevolucion.Size = new System.Drawing.Size(110, 21);
            this.LblDevolucion.TabIndex = 422;
            this.LblDevolucion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblCaja
            // 
            this.LblCaja.BackColor = System.Drawing.Color.White;
            this.LblCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblCaja.Location = new System.Drawing.Point(728, 19);
            this.LblCaja.Name = "LblCaja";
            this.LblCaja.Size = new System.Drawing.Size(147, 21);
            this.LblCaja.TabIndex = 455;
            this.LblCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(687, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 454;
            this.label16.Text = "Caja :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbOtros);
            this.groupBox1.Controls.Add(this.rbDescuentos);
            this.groupBox1.Controls.Add(this.rbNormal);
            this.groupBox1.Location = new System.Drawing.Point(561, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 52);
            this.groupBox1.TabIndex = 456;
            this.groupBox1.TabStop = false;
            // 
            // rbOtros
            // 
            this.rbOtros.AutoSize = true;
            this.rbOtros.Location = new System.Drawing.Point(254, 21);
            this.rbOtros.Name = "rbOtros";
            this.rbOtros.Size = new System.Drawing.Size(50, 17);
            this.rbOtros.TabIndex = 2;
            this.rbOtros.Text = "Otros";
            this.rbOtros.UseVisualStyleBackColor = true;
            this.rbOtros.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // rbDescuentos
            // 
            this.rbDescuentos.AutoSize = true;
            this.rbDescuentos.Location = new System.Drawing.Point(125, 21);
            this.rbDescuentos.Name = "rbDescuentos";
            this.rbDescuentos.Size = new System.Drawing.Size(82, 17);
            this.rbDescuentos.TabIndex = 1;
            this.rbDescuentos.Text = "Descuentos";
            this.rbDescuentos.UseVisualStyleBackColor = true;
            this.rbDescuentos.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Checked = true;
            this.rbNormal.Location = new System.Drawing.Point(21, 21);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(58, 17);
            this.rbNormal.TabIndex = 0;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "Normal";
            this.rbNormal.UseVisualStyleBackColor = true;
            this.rbNormal.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtDescuento);
            this.panel1.Controls.Add(this.lblMonto);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(167, 279);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 28);
            this.panel1.TabIndex = 422;
            this.panel1.Visible = false;
            // 
            // txtDescuento
            // 
            this.txtDescuento.BackColor = System.Drawing.Color.White;
            this.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescuento.Location = new System.Drawing.Point(81, 3);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(103, 22);
            this.txtDescuento.TabIndex = 458;
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged_1);
            this.txtDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuento_KeyPress_1);
            // 
            // lblMonto
            // 
            this.lblMonto.BackColor = System.Drawing.Color.White;
            this.lblMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMonto.Location = new System.Drawing.Point(243, 5);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(110, 21);
            this.lblMonto.TabIndex = 457;
            this.lblMonto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(190, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 449;
            this.label14.Text = "Monto :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 448;
            this.label8.Text = "Descuento % :";
            // 
            // NotaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LblCaja);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.LblDevolucion);
            this.Controls.Add(this.c1NumericEdit1);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.LblRUC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblEmpresa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TdgDetalleComprobante);
            this.Controls.Add(this.c1cboCia);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbComprobante);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtNumComprobante);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.TxtConcepto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.Name = "NotaCredito";
            this.Size = new System.Drawing.Size(923, 566);
            this.Load += new System.EventHandler(this.NotaCredito_Load);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.TxtConcepto, 0);
            this.Controls.SetChildIndex(this.lblNombre, 0);
            this.Controls.SetChildIndex(this.TxtNumComprobante, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.BtnBuscar, 0);
            this.Controls.SetChildIndex(this.label27, 0);
            this.Controls.SetChildIndex(this.cbComprobante, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.c1cboCia, 0);
            this.Controls.SetChildIndex(this.TdgDetalleComprobante, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.LblEmpresa, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.LblRUC, 0);
            this.Controls.SetChildIndex(this.BtnRegistrar, 0);
            this.Controls.SetChildIndex(this.c1NumericEdit1, 0);
            this.Controls.SetChildIndex(this.LblDevolucion, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.LblCaja, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.TdgDetalleComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNumComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtConcepto)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1NumericEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1Button BtnRegistrar;
        private System.Windows.Forms.Label LblRUC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblEmpresa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgDetalleComprobante;
        private C1.Win.C1List.C1Combo c1cboCia;
        private System.Windows.Forms.Label label9;
        private C1.Win.C1List.C1Combo cbComprobante;
        private System.Windows.Forms.Label label27;
        private C1.Win.C1Input.C1Button BtnBuscar;
        private System.Windows.Forms.Label label10;
        private C1.Win.C1Input.C1TextBox TxtNumComprobante;
        private System.Windows.Forms.Label lblNombre;
        private C1.Win.C1Input.C1TextBox TxtConcepto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblTipoDocumento;
        private System.Windows.Forms.Label LblVendedor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label LblAudCrea;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label label13;
        private C1.Win.C1Input.C1NumericEdit c1NumericEdit1;
        private System.Windows.Forms.ErrorProvider ErrProvider;
        private System.Windows.Forms.Label LblDevolucion;
        private System.Windows.Forms.Label LblCaja;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbOtros;
        private System.Windows.Forms.RadioButton rbDescuentos;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox lblDireccion;
        private System.Windows.Forms.TextBox txtDescuento;
    }
}
