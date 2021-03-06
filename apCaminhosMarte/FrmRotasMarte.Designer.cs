﻿namespace apCaminhosMarte
{
    partial class FrmRotasMarte
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRotasMarte));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpRotas = new System.Windows.Forms.TabPage();
            this.btnCarregarCaminhos = new System.Windows.Forms.Button();
            this.btnCarregarCidades = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvMelhorCaminho = new System.Windows.Forms.DataGridView();
            this.dgvCaminhos = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lsbDestino = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbOrigem = new System.Windows.Forms.ListBox();
            this.pbMapa = new System.Windows.Forms.PictureBox();
            this.tpArvore = new System.Windows.Forms.TabPage();
            this.pnlCidades = new System.Windows.Forms.Panel();
            this.pbArvore = new System.Windows.Forms.PictureBox();
            this.lblCidades = new System.Windows.Forms.Label();
            this.dlgAbrir = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tpRotas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMelhorCaminho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaminhos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).BeginInit();
            this.tpArvore.SuspendLayout();
            this.pnlCidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArvore)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpRotas);
            this.tabControl1.Controls.Add(this.tpArvore);
            this.tabControl1.Location = new System.Drawing.Point(2, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1025, 551);
            this.tabControl1.TabIndex = 0;
            // 
            // tpRotas
            // 
            this.tpRotas.Controls.Add(this.btnCarregarCaminhos);
            this.tpRotas.Controls.Add(this.btnCarregarCidades);
            this.tpRotas.Controls.Add(this.btnBuscar);
            this.tpRotas.Controls.Add(this.dgvMelhorCaminho);
            this.tpRotas.Controls.Add(this.dgvCaminhos);
            this.tpRotas.Controls.Add(this.label4);
            this.tpRotas.Controls.Add(this.label3);
            this.tpRotas.Controls.Add(this.label2);
            this.tpRotas.Controls.Add(this.lsbDestino);
            this.tpRotas.Controls.Add(this.label1);
            this.tpRotas.Controls.Add(this.lsbOrigem);
            this.tpRotas.Controls.Add(this.pbMapa);
            this.tpRotas.Location = new System.Drawing.Point(4, 22);
            this.tpRotas.Name = "tpRotas";
            this.tpRotas.Padding = new System.Windows.Forms.Padding(3);
            this.tpRotas.Size = new System.Drawing.Size(1017, 525);
            this.tpRotas.TabIndex = 0;
            this.tpRotas.Text = "Rotas entre cidades";
            this.tpRotas.UseVisualStyleBackColor = true;
            // 
            // btnCarregarCaminhos
            // 
            this.btnCarregarCaminhos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCarregarCaminhos.Enabled = false;
            this.btnCarregarCaminhos.Location = new System.Drawing.Point(920, 74);
            this.btnCarregarCaminhos.Name = "btnCarregarCaminhos";
            this.btnCarregarCaminhos.Size = new System.Drawing.Size(89, 35);
            this.btnCarregarCaminhos.TabIndex = 13;
            this.btnCarregarCaminhos.Text = "Carregar caminhos";
            this.btnCarregarCaminhos.UseVisualStyleBackColor = true;
            this.btnCarregarCaminhos.Click += new System.EventHandler(this.btnCarregarCaminhos_Click);
            // 
            // btnCarregarCidades
            // 
            this.btnCarregarCidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCarregarCidades.Location = new System.Drawing.Point(920, 25);
            this.btnCarregarCidades.Name = "btnCarregarCidades";
            this.btnCarregarCidades.Size = new System.Drawing.Size(89, 43);
            this.btnCarregarCidades.TabIndex = 12;
            this.btnCarregarCidades.Text = "Carregar cidades";
            this.btnCarregarCidades.UseVisualStyleBackColor = true;
            this.btnCarregarCidades.Click += new System.EventHandler(this.btnCarregarCidades_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Location = new System.Drawing.Point(920, 190);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(89, 23);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // dgvMelhorCaminho
            // 
            this.dgvMelhorCaminho.AllowUserToAddRows = false;
            this.dgvMelhorCaminho.AllowUserToDeleteRows = false;
            this.dgvMelhorCaminho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMelhorCaminho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMelhorCaminho.Location = new System.Drawing.Point(736, 448);
            this.dgvMelhorCaminho.Name = "dgvMelhorCaminho";
            this.dgvMelhorCaminho.ReadOnly = true;
            this.dgvMelhorCaminho.Size = new System.Drawing.Size(277, 71);
            this.dgvMelhorCaminho.TabIndex = 10;
            this.dgvMelhorCaminho.SelectionChanged += new System.EventHandler(this.dgvMelhorCaminho_SelectionChanged);
            // 
            // dgvCaminhos
            // 
            this.dgvCaminhos.AllowUserToAddRows = false;
            this.dgvCaminhos.AllowUserToDeleteRows = false;
            this.dgvCaminhos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCaminhos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaminhos.Location = new System.Drawing.Point(736, 238);
            this.dgvCaminhos.Name = "dgvCaminhos";
            this.dgvCaminhos.ReadOnly = true;
            this.dgvCaminhos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCaminhos.Size = new System.Drawing.Size(277, 181);
            this.dgvCaminhos.TabIndex = 9;
            this.dgvCaminhos.SelectionChanged += new System.EventHandler(this.dgvCaminhos_SelectionChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(733, 429);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Melhor caminho";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(733, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Caminhos encontrados:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(734, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Destino";
            // 
            // lsbDestino
            // 
            this.lsbDestino.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbDestino.FormattingEnabled = true;
            this.lsbDestino.ItemHeight = 16;
            this.lsbDestino.Items.AddRange(new object[] {
            "  0 - Acheron          ",
            "  1 - Arena           ",
            "  2 - Arrakeen       ",
            "  3 - Bakhuysen       ",
            "  4 - Bradbury ",
            "  5 - Burroughs       ",
            "  6 - Cairo            "});
            this.lsbDestino.Location = new System.Drawing.Point(737, 129);
            this.lsbDestino.Name = "lsbDestino";
            this.lsbDestino.Size = new System.Drawing.Size(177, 84);
            this.lsbDestino.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(737, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Origem";
            // 
            // lsbOrigem
            // 
            this.lsbOrigem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbOrigem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbOrigem.FormattingEnabled = true;
            this.lsbOrigem.ItemHeight = 16;
            this.lsbOrigem.Items.AddRange(new object[] {
            "  0 - Acheron          ",
            "  1 - Arena           ",
            "  2 - Arrakeen       ",
            "  3 - Bakhuysen       ",
            "  4 - Bradbury ",
            "  5 - Burroughs       ",
            "  6 - Cairo            "});
            this.lsbOrigem.Location = new System.Drawing.Point(737, 25);
            this.lsbOrigem.Name = "lsbOrigem";
            this.lsbOrigem.Size = new System.Drawing.Size(177, 84);
            this.lsbOrigem.TabIndex = 1;
            // 
            // pbMapa
            // 
            this.pbMapa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMapa.Image = ((System.Drawing.Image)(resources.GetObject("pbMapa.Image")));
            this.pbMapa.Location = new System.Drawing.Point(7, 7);
            this.pbMapa.Name = "pbMapa";
            this.pbMapa.Size = new System.Drawing.Size(723, 512);
            this.pbMapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMapa.TabIndex = 0;
            this.pbMapa.TabStop = false;
            this.pbMapa.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMapa_Paint);
            // 
            // tpArvore
            // 
            this.tpArvore.Controls.Add(this.pnlCidades);
            this.tpArvore.Controls.Add(this.lblCidades);
            this.tpArvore.Location = new System.Drawing.Point(4, 22);
            this.tpArvore.Name = "tpArvore";
            this.tpArvore.Padding = new System.Windows.Forms.Padding(3);
            this.tpArvore.Size = new System.Drawing.Size(1017, 525);
            this.tpArvore.TabIndex = 1;
            this.tpArvore.Text = "Árvore de Cidades";
            this.tpArvore.UseVisualStyleBackColor = true;
            this.tpArvore.Enter += new System.EventHandler(this.PnlCidades_Resize);
            // 
            // pnlCidades
            // 
            this.pnlCidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCidades.AutoScroll = true;
            this.pnlCidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlCidades.Controls.Add(this.pbArvore);
            this.pnlCidades.Location = new System.Drawing.Point(10, 41);
            this.pnlCidades.Name = "pnlCidades";
            this.pnlCidades.Size = new System.Drawing.Size(1000, 475);
            this.pnlCidades.TabIndex = 2;
            this.pnlCidades.Resize += new System.EventHandler(this.PnlCidades_Resize);
            // 
            // pbArvore
            // 
            this.pbArvore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pbArvore.Location = new System.Drawing.Point(3, 3);
            this.pbArvore.Name = "pbArvore";
            this.pbArvore.Size = new System.Drawing.Size(994, 469);
            this.pbArvore.TabIndex = 0;
            this.pbArvore.TabStop = false;
            this.pbArvore.Paint += new System.Windows.Forms.PaintEventHandler(this.PbArvore_Paint);
            // 
            // lblCidades
            // 
            this.lblCidades.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCidades.Location = new System.Drawing.Point(6, 15);
            this.lblCidades.Name = "lblCidades";
            this.lblCidades.Size = new System.Drawing.Size(1004, 23);
            this.lblCidades.TabIndex = 1;
            this.lblCidades.Text = "Cidades";
            this.lblCidades.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dlgAbrir
            // 
            this.dlgAbrir.FileName = "Selecione o arquivo correspondente";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 554);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = " Caminho entre Cidades de Marte";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tpRotas.ResumeLayout(false);
            this.tpRotas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMelhorCaminho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaminhos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).EndInit();
            this.tpArvore.ResumeLayout(false);
            this.pnlCidades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbArvore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpRotas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lsbDestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsbOrigem;
        private System.Windows.Forms.PictureBox pbMapa;
        private System.Windows.Forms.TabPage tpArvore;
        private System.Windows.Forms.DataGridView dgvCaminhos;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvMelhorCaminho;
        private System.Windows.Forms.Button btnCarregarCidades;
        private System.Windows.Forms.OpenFileDialog dlgAbrir;
        private System.Windows.Forms.Button btnCarregarCaminhos;
        private System.Windows.Forms.Label lblCidades;
        private System.Windows.Forms.PictureBox pbArvore;
        private System.Windows.Forms.Panel pnlCidades;
    }
}

