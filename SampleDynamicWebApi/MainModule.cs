using System.Text.Json.Serialization;
using Authorization;
using Child;
using Core;

namespace SampleDynamicWebApi;

[DependsOn(Dependencies = new []{typeof(ChildModule), typeof(AuthorizationModule)})]
public class MainModule : ICoreModule
{
    public void Configure(IWebHostBuilder builder)
    {
        Console.WriteLine("Call MainModule.Configure");
        builder.ConfigureServices(services =>
        {
            services.AddControllers();
            services.AddScopedEx<IChildService, ChildService>();
        });
    }

    public void Initialize(WebApplication app)
    {
        Console.WriteLine("Call MainModule.Initialize");
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.MapControllers();
    }
}