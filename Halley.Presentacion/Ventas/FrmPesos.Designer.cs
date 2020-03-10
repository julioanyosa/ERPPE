namespace Halley.Presentacion.Ventas
{
    partial class FrmPesos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesos));
            this.btnLimpiar = new C1.Win.C1Input.C1Button();
            this.BtnRegistrar = new C1.Win.C1Input.C1Button();
            this.BtnBalanza = new C1.Win.C1Input.C1Button();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.TxtTara = new C1.Win.C1Input.C1TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.LstPesoBruto = new System.Windows.Forms.ListBox();
            this.BtnCerrar = new C1.Win.C1Input.C1Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LblNeto = new System.Windows.Forms.Label();
            this.LblBruto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTara)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::Halley.Presentacion.Properties.Resources.newdocument_16x16;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(22, 178);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(80, 25);
            this.btnLimpiar.TabIndex = 349;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.BtnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRegistrar.Location = new System.Drawing.Point(409, 226);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(82, 49);
            this.BtnRegistrar.TabIndex = 348;
            this.BtnRegistrar.Text = "&Registrar";
            this.BtnRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // BtnBalanza
            // 
            this.BtnBalanza.Image = global::Halley.Presentacion.Properties.Resources.Pesa_48x48;
            this.BtnBalanza.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnBalanza.Location = new System.Drawing.Point(409, 143);
            this.BtnBalanza.Name = "BtnBalanza";
            this.BtnBalanza.Size = new System.Drawing.Size(82, 77);
            this.BtnBalanza.TabIndex = 411;
            this.BtnBalanza.Text = "Balanza";
            this.BtnBalanza.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBalanza.UseVisualStyleBackColor = true;
            this.BtnBalanza.Click += new System.EventHandler(this.BtnBalanza_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(222, 250);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(56, 21);
            this.label32.TabIndex = 416;
            this.label32.Text = "Bruto:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(226, 213);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(52, 21);
            this.label31.TabIndex = 414;
            this.label31.Text = "Neto:";
            // 
            // TxtTara
            // 
            this.TxtTara.BackColor = System.Drawing.Color.White;
            this.TxtTara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTara.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTara.ForeColor = System.Drawing.Color.SteelBlue;
            this.TxtTara.Location = new System.Drawing.Point(284, 169);
            this.TxtTara.MaxLength = 8;
            this.TxtTara.Name = "TxtTara";
            this.TxtTara.Size = new System.Drawing.Size(105, 33);
            this.TxtTara.TabIndex = 413;
            this.TxtTara.Tag = null;
            this.TxtTara.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtTara.Value = "0.00";
            this.TxtTara.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtTara.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.TxtTara.TextChanged += new System.EventHandler(this.TxtTara_TextChanged);
            this.TxtTara.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTara_KeyPress);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(230, 176);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 21);
            this.label20.TabIndex = 412;
            this.label20.Text = "Tara:";
            // 
            // LstPesoBruto
            // 
            this.LstPesoBruto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.LstPesoBruto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstPesoBruto.ForeColor = System.Drawing.Color.Black;
            this.LstPesoBruto.FormatString = "N2";
            this.LstPesoBruto.FormattingEnabled = true;
            this.LstPesoBruto.ItemHeight = 21;
            this.LstPesoBruto.Location = new System.Drawing.Point(19, 33);
            this.LstPesoBruto.MultiColumn = true;
            this.LstPesoBruto.Name = "LstPesoBruto";
            this.LstPesoBruto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LstPesoBruto.Size = new System.Drawing.Size(367, 130);
            this.LstPesoBruto.TabIndex = 418;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Image = global::Halley.Presentacion.Properties.Resources.cerrar_16x16;
            this.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCerrar.Location = new System.Drawing.Point(409, 33);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(82, 25);
            this.BtnCerrar.TabIndex = 422;
            this.BtnCerrar.Text = "&Cerrar";
            this.BtnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 420;
            this.label1.Text = "Acumulado de peso bruto";
            // 
            // LblNeto
            // 
            this.LblNeto.BackColor = System.Drawing.Color.White;
            this.LblNeto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblNeto.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNeto.ForeColor = System.Drawing.Color.SteelBlue;
            this.LblNeto.Location = new System.Drawing.Point(284, 205);
            this.LblNeto.Name = "LblNeto";
            this.LblNeto.Size = new System.Drawing.Size(105, 33);
            this.LblNeto.TabIndex = 423;
            this.LblNeto.Text = "0.00";
            this.LblNeto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblBruto
            // 
            this.LblBruto.BackColor = System.Drawing.Color.White;
            this.LblBruto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblBruto.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBruto.ForeColor = System.Drawing.Color.SteelBlue;
            this.LblBruto.Location = new System.Drawing.Point(284, 242);
            this.LblBruto.Name = "LblBruto";
            this.LblBruto.Size = new System.Drawing.Size(105, 33);
            this.LblBruto.TabIndex = 424;
            this.LblBruto.Text = "0.00";
            this.LblBruto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FrmPesos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 293);
            this.Controls.Add(this.LblBruto);
            this.Controls.Add(this.LblNeto);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LstPesoBruto);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.TxtTara);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.BtnBalanza);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.BtnRegistrar);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPesos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pesado de mercaderia";
            this.Load += new System.EventHandler(this.FrmPesos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtTara)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1Button btnLimpiar;
        private C1.Win.C1Input.C1Button BtnRegistrar;
        private C1.Win.C1Input.C1Button BtnBalanza;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private C1.Win.C1Input.C1TextBox TxtTara;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ListBox LstPesoBruto;
        private C1.Win.C1Input.C1Button BtnCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblNeto;
        private System.Windows.Forms.Label LblBruto;

    }
}