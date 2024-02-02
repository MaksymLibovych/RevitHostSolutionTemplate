using RevitSolutionTemplate.Framework.Wpf.ViewModels;

namespace RevitSolutionTemplate.Framework.Wpf.Navigation;

public abstract class NavigationStoreBase<TCommandHandler>
    where TCommandHandler : CommandHandlerBase
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
