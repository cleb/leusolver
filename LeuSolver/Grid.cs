using System;
using System.Diagnostics.CodeAnalysis;

namespace LeuSolver
{
    public class Grid : IGrid, IEquatable<IGrid>
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

        private bool IsOutOfRange(int x, int y)
        {
            return x >= _width || y >= _height || x < 0 || y < 0;
        }

        public bool CheckCanPlace(int x, int y)
        {
            if(IsOutOfRange(x,y))
            {
                return false;
            }
            return _grid[y, x] == ' ';
        }

        public void Place(int x, int y, char value)
        {
            if(IsOutOfRange(x, y))
            {
                throw new ArgumentException($"Invalid coordinates {x}:{y}");
            }
            _grid[y, x] = value;
        }

        public bool Equals([AllowNull] IGrid other)
        {
            if(other.Width != Width || other.Height != Height)
            {
                return false;
            }
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if(_grid[i, j] != other[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            var item = obj as IGrid;
            if (item == null)
            {
                return false;
            }

            return this.Equals(item);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            for(int i = 0; i< Height; i++)
            {
                for(int j = 0; j < Width; j++)
                {
                    hash = hash * 23 + i.GetHashCode();
                    hash = hash * 23 + j.GetHashCode();
                    hash = hash * 23 + _grid[i,j].GetHashCode();
                }
            }
            return hash;
        }
    }
}
