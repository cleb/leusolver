using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeuSolver;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeuSolver.Tests
{
    [TestClass()]
    public class PieceTests
    {
        [TestMethod()]
        public void CheckCanPlaceTest()
        {
            var grid = new Grid(2, 2, new bool[,] { { false, false }, { true, false } });
            var piece = new Piece(new List<Step> { new Step { X = 0, Y = 0 }, new Step { X = 1, Y = 0 } }, 'a');
            Assert.IsTrue(piece.CheckCanPlace(grid, 0, 0, 1, 1,false));
            Assert.IsFalse(piece.CheckCanPlace(grid, 1, 0, 1, 1, false));
            Assert.IsFalse(piece.CheckCanPlace(grid, 0, 0, 1, 1, true));
            Assert.IsTrue(piece.CheckCanPlace(grid, 1, 0, 1, -1, true));
        }

        [TestMethod()]
        public void PlaceTest()
        {
            var grid = new Grid(2, 2, new bool[,] { { false, false }, { false, false } });
            var piece = new Piece(new List<Step> { new Step { X = 0, Y = 0 }, new Step { X = 1, Y = 0 } }, 'a');
            piece.Place(grid, 0, 0, 1, 1, false);
            Assert.IsFalse(grid.CheckCanPlace(0, 0));
            Assert.IsFalse(grid.CheckCanPlace(1, 0));
            Assert.IsTrue(grid.CheckCanPlace(0, 1));
            Assert.IsTrue(grid.CheckCanPlace(1, 1));
        }
    }
}