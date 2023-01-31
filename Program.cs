using System;
using HubJogos.JogoDaVelha;
using HubJogos.BatalhaNaval;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubJogos
{
    class Program
    {
        static void Main(string[] args)
        {

                int option;

            do
                {
                    Console.WriteLine("======== BEM VINDO AO HUB DE JOGOS ========");
                    Console.WriteLine("========      MENU PRINCIPAL      ========");
                    Console.WriteLine(" 1 - INICIAR JOGO DA VELHA ");
                    Console.WriteLine(" 2 - INICIAR JOGO BATALHA NAVAL ");
                    Console.WriteLine(" 0 - SAIR DO HUB DE JOGOS");

                    Console.WriteLine(" Digite a opção desejada: ");

                    option = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch(option)
                    {
                        case 1:
                            TelaJogoDaVelha.ExibirMenu();
                            Console.ReadKey();
                            break;
                        case 2:
                            TelaBatalhaNaval.ExibirMenu();
                            break;
                        case 0:
                        Console.WriteLine("Saindo do Hub de Jogos...");
                    break;
                    }          
                }
                while(option != 0);
            }
    }
}
