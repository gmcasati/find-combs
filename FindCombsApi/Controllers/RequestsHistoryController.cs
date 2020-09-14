using System;
using System.Threading.Tasks;
using FindCombsApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FindCombsApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RequestsHistoryController : ControllerBase
    {
        private readonly IRequestService _requestService;
        public RequestsHistoryController(IRequestService requestService)
        {
            _requestService = requestService;
        }
        [HttpGet]
        public async Task<ActionResult> GetRequestsAsync([FromQuery] DateTime start, [FromQuery] DateTime end) 
        {
            var result = await _requestService.GetRequestsAsync(start, end);
            return Ok(result);
        }
    }
}
