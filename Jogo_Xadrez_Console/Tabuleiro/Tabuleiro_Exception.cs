using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class Tabuleiro_Exception : Exception
    {
        public Tabuleiro_Exception(string msg) : base(msg) { }
    }
}
