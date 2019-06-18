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
        IStack<Cidade> caminho;

        List<IStack<Cidade>> caminhos;
        List<int> distancias;


        public Matriz(Arvore<Cidade> cidades, List<Caminho> caminhosPossiveis)
        {
            matrizDeAdjacencias = new int[cidades.QuantosDados, cidades.QuantosDados];

            this.cidades = new List<Cidade>();

            InserirCidade(cidades.Raiz);
            foreach (Caminho c in caminhosPossiveis)
                matrizDeAdjacencias[c.IdCidadeOrigem, c.IdCidadeDestino] = c.Distancia;
        }
        private void InserirCidade(NoArvore<Cidade> no)
        {
            if (no == null)
                return;

            InserirCidade(no.Esq);
            cidades.Add(no.Info);
            InserirCidade(no.Dir);
        }
        public void ProcurarCaminhos(int origem, int destino)
        {
            Preparar();
            AcharCaminhos(origem, destino, 0);
        }
        private void Preparar()
        {
            foreach (Cidade c in cidades)
                c.FoiVisitado = false;
            caminhos = new List<IStack<Cidade>>();
            caminho = new PilhaLista<Cidade>();
            distancias = new List<int>();
        }
        private void AcharCaminhos(int origem, int destino, int distanciaAcumulada) //origem == idCidadeOrigem || destino == idCidadeDestino 
        {
            var cidadeOrigem = cidades.Find(c => c.IdCidade == origem);
            cidadeOrigem.FoiVisitado = true;

            if (origem != destino)
            {
                for (int coluna = 0; coluna < cidades.Count; coluna++)
                {
                    if (!(matrizDeAdjacencias[origem, coluna] == 0 || cidades.Find(c => c.IdCidade == coluna).FoiVisitado))
                    {
                        //distancias[caminhos.Count] += matrizDeAdjacencias[origem, coluna];  //calcula a distância entre os caminhos até achar o destino
                        if (caminho.EstaVazia() || caminho.OTopo().IdCidade != origem)
                            caminho.Empilhar(cidadeOrigem);
                        AcharCaminhos(coluna, destino, distanciaAcumulada + matrizDeAdjacencias[origem, coluna]);
                        caminho.Desempilhar();
                    }
                }
            }
            else
            {
                caminho.Empilhar(cidades.Find(c => c.IdCidade == destino));

                var caminho2 = new PilhaLista<Cidade>();
                var aux = new PilhaLista<Cidade>();

                while (!caminho.EstaVazia())
                {
                    caminho2.Empilhar(caminho.OTopo());
                    aux.Empilhar(caminho.Desempilhar());
                }
                caminhos.Add(caminho2);

                caminho = new PilhaLista<Cidade>();
                while (!aux.EstaVazia())
                    caminho.Empilhar(aux.Desempilhar());

                distancias.Add(distanciaAcumulada);
            }
        }

        public int[,] MatrizDeAdjacencias { get => matrizDeAdjacencias; set => matrizDeAdjacencias = value; }
        public int Origem { get => origem; set => origem = value; }
        public int Destino { get => destino; set => destino = value; }
        public int Distancia { get => distancia; set => distancia = value; }
        public List<IStack<Cidade>> Caminhos { get => caminhos; set => caminhos = value; }
        public IStack<Cidade> MelhorCaminho
        {
            get
            {
                int menorDistancia = int.MaxValue, 
                    indiceMenorDistancia = -1;

                for (int i = 0; i < distancias.Count; i++)
                    if (distancias[i] < menorDistancia)
                    {
                        menorDistancia = distancias[i];
                        indiceMenorDistancia = i;
                    }

                return caminhos[indiceMenorDistancia];
            }
        }
    }
}
