namespace Halley.Presentacion.Ventas
{
    partial class FrmVentasDiferidas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVentasDiferidas));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.C1TdbConsulta = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.txtDescripcion = new C1.Win.C1Input.C1TextBox();
            this.txtMarca = new C1.Win.C1Input.C1TextBox();
            this.txtCantidad = new C1.Win.C1Input.C1TextBox();
            this.btnVentaDiferida = new C1.Win.C1Input.C1Button();
            this.txtDocumento = new C1.Win.C1Input.C1TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCliente = new C1.Win.C1Input.C1TextBox();
            this.cbDocumento = new C1.Win.C1List.C1Combo();
            this.label5 = new System.Windows.Forms.Label();
            this.gbVenta = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbEntidad = new C1.Win.C1List.C1Combo();
            this.txtNroEntidad = new C1.Win.C1Input.C1TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.C1TdbConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDocumento)).BeginInit();
            this.gbVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbEntidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroEntidad)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Producto :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(416, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Marca :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(798, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "Cantidad :";
            // 
            // C1TdbConsulta
            // 
            this.C1TdbConsulta.AllowUpdate = false;
            this.C1TdbConsulta.CaptionHeight = 17;
            this.C1TdbConsulta.CausesValidation = false;
            this.C1TdbConsulta.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveUp;
            this.C1TdbConsulta.EmptyRows = true;
            this.C1TdbConsulta.ExtendRightColumn = true;
            this.C1TdbConsulta.GroupByCaption = "Drag a column header here to group by that column";
            this.C1TdbConsulta.Images.Add(((System.Drawing.Image)(resources.GetObject("C1TdbConsulta.Images"))));
            this.C1TdbConsulta.Location = new System.Drawing.Point(9, 47);
            this.C1TdbConsulta.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.C1TdbConsulta.Name = "C1TdbConsulta";
            this.C1TdbConsulta.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.C1TdbConsulta.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.C1TdbConsulta.PreviewInfo.ZoomFactor = 75D;
            this.C1TdbConsulta.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("C1TdbConsulta.PrintInfo.PageSettings")));
            this.C1TdbConsulta.RowHeight = 18;
            this.C1TdbConsulta.Size = new System.Drawing.Size(764, 299);
            this.C1TdbConsulta.TabIndex = 87;
            this.C1TdbConsulta.Text = "Productos Genéricos";
            this.C1TdbConsulta.Visible = false;
            this.C1TdbConsulta.DoubleClick += new System.EventHandler(this.C1TdbConsulta_DoubleClick);
            this.C1TdbConsulta.PropBag = resources.GetString("C1TdbConsulta.PropBag");
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(9, 25);
            this.txtDescripcion.MaxLength = 200;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(384, 22);
            this.txtDescripcion.TabIndex = 88;
            this.txtDescripcion.Tag = null;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(419, 25);
            this.txtMarca.MaxLength = 17;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(354, 22);
            this.txtMarca.TabIndex = 89;
            this.txtMarca.Tag = null;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(801, 25);
            this.txtCantidad.MaxLength = 17;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(91, 22);
            this.txtCantidad.TabIndex = 90;
            this.txtCantidad.Tag = null;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // btnVentaDiferida
            // 
            this.btnVentaDiferida.Image = global::Halley.Presentacion.Properties.Resources.guardar_16x16;
            this.btnVentaDiferida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentaDiferida.Location = new System.Drawing.Point(9, 158);
            this.btnVentaDiferida.Name = "btnVentaDiferida";
            this.btnVentaDiferida.Size = new System.Drawing.Size(72, 23);
            this.btnVentaDiferida.TabIndex = 92;
            this.btnVentaDiferida.Text = "Guardar";
            this.btnVentaDiferida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVentaDiferida.UseVisualStyleBackColor = true;
            this.btnVentaDiferida.Click += new System.EventHandler(this.btnVentaDiferida_Click);
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(136, 35);
            this.txtDocumento.MaxLength = 12;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(289, 22);
            this.txtDocumento.TabIndex = 95;
            this.txtDocumento.Tag = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 94;
            this.label4.Text = "Cliente :";
            // 
            // txtCliente
            // 
            this.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCliente.Location = new System.Drawing.Point(9, 83);
            this.txtCliente.MaxLength = 200;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(416, 22);
            this.txtCliente.TabIndex = 96;
            this.txtCliente.Tag = null;
            // 
            // cbDocumento
            // 
            this.cbDocumento.AddItemSeparator = ';';
            this.cbDocumento.Caption = "";
            this.cbDocumento.CaptionHeight = 17;
            this.cbDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbDocumento.ColumnCaptionHeight = 17;
            this.cbDocumento.ColumnFooterHeight = 17;
            this.cbDocumento.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cbDocumento.ContentHeight = 17;
            this.cbDocumento.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbDocumento.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbDocumento.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDocumento.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbDocumento.EditorHeight = 17;
            this.cbDocumento.Images.Add(((System.Drawing.Image)(resources.GetObject("cbDocumento.Images"))));
            this.cbDocumento.ItemHeight = 15;
            this.cbDocumento.Location = new System.Drawing.Point(9, 34);
            this.cbDocumento.MatchEntryTimeout = ((long)(2000));
            this.cbDocumento.MaxDropDownItems = ((short)(5));
            this.cbDocumento.MaxLength = 32767;
            this.cbDocumento.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbDocumento.Name = "cbDocumento";
            this.cbDocumento.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cbDocumento.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cbDocumento.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbDocumento.Size = new System.Drawing.Size(121, 23);
            this.cbDocumento.TabIndex = 97;
            this.cbDocumento.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.cbDocumento.PropBag = resources.GetString("cbDocumento.PropBag");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 98;
            this.label5.Text = "Documento :";
            // 
            // gbVenta
            // 
            this.gbVenta.Controls.Add(this.label6);
            this.gbVenta.Controls.Add(this.cbEntidad);
            this.gbVenta.Controls.Add(this.txtNroEntidad);
            this.gbVenta.Controls.Add(this.label5);
            this.gbVenta.Controls.Add(this.btnVentaDiferida);
            this.gbVenta.Controls.Add(this.txtCliente);
            this.gbVenta.Controls.Add(this.cbDocumento);
            this.gbVenta.Controls.Add(this.label4);
            this.gbVenta.Controls.Add(this.txtDocumento);
            this.gbVenta.Location = new System.Drawing.Point(801, 87);
            this.gbVenta.Name = "gbVenta";
            this.gbVenta.Size = new System.Drawing.Size(431, 193);
            this.gbVenta.TabIndex = 99;
            this.gbVenta.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 101;
            this.label6.Text = "Entidad :";
            // 
            // cbEntidad
            // 
            this.cbEntidad.AddItemSeparator = ';';
            this.cbEntidad.Caption = "";
            this.cbEntidad.CaptionHeight = 17;
            this.cbEntidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbEntidad.ColumnCaptionHeight = 17;
            this.cbEntidad.ColumnFooterHeight = 17;
            this.cbEntidad.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cbEntidad.ContentHeight = 17;
            this.cbEntidad.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbEntidad.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbEntidad.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEntidad.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbEntidad.EditorHeight = 17;
            this.cbEntidad.Images.Add(((System.Drawing.Image)(resources.GetObject("cbEntidad.Images"))));
            this.cbEntidad.ItemHeight = 15;
            this.cbEntidad.Location = new System.Drawing.Point(9, 129);
            this.cbEntidad.MatchEntryTimeout = ((long)(2000));
            this.cbEntidad.MaxDropDownItems = ((short)(5));
            this.cbEntidad.MaxLength = 32767;
            this.cbEntidad.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbEntidad.Name = "cbEntidad";
            this.cbEntidad.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cbEntidad.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cbEntidad.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbEntidad.Size = new System.Drawing.Size(121, 23);
            this.cbEntidad.TabIndex = 100;
            this.cbEntidad.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.cbEntidad.PropBag = resources.GetString("cbEntidad.PropBag");
            // 
            // txtNroEntidad
            // 
            this.txtNroEntidad.Location = new System.Drawing.Point(136, 130);
            this.txtNroEntidad.MaxLength = 20;
            this.txtNroEntidad.Name = "txtNroEntidad";
            this.txtNroEntidad.Size = new System.Drawing.Size(289, 22);
            this.txtNroEntidad.TabIndex = 99;
            this.txtNroEntidad.Tag = null;
            this.txtNroEntidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroEntidad_KeyPress);
            // 
            // FrmVentasDiferidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbVenta);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.C1TdbConsulta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmVentasDiferidas";
            this.Size = new System.Drawing.Size(1260, 490);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.C1TdbConsulta, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.txtMarca, 0);
            this.Controls.SetChildIndex(this.txtCantidad, 0);
            this.Controls.SetChildIndex(this.gbVenta, 0);
            ((System.ComponentModel.ISupportInitialize)(this.C1TdbConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDocumento)).EndInit();
            this.gbVenta.ResumeLayout(false);
            this.gbVenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbEntidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroEntidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid C1TdbConsulta;
        private C1.Win.C1Input.C1TextBox txtDescripcion;
        private C1.Win.C1Input.C1TextBox txtMarca;
        private C1.Win.C1Input.C1TextBox txtCantidad;
        private C1.Win.C1Input.C1Button btnVentaDiferida;
        private C1.Win.C1Input.C1TextBox txtDocumento;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1TextBox txtCliente;
        private C1.Win.C1List.C1Combo cbDocumento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbVenta;
        private System.Windows.Forms.Label label6;
        private C1.Win.C1List.C1Combo cbEntidad;
        private C1.Win.C1Input.C1TextBox txtNroEntidad;
    }
}
