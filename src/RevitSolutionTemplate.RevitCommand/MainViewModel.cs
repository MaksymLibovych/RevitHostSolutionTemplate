using RevitSolutionTemplate.Framework.Wpf.Navigation;
using RevitSolutionTemplate.Framework.Wpf.ViewModels;

namespace RevitSolutionTemplate.RevitCommand;

public class MainViewModel : MainViewModelBase<RevitCommandDelegateCommand>
{
    public MainViewModel(NavigationStoreBase<RevitCommandDelegateCommand> navigationStoreBase)
        : base(navigationStoreBase)
    {
    }
}

