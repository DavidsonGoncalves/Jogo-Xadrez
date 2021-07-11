using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class Tabuleiro
    {

        public int linha { get; set; }
        public int coluna { get; set; }

        private Peca[,] pecas;

        public Tabuleiro(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
            pecas = new Peca[linha, coluna];
        }
        

        public Peca peca (int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca peca (Posicao pos)
        {
            
            return pecas[pos.linha, pos.coluna];
        }



        public bool ExistePeca(Posicao pos)
        {
            Validar_Posicao(pos);
            return peca(pos) != null;
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new Tabuleiro_Exception("Já existe uma peça nessa posição!");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        public Peca Retirar_Peca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }

            Peca aux = peca(pos);

            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;
        }



        public bool Posicao_Valida(Posicao pos)
        {
            if (pos.linha<0|| pos.linha>=linha||pos.coluna<0||pos.coluna>=coluna)
            {
                return false;
            }
            return true;
        }

        public void Validar_Posicao(Posicao pos)
        {
            if (!Posicao_Valida(pos))
            {
                throw new Tabuleiro_Exception("Posição Inválida!");
            }
        }
    }
}
