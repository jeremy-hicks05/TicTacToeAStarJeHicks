using System;
using System.Collections.Generic;
using System.Linq;
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
        public Token.Letter Player = new Token.Letter();
        public int Winner { get; set; }
        public int LayerNumber { get; set; }


        public static List<Node> results = new List<Node>();


        // ChatGPT Section

        public State[,] Tokens { get; private set; } // 2D array representing the board state
        //public Token.Letter CurrentPlayer { get; private set; } // Current player making the move

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
            Player = currentPlayer; // Assign the current player
        }

        public Node(State[,] tokens, Token.Letter currentPlayer)
        {
            Tokens = tokens; // Assign the board state
            Player = currentPlayer;
            //CurrentPlayer = currentPlayer; // Assign the current player
        }

        public Node(Token.Letter[,] newBoard, Token.Letter letter)
        {
            Player = letter;
            this.State = new State(newBoard);
        }

        //public Node(State state)
        //{
        //    State = state;
        //}

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

                // add result to parent
                currentNode.Parent.Winner = currentNode.Winner;
                results.Add(currentNode.Parent);

                //Console.WriteLine($"Result Found - ID: {currentNode.ID}, Winner: {currentNode.Winner}");
                //currentNode.PrintNodeState();
                //Console.ReadLine();

                return;
            }

            // Add a new layer of children to the current node
            currentNode.AddLayer();

            // Recursively explore each child node
            foreach (var child in currentNode.ChildNodes)
            {
                ExploreNode(child);
            }
        }
        // end from ChatGPT

        public void AddLayer()
        {

            if (this.State.HasAResult
                //|| State.ExploredStates.Contains(this.State)
                )
            {
                if (LayerNumber >= StartingLayer)
                {
                    Console.Clear();
                    this.PrintNodeState();
                    Console.WriteLine("Has a result? " + this.State.HasAResult + ". State already explored? " + State.ExploredStates.Contains(this.State) + " - not adding a layer");
                    if (State.ExploredStates.Contains(this.State))
                    {
                        Console.WriteLine("Explored by State: ");
                        State.ExploredStates.First(es => es.Equals(this.State)).PrintNodeState();
                    }
                    Console.ReadLine();
                }
            }
            else
            {
                State.ExploredStates.Add(this.State);
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
                    newNode.Player = this.Parent == null ? Token.Letter.X : SetPlayer(this.Player);
                    State newState = new State();

                    newState.Tokens = new Token[3, 3];
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            newState.Tokens[i, j] = State.Tokens[i, j];
                        }
                    }

                    newNode.State = Utility.Result(newState, new Action(action.X, action.Y, new Token() { LetterValue = newNode.Player }));

                    newNode.State.HasAResult = Utility.HasResult(newNode.State);

                    if (newNode.State.HasAResult)
                    {
                        if (Utility.HasAWinner(newNode.State) && newNode.Player == Token.Letter.X)
                        {
                            newNode.Winner = 1;
                        }
                        else if (Utility.HasAWinner(newNode.State) && newNode.Player == Token.Letter.O)
                        {
                            newNode.Winner = -1;
                        }
                        else
                        {
                            newNode.Winner = 0;
                        }

                        if (LayerNumber >= StartingLayer)
                        {
                            Console.Clear();
                            Console.WriteLine("New Node at layer " + LayerNumber + " with ID " + ID + " has a result: " + newNode.Winner);
                            newNode.State.PrintNodeState();
                            Console.WriteLine("Adding State:");
                            newNode.State.PrintNodeState();
                            Console.WriteLine("to Parent State:");
                            State.PrintNodeState();
                            Console.ReadLine();
                        }
                    }

                    if (!newNode.State.HasAResult && LayerNumber >= StartingLayer)
                    {
                        Console.Clear();
                        Console.WriteLine(newNode.Player + " Adding State:");
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
        }

        public Token.Letter SetPlayer(Token.Letter t) => t == Token.Letter.X ? Token.Letter.O : Token.Letter.X;


        //public Token.Letter SetPlayer(Token.Letter t)
        //{
        //    if (Parent != null)
        //    {
        //        return (t == Token.Letter.X ? Token.Letter.O : Token.Letter.X);
        //    }
        //    return Token.Letter.X;
        //}

        //public override bool Equals(object? obj)
        //{
        //    if (obj is Node other)
        //    {
        //        return State.Tokens.Cast<Token>().Select(t => t.LetterValue)
        //            .SequenceEqual(other.State.Tokens.Cast<Token>().Select(t => t.LetterValue));
        //    }
        //    return false;
        //}


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

                //if (matching)
                //{
                //    State.PrintNodeState();
                //    other.State.PrintNodeState();
                //    Console.WriteLine("Nodes match? " + matching);
                //    Console.ReadLine();
                //}
                return matching;
            }
            return false;
        }

        public void PrintNodeState()
        {
            int nextMove = 0;
            //Console.WriteLine("Layer: " + LayerNumber);
            Console.WriteLine("Type a number to select space:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (State.Tokens[i, j].LetterValue == Token.Letter.a)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(State.Tokens[i, j].LetterValue == Token.Letter.a ? nextMove++ : State.Tokens[i, j].LetterValue);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    if (j < 2)
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
            }
            //if (this.State.HasAResult)
            //{
            //    this.State.PrintNodeState();
            //    Console.WriteLine("Result: " + Winner);
            //    //Console.ReadLine();
            //}
            Console.WriteLine();
            //Console.ReadLine();
        }

        //public override int GetHashCode() =>
        //    HashCode.Combine(State.Tokens.Cast<Token>().Select(t => t.LetterValue).ToArray());


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




        public int CalculateHeuristic(Token.Letter player)
        {
            // Heuristic example: favor states where the player has more chances to win
            int score = 0;

            // Add logic to check rows, columns, and diagonals for potential win opportunities
            // For example, count lines where the player can still win (no opponent's marks in the line).

            return score;
        }

        //public void AStarSearch(Token.Letter player, Node startNode)
        //{
        //    // Priority queue to hold nodes sorted by f(n)
        //    var openSet = new SortedSet<Node>(new NodeComparer());

        //    // Initialize the first node and add it to the queue
        //    startNode.gCost = 0;
        //    startNode.hCost = startNode.CalculateHeuristic(player);
        //    startNode.fCost = startNode.gCost + startNode.hCost;
        //    openSet.Add(startNode);

        //    // While there are nodes to explore
        //    while (openSet.Count > 0)
        //    {
        //        // Get the node with the lowest f(n)
        //        Node currentNode = openSet.Min;
        //        openSet.Remove(currentNode);

        //        // Check if it's a win or terminal state
        //        if (currentNode.IsTerminal())
        //        {
        //            // Goal reached, reconstruct the path or process the result
        //            return;
        //        }

        //        // Explore neighbors
        //        foreach (var neighbor in currentNode.GetNeighbors())
        //        {
        //            // Calculate costs
        //            int tentativeGCost = currentNode.gCost + 1; // Move cost, depth increase

        //            if (tentativeGCost < neighbor.gCost)
        //            {
        //                // This path to neighbor is better, update its costs
        //                neighbor.gCost = tentativeGCost;
        //                neighbor.hCost = neighbor.CalculateHeuristic(player);
        //                neighbor.fCost = neighbor.gCost + neighbor.hCost;

        //                if (!openSet.Contains(neighbor))
        //                {
        //                    openSet.Add(neighbor);
        //                }
        //            }
        //        }
        //    }
        //}

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

        //public List<Node> GetNeighbors(int layer)
        //{
        //    List<Node> neighbors = new List<Node>();

        //    // Get the current player (X or O)
        //    Token.Letter currentPlayer = this.Player;

        //    // Iterate over the 2D board to find empty cells
        //    for (int row = 0; row < State.Tokens.GetLength(0); row++)
        //    {
        //        for (int col = 0; col < State.Tokens.GetLength(1); col++)
        //        {
        //            if (State.Tokens[row, col].LetterValue == Token.Letter.a) // Assuming 'a' represents an empty cell
        //            {
        //                // Create a new board configuration by placing the current player's mark
        //                Token.Letter[,] newBoard = (Token.Letter[,])State.Tokens.Clone();
        //                newBoard[row, col] = currentPlayer;

        //                // Create a new node for this neighbor
        //                Node neighbor = new Node(newBoard, GetNextPlayer(currentPlayer));

        //                // Optionally calculate costs here if not done in AStarSearch
        //                neighbor.gCost = this.gCost + 1; // Depth increase
        //                neighbor.hCost = neighbor.CalculateHeuristic(currentPlayer);
        //                neighbor.fCost = neighbor.gCost + neighbor.hCost;

        //                // Add the neighbor to the list
        //                neighbors.Add(neighbor);
        //            }
        //        }
        //    }

        //    return neighbors;
        //}

        public Token.Letter GetNextPlayer(Token.Letter currentPlayer)
        {
            // Assuming LetterValue.X represents player X and LetterValue.O represents player O
            if (currentPlayer == Token.Letter.X)
            {
                return Token.Letter.O;
            }
            else
            {
                return Token.Letter.X;
            }
        }

        internal Node Copy()
        {
            throw new NotImplementedException();
        }



        // end ChatGPT Section
    }
}
