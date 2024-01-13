using Autodesk.Revit.UI;
using RevitSolutionTemplate.RevitCommand;
using Microsoft.Extensions.Hosting;
using RevitSolutionTemplate.Core.RibbonTab;
using Microsoft.Extensions.Configuration;

namespace RevitSolutionTemplate.Application;

public class ExternalApplication : IExternalApplication
{
    private IHost _host;

    public Result OnStartup(UIControlledApplication uiControlledApplication)
    {
        string connectionString = "asdf";
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                connectionString = hostContext.Configuration.GetConnectionString("Default");
            })
            .Build();

        RibbonTabBuilder ribbonTabBuilder = new RibbonTabBuilder(uiControlledApplication, "RevitSolutionTemplateTab")
            .WithRibbonPanel("RevitSolutionTemplatePanel", ribbonPanelBuilder =>
            {
                ribbonPanelBuilder.AddPushButton<RevitCommandExternalCommand>("TestButton");
            });

        _host.Start();

        return Result.Succeeded;
    }

    public Result OnShutdown(UIControlledApplication uiControlledApplication)
    {
        _host.Dispose();

        return Result.Succeeded;
    }
}
