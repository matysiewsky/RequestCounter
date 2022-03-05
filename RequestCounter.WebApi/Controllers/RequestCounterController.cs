using Microsoft.AspNetCore.Mvc;
using RequestCounter.Services;

namespace RequestCounter.WebApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class RequestCounterController : ControllerBase
{
    private readonly IRequestCountStatsService _service;

    public RequestCounterController(IRequestCountStatsService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _service.IncreaseCounter("GET");

        return Ok();
    }

    [HttpPost]
    public IActionResult Post()
    {
        _service.IncreaseCounter("POST");

        return Ok();
    }

    [HttpPut]
    public IActionResult Put()
    {
        _service.IncreaseCounter("PUT");
        return Ok();
    }

    [HttpPatch]
    public IActionResult Patch()
    {
        _service.IncreaseCounter("PATCH");
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        _service.IncreaseCounter("DELETE");
        return Ok();
    }
}