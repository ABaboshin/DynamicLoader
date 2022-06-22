using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;

namespace Child;

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

public interface IChildService
{
    public void CallMe();
}

public class ChildService : IChildService
{
    [Authorize("sample")]
    public void CallMe()
    {
        Console.WriteLine("ChildService.CallMe");
    }
}