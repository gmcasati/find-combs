using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindCombsApi.Application.Interfaces;
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
    }
}
