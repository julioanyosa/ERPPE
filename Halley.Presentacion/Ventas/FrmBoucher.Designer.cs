namespace Halley.Presentacion.Ventas
{
    partial class FrmBoucher
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBoucher));
            this.TxtBanco = new C1.Win.C1Input.C1TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtMonto = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNumBoucher = new C1.Win.C1Input.C1TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Btnagregar = new C1.Win.C1Input.C1Button();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TxtBanco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNumBoucher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtBanco
            // 
            this.TxtBanco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtBanco.Location = new System.Drawing.Point(134, 25);
            this.TxtBanco.MaxLength = 200;
            this.TxtBanco.Name = "TxtBanco";
            this.TxtBanco.Size = new System.Drawing.Size(217, 22);
            this.TxtBanco.TabIndex = 0;
            this.TxtBanco.Tag = null;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(86, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 359;
            this.label11.Text = "Banco:";
            // 
            // TxtMonto
            // 
            this.TxtMonto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtMonto.Location = new System.Drawing.Point(134, 102);
            this.TxtMonto.MaxLength = 200;
            this.TxtMonto.Name = "TxtMonto";
            this.TxtMonto.Size = new System.Drawing.Size(105, 22);
            this.TxtMonto.TabIndex = 2;
            this.TxtMonto.Tag = null;
            this.TxtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMonto_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 361;
            this.label1.Text = "Monto:";
            // 
            // TxtNumBoucher
            // 
            this.TxtNumBoucher.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNumBoucher.Location = new System.Drawing.Point(134, 64);
            this.TxtNumBoucher.MaxLength = 200;
            this.TxtNumBoucher.Name = "TxtNumBoucher";
            this.TxtNumBoucher.Size = new System.Drawing.Size(142, 22);
            this.TxtNumBoucher.TabIndex = 1;
            this.TxtNumBoucher.Tag = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 365;
            this.label3.Text = "Nro de Boucher:";
            // 
            // Btnagregar
            // 
            this.Btnagregar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.Btnagregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btnagregar.Location = new System.Drawing.Point(269, 101);
            this.Btnagregar.Name = "Btnagregar";
            this.Btnagregar.Size = new System.Drawing.Size(82, 23);
            this.Btnagregar.TabIndex = 3;
            this.Btnagregar.Text = "&Aceptar";
            this.Btnagregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btnagregar.UseVisualStyleBackColor = true;
            this.Btnagregar.Click += new System.EventHandler(this.Btnagregar_Click);
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // FrmBoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 141);
            this.Controls.Add(this.Btnagregar);
            this.Controls.Add(this.TxtNumBoucher);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtMonto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtBanco);
            this.Controls.Add(this.label11);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmBoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ingresar Boucher";
            this.Load += new System.EventHandler(this.FrmValesConsumo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtBanco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNumBoucher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1TextBox TxtBanco;
        private System.Windows.Forms.Label label11;
        private C1.Win.C1Input.C1TextBox TxtMonto;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox TxtNumBoucher;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1Button Btnagregar;
        private System.Windows.Forms.ErrorProvider ErrProvider;
    }
}