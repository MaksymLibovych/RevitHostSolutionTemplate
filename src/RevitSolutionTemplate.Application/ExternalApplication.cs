using Autodesk.Revit.UI;

namespace RevitSolutionTemplate.Application;

public class ExternalApplication : IExternalApplication
{
    public Result OnStartup(UIControlledApplication application)
    {
        return Result.Succeeded;
    }

    public Result OnShutdown(UIControlledApplication application)
    {
        return Result.Succeeded;
    }
}
