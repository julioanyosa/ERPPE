namespace Halley.Presentacion.Almacen.Reportes
{
    partial class VentasPorCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentasPorCliente));
            this.useCliente1 = new Halley.Presentacion.Ventas.UseCliente();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnMostrar = new C1.Win.C1Input.C1Button();
            this.DtpFechaIni = new System.Windows.Forms.DateTimePicker();
            this.DtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CrvVentasCliente = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.c1cboCia = new C1.Win.C1List.C1Combo();
            this.label14 = new System.Windows.Forms.Label();
            this.TcVentasCliente = new System.Windows.Forms.TabControl();
            this.TpGeneral = new System.Windows.Forms.TabPage();
            this.TpPorComprobantes = new System.Windows.Forms.TabPage();
            this.CrvVentasClienteDetallado = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).BeginInit();
            this.TcVentasCliente.SuspendLayout();
            this.TpGeneral.SuspendLayout();
            this.TpPorComprobantes.SuspendLayout();
            this.SuspendLayout();
            // 
            // useCliente1
            // 
            this.useCliente1.Location = new System.Drawing.Point(3, 36);
            this.useCliente1.Name = "useCliente1";
            this.useCliente1.Size = new System.Drawing.Size(554, 129);
            this.useCliente1.TabIndex = 410;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 21);
            this.label1.TabIndex = 411;
            this.label1.Text = "VENTAS POR CLIENTES";
            // 
            // BtnMostrar
            // 
            this.BtnMostrar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.BtnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMostrar.Location = new System.Drawing.Point(636, 120);
            this.BtnMostrar.Name = "BtnMostrar";
            this.BtnMostrar.Size = new System.Drawing.Size(80, 25);
            this.BtnMostrar.TabIndex = 412;
            this.BtnMostrar.Text = "&Mostrar";
            this.BtnMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnMostrar.UseVisualStyleBackColor = true;
            this.BtnMostrar.Click += new System.EventHandler(this.BtnMostrar_Click);
            // 
            // DtpFechaIni
            // 
            this.DtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaIni.Location = new System.Drawing.Point(634, 64);
            this.DtpFechaIni.Name = "DtpFechaIni";
            this.DtpFechaIni.Size = new System.Drawing.Size(82, 22);
            this.DtpFechaIni.TabIndex = 413;
            // 
            // DtpFechaFin
            // 
            this.DtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaFin.Location = new System.Drawing.Point(634, 92);
            this.DtpFechaFin.Name = "DtpFechaFin";
            this.DtpFechaFin.Size = new System.Drawing.Size(82, 22);
            this.DtpFechaFin.TabIndex = 414;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(570, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 415;
            this.label2.Text = "Desde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(574, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 416;
            this.label3.Text = "hasta";
            // 
            // CrvVentasCliente
            // 
            this.CrvVentasCliente.ActiveViewIndex = -1;
            this.CrvVentasCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrvVentasCliente.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrvVentasCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrvVentasCliente.Location = new System.Drawing.Point(3, 3);
            this.CrvVentasCliente.Name = "CrvVentasCliente";
            this.CrvVentasCliente.Size = new System.Drawing.Size(699, 522);
            this.CrvVentasCliente.TabIndex = 417;
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
            this.c1cboCia.Location = new System.Drawing.Point(348, 12);
            this.c1cboCia.MatchEntryTimeout = ((long)(2000));
            this.c1cboCia.MaxDropDownItems = ((short)(10));
            this.c1cboCia.MaxLength = 32767;
            this.c1cboCia.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.c1cboCia.Name = "c1cboCia";
            this.c1cboCia.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.c1cboCia.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1cboCia.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1cboCia.Size = new System.Drawing.Size(199, 23);
            this.c1cboCia.TabIndex = 418;
            this.c1cboCia.ValueMember = "EmpresaID";
            this.c1cboCia.PropBag = resources.GetString("c1cboCia.PropBag");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(289, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 419;
            this.label14.Text = "Empresa:";
            // 
            // TcVentasCliente
            // 
            this.TcVentasCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TcVentasCliente.Controls.Add(this.TpGeneral);
            this.TcVentasCliente.Controls.Add(this.TpPorComprobantes);
            this.TcVentasCliente.Location = new System.Drawing.Point(3, 171);
            this.TcVentasCliente.Name = "TcVentasCliente";
            this.TcVentasCliente.SelectedIndex = 0;
            this.TcVentasCliente.Size = new System.Drawing.Size(713, 554);
            this.TcVentasCliente.TabIndex = 420;
            // 
            // TpGeneral
            // 
            this.TpGeneral.Controls.Add(this.CrvVentasCliente);
            this.TpGeneral.Location = new System.Drawing.Point(4, 22);
            this.TpGeneral.Name = "TpGeneral";
            this.TpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.TpGeneral.Size = new System.Drawing.Size(705, 528);
            this.TpGeneral.TabIndex = 0;
            this.TpGeneral.Text = "General";
            this.TpGeneral.UseVisualStyleBackColor = true;
            // 
            // TpPorComprobantes
            // 
            this.TpPorComprobantes.Controls.Add(this.CrvVentasClienteDetallado);
            this.TpPorComprobantes.Location = new System.Drawing.Point(4, 22);
            this.TpPorComprobantes.Name = "TpPorComprobantes";
            this.TpPorComprobantes.Padding = new System.Windows.Forms.Padding(3);
            this.TpPorComprobantes.Size = new System.Drawing.Size(705, 528);
            this.TpPorComprobantes.TabIndex = 1;
            this.TpPorComprobantes.Text = "Por Comprobantes";
            this.TpPorComprobantes.UseVisualStyleBackColor = true;
            // 
            // CrvVentasClienteDetallado
            // 
            this.CrvVentasClienteDetallado.ActiveViewIndex = -1;
            this.CrvVentasClienteDetallado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrvVentasClienteDetallado.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrvVentasClienteDetallado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrvVentasClienteDetallado.Location = new System.Drawing.Point(3, 3);
            this.CrvVentasClienteDetallado.Name = "CrvVentasClienteDetallado";
            this.CrvVentasClienteDetallado.Size = new System.Drawing.Size(699, 522);
            this.CrvVentasClienteDetallado.TabIndex = 418;
            // 
            // VentasPorCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TcVentasCliente);
            this.Controls.Add(this.c1cboCia);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DtpFechaFin);
            this.Controls.Add(this.DtpFechaIni);
            this.Controls.Add(this.BtnMostrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.useCliente1);
            this.Name = "VentasPorCliente";
            this.Size = new System.Drawing.Size(1242, 753);
            this.Load += new System.EventHandler(this.VentasPorCliente_Load);
            this.Controls.SetChildIndex(this.useCliente1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.BtnMostrar, 0);
            this.Controls.SetChildIndex(this.DtpFechaIni, 0);
            this.Controls.SetChildIndex(this.DtpFechaFin, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.c1cboCia, 0);
            this.Controls.SetChildIndex(this.TcVentasCliente, 0);
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).EndInit();
            this.TcVentasCliente.ResumeLayout(false);
            this.TpGeneral.ResumeLayout(false);
            this.TpPorComprobantes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ventas.UseCliente useCliente1;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1Button BtnMostrar;
        private System.Windows.Forms.DateTimePicker DtpFechaIni;
        private System.Windows.Forms.DateTimePicker DtpFechaFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrvVentasCliente;
        private C1.Win.C1List.C1Combo c1cboCia;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabControl TcVentasCliente;
        private System.Windows.Forms.TabPage TpGeneral;
        private System.Windows.Forms.TabPage TpPorComprobantes;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrvVentasClienteDetallado;
    }
}
