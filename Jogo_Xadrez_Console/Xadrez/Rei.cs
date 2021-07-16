using System;
using tabuleiro;

namespace Xadrez
{
    class Rei : Peca
    {

        private Partida_De_Xadrez partida;

        public Rei(Cor_Pecas cor, Tabuleiro tab, Partida_De_Xadrez partida) : base(cor, tab)
        {
            this.partida = partida;
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

        private bool Teste_Torre_Para_Roque(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.QtdMovimentos == 0;

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
            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Direita
            pos.DefinirValores(posicao.linha, posicao.coluna + 1);
            if (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Diagonal inf direita
            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
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
            pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //esquerda
            pos.DefinirValores(posicao.linha, posicao.coluna - 1);
            if (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Diagonal sup esquerda
            pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tab.Posicao_Valida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //#Jogadaespecial roque

            if (QtdMovimentos == 0 && !partida.xeque)
            {
                //#jogadaespecial roque pequeno
                Posicao PosT1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if (Teste_Torre_Para_Roque(PosT1))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    if (tab.peca(p1) == null && tab.peca(p2) == null)
                    {
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    }
                }

                //#jogadaespecial roque grande
                Posicao PosT2 = new Posicao(posicao.linha, posicao.coluna - 4);
                if (Teste_Torre_Para_Roque(PosT1))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null)
                    {
                        mat[posicao.linha, posicao.coluna - 2] = true;
                    }
                }

            }

            return mat;
        }


    }
}
