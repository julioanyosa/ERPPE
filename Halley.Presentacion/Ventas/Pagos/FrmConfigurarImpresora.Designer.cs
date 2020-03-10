namespace Halley.Presentacion.Ventas.Pagos
{
    partial class FrmConfigurarImpresora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfigurarImpresora));
            this.c1cboCia = new C1.Win.C1List.C1Combo();
            this.LblBoletaGranja = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.CboTipoComprobante = new C1.Win.C1List.C1Combo();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnImpresora = new C1.Win.C1Input.C1Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.LblTicketGranja = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblTicketPago = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.BtnImpresoraPago = new C1.Win.C1Input.C1Button();
            this.BtnCerrar = new C1.Win.C1Input.C1Button();
            this.label3 = new System.Windows.Forms.Label();
            this.LblFacturaGranja = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoComprobante)).BeginInit();
            this.SuspendLayout();
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
            this.c1cboCia.ContentHeight = 21;
            this.c1cboCia.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.c1cboCia.DisplayMember = "NomEmpresa";
            this.c1cboCia.EditorBackColor = System.Drawing.SystemColors.Window;
            this.c1cboCia.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1cboCia.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.c1cboCia.EditorHeight = 21;
            this.c1cboCia.Images.Add(((System.Drawing.Image)(resources.GetObject("c1cboCia.Images"))));
            this.c1cboCia.ItemHeight = 15;
            this.c1cboCia.Location = new System.Drawing.Point(152, 31);
            this.c1cboCia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.c1cboCia.MatchEntryTimeout = ((long)(2000));
            this.c1cboCia.MaxDropDownItems = ((short)(10));
            this.c1cboCia.MaxLength = 32767;
            this.c1cboCia.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.c1cboCia.Name = "c1cboCia";
            this.c1cboCia.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.c1cboCia.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1cboCia.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1cboCia.Size = new System.Drawing.Size(213, 27);
            this.c1cboCia.TabIndex = 387;
            this.c1cboCia.ValueMember = "EmpresaID";
            this.c1cboCia.PropBag = resources.GetString("c1cboCia.PropBag");
            // 
            // LblBoletaGranja
            // 
            this.LblBoletaGranja.BackColor = System.Drawing.Color.White;
            this.LblBoletaGranja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblBoletaGranja.Location = new System.Drawing.Point(152, 107);
            this.LblBoletaGranja.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblBoletaGranja.Name = "LblBoletaGranja";
            this.LblBoletaGranja.Size = new System.Drawing.Size(581, 25);
            this.LblBoletaGranja.TabIndex = 390;
            this.LblBoletaGranja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 389;
            this.label2.Text = "Boleta granja :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(72, 43);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 17);
            this.label12.TabIndex = 401;
            this.label12.Text = "Empresa :";
            // 
            // CboTipoComprobante
            // 
            this.CboTipoComprobante.AddItemSeparator = ';';
            this.CboTipoComprobante.Caption = "";
            this.CboTipoComprobante.CaptionHeight = 17;
            this.CboTipoComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboTipoComprobante.ColumnCaptionHeight = 17;
            this.CboTipoComprobante.ColumnFooterHeight = 17;
            this.CboTipoComprobante.ColumnHeaders = false;
            this.CboTipoComprobante.ColumnWidth = 100;
            this.CboTipoComprobante.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.CboTipoComprobante.ContentHeight = 21;
            this.CboTipoComprobante.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboTipoComprobante.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboTipoComprobante.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTipoComprobante.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboTipoComprobante.EditorHeight = 21;
            this.CboTipoComprobante.ExtendRightColumn = true;
            this.CboTipoComprobante.Images.Add(((System.Drawing.Image)(resources.GetObject("CboTipoComprobante.Images"))));
            this.CboTipoComprobante.ItemHeight = 15;
            this.CboTipoComprobante.Location = new System.Drawing.Point(152, 66);
            this.CboTipoComprobante.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CboTipoComprobante.MatchEntryTimeout = ((long)(2000));
            this.CboTipoComprobante.MaxDropDownItems = ((short)(5));
            this.CboTipoComprobante.MaxLength = 32767;
            this.CboTipoComprobante.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboTipoComprobante.Name = "CboTipoComprobante";
            this.CboTipoComprobante.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboTipoComprobante.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboTipoComprobante.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboTipoComprobante.Size = new System.Drawing.Size(213, 27);
            this.CboTipoComprobante.TabIndex = 402;
            this.CboTipoComprobante.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.CboTipoComprobante.PropBag = resources.GetString("CboTipoComprobante.PropBag");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 403;
            this.label1.Text = "Comprobante :";
            // 
            // BtnImpresora
            // 
            this.BtnImpresora.Image = global::Halley.Presentacion.Properties.Resources.print_16x16;
            this.BtnImpresora.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImpresora.Location = new System.Drawing.Point(400, 66);
            this.BtnImpresora.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnImpresora.Name = "BtnImpresora";
            this.BtnImpresora.Size = new System.Drawing.Size(116, 28);
            this.BtnImpresora.TabIndex = 419;
            this.BtnImpresora.Text = "Seleccionar";
            this.BtnImpresora.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnImpresora.UseVisualStyleBackColor = true;
            this.BtnImpresora.Click += new System.EventHandler(this.BtnImpresora_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // LblTicketGranja
            // 
            this.LblTicketGranja.BackColor = System.Drawing.Color.White;
            this.LblTicketGranja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblTicketGranja.Location = new System.Drawing.Point(152, 187);
            this.LblTicketGranja.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTicketGranja.Name = "LblTicketGranja";
            this.LblTicketGranja.Size = new System.Drawing.Size(581, 25);
            this.LblTicketGranja.TabIndex = 421;
            this.LblTicketGranja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 187);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 17);
            this.label6.TabIndex = 420;
            this.label6.Text = "Ticketera granja :";
            // 
            // LblTicketPago
            // 
            this.LblTicketPago.BackColor = System.Drawing.Color.White;
            this.LblTicketPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblTicketPago.Location = new System.Drawing.Point(152, 228);
            this.LblTicketPago.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTicketPago.Name = "LblTicketPago";
            this.LblTicketPago.Size = new System.Drawing.Size(457, 25);
            this.LblTicketPago.TabIndex = 428;
            this.LblTicketPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(31, 233);
            this.lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(111, 17);
            this.lbl.TabIndex = 427;
            this.lbl.Text = "Ticketera pago :";
            // 
            // BtnImpresoraPago
            // 
            this.BtnImpresoraPago.Image = global::Halley.Presentacion.Properties.Resources.print_16x16;
            this.BtnImpresoraPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImpresoraPago.Location = new System.Drawing.Point(617, 228);
            this.BtnImpresoraPago.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnImpresoraPago.Name = "BtnImpresoraPago";
            this.BtnImpresoraPago.Size = new System.Drawing.Size(116, 28);
            this.BtnImpresoraPago.TabIndex = 429;
            this.BtnImpresoraPago.Text = "Seleccionar";
            this.BtnImpresoraPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnImpresoraPago.UseVisualStyleBackColor = true;
            this.BtnImpresoraPago.Click += new System.EventHandler(this.BtnImpresoraPago_Click);
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Image = global::Halley.Presentacion.Properties.Resources.cerrar_16x16;
            this.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCerrar.Location = new System.Drawing.Point(617, 66);
            this.BtnCerrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(116, 28);
            this.BtnCerrar.TabIndex = 430;
            this.BtnCerrar.Text = "&Cerrar";
            this.BtnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 150);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 17);
            this.label3.TabIndex = 391;
            this.label3.Text = "Factura granja :";
            // 
            // LblFacturaGranja
            // 
            this.LblFacturaGranja.BackColor = System.Drawing.Color.White;
            this.LblFacturaGranja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblFacturaGranja.Location = new System.Drawing.Point(152, 148);
            this.LblFacturaGranja.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblFacturaGranja.Name = "LblFacturaGranja";
            this.LblFacturaGranja.Size = new System.Drawing.Size(581, 25);
            this.LblFacturaGranja.TabIndex = 392;
            this.LblFacturaGranja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmConfigurarImpresora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 281);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.BtnImpresoraPago);
            this.Controls.Add(this.LblTicketPago);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.LblTicketGranja);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnImpresora);
            this.Controls.Add(this.CboTipoComprobante);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.LblFacturaGranja);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblBoletaGranja);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.c1cboCia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FrmConfigurarImpresora";
            this.Text = "Configurar impresora";
            this.Load += new System.EventHandler(this.FrmConfigurarImpresora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboTipoComprobante)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1List.C1Combo c1cboCia;
        private System.Windows.Forms.Label LblBoletaGranja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private C1.Win.C1List.C1Combo CboTipoComprobante;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1Button BtnImpresora;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Label LblTicketGranja;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblTicketPago;
        private System.Windows.Forms.Label lbl;
        private C1.Win.C1Input.C1Button BtnImpresoraPago;
        private C1.Win.C1Input.C1Button BtnCerrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblFacturaGranja;
    }
}