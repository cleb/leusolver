using System;
using System.Collections.Generic;
using System.Text;

namespace LeuSolver
{
    public class Optimizer : IOptimizer
    {
        private HashSet<int> _knownStates;
        public Optimizer()
        {
            _knownStates = new HashSet<int>();
        }
        public bool IsKnownState(IGrid grid)
        {
            return _knownStates.Contains(grid.GetHashCode());            
        }

        public void SetKnownState(IGrid grid)
        {
            _knownStates.Add(grid.GetHashCode());
        }
    }
}
