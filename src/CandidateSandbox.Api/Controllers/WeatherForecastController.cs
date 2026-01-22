using Microsoft.AspNetCore.Mvc;

namespace CandidateSandbox.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Get weather forecast for the next 5 days
    /// </summary>
    /// <returns>A list of weather forecasts</returns>
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation("Getting weather forecast");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    /// <summary>
    /// Get weather forecast for a specific day
    /// </summary>
    /// <param name="days">Number of days from now</param>
    /// <returns>Weather forecast for the specified day</returns>
    [HttpGet("{days}", Name = "GetWeatherForecastByDay")]
    public ActionResult<WeatherForecast> GetByDay(int days)
    {
        if (days < 1 || days > 30)
        {
            _logger.LogWarning("Invalid day parameter: {Days}", days);
            return BadRequest("Days must be between 1 and 30");
        }

        _logger.LogInformation("Getting weather forecast for day {Days}", days);
        var forecast = new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(days)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };

        return Ok(forecast);
    }

    /// <summary>
    /// Create a new weather forecast
    /// </summary>
    /// <param name="forecast">The weather forecast to create</param>
    /// <returns>The created weather forecast</returns>
    [HttpPost(Name = "CreateWeatherForecast")]
    public ActionResult<WeatherForecast> Create([FromBody] WeatherForecast forecast)
    {
        if (forecast == null)
        {
            return BadRequest("Weather forecast cannot be null");
        }

        _logger.LogInformation("Creating weather forecast for {Date}", forecast.Date);
        return CreatedAtRoute("GetWeatherForecast", forecast);
    }
}
