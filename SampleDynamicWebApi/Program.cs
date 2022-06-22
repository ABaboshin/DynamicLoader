using Core;
using SampleDynamicWebApi;

var builder = WebApplication.CreateBuilder(args);

var app = builder.AddApplication<MainModule>();

app.Start();
