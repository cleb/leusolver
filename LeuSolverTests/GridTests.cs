using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeuSolver;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeuSolver.Tests
{
    [TestClass()]
    public class GridTests
    {
        [TestMethod()]
        public void GridTest()
        {
            var grid = new Grid(2,2,new bool[,] { {false, false }, { true, true } });
            Assert.IsTrue(grid.CheckCanPlace(0, 0));
            Assert.IsTrue(grid.CheckCanPlace(1, 0));
            Assert.IsFalse(grid.CheckCanPlace(0, 1));
            Assert.IsFalse(grid.CheckCanPlace(1, 1));
        }

        [TestMethod()]
        public void GridCopyTest()
        {
            var grid = new Grid(2, 2, new bool[,] { { false, false }, { true, true } });
            var grid2 = new Grid(grid);
            Assert.IsTrue(grid2.CheckCanPlace(0, 0));
            Assert.IsTrue(grid2.CheckCanPlace(1, 0));
            Assert.IsFalse(grid2.CheckCanPlace(0, 1));
            Assert.IsFalse(grid2.CheckCanPlace(1, 1));
        }

        [TestMethod()]
        public void TestPlace()
        {
            var grid = new Grid(2, 2, new bool[,] { { false, false }, { false, false } });
            grid.Place(1, 0, 'a');
            Assert.IsTrue(grid.CheckCanPlace(0, 0));
            Assert.IsFalse(grid.CheckCanPlace(1, 0));
            Assert.IsTrue(grid.CheckCanPlace(0, 1));
            Assert.IsTrue(grid.CheckCanPlace(1, 1));
        }
    }
}