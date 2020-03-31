using System;
using System.Collections.Generic;
using System.Text;

namespace LeuSolver
{
    public interface IGrid
    {
        bool CheckCanPlace(int x, int y);

        public void Place(int x, int y, char value);

        int Width { get; }
        int Height { get; }

        public char this[int y, int x] { get; }
    }
}
