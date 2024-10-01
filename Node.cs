using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeAStarJeHicks
{
    internal class Node
    {
        //
        /*
         Find the first X win node
         Find the first O win node
         Distance == Layer
         O attempts to find first O win
         X attempts to find first X win
         
         FIGHT!

        // TODO: Find path to closest X win
        // TODO: Find path to closest O win
        */
        //
        // properties
        private int StartingLayer = 11;
        public static int StaticID = 0;
        public int ID { get; set; }
        public State State
        {
            get;
            set;
        }
        public Node Parent { get; set; }
        public List<Node> ChildNodes { get; set; } = new List<Node>();
        //public Token.Letter Player = new Token.Letter();
        //public int Winner { get; set; }
        public int LayerNumber { get; set; }


        public static List<Node> results = new List<Node>();


        // ChatGPT Section

        public State[,] Tokens { get; private set; } // 2D array representing the board state

        public int gCost { get; set; }
        public int hCost { get; set; }
        public int fCost { get; set; }

        // end ChatGPT Section

        // constructors
        public Node()
        {
            State = new State();
        }

        public Node(Token[,] tokens, Token.Letter currentPlayer)
        {
            State.Tokens = tokens; // Assign the board state
            //Player = currentPlayer; // Assign the current player
        }

        public Node(State[,] tokens, Token.Letter currentPlayer)
        {
            Tokens = tokens; // Assign the board state
            //Player = currentPlayer;
            //CurrentPlayer = currentPlayer; // Assign the current player
        }

        public Node(Token.Letter[,] newBoard, Token.Letter letter)
        {
            //Player = letter;
            this.State = new State(newBoard);
        }

        public static void PrintAllNodes(Node node)
        {
            foreach (Node n in node.ChildNodes)
            {
                n.PrintNodeState();
                PrintAllNodes(n);
            }
        }

        // From ChatGPT
        public static void ExploreNode(Node currentNode)
        {
            // If the node has a result, add it to the results list and stop further exploration
            if (currentNode.State.HasAResult)
            {
                results.Add(currentNode);
                return;
            }

            // Add a new layer of children to the current node
            currentNode.AddLayer(currentNode.GetNextTurn());

            // Recursively explore each child node
            foreach (var child in currentNode.ChildNodes)
            {
                ExploreNode(child);
            }
        }
        // end from ChatGPT

        public void AddLayer(Token token)
        {
            if (LayerNumber >= StartingLayer)
            {
                Console.Clear();
                this.PrintNodeState();
                Console.WriteLine("Does not have a result, and has not been explored yet - adding a layer...");
                Console.ReadLine();
            }

            var possibleActions = Utility.Actions(this.State);
            foreach (var action in possibleActions)
            {
                Node newNode = new Node();
                newNode.Parent = this;
                newNode.ID = Interlocked.Increment(ref StaticID);
                newNode.LayerNumber = newNode.Parent.LayerNumber + 1;
                //newNode.Player = this.Parent == null ? Token.Letter.X : SetPlayer(this.Player);
                State newState = new State();

                newState.Tokens = new Token[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        newState.Tokens[i, j] = State.Tokens[i, j];
                    }
                }

                //newNode.State = Utility.Result(newState, new Action(action.X, action.Y, new Token() { LetterValue = newNode.Player }));
                newNode.State = Utility.Result(newState, new Action(action.X, action.Y, token));

                newNode.State.HasAResult = Utility.HasResult(newNode.State);

                //if (newNode.State.HasAResult)
                //{
                //    if (Utility.HasAWinner(newNode.State) && newNode.GetCurrentTurn().LetterValue == Token.Letter.X)
                //    {
                //        newNode.Winner = 1;
                //    }
                //    else if (Utility.HasAWinner(newNode.State) && newNode.GetCurrentTurn().LetterValue == Token.Letter.O)
                //    {
                //        newNode.Winner = -1;
                //    }
                //    else
                //    {
                //        newNode.Winner = 0;
                //    }

                //    if (LayerNumber >= StartingLayer)
                //    {
                //        Console.Clear();
                //        Console.WriteLine("New Node at layer " + LayerNumber + " with ID " + ID + " has a result: " + newNode.Winner);
                //        newNode.State.PrintNodeState();
                //        Console.WriteLine("Adding State:");
                //        newNode.State.PrintNodeState();
                //        Console.WriteLine("to Parent State:");
                //        State.PrintNodeState();
                //        Console.ReadLine();
                //    }
                //}

                if (!newNode.State.HasAResult && LayerNumber >= StartingLayer)
                {
                    Console.Clear();
                    Console.WriteLine("Adding State:");
                    newNode.PrintNodeState();
                    Console.WriteLine("to Parent State:");
                    Console.WriteLine("at layer: " + LayerNumber);
                    State.PrintNodeState();
                    Console.ReadLine();
                }

                this.ChildNodes
                    .Add(newNode);
            }
        }

        public Token.Letter SetPlayer(Token.Letter t) => t == Token.Letter.X ? Token.Letter.O : Token.Letter.X;

        public override bool Equals(object? obj)
        {
            if (obj is Node other)
            {
                bool matching = State.Tokens[0, 0].LetterValue.Equals(other.State.Tokens[0, 0].LetterValue) &&
                    State.Tokens[0, 1].LetterValue.Equals(other.State.Tokens[0, 1].LetterValue) &&
                    State.Tokens[0, 2].LetterValue.Equals(other.State.Tokens[0, 2].LetterValue) &&
                    State.Tokens[1, 0].LetterValue.Equals(other.State.Tokens[1, 0].LetterValue) &&
                    State.Tokens[1, 1].LetterValue.Equals(other.State.Tokens[1, 1].LetterValue) &&
                    State.Tokens[1, 2].LetterValue.Equals(other.State.Tokens[1, 2].LetterValue) &&
                    State.Tokens[2, 0].LetterValue.Equals(other.State.Tokens[2, 0].LetterValue) &&
                    State.Tokens[2, 1].LetterValue.Equals(other.State.Tokens[2, 1].LetterValue) &&
                    State.Tokens[2, 2].LetterValue.Equals(other.State.Tokens[2, 2].LetterValue);

                return matching;
            }
            return false;
        }

        //public void PrintNodeState()
        //{
        //    int nextMove = 0;
        //    //Console.WriteLine("Layer: " + LayerNumber);
        //    //Console.WriteLine("Type a number to select space:");
        //    for (int i = 0; i < 3; i++)
        //    {
        //        for (int j = 0; j < 3; j++)
        //        {
        //            if (State.Tokens[i, j].LetterValue == Token.Letter.a)
        //            {
        //                Console.BackgroundColor = ConsoleColor.Green;
        //                Console.ForegroundColor = ConsoleColor.Black;
        //            }
        //            Console.Write(State.Tokens[i, j].LetterValue == Token.Letter.a ? nextMove++ : State.Tokens[i, j].LetterValue);
        //            Console.BackgroundColor = ConsoleColor.Black;
        //            Console.ForegroundColor = ConsoleColor.White;
        //            if (j < 2)
        //            {
        //                Console.Write("|");
        //            }
        //        }
        //        Console.WriteLine();
        //    }
        //    //if (this.State.HasAResult)
        //    //{
        //    //    this.State.PrintNodeState();
        //    //    Console.WriteLine("Result: " + Winner);
        //    //    //Console.ReadLine();
        //    //}
        //    Console.WriteLine();
        //    //Console.ReadLine();
        //}

        public void PrintNodeState()
        {
            var openCoordinates = this.State.GetOpenCoordinates();
            Dictionary<(int, int), int> moveMapping = new();  // Maps coordinates to available move numbers
            int nextMove = 0;

            // Map available coordinates to dynamic numbers
            foreach (var coord in openCoordinates)
            {
                moveMapping[coord] = nextMove++;
            }

            // Loop over the 3x3 board
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    (int, int) coord = (i, j);  // Current position

                    if (State.Tokens[i, j].LetterValue == Token.Letter.a)
                    {
                        // If the spot is available, print the dynamically assigned number
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(moveMapping[coord]);  // Print dynamic number
                    }
                    else
                    {
                        // Print X or O for taken spaces
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(State.Tokens[i, j].LetterValue);  // Print X or O
                    }

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;

                    if (j < 2)
                    {
                        Console.Write("|");  // Print column separator
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }




        public override int GetHashCode()
        {
            return HashCode.Combine((State.Tokens[0, 0], State.Tokens[0, 1], State.Tokens[0, 2], State.Tokens[1, 0], State.Tokens[1, 1], State.Tokens[1, 2], State.Tokens[2, 0], State.Tokens[2, 1], State.Tokens[2, 2]).GetHashCode());
        }


        // ChatGPT Section

        public bool IsTerminal()
        {
            return Utility.HasResult(this.State);
        }

        public int GetScore()
        {
            // Check for a win for X
            if (HasPlayerWon(Token.Letter.X))
            {
                return 1; // X wins (assuming AI is X)
            }
            // Check for a win for O
            else if (HasPlayerWon(Token.Letter.O))
            {
                return -1; // O wins (assuming opponent is O)
            }
            // Check for a draw
            else if (IsDraw())
            {
                return 0; // Draw
            }

            // The game is not over yet, so no definitive score
            return 0; // Could also throw an exception here if this case should never happen
        }

        private bool HasPlayerWon(Token.Letter player)
        {
            // Check rows, columns, and diagonals for a win condition

            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (State.Tokens[row, 0].LetterValue == player &&
                    State.Tokens[row, 1].LetterValue == player &&
                    State.Tokens[row, 2].LetterValue == player)
                {
                    return true;
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (State.Tokens[0, col].LetterValue == player &&
                    State.Tokens[1, col].LetterValue == player &&
                    State.Tokens[2, col].LetterValue == player)
                {
                    return true;
                }
            }

            // Check diagonals
            if ((State.Tokens[0, 0].LetterValue == player &&
                 State.Tokens[1, 1].LetterValue == player &&
                 State.Tokens[2, 2].LetterValue == player) ||
                (State.Tokens[0, 2].LetterValue == player &&
                 State.Tokens[1, 1].LetterValue == player &&
                 State.Tokens[2, 0].LetterValue == player))
            {
                return true;
            }

            return false;
        }

        private bool IsDraw()
        {
            // If there are no empty spaces left and no winner, it's a draw
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (State.Tokens[row, col].LetterValue == Token.Letter.a) // Assuming 'a' is an empty cell
                    {
                        return false;
                    }
                }
            }

            return true; // No empty spaces, so it's a draw
        }

        public class NodeComparer : IComparer<Node>
        {
            public int Compare(Node x, Node y)
            {
                // Compare fCosts (and possibly use hCost as a tiebreaker)
                int comparison = x.fCost.CompareTo(y.fCost);
                if (comparison == 0)
                {
                    comparison = x.hCost.CompareTo(y.hCost);
                }
                return comparison;
            }
        }

        public Token GetCurrentTurn()
        {
            //int xCount = 0;
            //int oCount = 0;
            int aCount = 0;

            // Count the number of X's and O's in the current board state
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    //if (State.Tokens[row, col].LetterValue == Token.Letter.X)
                    //{
                    //    xCount++;
                    //}
                    //else if (State.Tokens[row, col].LetterValue == Token.Letter.O)
                    //{
                    //    oCount++;
                    //}
                    if (State.Tokens[row, col].LetterValue == Token.Letter.a)
                    {
                        aCount++;
                    }
                }
            }

            // Determine whose turn it is
            if (aCount % 2 == 0)
            {
                return new Token() { LetterValue = Token.Letter.O };  // X's turn
            }
            else
            {
                return new Token() { LetterValue = Token.Letter.X };  // O's turn
            }
        }

        public Token GetNextTurn()
        {
            //int xCount = 0;
            //int oCount = 0;
            int aCount = 0;

            // Count the number of X's and O's in the current board state
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    //if (State.Tokens[row, col].LetterValue == Token.Letter.X)
                    //{
                    //    xCount++;
                    //}
                    //else if (State.Tokens[row, col].LetterValue == Token.Letter.O)
                    //{
                    //    oCount++;
                    //}
                    if (State.Tokens[row, col].LetterValue == Token.Letter.a)
                    {
                        aCount++;
                    }
                }
            }

            // Determine whose turn it is
            if (aCount % 2 == 0)
            {
                return new Token() { LetterValue = Token.Letter.O};  // X's turn
            }
            else
            {
                return new Token() { LetterValue = Token.Letter.X };  // O's turn
            }
        }

        // end ChatGPT Section
    }
}
