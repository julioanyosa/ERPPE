namespace Halley.Presentacion.Ventas.Pagos
{
    partial class FrmBuscarComprobante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBuscarComprobante));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.DtpFechaIni = new System.Windows.Forms.DateTimePicker();
            this.BtnMostrar = new C1.Win.C1Input.C1Button();
            this.TdgComprobantes = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.useCliente1 = new Halley.Presentacion.Ventas.UseCliente();
            this.CboTipoVenta = new C1.Win.C1List.C1Combo();
            this.label3 = new System.Windows.Forms.Label();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TdgComprobantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 362;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 361;
            this.label1.Text = "Entre:";
            // 
            // DtpFechaFin
            // 
            this.DtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaFin.Location = new System.Drawing.Point(162, 149);
            this.DtpFechaFin.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFechaFin.Name = "DtpFechaFin";
            this.DtpFechaFin.Size = new System.Drawing.Size(81, 22);
            this.DtpFechaFin.TabIndex = 360;
            // 
            // DtpFechaIni
            // 
            this.DtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaIni.Location = new System.Drawing.Point(57, 149);
            this.DtpFechaIni.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFechaIni.Name = "DtpFechaIni";
            this.DtpFechaIni.Size = new System.Drawing.Size(81, 22);
            this.DtpFechaIni.TabIndex = 359;
            // 
            // BtnMostrar
            // 
            this.BtnMostrar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.BtnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMostrar.Location = new System.Drawing.Point(249, 149);
            this.BtnMostrar.Name = "BtnMostrar";
            this.BtnMostrar.Size = new System.Drawing.Size(82, 23);
            this.BtnMostrar.TabIndex = 358;
            this.BtnMostrar.Text = "Consultar";
            this.BtnMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnMostrar.UseVisualStyleBackColor = true;
            this.BtnMostrar.Click += new System.EventHandler(this.BtnMostrar_Click);
            // 
            // TdgComprobantes
            // 
            this.TdgComprobantes.AllowUpdate = false;
            this.TdgComprobantes.Caption = "COMPROBANTES EN CONTRADOS CON ESTE CRITERIO";
            this.TdgComprobantes.CaptionHeight = 17;
            this.TdgComprobantes.CausesValidation = false;
            this.TdgComprobantes.ColumnFooters = true;
            this.TdgComprobantes.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveUp;
            this.TdgComprobantes.EmptyRows = true;
            this.TdgComprobantes.ExtendRightColumn = true;
            this.TdgComprobantes.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgComprobantes.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgComprobantes.Images"))));
            this.TdgComprobantes.Location = new System.Drawing.Point(12, 187);
            this.TdgComprobantes.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgComprobantes.Name = "TdgComprobantes";
            this.TdgComprobantes.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgComprobantes.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgComprobantes.PreviewInfo.ZoomFactor = 75D;
            this.TdgComprobantes.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgPreciosBuscados.PrintInfo.PageSettings")));
            this.TdgComprobantes.RowHeight = 18;
            this.TdgComprobantes.Size = new System.Drawing.Size(554, 166);
            this.TdgComprobantes.TabIndex = 421;
            this.TdgComprobantes.Text = "Productos Genéricos";
            this.TdgComprobantes.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2007Blue;
            this.TdgComprobantes.DoubleClick += new System.EventHandler(this.TdgPreciosBuscados_DoubleClick);
            this.TdgComprobantes.PropBag = resources.GetString("TdgComprobantes.PropBag");
            // 
            // useCliente1
            // 
            this.useCliente1.Location = new System.Drawing.Point(12, 12);
            this.useCliente1.Name = "useCliente1";
            this.useCliente1.Size = new System.Drawing.Size(554, 129);
            this.useCliente1.TabIndex = 0;
            // 
            // CboTipoVenta
            // 
            this.CboTipoVenta.AddItemSeparator = ';';
            this.CboTipoVenta.Caption = "";
            this.CboTipoVenta.CaptionHeight = 17;
            this.CboTipoVenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboTipoVenta.ColumnCaptionHeight = 17;
            this.CboTipoVenta.ColumnFooterHeight = 17;
            this.CboTipoVenta.ColumnHeaders = false;
            this.CboTipoVenta.ColumnWidth = 100;
            this.CboTipoVenta.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.CboTipoVenta.ContentHeight = 17;
            this.CboTipoVenta.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboTipoVenta.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboTipoVenta.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTipoVenta.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboTipoVenta.EditorHeight = 17;
            this.CboTipoVenta.ExtendRightColumn = true;
            this.CboTipoVenta.Images.Add(((System.Drawing.Image)(resources.GetObject("CboTipoVenta.Images"))));
            this.CboTipoVenta.ItemHeight = 15;
            this.CboTipoVenta.Location = new System.Drawing.Point(418, 147);
            this.CboTipoVenta.MatchEntryTimeout = ((long)(2000));
            this.CboTipoVenta.MaxDropDownItems = ((short)(5));
            this.CboTipoVenta.MaxLength = 32767;
            this.CboTipoVenta.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboTipoVenta.Name = "CboTipoVenta";
            this.CboTipoVenta.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboTipoVenta.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboTipoVenta.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboTipoVenta.Size = new System.Drawing.Size(148, 23);
            this.CboTipoVenta.TabIndex = 422;
            this.CboTipoVenta.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.CboTipoVenta.PropBag = resources.GetString("CboTipoVenta.PropBag");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 423;
            this.label3.Text = "Tipo venta:";
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // FrmBuscarComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 361);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CboTipoVenta);
            this.Controls.Add(this.TdgComprobantes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpFechaFin);
            this.Controls.Add(this.DtpFechaIni);
            this.Controls.Add(this.BtnMostrar);
            this.Controls.Add(this.useCliente1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmBuscarComprobante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar comprobantes emitidos de usuarios";
            this.Load += new System.EventHandler(this.FrmBuscarComprobante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TdgComprobantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UseCliente useCliente1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpFechaFin;
        private System.Windows.Forms.DateTimePicker DtpFechaIni;
        private C1.Win.C1Input.C1Button BtnMostrar;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgComprobantes;
        private C1.Win.C1List.C1Combo CboTipoVenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider ErrProvider;
    }
}