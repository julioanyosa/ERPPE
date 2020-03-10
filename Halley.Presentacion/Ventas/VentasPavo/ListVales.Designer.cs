namespace Halley.Presentacion.Ventas.VentasPavo
{
    partial class ListVales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListVales));
            this.tdbgPresentaciones = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.lblTotales = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGenerar = new C1.Win.C1Input.C1Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lbl01 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lbl02 = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgPresentaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // tdbgPresentaciones
            // 
            this.tdbgPresentaciones.AllowUpdate = false;
            this.tdbgPresentaciones.Caption = "PRESENTACIONES";
            this.tdbgPresentaciones.CaptionHeight = 17;
            this.tdbgPresentaciones.CausesValidation = false;
            this.tdbgPresentaciones.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveUp;
            this.tdbgPresentaciones.EmptyRows = true;
            this.tdbgPresentaciones.ExtendRightColumn = true;
            this.tdbgPresentaciones.GroupByCaption = "Drag a column header here to group by that column";
            this.tdbgPresentaciones.Images.Add(((System.Drawing.Image)(resources.GetObject("tdbgPresentaciones.Images"))));
            this.tdbgPresentaciones.Location = new System.Drawing.Point(17, 52);
            this.tdbgPresentaciones.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.tdbgPresentaciones.Name = "tdbgPresentaciones";
            this.tdbgPresentaciones.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdbgPresentaciones.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdbgPresentaciones.PreviewInfo.ZoomFactor = 75D;
            this.tdbgPresentaciones.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdbgPresentaciones.PrintInfo.PageSettings")));
            this.tdbgPresentaciones.RowHeight = 18;
            this.tdbgPresentaciones.Size = new System.Drawing.Size(1042, 425);
            this.tdbgPresentaciones.TabIndex = 4;
            this.tdbgPresentaciones.Text = "Productos Genéricos";
            this.tdbgPresentaciones.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2007Blue;
            this.tdbgPresentaciones.PropBag = resources.GetString("tdbgPresentaciones.PropBag");
            // 
            // lblTotales
            // 
            this.lblTotales.BackColor = System.Drawing.Color.White;
            this.lblTotales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotales.Location = new System.Drawing.Point(582, 483);
            this.lblTotales.Name = "lblTotales";
            this.lblTotales.Size = new System.Drawing.Size(152, 21);
            this.lblTotales.TabIndex = 108;
            this.lblTotales.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(486, 487);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 107;
            this.label5.Text = "Total Nro Vales :";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Enabled = false;
            this.btnGenerar.Image = global::Halley.Presentacion.Properties.Resources.guardar_16x16;
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnGenerar.Location = new System.Drawing.Point(982, 483);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(77, 23);
            this.btnGenerar.TabIndex = 109;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = System.Drawing.Color.White;
            this.lblUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUsuario.Location = new System.Drawing.Point(456, 23);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(315, 21);
            this.lblUsuario.TabIndex = 111;
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUsuario.Visible = false;
            // 
            // lbl01
            // 
            this.lbl01.AutoSize = true;
            this.lbl01.Location = new System.Drawing.Point(398, 27);
            this.lbl01.Name = "lbl01";
            this.lbl01.Size = new System.Drawing.Size(53, 13);
            this.lbl01.TabIndex = 110;
            this.lbl01.Text = "Usuario :";
            this.lbl01.Visible = false;
            // 
            // lblFecha
            // 
            this.lblFecha.BackColor = System.Drawing.Color.White;
            this.lblFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFecha.Location = new System.Drawing.Point(838, 22);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(221, 21);
            this.lblFecha.TabIndex = 113;
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFecha.Visible = false;
            // 
            // lbl02
            // 
            this.lbl02.AutoSize = true;
            this.lbl02.Location = new System.Drawing.Point(789, 27);
            this.lbl02.Name = "lbl02";
            this.lbl02.Size = new System.Drawing.Size(43, 13);
            this.lbl02.TabIndex = 112;
            this.lbl02.Text = "Fecha :";
            this.lbl02.Visible = false;
            // 
            // lblMensaje
            // 
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(17, 26);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(373, 18);
            this.lblMensaje.TabIndex = 114;
            this.lblMensaje.Text = "Los vales ya fueron generados por :";
            this.lblMensaje.Visible = false;
            // 
            // ListVales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lbl02);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lbl01);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.lblTotales);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tdbgPresentaciones);
            this.Name = "ListVales";
            this.Size = new System.Drawing.Size(1157, 722);
            this.RefreshClick += new Halley.Presentacion.UITemplateAccess.delegateRefreshClick(this.ListVales_RefreshClick);
            this.ExportClick += new Halley.Presentacion.UITemplateAccess.delegateExportExcel(this.ListVales_ExportClick);
            this.Load += new System.EventHandler(this.ListPresentaciones_Load);
            this.Controls.SetChildIndex(this.tdbgPresentaciones, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.lblTotales, 0);
            this.Controls.SetChildIndex(this.btnGenerar, 0);
            this.Controls.SetChildIndex(this.lbl01, 0);
            this.Controls.SetChildIndex(this.lblUsuario, 0);
            this.Controls.SetChildIndex(this.lbl02, 0);
            this.Controls.SetChildIndex(this.lblFecha, 0);
            this.Controls.SetChildIndex(this.lblMensaje, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tdbgPresentaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdbgPresentaciones;
        private System.Windows.Forms.Label lblTotales;
        private System.Windows.Forms.Label label5;
        private C1.Win.C1Input.C1Button btnGenerar;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lbl01;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lbl02;
        private System.Windows.Forms.Label lblMensaje;
    }
}
