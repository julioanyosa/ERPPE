namespace Halley.Presentacion.Produccion
{
    partial class ModificarPlanProduccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarPlanProduccion));
            this.TdgMateriasPrimas = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.LblProducto = new System.Windows.Forms.Label();
            this.BtnGrabar = new C1.Win.C1Input.C1Button();
            this.BtnCerrar = new C1.Win.C1Input.C1Button();
            this.BtnAgregar = new C1.Win.C1Input.C1Button();
            this.BtnEliminar = new C1.Win.C1Input.C1Button();
            this.CboProductosMacroMicro = new C1.Win.C1List.C1Combo();
            ((System.ComponentModel.ISupportInitialize)(this.TdgMateriasPrimas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboProductosMacroMicro)).BeginInit();
            this.SuspendLayout();
            // 
            // TdgMateriasPrimas
            // 
            this.TdgMateriasPrimas.CaptionHeight = 17;
            this.TdgMateriasPrimas.EmptyRows = true;
            this.TdgMateriasPrimas.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgMateriasPrimas.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgMateriasPrimas.Images"))));
            this.TdgMateriasPrimas.Location = new System.Drawing.Point(12, 76);
            this.TdgMateriasPrimas.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgMateriasPrimas.Name = "TdgMateriasPrimas";
            this.TdgMateriasPrimas.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgMateriasPrimas.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgMateriasPrimas.PreviewInfo.ZoomFactor = 75D;
            this.TdgMateriasPrimas.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgMateriasPrimas.PrintInfo.PageSettings")));
            this.TdgMateriasPrimas.RowHeight = 18;
            this.TdgMateriasPrimas.Size = new System.Drawing.Size(504, 251);
            this.TdgMateriasPrimas.TabIndex = 0;
            this.TdgMateriasPrimas.Text = "c1TrueDBGrid1";
            this.TdgMateriasPrimas.BeforeColUpdate += new C1.Win.C1TrueDBGrid.BeforeColUpdateEventHandler(this.TdgMateriasPrimas_BeforeColUpdate);
            this.TdgMateriasPrimas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TdgMarcas_KeyPress);
            this.TdgMateriasPrimas.PropBag = resources.GetString("TdgMateriasPrimas.PropBag");
            // 
            // LblProducto
            // 
            this.LblProducto.AutoSize = true;
            this.LblProducto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProducto.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblProducto.Location = new System.Drawing.Point(12, 9);
            this.LblProducto.Name = "LblProducto";
            this.LblProducto.Size = new System.Drawing.Size(311, 21);
            this.LblProducto.TabIndex = 1;
            this.LblProducto.Text = "Mantenimiento del producto: xxxxxxxx";
            // 
            // BtnGrabar
            // 
            this.BtnGrabar.Image = global::Halley.Presentacion.Properties.Resources.save_16x16;
            this.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGrabar.Location = new System.Drawing.Point(536, 134);
            this.BtnGrabar.Name = "BtnGrabar";
            this.BtnGrabar.Size = new System.Drawing.Size(82, 23);
            this.BtnGrabar.TabIndex = 280;
            this.BtnGrabar.Text = "Grabar";
            this.BtnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGrabar.UseVisualStyleBackColor = true;
            this.BtnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCerrar.Image = global::Halley.Presentacion.Properties.Resources.cerrar_16x16;
            this.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCerrar.Location = new System.Drawing.Point(536, 76);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(82, 23);
            this.BtnCerrar.TabIndex = 282;
            this.BtnCerrar.Text = "Cerrar";
            this.BtnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Image = global::Halley.Presentacion.Properties.Resources.agregar_16x16;
            this.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgregar.Location = new System.Drawing.Point(535, 47);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(82, 23);
            this.BtnAgregar.TabIndex = 287;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Image = global::Halley.Presentacion.Properties.Resources.delete_16x16;
            this.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEliminar.Location = new System.Drawing.Point(536, 105);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(82, 23);
            this.BtnEliminar.TabIndex = 283;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // CboProductosMacroMicro
            // 
            this.CboProductosMacroMicro.AddItemSeparator = ';';
            this.CboProductosMacroMicro.AutoCompletion = true;
            this.CboProductosMacroMicro.AutoDropDown = true;
            this.CboProductosMacroMicro.Caption = "Seleccione Producto";
            this.CboProductosMacroMicro.CaptionHeight = 17;
            this.CboProductosMacroMicro.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboProductosMacroMicro.ColumnCaptionHeight = 17;
            this.CboProductosMacroMicro.ColumnFooterHeight = 17;
            this.CboProductosMacroMicro.ColumnHeaders = false;
            this.CboProductosMacroMicro.ContentHeight = 17;
            this.CboProductosMacroMicro.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboProductosMacroMicro.DisplayMember = "NomEmpresa";
            this.CboProductosMacroMicro.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboProductosMacroMicro.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboProductosMacroMicro.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboProductosMacroMicro.EditorHeight = 17;
            this.CboProductosMacroMicro.Images.Add(((System.Drawing.Image)(resources.GetObject("CboProductosMacroMicro.Images"))));
            this.CboProductosMacroMicro.ItemHeight = 15;
            this.CboProductosMacroMicro.Location = new System.Drawing.Point(12, 47);
            this.CboProductosMacroMicro.MatchEntryTimeout = ((long)(2000));
            this.CboProductosMacroMicro.MaxDropDownItems = ((short)(10));
            this.CboProductosMacroMicro.MaxLength = 32767;
            this.CboProductosMacroMicro.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboProductosMacroMicro.Name = "CboProductosMacroMicro";
            this.CboProductosMacroMicro.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboProductosMacroMicro.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboProductosMacroMicro.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboProductosMacroMicro.Size = new System.Drawing.Size(504, 23);
            this.CboProductosMacroMicro.TabIndex = 288;
            this.CboProductosMacroMicro.ValueMember = "EmpresaID";
            this.CboProductosMacroMicro.PropBag = resources.GetString("CboProductosMacroMicro.PropBag");
            // 
            // ModificarPlanProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.BtnCerrar;
            this.ClientSize = new System.Drawing.Size(644, 334);
            this.Controls.Add(this.CboProductosMacroMicro);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.BtnGrabar);
            this.Controls.Add(this.LblProducto);
            this.Controls.Add(this.TdgMateriasPrimas);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModificarPlanProduccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar las cantidades del plan de producción";
            this.Load += new System.EventHandler(this.ModificarPlanProduccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TdgMateriasPrimas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboProductosMacroMicro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgMateriasPrimas;
        private System.Windows.Forms.Label LblProducto;
        private C1.Win.C1Input.C1Button BtnGrabar;
        private C1.Win.C1Input.C1Button BtnCerrar;
        private C1.Win.C1Input.C1Button BtnAgregar;
        private C1.Win.C1Input.C1Button BtnEliminar;
        private C1.Win.C1List.C1Combo CboProductosMacroMicro;
    }
}