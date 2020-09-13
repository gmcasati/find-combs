using System;
using System.Linq;
using System.Threading.Tasks;
using FindCombsApi.Application.Interfaces;
using FindCombsApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FindCombsApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CombinationsController : ControllerBase
    {
        private readonly ICombinationService _combinationService;
        private readonly IRequestService _requestService;
        public CombinationsController(ICombinationService combinationService, IRequestService requestService)
        {
            _combinationService = combinationService;
            _requestService = requestService;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> FindFirst([FromBody] FindFirstRequest request)
        {
            var comb = _combinationService.FindFirstCombsWithReps(request.Values, request.Key);
            var response = await _requestService.Create(request.Values, request.Key, comb);
            if (response == null || response.Count() == 0)
            {
                return NotFound($"No possible combination in the sequence [{string.Join(", ", request.Values)}] that match key {request.Key}");
            }
            return Ok(response);
        }
    }
}
