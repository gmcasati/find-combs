using System;
using System.Linq;

namespace FindCombsApi.Commons.Extensions
{
    public static class CombsWithRep
    {
        public static void InitComb(int[] comb, int degree)
        {
            for (int i = 0; i < degree; i++)
            {
                comb[i] = -1;
            }
        }
        
        public static int FindSingle(int pos, int[] values, int[] comb, int size, int degree, int start, int count, int key, int[] sol, ref bool stop_1, ref bool stop_2)
        {
            if (pos >= degree)
            {
                int sum = comb.Sum();
                if (sum == key)
                {
                    stop_1 = true;
                    comb.CopyTo(sol, 0);
                }

                if (sum < key)
                {
                    stop_2 = false;
                }

                return count++;
            }

            for (int i = start; i < size && !stop_1; i++)
            {
                comb[pos] = values[i];
                count = FindSingle(pos + 1, values, comb, size, degree, start, count, key, sol, ref stop_1, ref stop_2);
                start++;
            }
            return count;
        }
    }
}
