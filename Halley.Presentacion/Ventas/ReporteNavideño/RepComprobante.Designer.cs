namespace Halley.Presentacion.Ventas.ReporteNavideño
{
    partial class RepComprobante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepComprobante));
            this.lblTot = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblVales = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tdbgClientes = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTot
            // 
            this.lblTot.BackColor = System.Drawing.Color.White;
            this.lblTot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTot.Location = new System.Drawing.Point(702, 497);
            this.lblTot.Name = "lblTot";
            this.lblTot.Size = new System.Drawing.Size(152, 21);
            this.lblTot.TabIndex = 135;
            this.lblTot.Text = "0";
            this.lblTot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(645, 502);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 134;
            this.label5.Text = "Boletas :";
            // 
            // lblVales
            // 
            this.lblVales.BackColor = System.Drawing.Color.White;
            this.lblVales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVales.Location = new System.Drawing.Point(702, 470);
            this.lblVales.Name = "lblVales";
            this.lblVales.Size = new System.Drawing.Size(152, 21);
            this.lblVales.TabIndex = 137;
            this.lblVales.Text = "0";
            this.lblVales.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(640, 474);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 136;
            this.label2.Text = "Facturas :";
            // 
            // tdbgClientes
            // 
            this.tdbgClientes.AllowUpdate = false;
            this.tdbgClientes.Caption = "REGISTRO DE CLIENTES";
            this.tdbgClientes.CaptionHeight = 17;
            this.tdbgClientes.CausesValidation = false;
            this.tdbgClientes.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveUp;
            this.tdbgClientes.EmptyRows = true;
            this.tdbgClientes.ExtendRightColumn = true;
            this.tdbgClientes.GroupByCaption = "Drag a column header here to group by that column";
            this.tdbgClientes.Images.Add(((System.Drawing.Image)(resources.GetObject("tdbgClientes.Images"))));
            this.tdbgClientes.Location = new System.Drawing.Point(16, 13);
            this.tdbgClientes.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.tdbgClientes.Name = "tdbgClientes";
            this.tdbgClientes.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdbgClientes.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdbgClientes.PreviewInfo.ZoomFactor = 75D;
            this.tdbgClientes.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdbgClientes.PrintInfo.PageSettings")));
            this.tdbgClientes.RowHeight = 18;
            this.tdbgClientes.Size = new System.Drawing.Size(1258, 454);
            this.tdbgClientes.TabIndex = 138;
            this.tdbgClientes.Text = "Productos Genéricos";
            this.tdbgClientes.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2007Blue;
            this.tdbgClientes.PropBag = resources.GetString("tdbgClientes.PropBag");
            // 
            // RepComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tdbgClientes);
            this.Controls.Add(this.lblVales);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTot);
            this.Controls.Add(this.label5);
            this.Name = "RepComprobante";
            this.Size = new System.Drawing.Size(1294, 586);
            this.RefreshClick += new Halley.Presentacion.UITemplateAccess.delegateRefreshClick(this.RepAsignacionVales_RefreshClick);
            this.ExportClick += new Halley.Presentacion.UITemplateAccess.delegateExportExcel(this.RepAsignacionVales_ExportClick);
            this.Load += new System.EventHandler(this.RepAsignacionVales_Load);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.lblTot, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblVales, 0);
            this.Controls.SetChildIndex(this.tdbgClientes, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tdbgClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTot;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblVales;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdbgClientes;
    }
}
