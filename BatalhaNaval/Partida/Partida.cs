using System;
using HubJogos.BatalhaNaval.Partida;
using HubJogos.BatalhaNaval.Tabuleiro;
using HubJogos.BatalhaNaval.Navio;
using HubJogos.BatalhaNaval.Movimentos;
using HubJogos.BatalhaNaval.Extension;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubJogos.BatalhaNaval.Partida
{
    public class Partida
    {
        public Tabuleiro.Tabuleiro Jogador1 { get; set; }
        public Tabuleiro.Tabuleiro Jogador2 { get; set; }
        public int VezJogador { get; set; }

        public Tabuleiro.Tabuleiro JogadorAtual => VezJogador == Jogador1.NumeroJogador ? Jogador1 : Jogador2;

        public Tabuleiro.Tabuleiro JogadorOponente => VezJogador == Jogador1.NumeroJogador ? Jogador2 : Jogador1;

        public Partida()
        {
            Jogador1 = new Tabuleiro.Tabuleiro(ObterNavios(), 1);
            Jogador2 = new Tabuleiro.Tabuleiro(ObterNavios(), 2);
            VezJogador = Jogador1.NumeroJogador;
        }

        public void Jogar()
        {
            Jogador1.PosicionarNavios();
            Console.Clear();
            Jogador2.PosicionarNavios();

            while(true)
            {
                Console.WriteLine();
                Console.WriteLine($"Vez do jogador N° {VezJogador}");

                Console.WriteLine("Seu tabuleiro:");
                JogadorAtual.ExibirPosicoesAtingidasTabuleiro();

                Console.WriteLine("Tabuleiro do oponente:");
                JogadorOponente.ExibirPosicoesAtingidasTabuleiro();

                var (linha, coluna) = ConsoleExtensions.LerLinhaColuna("Linha e Coluna para atacar o oponente:");
                Console.Clear();
                var tiroValido = JogadorOponente.SofrerTiro(linha, coluna);

                if(JogadorOponente.VerificarDerrota())
                {
                    ProcessarFimDoJogo();
                    return;
                }

                if(tiroValido)
                {
                    MudarVez();
                }
            }
        }

        private void ProcessarFimDoJogo()
        {
            Console.WriteLine("Fim de jogo!");
            Console.WriteLine($"O jogador N° {VezJogador} venceu!");

            Console.WriteLine();
            Console.WriteLine("Jogador 1:");
            Jogador1.ExibirPecasInseridasTabuleiro();
            Console.WriteLine();
            Console.WriteLine("Após ataques: ");
            Jogador1.ExibirPosicoesAtingidasTabuleiro();
            Console.WriteLine();
            Console.WriteLine("Movimentos realizados:");
            Jogador2.MostrarHistoricoTirosSofridos();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Jogador 2:");
            Jogador2.ExibirPecasInseridasTabuleiro();
            Console.WriteLine();
            Console.WriteLine("Após ataques: ");
            Jogador2.ExibirPosicoesAtingidasTabuleiro();
            Console.WriteLine();
            Console.WriteLine("Movimentos realizados:");
            Jogador1.MostrarHistoricoTirosSofridos();

            Console.SetCursorPosition(0, 0);
        }

        private List<Navio.Navio> ObterNavios()
        {
            return new List<Navio.Navio>
            {
                new Navio.Navio(5, "PORTA-AVIÕES", 'P'),
                new Navio.Navio(4, "ENCOURAÇADO", 'E'),
                new Navio.Navio(3,"SUBMARINO", 'S'),
                new Navio.Navio(3, "DESTROYER", 'D'),
                new Navio.Navio(2, "BARCO DE PATRULHA", 'B')
            };
        }

        private void MudarVez()
        {
            VezJogador = VezJogador == Jogador1.NumeroJogador 
            ? Jogador2.NumeroJogador 
            : Jogador1.NumeroJogador;
        }
    }
}