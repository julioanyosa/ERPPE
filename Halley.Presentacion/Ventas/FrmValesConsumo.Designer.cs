namespace Halley.Presentacion.Ventas
{
    partial class FrmValesConsumo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmValesConsumo));
            this.TxtCodigo = new C1.Win.C1Input.C1TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtMonto = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNumValeConsumo = new C1.Win.C1Input.C1TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TdgValesConsumo = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.DtpFechaEmision = new System.Windows.Forms.DateTimePicker();
            this.Btnagregar = new C1.Win.C1Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNumValeConsumo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgValesConsumo)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtCodigo.Location = new System.Drawing.Point(167, 18);
            this.TxtCodigo.MaxLength = 200;
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.Size = new System.Drawing.Size(217, 22);
            this.TxtCodigo.TabIndex = 360;
            this.TxtCodigo.Tag = null;
            this.TxtCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtCodigo_KeyUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 13);
            this.label11.TabIndex = 359;
            this.label11.Text = "Ingrese codigo de barras:";
            // 
            // TxtMonto
            // 
            this.TxtMonto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtMonto.Location = new System.Drawing.Point(77, 62);
            this.TxtMonto.MaxLength = 200;
            this.TxtMonto.Name = "TxtMonto";
            this.TxtMonto.Size = new System.Drawing.Size(105, 22);
            this.TxtMonto.TabIndex = 362;
            this.TxtMonto.Tag = null;
            this.TxtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMonto_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 361;
            this.label1.Text = "Monto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 363;
            this.label2.Text = "Fecha de emisión del vale:";
            // 
            // TxtNumValeConsumo
            // 
            this.TxtNumValeConsumo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNumValeConsumo.Location = new System.Drawing.Point(531, 62);
            this.TxtNumValeConsumo.MaxLength = 200;
            this.TxtNumValeConsumo.Name = "TxtNumValeConsumo";
            this.TxtNumValeConsumo.Size = new System.Drawing.Size(142, 22);
            this.TxtNumValeConsumo.TabIndex = 366;
            this.TxtNumValeConsumo.Tag = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(461, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 365;
            this.label3.Text = "Num de vale:";
            // 
            // TdgValesConsumo
            // 
            this.TdgValesConsumo.AllowDelete = true;
            this.TdgValesConsumo.AllowUpdate = false;
            this.TdgValesConsumo.Caption = "VALES INCLUIDOS EN LA COMPRA";
            this.TdgValesConsumo.CaptionHeight = 17;
            this.TdgValesConsumo.CausesValidation = false;
            this.TdgValesConsumo.ColumnFooters = true;
            this.TdgValesConsumo.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveUp;
            this.TdgValesConsumo.EmptyRows = true;
            this.TdgValesConsumo.ExtendRightColumn = true;
            this.TdgValesConsumo.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgValesConsumo.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgValesConsumo.Images"))));
            this.TdgValesConsumo.Location = new System.Drawing.Point(12, 102);
            this.TdgValesConsumo.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgValesConsumo.Name = "TdgValesConsumo";
            this.TdgValesConsumo.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgValesConsumo.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgValesConsumo.PreviewInfo.ZoomFactor = 75D;
            this.TdgValesConsumo.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgComprobantes.PrintInfo.PageSettings")));
            this.TdgValesConsumo.RowHeight = 18;
            this.TdgValesConsumo.Size = new System.Drawing.Size(749, 163);
            this.TdgValesConsumo.TabIndex = 422;
            this.TdgValesConsumo.Text = "Productos Genéricos";
            this.TdgValesConsumo.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2007Blue;
            this.TdgValesConsumo.PropBag = resources.GetString("TdgValesConsumo.PropBag");
            // 
            // DtpFechaEmision
            // 
            this.DtpFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaEmision.Location = new System.Drawing.Point(356, 62);
            this.DtpFechaEmision.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DtpFechaEmision.Name = "DtpFechaEmision";
            this.DtpFechaEmision.Size = new System.Drawing.Size(81, 22);
            this.DtpFechaEmision.TabIndex = 423;
            // 
            // Btnagregar
            // 
            this.Btnagregar.Image = global::Halley.Presentacion.Properties.Resources.Add_16x16;
            this.Btnagregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btnagregar.Location = new System.Drawing.Point(679, 60);
            this.Btnagregar.Name = "Btnagregar";
            this.Btnagregar.Size = new System.Drawing.Size(82, 23);
            this.Btnagregar.TabIndex = 424;
            this.Btnagregar.Text = "&Agregar";
            this.Btnagregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btnagregar.UseVisualStyleBackColor = true;
            this.Btnagregar.Click += new System.EventHandler(this.Btnagregar_Click);
            // 
            // FrmValesConsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 285);
            this.Controls.Add(this.Btnagregar);
            this.Controls.Add(this.DtpFechaEmision);
            this.Controls.Add(this.TdgValesConsumo);
            this.Controls.Add(this.TxtNumValeConsumo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtMonto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtCodigo);
            this.Controls.Add(this.label11);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmValesConsumo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ingreso de vales de consumo";
            this.Load += new System.EventHandler(this.FrmValesConsumo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNumValeConsumo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgValesConsumo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1TextBox TxtCodigo;
        private System.Windows.Forms.Label label11;
        private C1.Win.C1Input.C1TextBox TxtMonto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1TextBox TxtNumValeConsumo;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgValesConsumo;
        private System.Windows.Forms.DateTimePicker DtpFechaEmision;
        private C1.Win.C1Input.C1Button Btnagregar;
    }
}