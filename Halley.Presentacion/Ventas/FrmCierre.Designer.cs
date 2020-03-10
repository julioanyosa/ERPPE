namespace Halley.Presentacion.Ventas
{
    partial class FrmCierre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCierre));
            this.BtnCierre = new C1.Win.C1Input.C1Button();
            this.c1cboCia = new C1.Win.C1List.C1Combo();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.TxtFormatoticketera = new C1.Win.C1Input.C1TextBox();
            this.DtpFechaCierre = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFormatoticketera)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCierre
            // 
            this.BtnCierre.Image = global::Halley.Presentacion.Properties.Resources.Sum16x16;
            this.BtnCierre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCierre.Location = new System.Drawing.Point(268, 10);
            this.BtnCierre.Name = "BtnCierre";
            this.BtnCierre.Size = new System.Drawing.Size(87, 23);
            this.BtnCierre.TabIndex = 414;
            this.BtnCierre.Text = "Cerrar Caja";
            this.BtnCierre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCierre.UseVisualStyleBackColor = true;
            this.BtnCierre.Click += new System.EventHandler(this.BtnCierre_Click);
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
            this.c1cboCia.ContentHeight = 17;
            this.c1cboCia.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.c1cboCia.DisplayMember = "NomEmpresa";
            this.c1cboCia.EditorBackColor = System.Drawing.SystemColors.Window;
            this.c1cboCia.EditorFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1cboCia.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.c1cboCia.EditorHeight = 17;
            this.c1cboCia.Images.Add(((System.Drawing.Image)(resources.GetObject("c1cboCia.Images"))));
            this.c1cboCia.ItemHeight = 15;
            this.c1cboCia.Location = new System.Drawing.Point(12, 12);
            this.c1cboCia.MatchEntryTimeout = ((long)(2000));
            this.c1cboCia.MaxDropDownItems = ((short)(10));
            this.c1cboCia.MaxLength = 32767;
            this.c1cboCia.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.c1cboCia.Name = "c1cboCia";
            this.c1cboCia.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.c1cboCia.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1cboCia.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1cboCia.Size = new System.Drawing.Size(160, 23);
            this.c1cboCia.TabIndex = 424;
            this.c1cboCia.ValueMember = "EmpresaID";
            this.c1cboCia.PropBag = resources.GetString("c1cboCia.PropBag");
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // TxtFormatoticketera
            // 
            this.TxtFormatoticketera.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFormatoticketera.Location = new System.Drawing.Point(380, 12);
            this.TxtFormatoticketera.MaxLength = 300;
            this.TxtFormatoticketera.Name = "TxtFormatoticketera";
            this.TxtFormatoticketera.Size = new System.Drawing.Size(107, 21);
            this.TxtFormatoticketera.TabIndex = 425;
            this.TxtFormatoticketera.Tag = null;
            this.TxtFormatoticketera.Visible = false;
            // 
            // DtpFechaCierre
            // 
            this.DtpFechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaCierre.Location = new System.Drawing.Point(178, 13);
            this.DtpFechaCierre.Name = "DtpFechaCierre";
            this.DtpFechaCierre.Size = new System.Drawing.Size(84, 20);
            this.DtpFechaCierre.TabIndex = 426;
            // 
            // FrmCierre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 51);
            this.Controls.Add(this.DtpFechaCierre);
            this.Controls.Add(this.TxtFormatoticketera);
            this.Controls.Add(this.BtnCierre);
            this.Controls.Add(this.c1cboCia);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmCierre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cerrar Ticketera";
            this.Load += new System.EventHandler(this.FrmCierre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1cboCia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFormatoticketera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1Button BtnCierre;
        private C1.Win.C1List.C1Combo c1cboCia;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private C1.Win.C1Input.C1TextBox TxtFormatoticketera;
        private System.Windows.Forms.DateTimePicker DtpFechaCierre;
    }
}