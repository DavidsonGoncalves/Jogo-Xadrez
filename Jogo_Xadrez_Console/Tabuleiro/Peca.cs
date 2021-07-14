using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }

        public Cor_Pecas cor { get; protected set; }

        public int QtdMovimentos { get; protected set; }

        public Tabuleiro tab { get; protected set; }

        public Peca(Cor_Pecas cor, Tabuleiro tab)
        {
            this.posicao = null;
            this.cor = cor;
            this.tab = tab;
            this.QtdMovimentos = 0;
        }

        public void Adicionar_Movimentos()
        {
            QtdMovimentos++;
        }
        public void Diminuir_Movimentos()
        {
            QtdMovimentos--;
        }

        public bool exixteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < tab.linha; i++)
            {
                for (int j = 0; j < tab.coluna; j++)
                {
                    if (mat[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;

        }

        public bool Movimento_Possivel(Posicao pos)
        {
            return MovimentosPossiveis()[pos.linha, pos.coluna];
        }

         public abstract bool[,] MovimentosPossiveis();
        

    }
}
