using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeuSolver;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeuSolver.Tests
{
    [TestClass()]
    public class OptimizerTests
    {
        [TestMethod()]
        public void IsKnownStateTest()
        {
            var grid = new Grid(2, 2, new bool[,] { { false, false }, { true, true } });
            var optimizer = new Optimizer();
            Assert.IsFalse(optimizer.IsKnownState(grid));
            optimizer.SetKnownState(grid);
            Assert.IsTrue(optimizer.IsKnownState(grid));
            grid.Place(0, 0, 'A');
            Assert.IsFalse(optimizer.IsKnownState(grid));

        }
    }
}