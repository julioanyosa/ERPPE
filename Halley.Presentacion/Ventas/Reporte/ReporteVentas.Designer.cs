namespace Halley.Presentacion.Ventas.Reporte
{
    partial class ReporteVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteVentas));
            this.CrvResumenVentas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnGenerar = new C1.Win.C1Input.C1Button();
            this.CboCajero = new C1.Win.C1List.C1Combo();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.DtpFechaIni = new System.Windows.Forms.DateTimePicker();
            this.c1cboCia = new C1.Win.C1List.C1Combo();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CboSede = new C1.Win.C1List.C1Combo();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnImprimir = new C1.Win.C1Input.C1Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.pnlImprimir = new System.Windows.Forms.Panel();
            this.TxtEntrega12 = new C1.Win.C1Input.C1TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnCancelar = new C1.Win.C1Input.C1Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Imprimir = new C1.Win.C1Input.C1Button();
            this.TxtDineroEntregado = new C1.Win.C1Input.C1TextBox();
            this.LblCantidad = new System.Windows.Forms.Label();
            this.btnGenerar2 = new C1.Win.C1Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)(this.CboCajero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboSede)).BeginInit();
            this.pnlImprimir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEntrega12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDineroEntregado)).BeginInit();
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
            this.CrvResumenVentas.Location = new System.Drawing.Point(21, 98);
            this.CrvResumenVentas.Margin = new System.Windows.Forms.Padding(4);
            this.CrvResumenVentas.Name = "CrvResumenVentas";
            this.CrvResumenVentas.Size = new System.Drawing.Size(946, 579);
            this.CrvResumenVentas.TabIndex = 5;
            this.CrvResumenVentas.ToolPanelWidth = 267;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(903, 56);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(109, 34);
            this.btnGenerar.TabIndex = 347;
            this.btnGenerar.Text = "Consultar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // CboCajero
            // 
            this.CboCajero.AddItemSeparator = ';';
            this.CboCajero.AutoCompletion = true;
            this.CboCajero.AutoDropDown = true;
            this.CboCajero.Caption = "";
            this.CboCajero.CaptionHeight = 17;
            this.CboCajero.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboCajero.ColumnCaptionHeight = 17;
            this.CboCajero.ColumnFooterHeight = 17;
            this.CboCajero.ColumnHeaders = false;
            this.CboCajero.ContentHeight = 21;
            this.CboCajero.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboCajero.DisplayMember = "NomEmpresa";
            this.CboCajero.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboCajero.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboCajero.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboCajero.EditorHeight = 21;
            this.CboCajero.Images.Add(((System.Drawing.Image)(resources.GetObject("CboCajero.Images"))));
            this.CboCajero.ItemHeight = 15;
            this.CboCajero.Location = new System.Drawing.Point(272, 56);
            this.CboCajero.Margin = new System.Windows.Forms.Padding(4);
            this.CboCajero.MatchEntryTimeout = ((long)(2000));
            this.CboCajero.MaxDropDownItems = ((short)(10));
            this.CboCajero.MaxLength = 32767;
            this.CboCajero.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboCajero.Name = "CboCajero";
            this.CboCajero.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboCajero.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboCajero.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboCajero.Size = new System.Drawing.Size(309, 27);
            this.CboCajero.TabIndex = 352;
            this.CboCajero.ValueMember = "EmpresaID";
            this.CboCajero.PropBag = resources.GetString("CboCajero.PropBag");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(207, 66);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 19);
            this.label7.TabIndex = 351;
            this.label7.Text = "Cajero:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(765, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 19);
            this.label2.TabIndex = 357;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(589, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 19);
            this.label1.TabIndex = 356;
            this.label1.Text = "Entre:";
            // 
            // DtpFechaFin
            // 
            this.DtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaFin.Location = new System.Drawing.Point(787, 56);
            this.DtpFechaFin.Margin = new System.Windows.Forms.Padding(4);
            this.DtpFechaFin.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFechaFin.Name = "DtpFechaFin";
            this.DtpFechaFin.Size = new System.Drawing.Size(107, 26);
            this.DtpFechaFin.TabIndex = 355;
            // 
            // DtpFechaIni
            // 
            this.DtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaIni.Location = new System.Drawing.Point(647, 56);
            this.DtpFechaIni.Margin = new System.Windows.Forms.Padding(4);
            this.DtpFechaIni.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFechaIni.Name = "DtpFechaIni";
            this.DtpFechaIni.Size = new System.Drawing.Size(107, 26);
            this.DtpFechaIni.TabIndex = 354;
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
            this.c1cboCia.Location = new System.Drawing.Point(272, 13);
            this.c1cboCia.Margin = new System.Windows.Forms.Padding(4);
            this.c1cboCia.MatchEntryTimeout = ((long)(2000));
            this.c1cboCia.MaxDropDownItems = ((short)(10));
            this.c1cboCia.MaxLength = 32767;
            this.c1cboCia.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.c1cboCia.Name = "c1cboCia";
            this.c1cboCia.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.c1cboCia.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1cboCia.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1cboCia.Size = new System.Drawing.Size(213, 27);
            this.c1cboCia.TabIndex = 392;
            this.c1cboCia.ValueMember = "EmpresaID";
            this.c1cboCia.PropBag = resources.GetString("c1cboCia.PropBag");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(193, 26);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 19);
            this.label14.TabIndex = 393;
            this.label14.Text = "Empresa:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(495, 23);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 19);
            this.label8.TabIndex = 391;
            this.label8.Text = "Sede:";
            // 
            // CboSede
            // 
            this.CboSede.AddItemSeparator = ';';
            this.CboSede.AutoCompletion = true;
            this.CboSede.AutoDropDown = true;
            this.CboSede.Caption = "Seleccione Sede";
            this.CboSede.CaptionHeight = 17;
            this.CboSede.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboSede.ColumnCaptionHeight = 17;
            this.CboSede.ColumnFooterHeight = 17;
            this.CboSede.ColumnHeaders = false;
            this.CboSede.ContentHeight = 21;
            this.CboSede.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboSede.DisplayMember = "NomEmpresa";
            this.CboSede.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboSede.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboSede.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboSede.EditorHeight = 21;
            this.CboSede.Images.Add(((System.Drawing.Image)(resources.GetObject("CboSede.Images"))));
            this.CboSede.ItemHeight = 15;
            this.CboSede.Location = new System.Drawing.Point(549, 13);
            this.CboSede.Margin = new System.Windows.Forms.Padding(4);
            this.CboSede.MatchEntryTimeout = ((long)(2000));
            this.CboSede.MaxDropDownItems = ((short)(10));
            this.CboSede.MaxLength = 32767;
            this.CboSede.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboSede.Name = "CboSede";
            this.CboSede.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboSede.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboSede.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboSede.Size = new System.Drawing.Size(345, 27);
            this.CboSede.TabIndex = 390;
            this.CboSede.ValueMember = "EmpresaID";
            this.CboSede.PropBag = resources.GetString("CboSede.PropBag");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 56);
            this.label3.TabIndex = 395;
            this.label3.Text = "Cuadre\r\nde caja";
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Image = global::Halley.Presentacion.Properties.Resources.print_16x16;
            this.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImprimir.Location = new System.Drawing.Point(1020, 56);
            this.BtnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(112, 34);
            this.BtnImprimir.TabIndex = 396;
            this.BtnImprimir.Text = "Imp Total";
            this.BtnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnImprimir.UseVisualStyleBackColor = true;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // pnlImprimir
            // 
            this.pnlImprimir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlImprimir.Controls.Add(this.TxtEntrega12);
            this.pnlImprimir.Controls.Add(this.label5);
            this.pnlImprimir.Controls.Add(this.BtnCancelar);
            this.pnlImprimir.Controls.Add(this.label4);
            this.pnlImprimir.Controls.Add(this.Imprimir);
            this.pnlImprimir.Controls.Add(this.TxtDineroEntregado);
            this.pnlImprimir.Controls.Add(this.LblCantidad);
            this.pnlImprimir.Location = new System.Drawing.Point(733, 96);
            this.pnlImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.pnlImprimir.Name = "pnlImprimir";
            this.pnlImprimir.Size = new System.Drawing.Size(354, 234);
            this.pnlImprimir.TabIndex = 397;
            // 
            // TxtEntrega12
            // 
            this.TxtEntrega12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEntrega12.Location = new System.Drawing.Point(203, 115);
            this.TxtEntrega12.Margin = new System.Windows.Forms.Padding(4);
            this.TxtEntrega12.MaxLength = 17;
            this.TxtEntrega12.Name = "TxtEntrega12";
            this.TxtEntrega12.Size = new System.Drawing.Size(129, 29);
            this.TxtEntrega12.TabIndex = 375;
            this.TxtEntrega12.Tag = null;
            this.TxtEntrega12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtEntrega12.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtEntrega12_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 123);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 19);
            this.label5.TabIndex = 376;
            this.label5.Text = "entrega a las 12 pm:";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Image = global::Halley.Presentacion.Properties.Resources.cancel_16x16;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(53, 175);
            this.BtnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(107, 37);
            this.BtnCancelar.TabIndex = 374;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 50);
            this.label4.TabIndex = 373;
            this.label4.Text = "Imprimir\r\ntotales";
            // 
            // Imprimir
            // 
            this.Imprimir.Image = global::Halley.Presentacion.Properties.Resources.print_16x16;
            this.Imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Imprimir.Location = new System.Drawing.Point(203, 175);
            this.Imprimir.Margin = new System.Windows.Forms.Padding(4);
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Size = new System.Drawing.Size(107, 37);
            this.Imprimir.TabIndex = 371;
            this.Imprimir.Text = "Imprimir";
            this.Imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Imprimir.UseVisualStyleBackColor = true;
            this.Imprimir.Click += new System.EventHandler(this.Imprimir_Click);
            // 
            // TxtDineroEntregado
            // 
            this.TxtDineroEntregado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDineroEntregado.Location = new System.Drawing.Point(203, 75);
            this.TxtDineroEntregado.Margin = new System.Windows.Forms.Padding(4);
            this.TxtDineroEntregado.MaxLength = 17;
            this.TxtDineroEntregado.Name = "TxtDineroEntregado";
            this.TxtDineroEntregado.Size = new System.Drawing.Size(129, 29);
            this.TxtDineroEntregado.TabIndex = 370;
            this.TxtDineroEntregado.Tag = null;
            this.TxtDineroEntregado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtDineroEntregado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDineroEntregado_KeyPress);
            // 
            // LblCantidad
            // 
            this.LblCantidad.AutoSize = true;
            this.LblCantidad.Location = new System.Drawing.Point(5, 82);
            this.LblCantidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblCantidad.Name = "LblCantidad";
            this.LblCantidad.Size = new System.Drawing.Size(167, 19);
            this.LblCantidad.TabIndex = 372;
            this.LblCantidad.Text = "Ingrese dinero entregado:";
            // 
            // btnGenerar2
            // 
            this.btnGenerar2.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.btnGenerar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar2.Location = new System.Drawing.Point(903, 13);
            this.btnGenerar2.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerar2.Name = "btnGenerar2";
            this.btnGenerar2.Size = new System.Drawing.Size(109, 34);
            this.btnGenerar2.TabIndex = 398;
            this.btnGenerar2.Text = "no usar";
            this.btnGenerar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar2.UseVisualStyleBackColor = true;
            this.btnGenerar2.Visible = false;
            this.btnGenerar2.Click += new System.EventHandler(this.btnGenerar2_Click);
            // 
            // ReporteVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGenerar2);
            this.Controls.Add(this.pnlImprimir);
            this.Controls.Add(this.BtnImprimir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.c1cboCia);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CboSede);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpFechaFin);
            this.Controls.Add(this.DtpFechaIni);
            this.Controls.Add(this.CboCajero);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CrvResumenVentas);
            this.Controls.Add(this.btnGenerar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReporteVentas";
            this.Size = new System.Drawing.Size(1177, 737);
            this.Load += new System.EventHandler(this.ReporteVentas_Load);
            this.Controls.SetChildIndex(this.btnGenerar, 0);
            this.Controls.SetChildIndex(this.CrvResumenVentas, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.CboCajero, 0);
            this.Controls.SetChildIndex(this.DtpFechaIni, 0);
            this.Controls.SetChildIndex(this.DtpFechaFin, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.CboSede, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.c1cboCia, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.BtnImprimir, 0);
            this.Controls.SetChildIndex(this.pnlImprimir, 0);
            this.Controls.SetChildIndex(this.btnGenerar2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.CboCajero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboSede)).EndInit();
            this.pnlImprimir.ResumeLayout(false);
            this.pnlImprimir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEntrega12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDineroEntregado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrvResumenVentas;
        private C1.Win.C1Input.C1Button btnGenerar;
        private C1.Win.C1List.C1Combo CboCajero;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpFechaFin;
        private System.Windows.Forms.DateTimePicker DtpFechaIni;
        private C1.Win.C1List.C1Combo c1cboCia;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private C1.Win.C1List.C1Combo CboSede;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1Button BtnImprimir;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Panel pnlImprimir;
        private C1.Win.C1Input.C1Button BtnCancelar;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1Button Imprimir;
        private C1.Win.C1Input.C1TextBox TxtDineroEntregado;
        private System.Windows.Forms.Label LblCantidad;
        private C1.Win.C1Input.C1TextBox TxtEntrega12;
        private System.Windows.Forms.Label label5;
        private C1.Win.C1Input.C1Button btnGenerar2;
    }
}
