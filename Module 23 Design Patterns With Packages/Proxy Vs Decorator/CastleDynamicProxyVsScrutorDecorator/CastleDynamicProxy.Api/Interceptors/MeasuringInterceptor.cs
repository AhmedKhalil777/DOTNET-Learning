using System.Diagnostics;
using Castle.DynamicProxy;

namespace CastleDynamicProxy.Api.Interceptors;

public class MeasuringInterceptor : IInterceptor
{
    private readonly ILogger<MeasuringInterceptor> _logger;

    public MeasuringInterceptor(ILogger<MeasuringInterceptor> logger)
    {
        _logger = logger;
    }
    public void Intercept(IInvocation invocation)
    {
        //before calling
        var sw = Stopwatch.StartNew();
        try
        {
            invocation.Proceed();
        }
        finally
        {
            _logger.LogInformation($"{invocation.Method.Name} take {sw.ElapsedMilliseconds} ms");
        }
    }
}