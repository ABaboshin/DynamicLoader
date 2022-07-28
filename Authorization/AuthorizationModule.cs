using Autofac;
using Castle.DynamicProxy;
using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Authorization;

[DependsOn(Dependencies = new []{typeof(AutofacIntegrationModule)})]
public class AuthorizationModule : ICoreModule
{
    public void Configure(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddSingleton<IInterceptor, AuthorizationInterceptor>();
        });
        
        Console.WriteLine("AuthorizationModule.Configure");
    }

    public void Initialize(WebApplication application)
    {
        Console.WriteLine("AuthorizationModule.Initialize");
    }
}

public class AuthorizationInterceptor : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        var attributes = invocation.MethodInvocationTarget
            .GetCustomAttributes(true).OfType<AuthorizeAttribute>()
            .ToList();

        foreach (var attribute in attributes)
        {
            Console.WriteLine($"Auth attribute {attribute.Policy} on {invocation.Method.Name}");
        }
        
        invocation.Proceed();
    }
}

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddScopedEx<TService, TImplementation>(this IServiceCollection services)
        where TService : class
        where TImplementation : class, TService
    {
        services.AddScoped<TImplementation>();
        services.AddScoped(typeof(TService), serviceProvider =>
        {
            var proxyGenerator = new ProxyGenerator();
            var interceptors = serviceProvider.GetServices<IInterceptor>().ToArray();
            var actual = serviceProvider.GetRequiredService<TImplementation>();
            return proxyGenerator.CreateInterfaceProxyWithTarget(typeof(TService), actual, interceptors);
        });

        return services;
    }
}