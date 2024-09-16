using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeAStarJeHicks
{
    internal class Action
    {
        public Action() { }
        public Action(int x, int y, Token token)
        {
            X = x;
            Y = y;
            Token = token;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public Token Token { get; set; }
    }
}
