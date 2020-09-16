using System;
using System.Linq;

namespace FindCombsApi.Commons.Extensions
{
    public static class CombsWithRep
    {
        public static void InitComb(int?[] comb, int degree)
        {
            for (int i = 0; i < degree; i++)
            {
                comb[i] = null;
            }
        }

        public static int[] ConvertComb(int?[] combIn, int degree)
        {
            int[] combOut = new int[degree];
            for (int i = 0; i < degree; i++)
            {
                combOut[i] = (int)combIn[i];
            }
            return combOut;
        }

        public static bool VerifyValues(int[] values, int key)
        {
            if(values.Length == 0) 
            {
                return false;
            }
            else if (values.Length == 1)
            {
                if (values[0] == 0 && values[0] != key)
                {
                    return false;
                }

                if (values[0] % 2 == 0 && key % 2 != 0)
                {
                    return false;
                }

                if (key > 0)
                {
                    if (key < values[0])
                    {
                        return false;
                    }

                    if (key % values[0] != 0)
                    {
                        return false;
                    }
                } 
                else if(key < 0)
                {
                    if (key > values[0])
                    {
                        return false;
                    }

                    if (key % values[0] != 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                bool allPositive = true;
                for (int i = 0; i < values.Length && allPositive; i++)
                {
                    if (values[i] < 0)
                    {
                        allPositive = false;
                    }
                }

                if (allPositive && key < 0)
                {
                    return false;
                }

                bool allNegative = true;
                for (int i = 0; i < values.Length && allNegative; i++)
                {
                    if (values[i] > 0)
                    {
                        allNegative = false;
                    }
                }

                if (allNegative && key > 0)
                {
                    return false;
                }

                bool allZeros = true;
                for (int i = 0; i < values.Length && allZeros; i++)
                {
                    if (values[i] != 0)
                    {
                        allZeros = false;
                    }
                }

                if (allZeros && key != 0)
                {
                    return false;
                }

                bool allEven = true;
                for (int i = 0; i < values.Length && allEven; i++)
                {
                    if (values[i] % 2 != 0)
                    {
                        allEven = false;
                    }
                }

                if (allEven && key % 2 != 0)
                {
                    return false;
                }
                return true;
            }
        }

        public static int FindSingle(int pos, int[] values, int?[] comb, int size, int degree, int start, int count, int key, int?[] sol, ref bool stop)
        {
            if (pos >= degree)
            {
                int? sum = comb.Sum();
                if (sum == key)
                {
                    stop = true;
                    comb.CopyTo(sol, 0);
                }

                return count++;
            }

            for (int i = start; i < size && !stop; i++)
            {
                comb[pos] = values[i];
                count = FindSingle(pos + 1, values, comb, size, degree, start, count, key, sol, ref stop);
                start++;
            }
            return count;
        }
    }
}
