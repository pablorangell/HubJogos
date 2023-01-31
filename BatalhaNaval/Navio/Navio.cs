using System;
using HubJogos.BatalhaNaval.Partida;
using HubJogos.BatalhaNaval.Tabuleiro;
using HubJogos.BatalhaNaval.Navio;
using HubJogos.BatalhaNaval.Movimentos;
using HubJogos.BatalhaNaval.Extension;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubJogos.BatalhaNaval.Navio
{
    public class Navio
    {
                public int ComprimentoTotal { get; private set; }
        public int TotalAtingido { get; private set; }
        public string Nome { get; set; }
        public char Sigla { get; set; }
        public Navio(int comprimentoTotal, string nome, char sigla)
        {
            ComprimentoTotal = comprimentoTotal;
            Nome = nome;
            Sigla = sigla;
        }

        public bool Afundado => ComprimentoTotal == TotalAtingido;


        public void Atigido()
        {
            if(Afundado)
                return;

            TotalAtingido++;

                Console.WriteLine($"Você {(Afundado ? "afundou" : "atigiu")} um {Nome}");
        }

    }
    
}