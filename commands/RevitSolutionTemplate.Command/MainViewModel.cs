using RevitSolutionTemplate.Core.Common.Navigation;
using RevitSolutionTemplate.Core.Common.ViewModels;

namespace RevitSolutionTemplate.RevitCommand;

public class MainViewModel : MainViewModelBase<ExternalCommand>
{
    public MainViewModel(NavigationStoreBase<ExternalCommand> navigationStoreBase)
        : base(navigationStoreBase)
    {
    }
}

