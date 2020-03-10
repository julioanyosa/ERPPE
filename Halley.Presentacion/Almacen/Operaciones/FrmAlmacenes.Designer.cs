namespace Halley.Presentacion.Almacen.Operaciones
{
    partial class FrmAlmacenes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlmacenes));
            this.LbAlias = new System.Windows.Forms.Label();
            this.BtnCancelar = new C1.Win.C1Input.C1Button();
            this.LstStocks = new C1.Win.C1List.C1List();
            this.BtnSeleccionarAlmacen = new C1.Win.C1Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)(this.LstStocks)).BeginInit();
            this.SuspendLayout();
            // 
            // LbAlias
            // 
            this.LbAlias.AutoSize = true;
            this.LbAlias.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbAlias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LbAlias.Location = new System.Drawing.Point(12, 9);
            this.LbAlias.Name = "LbAlias";
            this.LbAlias.Size = new System.Drawing.Size(175, 21);
            this.LbAlias.TabIndex = 413;
            this.LbAlias.Text = "Nombre del producto";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Image = global::Halley.Presentacion.Properties.Resources.Cancelar_16x16;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(452, 113);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(84, 23);
            this.BtnCancelar.TabIndex = 412;
            this.BtnCancelar.Text = "&Cerrar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // LstStocks
            // 
            this.LstStocks.AddItemSeparator = ';';
            this.LstStocks.Caption = "Stock en almacenes";
            this.LstStocks.CaptionHeight = 17;
            this.LstStocks.ColumnCaptionHeight = 17;
            this.LstStocks.ColumnFooterHeight = 17;
            this.LstStocks.DeadAreaBackColor = System.Drawing.SystemColors.ControlDark;
            this.LstStocks.EmptyRows = true;
            this.LstStocks.Images.Add(((System.Drawing.Image)(resources.GetObject("LstStocks.Images"))));
            this.LstStocks.ItemHeight = 15;
            this.LstStocks.Location = new System.Drawing.Point(12, 33);
            this.LstStocks.MatchEntryTimeout = ((long)(2000));
            this.LstStocks.Name = "LstStocks";
            this.LstStocks.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.LstStocks.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.LstStocks.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.LstStocks.Size = new System.Drawing.Size(434, 105);
            this.LstStocks.TabIndex = 414;
            this.LstStocks.DoubleClick += new System.EventHandler(this.LstStocks_DoubleClick);
            this.LstStocks.PropBag = resources.GetString("LstStocks.PropBag");
            // 
            // BtnSeleccionarAlmacen
            // 
            this.BtnSeleccionarAlmacen.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.BtnSeleccionarAlmacen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSeleccionarAlmacen.Location = new System.Drawing.Point(452, 33);
            this.BtnSeleccionarAlmacen.Name = "BtnSeleccionarAlmacen";
            this.BtnSeleccionarAlmacen.Size = new System.Drawing.Size(84, 41);
            this.BtnSeleccionarAlmacen.TabIndex = 415;
            this.BtnSeleccionarAlmacen.Text = "&Seleccionar\r\nalmacen";
            this.BtnSeleccionarAlmacen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSeleccionarAlmacen.UseVisualStyleBackColor = true;
            this.BtnSeleccionarAlmacen.Click += new System.EventHandler(this.BtnSeleccionarAlmacen_Click);
            // 
            // FrmAlmacenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 148);
            this.Controls.Add(this.BtnSeleccionarAlmacen);
            this.Controls.Add(this.LstStocks);
            this.Controls.Add(this.LbAlias);
            this.Controls.Add(this.BtnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAlmacenes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stock por producto y almacen.";
            this.Load += new System.EventHandler(this.FrmDespachos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LstStocks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbAlias;
        private C1.Win.C1Input.C1Button BtnCancelar;
        private C1.Win.C1List.C1List LstStocks;
        private C1.Win.C1Input.C1Button BtnSeleccionarAlmacen;
    }
}