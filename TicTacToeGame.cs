using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TicTacToeAStarJeHicks
{
    internal class TicTacToeGame
    {
        public List<int> Moves { get; set; }

        public TicTacToeGame()
        {
            Moves = new List<int>();
        }

        //public int GetMove()
        //{
        //    string pressedKey = "";
        //    while (!Regex.IsMatch(pressedKey, "^[0-8]$"))
        //    {
        //        Console.WriteLine("Type a number to select space:");

        //        pressedKey = Console.ReadLine();
        //    }
        //    return int.Parse(pressedKey);
        //}

        public int GetMove(List<(int, int)> openCoordinates)
        {
            Dictionary<int, (int, int)> reverseMapping = new();  // Maps dynamic numbers back to coordinates
            int nextMove = 0;

            // Create a reverse mapping from dynamic numbers to coordinates
            foreach (var coord in openCoordinates)
            {
                reverseMapping[nextMove++] = coord;
            }

            string pressedKey = "";
            while (true)
            {
                Console.WriteLine("Type a number to select an open space (available moves: " + string.Join(", ", reverseMapping.Keys) + "):");
                pressedKey = Console.ReadLine();

                if (int.TryParse(pressedKey, out int move) && reverseMapping.ContainsKey(move))
                {
                    // Return the selected move's index (which can be used to select a child node, etc.)
                    return move;
                }
                else
                {
                    Console.WriteLine("Invalid move. Please try again.");
                }
            }
        }



        //public void AddMove()
        //{
        //    this.Moves.Add(GetMove());
        //}
    }
}
