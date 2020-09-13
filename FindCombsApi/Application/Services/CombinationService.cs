using System;
using System.Collections.Generic;
using System.Linq;
using FindCombsApi.Application.Interfaces;
using FindCombsApi.Commons.Extensions;

namespace FindCombsApi.Application.Services
{
    public class CombinationService : ICombinationService
    {
        public IList<int> FindFirstCombsWithReps(IList<int> values, int key)
        {
            IList<int> combMatcher = new List<int>();
            int[] valuesArray = values.ToArray();
            for (int degree = 2; degree <= valuesArray.Length; degree++)
            {
                int pos = 0;
                int start = 0;
                int count = 0;
                bool stop_1 = false;
                bool stop_2 = true;
                int[] comb = new int[degree];
                int[] sol = new int[degree];
                
                CombsWithRep.InitComb(comb, degree);
                CombsWithRep.InitComb(sol, degree);
                CombsWithRep.FindSingle(pos, valuesArray, comb, valuesArray.Length, degree, start, count, key, sol, ref stop_1, ref stop_2);

                if (stop_1 == true)
                {
                    combMatcher = new List<int>(sol);
                    break;
                }

                if (stop_2 == true)
                {
                    break;
                }
            }
            
            return combMatcher;
        }
    }
}
