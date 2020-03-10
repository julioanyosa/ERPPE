namespace Halley.Presentacion.Ventas.VentasPavo
{
    partial class ListPeso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListPeso));
            this.label2 = new System.Windows.Forms.Label();
            this.CbAlmacen = new C1.Win.C1List.C1Combo();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new C1.Win.C1Input.C1Button();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lbl01 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPesoTotal = new System.Windows.Forms.Label();
            this.btnRegistrar = new C1.Win.C1Input.C1Button();
            this.btnAgregar = new C1.Win.C1Input.C1Button();
            this.txtPeso = new C1.Win.C1Input.C1TextBox();
            this.tdgbPeso = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.c1NumericEdit1 = new C1.Win.C1Input.C1NumericEdit();
            this.lblPesoMinimo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbGenerico = new C1.Win.C1List.C1Combo();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CbAlmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdgbPeso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1NumericEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGenerico)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Almacen :";
            // 
            // CbAlmacen
            // 
            this.CbAlmacen.AddItemSeparator = ';';
            this.CbAlmacen.Caption = "";
            this.CbAlmacen.CaptionHeight = 17;
            this.CbAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CbAlmacen.ColumnCaptionHeight = 17;
            this.CbAlmacen.ColumnFooterHeight = 17;
            this.CbAlmacen.ColumnHeaders = false;
            this.CbAlmacen.ColumnWidth = 100;
            this.CbAlmacen.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.CbAlmacen.ContentHeight = 17;
            this.CbAlmacen.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CbAlmacen.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CbAlmacen.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbAlmacen.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CbAlmacen.EditorHeight = 17;
            this.CbAlmacen.ExtendRightColumn = true;
            this.CbAlmacen.Images.Add(((System.Drawing.Image)(resources.GetObject("CbAlmacen.Images"))));
            this.CbAlmacen.ItemHeight = 15;
            this.CbAlmacen.Location = new System.Drawing.Point(85, 10);
            this.CbAlmacen.MatchEntryTimeout = ((long)(2000));
            this.CbAlmacen.MaxDropDownItems = ((short)(5));
            this.CbAlmacen.MaxLength = 32767;
            this.CbAlmacen.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CbAlmacen.Name = "CbAlmacen";
            this.CbAlmacen.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CbAlmacen.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CbAlmacen.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CbAlmacen.Size = new System.Drawing.Size(248, 23);
            this.CbAlmacen.TabIndex = 1;
            this.CbAlmacen.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.CbAlmacen.PropBag = resources.GetString("CbAlmacen.PropBag");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Peso(KG) :";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = global::Halley.Presentacion.Properties.Resources.Cancelar_16x16;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnCancelar.Location = new System.Drawing.Point(1127, 521);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(77, 23);
            this.btnCancelar.TabIndex = 123;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblCantidad
            // 
            this.lblCantidad.BackColor = System.Drawing.Color.White;
            this.lblCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCantidad.Location = new System.Drawing.Point(418, 523);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(104, 21);
            this.lblCantidad.TabIndex = 125;
            this.lblCantidad.Text = "0";
            this.lblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl01
            // 
            this.lbl01.AutoSize = true;
            this.lbl01.Location = new System.Drawing.Point(341, 527);
            this.lbl01.Name = "lbl01";
            this.lbl01.Size = new System.Drawing.Size(71, 13);
            this.lbl01.TabIndex = 124;
            this.lbl01.Text = "Nro Pesada :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(535, 525);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 126;
            this.label3.Text = "Peso Total (KG) :";
            // 
            // lblPesoTotal
            // 
            this.lblPesoTotal.BackColor = System.Drawing.Color.White;
            this.lblPesoTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPesoTotal.Location = new System.Drawing.Point(629, 521);
            this.lblPesoTotal.Name = "lblPesoTotal";
            this.lblPesoTotal.Size = new System.Drawing.Size(226, 21);
            this.lblPesoTotal.TabIndex = 127;
            this.lblPesoTotal.Text = "0";
            this.lblPesoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Enabled = false;
            this.btnRegistrar.Image = global::Halley.Presentacion.Properties.Resources.guardar_16x16;
            this.btnRegistrar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnRegistrar.Location = new System.Drawing.Point(1044, 521);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(77, 23);
            this.btnRegistrar.TabIndex = 128;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Image = global::Halley.Presentacion.Properties.Resources.Add_16x16;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnAgregar.Location = new System.Drawing.Point(339, 69);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(72, 23);
            this.btnAgregar.TabIndex = 129;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(85, 70);
            this.txtPeso.MaxLength = 6;
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(248, 22);
            this.txtPeso.TabIndex = 130;
            this.txtPeso.Tag = null;
            this.txtPeso.TextChanged += new System.EventHandler(this.txtPeso_TextChanged);
            this.txtPeso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeso_KeyPress);
            // 
            // tdgbPeso
            // 
            this.tdgbPeso.CaptionHeight = 17;
            this.tdgbPeso.CausesValidation = false;
            this.tdgbPeso.ColumnFooters = true;
            this.tdgbPeso.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveUp;
            this.tdgbPeso.EmptyRows = true;
            this.tdgbPeso.ExtendRightColumn = true;
            this.tdgbPeso.GroupByCaption = "Drag a column header here to group by that column";
            this.tdgbPeso.Images.Add(((System.Drawing.Image)(resources.GetObject("tdgbPeso.Images"))));
            this.tdgbPeso.Location = new System.Drawing.Point(25, 95);
            this.tdgbPeso.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightCell;
            this.tdgbPeso.Name = "tdgbPeso";
            this.tdgbPeso.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdgbPeso.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdgbPeso.PreviewInfo.ZoomFactor = 75D;
            this.tdgbPeso.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdgbPeso.PrintInfo.PageSettings")));
            this.tdgbPeso.RowHeight = 18;
            this.tdgbPeso.Size = new System.Drawing.Size(1179, 424);
            this.tdgbPeso.TabIndex = 131;
            this.tdgbPeso.Text = "Productos Genéricos";
            this.tdgbPeso.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2007Blue;
            this.tdgbPeso.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.tdgbPeso_AfterColUpdate);
            this.tdgbPeso.FetchCellStyle += new C1.Win.C1TrueDBGrid.FetchCellStyleEventHandler(this.tdgbPeso_FetchCellStyle);
            this.tdgbPeso.PropBag = resources.GetString("tdgbPeso.PropBag");
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(195, 523);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 21);
            this.label4.TabIndex = 133;
            this.label4.Text = "200";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 527);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 132;
            this.label5.Text = "Nro Pesada Max :";
            // 
            // c1NumericEdit1
            // 
            this.c1NumericEdit1.Location = new System.Drawing.Point(110, 144);
            this.c1NumericEdit1.MaxLength = 6;
            this.c1NumericEdit1.Name = "c1NumericEdit1";
            this.c1NumericEdit1.Size = new System.Drawing.Size(94, 22);
            this.c1NumericEdit1.TabIndex = 134;
            this.c1NumericEdit1.Tag = null;
            this.c1NumericEdit1.Visible = false;
            this.c1NumericEdit1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None;
            // 
            // lblPesoMinimo
            // 
            this.lblPesoMinimo.BackColor = System.Drawing.Color.White;
            this.lblPesoMinimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPesoMinimo.Location = new System.Drawing.Point(1071, 65);
            this.lblPesoMinimo.Name = "lblPesoMinimo";
            this.lblPesoMinimo.Size = new System.Drawing.Size(133, 21);
            this.lblPesoMinimo.TabIndex = 136;
            this.lblPesoMinimo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(967, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 135;
            this.label7.Text = "Peso minimo(KG) :";
            // 
            // cbGenerico
            // 
            this.cbGenerico.AddItemSeparator = ';';
            this.cbGenerico.Caption = "";
            this.cbGenerico.CaptionHeight = 17;
            this.cbGenerico.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbGenerico.ColumnCaptionHeight = 17;
            this.cbGenerico.ColumnFooterHeight = 17;
            this.cbGenerico.ColumnHeaders = false;
            this.cbGenerico.ColumnWidth = 100;
            this.cbGenerico.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cbGenerico.ContentHeight = 17;
            this.cbGenerico.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbGenerico.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbGenerico.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGenerico.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbGenerico.EditorHeight = 17;
            this.cbGenerico.ExtendRightColumn = true;
            this.cbGenerico.Images.Add(((System.Drawing.Image)(resources.GetObject("cbGenerico.Images"))));
            this.cbGenerico.ItemHeight = 15;
            this.cbGenerico.Location = new System.Drawing.Point(85, 39);
            this.cbGenerico.MatchEntryTimeout = ((long)(2000));
            this.cbGenerico.MaxDropDownItems = ((short)(5));
            this.cbGenerico.MaxLength = 32767;
            this.cbGenerico.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbGenerico.Name = "cbGenerico";
            this.cbGenerico.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cbGenerico.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cbGenerico.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbGenerico.Size = new System.Drawing.Size(248, 23);
            this.cbGenerico.TabIndex = 137;
            this.cbGenerico.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.cbGenerico.SelectedValueChanged += new System.EventHandler(this.cbGenerico_SelectedValueChanged);
            this.cbGenerico.PropBag = resources.GetString("cbGenerico.PropBag");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 138;
            this.label6.Text = "Producto :";
            // 
            // ListPeso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbGenerico);
            this.Controls.Add(this.lblPesoMinimo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.c1NumericEdit1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tdgbPeso);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.lblPesoTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lbl01);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CbAlmacen);
            this.Name = "ListPeso";
            this.Size = new System.Drawing.Size(1243, 590);
            this.Load += new System.EventHandler(this.ListPesoPavos_Load);
            this.Controls.SetChildIndex(this.CbAlmacen, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.lbl01, 0);
            this.Controls.SetChildIndex(this.lblCantidad, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblPesoTotal, 0);
            this.Controls.SetChildIndex(this.btnRegistrar, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.txtPeso, 0);
            this.Controls.SetChildIndex(this.tdgbPeso, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.c1NumericEdit1, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.lblPesoMinimo, 0);
            this.Controls.SetChildIndex(this.cbGenerico, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            ((System.ComponentModel.ISupportInitialize)(this.CbAlmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdgbPeso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1NumericEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGenerico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private C1.Win.C1List.C1Combo CbAlmacen;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1Button btnCancelar;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lbl01;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPesoTotal;
        private C1.Win.C1Input.C1Button btnRegistrar;
        private C1.Win.C1Input.C1Button btnAgregar;
        private C1.Win.C1Input.C1TextBox txtPeso;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdgbPeso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private C1.Win.C1Input.C1NumericEdit c1NumericEdit1;
        private System.Windows.Forms.Label lblPesoMinimo;
        private System.Windows.Forms.Label label7;
        private C1.Win.C1List.C1Combo cbGenerico;
        private System.Windows.Forms.Label label6;
    }
}
