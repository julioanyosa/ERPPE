﻿namespace Halley.Presentacion.Ventas.Reporte
{
    partial class RepListaPrecio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepListaPrecio));
            this.CrvVentasSede = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnGenerar = new C1.Win.C1Input.C1Button();
            this.c1cboCia = new C1.Win.C1List.C1Combo();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CboSede = new C1.Win.C1List.C1Combo();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboSede)).BeginInit();
            this.SuspendLayout();
            // 
            // CrvVentasSede
            // 
            this.CrvVentasSede.ActiveViewIndex = -1;
            this.CrvVentasSede.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CrvVentasSede.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrvVentasSede.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrvVentasSede.Location = new System.Drawing.Point(25, 57);
            this.CrvVentasSede.Margin = new System.Windows.Forms.Padding(4);
            this.CrvVentasSede.Name = "CrvVentasSede";
            this.CrvVentasSede.Size = new System.Drawing.Size(991, 544);
            this.CrvVentasSede.TabIndex = 5;
            this.CrvVentasSede.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(888, 15);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(109, 34);
            this.btnGenerar.TabIndex = 347;
            this.btnGenerar.Text = "Consultar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // c1cboCia
            // 
            this.c1cboCia.AddItemSeparator = ';';
            this.c1cboCia.AutoCompletion = true;
            this.c1cboCia.AutoDropDown = true;
            this.c1cboCia.Caption = "";
            this.c1cboCia.CaptionHeight = 17;
            this.c1cboCia.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.c1cboCia.ColumnCaptionHeight = 17;
            this.c1cboCia.ColumnFooterHeight = 17;
            this.c1cboCia.ColumnHeaders = false;
            this.c1cboCia.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.c1cboCia.ContentHeight = 21;
            this.c1cboCia.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.c1cboCia.DisplayMember = "NomEmpresa";
            this.c1cboCia.EditorBackColor = System.Drawing.SystemColors.Window;
            this.c1cboCia.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1cboCia.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.c1cboCia.EditorHeight = 21;
            this.c1cboCia.Images.Add(((System.Drawing.Image)(resources.GetObject("c1cboCia.Images"))));
            this.c1cboCia.ItemHeight = 15;
            this.c1cboCia.Location = new System.Drawing.Point(244, 19);
            this.c1cboCia.Margin = new System.Windows.Forms.Padding(4);
            this.c1cboCia.MatchEntryTimeout = ((long)(2000));
            this.c1cboCia.MaxDropDownItems = ((short)(10));
            this.c1cboCia.MaxLength = 32767;
            this.c1cboCia.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.c1cboCia.Name = "c1cboCia";
            this.c1cboCia.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.c1cboCia.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1cboCia.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1cboCia.Size = new System.Drawing.Size(213, 27);
            this.c1cboCia.TabIndex = 388;
            this.c1cboCia.ValueMember = "EmpresaID";
            this.c1cboCia.PropBag = resources.GetString("c1cboCia.PropBag");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(173, 23);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 19);
            this.label14.TabIndex = 389;
            this.label14.Text = "Empresa:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(464, 23);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 19);
            this.label8.TabIndex = 387;
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
            this.CboSede.ContentHeight = 21;
            this.CboSede.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.CboSede.DisplayMember = "NomEmpresa";
            this.CboSede.EditorBackColor = System.Drawing.SystemColors.Window;
            this.CboSede.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboSede.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.CboSede.EditorHeight = 21;
            this.CboSede.Images.Add(((System.Drawing.Image)(resources.GetObject("CboSede.Images"))));
            this.CboSede.ItemHeight = 15;
            this.CboSede.Location = new System.Drawing.Point(512, 19);
            this.CboSede.Margin = new System.Windows.Forms.Padding(4);
            this.CboSede.MatchEntryTimeout = ((long)(2000));
            this.CboSede.MaxDropDownItems = ((short)(10));
            this.CboSede.MaxLength = 32767;
            this.CboSede.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.CboSede.Name = "CboSede";
            this.CboSede.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.CboSede.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.CboSede.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.CboSede.Size = new System.Drawing.Size(369, 27);
            this.CboSede.TabIndex = 386;
            this.CboSede.ValueMember = "EmpresaID";
            this.CboSede.PropBag = resources.GetString("CboSede.PropBag");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 28);
            this.label3.TabIndex = 395;
            this.label3.Text = "Lista de Precios";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RepListaPrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.c1cboCia);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CboSede);
            this.Controls.Add(this.CrvVentasSede);
            this.Controls.Add(this.btnGenerar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RepListaPrecio";
            this.Size = new System.Drawing.Size(1379, 662);
            this.Load += new System.EventHandler(this.ReporteVentas_Load);
            this.Controls.SetChildIndex(this.btnGenerar, 0);
            this.Controls.SetChildIndex(this.CrvVentasSede, 0);
            this.Controls.SetChildIndex(this.CboSede, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.c1cboCia, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboSede)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrvVentasSede;
        private C1.Win.C1Input.C1Button btnGenerar;
        private C1.Win.C1List.C1Combo c1cboCia;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private C1.Win.C1List.C1Combo CboSede;
        private System.Windows.Forms.Label label3;
    }
}
