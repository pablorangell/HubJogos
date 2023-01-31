using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubJogos.JogoDaVelha
{
    public class TelaJogoDaVelha
    {
        public static void ExibirMenu()
        {
            int option;
            bool sucess;

            do
            {
                Console.WriteLine("======== BEM VINDO AO JOGO DA VELHA ========");
                Console.WriteLine("========      MENU PRINCIPAL      ========");

                Console.WriteLine(" 1 - LOGIN");
                Console.WriteLine(" 2 - CADASTRO");
                Console.WriteLine(" 3 - RETORNAR AO MENU HUB DE JOGOS");

                Console.WriteLine(" Digite a opção desejada: ");

                option = int.Parse(Console.ReadLine());

                Console.WriteLine("Opção válida. Digite novamente: ");
                sucess = int.TryParse(Console.ReadLine(), out option);
                if (!sucess)
                {
                    Console.WriteLine("Opção inválida. Digite um número inteiro.");
                    continue;
                }

                Console.Clear();
                switch(option)
                {
                    case 1:
                        var game = new Game.Game();
                        game.CriarGame();
                        game.Jogar();
                    break;
                    case 2:
                        Console.WriteLine("Jogadores já Cadastrados!");
                        break;
                    case 3:
                        Console.WriteLine("EXIBIR JOGADORES CADASTRADOS");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        continue;
                }          
            }
            while(!sucess);

        }

    }
}