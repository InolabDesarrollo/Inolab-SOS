namespace TestSpire
{
    partial class Consultar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Consultar));
            this.ConsultaDGV = new System.Windows.Forms.DataGridView();
            this.folioDataGridViewTextBoxColumn = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.documentoDataGridViewTextBoxColumn = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.Documentador = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.FechaRegistro = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.fechaDeEmisionDataGridViewTextBoxColumn = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.hojasDataGridViewTextBoxColumn = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.usoDataGridViewTextBoxColumn = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.tipoServicioDataGridViewTextBoxColumn = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.clienteDataGridViewTextBoxColumn = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.fRSDataGridViewTextBoxColumn = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.estatusDataGridViewTextBoxColumn = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.getCCBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.browserDataSet1 = new TestSpire.BrowserDataSet1();
            this.getCCBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.FilterStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ShowAllLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Filterstati = new System.Windows.Forms.ToolStripStatusLabel();
            this.getCC = new TestSpire.GetCC();
            this.getCCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.getCCTableAdapter = new TestSpire.GetCCTableAdapters.GetCCTableAdapter();
            this.getCCTableAdapter1 = new TestSpire.BrowserDataSet1TableAdapters.GetCCTableAdapter();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiaControladaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporte1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porFRSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.browserDataSet2 = new TestSpire.BrowserDataSet2();
            this.getCCBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.getCCTableAdapter2 = new TestSpire.BrowserDataSet2TableAdapters.GetCCTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ConsultaDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCCBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCCBindingSource1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCCBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCCBindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // ConsultaDGV
            // 
            this.ConsultaDGV.AllowUserToAddRows = false;
            this.ConsultaDGV.AllowUserToDeleteRows = false;
            this.ConsultaDGV.AutoGenerateColumns = false;
            this.ConsultaDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ConsultaDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConsultaDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.folioDataGridViewTextBoxColumn,
            this.documentoDataGridViewTextBoxColumn,
            this.Documentador,
            this.FechaRegistro,
            this.fechaDeEmisionDataGridViewTextBoxColumn,
            this.hojasDataGridViewTextBoxColumn,
            this.usoDataGridViewTextBoxColumn,
            this.tipoServicioDataGridViewTextBoxColumn,
            this.clienteDataGridViewTextBoxColumn,
            this.fRSDataGridViewTextBoxColumn,
            this.estatusDataGridViewTextBoxColumn});
            this.ConsultaDGV.DataSource = this.getCCBindingSource3;
            this.ConsultaDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsultaDGV.Location = new System.Drawing.Point(0, 0);
            this.ConsultaDGV.Name = "ConsultaDGV";
            this.ConsultaDGV.ReadOnly = true;
            this.ConsultaDGV.Size = new System.Drawing.Size(940, 338);
            this.ConsultaDGV.TabIndex = 0;
            this.ConsultaDGV.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ConsultaDGV_CellContentDoubleClick);
            this.ConsultaDGV.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ConsultaDGV_CellMouseDoubleClick);
            this.ConsultaDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ConsultaDGV_DataBindingComplete);
            this.ConsultaDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConsultaDGV_KeyDown);
            // 
            // folioDataGridViewTextBoxColumn
            // 
            this.folioDataGridViewTextBoxColumn.DataPropertyName = "Folio";
            this.folioDataGridViewTextBoxColumn.HeaderText = "Folio";
            this.folioDataGridViewTextBoxColumn.Name = "folioDataGridViewTextBoxColumn";
            this.folioDataGridViewTextBoxColumn.ReadOnly = true;
            this.folioDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // documentoDataGridViewTextBoxColumn
            // 
            this.documentoDataGridViewTextBoxColumn.DataPropertyName = "Documento";
            this.documentoDataGridViewTextBoxColumn.HeaderText = "Documento";
            this.documentoDataGridViewTextBoxColumn.Name = "documentoDataGridViewTextBoxColumn";
            this.documentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.documentoDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Documentador
            // 
            this.Documentador.DataPropertyName = "Documentador";
            this.Documentador.HeaderText = "Documentador";
            this.Documentador.Name = "Documentador";
            this.Documentador.ReadOnly = true;
            this.Documentador.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.DataPropertyName = "FechaRegistro";
            this.FechaRegistro.HeaderText = "FechaRegistro";
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.ReadOnly = true;
            this.FechaRegistro.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // fechaDeEmisionDataGridViewTextBoxColumn
            // 
            this.fechaDeEmisionDataGridViewTextBoxColumn.DataPropertyName = "FechaDeEmision";
            this.fechaDeEmisionDataGridViewTextBoxColumn.HeaderText = "Fecha De Emision";
            this.fechaDeEmisionDataGridViewTextBoxColumn.Name = "fechaDeEmisionDataGridViewTextBoxColumn";
            this.fechaDeEmisionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDeEmisionDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // hojasDataGridViewTextBoxColumn
            // 
            this.hojasDataGridViewTextBoxColumn.DataPropertyName = "Hojas";
            this.hojasDataGridViewTextBoxColumn.HeaderText = "Hojas";
            this.hojasDataGridViewTextBoxColumn.Name = "hojasDataGridViewTextBoxColumn";
            this.hojasDataGridViewTextBoxColumn.ReadOnly = true;
            this.hojasDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // usoDataGridViewTextBoxColumn
            // 
            this.usoDataGridViewTextBoxColumn.DataPropertyName = "Uso";
            this.usoDataGridViewTextBoxColumn.HeaderText = "Uso";
            this.usoDataGridViewTextBoxColumn.Name = "usoDataGridViewTextBoxColumn";
            this.usoDataGridViewTextBoxColumn.ReadOnly = true;
            this.usoDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tipoServicioDataGridViewTextBoxColumn
            // 
            this.tipoServicioDataGridViewTextBoxColumn.DataPropertyName = "TipoServicio";
            this.tipoServicioDataGridViewTextBoxColumn.HeaderText = "TipoServicio";
            this.tipoServicioDataGridViewTextBoxColumn.Name = "tipoServicioDataGridViewTextBoxColumn";
            this.tipoServicioDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoServicioDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // clienteDataGridViewTextBoxColumn
            // 
            this.clienteDataGridViewTextBoxColumn.DataPropertyName = "Cliente";
            this.clienteDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.clienteDataGridViewTextBoxColumn.Name = "clienteDataGridViewTextBoxColumn";
            this.clienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // fRSDataGridViewTextBoxColumn
            // 
            this.fRSDataGridViewTextBoxColumn.DataPropertyName = "FRS";
            this.fRSDataGridViewTextBoxColumn.HeaderText = "FRS";
            this.fRSDataGridViewTextBoxColumn.Name = "fRSDataGridViewTextBoxColumn";
            this.fRSDataGridViewTextBoxColumn.ReadOnly = true;
            this.fRSDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // estatusDataGridViewTextBoxColumn
            // 
            this.estatusDataGridViewTextBoxColumn.DataPropertyName = "Estatus";
            this.estatusDataGridViewTextBoxColumn.HeaderText = "Estatus";
            this.estatusDataGridViewTextBoxColumn.Name = "estatusDataGridViewTextBoxColumn";
            this.estatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.estatusDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // getCCBindingSource2
            // 
            this.getCCBindingSource2.DataMember = "GetCC";
            this.getCCBindingSource2.DataSource = this.browserDataSet1;
            // 
            // browserDataSet1
            // 
            this.browserDataSet1.DataSetName = "BrowserDataSet1";
            this.browserDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getCCBindingSource1
            // 
            this.getCCBindingSource1.DataMember = "GetCC";
            this.getCCBindingSource1.DataSource = this.browserDataSet1;
            this.getCCBindingSource1.CurrentChanged += new System.EventHandler(this.getCCBindingSource1_CurrentChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilterStatusLabel,
            this.ShowAllLabel,
            this.Filterstati});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(940, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // FilterStatusLabel
            // 
            this.FilterStatusLabel.Name = "FilterStatusLabel";
            this.FilterStatusLabel.Size = new System.Drawing.Size(0, 17);
            this.FilterStatusLabel.Visible = false;
            // 
            // ShowAllLabel
            // 
            this.ShowAllLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ShowAllLabel.IsLink = true;
            this.ShowAllLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.ShowAllLabel.Name = "ShowAllLabel";
            this.ShowAllLabel.Size = new System.Drawing.Size(81, 17);
            this.ShowAllLabel.Text = "Mostrar Todo";
            this.ShowAllLabel.Click += new System.EventHandler(this.ShowAllLabel_Click);
            // 
            // Filterstati
            // 
            this.Filterstati.Name = "Filterstati";
            this.Filterstati.Size = new System.Drawing.Size(0, 17);
            this.Filterstati.Visible = false;
            // 
            // getCC
            // 
            this.getCC.DataSetName = "GetCC";
            this.getCC.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getCCBindingSource
            // 
            this.getCCBindingSource.DataMember = "GetCC";
            this.getCCBindingSource.DataSource = this.getCC;
            // 
            // getCCTableAdapter
            // 
            this.getCCTableAdapter.ClearBeforeFill = true;
            // 
            // getCCTableAdapter1
            // 
            this.getCCTableAdapter1.ClearBeforeFill = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.verToolStripMenuItem,
            this.usuariosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(940, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copiaControladaToolStripMenuItem});
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // copiaControladaToolStripMenuItem
            // 
            this.copiaControladaToolStripMenuItem.Name = "copiaControladaToolStripMenuItem";
            this.copiaControladaToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.copiaControladaToolStripMenuItem.Text = "Copia controlada";
            this.copiaControladaToolStripMenuItem.Click += new System.EventHandler(this.copiaControladaToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión.";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteToolStripMenuItem,
            this.cambiosToolStripMenuItem});
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // reporteToolStripMenuItem
            // 
            this.reporteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporte1ToolStripMenuItem,
            this.porFRSToolStripMenuItem});
            this.reporteToolStripMenuItem.Name = "reporteToolStripMenuItem";
            this.reporteToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.reporteToolStripMenuItem.Text = "Reporte";
            this.reporteToolStripMenuItem.Click += new System.EventHandler(this.reporteToolStripMenuItem_Click);
            // 
            // reporte1ToolStripMenuItem
            // 
            this.reporte1ToolStripMenuItem.Name = "reporte1ToolStripMenuItem";
            this.reporte1ToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.reporte1ToolStripMenuItem.Text = "Por Usuario";
            this.reporte1ToolStripMenuItem.Click += new System.EventHandler(this.reporte1ToolStripMenuItem_Click);
            // 
            // porFRSToolStripMenuItem
            // 
            this.porFRSToolStripMenuItem.Name = "porFRSToolStripMenuItem";
            this.porFRSToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.porFRSToolStripMenuItem.Text = "Por FRS";
            this.porFRSToolStripMenuItem.Click += new System.EventHandler(this.porFRSToolStripMenuItem_Click);
            // 
            // cambiosToolStripMenuItem
            // 
            this.cambiosToolStripMenuItem.Name = "cambiosToolStripMenuItem";
            this.cambiosToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.cambiosToolStripMenuItem.Text = "Cambios";
            this.cambiosToolStripMenuItem.Click += new System.EventHandler(this.cambiosToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem1,
            this.actualizarToolStripMenuItem});
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // nuevoToolStripMenuItem1
            // 
            this.nuevoToolStripMenuItem1.Name = "nuevoToolStripMenuItem1";
            this.nuevoToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.nuevoToolStripMenuItem1.Text = "Nuevo";
            this.nuevoToolStripMenuItem1.Click += new System.EventHandler(this.nuevoToolStripMenuItem1_Click);
            // 
            // actualizarToolStripMenuItem
            // 
            this.actualizarToolStripMenuItem.Name = "actualizarToolStripMenuItem";
            this.actualizarToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.actualizarToolStripMenuItem.Text = "Actualizar";
            this.actualizarToolStripMenuItem.Click += new System.EventHandler(this.actualizarToolStripMenuItem_Click);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.ConsultaDGV);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(940, 338);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 63);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(940, 362);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // browserDataSet2
            // 
            this.browserDataSet2.DataSetName = "BrowserDataSet2";
            this.browserDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getCCBindingSource3
            // 
            this.getCCBindingSource3.DataMember = "GetCC";
            this.getCCBindingSource3.DataSource = this.browserDataSet2;
            // 
            // getCCTableAdapter2
            // 
            this.getCCTableAdapter2.ClearBeforeFill = true;
            // 
            // Consultar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 450);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Consultar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar";
            this.Deactivate += new System.EventHandler(this.Consultar_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Consultar_FormClosing);
            this.Load += new System.EventHandler(this.Consultar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ConsultaDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCCBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCCBindingSource1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCCBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCCBindingSource3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ConsultaDGV;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel FilterStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel ShowAllLabel;
        private GetCC getCC;
        private System.Windows.Forms.BindingSource getCCBindingSource;
        private GetCCTableAdapters.GetCCTableAdapter getCCTableAdapter;
        private BrowserDataSet1 browserDataSet1;
        private System.Windows.Forms.BindingSource getCCBindingSource1;
        private BrowserDataSet1TableAdapters.GetCCTableAdapter getCCTableAdapter1;
        private System.Windows.Forms.BindingSource getCCBindingSource2;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn folioDataGridViewTextBoxColumn;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn documentoDataGridViewTextBoxColumn;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn Documentador;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn FechaRegistro;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn fechaDeEmisionDataGridViewTextBoxColumn;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn hojasDataGridViewTextBoxColumn;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn usoDataGridViewTextBoxColumn;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn tipoServicioDataGridViewTextBoxColumn;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn clienteDataGridViewTextBoxColumn;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn fRSDataGridViewTextBoxColumn;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn estatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiosToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel Filterstati;
        private System.Windows.Forms.ToolStripMenuItem reporte1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porFRSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copiaControladaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem actualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private BrowserDataSet2 browserDataSet2;
        private System.Windows.Forms.BindingSource getCCBindingSource3;
        private BrowserDataSet2TableAdapters.GetCCTableAdapter getCCTableAdapter2;
    }
}