using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RevitSolutionTemplate.RevitCommand;

[Transaction(TransactionMode.Manual)]
[Regeneration(RegenerationOption.Manual)]
[Journaling(JournalingMode.NoCommandData)]
public class RevitCommandExternalCommand : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        return Result.Succeeded;
    }
}
