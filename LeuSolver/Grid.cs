using System;
using System.Collections.Generic;
using System.Text;

namespace LeuSolver
{
    public class Grid : IGrid
    {
        private readonly int _width;
        private readonly int _height;
        private char[,] _grid;

        public int Width => _width;
        public int Height => _height;
        public char this[int y,int x] => _grid[y, x];

        public Grid(int width, int height, bool[,] mask)
        {
            _width = width;
            _height = height;
            _grid = new char[width, height];
            
            for(int i = 0; i < _height; i++)
            {
                for(int j = 0; j < _width; j++)
                {
                    _grid[i, j] = mask[i, j] ? '-' : ' ';
                }
            }
        }

        public Grid(IGrid source)
        {
            _width = source.Width;
            _height = source.Height;
            _grid = new char[_width, _height];

            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    _grid[i, j] = source[i,j];
                }
            }
        }

        public bool CheckCanPlace(int x, int y)
        {
            if(x >= _width || y >= _height || x < 0 || y < 0)
            {
                return false;
            }
            return _grid[y, x] == ' ';
        }

        public void Place(int x, int y, char value)
        {
            if(!CheckCanPlace(x,y))
            {
                throw new ArgumentException($"Invalid coordinates {x}:{y}");
            }
            _grid[y, x] = value;
        }

    }
}
