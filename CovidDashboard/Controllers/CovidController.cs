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

    [HttpGet("agegroup-gendered")]
    public IActionResult GetAgeGroupGendered()
    {
        return Ok(covidService.GetAgegroupGendered());
    }

    [HttpGet("daily-deaths")]
    public IActionResult GetDailyDeaths()
    {
        return Ok(covidService.GetDailyDeaths());
    }

    [HttpGet("daily-county")]
    public IActionResult GetDailyCasesCounty()
    {
        return Ok(covidService.GetDailyCasesCounty());
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

    [HttpGet("deaths-gendered")]
    [AllowAnonymous]
    public IActionResult GetDeathsGendered()
    {
        return Ok(covidService.GetDeathsGendered());
    }
}
