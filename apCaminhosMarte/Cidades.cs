using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCaminhosMarte
{
    class Cidades
    {
        private int idCidade, x, y;
        private string nomeCidade;

        public string NomeCidade { get => nomeCidade; set => nomeCidade = value; }
        public int IdCidade { get => idCidade; set => idCidade = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Cidades(int id, string nome, int coordenadaX, int coordenadaY)
        {
            this.idCidade = id;
            this.x = coordenadaX;
            this.y = coordenadaY;
            this.nomeCidade = nome;
        }
    }
}
