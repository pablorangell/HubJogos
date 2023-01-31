using System;
using HubJogos.JogoDaVelha;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubJogos.JogoDaVelha.Game
{
    public class Game
    {
        public List<Player.Player> Players = new List<Player.Player>();
        public Peca.Peca[,] Peca {get;set;}

        public void CriarGame()
        {
            Peca = new Peca.Peca[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Peca[i, j] = new Peca.Peca();
                }
            }
        }

        private void Imprimir()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Peca[i, j].Verifica() == 0)
                    {
                        Console.Write(" - ");
                    }
                    else if (Peca[i, j].Verifica() == 1)
                    {
                        Console.Write(" O ");
                    }
                    else if (Peca[i, j].Verifica() == 2)
                    {
                        Console.Write(" X ");
                    }

                }
                Console.WriteLine();
            }
        }

        public void Jogar()
        {

            var player1 = CriarPlayer(new Peca.Circulo());
            Players.Add(player1);
            var player2 = CriarPlayer(new Peca.Xis());
            Players.Add(player2);
            Console.Clear();
            Imprimir();

            var jogadas = 1;
            while(true)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.WriteLine($"{i}, {j} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                if(jogadas == 10)
                {
                    Console.WriteLine("Deu velha!");
                    break;
                }

                var playerAtual = jogadas % 2 == 0 ? 1 : 0;
                Console.WriteLine($"Vez de {Players[playerAtual].Nome} jogar.");
                Console.WriteLine("Digite a posição:");
                string posicao = Console.ReadLine();
                int coluna = Convert.ToInt16(posicao.Substring(0, 1));
                int linha = Convert.ToInt16(posicao.Substring(2));

                if (VerificarPosicao(coluna, linha))
                {
                    Console.Clear();
                    GerarPeca(coluna, linha, Players[playerAtual].PecaEscolhida);
                    Imprimir();
                    jogadas++;
                }

                if(VerificarVitoriaLinha() || VerificarVitoriaColuna() || VerificarVitoriaDiagonal())
                {
                    Console.WriteLine($"O jogador {Players[playerAtual].Nome} venceu!");
                    Console.WriteLine("Deseja jogar novamente? (s/n)");
                    var escolha = Console.ReadLine().ToLower();
                    if (escolha == "s")
                    {
                        Console.Clear();
                        
                        CriarGame();
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private Player.Player CriarPlayer(Peca.Peca tipo)
        {
            Console.WriteLine("Digite o nome do jogador:");
            string nome = Console.ReadLine();
            var player = new Player.Player(nome, tipo);
            Console.WriteLine();
            return player;
        }

        private bool GerarPeca(int coluna, int linha, Peca.Peca tipo)
        {
            Peca[coluna, linha] = tipo;
            return true;
        }

        private bool VerificarPosicao(int coluna, int linha)
        {
            if (Peca[coluna, linha].Verifica() == 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Posição já ocupada, tente novamente.");
                return false;
            }
        }

        private bool VerificarVitoriaLinha()
        {
            if
            (
                Peca[0, 0].Verifica() == 1 && Peca[0, 1].Verifica() == 1 && Peca[0, 2].Verifica() == 1 ||
                Peca[1, 0].Verifica() == 1 && Peca[1, 1].Verifica() == 1 && Peca[1, 2].Verifica() == 1 ||
                Peca[2, 0].Verifica() == 1 && Peca[2, 1].Verifica() == 1 && Peca[2, 2].Verifica() == 1 ||
                Peca[0, 0].Verifica() == 2 && Peca[0, 1].Verifica() == 2 && Peca[0, 2].Verifica() == 2 ||
                Peca[1, 0].Verifica() == 2 && Peca[1, 1].Verifica() == 2 && Peca[1, 2].Verifica() == 2 ||
                Peca[2, 0].Verifica() == 2 && Peca[2, 1].Verifica() == 2 && Peca[2, 2].Verifica() == 2
            )
                {
                    return true;
                }
            return false;
        }

        private bool VerificarVitoriaColuna()
        {
            if
            (
                Peca[0, 0].Verifica() == 1 && Peca[1, 0].Verifica() == 1 && Peca[2, 0].Verifica() == 1 ||
                Peca[0, 1].Verifica() == 1 && Peca[1, 1].Verifica() == 1 && Peca[2, 1].Verifica() == 1 ||
                Peca[0, 2].Verifica() == 1 && Peca[1, 2].Verifica() == 1 && Peca[2, 2].Verifica() == 1 ||
                Peca[0, 0].Verifica() == 2 && Peca[1, 0].Verifica() == 2 && Peca[2, 0].Verifica() == 2 ||
                Peca[0, 1].Verifica() == 2 && Peca[1, 1].Verifica() == 2 && Peca[2, 1].Verifica() == 2 ||
                Peca[0, 2].Verifica() == 2 && Peca[1, 2].Verifica() == 2 && Peca[2, 2].Verifica() == 2
            )
                {
                    return true;
                }
            return false;
        }

        private bool VerificarVitoriaDiagonal()
        {
            if
            (
                Peca[0, 0].Verifica() == 1 && Peca[1, 1].Verifica() == 1 && Peca[2, 2].Verifica() == 1 ||
                Peca[0, 2].Verifica() == 1 && Peca[1, 1].Verifica() == 1 && Peca[2, 0].Verifica() == 1 ||
                Peca[0, 0].Verifica() == 2 && Peca[1, 1].Verifica() == 2 && Peca[2, 2].Verifica() == 2 ||
                Peca[0, 2].Verifica() == 2 && Peca[1, 1].Verifica() == 2 && Peca[2, 0].Verifica() == 2
            )
                {
                    return true;
                }
            return false;
        }
    }
    
}