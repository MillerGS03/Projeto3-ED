using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCaminhosMarte
{
    class Matriz
    {
        int[,] matrizDeAdjacencias;
        int origem, destino, distancia;
        List<Cidade> cidades;
        IStack<int> caminho;

        List<IStack<int>> caminhos;
        List<int> distancias;


        public Matriz(int tamanho, Arvore<Cidade> cidades)
        {
            matrizDeAdjacencias = new int[tamanho, tamanho];

            this.cidades = new List<Cidade>();

            caminhos = new List<IStack<int>>();
            caminho = new PilhaLista<int>();
            distancias = new List<int>();

            InserirCidade(cidades.Raiz);
        }
        private void InserirCidade(NoArvore<Cidade> no)
        {
            if (no == null)
                return;

            InserirCidade(no.Esq);

            cidades.Add(no.Info);

            InserirCidade(no.Dir);
        }

        public void inserirNaMatriz(int origem, int destino, int distancia)
        {
            MatrizDeAdjacencias[origem, destino] = distancia;
        }
        public void ProcurarCaminhos(int origem, int destino)
        {
            AcharCaminhos(origem, destino, 0);
        }
        private void AcharCaminhos(int origem, int destino, int distanciaAcumulada) //origem == idCidadeOrigem || destino == idCidadeDestino 
        {
            cidades.Find(c => c.IdCidade == origem).FoiVisitado = true;

            if (origem != destino)
            {
                for (int coluna = 0; coluna < cidades.Count; coluna++)
                {
                    if (!(matrizDeAdjacencias[origem, coluna] == 0 || cidades.Find(c => c.IdCidade == coluna).FoiVisitado))
                    {
                        //distancias[caminhos.Count] += matrizDeAdjacencias[origem, coluna];  //calcula a distância entre os caminhos até achar o destino
                        if (caminho.EstaVazia() || caminho.OTopo() != origem)
                            caminho.Empilhar(origem);
                        AcharCaminhos(coluna, destino, distanciaAcumulada + matrizDeAdjacencias[origem, coluna]);
                        caminho.Desempilhar();
                    }
                }
            }
            else
            {
                caminho.Empilhar(destino);

                var caminho2 = new PilhaLista<int>();
                var aux = new PilhaLista<int>();

                while (!caminho.EstaVazia())
                {
                    caminho2.Empilhar(caminho.OTopo());
                    aux.Empilhar(caminho.Desempilhar());
                }
                caminhos.Add(caminho2);

                caminho = new PilhaLista<int>();
                while (!aux.EstaVazia())
                    caminho.Empilhar(aux.Desempilhar());

                distancias.Add(distanciaAcumulada);
            }
        }

        public int[,] MatrizDeAdjacencias { get => matrizDeAdjacencias; set => matrizDeAdjacencias = value; }
        public int Origem { get => origem; set => origem = value; }
        public int Destino { get => destino; set => destino = value; }
        public int Distancia { get => distancia; set => distancia = value; }
        public List<IStack<int>> Caminhos { get => caminhos; set => caminhos = value; }
    }
}
