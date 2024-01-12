using Autodesk.Revit.UI;
using RevitSolutionTemplate.Core.Common.ViewModels;

namespace RevitSolutionTemplate.Core.Common.Navigation;

public abstract class NavigationServiceBase<TViewModel, TExternalCommand> : INavigationService<TViewModel>
    where TViewModel : ViewModelBase
    where TExternalCommand : IExternalCommand
{
    private readonly NavigationStoreBase<TExternalCommand> _navigationStore;
    private readonly Func<TViewModel> _createViewModel;

    public NavigationServiceBase(NavigationStoreBase<TExternalCommand> navigationStore, Func<TViewModel> createViewModel)
    {
        _navigationStore = navigationStore;
        _createViewModel = createViewModel;
    }

    public virtual void Navigate()
    {
        _navigationStore.CurrentViewModel = _createViewModel();
    }
}
