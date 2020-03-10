namespace Halley.Presentacion.Mantenimiento
{
    partial class MantenimientoProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MantenimientoProveedor));
            this.BtnNuevo = new C1.Win.C1Input.C1Button();
            this.BtnGuardar = new C1.Win.C1Input.C1Button();
            this.BtnEditar = new C1.Win.C1Input.C1Button();
            this.BtnCancelar = new C1.Win.C1Input.C1Button();
            this.BtnEliminar = new C1.Win.C1Input.C1Button();
            this.btnBuscar = new C1.Win.C1Input.C1Button();
            this.TxtTelefono = new C1.Win.C1Input.C1TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtPais = new C1.Win.C1Input.C1TextBox();
            this.TxtNroDocumento = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtRazonSocial = new C1.Win.C1Input.C1TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblEstado = new System.Windows.Forms.Label();
            this.TxtIDProveedor = new C1.Win.C1Input.C1TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNroDocumento2 = new C1.Win.C1Input.C1TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtDireccion = new C1.Win.C1Input.C1TextBox();
            this.TxtCargoContacto = new C1.Win.C1Input.C1TextBox();
            this.TxtContacto = new C1.Win.C1Input.C1TextBox();
            this.TxtRegion = new C1.Win.C1Input.C1TextBox();
            this.TxtEmail = new C1.Win.C1Input.C1TextBox();
            this.CboTipoDocumento = new C1.Win.C1List.C1Combo();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTelefono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNroDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRazonSocial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtIDProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNroDocumento2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDireccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCargoContacto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtContacto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoDocumento)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Image = global::Halley.Presentacion.Properties.Resources.newdocument_16x16;
            this.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNuevo.Location = new System.Drawing.Point(573, 105);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(82, 23);
            this.BtnNuevo.TabIndex = 197;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Image = global::Halley.Presentacion.Properties.Resources.save_16x16;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(573, 198);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(82, 23);
            this.BtnGuardar.TabIndex = 196;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.Image = global::Halley.Presentacion.Properties.Resources.edit_16x16;
            this.BtnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEditar.Location = new System.Drawing.Point(573, 167);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(82, 23);
            this.BtnEditar.TabIndex = 195;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEditar.UseVisualStyleBackColor = true;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Image = global::Halley.Presentacion.Properties.Resources.cancel_16x16;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(573, 136);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(82, 23);
            this.BtnCancelar.TabIndex = 194;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Image = global::Halley.Presentacion.Properties.Resources.delete_16x16;
            this.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEliminar.Location = new System.Drawing.Point(573, 229);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(82, 23);
            this.BtnEliminar.TabIndex = 193;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Halley.Presentacion.Properties.Resources.Consultar_16x16;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(573, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(82, 23);
            this.btnBuscar.TabIndex = 192;
            this.btnBuscar.Text = "Consultar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // TxtTelefono
            // 
            this.TxtTelefono.BackColor = System.Drawing.Color.White;
            this.TxtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtTelefono.Location = new System.Drawing.Point(167, 140);
            this.TxtTelefono.MaxLength = 12;
            this.TxtTelefono.Name = "TxtTelefono";
            this.TxtTelefono.Size = new System.Drawing.Size(154, 20);
            this.TxtTelefono.TabIndex = 206;
            this.TxtTelefono.Tag = null;
            this.TxtTelefono.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtTelefono.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 207;
            this.label7.Text = "Nro de Documento:";
            // 
            // TxtPais
            // 
            this.TxtPais.BackColor = System.Drawing.Color.White;
            this.TxtPais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtPais.Location = new System.Drawing.Point(167, 167);
            this.TxtPais.MaxLength = 150;
            this.TxtPais.Name = "TxtPais";
            this.TxtPais.Size = new System.Drawing.Size(184, 20);
            this.TxtPais.TabIndex = 204;
            this.TxtPais.Tag = null;
            this.TxtPais.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtPais.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // TxtNroDocumento
            // 
            this.TxtNroDocumento.BackColor = System.Drawing.Color.White;
            this.TxtNroDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNroDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNroDocumento.Location = new System.Drawing.Point(167, 108);
            this.TxtNroDocumento.MaxLength = 20;
            this.TxtNroDocumento.Name = "TxtNroDocumento";
            this.TxtNroDocumento.Size = new System.Drawing.Size(112, 20);
            this.TxtNroDocumento.TabIndex = 203;
            this.TxtNroDocumento.Tag = null;
            this.TxtNroDocumento.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtNroDocumento.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.TxtNroDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNroDocumento_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 202;
            this.label1.Text = "País:";
            // 
            // TxtRazonSocial
            // 
            this.TxtRazonSocial.BackColor = System.Drawing.Color.White;
            this.TxtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtRazonSocial.Location = new System.Drawing.Point(167, 50);
            this.TxtRazonSocial.MaxLength = 200;
            this.TxtRazonSocial.Name = "TxtRazonSocial";
            this.TxtRazonSocial.Size = new System.Drawing.Size(256, 20);
            this.TxtRazonSocial.TabIndex = 198;
            this.TxtRazonSocial.Tag = null;
            this.TxtRazonSocial.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtRazonSocial.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(106, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 200;
            this.label4.Text = "Telefono:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 199;
            this.label3.Text = "Tipo Documento:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(89, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 211;
            this.label8.Text = "Razon Social";
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEstado.Location = new System.Drawing.Point(149, 365);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(12, 13);
            this.lblEstado.TabIndex = 212;
            this.lblEstado.Text = "*";
            // 
            // TxtIDProveedor
            // 
            this.TxtIDProveedor.BackColor = System.Drawing.Color.White;
            this.TxtIDProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtIDProveedor.Location = new System.Drawing.Point(167, 22);
            this.TxtIDProveedor.MaxLength = 10;
            this.TxtIDProveedor.Name = "TxtIDProveedor";
            this.TxtIDProveedor.Size = new System.Drawing.Size(100, 20);
            this.TxtIDProveedor.TabIndex = 213;
            this.TxtIDProveedor.Tag = null;
            this.TxtIDProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtIDProveedor.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtIDProveedor.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 214;
            this.label2.Text = "ID:";
            // 
            // TxtNroDocumento2
            // 
            this.TxtNroDocumento2.BackColor = System.Drawing.Color.White;
            this.TxtNroDocumento2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNroDocumento2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNroDocumento2.Location = new System.Drawing.Point(441, 14);
            this.TxtNroDocumento2.MaxLength = 8;
            this.TxtNroDocumento2.Name = "TxtNroDocumento2";
            this.TxtNroDocumento2.Size = new System.Drawing.Size(119, 20);
            this.TxtNroDocumento2.TabIndex = 215;
            this.TxtNroDocumento2.Tag = null;
            this.TxtNroDocumento2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtNroDocumento2.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtNroDocumento2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(294, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 26);
            this.label5.TabIndex = 216;
            this.label5.Text = "Ingrese Nro de documento\r\ndel Proveedor:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(114, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 217;
            this.label6.Text = "Region:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(103, 235);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 218;
            this.label9.Text = "Dirección:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(104, 273);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 219;
            this.label10.Text = "Contacto:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(70, 304);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 220;
            this.label11.Text = "Cargo Contacto:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(116, 333);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 221;
            this.label12.Text = "Correo:";
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.BackColor = System.Drawing.Color.White;
            this.TxtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDireccion.Location = new System.Drawing.Point(167, 232);
            this.TxtDireccion.MaxLength = 200;
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(249, 20);
            this.TxtDireccion.TabIndex = 225;
            this.TxtDireccion.Tag = null;
            this.TxtDireccion.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtDireccion.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // TxtCargoContacto
            // 
            this.TxtCargoContacto.BackColor = System.Drawing.Color.White;
            this.TxtCargoContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCargoContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtCargoContacto.Location = new System.Drawing.Point(167, 302);
            this.TxtCargoContacto.MaxLength = 150;
            this.TxtCargoContacto.Name = "TxtCargoContacto";
            this.TxtCargoContacto.Size = new System.Drawing.Size(249, 20);
            this.TxtCargoContacto.TabIndex = 224;
            this.TxtCargoContacto.Tag = null;
            this.TxtCargoContacto.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtCargoContacto.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // TxtContacto
            // 
            this.TxtContacto.BackColor = System.Drawing.Color.White;
            this.TxtContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtContacto.Location = new System.Drawing.Point(167, 272);
            this.TxtContacto.MaxLength = 150;
            this.TxtContacto.Name = "TxtContacto";
            this.TxtContacto.Size = new System.Drawing.Size(249, 20);
            this.TxtContacto.TabIndex = 223;
            this.TxtContacto.Tag = null;
            this.TxtContacto.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtContacto.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // TxtRegion
            // 
            this.TxtRegion.BackColor = System.Drawing.Color.White;
            this.TxtRegion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtRegion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtRegion.Location = new System.Drawing.Point(167, 198);
            this.TxtRegion.MaxLength = 150;
            this.TxtRegion.Name = "TxtRegion";
            this.TxtRegion.Size = new System.Drawing.Size(184, 20);
            this.TxtRegion.TabIndex = 222;
            this.TxtRegion.Tag = null;
            this.TxtRegion.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtRegion.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // TxtEmail
            // 
            this.TxtEmail.BackColor = System.Drawing.Color.White;
            this.TxtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtEmail.Location = new System.Drawing.Point(167, 331);
            this.TxtEmail.MaxLength = 200;
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(249, 20);
            this.TxtEmail.TabIndex = 226;
            this.TxtEmail.Tag = null;
            this.TxtEmail.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtEmail.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // CboTipoDocumento
            // 
            this.CboTipoDocumento.AddItemSeparator = ';';
            this.CboTipoDocumento.AutoCompletion = true;
            this.CboTipoDocumento.AutoDropDown = true;
            this.CboTipoDocumento.Caption = "";
            this.CboTipoDocumento.CaptionHeight = 17;
            this.CboTipoDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboTipoDocumento.ColumnCaptionHeight = 17;
            this.CboTipoDocumento.ColumnFooterHeight = 17;
            this.CboTipoDocumento.ColumnHeaders = false;
            this.CboTipoDocumento.ContentHeight = 17;
            this.CboTipoDocumento.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboTipoDocumento.DisplayMember = "NomEmpresa";
            this.CboTipoDocumento.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboTipoDocumento.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTipoDocumento.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboTipoDocumento.EditorHeight = 17;
            this.CboTipoDocumento.Images.Add(((System.Drawing.Image)(resources.GetObject("CboTipoDocumento.Images"))));
            this.CboTipoDocumento.ItemHeight = 15;
            this.CboTipoDocumento.Location = new System.Drawing.Point(167, 80);
            this.CboTipoDocumento.MatchEntryTimeout = ((long)(2000));
            this.CboTipoDocumento.MaxDropDownItems = ((short)(10));
            this.CboTipoDocumento.MaxLength = 32767;
            this.CboTipoDocumento.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboTipoDocumento.Name = "CboTipoDocumento";
            this.CboTipoDocumento.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboTipoDocumento.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboTipoDocumento.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboTipoDocumento.Size = new System.Drawing.Size(196, 23);
            this.CboTipoDocumento.TabIndex = 227;
            this.CboTipoDocumento.ValueMember = "EmpresaID";
            this.CboTipoDocumento.PropBag = resources.GetString("CboTipoDocumento.PropBag");
            // 
            // MantenimientoProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CboTipoDocumento);
            this.Controls.Add(this.TxtEmail);
            this.Controls.Add(this.TxtDireccion);
            this.Controls.Add(this.TxtCargoContacto);
            this.Controls.Add(this.TxtContacto);
            this.Controls.Add(this.TxtRegion);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtNroDocumento2);
            this.Controls.Add(this.TxtIDProveedor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtTelefono);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtPais);
            this.Controls.Add(this.TxtNroDocumento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtRazonSocial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnEditar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.btnBuscar);
            this.Name = "MantenimientoProveedor";
            this.Size = new System.Drawing.Size(693, 455);
            this.Load += new System.EventHandler(this.MantenimientoVehiculos_Load);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.BtnEliminar, 0);
            this.Controls.SetChildIndex(this.BtnCancelar, 0);
            this.Controls.SetChildIndex(this.BtnEditar, 0);
            this.Controls.SetChildIndex(this.BtnGuardar, 0);
            this.Controls.SetChildIndex(this.BtnNuevo, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.TxtRazonSocial, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.TxtNroDocumento, 0);
            this.Controls.SetChildIndex(this.TxtPais, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.TxtTelefono, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.lblEstado, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.TxtIDProveedor, 0);
            this.Controls.SetChildIndex(this.TxtNroDocumento2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.TxtRegion, 0);
            this.Controls.SetChildIndex(this.TxtContacto, 0);
            this.Controls.SetChildIndex(this.TxtCargoContacto, 0);
            this.Controls.SetChildIndex(this.TxtDireccion, 0);
            this.Controls.SetChildIndex(this.TxtEmail, 0);
            this.Controls.SetChildIndex(this.CboTipoDocumento, 0);
            ((System.ComponentModel.ISupportInitialize)(this.TxtTelefono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNroDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRazonSocial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtIDProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNroDocumento2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDireccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCargoContacto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtContacto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoDocumento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1Button BtnNuevo;
        private C1.Win.C1Input.C1Button BtnGuardar;
        private C1.Win.C1Input.C1Button BtnEditar;
        private C1.Win.C1Input.C1Button BtnCancelar;
        private C1.Win.C1Input.C1Button BtnEliminar;
        private C1.Win.C1Input.C1Button btnBuscar;
        private C1.Win.C1Input.C1TextBox TxtTelefono;
        private System.Windows.Forms.Label label7;
        private C1.Win.C1Input.C1TextBox TxtPais;
        private C1.Win.C1Input.C1TextBox TxtNroDocumento;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox TxtRazonSocial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider ErrProvider;
        private System.Windows.Forms.Label lblEstado;
        private C1.Win.C1Input.C1TextBox TxtIDProveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private C1.Win.C1Input.C1TextBox TxtNroDocumento2;
        private C1.Win.C1Input.C1TextBox TxtEmail;
        private C1.Win.C1Input.C1TextBox TxtDireccion;
        private C1.Win.C1Input.C1TextBox TxtCargoContacto;
        private C1.Win.C1Input.C1TextBox TxtContacto;
        private C1.Win.C1Input.C1TextBox TxtRegion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private C1.Win.C1List.C1Combo CboTipoDocumento;
    }
}
