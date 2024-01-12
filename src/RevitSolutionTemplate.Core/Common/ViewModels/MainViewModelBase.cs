using Autodesk.Revit.UI;
using RevitSolutionTemplate.Core.Common.Navigation;

namespace RevitSolutionTemplate.Core.Common.ViewModels;

public abstract class MainViewModelBase<TExternalCommand> : ViewModelBase, IMainViewModel<TExternalCommand>
    where TExternalCommand : IExternalCommand
{
    private readonly NavigationStoreBase<TExternalCommand> _navigationStoreBase;

    public MainViewModelBase(NavigationStoreBase<TExternalCommand> navigationStoreBase)
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
