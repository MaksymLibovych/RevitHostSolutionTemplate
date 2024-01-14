using RevitSolutionTemplate.Framework.Wpf.Commands;
using RevitSolutionTemplate.Framework.Wpf.ViewModels;
using System.Windows.Input;

namespace RevitSolutionTemplate.Framework.Wpf.Navigation;

public class NavigateCommand<TViewModel, TDelegateCommand> : CommandBase
    where TViewModel : ViewModelBase
    where TDelegateCommand : ICommand
{
    private readonly NavigationServiceBase<TViewModel, TDelegateCommand> _navigationService;

    public NavigateCommand(NavigationServiceBase<TViewModel, TDelegateCommand> navigationService)
    {
        _navigationService = navigationService;
    }

    public override void Execute(object parameter)
    {
        _navigationService.Navigate();
    }
}
