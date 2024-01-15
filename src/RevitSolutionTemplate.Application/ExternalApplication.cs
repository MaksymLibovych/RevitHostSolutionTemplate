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

        builder.WithDelegateRibbonPanel("RevitSolutionTemplatePanel", ribbonPanelBuilder =>
        {
            ribbonPanelBuilder.AddDelegateRibbonButton<RevitCommandDelegateCommand>(
                "RevitSolutionTemplateButton",
                @"pack://application:,,,/RevitSolutionTemplate.Application;component/Resources/Icons/RevitCommandExternalCommand16.png",
                @"pack://application:,,,/RevitSolutionTemplate.Application;component/Resources/Icons/RevitCommandExternalCommand32.png");
        });

        builder.Services.RegisterModule<RevitCommandModule>();

        var app = builder.Build();

        app.MapDelegateRibbonButton<RevitCommandDelegateCommand>();

        app.MapDelegateRibbonButton("RibbonButton", () =>
        {
            
        });

        return Result.Succeeded;
    }

    public Result OnShutdown(UIControlledApplication uiControlledApplication)
    {
        return Result.Succeeded;
    }
}
