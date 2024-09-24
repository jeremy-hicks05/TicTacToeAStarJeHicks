using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeAStarJeHicks
{
    internal class State
    {
        public State()
        {
            Token blankToken = new Token();
            Token XToken = new Token();
            Token OToken = new Token();

            blankToken.LetterValue = Token.Letter.a;
            XToken.LetterValue = Token.Letter.X;
            OToken.LetterValue = Token.Letter.O;

            this.Tokens = new Token[3, 3]
            {
                { blankToken, blankToken, blankToken },
                { blankToken, blankToken, blankToken },
                { blankToken, blankToken, blankToken }
            };
        }

        public State(State state)
        {
            this.HasAResult = state.HasAResult;
            this.Tokens = state.Tokens;
        }

        public State(Token[,] tokens)
        {
            Tokens = tokens;
        }

        public State(Token.Letter[,] newBoard)
        {
            //Tokens = newBoard;
        }

        public static List<State> ExploredStates = new List<State>();
        public Token[,] Tokens { get; set; } = new Token[3, 3];
        public bool HasAResult { get; set; }

        public State PerformAction(Action a)
        {
            this.Tokens[a.X, a.Y] = a.Token;
            return this;
        }

        public void PrintNodeState()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(Tokens[i, j].LetterValue == Token.Letter.a ? " " : Tokens[i, j].LetterValue);
                    if (j < 2)
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            //Console.ReadLine();
        }

        public static void PrintExploredStates()
        {
            foreach(var state in ExploredStates)
            {
                state.PrintNodeState();
                //Console.ReadLine();
            }
        }

        public int GetAvailableMoves()
        {
            int availableMoves = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Tokens[i, j].LetterValue == Token.Letter.a)
                    {
                        availableMoves++;
                    }
                }
            }
            return availableMoves;
        }

        public State Copy(State state)
        {
            return new State
            {
                HasAResult = state.HasAResult,
                Tokens = state.Tokens
            };
        }

        // Actions(s)
        public List<(int, int)> GetOpenCoordinates()
        {
            List<(int, int)> openCoordinates = new();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Tokens[i, j].LetterValue == Token.Letter.a)
                    {
                        openCoordinates.Add((i, j));
                    }
                }
            }
            return openCoordinates;
        }

        //public bool CheckForWinner()
        //{
        //    if (GetAvailableMoves() == 0)
        //    {
        //        HasAWinner = true;
        //    }
        //    else
        //    {
        //        HasAWinner = false;
        //    }
        //    return HasAWinner;
        //}

        public override bool Equals(object obj)
        {
            if (obj is State other)
            {

                //this.PrintNodeState();
                //other.PrintNodeState();

                bool matching = Tokens[0, 0].LetterValue == other.Tokens[0, 0].LetterValue &&
                    Tokens[0, 1].LetterValue == other.Tokens[0, 1].LetterValue &&
                    Tokens[0, 2].LetterValue == other.Tokens[0, 2].LetterValue &&
                    Tokens[1, 0].LetterValue == other.Tokens[1, 0].LetterValue &&
                    Tokens[1, 1].LetterValue == other.Tokens[1, 1].LetterValue &&
                    Tokens[1, 2].LetterValue == other.Tokens[1, 2].LetterValue &&
                    Tokens[2, 0].LetterValue == other.Tokens[2, 0].LetterValue &&
                    Tokens[2, 1].LetterValue == other.Tokens[2, 1].LetterValue &&
                    Tokens[2, 2].LetterValue == other.Tokens[2, 2].LetterValue;

                //Console.WriteLine("States match? " + matching);

                return matching;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((Tokens[0, 0], Tokens[0, 1], Tokens[0, 2], Tokens[1, 0], Tokens[1, 1], Tokens[1, 2], Tokens[2, 0], Tokens[2, 1], Tokens[2, 2]).GetHashCode());
        }
    }
}
