using System;
using tabuleiro;

namespace Xadrez
{
    class Partida_De_Xadrez
    {

        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor_Pecas Jogador_Atual { get; private set; }
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

        public void Jogada(Posicao origem, Posicao destino)
        {
            Movimento(origem, destino);
            Turno++;
            MudaJogador();

        }

        private void MudaJogador()
        {
            if (Jogador_Atual == Cor_Pecas.Branca)
            {
                Jogador_Atual = Cor_Pecas.Preta;
            }
            else
            {
                Jogador_Atual = Cor_Pecas.Branca;
            }
        }

        public void Valida_Pos_Origem(Posicao pos)
        {
            if (!Tab.ExistePeca(pos))
            {
                throw new Tabuleiro_Exception("Não existe peça nessa posição!");
            }
            if (Tab.peca(pos).cor != Jogador_Atual)
            {
                throw new Tabuleiro_Exception("Só pode mover as peças " + Jogador_Atual);
            }
            
            if (!Tab.peca(pos).exixteMovimentosPossiveis())
            {
                throw new Tabuleiro_Exception("Peça presa!");
            }
        }

        public void Valida_Pos_Destino(Posicao origem, Posicao destino)
        {
            if (!Tab.peca(origem).Pode_Mover_Para(destino))
            {
                throw new Tabuleiro_Exception("Movimento inválido!");
            }
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
