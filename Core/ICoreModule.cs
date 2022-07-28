using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Core;

public interface ICoreModule
{
    public void Configure(IWebHostBuilder builder);
    public void Initialize(WebApplication application);
}

public static class WebApplicationBuilderExtensions
{
    public static IApplication AddApplication<T>(this IWebHostBuilder builder) where T : class, ICoreModule
    {
        return new Application(builder, typeof(T));
    }
}