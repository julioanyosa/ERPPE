namespace Halley.Presentacion.Compras
{
    partial class FrmCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompra));
            this.label1 = new System.Windows.Forms.Label();
            this.CbProveedor = new C1.Win.C1List.C1Combo();
            this.BtnCompras = new C1.Win.C1Input.C1Button();
            this.PdfOrdenCompra = new C1.C1Pdf.C1PdfDocument();
            this.CboSedes = new C1.Win.C1List.C1Combo();
            this.label2 = new System.Windows.Forms.Label();
            this.C1tdbCompra = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtDiasCredito = new C1.Win.C1Input.C1TextBox();
            this.TxtCondicion = new C1.Win.C1Input.C1TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtOtros = new C1.Win.C1Input.C1TextBox();
            this.txtRecargo = new C1.Win.C1Input.C1TextBox();
            this.Txtdescuento = new C1.Win.C1Input.C1TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtObservacion = new C1.Win.C1Input.C1TextBox();
            this.C1TdbgRequerimiento = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnActualizar = new C1.Win.C1Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)(this.CbProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboSedes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.C1tdbCompra)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDiasCredito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCondicion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOtros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRecargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtdescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtObservacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.C1TdbgRequerimiento)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(973, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 75;
            this.label1.Text = "Proveedor :";
            // 
            // CbProveedor
            // 
            this.CbProveedor.AddItemSeparator = ';';
            this.CbProveedor.Caption = "";
            this.CbProveedor.CaptionHeight = 17;
            this.CbProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CbProveedor.ColumnCaptionHeight = 17;
            this.CbProveedor.ColumnFooterHeight = 17;
            this.CbProveedor.ColumnHeaders = false;
            this.CbProveedor.ColumnWidth = 100;
            this.CbProveedor.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.CbProveedor.ContentHeight = 17;
            this.CbProveedor.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CbProveedor.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CbProveedor.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbProveedor.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CbProveedor.EditorHeight = 17;
            this.CbProveedor.ExtendRightColumn = true;
            this.CbProveedor.Images.Add(((System.Drawing.Image)(resources.GetObject("CbProveedor.Images"))));
            this.CbProveedor.ItemHeight = 15;
            this.CbProveedor.Location = new System.Drawing.Point(1045, 15);
            this.CbProveedor.MatchEntryTimeout = ((long)(2000));
            this.CbProveedor.MaxDropDownItems = ((short)(5));
            this.CbProveedor.MaxLength = 32767;
            this.CbProveedor.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CbProveedor.Name = "CbProveedor";
            this.CbProveedor.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CbProveedor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CbProveedor.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CbProveedor.Size = new System.Drawing.Size(230, 23);
            this.CbProveedor.TabIndex = 1;
            this.CbProveedor.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.CbProveedor.PropBag = resources.GetString("CbProveedor.PropBag");
            // 
            // BtnCompras
            // 
            this.BtnCompras.Image = global::Halley.Presentacion.Properties.Resources.buy_16x16;
            this.BtnCompras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCompras.Location = new System.Drawing.Point(1214, 263);
            this.BtnCompras.Name = "BtnCompras";
            this.BtnCompras.Size = new System.Drawing.Size(61, 22);
            this.BtnCompras.TabIndex = 9;
            this.BtnCompras.Text = "Enviar ";
            this.BtnCompras.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.BtnCompras.UseVisualStyleBackColor = true;
            this.BtnCompras.Click += new System.EventHandler(this.BtnCompras_Click_1);
            // 
            // PdfOrdenCompra
            // 
            this.PdfOrdenCompra.ImageQuality = C1.C1Pdf.ImageQualityEnum.High;
            // 
            // CboSedes
            // 
            this.CboSedes.AddItemSeparator = ';';
            this.CboSedes.Caption = "";
            this.CboSedes.CaptionHeight = 17;
            this.CboSedes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboSedes.ColumnCaptionHeight = 17;
            this.CboSedes.ColumnFooterHeight = 17;
            this.CboSedes.ColumnHeaders = false;
            this.CboSedes.ColumnWidth = 100;
            this.CboSedes.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.CboSedes.ContentHeight = 17;
            this.CboSedes.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboSedes.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboSedes.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboSedes.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboSedes.EditorHeight = 17;
            this.CboSedes.ExtendRightColumn = true;
            this.CboSedes.Images.Add(((System.Drawing.Image)(resources.GetObject("CboSedes.Images"))));
            this.CboSedes.ItemHeight = 15;
            this.CboSedes.Location = new System.Drawing.Point(1045, 44);
            this.CboSedes.MatchEntryTimeout = ((long)(2000));
            this.CboSedes.MaxDropDownItems = ((short)(5));
            this.CboSedes.MaxLength = 32767;
            this.CboSedes.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboSedes.Name = "CboSedes";
            this.CboSedes.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboSedes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboSedes.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboSedes.Size = new System.Drawing.Size(230, 23);
            this.CboSedes.TabIndex = 2;
            this.CboSedes.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.CboSedes.PropBag = resources.GetString("CboSedes.PropBag");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(978, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 26);
            this.label2.TabIndex = 78;
            this.label2.Text = "Lugar de\r\nrecepción:";
            // 
            // C1tdbCompra
            // 
            this.C1tdbCompra.AlternatingRows = true;
            this.C1tdbCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.C1tdbCompra.CaptionHeight = 17;
            this.C1tdbCompra.EmptyRows = true;
            this.C1tdbCompra.FilterBar = true;
            this.C1tdbCompra.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C1tdbCompra.GroupByCaption = "Drag a column header here to group by that column";
            this.C1tdbCompra.Images.Add(((System.Drawing.Image)(resources.GetObject("C1tdbCompra.Images"))));
            this.C1tdbCompra.LinesPerRow = 2;
            this.C1tdbCompra.Location = new System.Drawing.Point(6, 19);
            this.C1tdbCompra.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightCell;
            this.C1tdbCompra.Name = "C1tdbCompra";
            this.C1tdbCompra.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.C1tdbCompra.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.C1tdbCompra.PreviewInfo.ZoomFactor = 75D;
            this.C1tdbCompra.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("C1tdbCompra.PrintInfo.PageSettings")));
            this.C1tdbCompra.RowHeight = 15;
            this.C1tdbCompra.Size = new System.Drawing.Size(941, 274);
            this.C1tdbCompra.TabIndex = 0;
            this.C1tdbCompra.Text = "c1TrueDBGrid1";
            this.C1tdbCompra.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.C1tdbCompra_AfterColUpdate);
            this.C1tdbCompra.AfterDelete += new System.EventHandler(this.C1tdbCompra_AfterDelete);
            this.C1tdbCompra.PropBag = resources.GetString("C1tdbCompra.PropBag");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.C1tdbCompra);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.TxtDiasCredito);
            this.groupBox1.Controls.Add(this.TxtCondicion);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TxtOtros);
            this.groupBox1.Controls.Add(this.txtRecargo);
            this.groupBox1.Controls.Add(this.Txtdescuento);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtObservacion);
            this.groupBox1.Controls.Add(this.CboSedes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CbProveedor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BtnCompras);
            this.groupBox1.Location = new System.Drawing.Point(5, 215);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1287, 299);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de orden de compra";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1093, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 92;
            this.label9.Text = "día(s)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(967, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 91;
            this.label7.Text = "Días crédito:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(975, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 90;
            this.label8.Text = "Condición:";
            // 
            // TxtDiasCredito
            // 
            this.TxtDiasCredito.Location = new System.Drawing.Point(1045, 182);
            this.TxtDiasCredito.Name = "TxtDiasCredito";
            this.TxtDiasCredito.Size = new System.Drawing.Size(42, 22);
            this.TxtDiasCredito.TabIndex = 5;
            this.TxtDiasCredito.Tag = null;
            this.TxtDiasCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtDiasCredito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDiasCredito_KeyPress);
            // 
            // TxtCondicion
            // 
            this.TxtCondicion.Location = new System.Drawing.Point(1045, 155);
            this.TxtCondicion.Name = "TxtCondicion";
            this.TxtCondicion.Size = new System.Drawing.Size(132, 22);
            this.TxtCondicion.TabIndex = 4;
            this.TxtCondicion.Tag = null;
            this.TxtCondicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(986, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 86;
            this.label5.Text = "Recargo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(973, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 85;
            this.label4.Text = "Descuento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(999, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 87;
            this.label6.Text = "Otros:";
            // 
            // TxtOtros
            // 
            this.TxtOtros.Location = new System.Drawing.Point(1045, 265);
            this.TxtOtros.Name = "TxtOtros";
            this.TxtOtros.Size = new System.Drawing.Size(92, 22);
            this.TxtOtros.TabIndex = 8;
            this.TxtOtros.Tag = null;
            this.TxtOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtOtros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtOtros_KeyPress);
            // 
            // txtRecargo
            // 
            this.txtRecargo.Location = new System.Drawing.Point(1045, 237);
            this.txtRecargo.Name = "txtRecargo";
            this.txtRecargo.Size = new System.Drawing.Size(92, 22);
            this.txtRecargo.TabIndex = 7;
            this.txtRecargo.Tag = null;
            this.txtRecargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRecargo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRecargo_KeyPress);
            // 
            // Txtdescuento
            // 
            this.Txtdescuento.Location = new System.Drawing.Point(1045, 210);
            this.Txtdescuento.Name = "Txtdescuento";
            this.Txtdescuento.Size = new System.Drawing.Size(92, 22);
            this.Txtdescuento.TabIndex = 6;
            this.Txtdescuento.Tag = null;
            this.Txtdescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Txtdescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txtdescuento_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(961, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "Observación :";
            // 
            // TxtObservacion
            // 
            this.TxtObservacion.Location = new System.Drawing.Point(1045, 78);
            this.TxtObservacion.Multiline = true;
            this.TxtObservacion.Name = "TxtObservacion";
            this.TxtObservacion.Size = new System.Drawing.Size(230, 71);
            this.TxtObservacion.TabIndex = 3;
            this.TxtObservacion.Tag = null;
            // 
            // C1TdbgRequerimiento
            // 
            this.C1TdbgRequerimiento.AllowUpdate = false;
            this.C1TdbgRequerimiento.AlternatingRows = true;
            this.C1TdbgRequerimiento.CaptionHeight = 17;
            this.C1TdbgRequerimiento.EmptyRows = true;
            this.C1TdbgRequerimiento.FilterBar = true;
            this.C1TdbgRequerimiento.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C1TdbgRequerimiento.GroupByCaption = "Drag a column header here to group by that column";
            this.C1TdbgRequerimiento.Images.Add(((System.Drawing.Image)(resources.GetObject("C1TdbgRequerimiento.Images"))));
            this.C1TdbgRequerimiento.LinesPerRow = 2;
            this.C1TdbgRequerimiento.Location = new System.Drawing.Point(6, 38);
            this.C1TdbgRequerimiento.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightCell;
            this.C1TdbgRequerimiento.Name = "C1TdbgRequerimiento";
            this.C1TdbgRequerimiento.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.C1TdbgRequerimiento.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.C1TdbgRequerimiento.PreviewInfo.ZoomFactor = 75D;
            this.C1TdbgRequerimiento.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("C1TdbgRequerimiento.PrintInfo.PageSettings")));
            this.C1TdbgRequerimiento.RowHeight = 15;
            this.C1TdbgRequerimiento.Size = new System.Drawing.Size(1269, 167);
            this.C1TdbgRequerimiento.TabIndex = 75;
            this.C1TdbgRequerimiento.Text = "c1TrueDBGrid1";
            this.C1TdbgRequerimiento.DoubleClick += new System.EventHandler(this.C1TdbgRequerimiento_DoubleClick);
            this.C1TdbgRequerimiento.PropBag = resources.GetString("C1TdbgRequerimiento.PropBag");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnActualizar);
            this.groupBox2.Controls.Add(this.C1TdbgRequerimiento);
            this.groupBox2.Location = new System.Drawing.Point(5, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1287, 211);
            this.groupBox2.TabIndex = 76;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "REquerimientos de compra";
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Image = global::Halley.Presentacion.Properties.Resources.actualizar_16x16;
            this.BtnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnActualizar.Location = new System.Drawing.Point(1191, 10);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(84, 22);
            this.BtnActualizar.TabIndex = 76;
            this.BtnActualizar.Text = "Actualizar";
            this.BtnActualizar.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // FrmCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCompra";
            this.Size = new System.Drawing.Size(1338, 577);
            this.Load += new System.EventHandler(this.Compra_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.CbProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboSedes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.C1tdbCompra)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDiasCredito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCondicion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOtros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRecargo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtdescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtObservacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.C1TdbgRequerimiento)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1Button BtnCompras;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1List.C1Combo CbProveedor;
        private C1.C1Pdf.C1PdfDocument PdfOrdenCompra;
        private C1.Win.C1List.C1Combo CboSedes;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid C1tdbCompra;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1TextBox TxtObservacion;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1TextBox TxtOtros;
        private C1.Win.C1Input.C1TextBox txtRecargo;
        private C1.Win.C1Input.C1TextBox Txtdescuento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private C1.Win.C1Input.C1TextBox TxtDiasCredito;
        private C1.Win.C1Input.C1TextBox TxtCondicion;
        private System.Windows.Forms.Label label9;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid C1TdbgRequerimiento;
        private System.Windows.Forms.GroupBox groupBox2;
        private C1.Win.C1Input.C1Button BtnActualizar;


    }
}
