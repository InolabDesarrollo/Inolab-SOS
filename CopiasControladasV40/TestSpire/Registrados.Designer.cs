namespace TestSpire
{
    partial class Registrados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registrados));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.browserDataSet2 = new TestSpire.BrowserDataSet2();
            this.getCCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.getCCTableAdapter = new TestSpire.BrowserDataSet2TableAdapters.GetCCTableAdapter();
            this.copiasControladasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.browserDataSet3 = new TestSpire.BrowserDataSet3();
            this.copiasControladasTableAdapter = new TestSpire.BrowserDataSet3TableAdapters.CopiasControladasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.copiasControladasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(940, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // browserDataSet2
            // 
            this.browserDataSet2.DataSetName = "BrowserDataSet2";
            this.browserDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getCCBindingSource
            // 
            this.getCCBindingSource.DataMember = "GetCC";
            this.getCCBindingSource.DataSource = this.browserDataSet2;
            // 
            // getCCTableAdapter
            // 
            this.getCCTableAdapter.ClearBeforeFill = true;
            // 
            // copiasControladasBindingSource
            // 
            this.copiasControladasBindingSource.DataMember = "CopiasControladas";
            this.copiasControladasBindingSource.DataSource = this.browserDataSet3;
            // 
            // browserDataSet3
            // 
            this.browserDataSet3.DataSetName = "BrowserDataSet3";
            this.browserDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // copiasControladasTableAdapter
            // 
            this.copiasControladasTableAdapter.ClearBeforeFill = true;
            // 
            // Registrados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 450);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(956, 489);
            this.Name = "Registrados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro";
            this.Load += new System.EventHandler(this.Registrados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.copiasControladasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private BrowserDataSet3 browserDataSet3;
        private System.Windows.Forms.BindingSource copiasControladasBindingSource;
        private BrowserDataSet3TableAdapters.CopiasControladasTableAdapter copiasControladasTableAdapter;
        private BrowserDataSet2 browserDataSet2;
        private System.Windows.Forms.BindingSource getCCBindingSource;
        private BrowserDataSet2TableAdapters.GetCCTableAdapter getCCTableAdapter;
    }
}