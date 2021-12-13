using CovidDashboard.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CovidDashboard.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class CovidController : ControllerBase
{
    private readonly CovidService covidService;

    public CovidController(CovidService covidService)
    {
        this.covidService = covidService;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult GetTimeline()
    {
        return Ok(covidService.GetTimeline());
    }

    [HttpGet("daily")]
    [AllowAnonymous]
    public IActionResult GetTimelineDaily()
    {
        return Ok(covidService.GetTimelineDaily());
    }

    [HttpGet("agegroup")]
    [AllowAnonymous]
    public IActionResult GetAgeGroup()
    {
        return Ok(covidService.GetAgeGroup());
    }

    [HttpGet("agegroup-gendered")]
    [AllowAnonymous]
    public IActionResult GetAgeGroupGendered()
    {
        return Ok(covidService.GetAgegroupGendered());
    }
}
