namespace Halley.Presentacion.Almacen.Operaciones
{
    partial class Requemientos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Requemientos));
            this.BtnAgregar = new C1.Win.C1Input.C1Button();
            this.TdgRequerimientos = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.BtnCancelar = new C1.Win.C1Input.C1Button();
            this.label15 = new System.Windows.Forms.Label();
            this.CboAlmacen = new C1.Win.C1List.C1Combo();
            this.c1NELith = new C1.Win.C1Input.C1NumericEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.c1SuperTooltip1 = new C1.Win.C1SuperTooltip.C1SuperTooltip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TdgRequerimientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboAlmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1NELith)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Image = global::Halley.Presentacion.Properties.Resources.Box32x32;
            this.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgregar.Location = new System.Drawing.Point(957, 19);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(104, 52);
            this.BtnAgregar.TabIndex = 18;
            this.BtnAgregar.Text = "Agregar al\r\nDespacho";
            this.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // TdgRequerimientos
            // 
            this.TdgRequerimientos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TdgRequerimientos.CaptionHeight = 17;
            this.TdgRequerimientos.EmptyRows = true;
            this.TdgRequerimientos.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgRequerimientos.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgRequerimientos.Images"))));
            this.TdgRequerimientos.LinesPerRow = 2;
            this.TdgRequerimientos.Location = new System.Drawing.Point(12, 77);
            this.TdgRequerimientos.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgRequerimientos.Name = "TdgRequerimientos";
            this.TdgRequerimientos.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgRequerimientos.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgRequerimientos.PreviewInfo.ZoomFactor = 75D;
            this.TdgRequerimientos.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgRequerimientos.PrintInfo.PageSettings")));
            this.TdgRequerimientos.RowHeight = 18;
            this.TdgRequerimientos.Size = new System.Drawing.Size(1052, 317);
            this.TdgRequerimientos.TabIndex = 17;
            this.TdgRequerimientos.TabStop = false;
            this.TdgRequerimientos.Text = "c1TrueDBGrid1";
            this.TdgRequerimientos.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.TdgRequerimientos_BeforeColUpdate);
            this.TdgRequerimientos.FetchCellStyle += new C1.Win.C1TrueDBGrid.FetchCellStyleEventHandler(this.TdgRequerimientos_FetchCellStyle);
            this.TdgRequerimientos.DoubleClick += new System.EventHandler(this.TdgRequerimientos_DoubleClick);
            this.TdgRequerimientos.PropBag = resources.GetString("TdgRequerimientos.PropBag");
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Image = global::Halley.Presentacion.Properties.Resources.Cerrar_32x32;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(852, 19);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(99, 52);
            this.BtnCancelar.TabIndex = 281;
            this.BtnCancelar.Text = "cerrar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(596, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 13);
            this.label15.TabIndex = 292;
            this.label15.Text = "Seleccione almacen:";
            // 
            // CboAlmacen
            // 
            this.CboAlmacen.AddItemSeparator = ';';
            this.CboAlmacen.AutoCompletion = true;
            this.CboAlmacen.AutoDropDown = true;
            this.CboAlmacen.Caption = "Seleccione Almacen";
            this.CboAlmacen.CaptionHeight = 17;
            this.CboAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboAlmacen.ColumnCaptionHeight = 17;
            this.CboAlmacen.ColumnFooterHeight = 17;
            this.CboAlmacen.ColumnHeaders = false;
            this.CboAlmacen.ContentHeight = 17;
            this.CboAlmacen.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboAlmacen.DisplayMember = "NomEmpresa";
            this.CboAlmacen.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboAlmacen.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboAlmacen.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboAlmacen.EditorHeight = 17;
            this.CboAlmacen.Images.Add(((System.Drawing.Image)(resources.GetObject("CboAlmacen.Images"))));
            this.CboAlmacen.ItemHeight = 15;
            this.CboAlmacen.Location = new System.Drawing.Point(598, 48);
            this.CboAlmacen.MatchEntryTimeout = ((long)(2000));
            this.CboAlmacen.MaxDropDownItems = ((short)(10));
            this.CboAlmacen.MaxLength = 32767;
            this.CboAlmacen.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboAlmacen.Name = "CboAlmacen";
            this.CboAlmacen.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboAlmacen.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboAlmacen.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboAlmacen.Size = new System.Drawing.Size(235, 23);
            this.CboAlmacen.TabIndex = 291;
            this.CboAlmacen.ValueMember = "EmpresaID";
            this.CboAlmacen.SelectedValueChanged += new System.EventHandler(this.CboAlmacen_SelectedValueChanged);
            this.CboAlmacen.PropBag = resources.GetString("CboAlmacen.PropBag");
            // 
            // c1NELith
            // 
            this.c1NELith.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.c1NELith.Calculator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
            this.c1NELith.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.System;
            this.c1NELith.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Black;
            this.c1NELith.DataType = typeof(int);
            this.c1NELith.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.FormatType | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
                        | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.c1NELith.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.FormatType | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
                        | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.c1NELith.Location = new System.Drawing.Point(435, 160);
            this.c1NELith.Name = "c1NELith";
            this.c1NELith.Size = new System.Drawing.Size(77, 18);
            this.c1NELith.TabIndex = 293;
            this.c1NELith.Tag = null;
            this.c1NELith.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c1NELith.Visible = false;
            this.c1NELith.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 32);
            this.label1.TabIndex = 295;
            this.label1.Text = "Requerimientos";
            // 
            // c1SuperTooltip1
            // 
            this.c1SuperTooltip1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1SuperTooltip1.Images.Add(new C1.Win.C1SuperTooltip.ImageEntry("Pollos_32x32.gif", ((System.Drawing.Image)(resources.GetObject("c1SuperTooltip1.Images")))));
            this.c1SuperTooltip1.Images.Add(new C1.Win.C1SuperTooltip.ImageEntry("pollito32x32.gif", ((System.Drawing.Image)(resources.GetObject("c1SuperTooltip1.Images1")))));
            this.c1SuperTooltip1.Images.Add(new C1.Win.C1SuperTooltip.ImageEntry("Recepcion32x32.gif", ((System.Drawing.Image)(resources.GetObject("c1SuperTooltip1.Images2")))));
            this.c1SuperTooltip1.IsBalloon = true;
            // 
            // Requemientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1076, 406);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c1NELith);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.CboAlmacen);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.TdgRequerimientos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Requemientos";
            this.Text = "Requemientos";
            this.Load += new System.EventHandler(this.Requemientos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TdgRequerimientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboAlmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1NELith)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgRequerimientos;
        private C1.Win.C1Input.C1Button BtnAgregar;
        private C1.Win.C1Input.C1Button BtnCancelar;
        private System.Windows.Forms.Label label15;
        private C1.Win.C1List.C1Combo CboAlmacen;
        private C1.Win.C1Input.C1NumericEdit c1NELith;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1SuperTooltip.C1SuperTooltip c1SuperTooltip1;
    }
}