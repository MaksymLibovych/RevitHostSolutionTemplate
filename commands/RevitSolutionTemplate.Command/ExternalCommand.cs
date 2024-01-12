using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitSolutionTemplate.RevitCommand.Navigation;
using RevitSolutionTemplate.RevitCommand.ViewModels;

namespace RevitSolutionTemplate.RevitCommand;

[Transaction(TransactionMode.Manual)]
[Regeneration(RegenerationOption.Manual)]
[Journaling(JournalingMode.NoCommandData)]
public class ExternalCommand : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        var navigationStore = new NavigationStore
        {
            CurrentViewModel = new RevitCommandViewModel()
        };

        var mainWindow = new MainWindow
        {
            DataContext = new MainViewModel(navigationStore)
        };

        mainWindow.Show();

        return Result.Succeeded;
    }
}
