using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FindCombsApi.Models;

namespace FindCombsApi.Infrastructure.Interfaces
{
    public interface IRequestRepository
    {
        Task<Request> Create(IList<int> values, int key, IList<int> sols);
    }
}
