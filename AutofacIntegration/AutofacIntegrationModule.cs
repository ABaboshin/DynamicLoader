using Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Autofac;

public class AutofacIntegrationModule : ICoreModule
{
    public void Configure(WebApplicationBuilder builder)
    {
        // builder.Services.addau
        throw new NotImplementedException();
    }

    public void Initialize(WebApplication application)
    {
        throw new NotImplementedException();
    }
}

// public static class AutofacExtensions
// {
//     public static IHostBuilder UseAutofac(this IHostBuilder builder)
//     {
//         builder.Use
//     }
// }

public class AutofacProviderFactory : IServiceProviderFactory<ContainerBuilder>
{
    
}