namespace Halley.Presentacion.Ventas.ReporteNavideño
{
    partial class RepGeneraVales
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
            this.crvDetalle = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvDetalle
            // 
            this.crvDetalle.ActiveViewIndex = -1;
            this.crvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvDetalle.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvDetalle.Location = new System.Drawing.Point(0, 0);
            this.crvDetalle.Name = "crvDetalle";
            this.crvDetalle.ShowZoomButton = false;
            this.crvDetalle.Size = new System.Drawing.Size(710, 559);
            this.crvDetalle.TabIndex = 0;
            this.crvDetalle.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // RepGeneraVales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 559);
            this.Controls.Add(this.crvDetalle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RepGeneraVales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REPORTE DE VALES";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RepGeneraVales_FormClosed);
            this.Load += new System.EventHandler(this.RepGeneraVales_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvDetalle;
    }
}