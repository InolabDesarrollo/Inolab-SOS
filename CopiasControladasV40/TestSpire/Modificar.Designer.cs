namespace TestSpire
{
    partial class Modificar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Modificar));
            this.save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.folioLabel = new System.Windows.Forms.Label();
            this.documento = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.FechaDeEmision = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FechaDeRegistro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NoHojas = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.uso = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TipoServicio = new System.Windows.Forms.ComboBox();
            this.cliente = new System.Windows.Forms.ComboBox();
            this.frs = new System.Windows.Forms.TextBox();
            this.estatus = new System.Windows.Forms.ComboBox();
            this.documentador = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.browserDataSet3 = new TestSpire.BrowserDataSet3();
            this.tipoServicioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipo_ServicioTableAdapter = new TestSpire.BrowserDataSet3TableAdapters.Tipo_ServicioTableAdapter();
            this.clientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientesTableAdapter = new TestSpire.BrowserDataSet3TableAdapters.ClientesTableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoServicioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // save
            // 
            this.save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save.Location = new System.Drawing.Point(389, 378);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 0;
            this.save.Text = "Guardar";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Folio: ";
            // 
            // folioLabel
            // 
            this.folioLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.folioLabel.AutoSize = true;
            this.folioLabel.Location = new System.Drawing.Point(129, 34);
            this.folioLabel.Name = "folioLabel";
            this.folioLabel.Size = new System.Drawing.Size(335, 13);
            this.folioLabel.TabIndex = 2;
            this.folioLabel.Text = "label2";
            // 
            // documento
            // 
            this.documento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.documento.AutoSize = true;
            this.documento.Location = new System.Drawing.Point(129, 59);
            this.documento.Name = "documento";
            this.documento.Size = new System.Drawing.Size(335, 13);
            this.documento.TabIndex = 3;
            this.documento.TabStop = true;
            this.documento.Text = "linkLabel1";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Documento:";
            // 
            // FechaDeEmision
            // 
            this.FechaDeEmision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FechaDeEmision.Location = new System.Drawing.Point(129, 85);
            this.FechaDeEmision.Name = "FechaDeEmision";
            this.FechaDeEmision.Size = new System.Drawing.Size(335, 20);
            this.FechaDeEmision.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha de Emision";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha de Registro";
            // 
            // FechaDeRegistro
            // 
            this.FechaDeRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FechaDeRegistro.Location = new System.Drawing.Point(129, 122);
            this.FechaDeRegistro.Name = "FechaDeRegistro";
            this.FechaDeRegistro.Size = new System.Drawing.Size(335, 20);
            this.FechaDeRegistro.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "No. De Hojas";
            // 
            // NoHojas
            // 
            this.NoHojas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NoHojas.AutoSize = true;
            this.NoHojas.Location = new System.Drawing.Point(129, 159);
            this.NoHojas.Name = "NoHojas";
            this.NoHojas.Size = new System.Drawing.Size(335, 13);
            this.NoHojas.TabIndex = 10;
            this.NoHojas.Text = "label6";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Uso";
            // 
            // uso
            // 
            this.uso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.uso.Location = new System.Drawing.Point(129, 190);
            this.uso.Name = "uso";
            this.uso.Size = new System.Drawing.Size(335, 20);
            this.uso.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Tipo De Servicio";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Cliente";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 308);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "FRS";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 344);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Estatus";
            // 
            // TipoServicio
            // 
            this.TipoServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TipoServicio.DataSource = this.tipoServicioBindingSource;
            this.TipoServicio.DisplayMember = "Descripcion";
            this.TipoServicio.FormattingEnabled = true;
            this.TipoServicio.Location = new System.Drawing.Point(129, 229);
            this.TipoServicio.Name = "TipoServicio";
            this.TipoServicio.Size = new System.Drawing.Size(335, 21);
            this.TipoServicio.TabIndex = 17;
            this.TipoServicio.ValueMember = "ID";
            // 
            // cliente
            // 
            this.cliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cliente.DataSource = this.clientesBindingSource;
            this.cliente.DisplayMember = "Empresa";
            this.cliente.FormattingEnabled = true;
            this.cliente.Location = new System.Drawing.Point(129, 267);
            this.cliente.Name = "cliente";
            this.cliente.Size = new System.Drawing.Size(335, 21);
            this.cliente.TabIndex = 18;
            this.cliente.ValueMember = "IdCliente";
            // 
            // frs
            // 
            this.frs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.frs.Location = new System.Drawing.Point(129, 304);
            this.frs.Name = "frs";
            this.frs.Size = new System.Drawing.Size(335, 20);
            this.frs.TabIndex = 19;
            // 
            // estatus
            // 
            this.estatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.estatus.FormattingEnabled = true;
            this.estatus.Items.AddRange(new object[] {
            "Cancelada",
            "Activo"});
            this.estatus.Location = new System.Drawing.Point(129, 340);
            this.estatus.Name = "estatus";
            this.estatus.Size = new System.Drawing.Size(335, 21);
            this.estatus.TabIndex = 20;
            // 
            // documentador
            // 
            this.documentador.AutoSize = true;
            this.documentador.Location = new System.Drawing.Point(3, 0);
            this.documentador.Name = "documentador";
            this.documentador.Size = new System.Drawing.Size(41, 13);
            this.documentador.TabIndex = 21;
            this.documentador.Text = "label11";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.17149F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.82851F));
            this.tableLayoutPanel1.Controls.Add(this.documentador, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.save, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.estatus, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.frs, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cliente, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.TipoServicio, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.folioLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.documento, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.FechaDeEmision, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.FechaDeRegistro, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.uso, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.NoHojas, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.85185F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.14815F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(467, 404);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // browserDataSet3
            // 
            this.browserDataSet3.DataSetName = "BrowserDataSet3";
            this.browserDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tipoServicioBindingSource
            // 
            this.tipoServicioBindingSource.DataMember = "Tipo_Servicio";
            this.tipoServicioBindingSource.DataSource = this.browserDataSet3;
            // 
            // tipo_ServicioTableAdapter
            // 
            this.tipo_ServicioTableAdapter.ClearBeforeFill = true;
            // 
            // clientesBindingSource
            // 
            this.clientesBindingSource.DataMember = "Clientes";
            this.clientesBindingSource.DataSource = this.browserDataSet3;
            // 
            // clientesTableAdapter
            // 
            this.clientesTableAdapter.ClearBeforeFill = true;
            // 
            // Modificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 404);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(780, 443);
            this.MinimumSize = new System.Drawing.Size(357, 443);
            this.Name = "Modificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar";
            this.Load += new System.EventHandler(this.Modificar_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoServicioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label folioLabel;
        private System.Windows.Forms.LinkLabel documento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FechaDeEmision;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FechaDeRegistro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label NoHojas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox uso;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox TipoServicio;
        private System.Windows.Forms.ComboBox cliente;
        private System.Windows.Forms.TextBox frs;
        private System.Windows.Forms.ComboBox estatus;
        private System.Windows.Forms.Label documentador;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private BrowserDataSet3 browserDataSet3;
        private System.Windows.Forms.BindingSource tipoServicioBindingSource;
        private BrowserDataSet3TableAdapters.Tipo_ServicioTableAdapter tipo_ServicioTableAdapter;
        private System.Windows.Forms.BindingSource clientesBindingSource;
        private BrowserDataSet3TableAdapters.ClientesTableAdapter clientesTableAdapter;
    }
}