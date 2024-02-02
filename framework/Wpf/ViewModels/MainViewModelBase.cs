using RevitSolutionTemplate.Framework.Wpf.Navigation;

namespace RevitSolutionTemplate.Framework.Wpf.ViewModels;

public abstract class MainViewModelBase<TCommandHandler> : ViewModelBase
    where TCommandHandler : CommandHandlerBase
{
    private readonly NavigationStoreBase<TCommandHandler> _navigationStoreBase;

    public MainViewModelBase(NavigationStoreBase<TCommandHandler> navigationStoreBase)
    {
        _navigationStoreBase = navigationStoreBase;

        _navigationStoreBase.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }

    public ViewModelBase? CurrentViewModel => _navigationStoreBase.CurrentViewModel;

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}
