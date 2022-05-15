// See https://aka.ms/new-console-template for more information

using Castle.DynamicProxy;

var proxyGenerator = new ProxyGenerator();
var proxy = proxyGenerator.CreateInterfaceProxyWithoutTarget<IUserRepository>(new FakeInterceptor());
var res = proxy.CreateUser(new User("Mohammad"));
Console.WriteLine($"Is User Created : {res}");
public interface IUserRepository
{
    bool CreateUser(User user);
}

public record User(string FullName);

public class FakeInterceptor : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        invocation.ReturnValue = true;
    }
}