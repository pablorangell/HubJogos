using System;
using HubJogos.BatalhaNaval.Partida;
using HubJogos.BatalhaNaval.Tabuleiro;
using HubJogos.BatalhaNaval.Navio;
using HubJogos.BatalhaNaval.Movimentos;
using HubJogos.BatalhaNaval.Extension;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubJogos.BatalhaNaval.Movimentos
{
    public class HistoricoMovimentos
    {
        public int Linha { get; private set; }
        public int Coluna { get; private set; }

        public string Nome { get; private set; }
        public bool Sucedido { get; private set; }
        public bool Atingido { get; private set; }

        public HistoricoMovimentos(int linha, int coluna, Navio.Navio navio = null)
        {
            Linha = linha;
            Coluna = coluna;

            Nome = navio?.Nome;
            Atingido = navio?.Afundado ?? false;
            Sucedido = navio != null;
        }

        public bool Comparar(int linha, int coluna)
        {
            return Linha == linha && Coluna == coluna;
        }


        public override string ToString()
        {
            if(!Sucedido)
                return $"Não sucedido ({Linha},{Coluna})";

            if(Atingido)
                return $"Sucedido ({Linha},{Coluna}) - Afundou {Nome}";

                return $"Sucedido ({Linha},{Coluna}) - Atingiu {Nome}";
        }
    }
}