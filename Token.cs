using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeAStarJeHicks
{
    internal class Token
    {
        public enum Letter {X, O, a}
        public Letter LetterValue;

        public override bool Equals(object? obj)
        {
            if (obj is Token other)
            {
                bool matching = LetterValue == other.LetterValue;

                return matching;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (int)LetterValue.GetHashCode();
        }
    }
}
