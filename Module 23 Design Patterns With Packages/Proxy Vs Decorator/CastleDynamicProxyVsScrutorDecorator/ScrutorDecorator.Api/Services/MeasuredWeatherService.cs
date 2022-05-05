using System.Diagnostics;
using WeatherCore;
using WeatherCore.Services;

namespace ScrutorDecorator.Api.Services;

public class MeasuredWeatherService : IWeatherService
{
    private readonly IWeatherService _weatherService;
    private readonly ILogger<MeasuredWeatherService> _logger;

    public MeasuredWeatherService(IWeatherService weatherService, ILogger<MeasuredWeatherService> logger)
    {
        _weatherService = weatherService;
        _logger = logger;
    }
    public WeatherForecast[] GetWeatherForecast()
    {
        var stopWatch = Stopwatch.StartNew();
        try
        {
            return _weatherService.GetWeatherForecast();
        }
        finally
        {
            _logger.LogInformation($"{nameof(GetWeatherForecast)} take {stopWatch.ElapsedMilliseconds} ms");
        }
    }
}