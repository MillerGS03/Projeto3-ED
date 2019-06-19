// Diego Henrique Raul Silva - 17169
// Gustavo Miller Santos     - 18179

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCaminhosMarte
{
    public class Caminho
    {
        public Caminho(int idCidadeOrigem, int idCidadeDestino, int distancia, int tempo, int custo)
        {
            IdCidadeOrigem = idCidadeOrigem;
            IdCidadeDestino = idCidadeDestino;
            Distancia = distancia;
            Tempo = tempo;
            Custo = custo;
        }
        public Caminho(string registro)
        {
            IdCidadeOrigem = int.Parse(registro.Substring(0, 3));
            IdCidadeDestino = int.Parse(registro.Substring(3, 3));
            Distancia = int.Parse(registro.Substring(6, 5));
            Tempo = int.Parse(registro.Substring(11, 4));
            Custo = int.Parse(registro.Substring(15));
        }
        public int IdCidadeOrigem { get; set; }
        public int IdCidadeDestino { get; set; }
        public int Distancia { get; set; }
        public int Tempo { get; set; }
        public int Custo { get; set; }
    }
}
