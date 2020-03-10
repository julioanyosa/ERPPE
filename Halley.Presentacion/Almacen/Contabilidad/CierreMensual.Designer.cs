namespace Halley.Presentacion.Almacen.Contabilidad
{
    partial class CierreMensual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CierreMensual));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CboPeriodo = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.BtnCerrar = new C1.Win.C1Input.C1Button();
            this.CboAnno = new C1.Win.C1List.C1Combo();
            this.label3 = new System.Windows.Forms.Label();
            this.c1cboCia = new C1.Win.C1List.C1Combo();
            this.label14 = new System.Windows.Forms.Label();
            this.CboAlmacenHalley = new C1.Win.C1List.C1Combo();
            this.RbAlmacen = new System.Windows.Forms.RadioButton();
            this.RbProducto = new System.Windows.Forms.RadioButton();
            this.PnlProducto = new System.Windows.Forms.Panel();
            this.CboProducto = new C1.Win.C1List.C1Combo();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RbConCosto = new System.Windows.Forms.RadioButton();
            this.RBCostoCero = new System.Windows.Forms.RadioButton();
            this.TxtCantidad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtCostoUnitario = new System.Windows.Forms.TextBox();
            this.CboProducto2 = new C1.Win.C1List.C1Combo();
            this.label6 = new System.Windows.Forms.Label();
            this.Btningresar = new C1.Win.C1Input.C1Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.c1cboCia2 = new C1.Win.C1List.C1Combo();
            this.label7 = new System.Windows.Forms.Label();
            this.CboAnno2 = new C1.Win.C1List.C1Combo();
            this.label8 = new System.Windows.Forms.Label();
            this.CboPeriodo2 = new C1.Win.C1List.C1Combo();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CboPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboAnno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboAlmacenHalley)).BeginInit();
            this.PnlProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboProducto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboProducto2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboAnno2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboPeriodo2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 63);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cierre\r\nmensual\r\n(Kardex)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Periodo:";
            // 
            // CboPeriodo
            // 
            this.CboPeriodo.AddItemSeparator = ';';
            this.CboPeriodo.Caption = "";
            this.CboPeriodo.CaptionHeight = 17;
            this.CboPeriodo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboPeriodo.ColumnCaptionHeight = 17;
            this.CboPeriodo.ColumnFooterHeight = 17;
            this.CboPeriodo.ContentHeight = 17;
            this.CboPeriodo.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboPeriodo.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboPeriodo.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboPeriodo.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboPeriodo.EditorHeight = 17;
            this.CboPeriodo.Images.Add(((System.Drawing.Image)(resources.GetObject("CboPeriodo.Images"))));
            this.CboPeriodo.ItemHeight = 15;
            this.CboPeriodo.Location = new System.Drawing.Point(88, 76);
            this.CboPeriodo.MatchEntryTimeout = ((long)(2000));
            this.CboPeriodo.MaxDropDownItems = ((short)(5));
            this.CboPeriodo.MaxLength = 32767;
            this.CboPeriodo.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboPeriodo.Name = "CboPeriodo";
            this.CboPeriodo.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboPeriodo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboPeriodo.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboPeriodo.Size = new System.Drawing.Size(160, 23);
            this.CboPeriodo.TabIndex = 7;
            this.CboPeriodo.PropBag = resources.GetString("CboPeriodo.PropBag");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(7, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 389;
            this.label12.Text = "Producto:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(22, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 388;
            this.label11.Text = "Almacen:";
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCerrar.Location = new System.Drawing.Point(682, 276);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(86, 23);
            this.BtnCerrar.TabIndex = 390;
            this.BtnCerrar.Text = "Iniciar";
            this.BtnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
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
            this.CboAnno.ContentHeight = 17;
            this.CboAnno.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboAnno.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboAnno.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboAnno.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboAnno.EditorHeight = 17;
            this.CboAnno.Images.Add(((System.Drawing.Image)(resources.GetObject("CboAnno.Images"))));
            this.CboAnno.ItemHeight = 15;
            this.CboAnno.Location = new System.Drawing.Point(88, 47);
            this.CboAnno.MatchEntryTimeout = ((long)(2000));
            this.CboAnno.MaxDropDownItems = ((short)(5));
            this.CboAnno.MaxLength = 32767;
            this.CboAnno.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboAnno.Name = "CboAnno";
            this.CboAnno.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboAnno.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboAnno.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboAnno.Size = new System.Drawing.Size(82, 23);
            this.CboAnno.TabIndex = 392;
            this.CboAnno.PropBag = resources.GetString("CboAnno.PropBag");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 391;
            this.label3.Text = "Año:";
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
            this.c1cboCia.Location = new System.Drawing.Point(88, 18);
            this.c1cboCia.MatchEntryTimeout = ((long)(2000));
            this.c1cboCia.MaxDropDownItems = ((short)(10));
            this.c1cboCia.MaxLength = 32767;
            this.c1cboCia.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.c1cboCia.Name = "c1cboCia";
            this.c1cboCia.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.c1cboCia.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1cboCia.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1cboCia.Size = new System.Drawing.Size(160, 23);
            this.c1cboCia.TabIndex = 393;
            this.c1cboCia.ValueMember = "EmpresaID";
            this.c1cboCia.PropBag = resources.GetString("c1cboCia.PropBag");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(29, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 394;
            this.label14.Text = "Empresa:";
            // 
            // CboAlmacenHalley
            // 
            this.CboAlmacenHalley.AddItemSeparator = ';';
            this.CboAlmacenHalley.AutoCompletion = true;
            this.CboAlmacenHalley.AutoDropDown = true;
            this.CboAlmacenHalley.Caption = "Seleccione Almacen";
            this.CboAlmacenHalley.CaptionHeight = 17;
            this.CboAlmacenHalley.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboAlmacenHalley.ColumnCaptionHeight = 17;
            this.CboAlmacenHalley.ColumnFooterHeight = 17;
            this.CboAlmacenHalley.ColumnHeaders = false;
            this.CboAlmacenHalley.ContentHeight = 17;
            this.CboAlmacenHalley.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboAlmacenHalley.DisplayMember = "NomEmpresa";
            this.CboAlmacenHalley.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboAlmacenHalley.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboAlmacenHalley.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboAlmacenHalley.EditorHeight = 17;
            this.CboAlmacenHalley.Images.Add(((System.Drawing.Image)(resources.GetObject("CboAlmacenHalley.Images"))));
            this.CboAlmacenHalley.ItemHeight = 15;
            this.CboAlmacenHalley.Location = new System.Drawing.Point(83, 38);
            this.CboAlmacenHalley.MatchEntryTimeout = ((long)(2000));
            this.CboAlmacenHalley.MaxDropDownItems = ((short)(10));
            this.CboAlmacenHalley.MaxLength = 32767;
            this.CboAlmacenHalley.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboAlmacenHalley.Name = "CboAlmacenHalley";
            this.CboAlmacenHalley.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboAlmacenHalley.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboAlmacenHalley.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboAlmacenHalley.Size = new System.Drawing.Size(290, 23);
            this.CboAlmacenHalley.TabIndex = 413;
            this.CboAlmacenHalley.ValueMember = "EmpresaID";
            this.CboAlmacenHalley.PropBag = resources.GetString("CboAlmacenHalley.PropBag");
            // 
            // RbAlmacen
            // 
            this.RbAlmacen.AutoSize = true;
            this.RbAlmacen.Checked = true;
            this.RbAlmacen.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RbAlmacen.Location = new System.Drawing.Point(10, 16);
            this.RbAlmacen.Name = "RbAlmacen";
            this.RbAlmacen.Size = new System.Drawing.Size(89, 17);
            this.RbAlmacen.TabIndex = 414;
            this.RbAlmacen.TabStop = true;
            this.RbAlmacen.Text = "Por almacen";
            this.RbAlmacen.UseVisualStyleBackColor = true;
            this.RbAlmacen.CheckedChanged += new System.EventHandler(this.RbProducto_CheckedChanged);
            // 
            // RbProducto
            // 
            this.RbProducto.AutoSize = true;
            this.RbProducto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RbProducto.Location = new System.Drawing.Point(105, 16);
            this.RbProducto.Name = "RbProducto";
            this.RbProducto.Size = new System.Drawing.Size(94, 17);
            this.RbProducto.TabIndex = 415;
            this.RbProducto.Text = "Por Producto";
            this.RbProducto.UseVisualStyleBackColor = true;
            this.RbProducto.CheckedChanged += new System.EventHandler(this.RbProducto_CheckedChanged);
            // 
            // PnlProducto
            // 
            this.PnlProducto.Controls.Add(this.CboProducto);
            this.PnlProducto.Controls.Add(this.label12);
            this.PnlProducto.Location = new System.Drawing.Point(7, 35);
            this.PnlProducto.Name = "PnlProducto";
            this.PnlProducto.Size = new System.Drawing.Size(638, 30);
            this.PnlProducto.TabIndex = 416;
            // 
            // CboProducto
            // 
            this.CboProducto.AddItemSeparator = ';';
            this.CboProducto.Caption = "";
            this.CboProducto.CaptionHeight = 17;
            this.CboProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboProducto.ColumnCaptionHeight = 17;
            this.CboProducto.ColumnFooterHeight = 17;
            this.CboProducto.ContentHeight = 17;
            this.CboProducto.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboProducto.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboProducto.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboProducto.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboProducto.EditorHeight = 17;
            this.CboProducto.Images.Add(((System.Drawing.Image)(resources.GetObject("CboProducto.Images"))));
            this.CboProducto.ItemHeight = 15;
            this.CboProducto.Location = new System.Drawing.Point(77, 4);
            this.CboProducto.MatchEntryTimeout = ((long)(2000));
            this.CboProducto.MaxDropDownItems = ((short)(5));
            this.CboProducto.MaxLength = 32767;
            this.CboProducto.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboProducto.Name = "CboProducto";
            this.CboProducto.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboProducto.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboProducto.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboProducto.Size = new System.Drawing.Size(550, 23);
            this.CboProducto.TabIndex = 390;
            this.CboProducto.PropBag = resources.GetString("CboProducto.PropBag");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.c1cboCia);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.CboAnno);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CboPeriodo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(10, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 113);
            this.groupBox1.TabIndex = 417;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PnlProducto);
            this.groupBox2.Controls.Add(this.RbProducto);
            this.groupBox2.Controls.Add(this.RbAlmacen);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.CboAlmacenHalley);
            this.groupBox2.Location = new System.Drawing.Point(15, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(661, 84);
            this.groupBox2.TabIndex = 418;
            this.groupBox2.TabStop = false;
            // 
            // RbConCosto
            // 
            this.RbConCosto.AutoSize = true;
            this.RbConCosto.Checked = true;
            this.RbConCosto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RbConCosto.Location = new System.Drawing.Point(22, 96);
            this.RbConCosto.Name = "RbConCosto";
            this.RbConCosto.Size = new System.Drawing.Size(77, 17);
            this.RbConCosto.TabIndex = 419;
            this.RbConCosto.TabStop = true;
            this.RbConCosto.Text = "Con costo";
            this.RbConCosto.UseVisualStyleBackColor = true;
            // 
            // RBCostoCero
            // 
            this.RBCostoCero.AutoSize = true;
            this.RBCostoCero.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBCostoCero.Location = new System.Drawing.Point(145, 96);
            this.RBCostoCero.Name = "RBCostoCero";
            this.RBCostoCero.Size = new System.Drawing.Size(80, 17);
            this.RBCostoCero.TabIndex = 420;
            this.RBCostoCero.Text = "Costo cero";
            this.RBCostoCero.UseVisualStyleBackColor = true;
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.Location = new System.Drawing.Point(81, 83);
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(111, 22);
            this.TxtCantidad.TabIndex = 421;
            this.TxtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCantidad_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 395;
            this.label4.Text = "Cantidad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(205, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 423;
            this.label5.Text = "Costo unitario:";
            // 
            // TxtCostoUnitario
            // 
            this.TxtCostoUnitario.Location = new System.Drawing.Point(295, 83);
            this.TxtCostoUnitario.Name = "TxtCostoUnitario";
            this.TxtCostoUnitario.Size = new System.Drawing.Size(111, 22);
            this.TxtCostoUnitario.TabIndex = 424;
            this.TxtCostoUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCostoUnitario_KeyPress);
            // 
            // CboProducto2
            // 
            this.CboProducto2.AddItemSeparator = ';';
            this.CboProducto2.Caption = "";
            this.CboProducto2.CaptionHeight = 17;
            this.CboProducto2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboProducto2.ColumnCaptionHeight = 17;
            this.CboProducto2.ColumnFooterHeight = 17;
            this.CboProducto2.ContentHeight = 17;
            this.CboProducto2.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboProducto2.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboProducto2.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboProducto2.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboProducto2.EditorHeight = 17;
            this.CboProducto2.Images.Add(((System.Drawing.Image)(resources.GetObject("CboProducto2.Images"))));
            this.CboProducto2.ItemHeight = 15;
            this.CboProducto2.Location = new System.Drawing.Point(81, 54);
            this.CboProducto2.MatchEntryTimeout = ((long)(2000));
            this.CboProducto2.MaxDropDownItems = ((short)(5));
            this.CboProducto2.MaxLength = 32767;
            this.CboProducto2.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboProducto2.Name = "CboProducto2";
            this.CboProducto2.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboProducto2.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboProducto2.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboProducto2.Size = new System.Drawing.Size(550, 23);
            this.CboProducto2.TabIndex = 392;
            this.CboProducto2.PropBag = resources.GetString("CboProducto2.PropBag");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 391;
            this.label6.Text = "Producto:";
            // 
            // Btningresar
            // 
            this.Btningresar.Image = global::Halley.Presentacion.Properties.Resources.Add_16x16;
            this.Btningresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btningresar.Location = new System.Drawing.Point(547, 84);
            this.Btningresar.Name = "Btningresar";
            this.Btningresar.Size = new System.Drawing.Size(86, 23);
            this.Btningresar.TabIndex = 425;
            this.Btningresar.Text = "Ingresar";
            this.Btningresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btningresar.UseVisualStyleBackColor = true;
            this.Btningresar.Click += new System.EventHandler(this.Btningresar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.c1cboCia2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.CboAnno2);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.CboPeriodo2);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.Btningresar);
            this.groupBox3.Controls.Add(this.CboProducto2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.TxtCostoUnitario);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.TxtCantidad);
            this.groupBox3.Location = new System.Drawing.Point(16, 338);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(660, 131);
            this.groupBox3.TabIndex = 426;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ingreso manual";
            // 
            // c1cboCia2
            // 
            this.c1cboCia2.AddItemSeparator = ';';
            this.c1cboCia2.AutoCompletion = true;
            this.c1cboCia2.AutoDropDown = true;
            this.c1cboCia2.Caption = "";
            this.c1cboCia2.CaptionHeight = 17;
            this.c1cboCia2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.c1cboCia2.ColumnCaptionHeight = 17;
            this.c1cboCia2.ColumnFooterHeight = 17;
            this.c1cboCia2.ColumnHeaders = false;
            this.c1cboCia2.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.c1cboCia2.ContentHeight = 17;
            this.c1cboCia2.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.c1cboCia2.DisplayMember = "NomEmpresa";
            this.c1cboCia2.EditorBackColor = System.Drawing.SystemColors.Window;
            this.c1cboCia2.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1cboCia2.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.c1cboCia2.EditorHeight = 17;
            this.c1cboCia2.Images.Add(((System.Drawing.Image)(resources.GetObject("c1cboCia2.Images"))));
            this.c1cboCia2.ItemHeight = 15;
            this.c1cboCia2.Location = new System.Drawing.Point(81, 21);
            this.c1cboCia2.MatchEntryTimeout = ((long)(2000));
            this.c1cboCia2.MaxDropDownItems = ((short)(10));
            this.c1cboCia2.MaxLength = 32767;
            this.c1cboCia2.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.c1cboCia2.Name = "c1cboCia2";
            this.c1cboCia2.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.c1cboCia2.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1cboCia2.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1cboCia2.Size = new System.Drawing.Size(160, 23);
            this.c1cboCia2.TabIndex = 430;
            this.c1cboCia2.ValueMember = "EmpresaID";
            this.c1cboCia2.PropBag = resources.GetString("c1cboCia2.PropBag");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 431;
            this.label7.Text = "Empresa:";
            // 
            // CboAnno2
            // 
            this.CboAnno2.AddItemSeparator = ';';
            this.CboAnno2.Caption = "";
            this.CboAnno2.CaptionHeight = 17;
            this.CboAnno2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboAnno2.ColumnCaptionHeight = 17;
            this.CboAnno2.ColumnFooterHeight = 17;
            this.CboAnno2.ColumnWidth = 54;
            this.CboAnno2.ContentHeight = 17;
            this.CboAnno2.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboAnno2.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboAnno2.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboAnno2.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboAnno2.EditorHeight = 17;
            this.CboAnno2.Images.Add(((System.Drawing.Image)(resources.GetObject("CboAnno2.Images"))));
            this.CboAnno2.ItemHeight = 15;
            this.CboAnno2.Location = new System.Drawing.Point(296, 21);
            this.CboAnno2.MatchEntryTimeout = ((long)(2000));
            this.CboAnno2.MaxDropDownItems = ((short)(5));
            this.CboAnno2.MaxLength = 32767;
            this.CboAnno2.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboAnno2.Name = "CboAnno2";
            this.CboAnno2.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboAnno2.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboAnno2.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboAnno2.Size = new System.Drawing.Size(82, 23);
            this.CboAnno2.TabIndex = 429;
            this.CboAnno2.PropBag = resources.GetString("CboAnno2.PropBag");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(258, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 428;
            this.label8.Text = "Año:";
            // 
            // CboPeriodo2
            // 
            this.CboPeriodo2.AddItemSeparator = ';';
            this.CboPeriodo2.Caption = "";
            this.CboPeriodo2.CaptionHeight = 17;
            this.CboPeriodo2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboPeriodo2.ColumnCaptionHeight = 17;
            this.CboPeriodo2.ColumnFooterHeight = 17;
            this.CboPeriodo2.ContentHeight = 17;
            this.CboPeriodo2.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboPeriodo2.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboPeriodo2.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboPeriodo2.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboPeriodo2.EditorHeight = 17;
            this.CboPeriodo2.Images.Add(((System.Drawing.Image)(resources.GetObject("CboPeriodo2.Images"))));
            this.CboPeriodo2.ItemHeight = 15;
            this.CboPeriodo2.Location = new System.Drawing.Point(471, 21);
            this.CboPeriodo2.MatchEntryTimeout = ((long)(2000));
            this.CboPeriodo2.MaxDropDownItems = ((short)(5));
            this.CboPeriodo2.MaxLength = 32767;
            this.CboPeriodo2.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboPeriodo2.Name = "CboPeriodo2";
            this.CboPeriodo2.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboPeriodo2.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboPeriodo2.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboPeriodo2.Size = new System.Drawing.Size(160, 23);
            this.CboPeriodo2.TabIndex = 427;
            this.CboPeriodo2.PropBag = resources.GetString("CboPeriodo2.PropBag");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(399, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 426;
            this.label9.Text = "Periodo:";
            // 
            // CierreMensual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.RBCostoCero);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.RbConCosto);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "CierreMensual";
            this.Size = new System.Drawing.Size(813, 588);
            this.Load += new System.EventHandler(this.CierreMensual_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.RbConCosto, 0);
            this.Controls.SetChildIndex(this.BtnCerrar, 0);
            this.Controls.SetChildIndex(this.RBCostoCero, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.CboPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboAnno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboAlmacenHalley)).EndInit();
            this.PnlProducto.ResumeLayout(false);
            this.PnlProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboProducto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboProducto2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboAnno2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboPeriodo2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1List.C1Combo CboPeriodo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private C1.Win.C1Input.C1Button BtnCerrar;
        private C1.Win.C1List.C1Combo CboAnno;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1List.C1Combo c1cboCia;
        private System.Windows.Forms.Label label14;
        private C1.Win.C1List.C1Combo CboAlmacenHalley;
        private System.Windows.Forms.RadioButton RbAlmacen;
        private System.Windows.Forms.RadioButton RbProducto;
        private System.Windows.Forms.Panel PnlProducto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RbConCosto;
        private System.Windows.Forms.RadioButton RBCostoCero;
        private C1.Win.C1List.C1Combo CboProducto;
        private System.Windows.Forms.TextBox TxtCantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtCostoUnitario;
        private C1.Win.C1List.C1Combo CboProducto2;
        private System.Windows.Forms.Label label6;
        private C1.Win.C1Input.C1Button Btningresar;
        private System.Windows.Forms.GroupBox groupBox3;
        private C1.Win.C1List.C1Combo c1cboCia2;
        private System.Windows.Forms.Label label7;
        private C1.Win.C1List.C1Combo CboAnno2;
        private System.Windows.Forms.Label label8;
        private C1.Win.C1List.C1Combo CboPeriodo2;
        private System.Windows.Forms.Label label9;
    }
}
