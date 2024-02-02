using Autodesk.Revit.UI;
using RevitSolutionTemplate.Framework;
using RevitSolutionTemplate.RevitCommand;
#if DEBUG
using ricaun.Revit.UI;
#endif

namespace RevitSolutionTemplate.Application;

#if DEBUG
[AppLoader]
#endif
public class ExternalApplication : IExternalApplication
{
    private RevitApplication? _revitApplication;

    public Result OnStartup(UIControlledApplication uiControlledApplication)
    {
        var builder = RevitApplication.CreateBuilder(uiControlledApplication, "TabName");

        builder.Services.AddRevitCommand();

        _revitApplication = builder.Build();

        _revitApplication.AddRibbonPanel("RibbonPanel", panelBuilder =>
        {
            panelBuilder.AddRibbonButton<RevitCommandHandler>(
                "ButtonName",
                "Resources/Icons/RevitCommandExternalCommand16.png",
                "Resources/Icons/RevitCommandExternalCommand32.png");
        });

        return Result.Succeeded;
    }

    public Result OnShutdown(UIControlledApplication uiControlledApplication)
    {
        _revitApplication?.Dispose();
        return Result.Succeeded;
    }
}
