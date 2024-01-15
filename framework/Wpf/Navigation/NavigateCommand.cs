using RevitSolutionTemplate.Framework.Wpf.Commands;
using RevitSolutionTemplate.Framework.Wpf.ViewModels;
using System.Windows.Input;

namespace RevitSolutionTemplate.Framework.Wpf.Navigation;

public class NavigateCommand<TViewModel> : CommandBase
    where TViewModel : ViewModelBase
{
    private readonly NavigationServiceBase<TViewModel> _navigationService;

    public NavigateCommand(NavigationServiceBase<TViewModel> navigationService)
    {
        _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {
        _navigationService.Navigate();
    }
}
