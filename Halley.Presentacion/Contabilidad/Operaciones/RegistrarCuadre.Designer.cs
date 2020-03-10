namespace Halley.Presentacion.Contabilidad.Operaciones
{
    partial class RegistrarCuadre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarCuadre));
            this.BtnRegistrar = new C1.Win.C1Input.C1Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtDineroEntregado = new C1.Win.C1Input.C1TextBox();
            this.LblCantidad = new System.Windows.Forms.Label();
            this.BtnVercierre = new C1.Win.C1Input.C1Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpFechaIni = new System.Windows.Forms.DateTimePicker();
            this.c1cboCia = new C1.Win.C1List.C1Combo();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CboSede = new C1.Win.C1List.C1Combo();
            this.CboCajero = new C1.Win.C1List.C1Combo();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnTotalDia = new C1.Win.C1Input.C1Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblEntregar = new System.Windows.Forms.Label();
            this.LblTotalPagos = new System.Windows.Forms.Label();
            this.LblEgreso = new System.Windows.Forms.Label();
            this.LblIngreso = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.CrvResumenVentas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DtpFechaCierre = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDineroEntregado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboSede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboCajero)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Image = global::Halley.Presentacion.Properties.Resources.save_16x16;
            this.BtnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRegistrar.Location = new System.Drawing.Point(178, 67);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(82, 25);
            this.BtnRegistrar.TabIndex = 3;
            this.BtnRegistrar.Text = "Registrar";
            this.BtnRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnGuardarCierre_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 40);
            this.label4.TabIndex = 382;
            this.label4.Text = "Registrar\r\nCuadre";
            // 
            // TxtDineroEntregado
            // 
            this.TxtDineroEntregado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDineroEntregado.Location = new System.Drawing.Point(91, 69);
            this.TxtDineroEntregado.MaxLength = 17;
            this.TxtDineroEntregado.Name = "TxtDineroEntregado";
            this.TxtDineroEntregado.Size = new System.Drawing.Size(81, 23);
            this.TxtDineroEntregado.TabIndex = 2;
            this.TxtDineroEntregado.Tag = null;
            this.TxtDineroEntregado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LblCantidad
            // 
            this.LblCantidad.AutoSize = true;
            this.LblCantidad.Location = new System.Drawing.Point(3, 68);
            this.LblCantidad.Name = "LblCantidad";
            this.LblCantidad.Size = new System.Drawing.Size(82, 26);
            this.LblCantidad.TabIndex = 381;
            this.LblCantidad.Text = "Ingrese dinero\r\nentregado:";
            this.LblCantidad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BtnVercierre
            // 
            this.BtnVercierre.Image = global::Halley.Presentacion.Properties.Resources.Explosion_16x16;
            this.BtnVercierre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnVercierre.Location = new System.Drawing.Point(1, 66);
            this.BtnVercierre.Name = "BtnVercierre";
            this.BtnVercierre.Size = new System.Drawing.Size(82, 25);
            this.BtnVercierre.TabIndex = 1;
            this.BtnVercierre.Text = "Ver Cierre";
            this.BtnVercierre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnVercierre.UseVisualStyleBackColor = true;
            this.BtnVercierre.Click += new System.EventHandler(this.BtnVercierre_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 401;
            this.label1.Text = "Fecha:";
            // 
            // DtpFechaIni
            // 
            this.DtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaIni.Location = new System.Drawing.Point(91, 17);
            this.DtpFechaIni.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFechaIni.Name = "DtpFechaIni";
            this.DtpFechaIni.Size = new System.Drawing.Size(81, 22);
            this.DtpFechaIni.TabIndex = 0;
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
            this.c1cboCia.Location = new System.Drawing.Point(169, 3);
            this.c1cboCia.MatchEntryTimeout = ((long)(2000));
            this.c1cboCia.MaxDropDownItems = ((short)(10));
            this.c1cboCia.MaxLength = 32767;
            this.c1cboCia.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.c1cboCia.Name = "c1cboCia";
            this.c1cboCia.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.c1cboCia.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1cboCia.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1cboCia.Size = new System.Drawing.Size(160, 23);
            this.c1cboCia.TabIndex = 1;
            this.c1cboCia.ValueMember = "EmpresaID";
            this.c1cboCia.PropBag = resources.GetString("c1cboCia.PropBag");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(110, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 407;
            this.label14.Text = "Empresa:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(128, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 405;
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
            this.CboSede.ContentHeight = 17;
            this.CboSede.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboSede.DisplayMember = "NomEmpresa";
            this.CboSede.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboSede.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboSede.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboSede.EditorHeight = 17;
            this.CboSede.Images.Add(((System.Drawing.Image)(resources.GetObject("CboSede.Images"))));
            this.CboSede.ItemHeight = 15;
            this.CboSede.Location = new System.Drawing.Point(169, 62);
            this.CboSede.MatchEntryTimeout = ((long)(2000));
            this.CboSede.MaxDropDownItems = ((short)(10));
            this.CboSede.MaxLength = 32767;
            this.CboSede.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboSede.Name = "CboSede";
            this.CboSede.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboSede.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboSede.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboSede.Size = new System.Drawing.Size(259, 23);
            this.CboSede.TabIndex = 2;
            this.CboSede.ValueMember = "EmpresaID";
            this.CboSede.PropBag = resources.GetString("CboSede.PropBag");
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
            this.CboCajero.ContentHeight = 17;
            this.CboCajero.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboCajero.DisplayMember = "NomEmpresa";
            this.CboCajero.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboCajero.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboCajero.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboCajero.EditorHeight = 17;
            this.CboCajero.Images.Add(((System.Drawing.Image)(resources.GetObject("CboCajero.Images"))));
            this.CboCajero.ItemHeight = 15;
            this.CboCajero.Location = new System.Drawing.Point(169, 33);
            this.CboCajero.MatchEntryTimeout = ((long)(2000));
            this.CboCajero.MaxDropDownItems = ((short)(10));
            this.CboCajero.MaxLength = 32767;
            this.CboCajero.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboCajero.Name = "CboCajero";
            this.CboCajero.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboCajero.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboCajero.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboCajero.Size = new System.Drawing.Size(232, 23);
            this.CboCajero.TabIndex = 403;
            this.CboCajero.ValueMember = "EmpresaID";
            this.CboCajero.PropBag = resources.GetString("CboCajero.PropBag");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(120, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 402;
            this.label7.Text = "Cajero:";
            // 
            // BtnTotalDia
            // 
            this.BtnTotalDia.Image = global::Halley.Presentacion.Properties.Resources.Adelantos16x16;
            this.BtnTotalDia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTotalDia.Location = new System.Drawing.Point(178, 17);
            this.BtnTotalDia.Name = "BtnTotalDia";
            this.BtnTotalDia.Size = new System.Drawing.Size(82, 25);
            this.BtnTotalDia.TabIndex = 1;
            this.BtnTotalDia.Text = "Ver total";
            this.BtnTotalDia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnTotalDia.UseVisualStyleBackColor = true;
            this.BtnTotalDia.Click += new System.EventHandler(this.BtnTotalDia_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 410;
            this.label2.Text = "Ingreso:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 412;
            this.label3.Text = "Egreso:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 414;
            this.label5.Text = "Total pagos:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 415;
            this.label6.Text = "Total Entregar:";
            // 
            // LblEntregar
            // 
            this.LblEntregar.BackColor = System.Drawing.SystemColors.Window;
            this.LblEntregar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblEntregar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEntregar.Location = new System.Drawing.Point(91, 42);
            this.LblEntregar.Name = "LblEntregar";
            this.LblEntregar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblEntregar.Size = new System.Drawing.Size(81, 19);
            this.LblEntregar.TabIndex = 416;
            this.LblEntregar.Text = "0.00";
            // 
            // LblTotalPagos
            // 
            this.LblTotalPagos.Location = new System.Drawing.Point(135, 69);
            this.LblTotalPagos.Name = "LblTotalPagos";
            this.LblTotalPagos.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblTotalPagos.Size = new System.Drawing.Size(96, 13);
            this.LblTotalPagos.TabIndex = 417;
            this.LblTotalPagos.Text = "0.00";
            // 
            // LblEgreso
            // 
            this.LblEgreso.ForeColor = System.Drawing.Color.Red;
            this.LblEgreso.Location = new System.Drawing.Point(135, 44);
            this.LblEgreso.Name = "LblEgreso";
            this.LblEgreso.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblEgreso.Size = new System.Drawing.Size(96, 13);
            this.LblEgreso.TabIndex = 418;
            this.LblEgreso.Text = "0.00";
            // 
            // LblIngreso
            // 
            this.LblIngreso.Location = new System.Drawing.Point(135, 18);
            this.LblIngreso.Name = "LblIngreso";
            this.LblIngreso.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblIngreso.Size = new System.Drawing.Size(96, 13);
            this.LblIngreso.TabIndex = 419;
            this.LblIngreso.Text = "0.00";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblIngreso);
            this.groupBox1.Controls.Add(this.LblEgreso);
            this.groupBox1.Controls.Add(this.LblTotalPagos);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(434, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 98);
            this.groupBox1.TabIndex = 420;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de caja";
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // CrvResumenVentas
            // 
            this.CrvResumenVentas.ActiveViewIndex = -1;
            this.CrvResumenVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CrvResumenVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrvResumenVentas.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrvResumenVentas.Location = new System.Drawing.Point(3, 104);
            this.CrvResumenVentas.Name = "CrvResumenVentas";
            this.CrvResumenVentas.Size = new System.Drawing.Size(1042, 361);
            this.CrvResumenVentas.TabIndex = 3;
            this.CrvResumenVentas.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtDineroEntregado);
            this.groupBox2.Controls.Add(this.LblCantidad);
            this.groupBox2.Controls.Add(this.BtnRegistrar);
            this.groupBox2.Controls.Add(this.LblEntregar);
            this.groupBox2.Controls.Add(this.BtnTotalDia);
            this.groupBox2.Controls.Add(this.DtpFechaIni);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(683, -1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 99);
            this.groupBox2.TabIndex = 422;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registrar";
            // 
            // DtpFechaCierre
            // 
            this.DtpFechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaCierre.Location = new System.Drawing.Point(4, 41);
            this.DtpFechaCierre.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFechaCierre.Name = "DtpFechaCierre";
            this.DtpFechaCierre.Size = new System.Drawing.Size(76, 22);
            this.DtpFechaCierre.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 26);
            this.label9.TabIndex = 424;
            this.label9.Text = "Ver fecha\r\ncierre";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.DtpFechaCierre);
            this.groupBox3.Controls.Add(this.BtnVercierre);
            this.groupBox3.Location = new System.Drawing.Point(956, -1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(90, 99);
            this.groupBox3.TabIndex = 425;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Reporte";
            // 
            // RegistrarCuadre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CrvResumenVentas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.c1cboCia);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CboSede);
            this.Controls.Add(this.CboCajero);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Name = "RegistrarCuadre";
            this.Size = new System.Drawing.Size(1048, 483);
            this.Load += new System.EventHandler(this.RegistrarCuadre_Load);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.CboCajero, 0);
            this.Controls.SetChildIndex(this.CboSede, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.c1cboCia, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.CrvResumenVentas, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.TxtDineroEntregado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboSede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboCajero)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1Button BtnRegistrar;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1TextBox TxtDineroEntregado;
        private System.Windows.Forms.Label LblCantidad;
        private C1.Win.C1Input.C1Button BtnVercierre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpFechaIni;
        private C1.Win.C1List.C1Combo c1cboCia;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private C1.Win.C1List.C1Combo CboSede;
        private C1.Win.C1List.C1Combo CboCajero;
        private System.Windows.Forms.Label label7;
        private C1.Win.C1Input.C1Button BtnTotalDia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblEntregar;
        private System.Windows.Forms.Label LblTotalPagos;
        private System.Windows.Forms.Label LblEgreso;
        private System.Windows.Forms.Label LblIngreso;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ErrorProvider ErrProvider;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrvResumenVentas;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker DtpFechaCierre;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
