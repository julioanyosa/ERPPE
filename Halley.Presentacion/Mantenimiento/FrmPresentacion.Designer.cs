namespace Halley.Presentacion.Mantenimiento
{
    partial class FrmPresentacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPresentacion));
            this.TxtNomPresentacion = new C1.Win.C1Input.C1TextBox();
            this.TxtPresentacionID = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnNuevo = new C1.Win.C1Input.C1Button();
            this.BtnGuardar = new C1.Win.C1Input.C1Button();
            this.BtnEditar = new C1.Win.C1Input.C1Button();
            this.BtnCancelar = new C1.Win.C1Input.C1Button();
            this.BtnEliminar = new C1.Win.C1Input.C1Button();
            this.TdgPresentacion = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblEstado = new System.Windows.Forms.Label();
            this.TxtUnidades = new C1.Win.C1Input.C1TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CboUM = new C1.Win.C1List.C1Combo();
            this.BtnUnidadMedida = new C1.Win.C1Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNomPresentacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPresentacionID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgPresentacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUnidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboUM)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtNomPresentacion
            // 
            this.TxtNomPresentacion.BackColor = System.Drawing.Color.White;
            this.TxtNomPresentacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNomPresentacion.Location = new System.Drawing.Point(124, 45);
            this.TxtNomPresentacion.MaxLength = 50;
            this.TxtNomPresentacion.Name = "TxtNomPresentacion";
            this.TxtNomPresentacion.Size = new System.Drawing.Size(207, 18);
            this.TxtNomPresentacion.TabIndex = 224;
            this.TxtNomPresentacion.Tag = null;
            this.TxtNomPresentacion.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtNomPresentacion.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // TxtPresentacionID
            // 
            this.TxtPresentacionID.BackColor = System.Drawing.Color.White;
            this.TxtPresentacionID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPresentacionID.Location = new System.Drawing.Point(124, 17);
            this.TxtPresentacionID.MaxLength = 4;
            this.TxtPresentacionID.Name = "TxtPresentacionID";
            this.TxtPresentacionID.Size = new System.Drawing.Size(53, 18);
            this.TxtPresentacionID.TabIndex = 223;
            this.TxtPresentacionID.Tag = null;
            this.TxtPresentacionID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtPresentacionID.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtPresentacionID.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 222;
            this.label1.Text = "Descripción:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 221;
            this.label4.Text = "ID:";
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Image = global::Halley.Presentacion.Properties.Resources.newdocument_16x16;
            this.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNuevo.Location = new System.Drawing.Point(605, 73);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(82, 23);
            this.BtnNuevo.TabIndex = 220;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Image = global::Halley.Presentacion.Properties.Resources.save_16x16;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(605, 166);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(82, 23);
            this.BtnGuardar.TabIndex = 219;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.Image = global::Halley.Presentacion.Properties.Resources.edit_16x16;
            this.BtnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEditar.Location = new System.Drawing.Point(605, 135);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(82, 23);
            this.BtnEditar.TabIndex = 218;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEditar.UseVisualStyleBackColor = true;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Image = global::Halley.Presentacion.Properties.Resources.cancel_16x16;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(605, 104);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(82, 23);
            this.BtnCancelar.TabIndex = 217;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Image = global::Halley.Presentacion.Properties.Resources.delete_16x16;
            this.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEliminar.Location = new System.Drawing.Point(605, 197);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(82, 23);
            this.BtnEliminar.TabIndex = 216;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // TdgPresentacion
            // 
            this.TdgPresentacion.AllowUpdate = false;
            this.TdgPresentacion.CaptionHeight = 17;
            this.TdgPresentacion.EmptyRows = true;
            this.TdgPresentacion.FilterBar = true;
            this.TdgPresentacion.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgPresentacion.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgPresentacion.Images"))));
            this.TdgPresentacion.Location = new System.Drawing.Point(12, 146);
            this.TdgPresentacion.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgPresentacion.Name = "TdgPresentacion";
            this.TdgPresentacion.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgPresentacion.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgPresentacion.PreviewInfo.ZoomFactor = 75D;
            this.TdgPresentacion.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgPresentacion.PrintInfo.PageSettings")));
            this.TdgPresentacion.RowHeight = 18;
            this.TdgPresentacion.Size = new System.Drawing.Size(581, 180);
            this.TdgPresentacion.TabIndex = 225;
            this.TdgPresentacion.Text = "c1TrueDBGrid1";
            this.TdgPresentacion.DoubleClick += new System.EventHandler(this.TdgUnidadMedida_DoubleClick);
            this.TdgPresentacion.PropBag = resources.GetString("TdgPresentacion.PropBag");
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEstado.Location = new System.Drawing.Point(347, 50);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(11, 13);
            this.lblEstado.TabIndex = 226;
            this.lblEstado.Text = "*";
            // 
            // TxtUnidades
            // 
            this.TxtUnidades.BackColor = System.Drawing.Color.White;
            this.TxtUnidades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUnidades.Location = new System.Drawing.Point(124, 76);
            this.TxtUnidades.MaxLength = 20;
            this.TxtUnidades.Name = "TxtUnidades";
            this.TxtUnidades.Size = new System.Drawing.Size(102, 18);
            this.TxtUnidades.TabIndex = 228;
            this.TxtUnidades.Tag = null;
            this.TxtUnidades.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtUnidades.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.TxtUnidades.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUnidades_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 227;
            this.label2.Text = "Peso en Kg:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 361;
            this.label6.Text = "Unidad de Medida";
            // 
            // CboUM
            // 
            this.CboUM.AddItemSeparator = ';';
            this.CboUM.AutoCompletion = true;
            this.CboUM.AutoDropDown = true;
            this.CboUM.Caption = "Seleccione Producto";
            this.CboUM.CaptionHeight = 17;
            this.CboUM.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboUM.ColumnCaptionHeight = 17;
            this.CboUM.ColumnFooterHeight = 17;
            this.CboUM.ColumnHeaders = false;
            this.CboUM.ContentHeight = 17;
            this.CboUM.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboUM.DisplayMember = "NomEmpresa";
            this.CboUM.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboUM.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboUM.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboUM.EditorHeight = 17;
            this.CboUM.Images.Add(((System.Drawing.Image)(resources.GetObject("CboUM.Images"))));
            this.CboUM.ItemHeight = 15;
            this.CboUM.Location = new System.Drawing.Point(124, 104);
            this.CboUM.MatchEntryTimeout = ((long)(2000));
            this.CboUM.MaxDropDownItems = ((short)(10));
            this.CboUM.MaxLength = 32767;
            this.CboUM.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboUM.Name = "CboUM";
            this.CboUM.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboUM.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboUM.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboUM.Size = new System.Drawing.Size(259, 23);
            this.CboUM.TabIndex = 362;
            this.CboUM.ValueMember = "EmpresaID";
            this.CboUM.PropBag = resources.GetString("CboUM.PropBag");
            // 
            // BtnUnidadMedida
            // 
            this.BtnUnidadMedida.Image = global::Halley.Presentacion.Properties.Resources.Mantenimiento_16x16;
            this.BtnUnidadMedida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUnidadMedida.Location = new System.Drawing.Point(389, 104);
            this.BtnUnidadMedida.Name = "BtnUnidadMedida";
            this.BtnUnidadMedida.Size = new System.Drawing.Size(45, 23);
            this.BtnUnidadMedida.TabIndex = 395;
            this.BtnUnidadMedida.Text = "...";
            this.BtnUnidadMedida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUnidadMedida.UseVisualStyleBackColor = true;
            this.BtnUnidadMedida.Click += new System.EventHandler(this.BtnUnidadMedida_Click);
            // 
            // FrmPresentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 348);
            this.Controls.Add(this.BtnUnidadMedida);
            this.Controls.Add(this.CboUM);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtUnidades);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.TdgPresentacion);
            this.Controls.Add(this.TxtNomPresentacion);
            this.Controls.Add(this.TxtPresentacionID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnEditar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnEliminar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPresentacion";
            this.Text = "Mantenimto dePresentaciones";
            this.Load += new System.EventHandler(this.FrmUnidadMedidacs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtNomPresentacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPresentacionID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgPresentacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUnidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboUM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1TextBox TxtNomPresentacion;
        private C1.Win.C1Input.C1TextBox TxtPresentacionID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1Button BtnNuevo;
        private C1.Win.C1Input.C1Button BtnGuardar;
        private C1.Win.C1Input.C1Button BtnEditar;
        private C1.Win.C1Input.C1Button BtnCancelar;
        private C1.Win.C1Input.C1Button BtnEliminar;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgPresentacion;
        private System.Windows.Forms.ErrorProvider ErrProvider;
        private System.Windows.Forms.Label lblEstado;
        private C1.Win.C1Input.C1TextBox TxtUnidades;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private C1.Win.C1List.C1Combo CboUM;
        private C1.Win.C1Input.C1Button BtnUnidadMedida;
    }
}