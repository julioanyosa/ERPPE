namespace Halley.Presentacion.Almacen.Contabilidad
{
    partial class FrmOperacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOperacion));
            this.TxtDescripcion = new C1.Win.C1Input.C1TextBox();
            this.TxtOperacionID = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnNuevo = new C1.Win.C1Input.C1Button();
            this.BtnGuardar = new C1.Win.C1Input.C1Button();
            this.BtnEditar = new C1.Win.C1Input.C1Button();
            this.BtnCancelar = new C1.Win.C1Input.C1Button();
            this.BtnEliminar = new C1.Win.C1Input.C1Button();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblEstado = new System.Windows.Forms.Label();
            this.BtnCerrar = new C1.Win.C1Input.C1Button();
            this.TdgMovimientos = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOperacionID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgMovimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.BackColor = System.Drawing.Color.White;
            this.TxtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDescripcion.Location = new System.Drawing.Point(105, 45);
            this.TxtDescripcion.MaxLength = 150;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(294, 20);
            this.TxtDescripcion.TabIndex = 224;
            this.TxtDescripcion.Tag = null;
            this.TxtDescripcion.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtDescripcion.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // TxtOperacionID
            // 
            this.TxtOperacionID.BackColor = System.Drawing.Color.White;
            this.TxtOperacionID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtOperacionID.Location = new System.Drawing.Point(105, 17);
            this.TxtOperacionID.MaxLength = 2;
            this.TxtOperacionID.Name = "TxtOperacionID";
            this.TxtOperacionID.Size = new System.Drawing.Size(64, 20);
            this.TxtOperacionID.TabIndex = 223;
            this.TxtOperacionID.Tag = null;
            this.TxtOperacionID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtOperacionID.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtOperacionID.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.TxtOperacionID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtOperacionID_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 222;
            this.label1.Text = "Descripción:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 221;
            this.label4.Text = "Codigo:";
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Image = global::Halley.Presentacion.Properties.Resources.newdocument_16x16;
            this.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNuevo.Location = new System.Drawing.Point(459, 128);
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
            this.BtnGuardar.Location = new System.Drawing.Point(459, 221);
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
            this.BtnEditar.Location = new System.Drawing.Point(459, 190);
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
            this.BtnCancelar.Location = new System.Drawing.Point(459, 159);
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
            this.BtnEliminar.Location = new System.Drawing.Point(459, 252);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(82, 23);
            this.BtnEliminar.TabIndex = 216;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEstado.Location = new System.Drawing.Point(102, 88);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(12, 13);
            this.lblEstado.TabIndex = 226;
            this.lblEstado.Text = "*";
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCerrar.Image = global::Halley.Presentacion.Properties.Resources.cerrar_16x16;
            this.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCerrar.Location = new System.Drawing.Point(459, 12);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(82, 23);
            this.BtnCerrar.TabIndex = 230;
            this.BtnCerrar.Text = "&Cerrar";
            this.BtnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            // 
            // TdgMovimientos
            // 
            this.TdgMovimientos.AllowUpdate = false;
            this.TdgMovimientos.AlternatingRows = true;
            this.TdgMovimientos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TdgMovimientos.CaptionHeight = 17;
            this.TdgMovimientos.EmptyRows = true;
            this.TdgMovimientos.FilterBar = true;
            this.TdgMovimientos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TdgMovimientos.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgMovimientos.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgMovimientos.Images"))));
            this.TdgMovimientos.LinesPerRow = 2;
            this.TdgMovimientos.Location = new System.Drawing.Point(11, 107);
            this.TdgMovimientos.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightCell;
            this.TdgMovimientos.Name = "TdgMovimientos";
            this.TdgMovimientos.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgMovimientos.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgMovimientos.PreviewInfo.ZoomFactor = 75D;
            this.TdgMovimientos.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgMovimientos.PrintInfo.PageSettings")));
            this.TdgMovimientos.RowHeight = 15;
            this.TdgMovimientos.Size = new System.Drawing.Size(388, 168);
            this.TdgMovimientos.TabIndex = 231;
            this.TdgMovimientos.Text = "c1TrueDBGrid1";
            this.TdgMovimientos.DoubleClick += new System.EventHandler(this.TdgMovimientos_DoubleClick);
            this.TdgMovimientos.PropBag = resources.GetString("TdgMovimientos.PropBag");
            // 
            // FrmOperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCerrar;
            this.ClientSize = new System.Drawing.Size(546, 287);
            this.Controls.Add(this.TdgMovimientos);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.TxtDescripcion);
            this.Controls.Add(this.TxtOperacionID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnEditar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnEliminar);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmOperacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mantenimiento de Operaciones";
            this.Load += new System.EventHandler(this.FrmUnidadMedidacs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOperacionID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgMovimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1TextBox TxtDescripcion;
        private C1.Win.C1Input.C1TextBox TxtOperacionID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1Button BtnNuevo;
        private C1.Win.C1Input.C1Button BtnGuardar;
        private C1.Win.C1Input.C1Button BtnEditar;
        private C1.Win.C1Input.C1Button BtnCancelar;
        private C1.Win.C1Input.C1Button BtnEliminar;
        private System.Windows.Forms.ErrorProvider ErrProvider;
        private System.Windows.Forms.Label lblEstado;
        private C1.Win.C1Input.C1Button BtnCerrar;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgMovimientos;
    }
}