namespace Halley.Presentacion.Ventas
{
    partial class FrmReserva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReserva));
            this.TdgReservas = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtTotalReservado = new C1.Win.C1Input.C1TextBox();
            this.BtnCancelar = new C1.Win.C1Input.C1Button();
            this.LbAlias = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DeFechaReserva = new C1.Win.C1Input.C1DateEdit();
            this.BtnReservar = new C1.Win.C1Input.C1Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtCantidadReservar = new C1.Win.C1Input.C1TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TdgReservas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotalReservado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeFechaReserva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCantidadReservar)).BeginInit();
            this.SuspendLayout();
            // 
            // TdgReservas
            // 
            this.TdgReservas.AllowUpdate = false;
            this.TdgReservas.CaptionHeight = 17;
            this.TdgReservas.EmptyRows = true;
            this.TdgReservas.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgReservas.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgReservas.Images"))));
            this.TdgReservas.Location = new System.Drawing.Point(13, 9);
            this.TdgReservas.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgReservas.Name = "TdgReservas";
            this.TdgReservas.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgReservas.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgReservas.PreviewInfo.ZoomFactor = 75D;
            this.TdgReservas.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgReservas.PrintInfo.PageSettings")));
            this.TdgReservas.RowHeight = 18;
            this.TdgReservas.Size = new System.Drawing.Size(675, 117);
            this.TdgReservas.TabIndex = 395;
            this.TdgReservas.Text = "c1TrueDBGrid1";
            this.TdgReservas.PropBag = resources.GetString("TdgReservas.PropBag");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(469, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 408;
            this.label8.Text = "Total reservado:";
            // 
            // TxtTotalReservado
            // 
            this.TxtTotalReservado.Location = new System.Drawing.Point(563, 132);
            this.TxtTotalReservado.Name = "TxtTotalReservado";
            this.TxtTotalReservado.Size = new System.Drawing.Size(125, 22);
            this.TxtTotalReservado.TabIndex = 407;
            this.TxtTotalReservado.Tag = null;
            this.TxtTotalReservado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Image = global::Halley.Presentacion.Properties.Resources.Cancelar_16x16;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(606, 220);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(82, 23);
            this.BtnCancelar.TabIndex = 410;
            this.BtnCancelar.Text = "&Cerrar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // LbAlias
            // 
            this.LbAlias.AutoSize = true;
            this.LbAlias.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbAlias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LbAlias.Location = new System.Drawing.Point(12, 133);
            this.LbAlias.Name = "LbAlias";
            this.LbAlias.Size = new System.Drawing.Size(175, 21);
            this.LbAlias.TabIndex = 411;
            this.LbAlias.Text = "Nombre del producto";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(459, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 413;
            this.label7.Text = "Fecha de Reserva:";
            // 
            // DeFechaReserva
            // 
            this.DeFechaReserva.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.DeFechaReserva.Location = new System.Drawing.Point(563, 160);
            this.DeFechaReserva.Name = "DeFechaReserva";
            this.DeFechaReserva.Size = new System.Drawing.Size(125, 22);
            this.DeFechaReserva.TabIndex = 412;
            this.DeFechaReserva.Tag = null;
            this.DeFechaReserva.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown;
            // 
            // BtnReservar
            // 
            this.BtnReservar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.BtnReservar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReservar.Location = new System.Drawing.Point(509, 220);
            this.BtnReservar.Name = "BtnReservar";
            this.BtnReservar.Size = new System.Drawing.Size(82, 23);
            this.BtnReservar.TabIndex = 414;
            this.BtnReservar.Text = "&Reservar";
            this.BtnReservar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnReservar.UseVisualStyleBackColor = true;
            this.BtnReservar.Click += new System.EventHandler(this.BtnReservar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(448, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 416;
            this.label1.Text = "Cantidad a reservar:";
            // 
            // TxtCantidadReservar
            // 
            this.TxtCantidadReservar.Location = new System.Drawing.Point(563, 190);
            this.TxtCantidadReservar.Name = "TxtCantidadReservar";
            this.TxtCantidadReservar.Size = new System.Drawing.Size(125, 22);
            this.TxtCantidadReservar.TabIndex = 415;
            this.TxtCantidadReservar.Tag = null;
            this.TxtCantidadReservar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtCantidadReservar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCantidadReservar_KeyPress);
            // 
            // FrmReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(700, 257);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtCantidadReservar);
            this.Controls.Add(this.BtnReservar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DeFechaReserva);
            this.Controls.Add(this.LbAlias);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtTotalReservado);
            this.Controls.Add(this.TdgReservas);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReserva";
            this.Text = "Reservas del producto";
            this.Load += new System.EventHandler(this.FrmReserva_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TdgReservas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTotalReservado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeFechaReserva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCantidadReservar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgReservas;
        private System.Windows.Forms.Label label8;
        private C1.Win.C1Input.C1TextBox TxtTotalReservado;
        private C1.Win.C1Input.C1Button BtnCancelar;
        private System.Windows.Forms.Label LbAlias;
        private System.Windows.Forms.Label label7;
        private C1.Win.C1Input.C1DateEdit DeFechaReserva;
        private C1.Win.C1Input.C1Button BtnReservar;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox TxtCantidadReservar;
    }
}