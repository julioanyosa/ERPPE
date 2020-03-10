namespace Halley.Presentacion.Almacen.Reportes
{
    partial class Despachos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Despachos));
            this.CrvVentasSede = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnGenerar = new C1.Win.C1Input.C1Button();
            this.c1Button1 = new C1.Win.C1Input.C1Button();
            this.c1cboCia = new C1.Win.C1List.C1Combo();
            this.label6 = new System.Windows.Forms.Label();
            this.cbComprobante = new C1.Win.C1List.C1Combo();
            this.label27 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNumComprobante = new C1.Win.C1Input.C1TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNumComprobante)).BeginInit();
            this.SuspendLayout();
            // 
            // CrvVentasSede
            // 
            this.CrvVentasSede.ActiveViewIndex = -1;
            this.CrvVentasSede.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CrvVentasSede.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrvVentasSede.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrvVentasSede.Location = new System.Drawing.Point(13, 61);
            this.CrvVentasSede.Name = "CrvVentasSede";
            this.CrvVentasSede.Size = new System.Drawing.Size(888, 394);
            this.CrvVentasSede.TabIndex = 395;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(544, 29);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(82, 23);
            this.btnGenerar.TabIndex = 390;
            this.btnGenerar.Text = "Consultar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // c1Button1
            // 
            this.c1Button1.Image = global::Halley.Presentacion.Properties.Resources.find_16x16;
            this.c1Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.c1Button1.Location = new System.Drawing.Point(632, 29);
            this.c1Button1.Name = "c1Button1";
            this.c1Button1.Size = new System.Drawing.Size(82, 23);
            this.c1Button1.TabIndex = 413;
            this.c1Button1.Text = "Buscar";
            this.c1Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.c1Button1.UseVisualStyleBackColor = true;
            this.c1Button1.Click += new System.EventHandler(this.c1Button1_Click);
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
            this.c1cboCia.Location = new System.Drawing.Point(99, 3);
            this.c1cboCia.MatchEntryTimeout = ((long)(2000));
            this.c1cboCia.MaxDropDownItems = ((short)(10));
            this.c1cboCia.MaxLength = 32767;
            this.c1cboCia.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.c1cboCia.Name = "c1cboCia";
            this.c1cboCia.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.c1cboCia.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1cboCia.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1cboCia.Size = new System.Drawing.Size(208, 23);
            this.c1cboCia.TabIndex = 411;
            this.c1cboCia.ValueMember = "EmpresaID";
            this.c1cboCia.PropBag = resources.GetString("c1cboCia.PropBag");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 412;
            this.label6.Text = "Empresa:";
            // 
            // cbComprobante
            // 
            this.cbComprobante.AddItemSeparator = ';';
            this.cbComprobante.Caption = "";
            this.cbComprobante.CaptionHeight = 17;
            this.cbComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbComprobante.ColumnCaptionHeight = 17;
            this.cbComprobante.ColumnFooterHeight = 17;
            this.cbComprobante.ColumnHeaders = false;
            this.cbComprobante.ColumnWidth = 100;
            this.cbComprobante.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cbComprobante.ContentHeight = 17;
            this.cbComprobante.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbComprobante.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbComprobante.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbComprobante.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbComprobante.EditorHeight = 17;
            this.cbComprobante.ExtendRightColumn = true;
            this.cbComprobante.Images.Add(((System.Drawing.Image)(resources.GetObject("cbComprobante.Images"))));
            this.cbComprobante.ItemHeight = 15;
            this.cbComprobante.Location = new System.Drawing.Point(99, 32);
            this.cbComprobante.MatchEntryTimeout = ((long)(2000));
            this.cbComprobante.MaxDropDownItems = ((short)(5));
            this.cbComprobante.MaxLength = 32767;
            this.cbComprobante.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbComprobante.Name = "cbComprobante";
            this.cbComprobante.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cbComprobante.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cbComprobante.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbComprobante.Size = new System.Drawing.Size(208, 23);
            this.cbComprobante.TabIndex = 409;
            this.cbComprobante.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.cbComprobante.PropBag = resources.GetString("cbComprobante.PropBag");
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(11, 37);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(84, 13);
            this.label27.TabIndex = 410;
            this.label27.Text = "Comprobante :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 407;
            this.label2.Text = "Documento :";
            // 
            // TxtNumComprobante
            // 
            this.TxtNumComprobante.BackColor = System.Drawing.Color.White;
            this.TxtNumComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNumComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNumComprobante.Location = new System.Drawing.Point(395, 32);
            this.TxtNumComprobante.MaxLength = 150;
            this.TxtNumComprobante.Name = "TxtNumComprobante";
            this.TxtNumComprobante.Size = new System.Drawing.Size(135, 20);
            this.TxtNumComprobante.TabIndex = 406;
            this.TxtNumComprobante.Tag = null;
            this.TxtNumComprobante.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtNumComprobante.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // Despachos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.c1Button1);
            this.Controls.Add(this.c1cboCia);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbComprobante);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtNumComprobante);
            this.Controls.Add(this.CrvVentasSede);
            this.Controls.Add(this.btnGenerar);
            this.Name = "Despachos";
            this.Size = new System.Drawing.Size(914, 483);
            this.Load += new System.EventHandler(this.ProductosPorSede_Load);
            this.Controls.SetChildIndex(this.btnGenerar, 0);
            this.Controls.SetChildIndex(this.CrvVentasSede, 0);
            this.Controls.SetChildIndex(this.TxtNumComprobante, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label27, 0);
            this.Controls.SetChildIndex(this.cbComprobante, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.c1cboCia, 0);
            this.Controls.SetChildIndex(this.c1Button1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNumComprobante)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1Button btnGenerar;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrvVentasSede;
        private C1.Win.C1Input.C1Button c1Button1;
        private C1.Win.C1List.C1Combo c1cboCia;
        private System.Windows.Forms.Label label6;
        private C1.Win.C1List.C1Combo cbComprobante;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1TextBox TxtNumComprobante;
    }
}
