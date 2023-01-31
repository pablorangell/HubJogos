using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubJogos.JogoDaVelha.Peca
{
    public class Xis : Peca
    {
        public override void Imprimir()
        {
            Console.WriteLine(" X ");
        }

        public override int Verifica()
        {
            return 2;
        }
    }
}