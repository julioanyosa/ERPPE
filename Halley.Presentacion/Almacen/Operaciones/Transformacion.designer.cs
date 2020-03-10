namespace Halley.Presentacion.Almacen.Operaciones
{
    partial class Transformacion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transformacion));
            this.BtnAgregar = new C1.Win.C1Input.C1Button();
            this.TdgProductosAgregar = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.BtnTransformar = new C1.Win.C1Input.C1Button();
            this.TxtCantidad = new C1.Win.C1Input.C1TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.TxtFiltro = new C1.Win.C1Input.C1TextBox();
            this.LstProductosPrincipales = new C1.Win.C1List.C1List();
            this.LstDerivados = new C1.Win.C1List.C1List();
            ((System.ComponentModel.ISupportInitialize)(this.TdgProductosAgregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFiltro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LstProductosPrincipales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LstDerivados)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Image = global::Halley.Presentacion.Properties.Resources.agregar_16x16;
            this.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgregar.Location = new System.Drawing.Point(638, 326);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(82, 23);
            this.BtnAgregar.TabIndex = 385;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // TdgProductosAgregar
            // 
            this.TdgProductosAgregar.AllowDelete = true;
            this.TdgProductosAgregar.CaptionHeight = 17;
            this.TdgProductosAgregar.EmptyRows = true;
            this.TdgProductosAgregar.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgProductosAgregar.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgProductosAgregar.Images"))));
            this.TdgProductosAgregar.Location = new System.Drawing.Point(6, 299);
            this.TdgProductosAgregar.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgProductosAgregar.Name = "TdgProductosAgregar";
            this.TdgProductosAgregar.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgProductosAgregar.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgProductosAgregar.PreviewInfo.ZoomFactor = 75D;
            this.TdgProductosAgregar.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgProductosAgregar.PrintInfo.PageSettings")));
            this.TdgProductosAgregar.RowHeight = 18;
            this.TdgProductosAgregar.Size = new System.Drawing.Size(624, 226);
            this.TdgProductosAgregar.TabIndex = 386;
            this.TdgProductosAgregar.Text = "c1TrueDBGrid1";
            this.TdgProductosAgregar.PropBag = resources.GetString("TdgProductosAgregar.PropBag");
            // 
            // BtnTransformar
            // 
            this.BtnTransformar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.BtnTransformar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTransformar.Location = new System.Drawing.Point(638, 513);
            this.BtnTransformar.Name = "BtnTransformar";
            this.BtnTransformar.Size = new System.Drawing.Size(97, 23);
            this.BtnTransformar.TabIndex = 387;
            this.BtnTransformar.Text = "Transformar";
            this.BtnTransformar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnTransformar.UseVisualStyleBackColor = true;
            this.BtnTransformar.Click += new System.EventHandler(this.BtnTransformar_Click);
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCantidad.Location = new System.Drawing.Point(578, 3);
            this.TxtCantidad.MaxLength = 8;
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(74, 20);
            this.TxtCantidad.TabIndex = 388;
            this.TxtCantidad.Tag = null;
            this.TxtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtCantidad.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtCantidad.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.TxtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCantidad_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(442, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 389;
            this.label2.Text = "Cantidad a Transformar:";
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 424;
            this.label1.Text = "Filtrar por nombre:";
            // 
            // TxtFiltro
            // 
            this.TxtFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtFiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFiltro.Location = new System.Drawing.Point(131, 4);
            this.TxtFiltro.MaxLength = 150;
            this.TxtFiltro.Name = "TxtFiltro";
            this.TxtFiltro.Size = new System.Drawing.Size(287, 20);
            this.TxtFiltro.TabIndex = 423;
            this.TxtFiltro.Tag = null;
            this.TxtFiltro.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtFiltro.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // LstProductosPrincipales
            // 
            this.LstProductosPrincipales.AddItemSeparator = ';';
            this.LstProductosPrincipales.BackColor = System.Drawing.Color.White;
            this.LstProductosPrincipales.Caption = "";
            this.LstProductosPrincipales.CaptionHeight = 17;
            this.LstProductosPrincipales.ColumnCaptionHeight = 17;
            this.LstProductosPrincipales.ColumnFooterHeight = 17;
            this.LstProductosPrincipales.DeadAreaBackColor = System.Drawing.Color.White;
            this.LstProductosPrincipales.EmptyRows = true;
            this.LstProductosPrincipales.Images.Add(((System.Drawing.Image)(resources.GetObject("LstProductosPrincipales.Images"))));
            this.LstProductosPrincipales.ItemHeight = 15;
            this.LstProductosPrincipales.Location = new System.Drawing.Point(6, 28);
            this.LstProductosPrincipales.MatchEntryTimeout = ((long)(2000));
            this.LstProductosPrincipales.Name = "LstProductosPrincipales";
            this.LstProductosPrincipales.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.LstProductosPrincipales.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.LstProductosPrincipales.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.LstProductosPrincipales.Size = new System.Drawing.Size(918, 143);
            this.LstProductosPrincipales.TabIndex = 422;
            this.LstProductosPrincipales.Text = "c1List1";
            this.LstProductosPrincipales.SelectedValueChanged += new System.EventHandler(this.LstProductosPrincipales_SelectedValueChanged);
            this.LstProductosPrincipales.PropBag = resources.GetString("LstProductosPrincipales.PropBag");
            // 
            // LstDerivados
            // 
            this.LstDerivados.AddItemSeparator = ';';
            this.LstDerivados.BackColor = System.Drawing.Color.White;
            this.LstDerivados.Caption = "";
            this.LstDerivados.CaptionHeight = 17;
            this.LstDerivados.ColumnCaptionHeight = 17;
            this.LstDerivados.ColumnFooterHeight = 17;
            this.LstDerivados.DeadAreaBackColor = System.Drawing.Color.White;
            this.LstDerivados.EmptyRows = true;
            this.LstDerivados.Images.Add(((System.Drawing.Image)(resources.GetObject("LstDerivados.Images"))));
            this.LstDerivados.ItemHeight = 15;
            this.LstDerivados.Location = new System.Drawing.Point(6, 177);
            this.LstDerivados.MatchEntryTimeout = ((long)(2000));
            this.LstDerivados.Name = "LstDerivados";
            this.LstDerivados.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.LstDerivados.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.LstDerivados.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.LstDerivados.Size = new System.Drawing.Size(918, 112);
            this.LstDerivados.TabIndex = 425;
            this.LstDerivados.Text = "c1List1";
            this.LstDerivados.PropBag = resources.GetString("LstDerivados.PropBag");
            // 
            // Transformacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LstDerivados);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtFiltro);
            this.Controls.Add(this.LstProductosPrincipales);
            this.Controls.Add(this.TdgProductosAgregar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtCantidad);
            this.Controls.Add(this.BtnTransformar);
            this.Name = "Transformacion";
            this.Size = new System.Drawing.Size(978, 483);
            this.Load += new System.EventHandler(this.Transformacion_Load);
            this.Controls.SetChildIndex(this.BtnTransformar, 0);
            this.Controls.SetChildIndex(this.TxtCantidad, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.BtnAgregar, 0);
            this.Controls.SetChildIndex(this.TdgProductosAgregar, 0);
            this.Controls.SetChildIndex(this.LstProductosPrincipales, 0);
            this.Controls.SetChildIndex(this.TxtFiltro, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.LstDerivados, 0);
            ((System.ComponentModel.ISupportInitialize)(this.TdgProductosAgregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFiltro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LstProductosPrincipales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LstDerivados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1Button BtnAgregar;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgProductosAgregar;
        private C1.Win.C1Input.C1Button BtnTransformar;
        private C1.Win.C1Input.C1TextBox TxtCantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider ErrProvider;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox TxtFiltro;
        private C1.Win.C1List.C1List LstProductosPrincipales;
        private C1.Win.C1List.C1List LstDerivados;
    }
}
