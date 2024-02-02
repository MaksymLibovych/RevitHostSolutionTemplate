using Autodesk.Revit.UI;
using Autodesk.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Reflection;

namespace RevitSolutionTemplate.Framework;

public class RevitApplicationBuilder
{
    private readonly IHostBuilder _hostBuilder = Host.CreateDefaultBuilder();
    private readonly IServiceCollection _services = new ServiceCollection();

    private readonly UIControlledApplication _uiControlledApplication;
    private readonly RibbonTabCollection _ribbonTabCollection;
    private readonly RibbonTab _ribbonTab;

    internal RevitApplicationBuilder(UIControlledApplication uiControlledApplication, string tabName)
    {
        _uiControlledApplication = uiControlledApplication;

        _ribbonTabCollection = ComponentManager.Ribbon.Tabs;
        _ribbonTab = new RibbonTab { Title = tabName };
    }

    public IServiceCollection Services => _services;

    public RevitApplication Build()
    {
        _ribbonTabCollection.Add(_ribbonTab);

        string loggingSavePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                              "RevitSolutionTemplate",
                                              "logs");

        if (!Directory.Exists(loggingSavePath))
        {
            Directory.CreateDirectory(loggingSavePath);
        }

        Serilog.Core.Logger logger = new LoggerConfiguration()
            .WriteTo.File(Path.Combine(loggingSavePath, "log.txt"), rollingInterval: RollingInterval.Day)
            .CreateLogger();

        _hostBuilder.UseSerilog(logger);

        _hostBuilder.ConfigureServices((context, services) =>
        {
            foreach (var service in _services)
            {
                services.Add(service);
            }

            _services.Clear();
        });

        _hostBuilder.ConfigureAppConfiguration((context, configurationBuilder) =>
        {
            configurationBuilder.SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            #if DEBUG
            configurationBuilder.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
            #else
            configurationBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            #endif
        });

        return new RevitApplication(_hostBuilder.Build(), _ribbonTabCollection, _ribbonTab);
    }
}
