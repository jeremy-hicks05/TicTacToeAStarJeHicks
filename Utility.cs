using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeAStarJeHicks
{
    internal static class Utility
    {
        public static List<Action> Actions(State s)
        {
            List<Action> actions = new List<Action>();
            foreach (var coord in s.GetOpenCoordinates())
            {
                actions.Add(new Action() { X = coord.Item1, Y = coord.Item2 });
            }
            return actions;
        }

        public static State Result(State s, Action a)
        {
            //State newState = new State();
            //newState.Tokens = s.Tokens;
            //newState.HasAWinner = s.HasAWinner;

            s.PerformAction(a);
            return s;
        }

        private static bool CheckWin(State s)
        {
            // check horizontal, vertical, and diagonal win conditions
            return (s.Tokens[0, 0].LetterValue != Token.Letter.a &&
                    (s.Tokens[0, 0].LetterValue == s.Tokens[0, 1].LetterValue && s.Tokens[0, 1].LetterValue == s.Tokens[0, 2].LetterValue)) ||
                   (s.Tokens[1, 0].LetterValue != Token.Letter.a &&
                    (s.Tokens[1, 0].LetterValue == s.Tokens[1, 1].LetterValue && s.Tokens[1, 1].LetterValue == s.Tokens[1, 2].LetterValue)) ||
                   (s.Tokens[2, 0].LetterValue != Token.Letter.a &&
                    (s.Tokens[2, 0].LetterValue == s.Tokens[2, 1].LetterValue && s.Tokens[2, 1].LetterValue == s.Tokens[2, 2].LetterValue)) ||
                   (s.Tokens[0, 0].LetterValue != Token.Letter.a &&
                    (s.Tokens[0, 0].LetterValue == s.Tokens[1, 0].LetterValue && s.Tokens[1, 0].LetterValue == s.Tokens[2, 0].LetterValue)) ||
                   (s.Tokens[0, 1].LetterValue != Token.Letter.a &&
                    (s.Tokens[0, 1].LetterValue == s.Tokens[1, 1].LetterValue && s.Tokens[1, 1].LetterValue == s.Tokens[2, 1].LetterValue)) ||
                   (s.Tokens[0, 2].LetterValue != Token.Letter.a &&
                    (s.Tokens[0, 2].LetterValue == s.Tokens[1, 2].LetterValue && s.Tokens[1, 2].LetterValue == s.Tokens[2, 2].LetterValue)) ||
                   (s.Tokens[1, 1].LetterValue != Token.Letter.a &&
                    ((s.Tokens[0, 0].LetterValue == s.Tokens[1, 1].LetterValue && s.Tokens[1, 1].LetterValue == s.Tokens[2, 2].LetterValue) ||
                     (s.Tokens[0, 2].LetterValue == s.Tokens[1, 1].LetterValue && s.Tokens[1, 1].LetterValue == s.Tokens[2, 0].LetterValue)));
        }

        public static bool HasResult(State s)
        {
            return CheckWin(s) || s.GetOpenCoordinates().Count == 0;
        }

        public static bool HasAWinner(State s)
        {
            return CheckWin(s);
        }
    }
}
