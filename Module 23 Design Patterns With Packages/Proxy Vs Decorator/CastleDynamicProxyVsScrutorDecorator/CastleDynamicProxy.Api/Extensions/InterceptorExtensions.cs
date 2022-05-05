using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CastleDynamicProxy.Api.Extensions;

public static class InterceptorExtensions
{
    public static IServiceCollection AddInterceptedSingleton<TService, TImplementation, TInterceptor>(
        this IServiceCollection services)
        where TService: class
        where TImplementation : class,TService
        where TInterceptor: class, IInterceptor
    {
        services.TryAddSingleton<IProxyGenerator, ProxyGenerator>();
        services.AddSingleton<TImplementation>();
        services.TryAddTransient<TInterceptor>();
        services.AddSingleton(provider =>
        {
            var proxyGenerator = provider.GetRequiredService<IProxyGenerator>();
            var imp = provider.GetRequiredService<TImplementation>();
            var interceptor = provider.GetRequiredService<TInterceptor>();
            return proxyGenerator.CreateInterfaceProxyWithTargetInterface<TService>(imp, interceptor);
        });
        return services;
    }
}