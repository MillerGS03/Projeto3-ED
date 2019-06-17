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
        int[] caminhos;
        IStack<int> caminho;
        IStack<int> caminho2;
        bool[,] passouCidade;

        public Matriz(int tamanho)
        {
            matrizDeAdjacencias = new int[tamanho, tamanho];
        }

        public void inserirNaMatriz(int origem, int destino, int distancia)
        {
            MatrizDeAdjacencias[origem, destino] = distancia;
        }

        public void acharCaminhos(int origem, int destino) //origem == idCidadeOrigem || destino == idCidadeDestino 
        {
            int coluna = 0;  //teste de disponibilidade de caminhos
            if (origem != destino)
                if (matrizDeAdjacencias[origem, coluna] == 0)
                    coluna++;
                else
                {
                    passouCidade[origem, coluna] = true;
                    distancia += matrizDeAdjacencias[origem, coluna];  //calcula a distância entre os caminhos até achar o destino
                    caminho.Empilhar(origem);
                    origem = coluna;
                    acharCaminhos(origem, destino);
                }
            caminho.Empilhar(destino);
            while (!caminho.EstaVazia())
            {
                caminho2.Empilhar(caminho.Desempilhar());
            }
            while (!caminho2.EstaVazia())
            {
                int i = 0;
                caminhos[i] = caminho2.Desempilhar();
            }
        }

        public int[,] MatrizDeAdjacencias { get => matrizDeAdjacencias; set => matrizDeAdjacencias = value; }
        public int Origem { get => origem; set => origem = value; }
        public int Destino { get => destino; set => destino = value; }
        public int Distancia { get => distancia; set => distancia = value; }
    }
}
