namespace Halley.Presentacion.Mantenimiento
{
    partial class MantenimientoChofer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MantenimientoChofer));
            this.BtnNuevo = new C1.Win.C1Input.C1Button();
            this.BtnGuardar = new C1.Win.C1Input.C1Button();
            this.BtnEditar = new C1.Win.C1Input.C1Button();
            this.BtnCancelar = new C1.Win.C1Input.C1Button();
            this.BtnEliminar = new C1.Win.C1Input.C1Button();
            this.btnBuscar = new C1.Win.C1Input.C1Button();
            this.TxtApeChofer = new C1.Win.C1Input.C1TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtLicencia = new C1.Win.C1Input.C1TextBox();
            this.TxtDNI = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNomChofer = new C1.Win.C1Input.C1TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CboEmpresa = new C1.Win.C1List.C1Combo();
            this.label8 = new System.Windows.Forms.Label();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblEstado = new System.Windows.Forms.Label();
            this.TxtChoferID = new C1.Win.C1Input.C1TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtDNI2 = new C1.Win.C1Input.C1TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TxtApeChofer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLicencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDNI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNomChofer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboEmpresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtChoferID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDNI2)).BeginInit();
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
            this.btnBuscar.Location = new System.Drawing.Point(551, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(82, 23);
            this.btnBuscar.TabIndex = 192;
            this.btnBuscar.Text = "Consultar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // TxtApeChofer
            // 
            this.TxtApeChofer.BackColor = System.Drawing.Color.White;
            this.TxtApeChofer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtApeChofer.Location = new System.Drawing.Point(193, 162);
            this.TxtApeChofer.MaxLength = 20;
            this.TxtApeChofer.Name = "TxtApeChofer";
            this.TxtApeChofer.Size = new System.Drawing.Size(184, 20);
            this.TxtApeChofer.TabIndex = 206;
            this.TxtApeChofer.Tag = null;
            this.TxtApeChofer.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtApeChofer.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(132, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 207;
            this.label7.Text = "Apellidos";
            // 
            // TxtLicencia
            // 
            this.TxtLicencia.BackColor = System.Drawing.Color.White;
            this.TxtLicencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtLicencia.Location = new System.Drawing.Point(193, 218);
            this.TxtLicencia.MaxLength = 20;
            this.TxtLicencia.Name = "TxtLicencia";
            this.TxtLicencia.Size = new System.Drawing.Size(184, 20);
            this.TxtLicencia.TabIndex = 204;
            this.TxtLicencia.Tag = null;
            this.TxtLicencia.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtLicencia.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // TxtDNI
            // 
            this.TxtDNI.BackColor = System.Drawing.Color.White;
            this.TxtDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDNI.Location = new System.Drawing.Point(193, 190);
            this.TxtDNI.MaxLength = 8;
            this.TxtDNI.Name = "TxtDNI";
            this.TxtDNI.Size = new System.Drawing.Size(112, 20);
            this.TxtDNI.TabIndex = 203;
            this.TxtDNI.Tag = null;
            this.TxtDNI.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtDNI.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.TxtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDNI_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 202;
            this.label1.Text = "Licencia:";
            // 
            // TxtNomChofer
            // 
            this.TxtNomChofer.BackColor = System.Drawing.Color.White;
            this.TxtNomChofer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNomChofer.Location = new System.Drawing.Point(193, 134);
            this.TxtNomChofer.MaxLength = 20;
            this.TxtNomChofer.Name = "TxtNomChofer";
            this.TxtNomChofer.Size = new System.Drawing.Size(184, 20);
            this.TxtNomChofer.TabIndex = 198;
            this.TxtNomChofer.Tag = null;
            this.TxtNomChofer.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtNomChofer.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 200;
            this.label4.Text = "DNI:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 199;
            this.label3.Text = "Nombres:";
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
            this.CboEmpresa.Location = new System.Drawing.Point(193, 98);
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
            this.label8.Location = new System.Drawing.Point(134, 105);
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
            this.lblEstado.Location = new System.Drawing.Point(190, 251);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(12, 13);
            this.lblEstado.TabIndex = 212;
            this.lblEstado.Text = "*";
            // 
            // TxtChoferID
            // 
            this.TxtChoferID.BackColor = System.Drawing.Color.White;
            this.TxtChoferID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtChoferID.Location = new System.Drawing.Point(193, 72);
            this.TxtChoferID.MaxLength = 10;
            this.TxtChoferID.Name = "TxtChoferID";
            this.TxtChoferID.Size = new System.Drawing.Size(100, 20);
            this.TxtChoferID.TabIndex = 213;
            this.TxtChoferID.Tag = null;
            this.TxtChoferID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtChoferID.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtChoferID.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 214;
            this.label2.Text = "ID:";
            // 
            // TxtDNI2
            // 
            this.TxtDNI2.BackColor = System.Drawing.Color.White;
            this.TxtDNI2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDNI2.Location = new System.Drawing.Point(445, 12);
            this.TxtDNI2.MaxLength = 8;
            this.TxtDNI2.Name = "TxtDNI2";
            this.TxtDNI2.Size = new System.Drawing.Size(100, 20);
            this.TxtDNI2.TabIndex = 215;
            this.TxtDNI2.Tag = null;
            this.TxtDNI2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtDNI2.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtDNI2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(314, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 216;
            this.label5.Text = "Ingrese DNI del chofer:";
            // 
            // MantenimientoChofer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtDNI2);
            this.Controls.Add(this.TxtChoferID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.CboEmpresa);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtApeChofer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtLicencia);
            this.Controls.Add(this.TxtDNI);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtNomChofer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnEditar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.btnBuscar);
            this.Name = "MantenimientoChofer";
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
            this.Controls.SetChildIndex(this.TxtNomChofer, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.TxtDNI, 0);
            this.Controls.SetChildIndex(this.TxtLicencia, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.TxtApeChofer, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.CboEmpresa, 0);
            this.Controls.SetChildIndex(this.lblEstado, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.TxtChoferID, 0);
            this.Controls.SetChildIndex(this.TxtDNI2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            ((System.ComponentModel.ISupportInitialize)(this.TxtApeChofer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLicencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDNI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNomChofer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboEmpresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtChoferID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDNI2)).EndInit();
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
        private C1.Win.C1Input.C1TextBox TxtApeChofer;
        private System.Windows.Forms.Label label7;
        private C1.Win.C1Input.C1TextBox TxtLicencia;
        private C1.Win.C1Input.C1TextBox TxtDNI;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox TxtNomChofer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1List.C1Combo CboEmpresa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider ErrProvider;
        private System.Windows.Forms.Label lblEstado;
        private C1.Win.C1Input.C1TextBox TxtChoferID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private C1.Win.C1Input.C1TextBox TxtDNI2;
    }
}
