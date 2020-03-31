using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeuSolver
{
    public class State
    {
        IList<Piece> _availablePieces;
        IGrid _grid;
        public IGrid Grid => _grid;
        public State(IList<Piece> availablePieces, IGrid grid)
        {
            _availablePieces = availablePieces;
            _grid = grid;
        }

        public State GetWinningState()
        {
            for(int i =0; i< _grid.Height; i++)
            {
                for (int j = 0; j < _grid.Width; j++)
                {
                    foreach (var piece in _availablePieces)
                    {
                        var newPieces = _availablePieces.Where(x => x != piece).ToList();
                        var winningState = CheckAllNextStates(piece, j, i, newPieces);
                        if (winningState != null)
                        {
                            return winningState;
                        }
                    }
                }
            }                
            return null;
        }

        public State CheckAllNextStates(Piece piece, int x, int y, IList<Piece> pieces)
        {
            return CheckNextState(piece, x, y, 1, 1, false, pieces)
                ?? CheckNextState(piece, x, y, -1, 1, false, pieces)
                ?? CheckNextState(piece, x, y, 1, -1, false, pieces)
                ?? CheckNextState(piece, x, y, -1, -1, false, pieces)
                ?? CheckNextState(piece, x, y, 1, 1, true, pieces)
                ?? CheckNextState(piece, x, y, -1, 1, true, pieces)
                ?? CheckNextState(piece, x, y, 1, -1, true, pieces)
                ?? CheckNextState(piece, x, y, -1, -1, true, pieces);
        }

        public State CheckNextState(Piece piece, int x, int y, int xDir, int yDir, bool swap, IList<Piece> pieces)
        {
            if (piece.CheckCanPlace(_grid, x, y, xDir, yDir, swap))
            {
                //final state
                if(pieces.Count == 0)
                {
                    return this;
                }
                var newGrid = new Grid(_grid);
                piece.Place(newGrid, x, y, xDir, yDir, swap);

                if (!IsPossibleGrid(newGrid))
                {
                    return null;
                }

                var candidate = new State(pieces, newGrid);
                var candidateState = candidate.GetWinningState();
                if (candidateState != null)
                {
                    return candidateState;
                }
            }
            return null;
        }
        private bool IsPossibleGrid(IGrid grid)
        {
            for(int y = 0; y < grid.Height; y++)
            {
                for(int x = 0; x < grid.Width; x++)
                {
                    if(grid.CheckCanPlace(x,y) && !grid.CheckCanPlace(x + 1, y) && !grid.CheckCanPlace(x -1 , y) && !grid.CheckCanPlace(x, y + 1) && !grid.CheckCanPlace(x , y - 1))
                    {
                        return false;
                    }

                    if (grid.CheckCanPlace(x, y) && grid.CheckCanPlace(x + 1, y) 
                        && !grid.CheckCanPlace(x - 1, y) && !grid.CheckCanPlace(x, y + 1) && !grid.CheckCanPlace(x, y - 1)
                        && !grid.CheckCanPlace(x + 2, y) && !grid.CheckCanPlace(x + 1 , y + 1) && !grid.CheckCanPlace(x + 1, y - 1))
                    {
                        return false;
                    }

                    if (grid.CheckCanPlace(x, y) && grid.CheckCanPlace(x, y + 1)
                        && !grid.CheckCanPlace(x , y - 1) && !grid.CheckCanPlace(x + 1, y) && !grid.CheckCanPlace(x - 1, y)
                        && !grid.CheckCanPlace(x, y + 2) && !grid.CheckCanPlace(x + 1, y + 1) && !grid.CheckCanPlace(x - 1, y + 1))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
