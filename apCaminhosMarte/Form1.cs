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
        private Cidades[] cidade = new Cidades[20];   //Número de cidades no arquivo
        private int quantosDados;
        private Arvore<Cidades> arvore;

        public Form1()
        {
            InitializeComponent();
            arvore = new Arvore<Cidades>();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Buscar caminhos entre cidades selecionadas");
        }

        private void btnCarregarCidades_Click(object sender, EventArgs e)
        {
            if(dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(dlgAbrir.FileName);
                while (!sr.EndOfStream)
                    cidade[quantosDados] = new Cidades(sr.ReadLine());  //Insere os dados do arquivo no objeto cidade
                ordenarCidades();
                sr.Close();
                NoArvore<Cidades> primeiroNo = null;
                inserirVetorEmArvore(0, quantosDados - 1, ref primeiroNo);
                arvore.Raiz = primeiroNo;
            }
        }

        void inserirVetorEmArvore(int inicio, int fim, ref NoArvore<Cidades> noAtual)
        {
            if (inicio > fim)
                noAtual = null;
            else
            {
                int meio = (inicio + fim) / 2;
                noAtual = new NoArvore<Cidades>(cidade[meio], null, null);
                NoArvore<Cidades> esquerda = null;
                inserirVetorEmArvore(inicio, meio - 1, ref esquerda);
                noAtual.Esq = esquerda;
                NoArvore<Cidades> direita = null;
                inserirVetorEmArvore(meio + 1, fim, ref direita);
                noAtual.Dir = direita;
            }
        }

        private void ordenarCidades()
        {
            int k, j, aux;
            Cidades[] aux2 = new Cidades[20];  //auxiliar armazenamento do valor a ser mudado de posição
            k = 1;
            while (k<20)
            {
                aux = cidade[k].IdCidade;
                aux2[0] = cidade[k];
                j = k - 1;
                while(j>=0 && aux < cidade[j].IdCidade)  //Ordenar o vetor de cidades para poder inserir na árvore sem problemas
                {
                    cidade[j + 1] = cidade[j];
                    j--;
                }
                cidade[j + 1] = aux2[0];
                k++;
            } 
        }
    }
}
