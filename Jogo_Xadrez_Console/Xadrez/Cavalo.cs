using System;
using tabuleiro;

namespace Xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Cor_Pecas cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "C";
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

            //acima direita
            pos.DefinirValores(posicao.linha - 2, posicao.coluna+1);
            if (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //acima esquerda 
            pos.DefinirValores(posicao.linha - 2, posicao.coluna - 1);
            if (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Direita cima
            pos.DefinirValores(posicao.linha-1, posicao.coluna + 2);
            if (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Direita baixo
            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 2);
            if (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Baixo direita
            pos.DefinirValores(posicao.linha + 2, posicao.coluna+1);
            if (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //baixo esquerda
            pos.DefinirValores(posicao.linha + 2, posicao.coluna - 1);
            if (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //esquerda baixo
            pos.DefinirValores(posicao.linha+1, posicao.coluna - 2);
            if (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //esquerda cima
            pos.DefinirValores(posicao.linha - 1, posicao.coluna - 2);
            if (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            return mat;
        }


    }

}

