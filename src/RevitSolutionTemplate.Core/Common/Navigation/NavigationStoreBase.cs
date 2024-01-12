using Autodesk.Revit.UI;
using RevitSolutionTemplate.Core.Common.ViewModels;

namespace RevitSolutionTemplate.Core.Common.Navigation;

public abstract class NavigationStoreBase<TExternalCommand> : INavigationStore<TExternalCommand>
    where TExternalCommand : IExternalCommand
{
    private ViewModelBase? _currentViewModel;

    public event Action? CurrentViewModelChanged;

    public virtual ViewModelBase? CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel?.Dispose();
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    private void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }
}
