using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubJogos.JogoDaVelha.Peca
{
    public class Peca
    {
        public virtual void Imprimir()
        {
            Console.WriteLine(" - ");
        }

        public virtual int Verifica()
        {
            return 0;
        }
    }
}