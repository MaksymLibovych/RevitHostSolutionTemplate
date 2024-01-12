using Autodesk.Revit.UI;
using RevitSolutionTemplate.Core.Common.Navigation;
using RevitSolutionTemplate.Core.Common.ViewModels;

namespace RevitSolutionTemplate.RevitCommand.Navigation;

public class NavigationService<TViewModel, TExternalCommand> : NavigationServiceBase<TViewModel, TExternalCommand>
    where TViewModel : ViewModelBase
    where TExternalCommand : IExternalCommand
{
    public NavigationService(NavigationStoreBase<TExternalCommand> navigationStore, Func<TViewModel> createViewModel)
        : base(navigationStore, createViewModel)
    {
    }
}
