namespace Halley.Presentacion.Almacen.Reportes
{
	partial class FrmGuiaCompraMaiz
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
            this.CrvGuiaCompraMaiz = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TxtNroHojaLiquidacion = new System.Windows.Forms.ToolStripTextBox();
            this.BtnMostrar = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CrvGuiaCompraMaiz
            // 
            this.CrvGuiaCompraMaiz.ActiveViewIndex = -1;
            this.CrvGuiaCompraMaiz.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CrvGuiaCompraMaiz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrvGuiaCompraMaiz.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrvGuiaCompraMaiz.DisplayStatusBar = false;
            this.CrvGuiaCompraMaiz.Location = new System.Drawing.Point(0, 28);
            this.CrvGuiaCompraMaiz.Name = "CrvGuiaCompraMaiz";
            this.CrvGuiaCompraMaiz.Size = new System.Drawing.Size(872, 475);
            this.CrvGuiaCompraMaiz.TabIndex = 1;
            this.CrvGuiaCompraMaiz.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.TxtNroHojaLiquidacion,
            this.BtnMostrar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(872, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(160, 22);
            this.toolStripLabel1.Text = "Ingrese Nro Hoja de liquidacion:";
            // 
            // TxtNroHojaLiquidacion
            // 
            this.TxtNroHojaLiquidacion.Name = "TxtNroHojaLiquidacion";
            this.TxtNroHojaLiquidacion.Size = new System.Drawing.Size(100, 25);
            // 
            // BtnMostrar
            // 
            this.BtnMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnMostrar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.BtnMostrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnMostrar.Name = "BtnMostrar";
            this.BtnMostrar.Size = new System.Drawing.Size(23, 22);
            this.BtnMostrar.Text = "Mostrar";
            this.BtnMostrar.Click += new System.EventHandler(this.BtnMostrar_Click);
            // 
            // FrmGuiaCompraMaiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 503);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.CrvGuiaCompraMaiz);
            this.Name = "FrmGuiaCompraMaiz";
            this.Text = "Hoja de liquidacion de un producto";
            this.Load += new System.EventHandler(this.FrmGuiaCompraMaiz_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrvGuiaCompraMaiz;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox TxtNroHojaLiquidacion;
        private System.Windows.Forms.ToolStripButton BtnMostrar;
	}
}