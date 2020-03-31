﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeuSolver
{
    public class Piece
    {
        IList<Step> _steps;
        private readonly char _identifier;
        private Dictionary<Tuple<bool, int, int>, bool> _validPositions;
        public char Identifier => _identifier;
        public Piece(IList<Step> steps, char identifier)
        {
            _steps = steps;
            _identifier = identifier;
        }

        public bool CheckCanPlace(IGrid grid, int x, int y, int xDir, int yDir, bool swap)
        {
            foreach(var step in _steps)
            {
                var coord = CalculateCoord(step.X, step.Y, x, y, xDir, yDir, swap);
                if (!grid.CheckCanPlace(coord.X, coord.Y))
                {
                    return false;
                }
            }
            return true;
        }

        public void Place(IGrid grid, int x, int y, int xDir, int yDir, bool swap)
        {
            foreach (var step in _steps)
            {
                var coord = CalculateCoord(step.X, step.Y, x, y, xDir, yDir, swap);
                grid.Place(coord.X, coord.Y, Identifier);
            }
        }

        private Coord CalculateCoord(int x, int y, int moveX, int moveY, int xDir, int yDir, bool swap)
        {
            var xTransformed = x * xDir;
            var yTransformed = y * yDir;
            var xPos = moveX + (swap ? yTransformed : xTransformed);
            var yPos = moveY + (swap ? xTransformed : yTransformed);
            return new Coord
            {
                X = xPos,
                Y = yPos
            };
            
        }

    }
}
