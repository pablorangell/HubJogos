using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubJogos.JogoDaVelha.Player
{
    public class Player
    {
        public string Nome { get; private set; }
        public Peca.Peca PecaEscolhida { get; private set; }

        public Player(string nome, Peca.Peca pecaEscolhida)
        {
            Nome = nome;
            PecaEscolhida = pecaEscolhida;
        }
    }
}