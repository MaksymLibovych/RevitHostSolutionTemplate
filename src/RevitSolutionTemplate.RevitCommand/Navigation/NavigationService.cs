using RevitSolutionTemplate.Framework.Wpf.Navigation;
using RevitSolutionTemplate.Framework.Wpf.ViewModels;

namespace RevitSolutionTemplate.RevitCommand.Navigation;

public class NavigationService<TViewModel> : NavigationServiceBase<RevitCommandHandler, TViewModel>
    where TViewModel : ViewModelBase
{
    public NavigationService(NavigationStoreBase<RevitCommandHandler> navigationStore, Func<TViewModel> createViewModel)
        : base(navigationStore, createViewModel)
    {
    }
}
