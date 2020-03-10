namespace Halley.Presentacion.Ventas.Reporte
{
    partial class RptReservasFecha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptReservasFecha));
            this.CrvReservas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnMostrar = new C1.Win.C1Input.C1Button();
            this.DtpFechaIni = new System.Windows.Forms.DateTimePicker();
            this.DtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CboProducto = new C1.Win.C1List.C1Combo();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CboProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // CrvReservas
            // 
            this.CrvReservas.ActiveViewIndex = -1;
            this.CrvReservas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CrvReservas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CrvReservas.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrvReservas.Location = new System.Drawing.Point(16, 36);
            this.CrvReservas.Name = "CrvReservas";
            this.CrvReservas.Size = new System.Drawing.Size(746, 748);
            this.CrvReservas.TabIndex = 348;
            this.CrvReservas.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnMostrar
            // 
            this.btnMostrar.Image = global::Halley.Presentacion.Properties.Resources.Perfil_16x16;
            this.btnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMostrar.Location = new System.Drawing.Point(732, 12);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(82, 23);
            this.btnMostrar.TabIndex = 349;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // DtpFechaIni
            // 
            this.DtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaIni.Location = new System.Drawing.Point(540, 13);
            this.DtpFechaIni.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFechaIni.Name = "DtpFechaIni";
            this.DtpFechaIni.Size = new System.Drawing.Size(81, 22);
            this.DtpFechaIni.TabIndex = 350;
            // 
            // DtpFechaFin
            // 
            this.DtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaFin.Location = new System.Drawing.Point(645, 13);
            this.DtpFechaFin.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFechaFin.Name = "DtpFechaFin";
            this.DtpFechaFin.Size = new System.Drawing.Size(81, 22);
            this.DtpFechaFin.TabIndex = 351;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(497, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 352;
            this.label1.Text = "Entre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(629, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 353;
            this.label2.Text = "Y";
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
            this.CboProducto.Location = new System.Drawing.Point(169, 12);
            this.CboProducto.MatchEntryTimeout = ((long)(2000));
            this.CboProducto.MaxDropDownItems = ((short)(10));
            this.CboProducto.MaxLength = 32767;
            this.CboProducto.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboProducto.Name = "CboProducto";
            this.CboProducto.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboProducto.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboProducto.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboProducto.Size = new System.Drawing.Size(322, 23);
            this.CboProducto.TabIndex = 382;
            this.CboProducto.ValueMember = "EmpresaID";
            this.CboProducto.PropBag = resources.GetString("CboProducto.PropBag");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(106, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 381;
            this.label12.Text = "Producto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 21);
            this.label3.TabIndex = 397;
            this.label3.Text = "Reservas";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RptReservasFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CboProducto);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpFechaFin);
            this.Controls.Add(this.DtpFechaIni);
            this.Controls.Add(this.CrvReservas);
            this.Controls.Add(this.btnMostrar);
            this.Name = "RptReservasFecha";
            this.Size = new System.Drawing.Size(1157, 536);
            this.Load += new System.EventHandler(this.RptVendedor_Load);
            this.Controls.SetChildIndex(this.btnMostrar, 0);
            this.Controls.SetChildIndex(this.CrvReservas, 0);
            this.Controls.SetChildIndex(this.DtpFechaIni, 0);
            this.Controls.SetChildIndex(this.DtpFechaFin, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.CboProducto, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.CboProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrvReservas;
        private C1.Win.C1Input.C1Button btnMostrar;
        private System.Windows.Forms.DateTimePicker DtpFechaIni;
        private System.Windows.Forms.DateTimePicker DtpFechaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1List.C1Combo CboProducto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
    }
}
