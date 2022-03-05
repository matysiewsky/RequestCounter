using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestCounter.Services;

namespace RequestCounter.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IRequestCountStatsService _service;

        public StatisticsController(IRequestCountStatsService requestCountStatsService)
        {
            _service = requestCountStatsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Stats stats = _service.GetStatistics();
            return Ok(stats);
        }
    }
}
