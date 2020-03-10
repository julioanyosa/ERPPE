namespace Halley.Presentacion.Mantenimiento.Contabilidad
{
    partial class AgruparProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgruparProductos));
            this.LstProductosPrincipales = new C1.Win.C1List.C1List();
            this.BtnAgregar = new C1.Win.C1Input.C1Button();
            this.LstDerivados = new C1.Win.C1List.C1List();
            this.tdgProductosBuscados = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.BtnRefrescar = new C1.Win.C1Input.C1Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtFiltro = new C1.Win.C1Input.C1TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.LstProductosPrincipales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LstDerivados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdgProductosBuscados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFiltro)).BeginInit();
            this.SuspendLayout();
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
            this.LstProductosPrincipales.Location = new System.Drawing.Point(3, 30);
            this.LstProductosPrincipales.MatchEntryTimeout = ((long)(2000));
            this.LstProductosPrincipales.Name = "LstProductosPrincipales";
            this.LstProductosPrincipales.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.LstProductosPrincipales.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.LstProductosPrincipales.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.LstProductosPrincipales.Size = new System.Drawing.Size(918, 162);
            this.LstProductosPrincipales.TabIndex = 383;
            this.LstProductosPrincipales.Text = "c1List1";
            this.LstProductosPrincipales.SelectedValueChanged += new System.EventHandler(this.LstProductosPrincipales_SelectedValueChanged);
            this.LstProductosPrincipales.PropBag = resources.GetString("LstProductosPrincipales.PropBag");
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Image = global::Halley.Presentacion.Properties.Resources.agregar_16x16;
            this.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgregar.Location = new System.Drawing.Point(933, 198);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(73, 23);
            this.BtnAgregar.TabIndex = 385;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
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
            this.LstDerivados.Location = new System.Drawing.Point(7, 321);
            this.LstDerivados.MatchEntryTimeout = ((long)(2000));
            this.LstDerivados.Name = "LstDerivados";
            this.LstDerivados.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.LstDerivados.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.LstDerivados.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.LstDerivados.Size = new System.Drawing.Size(918, 162);
            this.LstDerivados.TabIndex = 386;
            this.LstDerivados.Text = "c1List1";
            this.LstDerivados.PropBag = resources.GetString("LstDerivados.PropBag");
            // 
            // tdgProductosBuscados
            // 
            this.tdgProductosBuscados.AllowUpdate = false;
            this.tdgProductosBuscados.AlternatingRows = true;
            this.tdgProductosBuscados.CaptionHeight = 17;
            this.tdgProductosBuscados.EmptyRows = true;
            this.tdgProductosBuscados.FilterBar = true;
            this.tdgProductosBuscados.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tdgProductosBuscados.GroupByCaption = "Drag a column header here to group by that column";
            this.tdgProductosBuscados.Images.Add(((System.Drawing.Image)(resources.GetObject("tdgProductosBuscados.Images"))));
            this.tdgProductosBuscados.LinesPerRow = 2;
            this.tdgProductosBuscados.Location = new System.Drawing.Point(7, 198);
            this.tdgProductosBuscados.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.tdgProductosBuscados.Name = "tdgProductosBuscados";
            this.tdgProductosBuscados.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdgProductosBuscados.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdgProductosBuscados.PreviewInfo.ZoomFactor = 75D;
            this.tdgProductosBuscados.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdgProductosBuscados.PrintInfo.PageSettings")));
            this.tdgProductosBuscados.RowHeight = 15;
            this.tdgProductosBuscados.Size = new System.Drawing.Size(914, 117);
            this.tdgProductosBuscados.TabIndex = 418;
            this.tdgProductosBuscados.Text = "c1TrueDBGrid1";
            this.tdgProductosBuscados.PropBag = resources.GetString("tdgProductosBuscados.PropBag");
            // 
            // BtnRefrescar
            // 
            this.BtnRefrescar.Image = global::Halley.Presentacion.Properties.Resources.actualizar_16x16;
            this.BtnRefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRefrescar.Location = new System.Drawing.Point(933, 30);
            this.BtnRefrescar.Name = "BtnRefrescar";
            this.BtnRefrescar.Size = new System.Drawing.Size(73, 23);
            this.BtnRefrescar.TabIndex = 419;
            this.BtnRefrescar.Text = "Refrescar";
            this.BtnRefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRefrescar.UseVisualStyleBackColor = true;
            this.BtnRefrescar.Click += new System.EventHandler(this.BtnRefrescar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 421;
            this.label1.Text = "Filtrar por nombre:";
            // 
            // TxtFiltro
            // 
            this.TxtFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtFiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFiltro.Location = new System.Drawing.Point(128, 6);
            this.TxtFiltro.MaxLength = 150;
            this.TxtFiltro.Name = "TxtFiltro";
            this.TxtFiltro.Size = new System.Drawing.Size(287, 20);
            this.TxtFiltro.TabIndex = 420;
            this.TxtFiltro.Tag = null;
            this.TxtFiltro.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtFiltro.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.TxtFiltro.TextChanged += new System.EventHandler(this.TxtFiltro_TextChanged);
            // 
            // AgruparProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtFiltro);
            this.Controls.Add(this.BtnRefrescar);
            this.Controls.Add(this.tdgProductosBuscados);
            this.Controls.Add(this.LstDerivados);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.LstProductosPrincipales);
            this.Name = "AgruparProductos";
            this.Size = new System.Drawing.Size(1072, 484);
            this.Load += new System.EventHandler(this.AgruparProductos_Load);
            this.Controls.SetChildIndex(this.LstProductosPrincipales, 0);
            this.Controls.SetChildIndex(this.BtnAgregar, 0);
            this.Controls.SetChildIndex(this.LstDerivados, 0);
            this.Controls.SetChildIndex(this.tdgProductosBuscados, 0);
            this.Controls.SetChildIndex(this.BtnRefrescar, 0);
            this.Controls.SetChildIndex(this.TxtFiltro, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.LstProductosPrincipales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LstDerivados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdgProductosBuscados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFiltro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1List.C1List LstProductosPrincipales;
        private C1.Win.C1Input.C1Button BtnAgregar;
        private C1.Win.C1List.C1List LstDerivados;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdgProductosBuscados;
        private C1.Win.C1Input.C1Button BtnRefrescar;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox TxtFiltro;
    }
}
