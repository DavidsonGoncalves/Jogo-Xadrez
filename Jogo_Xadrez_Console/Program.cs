using System;
using tabuleiro;
using Xadrez;

namespace Jogo_Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.ColocarPeca(new Torre(Cor_Pecas.Preta, tab), new Posicao(0, 0));
                tab.ColocarPeca(new Torre(Cor_Pecas.Preta, tab), new Posicao(1, 3));
                tab.ColocarPeca(new Rei(Cor_Pecas.Branca, tab), new Posicao(0, 2));

                tab.ColocarPeca(new Torre(Cor_Pecas.Branca, tab), new Posicao(3, 5));
               


                Tela.Imprimir_Tabuleiro(tab);


                Console.ReadLine();
                

            }catch(Tabuleiro_Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
