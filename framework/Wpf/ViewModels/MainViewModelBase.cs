using Autodesk.Revit.UI;
using RevitSolutionTemplate.Framework.Wpf.Navigation;
using System.Windows.Input;

namespace RevitSolutionTemplate.Framework.Wpf.ViewModels;

public abstract class MainViewModelBase : ViewModelBase
{
    private readonly NavigationStoreBase _navigationStoreBase;

    public MainViewModelBase(NavigationStoreBase navigationStoreBase)
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
