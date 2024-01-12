using Autodesk.Revit.UI;
using RevitSolutionTemplate.Core.Common.Commands;
using RevitSolutionTemplate.Core.Common.ViewModels;

namespace RevitSolutionTemplate.Core.Common.Navigation;

public class NavigateCommand<TViewModel, TExternalCommand> : CommandBase
    where TViewModel : ViewModelBase
    where TExternalCommand : IExternalCommand
{
    private readonly NavigationServiceBase<TViewModel, TExternalCommand> _navigationService;

    public NavigateCommand(NavigationServiceBase<TViewModel, TExternalCommand> navigationService)
    {
        _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {
        _navigationService.Navigate();
    }
}
