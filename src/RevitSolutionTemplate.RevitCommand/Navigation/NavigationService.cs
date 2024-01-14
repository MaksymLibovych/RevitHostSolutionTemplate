using RevitSolutionTemplate.Framework;
using RevitSolutionTemplate.Framework.Wpf.Navigation;
using RevitSolutionTemplate.Framework.Wpf.ViewModels;
using System.Windows.Input;

namespace RevitSolutionTemplate.RevitCommand.Navigation;

public class NavigationService<TViewModel, TDelegateCommand> : NavigationServiceBase<TViewModel, TDelegateCommand>
    where TViewModel : ViewModelBase
    where TDelegateCommand : ICommand
{
    public NavigationService(NavigationStoreBase<TDelegateCommand> navigationStore, Func<TViewModel> createViewModel)
        : base(navigationStore, createViewModel)
    {
    }
}
