using System;
using tabuleiro;
using Xadrez;
namespace Jogo_Xadrez_Console
{
    class Tela
    {
        public static void Imprimir_Tabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + "| ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab.peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Imprimir_Peca(tab.peca(i, j));
                        Console.Write(" ");
                    }

                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ===============");
            Console.WriteLine("   A B C D E F G H");
        }

        public static void Imprimir_Peca(Peca peca)
        {
            if (peca.cor == Cor_Pecas.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
        public static Posicao_Xadrez LerPosicao_Xadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new Posicao_Xadrez(coluna, linha);
        }

    }
}
