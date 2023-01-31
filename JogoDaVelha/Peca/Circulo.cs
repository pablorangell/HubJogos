using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubJogos.JogoDaVelha.Peca
{
    public class Circulo : Peca
    {
                public override void Imprimir()
        {
            Console.WriteLine(" O ");
        }

        public override int Verifica()
        {
            return 1;
        }
    }
}