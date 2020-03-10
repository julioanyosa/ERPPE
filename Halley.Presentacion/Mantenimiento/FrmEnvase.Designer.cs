namespace Halley.Presentacion.Mantenimiento
{
    partial class FrmEnvase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEnvase));
            this.TxtNomEnvase = new C1.Win.C1Input.C1TextBox();
            this.TxtEnvaseID = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnNuevo = new C1.Win.C1Input.C1Button();
            this.BtnGuardar = new C1.Win.C1Input.C1Button();
            this.BtnEditar = new C1.Win.C1Input.C1Button();
            this.BtnCancelar = new C1.Win.C1Input.C1Button();
            this.BtnEliminar = new C1.Win.C1Input.C1Button();
            this.TdgEnvase = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblEstado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNomEnvase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEnvaseID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgEnvase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtNomEnvase
            // 
            this.TxtNomEnvase.BackColor = System.Drawing.Color.White;
            this.TxtNomEnvase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNomEnvase.Location = new System.Drawing.Point(105, 45);
            this.TxtNomEnvase.MaxLength = 20;
            this.TxtNomEnvase.Name = "TxtNomEnvase";
            this.TxtNomEnvase.Size = new System.Drawing.Size(207, 18);
            this.TxtNomEnvase.TabIndex = 224;
            this.TxtNomEnvase.Tag = null;
            this.TxtNomEnvase.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtNomEnvase.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            // 
            // TxtEnvaseID
            // 
            this.TxtEnvaseID.BackColor = System.Drawing.Color.White;
            this.TxtEnvaseID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtEnvaseID.Location = new System.Drawing.Point(105, 17);
            this.TxtEnvaseID.MaxLength = 2;
            this.TxtEnvaseID.Name = "TxtEnvaseID";
            this.TxtEnvaseID.Size = new System.Drawing.Size(32, 18);
            this.TxtEnvaseID.TabIndex = 223;
            this.TxtEnvaseID.Tag = null;
            this.TxtEnvaseID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtEnvaseID.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            this.TxtEnvaseID.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
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
            // TdgEnvase
            // 
            this.TdgEnvase.AllowUpdate = false;
            this.TdgEnvase.CaptionHeight = 17;
            this.TdgEnvase.EmptyRows = true;
            this.TdgEnvase.FilterBar = true;
            this.TdgEnvase.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgEnvase.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgEnvase.Images"))));
            this.TdgEnvase.Location = new System.Drawing.Point(36, 86);
            this.TdgEnvase.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgEnvase.Name = "TdgEnvase";
            this.TdgEnvase.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgEnvase.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgEnvase.PreviewInfo.ZoomFactor = 75D;
            this.TdgEnvase.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgEnvase.PrintInfo.PageSettings")));
            this.TdgEnvase.RowHeight = 18;
            this.TdgEnvase.Size = new System.Drawing.Size(380, 134);
            this.TdgEnvase.TabIndex = 225;
            this.TdgEnvase.Text = "c1TrueDBGrid1";
            this.TdgEnvase.DoubleClick += new System.EventHandler(this.TdgUnidadMedida_DoubleClick);
            this.TdgEnvase.PropBag = resources.GetString("TdgEnvase.PropBag");
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
            // FrmEnvase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 262);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.TdgEnvase);
            this.Controls.Add(this.TxtNomEnvase);
            this.Controls.Add(this.TxtEnvaseID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnEditar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnEliminar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmEnvase";
            this.Text = "Mantenimiento de Envases";
            this.Load += new System.EventHandler(this.FrmUnidadMedidacs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtNomEnvase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtEnvaseID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgEnvase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Input.C1TextBox TxtNomEnvase;
        private C1.Win.C1Input.C1TextBox TxtEnvaseID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1Button BtnNuevo;
        private C1.Win.C1Input.C1Button BtnGuardar;
        private C1.Win.C1Input.C1Button BtnEditar;
        private C1.Win.C1Input.C1Button BtnCancelar;
        private C1.Win.C1Input.C1Button BtnEliminar;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgEnvase;
        private System.Windows.Forms.ErrorProvider ErrProvider;
        private System.Windows.Forms.Label lblEstado;
    }
}