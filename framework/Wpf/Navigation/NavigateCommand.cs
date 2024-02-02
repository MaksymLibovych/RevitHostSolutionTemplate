using RevitSolutionTemplate.Framework.Wpf.Commands;
using RevitSolutionTemplate.Framework.Wpf.ViewModels;

namespace RevitSolutionTemplate.Framework.Wpf.Navigation;

public class NavigateCommand<TCommandHandler, TViewModel> : CommandBase
    where TCommandHandler : CommandHandlerBase
    where TViewModel : ViewModelBase
{
    private readonly NavigationServiceBase<TCommandHandler, TViewModel> _navigationService;

    public NavigateCommand(NavigationServiceBase<TCommandHandler, TViewModel> navigationService)
    {
        _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {
        _navigationService.Navigate();
    }
}
