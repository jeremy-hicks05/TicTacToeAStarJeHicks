using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeAStarJeHicks
{
    internal class TicTacToeAI
    {

        public TicTacToeAI() { }
        public TicTacToeAI(Node rootNode)
        {
            
        }

        // Minimax function
        public int Minimax(Node node, bool isMaximizingPlayer)
        {
            // Limit depth to control search
            if (node.IsTerminal())
            {
                return node.Winner;
                //return EvaluateGameState(node);
            }

            if (isMaximizingPlayer)
            {
                int bestScore = int.MinValue;
                foreach (Node child in node.ChildNodes)
                {
                    //Console.WriteLine("Considering child within Minimax function:");
                    //child.PrintNodeState();
                    int childScore = Minimax(child, false);
                    bestScore = Math.Max(bestScore, childScore);
                    //Console.WriteLine("Best score is...");
                    //Console.WriteLine(bestScore);
                }
                return bestScore;
            }
            else
            {
                int bestScore = int.MaxValue;
                foreach (Node child in node.ChildNodes)
                {
                    //Console.WriteLine("Considering child within Minimax function:");
                    //child.PrintNodeState();
                    int childScore = Minimax(child, true);
                    bestScore = Math.Min(bestScore, childScore);
                    //Console.WriteLine("Best score is...");
                    //Console.WriteLine(bestScore);
                }
                return bestScore;
            }
        }



        public Node GetBestMove(Node currentNode)
        {
            Node bestMove = null;
            int bestValue = int.MinValue;
            //if (currentNode.Player == Token.Letter.X)
            //{
            //    bestValue = int.MinValue;
            //}
            //else
            //{
            //    bestValue = int.MaxValue;
            //}

            foreach (var child in currentNode.ChildNodes)
            {
                //Console.WriteLine("Considering child in GetBestMove:");
                //child.PrintNodeState();

                int moveValue = Minimax(child, false);
                //int moveValue = Minimax(child, currentNode.Player == Token.Letter.X);

                //Console.WriteLine("Child");
                //child.PrintNodeState();
                //Console.WriteLine("Selected with moveValue:");
                //Console.WriteLine(moveValue);

                if (moveValue > bestValue)
                {
                    bestValue = moveValue;
                    bestMove = child;
                    //Console.WriteLine("Selecting move:");
                    //bestMove.PrintNodeState();
                    //bestMove.ChildNodes = currentNode.ChildNodes;
                }
                //else if(child.Player == Token.Letter.O && (moveValue > bestValue))
                //{
                //    bestValue = moveValue;
                //    bestMove = child;
                //}
            }

            return bestMove; // Returns the optimal move for the AI
        }

        // Minimax function
        //public int Minimax(Node node, bool isMaximizingPlayer)
        //{
        //    if (node.IsTerminal())
        //    {
        //        return EvaluateGameState(node);
        //    }

        //    if (isMaximizingPlayer)
        //    {
        //        int bestScore = int.MinValue;
        //        foreach (Node child in node.ChildNodes)
        //        {
        //            int childScore = Minimax(child, false);
        //            bestScore = Math.Max(bestScore, childScore); // Update bestScore, do not sum
        //        }
        //        return bestScore;
        //    }
        //    else
        //    {
        //        int bestScore = int.MaxValue;
        //        foreach (Node child in node.ChildNodes)
        //        {
        //            int childScore = Minimax(child, true);
        //            bestScore = Math.Min(bestScore, childScore); // Update bestScore, do not sum
        //        }
        //        return bestScore;
        //    }
        //}

        //// EvaluateGameState method
        //public int EvaluateGameState(Node node)
        //{
        //    if (node.Winner == 1)
        //        return 1; // X wins
        //    else if (node.Winner == -1)
        //        return -1; // O wins
        //    else
        //        return 0; // Draw
        //}

        //// GetBestMove function
        //public Node GetBestMove(Node currentNode)
        //{
        //    Node bestMove = null;
        //    int bestValue = (currentNode.Player == Token.Letter.X) ? int.MinValue : int.MaxValue;

        //    foreach (var child in currentNode.ChildNodes)
        //    {
        //        int moveValue = Minimax(child, currentNode.Player == Token.Letter.O);

        //        if (currentNode.Player == Token.Letter.X && moveValue > bestValue)
        //        {
        //            bestValue = moveValue;
        //            bestMove = child;
        //        }
        //        else if (currentNode.Player == Token.Letter.O && moveValue < bestValue)
        //        {
        //            bestValue = moveValue;
        //            bestMove = child;
        //        }
        //    }

        //    return bestMove; // Returns the optimal move for the AI
        //}

    }

}
