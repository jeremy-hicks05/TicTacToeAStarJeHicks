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
            rootNode.Player = Token.Letter.X;

            State initialState = new State();

            rootNode.State = initialState;

            //rootNode.PrintNodeState();

            List<Node> results = new();

            //Node testNode1 = new Node();
            //testNode1.State = new State();
            //testNode1.State.Tokens[0, 0].LetterValue = Token.Letter.O;
            //testNode1.State.Tokens[0, 0].LetterValue = Token.Letter.X;
            //testNode1.State.Tokens[0, 0].LetterValue = Token.Letter.a;
            //testNode1.State.Tokens[0, 0].LetterValue = Token.Letter.X;
            //testNode1.State.Tokens[0, 0].LetterValue = Token.Letter.X;
            //testNode1.State.Tokens[0, 0].LetterValue = Token.Letter.O;
            //testNode1.State.Tokens[0, 0].LetterValue = Token.Letter.a;
            //testNode1.State.Tokens[0, 0].LetterValue = Token.Letter.X;
            //testNode1.State.Tokens[0, 0].LetterValue = Token.Letter.a;

            //Node testNode2 = new Node();
            //testNode2.State = new State();

            //testNode2.State.Tokens[0, 0].LetterValue = Token.Letter.O;
            //testNode2.State.Tokens[0, 0].LetterValue = Token.Letter.X;
            //testNode2.State.Tokens[0, 0].LetterValue = Token.Letter.a;
            //testNode2.State.Tokens[0, 0].LetterValue = Token.Letter.X;
            //testNode2.State.Tokens[0, 0].LetterValue = Token.Letter.X;
            //testNode2.State.Tokens[0, 0].LetterValue = Token.Letter.O;
            //testNode2.State.Tokens[0, 0].LetterValue = Token.Letter.a;
            //testNode2.State.Tokens[0, 0].LetterValue = Token.Letter.X;
            //testNode2.State.Tokens[0, 0].LetterValue = Token.Letter.a;

            //if (testNode1.State.Equals(testNode2.State))
            //{
            //    Console.WriteLine("Match!");
            //}

            // 9 loops
            //rootNode.AddLayer();

            ////results.AddRange(rootNode.ChildNodes.Where(cn => cn.State.HasAResult == true));

            //for (int i = 0; i < rootNode.ChildNodes.Count; i++)
            //{
            //    if (!rootNode.ChildNodes[i].State.HasAResult)
            //    {
            //        rootNode.ChildNodes[i].AddLayer();
            //    }
            //    else
            //    {
            //        results.Add(rootNode.ChildNodes[i]);
            //    }
            //}

            //for (int i = 0; i < rootNode.ChildNodes.Count; i++)
            //{
            //    for (int j = 0; j < rootNode.ChildNodes[i].ChildNodes.Count; j++)
            //    {
            //        if (!rootNode.ChildNodes[i].ChildNodes[j].State.HasAResult)
            //        {
            //            rootNode.ChildNodes[i].ChildNodes[j].AddLayer();
            //        }
            //        else
            //        {
            //            results.Add(rootNode.ChildNodes[i].ChildNodes[j]);
            //        }
            //    }
            //}

            //for (int i = 0; i < rootNode.ChildNodes.Count; i++)
            //{
            //    for (int j = 0; j < rootNode.ChildNodes[i].ChildNodes.Count; j++)
            //    {
            //        for (int k = 0; k < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes.Count; k++)
            //        {
            //            if (!rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].State.HasAResult)
            //            {
            //                rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].AddLayer();
            //            }
            //            else
            //            {
            //                results.Add(rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k]);
            //            }
            //        }
            //    }
            //}

            //for (int i = 0; i < rootNode.ChildNodes.Count; i++)
            //{
            //    for (int j = 0; j < rootNode.ChildNodes[i].ChildNodes.Count; j++)
            //    {
            //        for (int k = 0; k < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes.Count; k++)
            //        {
            //            for (int l = 0; l < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes.Count; l++)
            //            {
            //                if (!rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].State.HasAResult)
            //                {
            //                    rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].AddLayer();
            //                }
            //                else
            //                {
            //                    results.Add(rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l]);
            //                }
            //            }
            //        }
            //    }
            //}

            //for (int i = 0; i < rootNode.ChildNodes.Count; i++)
            //{
            //    for (int j = 0; j < rootNode.ChildNodes[i].ChildNodes.Count; j++)
            //    {
            //        for (int k = 0; k < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes.Count; k++)
            //        {
            //            for (int l = 0; l < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes.Count; l++)
            //            {
            //                for (int m = 0; m < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes.Count; m++)
            //                {
            //                    if (!rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].State.HasAResult)
            //                    {
            //                        rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].AddLayer();
            //                    }
            //                    else
            //                    {
            //                        results.Add(rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m]);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            //for (int i = 0; i < rootNode.ChildNodes.Count; i++)
            //{
            //    for (int j = 0; j < rootNode.ChildNodes[i].ChildNodes.Count; j++)
            //    {
            //        for (int k = 0; k < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes.Count; k++)
            //        {
            //            for (int l = 0; l < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes.Count; l++)
            //            {
            //                for (int m = 0; m < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes.Count; m++)
            //                {
            //                    for (int n = 0; n < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes.Count; n++)
            //                    {
            //                        if (!rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].State.HasAResult)
            //                        {
            //                            rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].AddLayer();
            //                        }
            //                        else
            //                        {
            //                            results.Add(rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n]);
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            //for (int i = 0; i < rootNode.ChildNodes.Count; i++)
            //{
            //    for (int j = 0; j < rootNode.ChildNodes[i].ChildNodes.Count; j++)
            //    {
            //        for (int k = 0; k < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes.Count; k++)
            //        {
            //            for (int l = 0; l < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes.Count; l++)
            //            {
            //                for (int m = 0; m < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes.Count; m++)
            //                {
            //                    for (int n = 0; n < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes.Count; n++)
            //                    {
            //                        for (int o = 0; o < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].ChildNodes.Count; o++)
            //                        {
            //                            if (!rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].State.HasAResult)
            //                            {
            //                                rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].ChildNodes[o].AddLayer();
            //                            }
            //                            else
            //                            {
            //                                results.Add(rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].ChildNodes[o]);
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            //for (int i = 0; i < rootNode.ChildNodes.Count; i++)
            //{
            //    for (int j = 0; j < rootNode.ChildNodes[i].ChildNodes.Count; j++)
            //    {
            //        for (int k = 0; k < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes.Count; k++)
            //        {
            //            for (int l = 0; l < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes.Count; l++)
            //            {
            //                for (int m = 0; m < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes.Count; m++)
            //                {
            //                    for (int n = 0; n < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes.Count; n++)
            //                    {
            //                        for (int o = 0; o < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].ChildNodes.Count; o++)
            //                        {
            //                            for (int p = 0; p < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].ChildNodes[o].ChildNodes.Count; p++)
            //                            {
            //                                if (!rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].ChildNodes[o].ChildNodes[p].State.HasAResult)
            //                                {
            //                                    rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].ChildNodes[o].ChildNodes[p].AddLayer();
            //                                }
            //                                else
            //                                {
            //                                    results.Add(rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].ChildNodes[o].ChildNodes[p]);
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            //for (int i = 0; i < rootNode.ChildNodes.Count; i++)
            //{
            //    for (int j = 0; j < rootNode.ChildNodes[i].ChildNodes.Count; j++)
            //    {
            //        for (int k = 0; k < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes.Count; k++)
            //        {
            //            for (int l = 0; l < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes.Count; l++)
            //            {
            //                for (int m = 0; m < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes.Count; m++)
            //                {
            //                    for (int n = 0; n < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes.Count; n++)
            //                    {
            //                        for (int o = 0; o < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].ChildNodes.Count; o++)
            //                        {
            //                            for (int p = 0; p < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].ChildNodes[o].ChildNodes.Count; p++)
            //                            {
            //                                for (int q = 0; q < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].ChildNodes[o].ChildNodes[p].ChildNodes.Count; q++)
            //                                {
            //                                    if (!rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].ChildNodes[o].ChildNodes[p].ChildNodes[q].State.HasAResult)
            //                                    {
            //                                        rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].ChildNodes[o].ChildNodes[p].ChildNodes[q].AddLayer();
            //                                    }
            //                                    else
            //                                    {
            //                                        results.Add(rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].ChildNodes[o].ChildNodes[p].ChildNodes[q]);
            //                                    }
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            //for (int i = 0; i < rootNode.ChildNodes.Count; i++)
            //{
            //    for (int j = 0; j < rootNode.ChildNodes[i].ChildNodes.Count; j++)
            //    {
            //        for (int k = 0; k < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes.Count; k++)
            //        {
            //            for (int l = 0; l < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes.Count; l++)
            //            {
            //                for (int m = 0; m < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes.Count; m++)
            //                {
            //                    for (int n = 0; n < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes.Count; n++)
            //                    {
            //                        for (int o = 0; o < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].ChildNodes.Count; o++)
            //                        {
            //                            for (int p = 0; p < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].ChildNodes[o].ChildNodes.Count; p++)
            //                            {
            //                                for (int q = 0; q < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].ChildNodes[o].ChildNodes[p].ChildNodes.Count; q++)
            //                                {
            //                                    for (int r = 0; r < rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].ChildNodes[o].ChildNodes[p].ChildNodes[q].ChildNodes.Count; r++)
            //                                    {
            //                                        if (!rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].ChildNodes[o].ChildNodes[p].ChildNodes[q].State.HasAResult)
            //                                        {
            //                                            rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].ChildNodes[o].ChildNodes[p].ChildNodes[q].ChildNodes[r].AddLayer();
            //                                        }
            //                                        else
            //                                        {
            //                                            results.Add(rootNode.ChildNodes[i].ChildNodes[j].ChildNodes[k].ChildNodes[l].ChildNodes[m].ChildNodes[n].ChildNodes[o].ChildNodes[p].ChildNodes[q].ChildNodes[r]);
            //                                        }
            //                                    }
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            //rootNode.PrintNodeState();

            //results = results.Distinct().ToList();
            //var xWins = results.Where(r => r.Winner == 1);
            //var oWins = results.Where(r => r.Winner == -1);
            //var draws = results.Where(r => r.Winner == 0);

            //Console.WriteLine("X Wins: " + xWins.Count());
            //Console.WriteLine("O Wins: " + oWins.Count());
            //Console.WriteLine("Draws: " + draws.Count());

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

            var xWins = Node.results.Where(r => r.Winner == 1);
            var oWins = Node.results.Where(r => r.Winner == -1);
            var draws = Node.results.Where(r => r.Winner == 0);

            Console.WriteLine("X Wins: " + xWins.Count());
            Console.WriteLine("O Wins: " + oWins.Count());
            Console.WriteLine("Draws: " + draws.Count());

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

            while (gameNode != null && !gameNode.IsTerminal())
            {
                gameNode.PrintNodeState();
                gameNode = ticTac.GetBestMove(gameNode);
                if (gameNode != null && !gameNode.IsTerminal())
                {
                    gameNode.PrintNodeState();
                    gameNode = gameNode.ChildNodes[game.GetMove()];
                }
            }

            //rootNode.PrintNodeState();

            //Node firstHumanMove = rootNode.ChildNodes[game.GetMove()];
            //firstHumanMove.PrintNodeState();

            //Node firstAIMove = ticTac.GetBestMove(firstHumanMove); // move by AI
            //firstAIMove.PrintNodeState();

            //Node secondHumanMove = firstAIMove.ChildNodes[game.GetMove()]; // move by Human
            //secondHumanMove.PrintNodeState();

            //Node secondAIMove = ticTac.GetBestMove(secondHumanMove); // move by AI
            //secondAIMove.PrintNodeState();

            //Node thirdHumanhMove = secondAIMove.ChildNodes[0]; // move by Human
            //thirdHumanhMove.PrintNodeState();

            //Node thirdAIMove = ticTac.GetBestMove(thirdHumanhMove); // move by AI
            //thirdAIMove.PrintNodeState();

            //Node fourthHumanMove = thirdAIMove.ChildNodes[game.GetMove()]; // move by Human
            //fourthHumanMove.PrintNodeState();//

            //Node fourthAIMove = ticTac.GetBestMove(fourthHumanMove); // move by AI
            //fourthAIMove.PrintNodeState();

            //Node fifthHumanMove = fourthAIMove.ChildNodes[game.GetMove()];
            //fifthHumanMove.PrintNodeState();

            gameNode.PrintNodeState();
            Console.WriteLine("Game complete!");
            //Console.WriteLine(gameNode.Player + " wins!");
            Console.ReadLine();
        }
    }
}