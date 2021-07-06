using System;
using tabuleiro;
using Xadrez;

namespace Jogo_Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.ColocarPeca(new Torre(Cor_Pecas.Preta, tab) , new Posicao(0, 0));
            tab.ColocarPeca(new Torre(Cor_Pecas.Preta, tab) , new Posicao(1, 3));
            tab.ColocarPeca(new Rei(Cor_Pecas.Branca,tab), new Posicao(2, 4));


            Tela.Imprimir_Tabuleiro(tab);


            Console.ReadLine();



        }
    }
}
