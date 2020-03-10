namespace Halley.Presentacion.Mantenimiento
{
    partial class MantenimientoSerieGuias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MantenimientoSerieGuias));
            this.BtnNuevo = new C1.Win.C1Input.C1Button();
            this.BtnGuardar = new C1.Win.C1Input.C1Button();
            this.BtnCancelar = new C1.Win.C1Input.C1Button();
            this.TxtNumeroT = new C1.Win.C1Input.C1TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.c1cboCiaR = new C1.Win.C1List.C1Combo();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CboSedeR = new C1.Win.C1List.C1Combo();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbNotaCredito = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSerieN = new C1.Win.C1Input.C1TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumeroN = new C1.Win.C1Input.C1TextBox();
            this.RbR = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtSerieR = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNumeroR = new C1.Win.C1Input.C1TextBox();
            this.RbT = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtSerieT = new C1.Win.C1Input.C1TextBox();
            this.BtnEditar = new C1.Win.C1Input.C1Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TxtNumeroT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCiaR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboSedeR)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerieN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroN)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSerieR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNumeroR)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSerieT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Image = global::Halley.Presentacion.Properties.Resources.newdocument_16x16;
            this.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNuevo.Location = new System.Drawing.Point(773, 30);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(82, 23);
            this.BtnNuevo.TabIndex = 361;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Image = global::Halley.Presentacion.Properties.Resources.save_16x16;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(773, 117);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(82, 23);
            this.BtnGuardar.TabIndex = 359;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Image = global::Halley.Presentacion.Properties.Resources.cancel_16x16;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(773, 88);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(82, 23);
            this.BtnCancelar.TabIndex = 360;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // TxtNumeroT
            // 
            this.TxtNumeroT.BackColor = System.Drawing.Color.White;
            this.TxtNumeroT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNumeroT.Location = new System.Drawing.Point(139, 47);
            this.TxtNumeroT.MaxLength = 8;
            this.TxtNumeroT.Name = "TxtNumeroT";
            this.TxtNumeroT.Size = new System.Drawing.Size(87, 20);
            this.TxtNumeroT.TabIndex = 358;
            this.TxtNumeroT.Tag = null;
            this.TxtNumeroT.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtNumeroT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.TxtNumeroT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNumeroT_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 357;
            this.label6.Text = "Numero Transporte:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 353;
            this.label5.Text = "Serie Transporte:";
            // 
            // c1cboCiaR
            // 
            this.c1cboCiaR.AddItemSeparator = ';';
            this.c1cboCiaR.AutoCompletion = true;
            this.c1cboCiaR.AutoDropDown = true;
            this.c1cboCiaR.Caption = "";
            this.c1cboCiaR.CaptionHeight = 17;
            this.c1cboCiaR.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.c1cboCiaR.ColumnCaptionHeight = 17;
            this.c1cboCiaR.ColumnFooterHeight = 17;
            this.c1cboCiaR.ColumnHeaders = false;
            this.c1cboCiaR.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.c1cboCiaR.ContentHeight = 17;
            this.c1cboCiaR.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.c1cboCiaR.DisplayMember = "NomEmpresa";
            this.c1cboCiaR.EditorBackColor = System.Drawing.SystemColors.Window;
            this.c1cboCiaR.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1cboCiaR.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.c1cboCiaR.EditorHeight = 17;
            this.c1cboCiaR.Images.Add(((System.Drawing.Image)(resources.GetObject("c1cboCiaR.Images"))));
            this.c1cboCiaR.ItemHeight = 15;
            this.c1cboCiaR.Location = new System.Drawing.Point(82, 21);
            this.c1cboCiaR.MatchEntryTimeout = ((long)(2000));
            this.c1cboCiaR.MaxDropDownItems = ((short)(10));
            this.c1cboCiaR.MaxLength = 32767;
            this.c1cboCiaR.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.c1cboCiaR.Name = "c1cboCiaR";
            this.c1cboCiaR.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.c1cboCiaR.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1cboCiaR.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1cboCiaR.Size = new System.Drawing.Size(160, 23);
            this.c1cboCiaR.TabIndex = 386;
            this.c1cboCiaR.ValueMember = "EmpresaID";
            this.c1cboCiaR.PropBag = resources.GetString("c1cboCiaR.PropBag");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 387;
            this.label14.Text = "Empresa:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 389;
            this.label8.Text = "Sede:";
            // 
            // CboSedeR
            // 
            this.CboSedeR.AddItemSeparator = ';';
            this.CboSedeR.AutoCompletion = true;
            this.CboSedeR.AutoDropDown = true;
            this.CboSedeR.Caption = "Seleccione Sede";
            this.CboSedeR.CaptionHeight = 17;
            this.CboSedeR.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboSedeR.ColumnCaptionHeight = 17;
            this.CboSedeR.ColumnFooterHeight = 17;
            this.CboSedeR.ColumnHeaders = false;
            this.CboSedeR.ContentHeight = 17;
            this.CboSedeR.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboSedeR.DisplayMember = "NomEmpresa";
            this.CboSedeR.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboSedeR.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboSedeR.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboSedeR.EditorHeight = 17;
            this.CboSedeR.Images.Add(((System.Drawing.Image)(resources.GetObject("CboSedeR.Images"))));
            this.CboSedeR.ItemHeight = 15;
            this.CboSedeR.Location = new System.Drawing.Point(82, 51);
            this.CboSedeR.MatchEntryTimeout = ((long)(2000));
            this.CboSedeR.MaxDropDownItems = ((short)(10));
            this.CboSedeR.MaxLength = 32767;
            this.CboSedeR.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboSedeR.Name = "CboSedeR";
            this.CboSedeR.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboSedeR.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboSedeR.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboSedeR.Size = new System.Drawing.Size(277, 23);
            this.CboSedeR.TabIndex = 388;
            this.CboSedeR.ValueMember = "EmpresaID";
            this.CboSedeR.SelectedValueChanged += new System.EventHandler(this.CboSedeR_SelectedValueChanged);
            this.CboSedeR.PropBag = resources.GetString("CboSedeR.PropBag");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNotaCredito);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.RbR);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.RbT);
            this.groupBox1.Controls.Add(this.BtnEditar);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.c1cboCiaR);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.CboSedeR);
            this.groupBox1.Controls.Add(this.BtnNuevo);
            this.groupBox1.Controls.Add(this.BtnGuardar);
            this.groupBox1.Controls.Add(this.BtnCancelar);
            this.groupBox1.Location = new System.Drawing.Point(29, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(872, 242);
            this.groupBox1.TabIndex = 390;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de documento";
            // 
            // rbNotaCredito
            // 
            this.rbNotaCredito.AutoSize = true;
            this.rbNotaCredito.Location = new System.Drawing.Point(548, 129);
            this.rbNotaCredito.Name = "rbNotaCredito";
            this.rbNotaCredito.Size = new System.Drawing.Size(105, 17);
            this.rbNotaCredito.TabIndex = 415;
            this.rbNotaCredito.TabStop = true;
            this.rbNotaCredito.Text = "Nota de credito";
            this.rbNotaCredito.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtSerieN);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtNumeroN);
            this.groupBox4.Location = new System.Drawing.Point(542, 143);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(216, 83);
            this.groupBox4.TabIndex = 414;
            this.groupBox4.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 391;
            this.label3.Text = "Serie :";
            // 
            // txtSerieN
            // 
            this.txtSerieN.BackColor = System.Drawing.Color.White;
            this.txtSerieN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerieN.Location = new System.Drawing.Point(88, 19);
            this.txtSerieN.MaxLength = 3;
            this.txtSerieN.Name = "txtSerieN";
            this.txtSerieN.Size = new System.Drawing.Size(48, 20);
            this.txtSerieN.TabIndex = 394;
            this.txtSerieN.Tag = null;
            this.txtSerieN.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.txtSerieN.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.txtSerieN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerieN_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 392;
            this.label4.Text = "Numero :";
            // 
            // txtNumeroN
            // 
            this.txtNumeroN.BackColor = System.Drawing.Color.White;
            this.txtNumeroN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroN.Location = new System.Drawing.Point(88, 44);
            this.txtNumeroN.MaxLength = 8;
            this.txtNumeroN.Name = "txtNumeroN";
            this.txtNumeroN.Size = new System.Drawing.Size(87, 20);
            this.txtNumeroN.TabIndex = 393;
            this.txtNumeroN.Tag = null;
            this.txtNumeroN.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.txtNumeroN.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.txtNumeroN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroN_KeyPress);
            // 
            // RbR
            // 
            this.RbR.AutoSize = true;
            this.RbR.Location = new System.Drawing.Point(262, 129);
            this.RbR.Name = "RbR";
            this.RbR.Size = new System.Drawing.Size(120, 17);
            this.RbR.TabIndex = 411;
            this.RbR.TabStop = true;
            this.RbR.Text = "Guia de Remitente";
            this.RbR.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.TxtSerieR);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.TxtNumeroR);
            this.groupBox3.Location = new System.Drawing.Point(262, 143);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(274, 83);
            this.groupBox3.TabIndex = 391;
            this.groupBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 391;
            this.label2.Text = "Serie Remitente:";
            // 
            // TxtSerieR
            // 
            this.TxtSerieR.BackColor = System.Drawing.Color.White;
            this.TxtSerieR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSerieR.Location = new System.Drawing.Point(140, 19);
            this.TxtSerieR.MaxLength = 3;
            this.TxtSerieR.Name = "TxtSerieR";
            this.TxtSerieR.Size = new System.Drawing.Size(48, 20);
            this.TxtSerieR.TabIndex = 394;
            this.TxtSerieR.Tag = null;
            this.TxtSerieR.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtSerieR.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.TxtSerieR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSerieR_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 392;
            this.label1.Text = "Numero Remitente:";
            // 
            // TxtNumeroR
            // 
            this.TxtNumeroR.BackColor = System.Drawing.Color.White;
            this.TxtNumeroR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNumeroR.Location = new System.Drawing.Point(140, 44);
            this.TxtNumeroR.MaxLength = 8;
            this.TxtNumeroR.Name = "TxtNumeroR";
            this.TxtNumeroR.Size = new System.Drawing.Size(87, 20);
            this.TxtNumeroR.TabIndex = 393;
            this.TxtNumeroR.Tag = null;
            this.TxtNumeroR.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtNumeroR.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.TxtNumeroR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNumeroR_KeyPress);
            // 
            // RbT
            // 
            this.RbT.AutoSize = true;
            this.RbT.Checked = true;
            this.RbT.Location = new System.Drawing.Point(12, 126);
            this.RbT.Name = "RbT";
            this.RbT.Size = new System.Drawing.Size(123, 17);
            this.RbT.TabIndex = 410;
            this.RbT.TabStop = true;
            this.RbT.Text = "Guia de Transporte";
            this.RbT.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtSerieT);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TxtNumeroT);
            this.groupBox2.Location = new System.Drawing.Point(6, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 83);
            this.groupBox2.TabIndex = 413;
            this.groupBox2.TabStop = false;
            // 
            // TxtSerieT
            // 
            this.TxtSerieT.BackColor = System.Drawing.Color.White;
            this.TxtSerieT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSerieT.Location = new System.Drawing.Point(139, 22);
            this.TxtSerieT.MaxLength = 3;
            this.TxtSerieT.Name = "TxtSerieT";
            this.TxtSerieT.Size = new System.Drawing.Size(37, 20);
            this.TxtSerieT.TabIndex = 390;
            this.TxtSerieT.Tag = null;
            this.TxtSerieT.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtSerieT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.TxtSerieT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSerieT_KeyPress);
            // 
            // BtnEditar
            // 
            this.BtnEditar.Image = global::Halley.Presentacion.Properties.Resources.edit_16x16;
            this.BtnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEditar.Location = new System.Drawing.Point(773, 59);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(82, 23);
            this.BtnEditar.TabIndex = 406;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEditar.UseVisualStyleBackColor = true;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click_1);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEstado.Location = new System.Drawing.Point(38, 282);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(12, 13);
            this.lblEstado.TabIndex = 409;
            this.lblEstado.Text = "*";
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // MantenimientoSerieGuias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblEstado);
            this.Name = "MantenimientoSerieGuias";
            this.Size = new System.Drawing.Size(1084, 446);
            this.Load += new System.EventHandler(this.MantenimientoSerieGuias_Load);
            this.Controls.SetChildIndex(this.lblEstado, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.TxtNumeroT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCiaR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboSedeR)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerieN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroN)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSerieR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNumeroR)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSerieT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1Button BtnNuevo;
        private C1.Win.C1Input.C1Button BtnGuardar;
        private C1.Win.C1Input.C1Button BtnCancelar;
        private C1.Win.C1Input.C1TextBox TxtNumeroT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private C1.Win.C1List.C1Combo c1cboCiaR;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private C1.Win.C1List.C1Combo CboSedeR;
        private System.Windows.Forms.GroupBox groupBox1;
        private C1.Win.C1Input.C1TextBox TxtSerieT;
        private C1.Win.C1Input.C1TextBox TxtSerieR;
        private C1.Win.C1Input.C1TextBox TxtNumeroR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider ErrProvider;
        private System.Windows.Forms.Label lblEstado;
        private C1.Win.C1Input.C1Button BtnEditar;
        private System.Windows.Forms.RadioButton RbR;
        private System.Windows.Forms.RadioButton RbT;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbNotaCredito;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1TextBox txtSerieN;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1TextBox txtNumeroN;
    }
}
