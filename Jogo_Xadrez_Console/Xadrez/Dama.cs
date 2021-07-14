using System;
using tabuleiro;

namespace Xadrez
{
    class Dama : Peao
    {
        public Dama(Cor_Pecas cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "D";
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

            //Direita
            pos.DefinirValores(posicao.linha, posicao.coluna + 1);
            while (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = pos.coluna + 1;
            }

            //Esquerda
            pos.DefinirValores(posicao.linha, posicao.coluna - 1);
            while (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = pos.coluna - 1;
            }

            //Cima
            pos.DefinirValores(posicao.linha - 1, posicao.coluna);
            while (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = pos.linha - 1;
            }

            //baixo
            pos.DefinirValores(posicao.linha + 1, posicao.coluna);
            while (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;

                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = pos.linha + 1;
            }

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
