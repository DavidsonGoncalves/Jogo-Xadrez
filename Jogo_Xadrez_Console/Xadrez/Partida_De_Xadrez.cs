using System;
using tabuleiro;

namespace Xadrez
{
    class Partida_De_Xadrez
    {

        public Tabuleiro Tab { get; private set; }
        private int Turno;
        private Cor_Pecas Jogador_Atual;
        public bool Terminada { get; private set; }


        public Partida_De_Xadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            Jogador_Atual = Cor_Pecas.Branca;
            Colocar_Pecas();
            Terminada = false;
        }

        public void Movimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.Retirar_Peca(origem);
            p.Adicionar_Movimentos();
            Peca Peca_Capturada = Tab.Retirar_Peca(destino);

            Tab.ColocarPeca(p, destino);

        }

        private void Colocar_Pecas()
        {
            Tab.ColocarPeca(new Torre(Cor_Pecas.Branca, Tab), new Posicao_Xadrez('c', 1).ToPosicao());
            Tab.ColocarPeca(new Torre(Cor_Pecas.Branca, Tab), new Posicao_Xadrez('c', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Cor_Pecas.Branca, Tab), new Posicao_Xadrez('d', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Cor_Pecas.Branca, Tab), new Posicao_Xadrez('e', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Cor_Pecas.Branca, Tab), new Posicao_Xadrez('e', 1).ToPosicao());
            Tab.ColocarPeca(new Rei(Cor_Pecas.Branca, Tab), new Posicao_Xadrez('d', 1).ToPosicao());

            Tab.ColocarPeca(new Torre(Cor_Pecas.Preta, Tab), new Posicao_Xadrez('c', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Cor_Pecas.Preta, Tab), new Posicao_Xadrez('c', 8).ToPosicao());
            Tab.ColocarPeca(new Torre(Cor_Pecas.Preta, Tab), new Posicao_Xadrez('d', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Cor_Pecas.Preta, Tab), new Posicao_Xadrez('e', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Cor_Pecas.Preta, Tab), new Posicao_Xadrez('e', 8).ToPosicao());
            Tab.ColocarPeca(new Rei(Cor_Pecas.Preta, Tab), new Posicao_Xadrez('d', 8).ToPosicao());
        }
    }
}
