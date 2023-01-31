using System;
using HubJogos.BatalhaNaval.Partida;
using HubJogos.BatalhaNaval.Tabuleiro;
using HubJogos.BatalhaNaval.Navio;
using HubJogos.BatalhaNaval.Movimentos;
using HubJogos.BatalhaNaval.Extension;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubJogos.BatalhaNaval.Tabuleiro
{
    public class Tabuleiro
    {
        public Navio.Navio[,] Area { get; set; }
        public List<Navio.Navio> Navios { get; set; }

        private List<HistoricoMovimentos> HistoricoTirosSofridos { get; set; }
        public int NumeroJogador { get; private set; }
    
        public Tabuleiro(List<Navio.Navio> navios, int numeroJogador)
        {
            Area = new Navio.Navio[10, 10];
            NumeroJogador = numeroJogador;
            HistoricoTirosSofridos = new List<HistoricoMovimentos>();
            Navios = navios;
        }

        public void PosicionarNavios()
        {
            foreach (var navio in Navios)
            {
                PosicionarNavios(navio);
            }
        }

        public bool SofrerTiro(int linha, int coluna)
        {
            Console.WriteLine($"[Ataque ao jogador N° {NumeroJogador}]: ");

            if(PosicaoAtingida(linha, coluna))
            {
                Console.WriteLine($"Você já atigiu essa posição ({linha},{coluna})");
                return false;
            
            }

            var navio = Area[linha, coluna];

            if(navio == null)
            {
                Console.WriteLine($"Você atingiu a água!)");
            }
            else
            {
                navio.Atigido();
                Console.WriteLine($"Você atingiu o navio {navio.Nome}!");
            }

            HistoricoTirosSofridos.Add(new HistoricoMovimentos(linha, coluna, navio));
            return true;
        }

        public bool VerificarDerrota()
        {
            return Navios.All(n => n.Afundado);
        }

        public void MostrarHistoricoTirosSofridos()
        {
            foreach(var movimentos in HistoricoTirosSofridos)
            {
                Console.WriteLine(movimentos.ToString());
            }
        }

        public void ExibirPecasInseridasTabuleiro()
        {
            Console.WriteLine("   0   1   2   3   4   5   6   7   8   9   ");
            Console.WriteLine("  -----------------------------------------");
            var formatter = "| {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} |";

            for (var linha = 0; linha < Area.GetLength(0); linha++)
            {
                var args = Enumerable.Range(0, Area.GetLength(1)).Select(coluna => PosicaoAtingida(linha, coluna) 
                ? Area[linha, coluna]?.Sigla.ToString() ?? "." : " ").ToArray();

                Console.WriteLine($"{linha} {string.Format(formatter, args)}");
            }
        }

        public void ExibirPosicoesAtingidasTabuleiro()
        {
            Console.WriteLine("   0   1   2   3   4   5   6   7   8   9   ");
            Console.WriteLine("  -----------------------------------------");
            var formatter = "| {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} |";

            for (var linha = 0; linha < Area.GetLength(0); linha++)
            {
                var args = Enumerable.Range(0, Area.GetLength(1)).Select(coluna => PosicaoAtingida(linha, coluna)
                ? Area[linha, coluna]?.Sigla.ToString() ?? "." 
                : " ").ToArray();

                Console.WriteLine($"{linha} {string.Format(formatter, args)}");
            }
        }

        private bool PosicaoAtingida(int linha, int coluna)
        {
            return HistoricoTirosSofridos.Any(m => m.Comparar(linha, coluna));
        }

        private void PosicionarNavios(Navio.Navio navio)
        {
            while(true)
            {
                Console.WriteLine();
                Console.WriteLine($"Vez do jogador N° {NumeroJogador}");
                Console.WriteLine();
                Console.WriteLine($"Navio: {navio.Nome}");
                Console.WriteLine($"Tamanho: {navio.ComprimentoTotal}");
                ExibirPecasInseridasTabuleiro();

                var (linhaInicio, colunaInicio) = ConsoleExtensions.LerLinhaColuna("Linha/coluna iniciais:");
                var (linhaFinal, colunaFinal) = ConsoleExtensions.LerLinhaColuna("Linha/coluna finais:");
                Console.Clear();

                (linhaInicio, linhaFinal) = linhaInicio > linhaFinal ? (linhaFinal, linhaInicio) : (linhaInicio, linhaFinal);
                (colunaInicio, colunaFinal) = colunaInicio > colunaFinal ? (colunaFinal, colunaInicio) : (colunaInicio, colunaFinal);

                if(linhaInicio != linhaFinal && colunaInicio != colunaFinal)
                {
                    Console.WriteLine("O navio não pode estar na diagonal!");
                    continue;
                }

                if(linhaInicio == linhaFinal && colunaInicio == colunaFinal)
                {
                    Console.WriteLine("As posições de Inicio e Fim não podem ser iguais!");
                    continue;
                }

                if(linhaInicio >= Area.GetLength(0) || linhaFinal >= Area.GetLength(0)
                    || linhaInicio < 0 || linhaFinal < 0
                    || colunaInicio >= Area.GetLength(1) || colunaFinal >= Area.GetLength(1)
                    || colunaInicio < 0 || colunaFinal < 0)
                {
                    Console.WriteLine("Posição inválida!");
                    continue;
                }
                
                if(colunaInicio != colunaFinal && (colunaFinal - colunaInicio + 1) != navio.ComprimentoTotal
                    || linhaInicio != linhaFinal && (linhaFinal - linhaInicio + 1) != navio.ComprimentoTotal)
                {
                    Console.WriteLine("O navio não se encaixa nesta posição!");
                    continue;
                }

                var posicoes = new List<(int linha, int coluna)>();

                for (var linha = linhaInicio; linha <= linhaFinal; linha++)
                {
                    for (var coluna = colunaInicio; coluna <= colunaFinal; coluna++)
                    {
                        posicoes.Add((linha, coluna));
                    }
                }

                if(posicoes.Any(p => Area[p.linha, p.coluna] != null))
                {
                    Console.WriteLine("O navio não pode colidir com outro.");
                    continue;
                }

                foreach (var posicao in posicoes)
                {
                    Area[posicao.linha, posicao.coluna] = navio;
                }
                return;
            }
        }
    }
}