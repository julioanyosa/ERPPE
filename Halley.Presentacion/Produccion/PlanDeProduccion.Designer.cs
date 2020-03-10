namespace Halley.Presentacion.Produccion
{
    partial class PlanDeProduccion
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanDeProduccion));
            this.TcProduccion = new System.Windows.Forms.TabControl();
            this.TpMicroInsumos = new System.Windows.Forms.TabPage();
            this.TdgMicro = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.TpMacroInsumos = new System.Windows.Forms.TabPage();
            this.TdgMacro = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnQuitar = new C1.Win.C1Input.C1Button();
            this.BtnAgregar = new C1.Win.C1Input.C1Button();
            this.BtnNuevo = new C1.Win.C1Input.C1Button();
            this.BtnMostrarPlan = new C1.Win.C1Input.C1Button();
            this.BtnGrabar = new C1.Win.C1Input.C1Button();
            this.TdgFormuladosBatch = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.TdgProductosFormulados = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.TcOpciones = new System.Windows.Forms.TabControl();
            this.TpPlanActual = new System.Windows.Forms.TabPage();
            this.TpPlanHistorico = new System.Windows.Forms.TabPage();
            this.BtnProductoTerminado = new C1.Win.C1Input.C1Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LstHistorico = new System.Windows.Forms.ListBox();
            this.BtnQuitarHistorico = new C1.Win.C1Input.C1Button();
            this.TdgFormuladosHistorico = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.btnGenerar = new C1.Win.C1Input.C1Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboFechaFin = new C1.Win.C1Input.C1DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.cboFechaInicio = new C1.Win.C1Input.C1DateEdit();
            this.BtnExportarExcel = new C1.Win.C1Input.C1Button();
            this.TcProduccion.SuspendLayout();
            this.TpMicroInsumos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TdgMicro)).BeginInit();
            this.TpMacroInsumos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TdgMacro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgFormuladosBatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgProductosFormulados)).BeginInit();
            this.TcOpciones.SuspendLayout();
            this.TpPlanActual.SuspendLayout();
            this.TpPlanHistorico.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TdgFormuladosHistorico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaInicio)).BeginInit();
            this.SuspendLayout();
            // 
            // TcProduccion
            // 
            this.TcProduccion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TcProduccion.Controls.Add(this.TpMicroInsumos);
            this.TcProduccion.Controls.Add(this.TpMacroInsumos);
            this.TcProduccion.Location = new System.Drawing.Point(15, 216);
            this.TcProduccion.Name = "TcProduccion";
            this.TcProduccion.SelectedIndex = 0;
            this.TcProduccion.Size = new System.Drawing.Size(1094, 279);
            this.TcProduccion.TabIndex = 5;
            // 
            // TpMicroInsumos
            // 
            this.TpMicroInsumos.Controls.Add(this.TdgMicro);
            this.TpMicroInsumos.Location = new System.Drawing.Point(4, 22);
            this.TpMicroInsumos.Name = "TpMicroInsumos";
            this.TpMicroInsumos.Padding = new System.Windows.Forms.Padding(3);
            this.TpMicroInsumos.Size = new System.Drawing.Size(1086, 253);
            this.TpMicroInsumos.TabIndex = 0;
            this.TpMicroInsumos.Text = "MicroInsumos";
            this.TpMicroInsumos.UseVisualStyleBackColor = true;
            // 
            // TdgMicro
            // 
            this.TdgMicro.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TdgMicro.CaptionHeight = 17;
            this.TdgMicro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TdgMicro.EmptyRows = true;
            this.TdgMicro.FetchRowStyles = true;
            this.TdgMicro.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgMicro.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgMicro.Images"))));
            this.TdgMicro.Location = new System.Drawing.Point(3, 3);
            this.TdgMicro.Name = "TdgMicro";
            this.TdgMicro.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgMicro.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgMicro.PreviewInfo.ZoomFactor = 75D;
            this.TdgMicro.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgMicro.PrintInfo.PageSettings")));
            this.TdgMicro.RowHeight = 18;
            this.TdgMicro.Size = new System.Drawing.Size(1080, 247);
            this.TdgMicro.TabIndex = 8;
            this.TdgMicro.Text = "c1TrueDBGrid2";
            this.TdgMicro.FormatText += new C1.Win.C1TrueDBGrid.FormatTextEventHandler(this.TdgMicro_FormatText);
            this.TdgMicro.FetchRowStyle += new C1.Win.C1TrueDBGrid.FetchRowStyleEventHandler(this.TdgMicro_FetchRowStyle);
            this.TdgMicro.PropBag = resources.GetString("TdgMicro.PropBag");
            // 
            // TpMacroInsumos
            // 
            this.TpMacroInsumos.Controls.Add(this.TdgMacro);
            this.TpMacroInsumos.Location = new System.Drawing.Point(4, 22);
            this.TpMacroInsumos.Name = "TpMacroInsumos";
            this.TpMacroInsumos.Padding = new System.Windows.Forms.Padding(3);
            this.TpMacroInsumos.Size = new System.Drawing.Size(1086, 253);
            this.TpMacroInsumos.TabIndex = 1;
            this.TpMacroInsumos.Text = "MacroInsumos";
            this.TpMacroInsumos.UseVisualStyleBackColor = true;
            // 
            // TdgMacro
            // 
            this.TdgMacro.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TdgMacro.CaptionHeight = 17;
            this.TdgMacro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TdgMacro.EmptyRows = true;
            this.TdgMacro.FetchRowStyles = true;
            this.TdgMacro.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgMacro.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgMacro.Images"))));
            this.TdgMacro.Location = new System.Drawing.Point(3, 3);
            this.TdgMacro.Name = "TdgMacro";
            this.TdgMacro.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgMacro.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgMacro.PreviewInfo.ZoomFactor = 75D;
            this.TdgMacro.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgMacro.PrintInfo.PageSettings")));
            this.TdgMacro.RowHeight = 15;
            this.TdgMacro.Size = new System.Drawing.Size(1080, 273);
            this.TdgMacro.TabIndex = 9;
            this.TdgMacro.Text = "c1TrueDBGrid1";
            this.TdgMacro.FormatText += new C1.Win.C1TrueDBGrid.FormatTextEventHandler(this.TdgMacro_FormatText);
            this.TdgMacro.FetchRowStyle += new C1.Win.C1TrueDBGrid.FetchRowStyleEventHandler(this.TdgMacro_FetchRowStyle);
            this.TdgMacro.PropBag = resources.GetString("TdgMacro.PropBag");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(382, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 21);
            this.label1.TabIndex = 356;
            this.label1.Text = "Plan de Producción";
            // 
            // BtnQuitar
            // 
            this.BtnQuitar.Image = global::Halley.Presentacion.Properties.Resources.previous_16x16;
            this.BtnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnQuitar.Location = new System.Drawing.Point(431, 102);
            this.BtnQuitar.Name = "BtnQuitar";
            this.BtnQuitar.Size = new System.Drawing.Size(82, 23);
            this.BtnQuitar.TabIndex = 358;
            this.BtnQuitar.Text = "Quitar";
            this.BtnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnQuitar.UseVisualStyleBackColor = true;
            this.BtnQuitar.Click += new System.EventHandler(this.BtnQuitar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Image = global::Halley.Presentacion.Properties.Resources.next_16x16;
            this.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgregar.Location = new System.Drawing.Point(430, 43);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(82, 23);
            this.BtnAgregar.TabIndex = 357;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Image = global::Halley.Presentacion.Properties.Resources.newdocument_16x16;
            this.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNuevo.Location = new System.Drawing.Point(1023, 16);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(82, 23);
            this.BtnNuevo.TabIndex = 355;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnMostrarPlan
            // 
            this.BtnMostrarPlan.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.BtnMostrarPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMostrarPlan.Location = new System.Drawing.Point(872, 3);
            this.BtnMostrarPlan.Name = "BtnMostrarPlan";
            this.BtnMostrarPlan.Size = new System.Drawing.Size(82, 23);
            this.BtnMostrarPlan.TabIndex = 354;
            this.BtnMostrarPlan.Text = "Ver plan";
            this.BtnMostrarPlan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnMostrarPlan.UseVisualStyleBackColor = true;
            this.BtnMostrarPlan.Click += new System.EventHandler(this.BtnMostrarPlan_Click);
            // 
            // BtnGrabar
            // 
            this.BtnGrabar.Image = global::Halley.Presentacion.Properties.Resources.green;
            this.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGrabar.Location = new System.Drawing.Point(1023, 45);
            this.BtnGrabar.Name = "BtnGrabar";
            this.BtnGrabar.Size = new System.Drawing.Size(82, 23);
            this.BtnGrabar.TabIndex = 353;
            this.BtnGrabar.Text = "Producir";
            this.BtnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGrabar.UseVisualStyleBackColor = true;
            this.BtnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // TdgFormuladosBatch
            // 
            this.TdgFormuladosBatch.CaptionHeight = 17;
            this.TdgFormuladosBatch.EmptyRows = true;
            this.TdgFormuladosBatch.FilterBar = true;
            this.TdgFormuladosBatch.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgFormuladosBatch.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgFormuladosBatch.Images"))));
            this.TdgFormuladosBatch.Location = new System.Drawing.Point(542, 15);
            this.TdgFormuladosBatch.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgFormuladosBatch.Name = "TdgFormuladosBatch";
            this.TdgFormuladosBatch.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgFormuladosBatch.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgFormuladosBatch.PreviewInfo.ZoomFactor = 75D;
            this.TdgFormuladosBatch.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgFormuladosBatch.PrintInfo.PageSettings")));
            this.TdgFormuladosBatch.RowHeight = 18;
            this.TdgFormuladosBatch.Size = new System.Drawing.Size(380, 134);
            this.TdgFormuladosBatch.TabIndex = 7;
            this.TdgFormuladosBatch.Text = "c1TrueDBGrid1";
            this.TdgFormuladosBatch.DoubleClick += new System.EventHandler(this.TdgFormuladosBatch_DoubleClick);
            this.TdgFormuladosBatch.PropBag = resources.GetString("TdgFormuladosBatch.PropBag");
            // 
            // TdgProductosFormulados
            // 
            this.TdgProductosFormulados.AllowUpdate = false;
            this.TdgProductosFormulados.CaptionHeight = 17;
            this.TdgProductosFormulados.EmptyRows = true;
            this.TdgProductosFormulados.FilterBar = true;
            this.TdgProductosFormulados.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgProductosFormulados.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgProductosFormulados.Images"))));
            this.TdgProductosFormulados.Location = new System.Drawing.Point(17, 15);
            this.TdgProductosFormulados.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgProductosFormulados.Name = "TdgProductosFormulados";
            this.TdgProductosFormulados.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgProductosFormulados.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgProductosFormulados.PreviewInfo.ZoomFactor = 75D;
            this.TdgProductosFormulados.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgProductosFormulados.PrintInfo.PageSettings")));
            this.TdgProductosFormulados.RowHeight = 18;
            this.TdgProductosFormulados.Size = new System.Drawing.Size(391, 134);
            this.TdgProductosFormulados.TabIndex = 7;
            this.TdgProductosFormulados.Text = "c1TrueDBGrid1";
            this.TdgProductosFormulados.PropBag = resources.GetString("TdgProductosFormulados.PropBag");
            // 
            // TcOpciones
            // 
            this.TcOpciones.Controls.Add(this.TpPlanActual);
            this.TcOpciones.Controls.Add(this.TpPlanHistorico);
            this.TcOpciones.Location = new System.Drawing.Point(15, 29);
            this.TcOpciones.Name = "TcOpciones";
            this.TcOpciones.SelectedIndex = 0;
            this.TcOpciones.Size = new System.Drawing.Size(950, 181);
            this.TcOpciones.TabIndex = 361;
            this.TcOpciones.SelectedIndexChanged += new System.EventHandler(this.TcOpciones_SelectedIndexChanged);
            // 
            // TpPlanActual
            // 
            this.TpPlanActual.Controls.Add(this.TdgProductosFormulados);
            this.TpPlanActual.Controls.Add(this.TdgFormuladosBatch);
            this.TpPlanActual.Controls.Add(this.BtnAgregar);
            this.TpPlanActual.Controls.Add(this.BtnQuitar);
            this.TpPlanActual.Location = new System.Drawing.Point(4, 22);
            this.TpPlanActual.Name = "TpPlanActual";
            this.TpPlanActual.Padding = new System.Windows.Forms.Padding(3);
            this.TpPlanActual.Size = new System.Drawing.Size(942, 155);
            this.TpPlanActual.TabIndex = 0;
            this.TpPlanActual.Text = "Plan Actual";
            this.TpPlanActual.UseVisualStyleBackColor = true;
            // 
            // TpPlanHistorico
            // 
            this.TpPlanHistorico.Controls.Add(this.BtnProductoTerminado);
            this.TpPlanHistorico.Controls.Add(this.groupBox1);
            this.TpPlanHistorico.Controls.Add(this.BtnQuitarHistorico);
            this.TpPlanHistorico.Controls.Add(this.TdgFormuladosHistorico);
            this.TpPlanHistorico.Controls.Add(this.btnGenerar);
            this.TpPlanHistorico.Controls.Add(this.label2);
            this.TpPlanHistorico.Controls.Add(this.cboFechaFin);
            this.TpPlanHistorico.Controls.Add(this.label3);
            this.TpPlanHistorico.Controls.Add(this.cboFechaInicio);
            this.TpPlanHistorico.Location = new System.Drawing.Point(4, 22);
            this.TpPlanHistorico.Name = "TpPlanHistorico";
            this.TpPlanHistorico.Padding = new System.Windows.Forms.Padding(3);
            this.TpPlanHistorico.Size = new System.Drawing.Size(942, 155);
            this.TpPlanHistorico.TabIndex = 1;
            this.TpPlanHistorico.Text = "Plan Historico";
            this.TpPlanHistorico.UseVisualStyleBackColor = true;
            // 
            // BtnProductoTerminado
            // 
            this.BtnProductoTerminado.Image = global::Halley.Presentacion.Properties.Resources.Validar_16x16;
            this.BtnProductoTerminado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnProductoTerminado.Location = new System.Drawing.Point(853, 6);
            this.BtnProductoTerminado.Name = "BtnProductoTerminado";
            this.BtnProductoTerminado.Size = new System.Drawing.Size(82, 23);
            this.BtnProductoTerminado.TabIndex = 363;
            this.BtnProductoTerminado.Text = "Terminado";
            this.BtnProductoTerminado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnProductoTerminado.UseVisualStyleBackColor = true;
            this.BtnProductoTerminado.Click += new System.EventHandler(this.BtnProductoTerminado_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LstHistorico);
            this.groupBox1.Location = new System.Drawing.Point(203, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 143);
            this.groupBox1.TabIndex = 361;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Historico de produccion :";
            // 
            // LstHistorico
            // 
            this.LstHistorico.DisplayMember = "AudCrea";
            this.LstHistorico.FormattingEnabled = true;
            this.LstHistorico.Location = new System.Drawing.Point(11, 16);
            this.LstHistorico.Name = "LstHistorico";
            this.LstHistorico.Size = new System.Drawing.Size(201, 121);
            this.LstHistorico.TabIndex = 250;
            this.LstHistorico.ValueMember = "MateriaPrimaHistoricoID";
            this.LstHistorico.DoubleClick += new System.EventHandler(this.LstHistorico_DoubleClick);
            // 
            // BtnQuitarHistorico
            // 
            this.BtnQuitarHistorico.Image = global::Halley.Presentacion.Properties.Resources.delete_16x16;
            this.BtnQuitarHistorico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnQuitarHistorico.Location = new System.Drawing.Point(765, 6);
            this.BtnQuitarHistorico.Name = "BtnQuitarHistorico";
            this.BtnQuitarHistorico.Size = new System.Drawing.Size(82, 23);
            this.BtnQuitarHistorico.TabIndex = 359;
            this.BtnQuitarHistorico.Text = "Quitar";
            this.BtnQuitarHistorico.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnQuitarHistorico.UseVisualStyleBackColor = true;
            this.BtnQuitarHistorico.Click += new System.EventHandler(this.BtnQuitarHistorico_Click);
            // 
            // TdgFormuladosHistorico
            // 
            this.TdgFormuladosHistorico.CaptionHeight = 17;
            this.TdgFormuladosHistorico.EmptyRows = true;
            this.TdgFormuladosHistorico.FilterBar = true;
            this.TdgFormuladosHistorico.GroupByCaption = "Drag a column header here to group by that column";
            this.TdgFormuladosHistorico.Images.Add(((System.Drawing.Image)(resources.GetObject("TdgFormuladosHistorico.Images"))));
            this.TdgFormuladosHistorico.Location = new System.Drawing.Point(433, 32);
            this.TdgFormuladosHistorico.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.TdgFormuladosHistorico.Name = "TdgFormuladosHistorico";
            this.TdgFormuladosHistorico.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.TdgFormuladosHistorico.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.TdgFormuladosHistorico.PreviewInfo.ZoomFactor = 75D;
            this.TdgFormuladosHistorico.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("TdgFormuladosHistorico.PrintInfo.PageSettings")));
            this.TdgFormuladosHistorico.RowHeight = 15;
            this.TdgFormuladosHistorico.Size = new System.Drawing.Size(503, 117);
            this.TdgFormuladosHistorico.TabIndex = 251;
            this.TdgFormuladosHistorico.Text = "c1TrueDBGrid1";
            this.TdgFormuladosHistorico.FetchCellStyle += new C1.Win.C1TrueDBGrid.FetchCellStyleEventHandler(this.TdgFormuladosHistorico_FetchCellStyle);
            this.TdgFormuladosHistorico.PropBag = resources.GetString("TdgFormuladosHistorico.PropBag");
            // 
            // btnGenerar
            // 
            this.btnGenerar.Image = global::Halley.Presentacion.Properties.Resources.Aceptar_16x16;
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(115, 70);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(82, 23);
            this.btnGenerar.TabIndex = 249;
            this.btnGenerar.Text = "Mostrar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 248;
            this.label2.Text = "Hasta:";
            // 
            // cboFechaFin
            // 
            // 
            // 
            // 
            this.cboFechaFin.Calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFechaFin.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.cboFechaFin.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
                        | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.cboFechaFin.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.cboFechaFin.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
                        | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.cboFechaFin.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDateShortTime;
            this.cboFechaFin.Location = new System.Drawing.Point(78, 42);
            this.cboFechaFin.Name = "cboFechaFin";
            this.cboFechaFin.Size = new System.Drawing.Size(119, 22);
            this.cboFechaFin.TabIndex = 247;
            this.cboFechaFin.Tag = null;
            this.cboFechaFin.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 246;
            this.label3.Text = "Ver desde:";
            // 
            // cboFechaInicio
            // 
            // 
            // 
            // 
            this.cboFechaInicio.Calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFechaInicio.Culture = 10250;
            this.cboFechaInicio.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.cboFechaInicio.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
                        | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.cboFechaInicio.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.cboFechaInicio.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText)
                        | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)
                        | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.cboFechaInicio.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDateShortTime;
            this.cboFechaInicio.Location = new System.Drawing.Point(78, 14);
            this.cboFechaInicio.Name = "cboFechaInicio";
            this.cboFechaInicio.Size = new System.Drawing.Size(119, 22);
            this.cboFechaInicio.TabIndex = 245;
            this.cboFechaInicio.Tag = null;
            this.cboFechaInicio.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown;
            // 
            // BtnExportarExcel
            // 
            this.BtnExportarExcel.Image = global::Halley.Presentacion.Properties.Resources.excel_16x16;
            this.BtnExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExportarExcel.Location = new System.Drawing.Point(1023, 187);
            this.BtnExportarExcel.Name = "BtnExportarExcel";
            this.BtnExportarExcel.Size = new System.Drawing.Size(82, 23);
            this.BtnExportarExcel.TabIndex = 362;
            this.BtnExportarExcel.Text = "Exportar";
            this.BtnExportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExportarExcel.UseVisualStyleBackColor = true;
            this.BtnExportarExcel.Click += new System.EventHandler(this.BtnExportarExcel_Click);
            // 
            // PlanDeProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnExportarExcel);
            this.Controls.Add(this.TcOpciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnMostrarPlan);
            this.Controls.Add(this.BtnGrabar);
            this.Controls.Add(this.TcProduccion);
            this.Name = "PlanDeProduccion";
            this.Size = new System.Drawing.Size(1123, 523);
            this.Load += new System.EventHandler(this.Produccion_Load);
            this.Controls.SetChildIndex(this.TcProduccion, 0);
            this.Controls.SetChildIndex(this.BtnGrabar, 0);
            this.Controls.SetChildIndex(this.BtnMostrarPlan, 0);
            this.Controls.SetChildIndex(this.BtnNuevo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.TcOpciones, 0);
            this.Controls.SetChildIndex(this.BtnExportarExcel, 0);
            this.TcProduccion.ResumeLayout(false);
            this.TpMicroInsumos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TdgMicro)).EndInit();
            this.TpMacroInsumos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TdgMacro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgFormuladosBatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TdgProductosFormulados)).EndInit();
            this.TcOpciones.ResumeLayout(false);
            this.TpPlanActual.ResumeLayout(false);
            this.TpPlanHistorico.ResumeLayout(false);
            this.TpPlanHistorico.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TdgFormuladosHistorico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaInicio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TcProduccion;
        private System.Windows.Forms.TabPage TpMicroInsumos;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgMicro;
        private System.Windows.Forms.TabPage TpMacroInsumos;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgFormuladosBatch;
        private C1.Win.C1Input.C1Button BtnNuevo;
        private C1.Win.C1Input.C1Button BtnMostrarPlan;
        private C1.Win.C1Input.C1Button BtnGrabar;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgMacro;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1Button BtnAgregar;
        private C1.Win.C1Input.C1Button BtnQuitar;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgProductosFormulados;
        private System.Windows.Forms.TabControl TcOpciones;
        private System.Windows.Forms.TabPage TpPlanActual;
        private System.Windows.Forms.TabPage TpPlanHistorico;
        private C1.Win.C1Input.C1Button BtnQuitarHistorico;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid TdgFormuladosHistorico;
        private System.Windows.Forms.ListBox LstHistorico;
        private C1.Win.C1Input.C1Button btnGenerar;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1DateEdit cboFechaFin;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1DateEdit cboFechaInicio;
        private System.Windows.Forms.GroupBox groupBox1;
        private C1.Win.C1Input.C1Button BtnExportarExcel;
        private C1.Win.C1Input.C1Button BtnProductoTerminado;
    }
}
