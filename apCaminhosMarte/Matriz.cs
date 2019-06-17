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
        IStack<int> caminho;

        public Matriz(int origem, int destino, int distancia)
        {
            Origem = origem;
            Destino = destino;
            Distancia = distancia;
        }

        public void inserirNaMatriz()
        {
            MatrizDeAdjacencias[origem, destino] = distancia;
        }

        public void acharCaminhos(int origem, int destino) //origem == idCidadeOrigem || destino == idCidadeDestino 
        {
            int coluna = 0;  //teste de disponibilidade de caminhos
            if(origem != destino)             
                if(matrizDeAdjacencias[origem, coluna] == 0)
                    coluna++;
                else
                {
                    distancia += matrizDeAdjacencias[origem, coluna];  //calcula a distância entre os caminhos até achar o destino
                    origem = coluna;
                    caminho.Empilhar(origem);
                    acharCaminhos(origem, destino);
                }
            
        }

        public int[,] MatrizDeAdjacencias { get => matrizDeAdjacencias; set => matrizDeAdjacencias = value; }
        public int Origem { get => origem; set => origem = value; }
        public int Destino { get => destino; set => destino = value; }
        public int Distancia { get => distancia; set => distancia = value; }
    }
}
