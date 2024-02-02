using RevitSolutionTemplate.Framework.Wpf.ViewModels;

namespace RevitSolutionTemplate.Framework.Wpf.Navigation;

public abstract class NavigationServiceBase<TCommandHandler, TViewModel> : INavigationService<TViewModel>
    where TCommandHandler : CommandHandlerBase
    where TViewModel : ViewModelBase
{
    private readonly NavigationStoreBase<TCommandHandler> _navigationStore;
    private readonly Func<TViewModel> _createViewModel;

    public NavigationServiceBase(NavigationStoreBase<TCommandHandler> navigationStore, Func<TViewModel> createViewModel)
    {
        _navigationStore = navigationStore;
        _createViewModel = createViewModel;
    }

    public virtual void Navigate()
    {
        _navigationStore.CurrentViewModel = _createViewModel();
    }
}
