using System;
using System.Collections.Generic;

namespace FindCombsApi.Application.Interfaces
{
    public interface ICombinationService
    {
        IList<int> FindFirstCombsWithReps(IList<int> values, int key);
    }
}
