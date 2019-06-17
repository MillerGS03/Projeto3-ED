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

        public void acharCaminho(int origem, int destino) 
        {
            int coluna = 0;
            if(origem != destino)             
                if(matrizDeAdjacencias[origem, coluna] == 0)
                    coluna++;
                else
                {
                    origem = coluna;
                    //guardar o caminho na pilha
                    acharCaminho(origem, destino);
                }
            
        }

        public int[,] MatrizDeAdjacencias { get => matrizDeAdjacencias; set => matrizDeAdjacencias = value; }
        public int Origem { get => origem; set => origem = value; }
        public int Destino { get => destino; set => destino = value; }
        public int Distancia { get => distancia; set => distancia = value; }
    }
}
