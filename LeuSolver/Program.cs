using System;
using System.Collections.Generic;

namespace LeuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var pieceA = new Piece(new List<Step>
            {
                new Step
                {
                    X = 0,
                    Y = 0
                },
                new Step
                {
                    X = 0,
                    Y = 1
                },
                new Step
                {
                    X = 0,
                    Y = 2
                },
                new Step
                {
                    X = 1,
                    Y = 2
                },
            }, 'A');

            var pieceB = new Piece(new List<Step>
            {
                new Step
                {
                    X = 0,
                    Y = 0
                },
                new Step
                {
                    X = 0,
                    Y = 1
                },
                new Step
                {
                    X = 1,
                    Y = 1
                },
                new Step
                {
                    X = 0,
                    Y = 2
                },
                new Step
                {
                    X = 1,
                    Y = 2
                },
            }, 'B');

            var pieceC = new Piece(new List<Step>
            {
                new Step
                {
                    X = 0,
                    Y = 0
                },
                new Step
                {
                    X = 0,
                    Y = 1
                },
                new Step
                {
                    X = 0,
                    Y = 2
                },
                new Step
                {
                    X = 0,
                    Y = 3
                },
                new Step
                {
                    X = 1,
                    Y = 3
                }
            }, 'C');

            var pieceD = new Piece(new List<Step>
            {
                new Step
                {
                    X = 0,
                    Y = 0
                },
                new Step
                {
                    X = 0,
                    Y = 1
                },
                new Step
                {
                    X = 0,
                    Y = 2
                },
                new Step
                {
                    X = 0,
                    Y = 3
                },
                new Step
                {
                    X = 1,
                    Y = 2
                },
            }, 'D');

            var pieceE = new Piece(new List<Step>
            {
                new Step
                {
                    X = 0,
                    Y = 0
                },
                new Step
                {
                    X = 0,
                    Y = 1
                },
                new Step
                {
                    X = 0,
                    Y = 2
                },
                new Step
                {
                    X = 1,
                    Y = 2
                },
                new Step
                {
                    X = 1,
                    Y = 3
                },
            }, 'E');

            var pieceF = new Piece(new List<Step>
            {
                new Step
                {
                    X = 0,
                    Y = 0
                },
                new Step
                {
                    X = 0,
                    Y = 1
                },
                new Step
                {
                    X = 1,
                    Y = 1
                }
            }, 'F');
            var pieceG = new Piece(new List<Step>
            {
                new Step
                {
                    X = 0,
                    Y = 0
                },
                new Step
                {
                    X = 0,
                    Y = 1
                },
                new Step
                {
                    X = 0,
                    Y = 2
                },
                new Step
                {
                    X = 1,
                    Y = 2
                },
                new Step
                {
                    X = 2,
                    Y = 2
                }
            }, 'G');

            var pieceH = new Piece(new List<Step>
            {
                new Step
                {
                    X = 0,
                    Y = 0
                },
                new Step
                {
                    X = 0,
                    Y = 1
                },
                new Step
                {
                    X = 1,
                    Y = 1
                },
                new Step
                {
                    X = 1,
                    Y = 2
                },
                new Step
                {
                    X = 2,
                    Y = 2
                }
            }, 'H');

            var pieceI = new Piece(new List<Step>
            {
                new Step
                {
                    X = 0,
                    Y = 0
                },
                new Step
                {
                    X = 1,
                    Y = 0
                },
                new Step
                {
                    X = 0,
                    Y = 1
                },
                new Step
                {
                    X = 0,
                    Y = 2
                },
                new Step
                {
                    X = 1,
                    Y = 2
                },
            }, 'I');

            var pieceJ = new Piece(new List<Step>
            {
                new Step
                {
                    X = 0,
                    Y = 0
                },
                new Step
                {
                    X = 0,
                    Y = 1
                },
                new Step
                {
                    X = 0,
                    Y = 2
                },
                new Step
                {
                    X = 0,
                    Y = 3
                },
            },'J');

            var pieceK = new Piece(new List<Step>
            {
                new Step
                {
                    X = 0,
                    Y = 0
                },
                new Step
                {
                    X = 0,
                    Y = 1
                },
                new Step
                {
                    X = 1,
                    Y = 0
                },
                new Step
                {
                    X = 1,
                    Y = 1
                },
            }, 'K', true);

            var pieceL = new Piece(new List<Step>
            {
                new Step
                {
                    X = 1,
                    Y = 0
                },
                new Step
                {
                    X = 1,
                    Y = 1
                },
                new Step
                {
                    X = 1,
                    Y = 2
                },
                new Step
                {
                    X = 0,
                    Y = 1
                },
                new Step
                {
                    X = 2,
                    Y = 1
                }
            }, 'L', true);



            var pieces = new List<Piece> { pieceA, pieceB, pieceC, pieceD, pieceE, pieceF, pieceG, pieceH, pieceI, pieceJ, pieceK, pieceL };
            var grid = new Grid(10, 10, new bool[,] {
                { true,  true,  true,  true,  true,  true,  true,  true,  true,  false},
                { true,  true,  true,  true,  true,  true,  true,  true,  false, false},
                { true,  true,  true,  true,  true,  true,  true,  false, false, false},
                { true,  true,  true,  true,  true,  true,  false, false, false, false},
                { true,  true,  true,  true,  true,  false, false, false, false, false},
                { true,  true,  true,  true,  false, false, false, false, false, false},
                { true,  true,  true,  false, false, false, false, false, false, false},
                { true,  true,  false, false, false, false, false, false, false, false},
                { true,  false, false, false, false, false, false, false, false, false},
                { false, false, false, false, false, false, false, false, false, false},
            });

            pieceB.Place(grid, 9, 7, -1, 1, false);
            pieceH.Place(grid, 9, 5, -1, 1, false);

            pieces.Remove(pieceB);
            pieces.Remove(pieceH);

            var state = new State(pieces, grid, new Optimizer());
            var winningState = state.GetWinningState();

            Console.WriteLine("====");

            var winningGrid = winningState.Grid;
            for (int y = 0; y < winningGrid.Height; y++)
            {
                for (int x = 0; x < winningGrid.Width; x++)
                {
                    Console.Write(winningGrid[y, x]);                                        
                }
                Console.WriteLine("");
            }

            Console.WriteLine("====");

        }
    }
}
