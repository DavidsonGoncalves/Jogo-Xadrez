using System.Collections.Generic;
using tabuleiro;

namespace Xadrez
{
    class Partida_De_Xadrez
    {

        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor_Pecas Jogador_Atual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xeque { get; private set; }



        public Partida_De_Xadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            Jogador_Atual = Cor_Pecas.Branca;
            Terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            Colocar_Pecas();
           
        }

        public Peca Movimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.Retirar_Peca(origem);
            p.Adicionar_Movimentos();
            Peca Peca_Capturada = Tab.Retirar_Peca(destino);
            Tab.ColocarPeca(p, destino);

            if (Peca_Capturada!=null)
            {
                capturadas.Add(Peca_Capturada);
            }
            return Peca_Capturada;
        }


        public void Jogada(Posicao origem, Posicao destino)
        {
            Peca Peca_Capturada = Movimento(origem, destino);

            if (Esta_Em_Xeque(Jogador_Atual))
            {
                Desfaz_Movimento(origem, destino, Peca_Capturada);
                throw new Tabuleiro_Exception("Você não pode se colocar em xeque");
            }

            if (Esta_Em_Xeque(adversaria(Jogador_Atual)))
            {
                xeque = true;
            }
            else xeque = false;

            Turno++;
            MudaJogador();

        }

        public void Desfaz_Movimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tab.Retirar_Peca(destino);
            p.Diminuir_Movimentos();

            if (pecaCapturada!=null)
            {
                Tab.ColocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            Tab.ColocarPeca(p, origem);

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

        public HashSet<Peca> Pecas_Capturadas(Cor_Pecas cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach(Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> Pecas_Em_Jogo(Cor_Pecas cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(Pecas_Capturadas(cor));
            return aux;
        }

        private Cor_Pecas adversaria(Cor_Pecas cor)
        {
            if (cor == Cor_Pecas.Branca)
            {
                return Cor_Pecas.Preta;
            }
            else return Cor_Pecas.Branca;
        }

        private Peca Rei(Cor_Pecas cor)
        {
            foreach (Peca x in Pecas_Em_Jogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool Esta_Em_Xeque(Cor_Pecas cor)
        {
            Peca R = Rei(cor);
            if (R==null)
            {
                throw new Tabuleiro_Exception("Não existe Rei no tabuleiro");
            }

            foreach (Peca x in Pecas_Em_Jogo(adversaria(cor)))
            {
                bool[,] mat = x.MovimentosPossiveis();
                if (mat[R.posicao.linha, R.posicao.coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public void Colocar_Nova_Peca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new Posicao_Xadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }

        private void Colocar_Pecas()
        {
            Colocar_Nova_Peca('c', 1, new Torre(Cor_Pecas.Branca, Tab));
            Colocar_Nova_Peca('c', 2, new Torre(Cor_Pecas.Branca, Tab));
            Colocar_Nova_Peca('d', 2, new Torre(Cor_Pecas.Branca, Tab));
            Colocar_Nova_Peca('e', 2, new Torre(Cor_Pecas.Branca, Tab));
            Colocar_Nova_Peca('e', 1, new Torre(Cor_Pecas.Branca, Tab));
            Colocar_Nova_Peca('d', 1, new Rei(Cor_Pecas.Branca, Tab));

            Colocar_Nova_Peca('c', 7, new Torre(Cor_Pecas.Preta, Tab));
            Colocar_Nova_Peca('c', 8, new Torre(Cor_Pecas.Preta, Tab));
            Colocar_Nova_Peca('d', 7, new Torre(Cor_Pecas.Preta, Tab));
            Colocar_Nova_Peca('e', 7, new Torre(Cor_Pecas.Preta, Tab));
            Colocar_Nova_Peca('e', 8, new Torre(Cor_Pecas.Preta, Tab));
            Colocar_Nova_Peca('d', 8, new Rei(Cor_Pecas.Preta, Tab));

        }
    }
}
