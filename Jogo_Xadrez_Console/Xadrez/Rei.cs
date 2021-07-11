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

        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);

            return p == null || p.cor != cor;
                
        }


        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linha, tab.coluna];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.DefinirValores(posicao.linha - 1, posicao.coluna);
            if (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Diagonal sup direita
            pos.DefinirValores(posicao.linha - 1, posicao.coluna +1);
            if (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Direita
            pos.DefinirValores(posicao.linha, posicao.coluna +1);
            if (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Diagonal inf direita
            pos.DefinirValores(posicao.linha + 1, posicao.coluna+1);
            if (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Baixo
            pos.DefinirValores(posicao.linha + 1, posicao.coluna);
            if (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //diagonal inf esquerda
            pos.DefinirValores(posicao.linha + 1, posicao.coluna-1);
            if (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //esquerda
            pos.DefinirValores(posicao.linha, posicao.coluna-1);
            if (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Diagonal sup esquerda
            pos.DefinirValores(posicao.linha - 1, posicao.coluna-1);
            if (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            return mat;
        }


    }
}
