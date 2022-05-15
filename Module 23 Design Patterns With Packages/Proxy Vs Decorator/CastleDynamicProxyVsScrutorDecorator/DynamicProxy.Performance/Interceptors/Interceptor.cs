using Castle.DynamicProxy;

namespace DynamicProxy.Performance.Interceptors;

public class Interceptor : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        invocation.Proceed();
    }
}