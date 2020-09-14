using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindCombsApi.Commons.DTO;

namespace FindCombsApi.Application.Interfaces
{
    public interface IRequestService
    {
        Task<IList<int>> Create(IList<int> values, int key, IList<int> sols);
        Task<ICollection<RequestDTO>> GetRequestsAsync(DateTime start, DateTime end);
    }
}
