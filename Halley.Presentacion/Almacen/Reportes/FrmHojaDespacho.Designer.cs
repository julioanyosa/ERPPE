namespace Halley.Presentacion.Almacen.Reportes
{
    partial class FrmHojaDespacho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHojaDespacho));
            this.CrvHojaDespacho = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrvHojaDespacho
            // 
            this.CrvHojaDespacho.ActiveViewIndex = -1;
            this.CrvHojaDespacho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrvHojaDespacho.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrvHojaDespacho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrvHojaDespacho.Location = new System.Drawing.Point(0, 0);
            this.CrvHojaDespacho.Name = "CrvHojaDespacho";
            this.CrvHojaDespacho.Size = new System.Drawing.Size(950, 490);
            this.CrvHojaDespacho.TabIndex = 0;
            this.CrvHojaDespacho.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FrmHojaDespacho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 490);
            this.Controls.Add(this.CrvHojaDespacho);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmHojaDespacho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hoja de despacho";
            this.Load += new System.EventHandler(this.FrmHojaDespacho_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrvHojaDespacho;








    }
}