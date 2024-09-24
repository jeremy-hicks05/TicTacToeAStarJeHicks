using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Console.WriteLine("Enter Move:");
            var pressedKey = Console.ReadLine();
            return int.Parse(pressedKey);
        }

        public void AddMove()
        {
            this.Moves.Add(GetMove());
        }
    }
}
