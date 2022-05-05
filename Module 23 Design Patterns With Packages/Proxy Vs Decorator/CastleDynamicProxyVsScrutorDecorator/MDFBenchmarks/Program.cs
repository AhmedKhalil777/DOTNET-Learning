// See https://aka.ms/new-console-template for more information


using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;
using Castle.DynamicProxy;
using WeatherCore.Services;

var su = BenchmarkRunner.Run<DPBenchmarks>();

[MinColumn, MaxColumn, MeanColumn, MedianColumn, MemoryDiagnoser]
public class DPBenchmarks
{
    private readonly IProxyGenerator _proxyGenerator = new ProxyGenerator();
    private readonly IWeatherService _decoratedService = new DecoratedWeatherService(new WeatherService());
    private readonly IWeatherService _interceptedService;

    public DPBenchmarks()
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
public class Interceptor : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        invocation.Proceed();
    }
}