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

                Posicao_Xadrez pos = new Posicao_Xadrez('c', 7);
                Console.WriteLine(pos);

                Console.WriteLine(pos.ToPosicao());





                Console.ReadKey();

            }catch(Tabuleiro_Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
