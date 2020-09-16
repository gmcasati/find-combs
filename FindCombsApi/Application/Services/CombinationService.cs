using System;
using System.Collections.Generic;
using System.Linq;
using FindCombsApi.Application.Interfaces;
using FindCombsApi.Commons.Extensions;

namespace FindCombsApi.Application.Services
{
    public class CombinationService : ICombinationService
    {
        private const int MAX_COMB_DEGREE = 50;
        public IList<int> FindFirstCombsWithReps(IList<int> values, int key)
        {
            IList<int> combMatcher = new List<int>();
            int[] valuesArray = values.ToArray();
            if (CombsWithRep.VerifyValues(valuesArray, key))
            {
                for (int degree = 1; degree < MAX_COMB_DEGREE; degree++)
                {
                    int pos = 0;
                    int start = 0;
                    int count = 0;
                    bool stop = false;
                    int?[] comb = new int?[degree];
                    int?[] sol = new int?[degree];

                    CombsWithRep.InitComb(comb, degree);
                    CombsWithRep.InitComb(sol, degree);
                    CombsWithRep.FindSingle(pos, valuesArray, comb, valuesArray.Length, degree, start, count, key, sol, ref stop);

                    if (stop == true)
                    {
                        combMatcher = new List<int>(CombsWithRep.ConvertComb(sol, degree));
                        break;
                    }
                }
            }
            return combMatcher;
        }
    }
}
