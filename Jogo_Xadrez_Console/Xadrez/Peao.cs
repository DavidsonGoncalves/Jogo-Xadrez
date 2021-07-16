using System;
using System.Collections.Generic;
using tabuleiro;

namespace Xadrez
{
    class Peao : Peca
    {
        private Partida_De_Xadrez partida;

        public Peao(Cor_Pecas cor, Tabuleiro tab, Partida_De_Xadrez partida) : base(cor, tab)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);

            return p == null || p.cor != cor;

        }

        private bool Existe_Inimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool Livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }


        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linha, tab.coluna];

            Posicao pos = new Posicao(0, 0);

            if (cor==Cor_Pecas.Branca)
            {
                pos.DefinirValores(posicao.linha - 1, posicao.coluna);
                if (tab.Posicao_Valida(pos) && Livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha - 2, posicao.coluna);
                if (tab.Posicao_Valida(pos)  && Livre(pos) && QtdMovimentos==0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.Posicao_Valida(pos)&& Existe_Inimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.Posicao_Valida(pos) && Existe_Inimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //#jogadaespecial En Passant esquerda
                if (posicao.linha==3)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.Posicao_Valida(esquerda)&& Existe_Inimigo(esquerda)&& tab.peca(esquerda)==partida.Vulneravel_EnPassant)
                    {
                        mat[esquerda.linha-1, esquerda.coluna] = true;
                    }
                }

                //#jogadaespecial En Passant direita
                if (posicao.linha == 3)
                {
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.Posicao_Valida(direita) && Existe_Inimigo(direita) && tab.peca(direita) == partida.Vulneravel_EnPassant)
                    {
                        mat[direita.linha-1, direita.coluna] = true;
                    }
                }
            }
            else
            {
                pos.DefinirValores(posicao.linha + 1, posicao.coluna);
                if (tab.Posicao_Valida(pos) && Livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha + 2, posicao.coluna);
                if (tab.Posicao_Valida(pos) && Livre(pos) && QtdMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.Posicao_Valida(pos) && Existe_Inimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.Posicao_Valida(pos) && Existe_Inimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //#jogadaespecial En Passant esquerda
                if (posicao.linha == 4)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.Posicao_Valida(esquerda) && Existe_Inimigo(esquerda) && tab.peca(esquerda) == partida.Vulneravel_EnPassant)
                    {
                        mat[esquerda.linha+1, esquerda.coluna] = true;
                    }
                }

                //#jogadaespecial En Passant direita
                if (posicao.linha == 4)
                {
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tab.Posicao_Valida(direita) && Existe_Inimigo(direita) && tab.peca(direita) == partida.Vulneravel_EnPassant)
                    {
                        mat[direita.linha+1, direita.coluna] = true;
                    }
                }
            }
            return mat;
        }
    }
}