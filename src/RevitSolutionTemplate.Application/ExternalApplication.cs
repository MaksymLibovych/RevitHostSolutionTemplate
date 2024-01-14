using Autodesk.Revit.UI;
using Autofac;
using RevitSolutionTemplate.Framework;
using RevitSolutionTemplate.RevitCommand;

namespace RevitSolutionTemplate.Application;

public class ExternalApplication : IExternalApplication
{
    public Result OnStartup(UIControlledApplication uiControlledApplication)
    {
        var builder = RevitApplication.CreateBuilder(uiControlledApplication, "RevitSolutionTemplateTab");

        builder.WithRibbonPanel("RevitSolutionTemplatePanel", ribbonPanelBuilder =>
        {
            ribbonPanelBuilder.AddRibbonButton<RevitCommandDelegateCommand>(
                "RevitSolutionTemplateButton",
                @"pack://application:,,,/RevitSolutionTemplate.Application;component/Resources/Icons/RevitCommandExternalCommand16.png",
                @"pack://application:,,,/RevitSolutionTemplate.Application;component/Resources/Icons/RevitCommandExternalCommand32.png");
        });

        builder.Services.RegisterModule<RevitCommandModule>();

        var app = builder.Build();

        app.MapRibbonButton<RevitCommandDelegateCommand>();

        return Result.Succeeded;
    }

    public Result OnShutdown(UIControlledApplication uiControlledApplication)
    {
        return Result.Succeeded;
    }
}
