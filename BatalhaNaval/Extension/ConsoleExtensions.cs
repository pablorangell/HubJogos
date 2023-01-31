using System;
using HubJogos.BatalhaNaval.Partida;
using HubJogos.BatalhaNaval.Tabuleiro;
using HubJogos.BatalhaNaval.Navio;
using HubJogos.BatalhaNaval.Movimentos;
using HubJogos.BatalhaNaval.Extension;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubJogos.BatalhaNaval.Extension
{
    public class ConsoleExtensions
    {
        public static (int linha, int coluna) LerLinhaColuna(string exibicao)
        {
            while(true)
            {
                try
                {
                    Console.WriteLine(exibicao);
                    var split = Console.ReadLine().Split(',');
                    var linha = int.Parse(split[0]);
                    var coluna = int.Parse(split[1]);
                    return (linha, coluna);
                }
                catch(Exception)
                {
                    Console.WriteLine("Linha e Coluna inválidas. Tente novamente.");
                    continue;
                }
            }
        }
    }
}