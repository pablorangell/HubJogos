using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubJogos.BatalhaNaval
{
    public class TelaBatalhaNaval
    {
                public static void ExibirMenu()
        {
            int option;

            do
            {
                Console.WriteLine("======== BEM VINDO AO BATALHA NAVAL ========");
                Console.WriteLine("========      MENU PRINCIPAL      ========");

                Console.WriteLine(" 1 - LOGIN");
                Console.WriteLine(" 2 - CADASTRO");
                Console.WriteLine(" 3 - EXIBIR JOGADORES CADASTRADOS");

                Console.WriteLine(" Digite a opção desejada: ");

                option = int.Parse(Console.ReadLine());
                Console.Clear();
                switch(option)
                {
                    case 1:
                    Partida.Partida partida = new Partida.Partida();
                    partida.Jogar();
                    break;
                    case 2:
                        Console.WriteLine("CADASTRO");
                        break;
                    case 3:
                        Console.WriteLine("EXIBIR JOGADORES CADASTRADOS");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }          
            }
            while(option != 0);

        }
    }
}