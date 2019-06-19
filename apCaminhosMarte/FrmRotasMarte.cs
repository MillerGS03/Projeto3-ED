// Diego Henrique Raul Silva - 17169
// Gustavo Miller Santos     - 18179

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace apCaminhosMarte
{
    public partial class FrmRotasMarte : Form
    {
        private Arvore<Cidade> cidades;
        private List<Caminho> caminhos;
        private Matriz grafo;

        public FrmRotasMarte()
        {
            InitializeComponent();

            cidades = new Arvore<Cidade>();
            caminhos = new List<Caminho>();
            pontosAUnir = new List<Point>();
            fonteCidades = lblCidades.Font;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (lsbOrigem.SelectedIndex == -1 || lsbDestino.SelectedIndex == -1)
                MessageBox.Show("Selecione as cidades de origem e destino!");
            else
            {
                grafo.ProcurarCaminhos(lsbOrigem.SelectedIndex, lsbDestino.SelectedIndex);

                dgvCaminhos.RowCount = grafo.Caminhos.Count;
                dgvMelhorCaminho.RowCount = (dgvCaminhos.RowCount > 0 ? 1 : 0);
                var melhorCaminho = grafo.MelhorCaminho;

                pontosAUnir = new List<Point>();

                for (int i = 0; i < grafo.Caminhos.Count; i++)
                {
                    PilhaLista<Cidade> aux = new PilhaLista<Cidade>();

                    for (int j = 0; !grafo.Caminhos[i].EstaVazia(); j++)
                    {
                        if (grafo.Caminhos[i] == melhorCaminho) // Coloca os nomes das cidades no DataGridView de melhor caminho
                        {
                            var cidade = grafo.Caminhos[i].OTopo();

                            if (dgvMelhorCaminho.ColumnCount < j + 1) // Aumenta a quantidade de colunas no DataGridView de melhor caminho se necessário
                                dgvMelhorCaminho.ColumnCount = j + 1;

                            dgvMelhorCaminho.Rows[0].Cells[j].Value = cidade.NomeCidade;
                        }

                        if (dgvCaminhos.ColumnCount < j + 1) // Aumenta a quantidade de colunas no DataGridView de caminhos se necessário
                            dgvCaminhos.ColumnCount = j + 1;

                        dgvCaminhos.Rows[i].Cells[j].Value = grafo.Caminhos[i].OTopo().NomeCidade;
                        aux.Empilhar(grafo.Caminhos[i].Desempilhar());
                    }
                    while (!aux.EstaVazia()) // Restaura a pilha do caminho, para que possa ser reutilizada
                        grafo.Caminhos[i].Empilhar(aux.Desempilhar());
                }

                AtualizarPontosAUnir();
                pbArvore.Invalidate();

                if (grafo.Caminhos.Count == 0)
                    MessageBox.Show("Não há caminhos!");
            }
        }

        private void btnCarregarCidades_Click(object sender, EventArgs e)
        {
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(dlgAbrir.FileName, Encoding.Default);
                while (!sr.EndOfStream)
                {
                    var registro = sr.ReadLine();
                    if (registro.TrimEnd().Length == 28)
                        cidades.Incluir(new Cidade(registro));
                }
                sr.Close();
                btnCarregarCidades.Enabled = false;
                btnCarregarCaminhos.Enabled = true;

                lsbDestino.Items.Clear();
                lsbOrigem.Items.Clear();

                ColocarNasListboxes(cidades.Raiz);
                fonteCidades = new Font(fonteCidades.FontFamily, (float)Width / 130, FontStyle.Bold);

                pbMapa.Invalidate();
            }
        }
        private void ColocarNasListboxes(NoArvore<Cidade> no)
        {
            if (no == null)
                return;
            ColocarNasListboxes(no.Esq);

            string item = no.Info.IdCidade + " - " + no.Info.NomeCidade;
            lsbOrigem.Items.Add(item);
            lsbDestino.Items.Add(item);

            ColocarNasListboxes(no.Dir);
        }
        private void PbArvore_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            int profundidade = DesenharArvore(cidades.Raiz, 0, 0, -1, -1, g); // Método recursivo retorna a profundidade da árvore
            pbArvore.MinimumSize = new Size((int)Math.Pow(2, profundidade) * tamanhoNos, (profundidade + 1) * (tamanhoNos + margemY));

            if (pbArvore.MinimumSize.Width < pnlCidades.Width)
                pbArvore.MinimumSize = new Size(pnlCidades.Width - 3, pbArvore.MinimumSize.Height); // Se o PictureBox poderia ser maior, seu tamanho é aumentado
        }
        SolidBrush brush = new SolidBrush(Color.White);
        Pen pen = new Pen(Color.Black, 2);
        int tamanhoNos = 50, margemY = 50;

        private void PnlCidades_Resize(object sender, EventArgs e)
        {
            pbArvore.Refresh();
        }

        private void btnCarregarCaminhos_Click(object sender, EventArgs e)
        {
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(dlgAbrir.FileName, Encoding.Default);
                while (!sr.EndOfStream)
                {
                    var registro = sr.ReadLine();
                    if (registro.TrimEnd().Length == 20)
                        caminhos.Add(new Caminho(registro));
                }
                sr.Close();

                grafo = new Matriz(cidades, caminhos);

                btnCarregarCaminhos.Enabled = false;
                btnBuscar.Enabled = true;
            }
        }

        private void pbMapa_Paint(object sender, PaintEventArgs e)
        {
            if (cidades.QuantosDados > 0)
                DesenharCidades(cidades.Raiz, e.Graphics);
        }

        Font fonteCidades;
        List<Point> pontosAUnir;
        private void DesenharCidades(NoArvore<Cidade> no, Graphics g)
        {
            if (no == null)
                return;

            DesenharCidades(no.Esq, g);
            DesenharCidades(no.Dir, g);

            float proporcaoX = (float)pbMapa.Width / 4096;
            float proporcaoY = (float)pbMapa.Height / 2048;

            int x = Convert.ToInt32(no.Info.X * proporcaoX);
            int y = Convert.ToInt32(no.Info.Y * proporcaoY);

            brush.Color = Color.Black;
            g.FillEllipse(brush, x - 3, y - 3, 6, 6);

            int tamanhoString = Convert.ToInt32(g.MeasureString(no.Info.NomeCidade, fonteCidades).Width);
            g.DrawString(no.Info.NomeCidade, fonteCidades, brush, x - tamanhoString / 2, y - 25);

            for (int i = 0; i < pontosAUnir.Count - 1; i++)
                g.DrawLine(pen, pontosAUnir[i].X * proporcaoX, pontosAUnir[i].Y * proporcaoY,
                           pontosAUnir[i + 1].X * proporcaoX, pontosAUnir[i + 1].Y * proporcaoY);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            fonteCidades = new Font(fonteCidades.FontFamily, (float)Width / 130, FontStyle.Bold);
        }

        private void AtualizarPontosAUnir()
        {
            pontosAUnir.Clear();

            if (dgvCaminhos.SelectedRows.Count != 0 && dgvCaminhos.SelectedRows[0].Index <= grafo.Caminhos.Count)
            {
                var caminho = grafo.Caminhos[dgvCaminhos.SelectedRows[0].Index];

                var aux = new PilhaLista<Cidade>();
                while (!caminho.EstaVazia())
                {
                    var cidade = caminho.OTopo();
                    pontosAUnir.Add(new Point(cidade.X, cidade.Y));
                    aux.Empilhar(caminho.Desempilhar());
                }

                while (!aux.EstaVazia())
                    caminho.Empilhar(aux.Desempilhar());
            }

            pbMapa.Invalidate();
        }
        private void dgvCaminhos_SelectionChanged(object sender, EventArgs e)
        {
            AtualizarPontosAUnir();
        }

        private void dgvMelhorCaminho_SelectionChanged(object sender, EventArgs e)
        {
            pontosAUnir.Clear();

            var caminho = grafo.MelhorCaminho;

            if (caminho != null)
            {
                var aux = new PilhaLista<Cidade>();
                while (!caminho.EstaVazia())
                {
                    var cidade = caminho.OTopo();
                    pontosAUnir.Add(new Point(cidade.X, cidade.Y)); 
                    aux.Empilhar(caminho.Desempilhar());
                }

                while (!aux.EstaVazia()) // Restaura a pilha para que possa ser reutilizada
                    caminho.Empilhar(aux.Desempilhar());
            }
            pbMapa.Invalidate();
        }

        private int DesenharArvore(NoArvore<Cidade> no, int profundidade, int posicao, int xPai, int yPai, Graphics g)
        {
            if (no == null)
                return profundidade - 1;

            int tot = (int)Math.Pow(2, profundidade); // Total de posições naquele nível
            int x = Convert.ToInt32((pbArvore.Width / tot) * (posicao + 0.5)) - tamanhoNos / 2; // Posição x é baseada na posição naquele nível e no tamanho da picture box.
            int y = margemY + profundidade * (tamanhoNos + margemY); // Posição y é baseada na profundidade, no tamanho do nó e na margem entre nós

            // Círculo do nó
            brush.Color = Color.White;
            g.FillEllipse(brush, x, y, tamanhoNos, tamanhoNos);
            g.DrawEllipse(pen, x, y, tamanhoNos, tamanhoNos);

            // Ligação entre o nó e seu pai
            if (xPai != -1 && yPai != -1) // Desenha apenas se não for a raiz
                g.DrawLine(pen, x + tamanhoNos / 2, y, xPai + tamanhoNos / 2, yPai + tamanhoNos);

            // Nome da cidade
            g.DrawString(no.Info.NomeCidade, lblCidades.Font, brush, x + (tamanhoNos - g.MeasureString(no.Info.NomeCidade, lblCidades.Font).Width) / 2, y - 22);

            // Id da cidade
            brush.Color = Color.Black;
            SizeF tamanhoId = g.MeasureString(no.Info.IdCidade.ToString(), lblCidades.Font);
            g.DrawString(no.Info.IdCidade.ToString(), lblCidades.Font, brush, x + (tamanhoNos - tamanhoId.Width) / 2, y + (tamanhoNos - tamanhoId.Height) / 2);

            // Filhos
            int profMaximaEsq = DesenharArvore(no.Esq, profundidade + 1, posicao * 2, x, y, g);
            int profMaximaDir = DesenharArvore(no.Dir, profundidade + 1, posicao * 2 + 1, x, y, g);

            if (profMaximaEsq > profMaximaDir)
                return profMaximaEsq;
            return profMaximaDir;
        }
    }
}
