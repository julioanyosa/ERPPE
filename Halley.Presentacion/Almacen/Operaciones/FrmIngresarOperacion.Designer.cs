namespace Halley.Presentacion.Almacen.Operaciones
{
    partial class FrmIngresarOperacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIngresarOperacion));
            this.CboMovimiento = new C1.Win.C1List.C1Combo();
            this.CboTipoDocumento = new C1.Win.C1List.C1Combo();
            this.CboAlmacen = new C1.Win.C1List.C1Combo();
            this.CboProducto = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CboSede = new C1.Win.C1List.C1Combo();
            this.TxtCantidad = new C1.Win.C1Input.C1TextBox();
            this.CboOperacion = new C1.Win.C1List.C1Combo();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtSerie = new C1.Win.C1Input.C1TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtNumero = new C1.Win.C1Input.C1TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtCostoUnitario = new C1.Win.C1Input.C1TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnIngresar = new C1.Win.C1Input.C1Button();
            this.BtnCerrar = new C1.Win.C1Input.C1Button();
            this.Errp = new System.Windows.Forms.ErrorProvider(this.components);
            this.DtFecha = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnTipoDocumento = new C1.Win.C1Input.C1Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnAgregar = new C1.Win.C1Input.C1Button();
            this.TdgProductos = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnMovimiento = new C1.Win.C1Input.C1Button();
            this.BtnOperacion = new C1.Win.C1Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)(this.CboMovimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboAlmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboSede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboOperacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSerie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNumero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCostoUnitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Errp)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TdgProductos)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // CboMovimiento
            // 
            this.CboMovimiento.AddItemSeparator = ';';
            this.CboMovimiento.AutoCompletion = true;
            this.CboMovimiento.AutoSelect = true;
            this.CboMovimiento.Caption = "";
            this.CboMovimiento.CaptionHeight = 17;
            this.CboMovimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboMovimiento.ColumnCaptionHeight = 17;
            this.CboMovimiento.ColumnFooterHeight = 17;
            this.CboMovimiento.ContentHeight = 15;
            this.CboMovimiento.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboMovimiento.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboMovimiento.EditorFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboMovimiento.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboMovimiento.EditorHeight = 15;
            this.CboMovimiento.Images.Add(((System.Drawing.Image)(resources.GetObject("CboMovimiento.Images"))));
            this.CboMovimiento.ItemHeight = 15;
            this.CboMovimiento.Location = new System.Drawing.Point(109, 21);
            this.CboMovimiento.MatchEntryTimeout = ((long)(2000));
            this.CboMovimiento.MaxDropDownItems = ((short)(5));
            this.CboMovimiento.MaxLength = 32767;
            this.CboMovimiento.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboMovimiento.Name = "CboMovimiento";
            this.CboMovimiento.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboMovimiento.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboMovimiento.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboMovimiento.Size = new System.Drawing.Size(304, 21);
            this.CboMovimiento.TabIndex = 0;
            this.CboMovimiento.PropBag = resources.GetString("CboMovimiento.PropBag");
            // 
            // CboTipoDocumento
            // 
            this.CboTipoDocumento.AddItemSeparator = ';';
            this.CboTipoDocumento.AutoCompletion = true;
            this.CboTipoDocumento.AutoSelect = true;
            this.CboTipoDocumento.Caption = "";
            this.CboTipoDocumento.CaptionHeight = 17;
            this.CboTipoDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboTipoDocumento.ColumnCaptionHeight = 30;
            this.CboTipoDocumento.ColumnFooterHeight = 17;
            this.CboTipoDocumento.ContentHeight = 15;
            this.CboTipoDocumento.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboTipoDocumento.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboTipoDocumento.EditorFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTipoDocumento.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboTipoDocumento.EditorHeight = 15;
            this.CboTipoDocumento.Images.Add(((System.Drawing.Image)(resources.GetObject("CboTipoDocumento.Images"))));
            this.CboTipoDocumento.ItemHeight = 15;
            this.CboTipoDocumento.Location = new System.Drawing.Point(109, 21);
            this.CboTipoDocumento.MatchEntryTimeout = ((long)(2000));
            this.CboTipoDocumento.MaxDropDownItems = ((short)(5));
            this.CboTipoDocumento.MaxLength = 32767;
            this.CboTipoDocumento.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboTipoDocumento.Name = "CboTipoDocumento";
            this.CboTipoDocumento.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboTipoDocumento.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboTipoDocumento.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboTipoDocumento.Size = new System.Drawing.Size(304, 21);
            this.CboTipoDocumento.TabIndex = 0;
            this.CboTipoDocumento.PropBag = resources.GetString("CboTipoDocumento.PropBag");
            // 
            // CboAlmacen
            // 
            this.CboAlmacen.AddItemSeparator = ';';
            this.CboAlmacen.AutoCompletion = true;
            this.CboAlmacen.AutoDropDown = true;
            this.CboAlmacen.AutoSelect = true;
            this.CboAlmacen.Caption = "";
            this.CboAlmacen.CaptionHeight = 17;
            this.CboAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboAlmacen.ColumnCaptionHeight = 17;
            this.CboAlmacen.ColumnFooterHeight = 17;
            this.CboAlmacen.ColumnHeaders = false;
            this.CboAlmacen.ContentHeight = 17;
            this.CboAlmacen.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboAlmacen.DisplayMember = "NomEmpresa";
            this.CboAlmacen.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboAlmacen.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboAlmacen.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboAlmacen.EditorHeight = 17;
            this.CboAlmacen.Images.Add(((System.Drawing.Image)(resources.GetObject("CboAlmacen.Images"))));
            this.CboAlmacen.ItemHeight = 15;
            this.CboAlmacen.Location = new System.Drawing.Point(528, 41);
            this.CboAlmacen.MatchEntryTimeout = ((long)(2000));
            this.CboAlmacen.MaxDropDownItems = ((short)(10));
            this.CboAlmacen.MaxLength = 32767;
            this.CboAlmacen.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboAlmacen.Name = "CboAlmacen";
            this.CboAlmacen.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboAlmacen.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboAlmacen.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboAlmacen.Size = new System.Drawing.Size(180, 23);
            this.CboAlmacen.TabIndex = 2;
            this.CboAlmacen.ValueMember = "EmpresaID";
            this.CboAlmacen.PropBag = resources.GetString("CboAlmacen.PropBag");
            // 
            // CboProducto
            // 
            this.CboProducto.AddItemSeparator = ';';
            this.CboProducto.AutoCompletion = true;
            this.CboProducto.AutoDropDown = true;
            this.CboProducto.AutoSelect = true;
            this.CboProducto.Caption = "";
            this.CboProducto.CaptionHeight = 17;
            this.CboProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboProducto.ColumnCaptionHeight = 17;
            this.CboProducto.ColumnFooterHeight = 17;
            this.CboProducto.ColumnHeaders = false;
            this.CboProducto.ContentHeight = 17;
            this.CboProducto.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboProducto.DisplayMember = "NomEmpresa";
            this.CboProducto.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboProducto.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboProducto.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboProducto.EditorHeight = 17;
            this.CboProducto.Images.Add(((System.Drawing.Image)(resources.GetObject("CboProducto.Images"))));
            this.CboProducto.ItemHeight = 15;
            this.CboProducto.Location = new System.Drawing.Point(109, 44);
            this.CboProducto.MatchEntryTimeout = ((long)(2000));
            this.CboProducto.MaxDropDownItems = ((short)(10));
            this.CboProducto.MaxLength = 32767;
            this.CboProducto.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboProducto.Name = "CboProducto";
            this.CboProducto.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboProducto.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboProducto.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboProducto.Size = new System.Drawing.Size(322, 23);
            this.CboProducto.TabIndex = 1;
            this.CboProducto.ValueMember = "EmpresaID";
            this.CboProducto.SelectedValueChanged += new System.EventHandler(this.CboProducto_SelectedValueChanged);
            this.CboProducto.PropBag = resources.GetString("CboProducto.PropBag");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(45, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 385;
            this.label12.Text = "Producto:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(467, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 384;
            this.label11.Text = "Almacen:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(68, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 383;
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
            this.CboSede.Location = new System.Drawing.Point(109, 15);
            this.CboSede.MatchEntryTimeout = ((long)(2000));
            this.CboSede.MaxDropDownItems = ((short)(10));
            this.CboSede.MaxLength = 32767;
            this.CboSede.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboSede.Name = "CboSede";
            this.CboSede.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboSede.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboSede.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboSede.Size = new System.Drawing.Size(277, 23);
            this.CboSede.TabIndex = 1;
            this.CboSede.ValueMember = "EmpresaID";
            this.CboSede.SelectedValueChanged += new System.EventHandler(this.CboSede_SelectedValueChanged);
            this.CboSede.PropBag = resources.GetString("CboSede.PropBag");
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCantidad.Location = new System.Drawing.Point(346, 72);
            this.TxtCantidad.MaxLength = 15;
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(85, 20);
            this.TxtCantidad.TabIndex = 4;
            this.TxtCantidad.Tag = null;
            this.TxtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtCantidad.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtCantidad.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.TxtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCantidad_KeyPress);
            // 
            // CboOperacion
            // 
            this.CboOperacion.AddItemSeparator = ';';
            this.CboOperacion.AutoCompletion = true;
            this.CboOperacion.AutoSelect = true;
            this.CboOperacion.Caption = "";
            this.CboOperacion.CaptionHeight = 17;
            this.CboOperacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboOperacion.ColumnCaptionHeight = 17;
            this.CboOperacion.ColumnFooterHeight = 17;
            this.CboOperacion.ContentHeight = 15;
            this.CboOperacion.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboOperacion.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboOperacion.EditorFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboOperacion.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboOperacion.EditorHeight = 15;
            this.CboOperacion.Images.Add(((System.Drawing.Image)(resources.GetObject("CboOperacion.Images"))));
            this.CboOperacion.ItemHeight = 15;
            this.CboOperacion.Location = new System.Drawing.Point(109, 48);
            this.CboOperacion.MatchEntryTimeout = ((long)(2000));
            this.CboOperacion.MaxDropDownItems = ((short)(5));
            this.CboOperacion.MaxLength = 32767;
            this.CboOperacion.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboOperacion.Name = "CboOperacion";
            this.CboOperacion.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboOperacion.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboOperacion.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboOperacion.Size = new System.Drawing.Size(304, 21);
            this.CboOperacion.TabIndex = 2;
            this.CboOperacion.SelectedValueChanged += new System.EventHandler(this.CboOperacion_SelectedValueChanged);
            this.CboOperacion.PropBag = resources.GetString("CboOperacion.PropBag");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 411;
            this.label1.Text = "Movimiento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 412;
            this.label2.Text = "Tipo documento:";
            // 
            // TxtSerie
            // 
            this.TxtSerie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtSerie.Location = new System.Drawing.Point(109, 52);
            this.TxtSerie.MaxLength = 8;
            this.TxtSerie.Name = "TxtSerie";
            this.TxtSerie.Size = new System.Drawing.Size(57, 20);
            this.TxtSerie.TabIndex = 1;
            this.TxtSerie.Tag = null;
            this.TxtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtSerie.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtSerie.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(283, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 414;
            this.label3.Text = "Cantidad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(68, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 415;
            this.label4.Text = "Serie:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(172, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 417;
            this.label5.Text = "Numero:";
            // 
            // TxtNumero
            // 
            this.TxtNumero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNumero.Location = new System.Drawing.Point(231, 50);
            this.TxtNumero.MaxLength = 7;
            this.TxtNumero.Name = "TxtNumero";
            this.TxtNumero.Size = new System.Drawing.Size(85, 20);
            this.TxtNumero.TabIndex = 2;
            this.TxtNumero.Tag = null;
            this.TxtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtNumero.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtNumero.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.TxtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNumero_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(40, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 418;
            this.label6.Text = "Operacion:";
            // 
            // TxtCostoUnitario
            // 
            this.TxtCostoUnitario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtCostoUnitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCostoUnitario.Location = new System.Drawing.Point(109, 73);
            this.TxtCostoUnitario.MaxLength = 15;
            this.TxtCostoUnitario.Name = "TxtCostoUnitario";
            this.TxtCostoUnitario.Size = new System.Drawing.Size(85, 20);
            this.TxtCostoUnitario.TabIndex = 4;
            this.TxtCostoUnitario.Tag = null;
            this.TxtCostoUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtCostoUnitario.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtCostoUnitario.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.TxtCostoUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCostoUnitario_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 420;
            this.label7.Text = "Costo unitario:";
            // 
            // BtnIngresar
            // 
            this.BtnIngresar.Image = global::Halley.Presentacion.Properties.Resources.agregar_16x16;
            this.BtnIngresar.Location = new System.Drawing.Point(851, 421);
            this.BtnIngresar.Name = "BtnIngresar";
            this.BtnIngresar.Size = new System.Drawing.Size(86, 23);
            this.BtnIngresar.TabIndex = 3;
            this.BtnIngresar.Text = "Ingresar";
            this.BtnIngresar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnIngresar.UseVisualStyleBackColor = true;
            this.BtnIngresar.Click += new System.EventHandler(this.BtnIngresar_Click);
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCerrar.Image = global::Halley.Presentacion.Properties.Resources.cerrar_16x16;
            this.BtnCerrar.Location = new System.Drawing.Point(759, 421);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(86, 23);
            this.BtnCerrar.TabIndex = 4;
            this.BtnCerrar.Text = "Cerrar";
            this.BtnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // Errp
            // 
            this.Errp.ContainerControl = this;
            // 
            // DtFecha
            // 
            this.DtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFecha.Location = new System.Drawing.Point(109, 75);
            this.DtFecha.Name = "DtFecha";
            this.DtFecha.Size = new System.Drawing.Size(85, 22);
            this.DtFecha.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(63, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 422;
            this.label9.Text = "Fecha:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnTipoDocumento);
            this.groupBox1.Controls.Add(this.TxtSerie);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtNumero);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.CboTipoDocumento);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(482, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del documento";
            // 
            // BtnTipoDocumento
            // 
            this.BtnTipoDocumento.Image = global::Halley.Presentacion.Properties.Resources.Mantenimiento_16x16;
            this.BtnTipoDocumento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTipoDocumento.Location = new System.Drawing.Point(416, 21);
            this.BtnTipoDocumento.Name = "BtnTipoDocumento";
            this.BtnTipoDocumento.Size = new System.Drawing.Size(45, 23);
            this.BtnTipoDocumento.TabIndex = 418;
            this.BtnTipoDocumento.Text = "...";
            this.BtnTipoDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnTipoDocumento.UseVisualStyleBackColor = true;
            this.BtnTipoDocumento.Click += new System.EventHandler(this.BtnTipoDocumento_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnAgregar);
            this.groupBox2.Controls.Add(this.TdgProductos);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.TxtCostoUnitario);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.TxtCantidad);
            this.groupBox2.Controls.Add(this.CboProducto);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.CboSede);
            this.groupBox2.Controls.Add(this.CboAlmacen);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(12, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(931, 283);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Producto";
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Image = global::Halley.Presentacion.Properties.Resources.Add_16x16;
            this.BtnAgregar.Location = new System.Drawing.Point(622, 69);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(86, 23);
            this.BtnAgregar.TabIndex = 5;
            this.BtnAgregar.Text = "&Agregar";
            this.BtnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // TdgProductos
            // 
            this.TdgProductos.AllowDelete = true;
            this.TdgProductos.AlternatingRows = true;
            this.TdgProductos.CaptionHeight = 17;
            this.TdgProductos.EmptyRows = true;
            this.TdgProductos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TdgProductos.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgProductos.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgProductos.Images"))));
            this.TdgProductos.LinesPerRow = 2;
            this.TdgProductos.Location = new System.Drawing.Point(11, 99);
            this.TdgProductos.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightCell;
            this.TdgProductos.Name = "TdgProductos";
            this.TdgProductos.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgProductos.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgProductos.PreviewInfo.ZoomFactor = 75D;
            this.TdgProductos.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgProductos.PrintInfo.PageSettings")));
            this.TdgProductos.RowHeight = 15;
            this.TdgProductos.Size = new System.Drawing.Size(914, 167);
            this.TdgProductos.TabIndex = 421;
            this.TdgProductos.Text = "c1TrueDBGrid1";
            this.TdgProductos.PropBag = resources.GetString("TdgProductos.PropBag");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnMovimiento);
            this.groupBox3.Controls.Add(this.BtnOperacion);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.DtFecha);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.CboOperacion);
            this.groupBox3.Controls.Add(this.CboMovimiento);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(464, 114);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos del movimiento";
            // 
            // BtnMovimiento
            // 
            this.BtnMovimiento.Image = global::Halley.Presentacion.Properties.Resources.Mantenimiento_16x16;
            this.BtnMovimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMovimiento.Location = new System.Drawing.Point(416, 19);
            this.BtnMovimiento.Name = "BtnMovimiento";
            this.BtnMovimiento.Size = new System.Drawing.Size(45, 23);
            this.BtnMovimiento.TabIndex = 7;
            this.BtnMovimiento.Text = "...";
            this.BtnMovimiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnMovimiento.UseVisualStyleBackColor = true;
            this.BtnMovimiento.Click += new System.EventHandler(this.BtnMovimiento_Click);
            // 
            // BtnOperacion
            // 
            this.BtnOperacion.Image = global::Halley.Presentacion.Properties.Resources.Mantenimiento_16x16;
            this.BtnOperacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOperacion.Location = new System.Drawing.Point(416, 48);
            this.BtnOperacion.Name = "BtnOperacion";
            this.BtnOperacion.Size = new System.Drawing.Size(45, 23);
            this.BtnOperacion.TabIndex = 8;
            this.BtnOperacion.Text = "...";
            this.BtnOperacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOperacion.UseVisualStyleBackColor = true;
            this.BtnOperacion.Click += new System.EventHandler(this.BtnOperacion_Click);
            // 
            // FrmIngresarOperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCerrar;
            this.ClientSize = new System.Drawing.Size(960, 451);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnIngresar);
            this.Controls.Add(this.BtnCerrar);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmIngresarOperacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ingreso manual de operaciones en kardex";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmIngresarOperacion_FormClosing);
            this.Load += new System.EventHandler(this.FrmIngresarOperacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CboMovimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboAlmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboSede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboOperacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSerie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNumero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCostoUnitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Errp)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TdgProductos)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1List.C1Combo CboMovimiento;
        private C1.Win.C1List.C1Combo CboTipoDocumento;
        private C1.Win.C1List.C1Combo CboAlmacen;
        private C1.Win.C1List.C1Combo CboProducto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private C1.Win.C1List.C1Combo CboSede;
        private C1.Win.C1Input.C1TextBox TxtCantidad;
        private C1.Win.C1List.C1Combo CboOperacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1TextBox TxtSerie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private C1.Win.C1Input.C1TextBox TxtNumero;
        private System.Windows.Forms.Label label6;
        private C1.Win.C1Input.C1TextBox TxtCostoUnitario;
        private System.Windows.Forms.Label label7;
        private C1.Win.C1Input.C1Button BtnIngresar;
        private C1.Win.C1Input.C1Button BtnCerrar;
        private System.Windows.Forms.ErrorProvider Errp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker DtFecha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private C1.Win.C1Input.C1Button BtnMovimiento;
        private C1.Win.C1Input.C1Button BtnOperacion;
        private C1.Win.C1Input.C1Button BtnTipoDocumento;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgProductos;
        private C1.Win.C1Input.C1Button BtnAgregar;
    }
}