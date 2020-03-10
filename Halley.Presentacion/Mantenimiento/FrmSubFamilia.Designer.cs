namespace Halley.Presentacion.Mantenimiento
{
    partial class FrmSubFamilia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSubFamilia));
            this.TxtNomSubFamilia = new C1.Win.C1Input.C1TextBox();
            this.TxtSubFamiliaID = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnNuevo = new C1.Win.C1Input.C1Button();
            this.BtnGuardar = new C1.Win.C1Input.C1Button();
            this.BtnEditar = new C1.Win.C1Input.C1Button();
            this.BtnCancelar = new C1.Win.C1Input.C1Button();
            this.BtnEliminar = new C1.Win.C1Input.C1Button();
            this.TdgSubfamilia = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblEstado = new System.Windows.Forms.Label();
            this.BtnUnidadMedida = new C1.Win.C1Input.C1Button();
            this.label6 = new System.Windows.Forms.Label();
            this.CboFamilia = new C1.Win.C1List.C1Combo();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNomSubFamilia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSubFamiliaID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgSubfamilia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboFamilia)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtNomSubFamilia
            // 
            this.TxtNomSubFamilia.BackColor = System.Drawing.Color.White;
            this.TxtNomSubFamilia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNomSubFamilia.Location = new System.Drawing.Point(118, 45);
            this.TxtNomSubFamilia.MaxLength = 150;
            this.TxtNomSubFamilia.Name = "TxtNomSubFamilia";
            this.TxtNomSubFamilia.Size = new System.Drawing.Size(207, 18);
            this.TxtNomSubFamilia.TabIndex = 224;
            this.TxtNomSubFamilia.Tag = null;
            this.TxtNomSubFamilia.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtNomSubFamilia.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // TxtSubFamiliaID
            // 
            this.TxtSubFamiliaID.BackColor = System.Drawing.Color.White;
            this.TxtSubFamiliaID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSubFamiliaID.Location = new System.Drawing.Point(118, 17);
            this.TxtSubFamiliaID.MaxLength = 2;
            this.TxtSubFamiliaID.Name = "TxtSubFamiliaID";
            this.TxtSubFamiliaID.Size = new System.Drawing.Size(32, 18);
            this.TxtSubFamiliaID.TabIndex = 223;
            this.TxtSubFamiliaID.Tag = null;
            this.TxtSubFamiliaID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtSubFamiliaID.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtSubFamiliaID.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 222;
            this.label1.Text = "Descripción:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 221;
            this.label4.Text = "ID:";
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Image = global::Halley.Presentacion.Properties.Resources.newdocument_16x16;
            this.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNuevo.Location = new System.Drawing.Point(517, 73);
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
            this.BtnGuardar.Location = new System.Drawing.Point(517, 166);
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
            this.BtnEditar.Location = new System.Drawing.Point(517, 135);
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
            this.BtnCancelar.Location = new System.Drawing.Point(517, 104);
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
            this.BtnEliminar.Location = new System.Drawing.Point(517, 197);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(82, 23);
            this.BtnEliminar.TabIndex = 216;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // TdgSubfamilia
            // 
            this.TdgSubfamilia.AllowUpdate = false;
            this.TdgSubfamilia.CaptionHeight = 17;
            this.TdgSubfamilia.EmptyRows = true;
            this.TdgSubfamilia.FilterBar = true;
            this.TdgSubfamilia.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgSubfamilia.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgSubfamilia.Images"))));
            this.TdgSubfamilia.Location = new System.Drawing.Point(36, 116);
            this.TdgSubfamilia.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgSubfamilia.Name = "TdgSubfamilia";
            this.TdgSubfamilia.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgSubfamilia.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgSubfamilia.PreviewInfo.ZoomFactor = 75D;
            this.TdgSubfamilia.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgSubfamilia.PrintInfo.PageSettings")));
            this.TdgSubfamilia.RowHeight = 18;
            this.TdgSubfamilia.Size = new System.Drawing.Size(449, 134);
            this.TdgSubfamilia.TabIndex = 225;
            this.TdgSubfamilia.Text = "c1TrueDBGrid1";
            this.TdgSubfamilia.DoubleClick += new System.EventHandler(this.TdgUnidadMedida_DoubleClick);
            this.TdgSubfamilia.PropBag = resources.GetString("TdgSubfamilia.PropBag");
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEstado.Location = new System.Drawing.Point(341, 50);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(11, 13);
            this.lblEstado.TabIndex = 226;
            this.lblEstado.Text = "*";
            // 
            // BtnUnidadMedida
            // 
            this.BtnUnidadMedida.Image = global::Halley.Presentacion.Properties.Resources.Mantenimiento_16x16;
            this.BtnUnidadMedida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUnidadMedida.Location = new System.Drawing.Point(383, 69);
            this.BtnUnidadMedida.Name = "BtnUnidadMedida";
            this.BtnUnidadMedida.Size = new System.Drawing.Size(45, 23);
            this.BtnUnidadMedida.TabIndex = 397;
            this.BtnUnidadMedida.Text = "...";
            this.BtnUnidadMedida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUnidadMedida.UseVisualStyleBackColor = true;
            this.BtnUnidadMedida.Click += new System.EventHandler(this.BtnUnidadMedida_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 396;
            this.label6.Text = "Familia:";
            // 
            // CboFamilia
            // 
            this.CboFamilia.AddItemSeparator = ';';
            this.CboFamilia.AutoCompletion = true;
            this.CboFamilia.AutoDropDown = true;
            this.CboFamilia.Caption = "Seleccione Producto";
            this.CboFamilia.CaptionHeight = 17;
            this.CboFamilia.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboFamilia.ColumnCaptionHeight = 17;
            this.CboFamilia.ColumnFooterHeight = 17;
            this.CboFamilia.ColumnHeaders = false;
            this.CboFamilia.ContentHeight = 17;
            this.CboFamilia.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboFamilia.DisplayMember = "NomEmpresa";
            this.CboFamilia.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboFamilia.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboFamilia.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboFamilia.EditorHeight = 17;
            this.CboFamilia.Images.Add(((System.Drawing.Image)(resources.GetObject("CboFamilia.Images"))));
            this.CboFamilia.ItemHeight = 15;
            this.CboFamilia.Location = new System.Drawing.Point(118, 69);
            this.CboFamilia.MatchEntryTimeout = ((long)(2000));
            this.CboFamilia.MaxDropDownItems = ((short)(10));
            this.CboFamilia.MaxLength = 32767;
            this.CboFamilia.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboFamilia.Name = "CboFamilia";
            this.CboFamilia.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboFamilia.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboFamilia.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboFamilia.Size = new System.Drawing.Size(259, 23);
            this.CboFamilia.TabIndex = 395;
            this.CboFamilia.ValueMember = "EmpresaID";
            this.CboFamilia.PropBag = resources.GetString("CboFamilia.PropBag");
            // 
            // FrmSubFamilia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 262);
            this.Controls.Add(this.BtnUnidadMedida);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CboFamilia);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.TdgSubfamilia);
            this.Controls.Add(this.TxtNomSubFamilia);
            this.Controls.Add(this.TxtSubFamiliaID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnEditar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnEliminar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSubFamilia";
            this.Text = "Mantenimiento de Subfamilia";
            this.Load += new System.EventHandler(this.FrmUnidadMedidacs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtNomSubFamilia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSubFamiliaID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgSubfamilia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboFamilia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1TextBox TxtNomSubFamilia;
        private C1.Win.C1Input.C1TextBox TxtSubFamiliaID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1Button BtnNuevo;
        private C1.Win.C1Input.C1Button BtnGuardar;
        private C1.Win.C1Input.C1Button BtnEditar;
        private C1.Win.C1Input.C1Button BtnCancelar;
        private C1.Win.C1Input.C1Button BtnEliminar;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgSubfamilia;
        private System.Windows.Forms.ErrorProvider ErrProvider;
        private System.Windows.Forms.Label lblEstado;
        private C1.Win.C1Input.C1Button BtnUnidadMedida;
        private System.Windows.Forms.Label label6;
        private C1.Win.C1List.C1Combo CboFamilia;
    }
}