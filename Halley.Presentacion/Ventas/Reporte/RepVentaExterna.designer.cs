namespace Halley.Presentacion.Ventas.Reporte
{
    partial class RepVentaExterna
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
            this.btnConsultar = new C1.Win.C1Input.C1Button();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpInicial = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.crvVentaExterna = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = global::Halley.Presentacion.Properties.Resources.printView_16x16;
            this.btnConsultar.Location = new System.Drawing.Point(311, 16);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(86, 23);
            this.btnConsultar.TabIndex = 123;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dtpFinal
            // 
            this.dtpFinal.CalendarMonthBackground = System.Drawing.Color.Yellow;
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(221, 16);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(86, 22);
            this.dtpFinal.TabIndex = 122;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 121;
            this.label4.Text = "F. Final :";
            // 
            // dtpInicial
            // 
            this.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicial.Location = new System.Drawing.Point(71, 15);
            this.dtpInicial.Name = "dtpInicial";
            this.dtpInicial.Size = new System.Drawing.Size(86, 22);
            this.dtpInicial.TabIndex = 120;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 119;
            this.label5.Text = "F. Inicial :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dtpInicial);
            this.panel1.Controls.Add(this.dtpFinal);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1003, 50);
            this.panel1.TabIndex = 124;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.crvVentaExterna);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1003, 611);
            this.panel2.TabIndex = 125;
            // 
            // crvVentaExterna
            // 
            this.crvVentaExterna.ActiveViewIndex = -1;
            this.crvVentaExterna.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvVentaExterna.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvVentaExterna.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvVentaExterna.Location = new System.Drawing.Point(0, 0);
            this.crvVentaExterna.Name = "crvVentaExterna";
            this.crvVentaExterna.Size = new System.Drawing.Size(1003, 611);
            this.crvVentaExterna.TabIndex = 0;
            this.crvVentaExterna.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // RepVentaExterna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "RepVentaExterna";
            this.Size = new System.Drawing.Size(1003, 686);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1Button btnConsultar;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpInicial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvVentaExterna;
    }
}
