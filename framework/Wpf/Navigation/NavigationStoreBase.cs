using RevitSolutionTemplate.Framework.Wpf.ViewModels;
using System.Windows.Input;

namespace RevitSolutionTemplate.Framework.Wpf.Navigation;

public abstract class NavigationStoreBase
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
