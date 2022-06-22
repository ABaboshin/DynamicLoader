using Microsoft.AspNetCore.Builder;

namespace Core;

public interface ICoreModule
{
    public void Configure(WebApplicationBuilder builder);
    public void Initialize(WebApplication application);
}

public static class WebApplicationBuilderExtensions
{
    public static IApplication AddApplication<T>(this WebApplicationBuilder builder) where T : class, ICoreModule
    {
        return new Application(builder, typeof(T));
    }
}