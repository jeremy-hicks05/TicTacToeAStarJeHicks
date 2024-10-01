namespace TicTacToeAStarJeHicks
{
    using System.Linq;
    //using TicTacToeAStarJeHicks;
    internal class Program
    {
        static void Main(string[] args)
        {
            Node rootNode = new Node();
            Node.StaticID = 0;
            //rootNode.Player = Token.Letter.X;
            Token AIToken = new Token() { LetterValue = Token.Letter.O };

            State initialState = new State();

            rootNode.State = initialState;

            List<Node> results = new();

            //for (int i = 0; i < results.Count; i++)
            //{
            //    results[i].PrintNodeState();
            //    //Console.ReadLine();
            //}

            //Console.WriteLine("Number of results: " + results.ToList().Count());
            //Console.WriteLine("Number of unique results: " + results.ToList().Distinct().Count());

            //Console.WriteLine("Starting print of explored spaces:");
            //State.PrintExploredStates();
            //Console.WriteLine("End list of explored states.");
            //Console.WriteLine("Number of explored states: " + State.ExploredStates.Count);

            Node.ExploreNode(rootNode);

            //Node.PrintAllNodes(rootNode);

            //var xWins = Node.results.Where(r => r.Winner == 1);
            //var oWins = Node.results.Where(r => r.Winner == -1);
            //var draws = Node.results.Where(r => r.Winner == 0);

            //Console.WriteLine("X Wins: " + xWins.Count());
            //Console.WriteLine("O Wins: " + oWins.Count());
            //Console.WriteLine("Draws: " + draws.Count());

            Console.WriteLine("Number of results: " + Node.results.ToList().Count());
            Console.WriteLine("Number of unique results: " + Node.results.ToList().Distinct().Count());

            //for (int i = 0; i < Node.results.Count; i++)
            //{
            //    Node.results[i].PrintNodeState();
            //    Console.ReadLine();
            //}

            Console.WriteLine("Done building tree");

            //Node.PrintAllNodes(rootNode);

            TicTacToeAI ticTac = new TicTacToeAI(rootNode);

            TicTacToeGame game = new TicTacToeGame();

            Node gameNode = rootNode;

            /*Select 7, 4, 4 to demonstrate how it looks ahead and "knows" it's going to win */
            
            while (gameNode != null && !gameNode.IsTerminal())
            {
                gameNode.PrintNodeState();
                gameNode = gameNode.ChildNodes[game.GetMove(gameNode.State.GetOpenCoordinates())];
                //gameNode.PrintNodeState();
                //gameNode = ticTac.GetBestMove(gameNode, AIToken);
                if (gameNode != null && !gameNode.IsTerminal())
                {
                    //gameNode.Player = gameNode.Player == Token.Letter.X ? Token.Letter.O : Token.Letter.X;
                    //gameNode.PrintNodeState();
                    //gameNode = gameNode.ChildNodes[game.GetMove()];
                    gameNode.PrintNodeState();
                    gameNode = ticTac.GetBestMove(gameNode, AIToken);
                }
            }

            // TODO: Manually create a game state where O should try to win
            //Token[,] tokens = new Token[3, 3]
            //{
            //    { new Token() { LetterValue = Token.Letter.O },
            //        new Token() { LetterValue = Token.Letter.X },
            //        new Token() { LetterValue = Token.Letter.a } },

            //    { new Token() { LetterValue = Token.Letter.a },
            //        new Token() { LetterValue = Token.Letter.a },
            //        new Token() { LetterValue = Token.Letter.X } },

            //    { new Token() { LetterValue = Token.Letter.O },
            //        new Token() { LetterValue = Token.Letter.X },
            //        new Token() { LetterValue = Token.Letter.a } }
            //};


            //Node testNode = new Node()
            //{
            //    ChildNodes = new List<Node>(),
            //    ID = 0,
            //    LayerNumber = 0,
            //    State = new State()
            //    {
            //        HasAResult = false,
            //        Tokens = tokens
            //    }
            //};
            //Node.ExploreNode(testNode);
            //testNode.PrintNodeState();
            //testNode.AddLayer(testNode.GetNextTurn());
            //foreach(Node n in testNode.ChildNodes)
            //{
            //    n.AddLayer(n.GetNextTurn());
            //}
            //Node nextNode = ticTac.GetBestMove(testNode, new Token() { LetterValue = Token.Letter.O });
            //nextNode.PrintNodeState();

            //rootNode.PrintNodeState();

            //Node firstHumanMove = rootNode.ChildNodes[game.GetMove()];
            //firstHumanMove.PrintNodeState();

            //Node firstAIMove = ticTac.GetBestMove(firstHumanMove, AIToken); // move by AI
            //firstAIMove.PrintNodeState();

            //Node secondHumanMove = firstAIMove.ChildNodes[game.GetMove()]; // move by Human
            //secondHumanMove.PrintNodeState();

            //Node secondAIMove = ticTac.GetBestMove(secondHumanMove, AIToken); // move by AI
            //secondAIMove.PrintNodeState();

            //Node thirdHumanhMove = secondAIMove.ChildNodes[game.GetMove()]; // move by Human
            //thirdHumanhMove.PrintNodeState();

            //Node thirdAIMove = ticTac.GetBestMove(thirdHumanhMove, AIToken); // move by AI
            //thirdAIMove.PrintNodeState();

            //Node fourthHumanMove = thirdAIMove.ChildNodes[game.GetMove()]; // move by Human
            //fourthHumanMove.PrintNodeState();//

            //Node fourthAIMove = ticTac.GetBestMove(fourthHumanMove, AIToken); // move by AI
            //fourthAIMove.PrintNodeState();

            //Node fifthHumanMove = fourthAIMove.ChildNodes[game.GetMove()];
            //fifthHumanMove.PrintNodeState();

            gameNode.PrintNodeState();
            //Console.WriteLine(gameNode.Winner + " wins!");
            Console.WriteLine("Game complete!");
            //Console.WriteLine(gameNode.Player + " wins!");
            Console.ReadLine();
        }
    }
}