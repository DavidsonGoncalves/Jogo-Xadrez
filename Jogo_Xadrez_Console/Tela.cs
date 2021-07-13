using System;
using System.Collections.Generic;
using tabuleiro;
using Xadrez;
namespace Jogo_Xadrez_Console
{
    class Tela
    {
        public static void ImprimirPartida(Partida_De_Xadrez partida)
        {
            Imprimir_Tabuleiro(partida.Tab);
            Console.WriteLine();
            
            Imprimir_Pecas_Capturadas(partida);
            Console.WriteLine();
            Console.WriteLine("TURNO: " + partida.Turno);
            Console.WriteLine("VEZ DA PEÇA: " + partida.Jogador_Atual);

            if (partida.xeque==true)
            {
                Console.WriteLine(" XEQUE! ");
            }
        }

        public static void Imprimir_Pecas_Capturadas(Partida_De_Xadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            Imprimir_Conjuntos(partida.Pecas_Capturadas(Cor_Pecas.Branca));
            Console.WriteLine();
            
            Console.Write("Pretas: ");
            ConsoleColor auxcolor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Imprimir_Conjuntos(partida.Pecas_Capturadas(Cor_Pecas.Preta));
            Console.ForegroundColor = auxcolor;
            
            Console.WriteLine();
        }

        public static void Imprimir_Conjuntos(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + "-");
            }
            Console.Write("]");
        }

        public static void Imprimir_Tabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linha; i++)
            {
                Console.Write(8 - i + "| ");
                for (int j = 0; j < tab.coluna; j++)
                {
                    Imprimir_Peca(tab.peca(i, j));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ===============");
            Console.WriteLine("   A B C D E F G H");
        }

        public static void Imprimir_Tabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.linha; i++)
            {
                Console.Write(8 - i + "| ");
                for (int j = 0; j < tab.coluna; j++)
                {
                    if (posicoesPossiveis[i,j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    Imprimir_Peca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ===============");
            Console.WriteLine("   A B C D E F G H");
            Console.BackgroundColor = fundoOriginal;
        }

        public static void Imprimir_Peca(Peca peca)
        {

            if (peca == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
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
