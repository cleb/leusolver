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
            foreach(var piece in _availablePieces)
            {
                for(int i =0; i< _grid.Height; i++)
                {
                    for (int j = 0; j < _grid.Width; j++)
                    {
                        var winningState = CheckAllNextStates(piece, j, i);
                        if (winningState != null)
                        {
                            return winningState;
                        }                        
                    }
                }                
            }
            return null;
        }

        public State CheckAllNextStates(Piece piece, int x, int y)
        {
            return CheckNextState(piece, x, y, 1, 1, false)
                ?? CheckNextState(piece, x, y, -1, 1, false)
                ?? CheckNextState(piece, x, y, 1, -1, false)
                ?? CheckNextState(piece, x, y, -1, -1, false)
                ?? CheckNextState(piece, x, y, 1, 1, true)
                ?? CheckNextState(piece, x, y, -1, 1, true)
                ?? CheckNextState(piece, x, y, 1, -1, true)
                ?? CheckNextState(piece, x, y, -1, -1, true);
        }

        public State CheckNextState(Piece piece, int x, int y, int xDir, int yDir, bool swap)
        {
            if (piece.CheckCanPlace(_grid, x, y, xDir, yDir, swap))
            {
                var newSteps = _availablePieces.Where(x => x != piece).ToList();
                var newGrid = new Grid(_grid);
                piece.Place(newGrid, x, y, xDir, yDir, swap);
                var candidate = new State(newSteps, newGrid);
                var candidateState = candidate.GetWinningState();
                if (candidateState != null)
                {
                    return candidateState;
                }
            }
            return null;
        }
    }
}
