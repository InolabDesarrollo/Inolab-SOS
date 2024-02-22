namespace TestSpire
{
    partial class ConsultarCambios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultarCambios));
            this.CC_DGV = new System.Windows.Forms.DataGridView();
            this.idlogccDataGridViewTextBoxColumn = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.folioDataGridViewTextBoxColumn = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.fechaCambioDataGridViewTextBoxColumn = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.cambioDataGridViewTextBoxColumn = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.getCambiosCCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.getCambiosCC = new TestSpire.GetCambiosCC();
            this.getCambiosCCTableAdapter = new TestSpire.GetCambiosCCTableAdapters.GetCambiosCCTableAdapter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            ((System.ComponentModel.ISupportInitialize)(this.CC_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCambiosCCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCambiosCC)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CC_DGV
            // 
            this.CC_DGV.AllowUserToAddRows = false;
            this.CC_DGV.AllowUserToDeleteRows = false;
            this.CC_DGV.AutoGenerateColumns = false;
            this.CC_DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CC_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CC_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idlogccDataGridViewTextBoxColumn,
            this.folioDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.fechaCambioDataGridViewTextBoxColumn,
            this.cambioDataGridViewTextBoxColumn});
            this.CC_DGV.DataSource = this.getCambiosCCBindingSource;
            this.CC_DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CC_DGV.Location = new System.Drawing.Point(0, 0);
            this.CC_DGV.Name = "CC_DGV";
            this.CC_DGV.ReadOnly = true;
            this.CC_DGV.Size = new System.Drawing.Size(799, 337);
            this.CC_DGV.TabIndex = 0;
            this.CC_DGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CC_DGV_CellContentClick);
            this.CC_DGV.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CC_DGV_CellMouseDoubleClick);
            this.CC_DGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.CC_DGV_DataBindingComplete);
            this.CC_DGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CC_DGV_KeyDown);
            // 
            // idlogccDataGridViewTextBoxColumn
            // 
            this.idlogccDataGridViewTextBoxColumn.DataPropertyName = "Idlogcc";
            this.idlogccDataGridViewTextBoxColumn.HeaderText = "Idlogcc";
            this.idlogccDataGridViewTextBoxColumn.Name = "idlogccDataGridViewTextBoxColumn";
            this.idlogccDataGridViewTextBoxColumn.ReadOnly = true;
            this.idlogccDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // folioDataGridViewTextBoxColumn
            // 
            this.folioDataGridViewTextBoxColumn.DataPropertyName = "Folio";
            this.folioDataGridViewTextBoxColumn.HeaderText = "Folio";
            this.folioDataGridViewTextBoxColumn.Name = "folioDataGridViewTextBoxColumn";
            this.folioDataGridViewTextBoxColumn.ReadOnly = true;
            this.folioDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // fechaCambioDataGridViewTextBoxColumn
            // 
            this.fechaCambioDataGridViewTextBoxColumn.DataPropertyName = "FechaCambio";
            this.fechaCambioDataGridViewTextBoxColumn.HeaderText = "FechaCambio";
            this.fechaCambioDataGridViewTextBoxColumn.Name = "fechaCambioDataGridViewTextBoxColumn";
            this.fechaCambioDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaCambioDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // cambioDataGridViewTextBoxColumn
            // 
            this.cambioDataGridViewTextBoxColumn.DataPropertyName = "Cambio";
            this.cambioDataGridViewTextBoxColumn.HeaderText = "Cambio";
            this.cambioDataGridViewTextBoxColumn.Name = "cambioDataGridViewTextBoxColumn";
            this.cambioDataGridViewTextBoxColumn.ReadOnly = true;
            this.cambioDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // getCambiosCCBindingSource
            // 
            this.getCambiosCCBindingSource.DataMember = "GetCambiosCC";
            this.getCambiosCCBindingSource.DataSource = this.getCambiosCC;
            // 
            // getCambiosCC
            // 
            this.getCambiosCC.DataSetName = "GetCambiosCC";
            this.getCambiosCC.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getCambiosCCTableAdapter
            // 
            this.getCambiosCCTableAdapter.ClearBeforeFill = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(799, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.IsLink = true;
            this.toolStripStatusLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(77, 17);
            this.toolStripStatusLabel1.Text = "Mostrar Todo";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            this.toolStripStatusLabel2.Visible = false;
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.CC_DGV);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(799, 337);
            this.toolStripContainer1.Location = new System.Drawing.Point(1, 64);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(799, 384);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // ConsultarCambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConsultarCambios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Cambios";
            this.Load += new System.EventHandler(this.ConsultarCambios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CC_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCambiosCCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCambiosCC)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView CC_DGV;
        private GetCambiosCC getCambiosCC;
        private System.Windows.Forms.BindingSource getCambiosCCBindingSource;
        private GetCambiosCCTableAdapters.GetCambiosCCTableAdapter getCambiosCCTableAdapter;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn idlogccDataGridViewTextBoxColumn;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn folioDataGridViewTextBoxColumn;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn fechaCambioDataGridViewTextBoxColumn;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn cambioDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
    }
}