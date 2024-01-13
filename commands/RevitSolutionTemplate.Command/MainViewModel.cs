using RevitSolutionTemplate.Core.Common.Navigation;
using RevitSolutionTemplate.Core.Common.ViewModels;

namespace RevitSolutionTemplate.RevitCommand;

public class MainViewModel : MainViewModelBase<RevitCommandExternalCommand>
{
    public MainViewModel(NavigationStoreBase<RevitCommandExternalCommand> navigationStoreBase)
        : base(navigationStoreBase)
    {
    }
}

