using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace WeatherCore.Services;

public abstract class WeatherServiceBase
{
    protected static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

}

public class WeatherNativeService : WeatherServiceBase, IWeatherService
{
    private readonly ILogger<WeatherNativeService> _logger;

    public WeatherNativeService(ILogger<WeatherNativeService> logger)
    {
        _logger = logger;
    }

    public WeatherForecast[] GetWeatherForecast()
    {
        var stopWatch = Stopwatch.StartNew();
        try
        {
            Thread.Sleep(2000);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
        }
        finally
        {
            _logger.LogInformation($"{nameof(GetWeatherForecast)} take {stopWatch.ElapsedMilliseconds} ms");
        }
    }
}

public class WeatherService : WeatherServiceBase, IWeatherService
{
    public WeatherForecast[] GetWeatherForecast()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        
    }
}

