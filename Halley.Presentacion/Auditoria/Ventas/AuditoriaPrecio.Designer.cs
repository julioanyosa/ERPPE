namespace Halley.Presentacion.Auditoria.Ventas
{
    partial class AuditoriaPrecio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuditoriaPrecio));
            this.label3 = new System.Windows.Forms.Label();
            this.c1cboCia = new C1.Win.C1List.C1Combo();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CboSede = new C1.Win.C1List.C1Combo();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.DtpFechaIni = new System.Windows.Forms.DateTimePicker();
            this.CrvResumenVentas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnGenerar = new C1.Win.C1Input.C1Button();
            this.CboAdministradores = new C1.Win.C1List.C1Combo();
            this.label7 = new System.Windows.Forms.Label();
            this.CboProducto = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboSede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboAdministradores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 42);
            this.label3.TabIndex = 406;
            this.label3.Text = "Reporte\r\nvariación de precios";
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
            this.c1cboCia.Location = new System.Drawing.Point(280, 3);
            this.c1cboCia.MatchEntryTimeout = ((long)(2000));
            this.c1cboCia.MaxDropDownItems = ((short)(10));
            this.c1cboCia.MaxLength = 32767;
            this.c1cboCia.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.c1cboCia.Name = "c1cboCia";
            this.c1cboCia.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.c1cboCia.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1cboCia.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1cboCia.Size = new System.Drawing.Size(160, 23);
            this.c1cboCia.TabIndex = 404;
            this.c1cboCia.ValueMember = "EmpresaID";
            this.c1cboCia.PropBag = resources.GetString("c1cboCia.PropBag");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(191, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 405;
            this.label14.Text = "Empresa:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(447, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 403;
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
            this.CboSede.Location = new System.Drawing.Point(488, 3);
            this.CboSede.MatchEntryTimeout = ((long)(2000));
            this.CboSede.MaxDropDownItems = ((short)(10));
            this.CboSede.MaxLength = 32767;
            this.CboSede.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboSede.Name = "CboSede";
            this.CboSede.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboSede.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboSede.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboSede.Size = new System.Drawing.Size(277, 23);
            this.CboSede.TabIndex = 402;
            this.CboSede.ValueMember = "EmpresaID";
            this.CboSede.PropBag = resources.GetString("CboSede.PropBag");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(667, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 401;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(535, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 400;
            this.label1.Text = "Entre:";
            // 
            // DtpFechaFin
            // 
            this.DtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaFin.Location = new System.Drawing.Point(683, 58);
            this.DtpFechaFin.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFechaFin.Name = "DtpFechaFin";
            this.DtpFechaFin.Size = new System.Drawing.Size(81, 22);
            this.DtpFechaFin.TabIndex = 399;
            // 
            // DtpFechaIni
            // 
            this.DtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaIni.Location = new System.Drawing.Point(578, 58);
            this.DtpFechaIni.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFechaIni.Name = "DtpFechaIni";
            this.DtpFechaIni.Size = new System.Drawing.Size(81, 22);
            this.DtpFechaIni.TabIndex = 398;
            // 
            // CrvResumenVentas
            // 
            this.CrvResumenVentas.ActiveViewIndex = -1;
            this.CrvResumenVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CrvResumenVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrvResumenVentas.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrvResumenVentas.Location = new System.Drawing.Point(16, 97);
            this.CrvResumenVentas.Name = "CrvResumenVentas";
            this.CrvResumenVentas.Size = new System.Drawing.Size(982, 361);
            this.CrvResumenVentas.TabIndex = 396;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(770, 60);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(82, 23);
            this.btnGenerar.TabIndex = 397;
            this.btnGenerar.Text = "Consultar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // CboAdministradores
            // 
            this.CboAdministradores.AddItemSeparator = ';';
            this.CboAdministradores.AutoCompletion = true;
            this.CboAdministradores.AutoDropDown = true;
            this.CboAdministradores.Caption = "";
            this.CboAdministradores.CaptionHeight = 17;
            this.CboAdministradores.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboAdministradores.ColumnCaptionHeight = 17;
            this.CboAdministradores.ColumnFooterHeight = 17;
            this.CboAdministradores.ColumnHeaders = false;
            this.CboAdministradores.ContentHeight = 17;
            this.CboAdministradores.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboAdministradores.DisplayMember = "NomEmpresa";
            this.CboAdministradores.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboAdministradores.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboAdministradores.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboAdministradores.EditorHeight = 17;
            this.CboAdministradores.Images.Add(((System.Drawing.Image)(resources.GetObject("CboAdministradores.Images"))));
            this.CboAdministradores.ItemHeight = 15;
            this.CboAdministradores.Location = new System.Drawing.Point(280, 60);
            this.CboAdministradores.MatchEntryTimeout = ((long)(2000));
            this.CboAdministradores.MaxDropDownItems = ((short)(10));
            this.CboAdministradores.MaxLength = 32767;
            this.CboAdministradores.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboAdministradores.Name = "CboAdministradores";
            this.CboAdministradores.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboAdministradores.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboAdministradores.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboAdministradores.Size = new System.Drawing.Size(232, 23);
            this.CboAdministradores.TabIndex = 408;
            this.CboAdministradores.ValueMember = "EmpresaID";
            this.CboAdministradores.PropBag = resources.GetString("CboAdministradores.PropBag");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(191, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 407;
            this.label7.Text = "Administrador:";
            // 
            // CboProducto
            // 
            this.CboProducto.AddItemSeparator = ';';
            this.CboProducto.AutoCompletion = true;
            this.CboProducto.AutoDropDown = true;
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
            this.CboProducto.Location = new System.Drawing.Point(280, 32);
            this.CboProducto.MatchEntryTimeout = ((long)(2000));
            this.CboProducto.MaxDropDownItems = ((short)(10));
            this.CboProducto.MaxLength = 32767;
            this.CboProducto.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboProducto.Name = "CboProducto";
            this.CboProducto.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboProducto.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboProducto.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboProducto.Size = new System.Drawing.Size(322, 23);
            this.CboProducto.TabIndex = 410;
            this.CboProducto.ValueMember = "EmpresaID";
            this.CboProducto.PropBag = resources.GetString("CboProducto.PropBag");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(191, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 409;
            this.label12.Text = "Producto:";
            // 
            // AuditoriaPrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CboProducto);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.CboAdministradores);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.c1cboCia);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CboSede);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpFechaFin);
            this.Controls.Add(this.DtpFechaIni);
            this.Controls.Add(this.CrvResumenVentas);
            this.Controls.Add(this.btnGenerar);
            this.Name = "AuditoriaPrecio";
            this.Size = new System.Drawing.Size(1001, 473);
            this.Load += new System.EventHandler(this.VariacionPrecio_Load);
            this.Controls.SetChildIndex(this.btnGenerar, 0);
            this.Controls.SetChildIndex(this.CrvResumenVentas, 0);
            this.Controls.SetChildIndex(this.DtpFechaIni, 0);
            this.Controls.SetChildIndex(this.DtpFechaFin, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.CboSede, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.c1cboCia, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.CboAdministradores, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.CboProducto, 0);
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboSede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboAdministradores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private C1.Win.C1List.C1Combo c1cboCia;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private C1.Win.C1List.C1Combo CboSede;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpFechaFin;
        private System.Windows.Forms.DateTimePicker DtpFechaIni;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrvResumenVentas;
        private C1.Win.C1Input.C1Button btnGenerar;
        private C1.Win.C1List.C1Combo CboAdministradores;
        private System.Windows.Forms.Label label7;
        private C1.Win.C1List.C1Combo CboProducto;
        private System.Windows.Forms.Label label12;
    }
}
