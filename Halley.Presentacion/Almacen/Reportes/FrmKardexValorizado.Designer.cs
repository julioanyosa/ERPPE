namespace Halley.Presentacion.Almacen.Reportes
{
    partial class FrmKardexValorizado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKardexValorizado));
            this.CrvKardex = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.BtnActualizar = new C1.Win.C1Input.C1Button();
            this.BtnCerrar = new C1.Win.C1Input.C1Button();
            this.SuspendLayout();
            // 
            // CrvKardex
            // 
            this.CrvKardex.ActiveViewIndex = -1;
            this.CrvKardex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CrvKardex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrvKardex.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrvKardex.Location = new System.Drawing.Point(0, 29);
            this.CrvKardex.Name = "CrvKardex";
            this.CrvKardex.Size = new System.Drawing.Size(758, 437);
            this.CrvKardex.TabIndex = 7;
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnActualizar.Image = global::Halley.Presentacion.Properties.Resources.save_16x16;
            this.BtnActualizar.Location = new System.Drawing.Point(571, 2);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(86, 23);
            this.BtnActualizar.TabIndex = 8;
            this.BtnActualizar.Text = "Actualizar";
            this.BtnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCerrar.Image = global::Halley.Presentacion.Properties.Resources.cerrar_16x16;
            this.BtnCerrar.Location = new System.Drawing.Point(667, 2);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(86, 23);
            this.BtnCerrar.TabIndex = 9;
            this.BtnCerrar.Text = "Cerrar";
            this.BtnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // FrmKardexValorizado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 466);
            this.Controls.Add(this.BtnActualizar);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.CrvKardex);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmKardexValorizado";
            this.Text = "Kardex valorizado";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmKardexValorizado_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrvKardex;
        private C1.Win.C1Input.C1Button BtnActualizar;
        private C1.Win.C1Input.C1Button BtnCerrar;
    }
}