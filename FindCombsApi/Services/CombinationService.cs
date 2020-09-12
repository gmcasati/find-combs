using System;
using System.Collections.Generic;
using System.Linq;
using FindCombsApi.Extensions;
using FindCombsApi.Repositories;

namespace FindCombsApi.Services
{
    public class CombinationService
    {
        private readonly RequestRepository _requestRepository;
        public CombinationService(RequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }
        public IEnumerable<int> FindFirst(IEnumerable<int> values, int key)
        {
            IEnumerable<int> winners = null;
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
                    winners = new List<int>(sol);
                    break;
                }

                if (stop_2 == true)
                {
                    break;
                }
            }
            _requestRepository.Create(values, key, winners);
            return winners;
        }
    }
}
