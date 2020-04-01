using System;
using System.Collections.Generic;
using System.Text;

namespace LeuSolver
{
    public interface IOptimizer
    {
        bool IsKnownState(IGrid grid);
        void SetKnownState(IGrid grid);
    }
}
