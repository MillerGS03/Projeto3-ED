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
    public partial class Form1 : Form
    {
        //private Cidade[] cidade = new Cidade[23];   //Número de cidades no arquivo
        //private int quantosDados;
        private Arvore<Cidade> cidades;
        private List<Caminho> caminhos;
        private bool[,] adjacencia;
        int[,] matrizAdjacencias;

        public Form1()
        {
            InitializeComponent();

            cidades = new Arvore<Cidade>();
            caminhos = new List<Caminho>();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Buscar caminhos entre cidades selecionadas");
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
            }
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

                adjacencia = new bool[cidades.QuantosDados, cidades.QuantosDados];
                while (!sr.EndOfStream)
                {
                    var registro = sr.ReadLine();
                    if (registro.TrimEnd().Length == 20)
                    {
                        var novoCaminho = new Caminho(registro);
                        adjacencia[novoCaminho.IdCidadeOrigem, novoCaminho.IdCidadeDestino] = true;
                        caminhos.Add(novoCaminho);
                    }
                }
                foreach(Caminho c in caminhos)
                {
                    matrizAdjacencias[c.IdCidadeOrigem, c.IdCidadeDestino] = c.Distancia;  //Cria a matriz com as distâncias 
                                                                                           //entre cidades
                }
                sr.Close();
                btnCarregarCaminhos.Enabled = false;
            }
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
        /*
void InserirVetorEmArvore(int inicio, int fim, ref NoArvore<Cidade> noAtual)
{
   if (inicio > fim)
       noAtual = null;
   else
   {
       int meio = (inicio + fim) / 2;
       noAtual = new NoArvore<Cidade>(cidade[meio], null, null);
       NoArvore<Cidade> esquerda = null;
       InserirVetorEmArvore(inicio, meio - 1, ref esquerda);
       noAtual.Esq = esquerda;
       NoArvore<Cidade> direita = null;
       InserirVetorEmArvore(meio + 1, fim, ref direita);
       noAtual.Dir = direita;
   }
}*/
    }
}
