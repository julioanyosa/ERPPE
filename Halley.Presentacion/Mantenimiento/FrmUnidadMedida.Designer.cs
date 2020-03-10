namespace Halley.Presentacion.Mantenimiento
{
    partial class FrmUnidadMedida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUnidadMedida));
            this.TxtNomUnidadMedida = new C1.Win.C1Input.C1TextBox();
            this.TxtUnidadMedidaID = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnNuevo = new C1.Win.C1Input.C1Button();
            this.BtnGuardar = new C1.Win.C1Input.C1Button();
            this.BtnEditar = new C1.Win.C1Input.C1Button();
            this.BtnCancelar = new C1.Win.C1Input.C1Button();
            this.BtnEliminar = new C1.Win.C1Input.C1Button();
            this.TdgUnidadMedida = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblEstado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNomUnidadMedida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUnidadMedidaID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgUnidadMedida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtNomUnidadMedida
            // 
            this.TxtNomUnidadMedida.BackColor = System.Drawing.Color.White;
            this.TxtNomUnidadMedida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNomUnidadMedida.Location = new System.Drawing.Point(105, 45);
            this.TxtNomUnidadMedida.MaxLength = 20;
            this.TxtNomUnidadMedida.Name = "TxtNomUnidadMedida";
            this.TxtNomUnidadMedida.Size = new System.Drawing.Size(207, 18);
            this.TxtNomUnidadMedida.TabIndex = 224;
            this.TxtNomUnidadMedida.Tag = null;
            this.TxtNomUnidadMedida.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtNomUnidadMedida.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // TxtUnidadMedidaID
            // 
            this.TxtUnidadMedidaID.BackColor = System.Drawing.Color.White;
            this.TxtUnidadMedidaID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUnidadMedidaID.Location = new System.Drawing.Point(105, 17);
            this.TxtUnidadMedidaID.MaxLength = 2;
            this.TxtUnidadMedidaID.Name = "TxtUnidadMedidaID";
            this.TxtUnidadMedidaID.Size = new System.Drawing.Size(32, 18);
            this.TxtUnidadMedidaID.TabIndex = 223;
            this.TxtUnidadMedidaID.Tag = null;
            this.TxtUnidadMedidaID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtUnidadMedidaID.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtUnidadMedidaID.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 222;
            this.label1.Text = "Descripción:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 221;
            this.label4.Text = "ID:";
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Image = global::Halley.Presentacion.Properties.Resources.newdocument_16x16;
            this.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNuevo.Location = new System.Drawing.Point(461, 73);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(82, 23);
            this.BtnNuevo.TabIndex = 220;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Image = global::Halley.Presentacion.Properties.Resources.save_16x16;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(461, 166);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(82, 23);
            this.BtnGuardar.TabIndex = 219;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.Image = global::Halley.Presentacion.Properties.Resources.edit_16x16;
            this.BtnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEditar.Location = new System.Drawing.Point(461, 135);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(82, 23);
            this.BtnEditar.TabIndex = 218;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEditar.UseVisualStyleBackColor = true;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Image = global::Halley.Presentacion.Properties.Resources.cancel_16x16;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(461, 104);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(82, 23);
            this.BtnCancelar.TabIndex = 217;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Image = global::Halley.Presentacion.Properties.Resources.delete_16x16;
            this.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEliminar.Location = new System.Drawing.Point(461, 197);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(82, 23);
            this.BtnEliminar.TabIndex = 216;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // TdgUnidadMedida
            // 
            this.TdgUnidadMedida.AllowUpdate = false;
            this.TdgUnidadMedida.CaptionHeight = 17;
            this.TdgUnidadMedida.EmptyRows = true;
            this.TdgUnidadMedida.FilterBar = true;
            this.TdgUnidadMedida.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgUnidadMedida.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgUnidadMedida.Images"))));
            this.TdgUnidadMedida.Location = new System.Drawing.Point(36, 86);
            this.TdgUnidadMedida.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgUnidadMedida.Name = "TdgUnidadMedida";
            this.TdgUnidadMedida.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgUnidadMedida.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgUnidadMedida.PreviewInfo.ZoomFactor = 75D;
            this.TdgUnidadMedida.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgUnidadMedida.PrintInfo.PageSettings")));
            this.TdgUnidadMedida.RowHeight = 18;
            this.TdgUnidadMedida.Size = new System.Drawing.Size(380, 134);
            this.TdgUnidadMedida.TabIndex = 225;
            this.TdgUnidadMedida.Text = "c1TrueDBGrid1";
            this.TdgUnidadMedida.DoubleClick += new System.EventHandler(this.TdgUnidadMedida_DoubleClick);
            this.TdgUnidadMedida.PropBag = resources.GetString("TdgUnidadMedida.PropBag");
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEstado.Location = new System.Drawing.Point(328, 50);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(11, 13);
            this.lblEstado.TabIndex = 226;
            this.lblEstado.Text = "*";
            // 
            // FrmUnidadMedida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 262);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.TdgUnidadMedida);
            this.Controls.Add(this.TxtNomUnidadMedida);
            this.Controls.Add(this.TxtUnidadMedidaID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnEditar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnEliminar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmUnidadMedida";
            this.Text = "Mantenimiento de Unidad de Medida";
            this.Load += new System.EventHandler(this.FrmUnidadMedidacs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtNomUnidadMedida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUnidadMedidaID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgUnidadMedida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1TextBox TxtNomUnidadMedida;
        private C1.Win.C1Input.C1TextBox TxtUnidadMedidaID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1Button BtnNuevo;
        private C1.Win.C1Input.C1Button BtnGuardar;
        private C1.Win.C1Input.C1Button BtnEditar;
        private C1.Win.C1Input.C1Button BtnCancelar;
        private C1.Win.C1Input.C1Button BtnEliminar;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgUnidadMedida;
        private System.Windows.Forms.ErrorProvider ErrProvider;
        private System.Windows.Forms.Label lblEstado;
    }
}