using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeAStarJeHicks
{
    internal class Node
    {
        // properties
        private int StartingLayer = 10;
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

        // constructors
        public Node()
        {
            State = new State();
        }
        //public Node(State state)
        //{
        //    State = state;
        //}

        // From ChatGPT
        public static void ExploreNode(Node currentNode)
        {
            // If the node has a result, add it to the results list and stop further exploration
            if (currentNode.State.HasAResult)
            {
                results.Add(currentNode);
                Console.WriteLine($"Result Found - ID: {currentNode.ID}, Winner: {currentNode.Winner}");
                currentNode.PrintNodeState();
                Console.ReadLine();
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

            if (this.State.HasAResult || State.ExploredStates.Contains(this.State))
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
            Console.WriteLine("Layer: " + LayerNumber);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(State.Tokens[i, j].LetterValue == Token.Letter.a ? " " : State.Tokens[i, j].LetterValue);
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
        }

        //public override int GetHashCode() =>
        //    HashCode.Combine(State.Tokens.Cast<Token>().Select(t => t.LetterValue).ToArray());


        public override int GetHashCode()
        {
            return HashCode.Combine((State.Tokens[0, 0], State.Tokens[0, 1], State.Tokens[0, 2], State.Tokens[1, 0], State.Tokens[1, 1], State.Tokens[1, 2], State.Tokens[2, 0], State.Tokens[2, 1], State.Tokens[2, 2]).GetHashCode());
        }
    }
}
