using CovidDashboard.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CovidDashboard.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class CovidController
{
    private readonly CovidService covidService;

    public CovidController(CovidService covidService)
    {
        this.covidService = covidService;
    }

    [HttpGet]
    public IActionResult GetTimeline()
    {
        return new OkObjectResult(covidService.GetTimeline());
    }
}
