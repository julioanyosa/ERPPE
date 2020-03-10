namespace Halley.Presentacion.Mantenimiento.Empresa
{
    partial class MantenimientoEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MantenimientoEmpresa));
            this.lblEstado = new System.Windows.Forms.Label();
            this.TxtNomEmpresa = new C1.Win.C1Input.C1TextBox();
            this.TxtEmpresaID = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnNuevo = new C1.Win.C1Input.C1Button();
            this.BtnGuardar = new C1.Win.C1Input.C1Button();
            this.BtnEditar = new C1.Win.C1Input.C1Button();
            this.BtnCancelar = new C1.Win.C1Input.C1Button();
            this.BtnEliminar = new C1.Win.C1Input.C1Button();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.TxtDomicilioFiscal = new C1.Win.C1Input.C1TextBox();
            this.TxtRUC = new C1.Win.C1Input.C1TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtTelefono = new C1.Win.C1Input.C1TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.TdgEmpresa = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.BtnCargar = new C1.Win.C1Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNomEmpresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEmpresaID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDomicilioFiscal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRUC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTelefono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgEmpresa)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEstado.Location = new System.Drawing.Point(370, 60);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(12, 13);
            this.lblEstado.TabIndex = 237;
            this.lblEstado.Text = "*";
            // 
            // TxtNomEmpresa
            // 
            this.TxtNomEmpresa.BackColor = System.Drawing.Color.White;
            this.TxtNomEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNomEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNomEmpresa.Location = new System.Drawing.Point(102, 53);
            this.TxtNomEmpresa.MaxLength = 100;
            this.TxtNomEmpresa.Name = "TxtNomEmpresa";
            this.TxtNomEmpresa.Size = new System.Drawing.Size(262, 20);
            this.TxtNomEmpresa.TabIndex = 235;
            this.TxtNomEmpresa.Tag = null;
            this.TxtNomEmpresa.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtNomEmpresa.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // TxtEmpresaID
            // 
            this.TxtEmpresaID.BackColor = System.Drawing.Color.White;
            this.TxtEmpresaID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtEmpresaID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtEmpresaID.Location = new System.Drawing.Point(102, 25);
            this.TxtEmpresaID.MaxLength = 2;
            this.TxtEmpresaID.Name = "TxtEmpresaID";
            this.TxtEmpresaID.Size = new System.Drawing.Size(48, 20);
            this.TxtEmpresaID.TabIndex = 234;
            this.TxtEmpresaID.Tag = null;
            this.TxtEmpresaID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtEmpresaID.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtEmpresaID.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 233;
            this.label1.Text = "Razón social:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 232;
            this.label4.Text = "ID:";
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Image = global::Halley.Presentacion.Properties.Resources.newdocument_16x16;
            this.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNuevo.Location = new System.Drawing.Point(440, 81);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(82, 23);
            this.BtnNuevo.TabIndex = 231;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Image = global::Halley.Presentacion.Properties.Resources.save_16x16;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(440, 174);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(82, 23);
            this.BtnGuardar.TabIndex = 230;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.Image = global::Halley.Presentacion.Properties.Resources.edit_16x16;
            this.BtnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEditar.Location = new System.Drawing.Point(440, 143);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(82, 23);
            this.BtnEditar.TabIndex = 229;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEditar.UseVisualStyleBackColor = true;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Image = global::Halley.Presentacion.Properties.Resources.cancel_16x16;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(440, 112);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(82, 23);
            this.BtnCancelar.TabIndex = 228;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Image = global::Halley.Presentacion.Properties.Resources.delete_16x16;
            this.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEliminar.Location = new System.Drawing.Point(440, 205);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(82, 23);
            this.BtnEliminar.TabIndex = 227;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // TxtDomicilioFiscal
            // 
            this.TxtDomicilioFiscal.BackColor = System.Drawing.Color.White;
            this.TxtDomicilioFiscal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDomicilioFiscal.Location = new System.Drawing.Point(102, 112);
            this.TxtDomicilioFiscal.MaxLength = 150;
            this.TxtDomicilioFiscal.Name = "TxtDomicilioFiscal";
            this.TxtDomicilioFiscal.Size = new System.Drawing.Size(306, 20);
            this.TxtDomicilioFiscal.TabIndex = 241;
            this.TxtDomicilioFiscal.Tag = null;
            this.TxtDomicilioFiscal.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtDomicilioFiscal.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // TxtRUC
            // 
            this.TxtRUC.BackColor = System.Drawing.Color.White;
            this.TxtRUC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtRUC.Location = new System.Drawing.Point(102, 84);
            this.TxtRUC.MaxLength = 11;
            this.TxtRUC.Name = "TxtRUC";
            this.TxtRUC.Size = new System.Drawing.Size(110, 20);
            this.TxtRUC.TabIndex = 240;
            this.TxtRUC.Tag = null;
            this.TxtRUC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtRUC.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtRUC.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.TxtRUC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtRUC_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 239;
            this.label2.Text = "Domicilio Fiscal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 238;
            this.label3.Text = "RUC:";
            // 
            // TxtTelefono
            // 
            this.TxtTelefono.BackColor = System.Drawing.Color.White;
            this.TxtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtTelefono.Location = new System.Drawing.Point(102, 138);
            this.TxtTelefono.MaxLength = 15;
            this.TxtTelefono.Name = "TxtTelefono";
            this.TxtTelefono.Size = new System.Drawing.Size(110, 20);
            this.TxtTelefono.TabIndex = 244;
            this.TxtTelefono.Tag = null;
            this.TxtTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtTelefono.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtTelefono.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 243;
            this.label5.Text = "Logo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 242;
            this.label6.Text = "Telefono:";
            // 
            // PbLogo
            // 
            this.PbLogo.BackColor = System.Drawing.Color.White;
            this.PbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbLogo.Location = new System.Drawing.Point(102, 164);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(207, 89);
            this.PbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbLogo.TabIndex = 245;
            this.PbLogo.TabStop = false;
            // 
            // TdgEmpresa
            // 
            this.TdgEmpresa.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.IndividualRows;
            this.TdgEmpresa.AllowUpdate = false;
            this.TdgEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.TdgEmpresa.CaptionHeight = 17;
            this.TdgEmpresa.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgEmpresa.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgEmpresa.Images"))));
            this.TdgEmpresa.Location = new System.Drawing.Point(15, 280);
            this.TdgEmpresa.Name = "TdgEmpresa";
            this.TdgEmpresa.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgEmpresa.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgEmpresa.PreviewInfo.ZoomFactor = 75D;
            this.TdgEmpresa.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgEmpresa.PrintInfo.PageSettings")));
            this.TdgEmpresa.RowHeight = 79;
            this.TdgEmpresa.Size = new System.Drawing.Size(836, 208);
            this.TdgEmpresa.TabIndex = 246;
            this.TdgEmpresa.Text = "c1TrueDBGrid1";
            this.TdgEmpresa.FetchCellStyle += new C1.Win.C1TrueDBGrid.FetchCellStyleEventHandler(this.TdgEmpresa_FetchCellStyle);
            this.TdgEmpresa.DoubleClick += new System.EventHandler(this.TdgEmpresa_DoubleClick);
            this.TdgEmpresa.PropBag = resources.GetString("TdgEmpresa.PropBag");
            // 
            // BtnCargar
            // 
            this.BtnCargar.Enabled = false;
            this.BtnCargar.Image = global::Halley.Presentacion.Properties.Resources.Add_16x16;
            this.BtnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCargar.Location = new System.Drawing.Point(315, 164);
            this.BtnCargar.Name = "BtnCargar";
            this.BtnCargar.Size = new System.Drawing.Size(24, 23);
            this.BtnCargar.TabIndex = 247;
            this.BtnCargar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCargar.UseVisualStyleBackColor = true;
            this.BtnCargar.Click += new System.EventHandler(this.BtnCargar_Click);
            // 
            // MantenimientoEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnCargar);
            this.Controls.Add(this.TdgEmpresa);
            this.Controls.Add(this.PbLogo);
            this.Controls.Add(this.TxtTelefono);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtDomicilioFiscal);
            this.Controls.Add(this.TxtRUC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.TxtNomEmpresa);
            this.Controls.Add(this.TxtEmpresaID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnEditar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnEliminar);
            this.Name = "MantenimientoEmpresa";
            this.Size = new System.Drawing.Size(916, 516);
            this.Load += new System.EventHandler(this.MantenimientoEmpresa_Load);
            this.Controls.SetChildIndex(this.BtnEliminar, 0);
            this.Controls.SetChildIndex(this.BtnCancelar, 0);
            this.Controls.SetChildIndex(this.BtnEditar, 0);
            this.Controls.SetChildIndex(this.BtnGuardar, 0);
            this.Controls.SetChildIndex(this.BtnNuevo, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.TxtEmpresaID, 0);
            this.Controls.SetChildIndex(this.TxtNomEmpresa, 0);
            this.Controls.SetChildIndex(this.lblEstado, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.TxtRUC, 0);
            this.Controls.SetChildIndex(this.TxtDomicilioFiscal, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.TxtTelefono, 0);
            this.Controls.SetChildIndex(this.PbLogo, 0);
            this.Controls.SetChildIndex(this.TdgEmpresa, 0);
            this.Controls.SetChildIndex(this.BtnCargar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.TxtNomEmpresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEmpresaID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDomicilioFiscal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRUC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTelefono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgEmpresa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEstado;
        private C1.Win.C1Input.C1TextBox TxtNomEmpresa;
        private C1.Win.C1Input.C1TextBox TxtEmpresaID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1Button BtnNuevo;
        private C1.Win.C1Input.C1Button BtnGuardar;
        private C1.Win.C1Input.C1Button BtnEditar;
        private C1.Win.C1Input.C1Button BtnCancelar;
        private C1.Win.C1Input.C1Button BtnEliminar;
        private System.Windows.Forms.ErrorProvider ErrProvider;
        private C1.Win.C1Input.C1TextBox TxtTelefono;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private C1.Win.C1Input.C1TextBox TxtDomicilioFiscal;
        private C1.Win.C1Input.C1TextBox TxtRUC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgEmpresa;
        private System.Windows.Forms.PictureBox PbLogo;
        private C1.Win.C1Input.C1Button BtnCargar;
    }
}
