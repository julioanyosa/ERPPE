namespace Halley.Galpon
{
    partial class Balanza
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
            this.TxtPeso = new C1.Win.C1Input.C1TextBox();
            this.LblCantidad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCancelar = new C1.Win.C1Input.C1Button();
            this.BtnCargar = new C1.Win.C1Input.C1Button();
            this.TxtCantidad = new C1.Win.C1Input.C1TextBox();
            this.LblPeso = new System.Windows.Forms.Label();
            this.SpBalanza = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TxtPeso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtPeso
            // 
            this.TxtPeso.BackColor = System.Drawing.Color.White;
            this.TxtPeso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPeso.Location = new System.Drawing.Point(26, 82);
            this.TxtPeso.MaxLength = 20;
            this.TxtPeso.Name = "TxtPeso";
            this.TxtPeso.Size = new System.Drawing.Size(297, 78);
            this.TxtPeso.TabIndex = 69;
            this.TxtPeso.Tag = null;
            this.TxtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtPeso.Value = "0";
            this.TxtPeso.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtPeso.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.TxtPeso.TextChanged += new System.EventHandler(this.TxtPeso_TextChanged);
            this.TxtPeso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPeso_KeyPress);
            // 
            // LblCantidad
            // 
            this.LblCantidad.AutoSize = true;
            this.LblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCantidad.ForeColor = System.Drawing.Color.DimGray;
            this.LblCantidad.Location = new System.Drawing.Point(324, 54);
            this.LblCantidad.Name = "LblCantidad";
            this.LblCantidad.Size = new System.Drawing.Size(106, 25);
            this.LblCantidad.TabIndex = 70;
            this.LblCantidad.Text = "Cantidad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(21, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 25);
            this.label1.TabIndex = 71;
            this.label1.Text = "Peso";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Image = global::Halley.Galpon.Properties.Resources.Cancel_32x32;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(196, 166);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(127, 52);
            this.BtnCancelar.TabIndex = 72;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnCargar
            // 
            this.BtnCargar.Image = global::Halley.Galpon.Properties.Resources.Agregar32x32;
            this.BtnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCargar.Location = new System.Drawing.Point(486, 170);
            this.BtnCargar.Name = "BtnCargar";
            this.BtnCargar.Size = new System.Drawing.Size(127, 52);
            this.BtnCargar.TabIndex = 73;
            this.BtnCargar.Text = "Cargar";
            this.BtnCargar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCargar.UseVisualStyleBackColor = true;
            this.BtnCargar.Click += new System.EventHandler(this.BtnCargar_Click);
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.BackColor = System.Drawing.Color.White;
            this.TxtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCantidad.Location = new System.Drawing.Point(329, 82);
            this.TxtCantidad.MaxLength = 20;
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(284, 78);
            this.TxtCantidad.TabIndex = 74;
            this.TxtCantidad.Tag = null;
            this.TxtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtCantidad.Value = "0";
            this.TxtCantidad.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtCantidad.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.TxtCantidad.TextChanged += new System.EventHandler(this.TxtCantidad_TextChanged);
            this.TxtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCantidad_KeyPress);
            // 
            // LblPeso
            // 
            this.LblPeso.AutoSize = true;
            this.LblPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPeso.ForeColor = System.Drawing.Color.Red;
            this.LblPeso.Location = new System.Drawing.Point(12, 9);
            this.LblPeso.Name = "LblPeso";
            this.LblPeso.Size = new System.Drawing.Size(235, 25);
            this.LblPeso.TabIndex = 75;
            this.LblPeso.Text = "Pesado de productos";
            // 
            // SpBalanza
            // 
            this.SpBalanza.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SpBalanza_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Balanza
            // 
            this.AcceptButton = this.BtnCargar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(629, 234);
            this.Controls.Add(this.LblPeso);
            this.Controls.Add(this.TxtCantidad);
            this.Controls.Add(this.BtnCargar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblCantidad);
            this.Controls.Add(this.TxtPeso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Balanza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Balanza";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Balanza_FormClosing);
            this.Load += new System.EventHandler(this.Balanza_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtPeso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1TextBox TxtPeso;
        private System.Windows.Forms.Label LblCantidad;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1Button BtnCancelar;
        private C1.Win.C1Input.C1Button BtnCargar;
        private C1.Win.C1Input.C1TextBox TxtCantidad;
        private System.Windows.Forms.Label LblPeso;
        private System.IO.Ports.SerialPort SpBalanza;
        private System.Windows.Forms.Timer timer1;
    }
}