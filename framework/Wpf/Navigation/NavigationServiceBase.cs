using Autodesk.Revit.UI;
using RevitSolutionTemplate.Framework.Wpf.ViewModels;
using System.Windows.Input;

namespace RevitSolutionTemplate.Framework.Wpf.Navigation;

public abstract class NavigationServiceBase<TViewModel> : INavigationService<TViewModel>
    where TViewModel : ViewModelBase
{
    private readonly NavigationStoreBase _navigationStore;
    private readonly Func<TViewModel> _createViewModel;

    public NavigationServiceBase(NavigationStoreBase navigationStore, Func<TViewModel> createViewModel)
    {
        _navigationStore = navigationStore;
        _createViewModel = createViewModel;
    }

    public virtual void Navigate()
    {
        _navigationStore.CurrentViewModel = _createViewModel();
    }
}
