using WeatherCore.Services;

namespace DynamicProxy.Performance.Services;

public class DecoratedWeatherService : IWeatherService
{
    private readonly IWeatherService _weatherService;

    public DecoratedWeatherService(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }
    public WeatherCore.WeatherForecast[] GetWeatherForecast()
    {
        return _weatherService.GetWeatherForecast();
    }
}