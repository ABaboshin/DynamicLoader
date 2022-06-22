using Core;
using Microsoft.AspNetCore.Builder;

namespace ChildModule;

public class ChildModule : ICoreModule
{
    public void Configure(WebApplicationBuilder builder)
    {
        Console.WriteLine("Call ChildModule.Configure");
    }

    public void Initialize(WebApplication application)
    {
        Console.WriteLine("Call ChildModule.Initialize");
    }
}