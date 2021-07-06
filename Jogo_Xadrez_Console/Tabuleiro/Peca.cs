using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }

        public Cor_Pecas cor { get; protected set; }

        public int QtdMovimentos { get; protected set; }

        public Tabuleiro tabuleiro { get; protected set; }

        public Peca(Cor_Pecas cor, Tabuleiro tabuleiro)
        {
            this.posicao = null;
            this.cor = cor;
            this.tabuleiro = tabuleiro;
            this.QtdMovimentos = 0;
        }



    }
}
