using Autodesk.Revit.UI;

namespace RevitSolutionTemplate.Core.Common.Navigation;

public interface INavigationStore<TExternalCommand> 
    where TExternalCommand : IExternalCommand
{
}
