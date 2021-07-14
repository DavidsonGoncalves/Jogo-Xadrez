using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace Xadrez
{
    class Bispo : Peca
    {
        public Bispo(Cor_Pecas cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "B";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);

            return p == null || p.cor != cor;

        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linha, tab.coluna];

            Posicao pos = new Posicao(0, 0);

            //Diagonal Superior esquerda
            pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
            while (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.linha - 1, pos.coluna - 1);
            }

            //Diagonal inferior direita
            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
            while (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.linha + 1, pos.coluna + 1);
            }

            //Diagonal superior direita
            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
            while (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.linha - 1, pos.coluna + 1);
            }

            //Diagonal inferior esquerda
            pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
            while (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.linha + 1, pos.coluna - 1);
            }

            return mat;
        }
    }
}
