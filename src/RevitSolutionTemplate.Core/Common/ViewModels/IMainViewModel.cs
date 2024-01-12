using Autodesk.Revit.UI;

namespace RevitSolutionTemplate.Core.Common.ViewModels;

public interface IMainViewModel<TExternalCommand>
    where TExternalCommand : IExternalCommand
{
}
