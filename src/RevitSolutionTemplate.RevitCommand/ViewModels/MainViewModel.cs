using RevitSolutionTemplate.Framework.Wpf.Navigation;
using RevitSolutionTemplate.Framework.Wpf.ViewModels;
using RevitSolutionTemplate.RevitCommand;

namespace RevitSolutionTemplate.ViewModels.RevitCommand;

public class MainViewModel : MainViewModelBase<RevitCommandHandler>
{
    public MainViewModel(NavigationStoreBase<RevitCommandHandler> navigationStoreBase)
        : base(navigationStoreBase)
    {
    }
}

