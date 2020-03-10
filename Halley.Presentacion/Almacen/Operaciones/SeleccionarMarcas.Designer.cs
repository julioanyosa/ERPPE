namespace Halley.Presentacion.Almacen.Operaciones
{
    partial class SeleccionarMarcas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeleccionarMarcas));
            this.TdgMarcas = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TdgMarcas)).BeginInit();
            this.SuspendLayout();
            // 
            // TdgMarcas
            // 
            this.TdgMarcas.AllowUpdate = false;
            this.TdgMarcas.CaptionHeight = 17;
            this.TdgMarcas.EmptyRows = true;
            this.TdgMarcas.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgMarcas.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgMarcas.Images"))));
            this.TdgMarcas.Location = new System.Drawing.Point(12, 34);
            this.TdgMarcas.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgMarcas.Name = "TdgMarcas";
            this.TdgMarcas.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgMarcas.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgMarcas.PreviewInfo.ZoomFactor = 75D;
            this.TdgMarcas.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgMarcas.PrintInfo.PageSettings")));
            this.TdgMarcas.RowHeight = 18;
            this.TdgMarcas.Size = new System.Drawing.Size(727, 106);
            this.TdgMarcas.TabIndex = 0;
            this.TdgMarcas.Text = "c1TrueDBGrid1";
            this.TdgMarcas.DoubleClick += new System.EventHandler(this.TdgMarcas_DoubleClick);
            this.TdgMarcas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TdgMarcas_KeyPress);
            this.TdgMarcas.PropBag = resources.GetString("TdgMarcas.PropBag");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Marcas disponibles para este producto";
            // 
            // SeleccionarMarcas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(746, 149);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TdgMarcas);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SeleccionarMarcas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Marcas disponibles del producto en esta sede";
            this.Load += new System.EventHandler(this.SeleccionarMarcas_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SeleccionarMarcas_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.TdgMarcas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgMarcas;
        private System.Windows.Forms.Label label1;
    }
}