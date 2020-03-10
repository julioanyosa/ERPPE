namespace Halley.Presentacion.Ventas.Reporte
{
    partial class RptVendedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptVendedor));
            this.CrvVendedores = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnMostrar = new C1.Win.C1Input.C1Button();
            this.label8 = new System.Windows.Forms.Label();
            this.CboSede = new C1.Win.C1List.C1Combo();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CboSede)).BeginInit();
            this.SuspendLayout();
            // 
            // CrvVendedores
            // 
            this.CrvVendedores.ActiveViewIndex = -1;
            this.CrvVendedores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CrvVendedores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrvVendedores.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrvVendedores.Location = new System.Drawing.Point(3, 35);
            this.CrvVendedores.Name = "CrvVendedores";
            this.CrvVendedores.Size = new System.Drawing.Size(1008, 768);
            this.CrvVendedores.TabIndex = 348;
            this.CrvVendedores.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnMostrar
            // 
            this.btnMostrar.Image = global::Halley.Presentacion.Properties.Resources.Perfil_16x16;
            this.btnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMostrar.Location = new System.Drawing.Point(732, 12);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(82, 23);
            this.btnMostrar.TabIndex = 349;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(395, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 390;
            this.label8.Text = "Sede:";
            // 
            // CboSede
            // 
            this.CboSede.AddItemSeparator = ';';
            this.CboSede.AutoCompletion = true;
            this.CboSede.AutoDropDown = true;
            this.CboSede.Caption = "Seleccione Sede";
            this.CboSede.CaptionHeight = 17;
            this.CboSede.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CboSede.ColumnCaptionHeight = 17;
            this.CboSede.ColumnFooterHeight = 17;
            this.CboSede.ColumnHeaders = false;
            this.CboSede.ContentHeight = 17;
            this.CboSede.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboSede.DisplayMember = "NomEmpresa";
            this.CboSede.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboSede.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboSede.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboSede.EditorHeight = 17;
            this.CboSede.Images.Add(((System.Drawing.Image)(resources.GetObject("CboSede.Images"))));
            this.CboSede.ItemHeight = 15;
            this.CboSede.Location = new System.Drawing.Point(434, 12);
            this.CboSede.MatchEntryTimeout = ((long)(2000));
            this.CboSede.MaxDropDownItems = ((short)(10));
            this.CboSede.MaxLength = 32767;
            this.CboSede.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboSede.Name = "CboSede";
            this.CboSede.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboSede.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboSede.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboSede.Size = new System.Drawing.Size(292, 23);
            this.CboSede.TabIndex = 389;
            this.CboSede.ValueMember = "EmpresaID";
            this.CboSede.PropBag = resources.GetString("CboSede.PropBag");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 21);
            this.label3.TabIndex = 398;
            this.label3.Text = "Lista de Vendedores";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RptVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CboSede);
            this.Controls.Add(this.CrvVendedores);
            this.Controls.Add(this.btnMostrar);
            this.Name = "RptVendedor";
            this.Size = new System.Drawing.Size(1108, 556);
            this.Load += new System.EventHandler(this.RptVendedor_Load);
            this.Controls.SetChildIndex(this.btnMostrar, 0);
            this.Controls.SetChildIndex(this.CrvVendedores, 0);
            this.Controls.SetChildIndex(this.CboSede, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.CboSede)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrvVendedores;
        private C1.Win.C1Input.C1Button btnMostrar;
        private System.Windows.Forms.Label label8;
        private C1.Win.C1List.C1Combo CboSede;
        private System.Windows.Forms.Label label3;
    }
}
