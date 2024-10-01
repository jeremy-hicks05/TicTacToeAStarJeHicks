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

        public int GetMove()
        {
            string pressedKey = "";
            while (!Regex.IsMatch(pressedKey, "^[0-8]$"))
            {
                Console.WriteLine("Type a number to select space:");

                pressedKey = Console.ReadLine();
            }
            return int.Parse(pressedKey);
        }

        public void AddMove()
        {
            this.Moves.Add(GetMove());
        }
    }
}
