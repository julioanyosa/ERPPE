namespace Halley.Presentacion.VentasTemp
{
    partial class FrmPago
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
            this.TxtVuelto = new C1.Win.C1Input.C1TextBox();
            this.Btncerrar = new C1.Win.C1Input.C1Button();
            this.lbldfdf = new System.Windows.Forms.Label();
            this.lblfd = new System.Windows.Forms.Label();
            this.TxtPago = new C1.Win.C1Input.C1TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TxtVuelto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPago)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtVuelto
            // 
            this.TxtVuelto.BackColor = System.Drawing.Color.White;
            this.TxtVuelto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtVuelto.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtVuelto.Location = new System.Drawing.Point(138, 107);
            this.TxtVuelto.MaxLength = 20;
            this.TxtVuelto.Name = "TxtVuelto";
            this.TxtVuelto.Size = new System.Drawing.Size(294, 78);
            this.TxtVuelto.TabIndex = 80;
            this.TxtVuelto.Tag = null;
            this.TxtVuelto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtVuelto.Value = "0";
            this.TxtVuelto.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtVuelto.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // Btncerrar
            // 
            this.Btncerrar.Image = global::Halley.Presentacion.Properties.Resources.Cancelar_16x16;
            this.Btncerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btncerrar.Location = new System.Drawing.Point(444, 160);
            this.Btncerrar.Name = "Btncerrar";
            this.Btncerrar.Size = new System.Drawing.Size(87, 25);
            this.Btncerrar.TabIndex = 79;
            this.Btncerrar.Text = "Cerrar";
            this.Btncerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btncerrar.UseVisualStyleBackColor = true;
            this.Btncerrar.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // lbldfdf
            // 
            this.lbldfdf.AutoSize = true;
            this.lbldfdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldfdf.ForeColor = System.Drawing.Color.DimGray;
            this.lbldfdf.Location = new System.Drawing.Point(59, 39);
            this.lbldfdf.Name = "lbldfdf";
            this.lbldfdf.Size = new System.Drawing.Size(73, 25);
            this.lbldfdf.TabIndex = 77;
            this.lbldfdf.Text = "Pago:";
            // 
            // lblfd
            // 
            this.lblfd.AutoSize = true;
            this.lblfd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfd.ForeColor = System.Drawing.Color.DimGray;
            this.lblfd.Location = new System.Drawing.Point(46, 121);
            this.lblfd.Name = "lblfd";
            this.lblfd.Size = new System.Drawing.Size(86, 25);
            this.lblfd.TabIndex = 76;
            this.lblfd.Text = "Vuelto:";
            // 
            // TxtPago
            // 
            this.TxtPago.BackColor = System.Drawing.Color.White;
            this.TxtPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPago.Location = new System.Drawing.Point(138, 12);
            this.TxtPago.MaxLength = 20;
            this.TxtPago.Name = "TxtPago";
            this.TxtPago.Size = new System.Drawing.Size(294, 78);
            this.TxtPago.TabIndex = 75;
            this.TxtPago.Tag = null;
            this.TxtPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtPago.Value = "0";
            this.TxtPago.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtPago.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.TxtPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPago_KeyPress);
            this.TxtPago.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtPago_KeyUp);
            // 
            // FrmPago
            // 
            this.AcceptButton = this.Btncerrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 198);
            this.Controls.Add(this.TxtVuelto);
            this.Controls.Add(this.Btncerrar);
            this.Controls.Add(this.lbldfdf);
            this.Controls.Add(this.lblfd);
            this.Controls.Add(this.TxtPago);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ingrese El pago para calcular el vuelto";
            ((System.ComponentModel.ISupportInitialize)(this.TxtVuelto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1TextBox TxtVuelto;
        private C1.Win.C1Input.C1Button Btncerrar;
        private System.Windows.Forms.Label lbldfdf;
        private System.Windows.Forms.Label lblfd;
        private C1.Win.C1Input.C1TextBox TxtPago;

    }
}