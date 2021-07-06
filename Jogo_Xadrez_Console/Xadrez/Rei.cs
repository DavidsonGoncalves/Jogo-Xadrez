using System;
using tabuleiro;

namespace Xadrez
{
    class Rei : Peca
    {
        public Rei( Cor_Pecas cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "R";
        }


    }
}
