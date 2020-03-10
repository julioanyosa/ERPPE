namespace Halley.Presentacion.Ventas.ReporteNavideño
{
    partial class RepVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepVentas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbPresentaciones = new C1.Win.C1List.C1Combo();
            this.lblPresentaciones = new System.Windows.Forms.Label();
            this.cbBusqueda = new C1.Win.C1List.C1Combo();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.crvVentas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbPresentaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBusqueda)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbPresentaciones);
            this.panel1.Controls.Add(this.lblPresentaciones);
            this.panel1.Controls.Add(this.cbBusqueda);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 40);
            this.panel1.TabIndex = 5;
            // 
            // cbPresentaciones
            // 
            this.cbPresentaciones.AddItemSeparator = ';';
            this.cbPresentaciones.Caption = "";
            this.cbPresentaciones.CaptionHeight = 17;
            this.cbPresentaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbPresentaciones.ColumnCaptionHeight = 17;
            this.cbPresentaciones.ColumnFooterHeight = 17;
            this.cbPresentaciones.ColumnHeaders = false;
            this.cbPresentaciones.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cbPresentaciones.ContentHeight = 17;
            this.cbPresentaciones.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbPresentaciones.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbPresentaciones.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPresentaciones.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbPresentaciones.EditorHeight = 17;
            this.cbPresentaciones.ExtendRightColumn = true;
            this.cbPresentaciones.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard;
            this.cbPresentaciones.Images.Add(((System.Drawing.Image)(resources.GetObject("cbPresentaciones.Images"))));
            this.cbPresentaciones.ItemHeight = 15;
            this.cbPresentaciones.Location = new System.Drawing.Point(336, 8);
            this.cbPresentaciones.MatchEntryTimeout = ((long)(2000));
            this.cbPresentaciones.MaxDropDownItems = ((short)(5));
            this.cbPresentaciones.MaxLength = 32767;
            this.cbPresentaciones.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbPresentaciones.Name = "cbPresentaciones";
            this.cbPresentaciones.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cbPresentaciones.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cbPresentaciones.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbPresentaciones.Size = new System.Drawing.Size(249, 23);
            this.cbPresentaciones.TabIndex = 69;
            this.cbPresentaciones.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.cbPresentaciones.SelectedValueChanged += new System.EventHandler(this.cbPresentaciones_SelectedValueChanged);
            this.cbPresentaciones.PropBag = resources.GetString("cbPresentaciones.PropBag");
            // 
            // lblPresentaciones
            // 
            this.lblPresentaciones.AutoSize = true;
            this.lblPresentaciones.Location = new System.Drawing.Point(241, 13);
            this.lblPresentaciones.Name = "lblPresentaciones";
            this.lblPresentaciones.Size = new System.Drawing.Size(90, 13);
            this.lblPresentaciones.TabIndex = 68;
            this.lblPresentaciones.Text = "Presentaciones :";
            // 
            // cbBusqueda
            // 
            this.cbBusqueda.AddItemSeparator = ';';
            this.cbBusqueda.Caption = "";
            this.cbBusqueda.CaptionHeight = 17;
            this.cbBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbBusqueda.ColumnCaptionHeight = 17;
            this.cbBusqueda.ColumnFooterHeight = 17;
            this.cbBusqueda.ColumnHeaders = false;
            this.cbBusqueda.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cbBusqueda.ContentHeight = 17;
            this.cbBusqueda.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbBusqueda.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbBusqueda.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBusqueda.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbBusqueda.EditorHeight = 17;
            this.cbBusqueda.ExtendRightColumn = true;
            this.cbBusqueda.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard;
            this.cbBusqueda.Images.Add(((System.Drawing.Image)(resources.GetObject("cbBusqueda.Images"))));
            this.cbBusqueda.ItemHeight = 15;
            this.cbBusqueda.Location = new System.Drawing.Point(83, 8);
            this.cbBusqueda.MatchEntryTimeout = ((long)(2000));
            this.cbBusqueda.MaxDropDownItems = ((short)(5));
            this.cbBusqueda.MaxLength = 32767;
            this.cbBusqueda.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbBusqueda.Name = "cbBusqueda";
            this.cbBusqueda.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cbBusqueda.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cbBusqueda.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbBusqueda.Size = new System.Drawing.Size(132, 23);
            this.cbBusqueda.TabIndex = 67;
            this.cbBusqueda.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.cbBusqueda.SelectedValueChanged += new System.EventHandler(this.cbBusqueda_SelectedValueChanged);
            this.cbBusqueda.PropBag = resources.GetString("cbBusqueda.PropBag");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "Busqueda :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.crvVentas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(686, 401);
            this.panel2.TabIndex = 6;
            // 
            // crvVentas
            // 
            this.crvVentas.ActiveViewIndex = -1;
            this.crvVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvVentas.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvVentas.Location = new System.Drawing.Point(0, 0);
            this.crvVentas.Name = "crvVentas";
            this.crvVentas.Size = new System.Drawing.Size(686, 401);
            this.crvVentas.TabIndex = 0;
            this.crvVentas.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crvVentas.Visible = false;
            // 
            // RepVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "RepVentas";
            this.Size = new System.Drawing.Size(686, 466);
            this.Load += new System.EventHandler(this.RepVentas_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbPresentaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBusqueda)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1List.C1Combo cbPresentaciones;
        private System.Windows.Forms.Label lblPresentaciones;
        private C1.Win.C1List.C1Combo cbBusqueda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvVentas;








    }
}
