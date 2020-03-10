namespace Halley.Presentacion.Mantenimiento
{
    partial class MantenimientoVehiculos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MantenimientoVehiculos));
            this.BtnNuevo = new C1.Win.C1Input.C1Button();
            this.BtnGuardar = new C1.Win.C1Input.C1Button();
            this.BtnEditar = new C1.Win.C1Input.C1Button();
            this.BtnCancelar = new C1.Win.C1Input.C1Button();
            this.BtnEliminar = new C1.Win.C1Input.C1Button();
            this.btnBuscar = new C1.Win.C1Input.C1Button();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtPesoBruto = new C1.Win.C1Input.C1TextBox();
            this.TxtMarca = new C1.Win.C1Input.C1TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtTara = new C1.Win.C1Input.C1TextBox();
            this.TxtConfiguracionVehicular = new C1.Win.C1Input.C1TextBox();
            this.TxtCertificadoInscripcion = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtPlaca = new C1.Win.C1Input.C1TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CboEmpresa = new C1.Win.C1List.C1Combo();
            this.label8 = new System.Windows.Forms.Label();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblEstado = new System.Windows.Forms.Label();
            this.TxtPlaca2 = new C1.Win.C1Input.C1TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPesoBruto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMarca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtConfiguracionVehicular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCertificadoInscripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPlaca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboEmpresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPlaca2)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Image = global::Halley.Presentacion.Properties.Resources.newdocument_16x16;
            this.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNuevo.Location = new System.Drawing.Point(551, 105);
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
            this.BtnGuardar.Location = new System.Drawing.Point(551, 198);
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
            this.BtnEditar.Location = new System.Drawing.Point(551, 167);
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
            this.BtnCancelar.Location = new System.Drawing.Point(551, 136);
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
            this.BtnEliminar.Location = new System.Drawing.Point(551, 229);
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
            this.btnBuscar.Location = new System.Drawing.Point(551, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(82, 23);
            this.btnBuscar.TabIndex = 192;
            this.btnBuscar.Text = "Consultar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(121, 241);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 209;
            this.label9.Text = "Peso Bruto:";
            // 
            // TxtPesoBruto
            // 
            this.TxtPesoBruto.Location = new System.Drawing.Point(193, 238);
            this.TxtPesoBruto.Name = "TxtPesoBruto";
            this.TxtPesoBruto.Size = new System.Drawing.Size(100, 22);
            this.TxtPesoBruto.TabIndex = 208;
            this.TxtPesoBruto.Tag = null;
            this.TxtPesoBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtPesoBruto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPesoBruto_KeyPress);
            // 
            // TxtMarca
            // 
            this.TxtMarca.BackColor = System.Drawing.Color.White;
            this.TxtMarca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtMarca.Location = new System.Drawing.Point(193, 128);
            this.TxtMarca.MaxLength = 50;
            this.TxtMarca.Name = "TxtMarca";
            this.TxtMarca.Size = new System.Drawing.Size(184, 20);
            this.TxtMarca.TabIndex = 206;
            this.TxtMarca.Tag = null;
            this.TxtMarca.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtMarca.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(146, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 207;
            this.label7.Text = "Marca:";
            // 
            // TxtTara
            // 
            this.TxtTara.BackColor = System.Drawing.Color.White;
            this.TxtTara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTara.Location = new System.Drawing.Point(193, 212);
            this.TxtTara.MaxLength = 15;
            this.TxtTara.Name = "TxtTara";
            this.TxtTara.Size = new System.Drawing.Size(100, 20);
            this.TxtTara.TabIndex = 205;
            this.TxtTara.Tag = null;
            this.TxtTara.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtTara.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtTara.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.TxtTara.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTara_KeyPress);
            // 
            // TxtConfiguracionVehicular
            // 
            this.TxtConfiguracionVehicular.BackColor = System.Drawing.Color.White;
            this.TxtConfiguracionVehicular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtConfiguracionVehicular.Location = new System.Drawing.Point(193, 184);
            this.TxtConfiguracionVehicular.MaxLength = 20;
            this.TxtConfiguracionVehicular.Name = "TxtConfiguracionVehicular";
            this.TxtConfiguracionVehicular.Size = new System.Drawing.Size(160, 20);
            this.TxtConfiguracionVehicular.TabIndex = 204;
            this.TxtConfiguracionVehicular.Tag = null;
            this.TxtConfiguracionVehicular.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtConfiguracionVehicular.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // TxtCertificadoInscripcion
            // 
            this.TxtCertificadoInscripcion.BackColor = System.Drawing.Color.White;
            this.TxtCertificadoInscripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCertificadoInscripcion.Location = new System.Drawing.Point(193, 156);
            this.TxtCertificadoInscripcion.MaxLength = 15;
            this.TxtCertificadoInscripcion.Name = "TxtCertificadoInscripcion";
            this.TxtCertificadoInscripcion.Size = new System.Drawing.Size(160, 20);
            this.TxtCertificadoInscripcion.TabIndex = 203;
            this.TxtCertificadoInscripcion.Tag = null;
            this.TxtCertificadoInscripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtCertificadoInscripcion.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtCertificadoInscripcion.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.TxtCertificadoInscripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCertificadoInscripcion_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 202;
            this.label1.Text = "Configuración Vehicular:";
            // 
            // TxtPlaca
            // 
            this.TxtPlaca.BackColor = System.Drawing.Color.White;
            this.TxtPlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPlaca.Location = new System.Drawing.Point(193, 100);
            this.TxtPlaca.MaxLength = 10;
            this.TxtPlaca.Name = "TxtPlaca";
            this.TxtPlaca.Size = new System.Drawing.Size(100, 20);
            this.TxtPlaca.TabIndex = 198;
            this.TxtPlaca.Tag = null;
            this.TxtPlaca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtPlaca.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtPlaca.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(156, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 201;
            this.label5.Text = "Tara:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 200;
            this.label4.Text = "Certificado de inscripción:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 199;
            this.label3.Text = "Placa:";
            // 
            // CboEmpresa
            // 
            this.CboEmpresa.AddItemSeparator = ';';
            this.CboEmpresa.AutoCompletion = true;
            this.CboEmpresa.AutoDropDown = true;
            this.CboEmpresa.Caption = "";
            this.CboEmpresa.CaptionHeight = 17;
            this.CboEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboEmpresa.ColumnCaptionHeight = 17;
            this.CboEmpresa.ColumnFooterHeight = 17;
            this.CboEmpresa.ColumnHeaders = false;
            this.CboEmpresa.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.CboEmpresa.ContentHeight = 17;
            this.CboEmpresa.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboEmpresa.DisplayMember = "NomEmpresa";
            this.CboEmpresa.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboEmpresa.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboEmpresa.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboEmpresa.EditorHeight = 17;
            this.CboEmpresa.Images.Add(((System.Drawing.Image)(resources.GetObject("CboEmpresa.Images"))));
            this.CboEmpresa.ItemHeight = 15;
            this.CboEmpresa.Location = new System.Drawing.Point(193, 64);
            this.CboEmpresa.MatchEntryTimeout = ((long)(2000));
            this.CboEmpresa.MaxDropDownItems = ((short)(10));
            this.CboEmpresa.MaxLength = 32767;
            this.CboEmpresa.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboEmpresa.Name = "CboEmpresa";
            this.CboEmpresa.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboEmpresa.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboEmpresa.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboEmpresa.Size = new System.Drawing.Size(160, 23);
            this.CboEmpresa.TabIndex = 210;
            this.CboEmpresa.ValueMember = "EmpresaID";
            this.CboEmpresa.PropBag = resources.GetString("CboEmpresa.PropBag");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(134, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 211;
            this.label8.Text = "Empresa:";
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEstado.Location = new System.Drawing.Point(190, 282);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(12, 13);
            this.lblEstado.TabIndex = 212;
            this.lblEstado.Text = "*";
            // 
            // TxtPlaca2
            // 
            this.TxtPlaca2.BackColor = System.Drawing.Color.White;
            this.TxtPlaca2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPlaca2.Location = new System.Drawing.Point(445, 13);
            this.TxtPlaca2.MaxLength = 10;
            this.TxtPlaca2.Name = "TxtPlaca2";
            this.TxtPlaca2.Size = new System.Drawing.Size(100, 20);
            this.TxtPlaca2.TabIndex = 213;
            this.TxtPlaca2.Tag = null;
            this.TxtPlaca2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtPlaca2.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtPlaca2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(362, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 214;
            this.label2.Text = "Ingrese Placa:";
            // 
            // MantenimientoVehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TxtPlaca2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.CboEmpresa);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtPesoBruto);
            this.Controls.Add(this.TxtMarca);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtTara);
            this.Controls.Add(this.TxtConfiguracionVehicular);
            this.Controls.Add(this.TxtCertificadoInscripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtPlaca);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnEditar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.btnBuscar);
            this.Name = "MantenimientoVehiculos";
            this.Size = new System.Drawing.Size(693, 396);
            this.Load += new System.EventHandler(this.MantenimientoVehiculos_Load);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.BtnEliminar, 0);
            this.Controls.SetChildIndex(this.BtnCancelar, 0);
            this.Controls.SetChildIndex(this.BtnEditar, 0);
            this.Controls.SetChildIndex(this.BtnGuardar, 0);
            this.Controls.SetChildIndex(this.BtnNuevo, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.TxtPlaca, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.TxtCertificadoInscripcion, 0);
            this.Controls.SetChildIndex(this.TxtConfiguracionVehicular, 0);
            this.Controls.SetChildIndex(this.TxtTara, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.TxtMarca, 0);
            this.Controls.SetChildIndex(this.TxtPesoBruto, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.CboEmpresa, 0);
            this.Controls.SetChildIndex(this.lblEstado, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.TxtPlaca2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.TxtPesoBruto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMarca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtConfiguracionVehicular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCertificadoInscripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPlaca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboEmpresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPlaca2)).EndInit();
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
        private System.Windows.Forms.Label label9;
        private C1.Win.C1Input.C1TextBox TxtPesoBruto;
        private C1.Win.C1Input.C1TextBox TxtMarca;
        private System.Windows.Forms.Label label7;
        private C1.Win.C1Input.C1TextBox TxtTara;
        private C1.Win.C1Input.C1TextBox TxtConfiguracionVehicular;
        private C1.Win.C1Input.C1TextBox TxtCertificadoInscripcion;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox TxtPlaca;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1List.C1Combo CboEmpresa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider ErrProvider;
        private System.Windows.Forms.Label lblEstado;
        private C1.Win.C1Input.C1TextBox TxtPlaca2;
        private System.Windows.Forms.Label label2;
    }
}
