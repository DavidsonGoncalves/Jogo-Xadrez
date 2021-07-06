using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class Tabuleiro
    {

        public int linhas { get; set; }
        public int colunas { get; set; }

        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }
        

        public Peca peca (int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca peca (Posicao pos)
        {
            
            return pecas[pos.Linha, pos.Coluna];
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
            pecas[pos.Linha, pos.Coluna] = p;
            p.posicao = pos;
        }



        public bool Posicao_Valida(Posicao pos)
        {
            if (pos.Linha<0|| pos.Linha<=linhas||pos.Coluna<0||pos.Coluna<=colunas)
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
