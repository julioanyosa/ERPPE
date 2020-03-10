namespace Halley.Presentacion.Ventas.Pagos
{
    partial class FrmPagosMultiples
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPagosMultiples));
            this.TdgMultiplesPagos = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.BtnPagar = new C1.Win.C1Input.C1Button();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtPagar = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtMontoRestante = new C1.Win.C1Input.C1TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtObservacion = new C1.Win.C1Input.C1TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFormaPago = new C1.Win.C1List.C1Combo();
            this.ChkSeleccionarTodo = new System.Windows.Forms.CheckBox();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.TdgMultiplesPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPagar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMontoRestante)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtObservacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFormaPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TdgMultiplesPagos
            // 
            this.TdgMultiplesPagos.CaptionHeight = 17;
            this.TdgMultiplesPagos.EmptyRows = true;
            this.TdgMultiplesPagos.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgMultiplesPagos.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgMultiplesPagos.Images"))));
            this.TdgMultiplesPagos.Location = new System.Drawing.Point(12, 165);
            this.TdgMultiplesPagos.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgMultiplesPagos.Name = "TdgMultiplesPagos";
            this.TdgMultiplesPagos.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgMultiplesPagos.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgMultiplesPagos.PreviewInfo.ZoomFactor = 75D;
            this.TdgMultiplesPagos.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgMultiplesPagos.PrintInfo.PageSettings")));
            this.TdgMultiplesPagos.RowHeight = 18;
            this.TdgMultiplesPagos.Size = new System.Drawing.Size(728, 207);
            this.TdgMultiplesPagos.TabIndex = 395;
            this.TdgMultiplesPagos.Text = "c1TrueDBGrid1";
            this.TdgMultiplesPagos.PropBag = resources.GetString("TdgMultiplesPagos.PropBag");
            // 
            // BtnPagar
            // 
            this.BtnPagar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.BtnPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPagar.Location = new System.Drawing.Point(658, 138);
            this.BtnPagar.Name = "BtnPagar";
            this.BtnPagar.Size = new System.Drawing.Size(82, 23);
            this.BtnPagar.TabIndex = 396;
            this.BtnPagar.Text = "Pagar";
            this.BtnPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPagar.UseVisualStyleBackColor = true;
            this.BtnPagar.Click += new System.EventHandler(this.BtnPagar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 13);
            this.label8.TabIndex = 408;
            this.label8.Text = "Ingrese monto a pagar :";
            // 
            // TxtPagar
            // 
            this.TxtPagar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPagar.Location = new System.Drawing.Point(149, 58);
            this.TxtPagar.Name = "TxtPagar";
            this.TxtPagar.Size = new System.Drawing.Size(98, 22);
            this.TxtPagar.TabIndex = 407;
            this.TxtPagar.Tag = null;
            this.TxtPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 410;
            this.label1.Text = "Monto restante:";
            // 
            // TxtMontoRestante
            // 
            this.TxtMontoRestante.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMontoRestante.Location = new System.Drawing.Point(149, 85);
            this.TxtMontoRestante.Name = "TxtMontoRestante";
            this.TxtMontoRestante.Size = new System.Drawing.Size(98, 22);
            this.TxtMontoRestante.TabIndex = 409;
            this.TxtMontoRestante.Tag = null;
            this.TxtMontoRestante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.TxtObservacion);
            this.groupBox4.Controls.Add(this.TxtMontoRestante);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.cbFormaPago);
            this.groupBox4.Controls.Add(this.TxtPagar);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(728, 117);
            this.groupBox4.TabIndex = 411;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pago";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(364, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 404;
            this.label7.Text = "Observación:";
            // 
            // TxtObservacion
            // 
            this.TxtObservacion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtObservacion.Location = new System.Drawing.Point(367, 33);
            this.TxtObservacion.MaxLength = 200;
            this.TxtObservacion.Multiline = true;
            this.TxtObservacion.Name = "TxtObservacion";
            this.TxtObservacion.Size = new System.Drawing.Size(332, 63);
            this.TxtObservacion.TabIndex = 403;
            this.TxtObservacion.Tag = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 401;
            this.label6.Text = "Forma Pago :";
            // 
            // cbFormaPago
            // 
            this.cbFormaPago.AddItemSeparator = ';';
            this.cbFormaPago.Caption = "";
            this.cbFormaPago.CaptionHeight = 17;
            this.cbFormaPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbFormaPago.ColumnCaptionHeight = 17;
            this.cbFormaPago.ColumnFooterHeight = 17;
            this.cbFormaPago.ColumnHeaders = false;
            this.cbFormaPago.ColumnWidth = 100;
            this.cbFormaPago.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cbFormaPago.ContentHeight = 17;
            this.cbFormaPago.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbFormaPago.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbFormaPago.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFormaPago.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbFormaPago.EditorHeight = 17;
            this.cbFormaPago.ExtendRightColumn = true;
            this.cbFormaPago.Images.Add(((System.Drawing.Image)(resources.GetObject("cbFormaPago.Images"))));
            this.cbFormaPago.ItemHeight = 15;
            this.cbFormaPago.Location = new System.Drawing.Point(149, 29);
            this.cbFormaPago.MatchEntryTimeout = ((long)(2000));
            this.cbFormaPago.MaxDropDownItems = ((short)(5));
            this.cbFormaPago.MaxLength = 32767;
            this.cbFormaPago.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbFormaPago.Name = "cbFormaPago";
            this.cbFormaPago.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cbFormaPago.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cbFormaPago.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbFormaPago.Size = new System.Drawing.Size(197, 23);
            this.cbFormaPago.TabIndex = 402;
            this.cbFormaPago.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.cbFormaPago.PropBag = resources.GetString("cbFormaPago.PropBag");
            // 
            // ChkSeleccionarTodo
            // 
            this.ChkSeleccionarTodo.AutoSize = true;
            this.ChkSeleccionarTodo.Location = new System.Drawing.Point(535, 142);
            this.ChkSeleccionarTodo.Name = "ChkSeleccionarTodo";
            this.ChkSeleccionarTodo.Size = new System.Drawing.Size(106, 17);
            this.ChkSeleccionarTodo.TabIndex = 412;
            this.ChkSeleccionarTodo.Text = "Seleccionar todo";
            this.ChkSeleccionarTodo.UseVisualStyleBackColor = true;
            this.ChkSeleccionarTodo.CheckedChanged += new System.EventHandler(this.ChkSeleccionarTodo_CheckedChanged);
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // FrmPagosMultiples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 413);
            this.Controls.Add(this.ChkSeleccionarTodo);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.BtnPagar);
            this.Controls.Add(this.TdgMultiplesPagos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmPagosMultiples";
            this.Text = "Realizar multiples pagos de comprobantes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPagosMultiples_FormClosed);
            this.Load += new System.EventHandler(this.FrmPagosMultiples_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TdgMultiplesPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPagar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMontoRestante)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtObservacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFormaPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgMultiplesPagos;
        private C1.Win.C1Input.C1Button BtnPagar;
        private System.Windows.Forms.Label label8;
        private C1.Win.C1Input.C1TextBox TxtPagar;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox TxtMontoRestante;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private C1.Win.C1Input.C1TextBox TxtObservacion;
        private System.Windows.Forms.Label label6;
        private C1.Win.C1List.C1Combo cbFormaPago;
        private System.Windows.Forms.ErrorProvider ErrProvider;
        private System.Windows.Forms.CheckBox ChkSeleccionarTodo;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}