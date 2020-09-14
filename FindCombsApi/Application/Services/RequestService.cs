using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindCombsApi.Application.Interfaces;
using FindCombsApi.Commons.DTO;
using FindCombsApi.Commons.Extensions;
using FindCombsApi.Infrastructure.Interfaces;

namespace FindCombsApi.Application.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        public RequestService(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }
        public async Task<IList<int>> Create(IList<int> values, int key, IList<int> sols)
        {
            var result = await _requestRepository.Create(values, key, sols);
            return result.Combination;
        }

        public async Task<ICollection<RequestDTO>> GetRequestsAsync(DateTime start, DateTime end)
        {
            DateTimeHelper.SetRange(start, end, out DateTime startOut, out DateTime endOut);
            var requests = await _requestRepository.GetRequestsAsync(startOut, endOut);
            return requests
                .Select(request => 
                    new RequestDTO 
                    { 
                        Values = request.Values,
                        Key = request.Key,
                        Combination = request.Combination,
                        RequestTime = request.Date
                    }).ToList();
        }
    }
}
