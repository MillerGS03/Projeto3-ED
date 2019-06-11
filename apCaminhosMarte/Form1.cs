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
        private Arvore<Cidade> arvore;

        public Form1()
        {
            InitializeComponent();

            arvore = new Arvore<Cidade>();
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
                    arvore.Incluir(new Cidade(sr.ReadLine()));  //Insere os dados do arquivo no objeto cidade
                sr.Close();
                //NoArvore<Cidade> primeiroNo = null;
                //InserirVetorEmArvore(0, quantosDados - 1, ref primeiroNo);
                //arvore.Raiz = primeiroNo;
            }
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
