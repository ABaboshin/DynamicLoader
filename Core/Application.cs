using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Core;

public class Application : IApplication
{
    public IWebHostBuilder Builder { get; private set; }
    public Type Module { get; private set; }

    private List<ICoreModule> _modules = new List<ICoreModule>();
    private WebApplication _application;

    public Application(IWebHostBuilder builder, Type module)
    {
        Builder = builder;
        Module = module;

        CollectDependencies();
        ConfigureDependencies();
    }

    private void ConfigureDependencies()
    {
        //TODO pre, post configure
        foreach (var module in _modules)
        {
            module.Configure(Builder);
        }
        
        _application = Builder.Build();

        foreach (var module in _modules)
        {
            module.Initialize(_application);
        }
    }

    private void CollectDependencies()
    {
        CollectDependencies(Module);
    }

    private void CollectDependencies(Type moduleType)
    {
        var moduleObj = Activator.CreateInstance(moduleType) as ICoreModule;
        _modules.Add(moduleObj);

        foreach (var dependency in moduleType.GetCustomAttributes(true).OfType<DependsOnAttribute>().SelectMany(d => d.Dependencies))
        {
            //TODO graph sort
            CollectDependencies(dependency);
        }
    }

    public void Start()
    {
        _application.Run();
    }
}