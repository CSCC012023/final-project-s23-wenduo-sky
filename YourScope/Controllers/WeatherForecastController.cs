using Microsoft.AspNetCore.Mvc;

namespace YourScope.Controllers;

[ApiController]
[Route("[controller]")]
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

    [HttpGet(Name = "GetWeatherForecast")]
    public int Get()
    {
        using (var context = new YourScopeContext())
        {
            var even = new Event { EventId = 1, Name = "Corgi", Description = "At 62 Heron Park Place" };
            context.Event.Add(even);
            context.SaveChanges();
        }
        return 0;
    }
}

