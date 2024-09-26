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
        public int Minimax(Node node, Token token)
        {
            // Limit depth to control search
            if (node.IsTerminal())
            {
                //Console.WriteLine("Found terminal node:");
                //node.PrintNodeState();
                //Console.WriteLine("With winner: " + node.Winner);
                //return node.Winner;
                return EvaluateGameState(node);
            }

            //if (isMaximizingPlayer)
            //{
            int bestScore;

            if (token.LetterValue == new Token() { LetterValue = Token.Letter.X }.LetterValue)
            {
                bestScore = int.MinValue;
            }
            else
            {
                bestScore = int.MaxValue;
            }
            foreach (Node child in node.ChildNodes)
            {
                //Console.WriteLine("Considering child within Minimax function:");
                //child.PrintNodeState();
                //int childScore = Minimax(child, false);
                int childScore = Minimax(child, child.GetCurrentTurn());

                if (token.LetterValue == Token.Letter.X)
                {
                    bestScore = Math.Max(bestScore, childScore);
                }
                else if (token.LetterValue == Token.Letter.O)
                {
                    bestScore = Math.Min(bestScore, childScore);
                }
                //Console.WriteLine("Best score is...");
                //Console.WriteLine(bestScore);
            }
            return bestScore;
        }



        public Node GetBestMove(Node currentNode, Token token)
        {
            Node bestMove = null;
            int bestValue;

            currentNode.PrintNodeState();

            if (token.LetterValue == Token.Letter.X)
            {
                bestValue = int.MinValue;
            }
            else
            {
                bestValue = int.MaxValue;
            }

            foreach (var child in currentNode.ChildNodes)
            {
                //Console.WriteLine("Considering child in GetBestMove:");
                //child.PrintNodeState();

                //int moveValue = Minimax(child, false);
                //int moveValue = Minimax(child, child.Player);
                Token opponentToken = child.GetNextTurn();
                Token thisToken = child.GetCurrentTurn();
                int moveValue = Minimax(child, thisToken);

                //Console.WriteLine("Child");
                //child.PrintNodeState();
                //Console.WriteLine("Selected with moveValue:");
                //Console.WriteLine(moveValue);

                if (
                    token.LetterValue == Token.Letter.X && (moveValue > bestValue))
                {
                    bestValue = moveValue;
                    bestMove = child;
                    Console.WriteLine("Selecting move for X:");
                    bestMove.PrintNodeState();
                    Console.WriteLine("With value " + moveValue);
                    //bestMove.ChildNodes = currentNode.ChildNodes;
                }
                else if (token.LetterValue == Token.Letter.O && (moveValue < bestValue))
                {
                    bestValue = moveValue;
                    bestMove = child;
                    Console.WriteLine("Selecting move for O:");
                    bestMove.PrintNodeState();
                    Console.WriteLine("With value " + moveValue);
                    //bestMove.ChildNodes = currentNode.ChildNodes;
                }
            }

            Console.WriteLine("Best Move");
            bestMove.PrintNodeState();
            Console.WriteLine("Selected with moveValue:");
            Console.WriteLine(bestValue);
            return bestMove; // Returns the optimal move for the AI
        }

        public int EvaluateGameState(Node node)
        {
            // Check for a win for X
            if (CheckWin(node, Token.Letter.X))
            {
                return 1; // Positive score for AI (X) win
            }
            // Check for a win for O
            else if (CheckWin(node, Token.Letter.O))
            {
                return -1; // Negative score for opponent (O) win
            }
            // Check for a draw (assuming a draw is when the board is full)
            else if (IsDraw(node))
            {
                return 0; // Score for a draw
            }

            return 0; // If the game is still ongoing, return 0 (or some other value if needed)
        }

        private bool CheckWin(Node node, Token.Letter letter)
        {
            // Check rows, columns, and diagonals for a win
            for (int i = 0; i < 3; i++)
            {
                // Check rows
                if (node.State.Tokens[i, 0].LetterValue == letter &&
                    node.State.Tokens[i, 1].LetterValue == letter &&
                    node.State.Tokens[i, 2].LetterValue == letter)
                {
                    return true;
                }

                // Check columns
                if (node.State.Tokens[0, i].LetterValue == letter &&
                    node.State.Tokens[1, i].LetterValue == letter &&
                    node.State.Tokens[2, i].LetterValue == letter)
                {
                    return true;
                }
            }

            // Check diagonals
            if (node.State.Tokens[0, 0].LetterValue == letter &&
                node.State.Tokens[1, 1].LetterValue == letter &&
                node.State.Tokens[2, 2].LetterValue == letter)
            {
                return true;
            }
            if (node.State.Tokens[0, 2].LetterValue == letter &&
                node.State.Tokens[1, 1].LetterValue == letter &&
                node.State.Tokens[2, 0].LetterValue == letter)
            {
                return true;
            }

            return false;
        }

        private bool IsDraw(Node node)
        {
            // Check if the board is full (i.e., no empty tokens)
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (node.State.Tokens[i, j].LetterValue == Token.Letter.a) // Assuming 'a' represents an empty token
                    {
                        return false; // Found an empty token, so it's not a draw
                    }
                }
            }
            return true; // All tokens are filled, it's a draw
        }


    }


}
