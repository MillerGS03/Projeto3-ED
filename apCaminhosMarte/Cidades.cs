using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCaminhosMarte
{
    class Cidades : IComparable<Cidades>
    {
        private int idCidade, x, y;
        private string nomeCidade;

        public string NomeCidade { get => nomeCidade; set => nomeCidade = value; }
        public int IdCidade { get => idCidade; set => idCidade = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Cidades() { }

        public Cidades(string linha)
        {
            idCidade = int.Parse(linha.Substring(0, 3));
            nomeCidade = linha.Substring(3, 18);
            x = int.Parse(linha.Substring(18, 23));
            y = int.Parse(linha.Substring(23, 28));  //Especifíca a localização de cada um nas posições de leitura
        }

        public int CompareTo(Cidades other)
        {
            throw new NotImplementedException();
        }
    }
}
