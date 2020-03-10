namespace Halley.Presentacion.Ventas
{
    partial class FrmAperturaCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAperturaCaja));
            this.TxtCantidad = new C1.Win.C1Input.C1TextBox();
            this.LblCantidad = new System.Windows.Forms.Label();
            this.BtnIngresar = new C1.Win.C1Input.C1Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.TcIngresos = new System.Windows.Forms.TabControl();
            this.TpApertura = new System.Windows.Forms.TabPage();
            this.TpAdelantos = new System.Windows.Forms.TabPage();
            this.BtnClientes = new C1.Win.C1Input.C1Button();
            this.BtnRegistrar = new C1.Win.C1Input.C1Button();
            this.LblCliente = new System.Windows.Forms.Label();
            this.LblNroDocumento = new System.Windows.Forms.Label();
            this.LblEmpresa = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtConcepto = new C1.Win.C1Input.C1TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtImporte = new C1.Win.C1Input.C1TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.TcIngresos.SuspendLayout();
            this.TpApertura.SuspendLayout();
            this.TpAdelantos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtConcepto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtImporte)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.Location = new System.Drawing.Point(109, 128);
            this.TxtCantidad.MaxLength = 17;
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(97, 22);
            this.TxtCantidad.TabIndex = 0;
            this.TxtCantidad.Tag = null;
            this.TxtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCantidad_KeyPress);
            // 
            // LblCantidad
            // 
            this.LblCantidad.AutoSize = true;
            this.LblCantidad.Location = new System.Drawing.Point(24, 131);
            this.LblCantidad.Name = "LblCantidad";
            this.LblCantidad.Size = new System.Drawing.Size(81, 13);
            this.LblCantidad.TabIndex = 362;
            this.LblCantidad.Text = "Aperturar con:";
            // 
            // BtnIngresar
            // 
            this.BtnIngresar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.BtnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnIngresar.Location = new System.Drawing.Point(238, 128);
            this.BtnIngresar.Name = "BtnIngresar";
            this.BtnIngresar.Size = new System.Drawing.Size(80, 25);
            this.BtnIngresar.TabIndex = 1;
            this.BtnIngresar.Text = "Aperturar";
            this.BtnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnIngresar.UseVisualStyleBackColor = true;
            this.BtnIngresar.Click += new System.EventHandler(this.BtnIngresar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 364;
            this.label1.Text = "Apertura de caja";
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // TcIngresos
            // 
            this.TcIngresos.Controls.Add(this.TpApertura);
            this.TcIngresos.Controls.Add(this.TpAdelantos);
            this.TcIngresos.Location = new System.Drawing.Point(1, 2);
            this.TcIngresos.Name = "TcIngresos";
            this.TcIngresos.SelectedIndex = 0;
            this.TcIngresos.Size = new System.Drawing.Size(348, 265);
            this.TcIngresos.TabIndex = 365;
            // 
            // TpApertura
            // 
            this.TpApertura.Controls.Add(this.label1);
            this.TpApertura.Controls.Add(this.BtnIngresar);
            this.TpApertura.Controls.Add(this.TxtCantidad);
            this.TpApertura.Controls.Add(this.LblCantidad);
            this.TpApertura.Location = new System.Drawing.Point(4, 22);
            this.TpApertura.Name = "TpApertura";
            this.TpApertura.Padding = new System.Windows.Forms.Padding(3);
            this.TpApertura.Size = new System.Drawing.Size(340, 239);
            this.TpApertura.TabIndex = 0;
            this.TpApertura.Text = "Apertura";
            this.TpApertura.UseVisualStyleBackColor = true;
            // 
            // TpAdelantos
            // 
            this.TpAdelantos.Controls.Add(this.BtnClientes);
            this.TpAdelantos.Controls.Add(this.BtnRegistrar);
            this.TpAdelantos.Controls.Add(this.LblCliente);
            this.TpAdelantos.Controls.Add(this.LblNroDocumento);
            this.TpAdelantos.Controls.Add(this.LblEmpresa);
            this.TpAdelantos.Controls.Add(this.label7);
            this.TpAdelantos.Controls.Add(this.TxtConcepto);
            this.TpAdelantos.Controls.Add(this.label2);
            this.TpAdelantos.Controls.Add(this.TxtImporte);
            this.TpAdelantos.Controls.Add(this.label3);
            this.TpAdelantos.Location = new System.Drawing.Point(4, 22);
            this.TpAdelantos.Name = "TpAdelantos";
            this.TpAdelantos.Padding = new System.Windows.Forms.Padding(3);
            this.TpAdelantos.Size = new System.Drawing.Size(340, 239);
            this.TpAdelantos.TabIndex = 1;
            this.TpAdelantos.Text = "Adelantos";
            this.TpAdelantos.UseVisualStyleBackColor = true;
            // 
            // BtnClientes
            // 
            this.BtnClientes.Image = global::Halley.Presentacion.Properties.Resources.Admin_Users16x16;
            this.BtnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnClientes.Location = new System.Drawing.Point(145, 12);
            this.BtnClientes.Name = "BtnClientes";
            this.BtnClientes.Size = new System.Drawing.Size(80, 25);
            this.BtnClientes.TabIndex = 416;
            this.BtnClientes.Text = "Clientes";
            this.BtnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClientes.UseVisualStyleBackColor = true;
            this.BtnClientes.Click += new System.EventHandler(this.BtnClientes_Click);
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Image = global::Halley.Presentacion.Properties.Resources.Adelantos16x16;
            this.BtnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRegistrar.Location = new System.Drawing.Point(241, 12);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(80, 25);
            this.BtnRegistrar.TabIndex = 415;
            this.BtnRegistrar.Text = "Registrar";
            this.BtnRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // LblCliente
            // 
            this.LblCliente.AutoSize = true;
            this.LblCliente.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCliente.Location = new System.Drawing.Point(7, 94);
            this.LblCliente.Name = "LblCliente";
            this.LblCliente.Size = new System.Drawing.Size(71, 13);
            this.LblCliente.TabIndex = 414;
            this.LblCliente.Text = "Razon social";
            // 
            // LblNroDocumento
            // 
            this.LblNroDocumento.AutoSize = true;
            this.LblNroDocumento.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNroDocumento.Location = new System.Drawing.Point(7, 74);
            this.LblNroDocumento.Name = "LblNroDocumento";
            this.LblNroDocumento.Size = new System.Drawing.Size(88, 13);
            this.LblNroDocumento.TabIndex = 413;
            this.LblNroDocumento.Text = "NroDocumento";
            // 
            // LblEmpresa
            // 
            this.LblEmpresa.AutoSize = true;
            this.LblEmpresa.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEmpresa.ForeColor = System.Drawing.Color.SteelBlue;
            this.LblEmpresa.Location = new System.Drawing.Point(7, 42);
            this.LblEmpresa.Name = "LblEmpresa";
            this.LblEmpresa.Size = new System.Drawing.Size(69, 20);
            this.LblEmpresa.TabIndex = 412;
            this.LblEmpresa.Text = "Empresa";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 408;
            this.label7.Text = "Concepto:";
            // 
            // TxtConcepto
            // 
            this.TxtConcepto.Location = new System.Drawing.Point(3, 173);
            this.TxtConcepto.MaxLength = 200;
            this.TxtConcepto.Multiline = true;
            this.TxtConcepto.Name = "TxtConcepto";
            this.TxtConcepto.Size = new System.Drawing.Size(318, 63);
            this.TxtConcepto.TabIndex = 407;
            this.TxtConcepto.Tag = null;
            this.TxtConcepto.Value = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 367;
            this.label2.Text = "Adelantos";
            // 
            // TxtImporte
            // 
            this.TxtImporte.Location = new System.Drawing.Point(74, 124);
            this.TxtImporte.MaxLength = 17;
            this.TxtImporte.Name = "TxtImporte";
            this.TxtImporte.Size = new System.Drawing.Size(97, 22);
            this.TxtImporte.TabIndex = 365;
            this.TxtImporte.Tag = null;
            this.TxtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtImporte_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 366;
            this.label3.Text = "Importe:";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // FrmAperturaCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 271);
            this.Controls.Add(this.TcIngresos);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmAperturaCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ingresos";
            this.Load += new System.EventHandler(this.FrmAperturaCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.TcIngresos.ResumeLayout(false);
            this.TpApertura.ResumeLayout(false);
            this.TpApertura.PerformLayout();
            this.TpAdelantos.ResumeLayout(false);
            this.TpAdelantos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtConcepto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtImporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1Input.C1TextBox TxtCantidad;
        private System.Windows.Forms.Label LblCantidad;
        private C1.Win.C1Input.C1Button BtnIngresar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider ErrProvider;
        private System.Windows.Forms.TabControl TcIngresos;
        private System.Windows.Forms.TabPage TpApertura;
        private System.Windows.Forms.TabPage TpAdelantos;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1TextBox TxtImporte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private C1.Win.C1Input.C1TextBox TxtConcepto;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label LblEmpresa;
        private C1.Win.C1Input.C1Button BtnRegistrar;
        private System.Windows.Forms.Label LblCliente;
        private System.Windows.Forms.Label LblNroDocumento;
        private C1.Win.C1Input.C1Button BtnClientes;
    }
}