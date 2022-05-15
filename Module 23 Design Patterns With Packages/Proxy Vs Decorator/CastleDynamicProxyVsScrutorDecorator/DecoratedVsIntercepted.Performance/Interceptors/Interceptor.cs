using Castle.DynamicProxy;

namespace DecoratedVsIntercepted;

public class Interceptor : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        invocation.Proceed();
    }
}