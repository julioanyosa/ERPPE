namespace Halley.Galpon
{
    partial class ListGalpon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListGalpon));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOk = new C1.Win.C1Input.C1Button();
            this.BtnBalanza = new C1.Win.C1Input.C1Button();
            this.RbPeso = new System.Windows.Forms.RadioButton();
            this.RbTara = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGalponero = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNeto = new System.Windows.Forms.TextBox();
            this.txtTara = new System.Windows.Forms.TextBox();
            this.txtBruto = new System.Windows.Forms.TextBox();
            this.txtNro = new System.Windows.Forms.TextBox();
            this.cbGalpon = new C1.Win.C1List.C1Combo();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblUsuario = new System.Windows.Forms.TextBox();
            this.c1Button1 = new C1.Win.C1Input.C1Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbGalpon)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Almacen :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pesador :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Galponero :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Nro Jabas :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Peso tara :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-1, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Peso Bruto :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Peso Neto :";
            // 
            // btnOk
            // 
            this.btnOk.Image = global::Halley.Galpon.Properties.Resources.exportExcel_16x16;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnOk.Location = new System.Drawing.Point(393, 99);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(69, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "&Exportar";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // BtnBalanza
            // 
            this.BtnBalanza.Image = global::Halley.Galpon.Properties.Resources.Pesa_48x48;
            this.BtnBalanza.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnBalanza.Location = new System.Drawing.Point(6, 56);
            this.BtnBalanza.Name = "BtnBalanza";
            this.BtnBalanza.Size = new System.Drawing.Size(82, 64);
            this.BtnBalanza.TabIndex = 2;
            this.BtnBalanza.Text = "Balanza";
            this.BtnBalanza.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBalanza.UseVisualStyleBackColor = true;
            this.BtnBalanza.Click += new System.EventHandler(this.BtnBalanza_Click);
            // 
            // RbPeso
            // 
            this.RbPeso.Appearance = System.Windows.Forms.Appearance.Button;
            this.RbPeso.AutoSize = true;
            this.RbPeso.BackColor = System.Drawing.Color.White;
            this.RbPeso.Image = global::Halley.Galpon.Properties.Resources.Peso_32x32;
            this.RbPeso.Location = new System.Drawing.Point(50, 12);
            this.RbPeso.Name = "RbPeso";
            this.RbPeso.Size = new System.Drawing.Size(38, 38);
            this.RbPeso.TabIndex = 1;
            this.RbPeso.UseVisualStyleBackColor = false;
            this.RbPeso.CheckedChanged += new System.EventHandler(this.RbPeso_CheckedChanged);
            // 
            // RbTara
            // 
            this.RbTara.Appearance = System.Windows.Forms.Appearance.Button;
            this.RbTara.AutoSize = true;
            this.RbTara.BackColor = System.Drawing.Color.Black;
            this.RbTara.Checked = true;
            this.RbTara.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.RbTara.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.RbTara.Image = global::Halley.Galpon.Properties.Resources.Tara_32x32;
            this.RbTara.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RbTara.Location = new System.Drawing.Point(6, 12);
            this.RbTara.Name = "RbTara";
            this.RbTara.Size = new System.Drawing.Size(38, 38);
            this.RbTara.TabIndex = 0;
            this.RbTara.TabStop = true;
            this.RbTara.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RbTara.UseVisualStyleBackColor = false;
            this.RbTara.CheckedChanged += new System.EventHandler(this.RbTara_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGalponero);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(289, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 76);
            this.groupBox1.TabIndex = 414;
            this.groupBox1.TabStop = false;
            // 
            // txtGalponero
            // 
            this.txtGalponero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGalponero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGalponero.Location = new System.Drawing.Point(72, 47);
            this.txtGalponero.Name = "txtGalponero";
            this.txtGalponero.Size = new System.Drawing.Size(176, 20);
            this.txtGalponero.TabIndex = 1;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsuario.Location = new System.Drawing.Point(72, 18);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(176, 20);
            this.txtUsuario.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNeto);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtTara);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtBruto);
            this.groupBox2.Controls.Add(this.txtNro);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 127);
            this.groupBox2.TabIndex = 415;
            this.groupBox2.TabStop = false;
            // 
            // txtNeto
            // 
            this.txtNeto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNeto.Enabled = false;
            this.txtNeto.Location = new System.Drawing.Point(70, 91);
            this.txtNeto.Name = "txtNeto";
            this.txtNeto.Size = new System.Drawing.Size(174, 20);
            this.txtNeto.TabIndex = 423;
            this.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTara
            // 
            this.txtTara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTara.Enabled = false;
            this.txtTara.Location = new System.Drawing.Point(70, 63);
            this.txtTara.Name = "txtTara";
            this.txtTara.Size = new System.Drawing.Size(174, 20);
            this.txtTara.TabIndex = 422;
            this.txtTara.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBruto
            // 
            this.txtBruto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBruto.Enabled = false;
            this.txtBruto.Location = new System.Drawing.Point(70, 38);
            this.txtBruto.Name = "txtBruto";
            this.txtBruto.Size = new System.Drawing.Size(174, 20);
            this.txtBruto.TabIndex = 421;
            this.txtBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNro
            // 
            this.txtNro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNro.Enabled = false;
            this.txtNro.Location = new System.Drawing.Point(70, 14);
            this.txtNro.Name = "txtNro";
            this.txtNro.Size = new System.Drawing.Size(174, 20);
            this.txtNro.TabIndex = 420;
            this.txtNro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbGalpon
            // 
            this.cbGalpon.AddItemSeparator = ';';
            this.cbGalpon.Caption = "";
            this.cbGalpon.CaptionHeight = 17;
            this.cbGalpon.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cbGalpon.ColumnCaptionHeight = 17;
            this.cbGalpon.ColumnFooterHeight = 17;
            this.cbGalpon.ColumnHeaders = false;
            this.cbGalpon.ColumnWidth = 100;
            this.cbGalpon.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cbGalpon.ContentHeight = 17;
            this.cbGalpon.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cbGalpon.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cbGalpon.EditorFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGalpon.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cbGalpon.EditorHeight = 17;
            this.cbGalpon.ExtendRightColumn = true;
            this.cbGalpon.Images.Add(((System.Drawing.Image)(resources.GetObject("cbGalpon.Images"))));
            this.cbGalpon.ItemHeight = 15;
            this.cbGalpon.Location = new System.Drawing.Point(63, 42);
            this.cbGalpon.MatchEntryTimeout = ((long)(2000));
            this.cbGalpon.MaxDropDownItems = ((short)(5));
            this.cbGalpon.MaxLength = 32767;
            this.cbGalpon.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cbGalpon.Name = "cbGalpon";
            this.cbGalpon.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.cbGalpon.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cbGalpon.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cbGalpon.Size = new System.Drawing.Size(181, 23);
            this.cbGalpon.TabIndex = 0;
            this.cbGalpon.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue;
            this.cbGalpon.PropBag = resources.GetString("cbGalpon.PropBag");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 417;
            this.label8.Text = "Usuario  :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblUsuario);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cbGalpon);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(269, 76);
            this.groupBox3.TabIndex = 419;
            this.groupBox3.TabStop = false;
            // 
            // lblUsuario
            // 
            this.lblUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUsuario.Enabled = false;
            this.lblUsuario.Location = new System.Drawing.Point(63, 16);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(181, 20);
            this.lblUsuario.TabIndex = 0;
            // 
            // c1Button1
            // 
            this.c1Button1.Image = global::Halley.Galpon.Properties.Resources.Cancelar_16x16;
            this.c1Button1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.c1Button1.Location = new System.Drawing.Point(481, 99);
            this.c1Button1.Name = "c1Button1";
            this.c1Button1.Size = new System.Drawing.Size(72, 23);
            this.c1Button1.TabIndex = 1;
            this.c1Button1.Text = "&Cancelar";
            this.c1Button1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.c1Button1.UseVisualStyleBackColor = true;
            this.c1Button1.Click += new System.EventHandler(this.c1Button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtnBalanza);
            this.groupBox4.Controls.Add(this.RbTara);
            this.groupBox4.Controls.Add(this.RbPeso);
            this.groupBox4.Location = new System.Drawing.Point(287, 94);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(100, 127);
            this.groupBox4.TabIndex = 421;
            this.groupBox4.TabStop = false;
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // ListGalpon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 232);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.c1Button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListGalpon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListGalpon_FormClosing);
            this.Load += new System.EventHandler(this.ListGalpon_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbGalpon)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private C1.Win.C1Input.C1Button btnOk;
        private C1.Win.C1Input.C1Button BtnBalanza;
        private System.Windows.Forms.RadioButton RbPeso;
        private System.Windows.Forms.RadioButton RbTara;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private C1.Win.C1List.C1Combo cbGalpon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtGalponero;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtNeto;
        private System.Windows.Forms.TextBox txtTara;
        private System.Windows.Forms.TextBox txtBruto;
        private System.Windows.Forms.TextBox txtNro;
        private System.Windows.Forms.TextBox lblUsuario;
        private C1.Win.C1Input.C1Button c1Button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ErrorProvider ErrProvider;
    }
}