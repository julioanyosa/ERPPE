namespace Halley.Presentacion.Ventas.ReporteNavideño
{
    partial class RepProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepProducto));
            this.tdbgdetalle = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c1NumericEdit1 = new C1.Win.C1Input.C1NumericEdit();
            this.btnCancelar = new C1.Win.C1Input.C1Button();
            this.btnRegistrar = new C1.Win.C1Input.C1Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblComprobante = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgdetalle)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1NumericEdit1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tdbgdetalle
            // 
            this.tdbgdetalle.Caption = "DETALLE DE PRODUCTOS";
            this.tdbgdetalle.CaptionHeight = 17;
            this.tdbgdetalle.CausesValidation = false;
            this.tdbgdetalle.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveUp;
            this.tdbgdetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tdbgdetalle.EmptyRows = true;
            this.tdbgdetalle.ExtendRightColumn = true;
            this.tdbgdetalle.GroupByCaption = "Drag a column header here to group by that column";
            this.tdbgdetalle.Images.Add(((System.Drawing.Image)(resources.GetObject("tdbgdetalle.Images"))));
            this.tdbgdetalle.Location = new System.Drawing.Point(0, 0);
            this.tdbgdetalle.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.tdbgdetalle.Name = "tdbgdetalle";
            this.tdbgdetalle.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdbgdetalle.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdbgdetalle.PreviewInfo.ZoomFactor = 75D;
            this.tdbgdetalle.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdbgdetalle.PrintInfo.PageSettings")));
            this.tdbgdetalle.RowHeight = 18;
            this.tdbgdetalle.Size = new System.Drawing.Size(763, 432);
            this.tdbgdetalle.TabIndex = 5;
            this.tdbgdetalle.Text = "Productos Genéricos";
            this.tdbgdetalle.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2007Blue;
            this.tdbgdetalle.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.tdbgdetalle_AfterColUpdate);
            this.tdbgdetalle.FetchCellStyle += new C1.Win.C1TrueDBGrid.FetchCellStyleEventHandler(this.tdbgdetalle_FetchCellStyle);
            this.tdbgdetalle.PropBag = resources.GetString("tdbgdetalle.PropBag");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.c1NumericEdit1);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnRegistrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 476);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 35);
            this.panel1.TabIndex = 6;
            // 
            // c1NumericEdit1
            // 
            this.c1NumericEdit1.DataType = typeof(long);
            this.c1NumericEdit1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.Integer;
            this.c1NumericEdit1.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
                        | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.c1NumericEdit1.Location = new System.Drawing.Point(334, 7);
            this.c1NumericEdit1.MaxLength = 10;
            this.c1NumericEdit1.Name = "c1NumericEdit1";
            this.c1NumericEdit1.Size = new System.Drawing.Size(94, 20);
            this.c1NumericEdit1.TabIndex = 108;
            this.c1NumericEdit1.Tag = null;
            this.c1NumericEdit1.Visible = false;
            this.c1NumericEdit1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::Halley.Presentacion.Properties.Resources.Cancelar_16x16;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(679, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(72, 23);
            this.btnCancelar.TabIndex = 93;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Image = global::Halley.Presentacion.Properties.Resources.guardar_16x16;
            this.btnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrar.Location = new System.Drawing.Point(603, 7);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(70, 23);
            this.btnRegistrar.TabIndex = 92;
            this.btnRegistrar.Text = "Guardar";
            this.btnRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tdbgdetalle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(763, 432);
            this.panel2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 138;
            this.label2.Text = "Cliente :";
            // 
            // lblCliente
            // 
            this.lblCliente.BackColor = System.Drawing.Color.White;
            this.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCliente.Location = new System.Drawing.Point(81, 9);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(353, 21);
            this.lblCliente.TabIndex = 139;
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(495, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 144;
            this.label8.Text = "Comprobante :";
            // 
            // lblComprobante
            // 
            this.lblComprobante.BackColor = System.Drawing.Color.White;
            this.lblComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblComprobante.Location = new System.Drawing.Point(577, 10);
            this.lblComprobante.Name = "lblComprobante";
            this.lblComprobante.Size = new System.Drawing.Size(174, 21);
            this.lblComprobante.TabIndex = 145;
            this.lblComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblComprobante);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.lblCliente);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(763, 44);
            this.panel3.TabIndex = 8;
            // 
            // RepProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 511);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RepProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DETALLE";
            this.Load += new System.EventHandler(this.RepProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tdbgdetalle)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1NumericEdit1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdbgdetalle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private C1.Win.C1Input.C1Button btnCancelar;
        private C1.Win.C1Input.C1Button btnRegistrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblComprobante;
        private System.Windows.Forms.Panel panel3;
        private C1.Win.C1Input.C1NumericEdit c1NumericEdit1;
    }
}