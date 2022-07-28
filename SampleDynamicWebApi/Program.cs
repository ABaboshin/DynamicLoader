using Autofac;
using Core;
using SampleDynamicWebApi;

var host = Host.CreateDefaultBuilder(args)
    .UseServiceProviderFactory(new AutofacProviderFactory())
    .ConfigureWebHost(builder =>
    {
        
    })

var builder = WebApplication.CreateBuilder(args);

var app = builder.AddApplication<MainModule>();

app.Start();
