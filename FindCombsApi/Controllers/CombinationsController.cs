using System;
using FindCombsApi.Requests;
using FindCombsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FindCombsApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CombinationsController : ControllerBase
    {
        private readonly CombinationService _combinationService;
        public CombinationsController(CombinationService combinationService)
        {
            _combinationService = combinationService;
        }
        [HttpPost]
        [Route("[action]")]
        public ActionResult FindFirst([FromBody] FindFirstRequest request)
        {
            var response = _combinationService.FindFirst(request.Values, request.Key);
            if (response == null)
            {
                return NotFound($"No possible combination in the sequence [{string.Join(", ", request.Values)}] that match key {request.Key}");
            }
            return Ok(response);
        }
    }
}
