using System;
using tabuleiro;

namespace Xadrez
{
    class Torre : Peca
    {
        public Torre(Cor_Pecas cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "T";
        }


    }
}
