using BenchmarkDotNet.Attributes;
using Castle.DynamicProxy;
using WeatherCore.Services;

namespace DecoratedVsIntercepted;

public class Benchmarks
{
    private readonly IProxyGenerator _proxyGenerator = new ProxyGenerator();
    private readonly IWeatherService _decoratedService = new DecoratedWeatherService(new WeatherService());
    private readonly IWeatherService _interceptedService;

    public Benchmarks()
    {
        IInterceptor interceptor = new Interceptor();
        _interceptedService = _proxyGenerator.CreateInterfaceProxyWithTargetInterface<IWeatherService>(new WeatherService(),interceptor);
    }

    [Benchmark]
    public WeatherCore.WeatherForecast[] GetInterceptedWeatherForecasts()
    {
        return _interceptedService.GetWeatherForecast();
    }
    
    [Benchmark]
    public WeatherCore.WeatherForecast[] GetDecoratedWeatherForecasts()
    {
        return _decoratedService.GetWeatherForecast();
    }
}