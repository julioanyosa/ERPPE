namespace Halley.Presentacion.Ventas.VentasPavo
{
    partial class ListOrdenPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListOrdenPedido));
            this.tdbgPedidos = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.cbProducto = new C1.Win.C1List.C1Combo();
            this.cbFormaPago = new C1.Win.C1List.C1Combo();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTipoPago = new C1.Win.C1List.C1Combo();
            this.label3 = new System.Windows.Forms.Label();
            this.cbComprobante = new C1.Win.C1List.C1Combo();
            this.label4 = new System.Windows.Forms.Label();
            this.chkExterno = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelar = new C1.Win.C1Input.C1Button();
            this.btnRegistrar = new C1.Win.C1Input.C1Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnEliminarRegistro = new C1.Win.C1Input.C1Button();
            this.cbAgregarLinea = new C1.Win.C1Input.C1Button();
            this.lblTotCantidad = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblIGV = new System.Windows.Forms.Label();
            this.lblTotPagar = new System.Windows.Forms.Label();
            this.lblNumPedido = new System.Windows.Forms.Label();
            this.c1NumericEdit1 = new C1.Win.C1Input.C1NumericEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtComentario = new C1.Win.C1Input.C1TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ucCliente = new Halley.Presentacion.Ventas.UseCliente();
            this.errValidar = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnStock = new C1.Win.C1Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFormaPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTipoPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1NumericEdit1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComentario)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errValidar)).BeginInit();
            this.SuspendLayout();
            // 
            // tdbgPedidos
            // 
            this.tdbgPedidos.Caption = "REGISTRO DE PEDIDOS";
            this.tdbgPedidos.CaptionHeight = 17;
            this.tdbgPedidos.CausesValidation = false;
            this.tdbgPedidos.ColumnFooters = true;
            this.tdbgPedidos.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveUp;
            this.tdbgPedidos.EmptyRows = true;
            this.tdbgPedidos.ExtendRightColumn = true;
            this.tdbgPedidos.GroupByCaption = "Drag a column header here to group by that column";
            this.tdbgPedidos.Images.Add(((System.Drawing.Image)(resources.GetObject("tdbgPedidos.Images"))));
            this.tdbgPedidos.Location = new System.Drawing.Point(24, 235);
            this.tdbgPedidos.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.tdbgPedidos.Name = "tdbgPedidos";
            this.tdbgPedidos.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdbgPedidos.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdbgPedidos.PreviewInfo.ZoomFactor = 75D;
            this.tdbgPedidos.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdbgPedidos.PrintInfo.PageSettings")));
            this.tdbgPedidos.RowHeight = 18;
            this.tdbgPedidos.Size = new System.Drawing.Size(982, 215);
            this.tdbgPedidos.TabIndex = 1;
            this.tdbgPedidos.Text = "Productos Genéricos";
            this.tdbgPedidos.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2007Blue;
            this.tdbgPedidos.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.tdbgPedidos_AfterColUpdate);
            this.tdbgPedidos.AfterUpdate += new System.EventHandler(this.tdbgPedidos_AfterUpdate);
            this.tdbgPedidos.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.tdbgPedidos_BeforeColUpdate);
            this.tdbgPedidos.PropBag = resources.GetString("tdbgPedidos.PropBag");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Producto :";
            // 
            // cbProducto
            // 
            this.cbProducto.AddItemSeparator = ';';
            this.cbProducto.Caption = "";
            this.cbProducto.CaptionHeight = 17;
            this.cbProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbProducto.ColumnCaptionHeight = 17;
            this.cbProducto.ColumnFooterHeight = 17;
            this.cbProducto.ColumnHeaders = false;
            this.cbProducto.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cbProducto.ContentHeight = 17;
            this.cbProducto.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbProducto.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbProducto.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProducto.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbProducto.EditorHeight = 17;
            this.cbProducto.ExtendRightColumn = true;
            this.cbProducto.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard;
            this.cbProducto.Images.Add(((System.Drawing.Image)(resources.GetObject("cbProducto.Images"))));
            this.cbProducto.ItemHeight = 15;
            this.cbProducto.Location = new System.Drawing.Point(78, 18);
            this.cbProducto.MatchEntryTimeout = ((long)(2000));
            this.cbProducto.MaxDropDownItems = ((short)(5));
            this.cbProducto.MaxLength = 32767;
            this.cbProducto.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbProducto.Name = "cbProducto";
            this.cbProducto.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cbProducto.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cbProducto.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbProducto.Size = new System.Drawing.Size(342, 23);
            this.cbProducto.TabIndex = 62;
            this.cbProducto.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.cbProducto.PropBag = resources.GetString("cbProducto.PropBag");
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
            this.cbFormaPago.Enabled = false;
            this.cbFormaPago.ExtendRightColumn = true;
            this.cbFormaPago.Images.Add(((System.Drawing.Image)(resources.GetObject("cbFormaPago.Images"))));
            this.cbFormaPago.ItemHeight = 15;
            this.cbFormaPago.Location = new System.Drawing.Point(98, 82);
            this.cbFormaPago.MatchEntryTimeout = ((long)(2000));
            this.cbFormaPago.MaxDropDownItems = ((short)(5));
            this.cbFormaPago.MaxLength = 32767;
            this.cbFormaPago.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbFormaPago.Name = "cbFormaPago";
            this.cbFormaPago.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cbFormaPago.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cbFormaPago.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbFormaPago.Size = new System.Drawing.Size(310, 23);
            this.cbFormaPago.TabIndex = 2;
            this.cbFormaPago.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.cbFormaPago.PropBag = resources.GetString("cbFormaPago.PropBag");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Forma Pago :";
            // 
            // cbTipoPago
            // 
            this.cbTipoPago.AddItemSeparator = ';';
            this.cbTipoPago.Caption = "";
            this.cbTipoPago.CaptionHeight = 17;
            this.cbTipoPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbTipoPago.ColumnCaptionHeight = 17;
            this.cbTipoPago.ColumnFooterHeight = 17;
            this.cbTipoPago.ColumnHeaders = false;
            this.cbTipoPago.ColumnWidth = 100;
            this.cbTipoPago.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cbTipoPago.ContentHeight = 17;
            this.cbTipoPago.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbTipoPago.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbTipoPago.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoPago.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbTipoPago.EditorHeight = 17;
            this.cbTipoPago.Enabled = false;
            this.cbTipoPago.ExtendRightColumn = true;
            this.cbTipoPago.Images.Add(((System.Drawing.Image)(resources.GetObject("cbTipoPago.Images"))));
            this.cbTipoPago.ItemHeight = 15;
            this.cbTipoPago.Location = new System.Drawing.Point(98, 50);
            this.cbTipoPago.MatchEntryTimeout = ((long)(2000));
            this.cbTipoPago.MaxDropDownItems = ((short)(5));
            this.cbTipoPago.MaxLength = 32767;
            this.cbTipoPago.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbTipoPago.Name = "cbTipoPago";
            this.cbTipoPago.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cbTipoPago.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cbTipoPago.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbTipoPago.Size = new System.Drawing.Size(310, 23);
            this.cbTipoPago.TabIndex = 1;
            this.cbTipoPago.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.cbTipoPago.SelectedValueChanged += new System.EventHandler(this.cbTipoPago_SelectedValueChanged);
            this.cbTipoPago.PropBag = resources.GetString("cbTipoPago.PropBag");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 65;
            this.label3.Text = "Tipo Pago :";
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
            this.cbComprobante.Enabled = false;
            this.cbComprobante.ExtendRightColumn = true;
            this.cbComprobante.Images.Add(((System.Drawing.Image)(resources.GetObject("cbComprobante.Images"))));
            this.cbComprobante.ItemHeight = 15;
            this.cbComprobante.Location = new System.Drawing.Point(98, 18);
            this.cbComprobante.MatchEntryTimeout = ((long)(2000));
            this.cbComprobante.MaxDropDownItems = ((short)(5));
            this.cbComprobante.MaxLength = 32767;
            this.cbComprobante.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbComprobante.Name = "cbComprobante";
            this.cbComprobante.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cbComprobante.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cbComprobante.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbComprobante.Size = new System.Drawing.Size(310, 23);
            this.cbComprobante.TabIndex = 0;
            this.cbComprobante.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.cbComprobante.PropBag = resources.GetString("cbComprobante.PropBag");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "Comprobante :";
            // 
            // chkExterno
            // 
            this.chkExterno.AutoSize = true;
            this.chkExterno.Location = new System.Drawing.Point(102, 15);
            this.chkExterno.Name = "chkExterno";
            this.chkExterno.Size = new System.Drawing.Size(65, 17);
            this.chkExterno.TabIndex = 69;
            this.chkExterno.Text = "Externo";
            this.chkExterno.UseVisualStyleBackColor = true;
            this.chkExterno.CheckedChanged += new System.EventHandler(this.chkExterno_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(587, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 70;
            this.label5.Text = "Num Pedido :";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = global::Halley.Presentacion.Properties.Resources.Cancelar_16x16;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(934, 493);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(72, 23);
            this.btnCancelar.TabIndex = 91;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Enabled = false;
            this.btnRegistrar.Image = global::Halley.Presentacion.Properties.Resources.guardar_16x16;
            this.btnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrar.Location = new System.Drawing.Point(848, 493);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(80, 23);
            this.btnRegistrar.TabIndex = 90;
            this.btnRegistrar.Text = "Generar";
            this.btnRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(396, 464);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 92;
            this.label6.Text = "SubTotal :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(607, 464);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 94;
            this.label7.Text = "IGV :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(782, 466);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 96;
            this.label8.Text = "Total a Pagar :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(154, 464);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 98;
            this.label9.Text = "Total Cantidad :";
            // 
            // btnEliminarRegistro
            // 
            this.btnEliminarRegistro.Enabled = false;
            this.btnEliminarRegistro.Image = global::Halley.Presentacion.Properties.Resources.cerrar_16x16;
            this.btnEliminarRegistro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarRegistro.Location = new System.Drawing.Point(24, 456);
            this.btnEliminarRegistro.Name = "btnEliminarRegistro";
            this.btnEliminarRegistro.Size = new System.Drawing.Size(57, 23);
            this.btnEliminarRegistro.TabIndex = 100;
            this.btnEliminarRegistro.Text = "Items";
            this.btnEliminarRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarRegistro.UseVisualStyleBackColor = true;
            this.btnEliminarRegistro.Click += new System.EventHandler(this.cbEliminarRegistro_Click);
            // 
            // cbAgregarLinea
            // 
            this.cbAgregarLinea.Image = global::Halley.Presentacion.Properties.Resources.Add_16x16;
            this.cbAgregarLinea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbAgregarLinea.Location = new System.Drawing.Point(426, 18);
            this.cbAgregarLinea.Name = "cbAgregarLinea";
            this.cbAgregarLinea.Size = new System.Drawing.Size(102, 23);
            this.cbAgregarLinea.TabIndex = 0;
            this.cbAgregarLinea.Text = "Agregar items";
            this.cbAgregarLinea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbAgregarLinea.UseVisualStyleBackColor = true;
            this.cbAgregarLinea.Click += new System.EventHandler(this.cbAgregarLinea_Click);
            // 
            // lblTotCantidad
            // 
            this.lblTotCantidad.BackColor = System.Drawing.Color.White;
            this.lblTotCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotCantidad.Location = new System.Drawing.Point(248, 460);
            this.lblTotCantidad.Name = "lblTotCantidad";
            this.lblTotCantidad.Size = new System.Drawing.Size(142, 21);
            this.lblTotCantidad.TabIndex = 102;
            this.lblTotCantidad.Text = "0";
            this.lblTotCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.BackColor = System.Drawing.Color.White;
            this.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubTotal.Location = new System.Drawing.Point(460, 460);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(132, 21);
            this.lblSubTotal.TabIndex = 103;
            this.lblSubTotal.Text = "0";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIGV
            // 
            this.lblIGV.BackColor = System.Drawing.Color.White;
            this.lblIGV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIGV.Location = new System.Drawing.Point(644, 460);
            this.lblIGV.Name = "lblIGV";
            this.lblIGV.Size = new System.Drawing.Size(116, 21);
            this.lblIGV.TabIndex = 104;
            this.lblIGV.Text = "0";
            this.lblIGV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotPagar
            // 
            this.lblTotPagar.BackColor = System.Drawing.Color.White;
            this.lblTotPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotPagar.Location = new System.Drawing.Point(867, 460);
            this.lblTotPagar.Name = "lblTotPagar";
            this.lblTotPagar.Size = new System.Drawing.Size(139, 21);
            this.lblTotPagar.TabIndex = 105;
            this.lblTotPagar.Text = "0";
            this.lblTotPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNumPedido
            // 
            this.lblNumPedido.BackColor = System.Drawing.Color.White;
            this.lblNumPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumPedido.Location = new System.Drawing.Point(682, 11);
            this.lblNumPedido.Name = "lblNumPedido";
            this.lblNumPedido.Size = new System.Drawing.Size(310, 21);
            this.lblNumPedido.TabIndex = 106;
            this.lblNumPedido.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // c1NumericEdit1
            // 
            this.c1NumericEdit1.DataType = typeof(long);
            this.c1NumericEdit1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.Integer;
            this.c1NumericEdit1.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
                        | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.c1NumericEdit1.Location = new System.Drawing.Point(338, 319);
            this.c1NumericEdit1.Name = "c1NumericEdit1";
            this.c1NumericEdit1.Size = new System.Drawing.Size(94, 22);
            this.c1NumericEdit1.TabIndex = 107;
            this.c1NumericEdit1.Tag = null;
            this.c1NumericEdit1.Visible = false;
            this.c1NumericEdit1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtComentario);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbTipoPago);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbFormaPago);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbComprobante);
            this.groupBox1.Location = new System.Drawing.Point(584, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 188);
            this.groupBox1.TabIndex = 108;
            this.groupBox1.TabStop = false;
            // 
            // txtComentario
            // 
            this.txtComentario.AutoSize = false;
            this.txtComentario.Location = new System.Drawing.Point(98, 114);
            this.txtComentario.MaxLength = 300;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(310, 59);
            this.txtComentario.TabIndex = 3;
            this.txtComentario.Tag = null;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 69;
            this.label10.Text = "Comentario :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbAgregarLinea);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbProducto);
            this.groupBox2.Location = new System.Drawing.Point(24, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 55);
            this.groupBox2.TabIndex = 109;
            this.groupBox2.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(44, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 111;
            this.label11.Text = "Pedido :";
            // 
            // ucCliente
            // 
            this.ucCliente.Location = new System.Drawing.Point(24, 38);
            this.ucCliente.Name = "ucCliente";
            this.ucCliente.Size = new System.Drawing.Size(554, 144);
            this.ucCliente.TabIndex = 0;
            // 
            // errValidar
            // 
            this.errValidar.ContainerControl = this;
            this.errValidar.RightToLeft = true;
            // 
            // btnStock
            // 
            this.btnStock.Image = global::Halley.Presentacion.Properties.Resources.record;
            this.btnStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStock.Location = new System.Drawing.Point(492, 15);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(78, 23);
            this.btnStock.TabIndex = 114;
            this.btnStock.Text = "Ver Stock";
            this.btnStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // ListOrdenPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStock);
            this.Controls.Add(this.ucCliente);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.c1NumericEdit1);
            this.Controls.Add(this.lblNumPedido);
            this.Controls.Add(this.lblTotPagar);
            this.Controls.Add(this.lblIGV);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.lblTotCantidad);
            this.Controls.Add(this.btnEliminarRegistro);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkExterno);
            this.Controls.Add(this.tdbgPedidos);
            this.Name = "ListOrdenPedido";
            this.Size = new System.Drawing.Size(1045, 543);
            this.Load += new System.EventHandler(this.ListOrdenPedido_Load);
            this.Controls.SetChildIndex(this.tdbgPedidos, 0);
            this.Controls.SetChildIndex(this.chkExterno, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.btnRegistrar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.btnEliminarRegistro, 0);
            this.Controls.SetChildIndex(this.lblTotCantidad, 0);
            this.Controls.SetChildIndex(this.lblSubTotal, 0);
            this.Controls.SetChildIndex(this.lblIGV, 0);
            this.Controls.SetChildIndex(this.lblTotPagar, 0);
            this.Controls.SetChildIndex(this.lblNumPedido, 0);
            this.Controls.SetChildIndex(this.c1NumericEdit1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.ucCliente, 0);
            this.Controls.SetChildIndex(this.btnStock, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tdbgPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFormaPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTipoPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1NumericEdit1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComentario)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errValidar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdbgPedidos;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1List.C1Combo cbProducto;
        private C1.Win.C1List.C1Combo cbFormaPago;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1List.C1Combo cbTipoPago;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1List.C1Combo cbComprobante;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkExterno;
        private System.Windows.Forms.Label label5;
        private C1.Win.C1Input.C1Button btnCancelar;
        private C1.Win.C1Input.C1Button btnRegistrar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private C1.Win.C1Input.C1Button btnEliminarRegistro;
        private C1.Win.C1Input.C1Button cbAgregarLinea;
        private System.Windows.Forms.Label lblTotCantidad;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblIGV;
        private System.Windows.Forms.Label lblTotPagar;
        private System.Windows.Forms.Label lblNumPedido;
        private C1.Win.C1Input.C1NumericEdit c1NumericEdit1;
        private System.Windows.Forms.GroupBox groupBox1;
        private C1.Win.C1Input.C1TextBox txtComentario;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private UseCliente ucCliente;
        private System.Windows.Forms.ErrorProvider errValidar;
        private C1.Win.C1Input.C1Button btnStock;
    }
}
