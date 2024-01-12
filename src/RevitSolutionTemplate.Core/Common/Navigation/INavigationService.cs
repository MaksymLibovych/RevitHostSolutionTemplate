using RevitSolutionTemplate.Core.Common.ViewModels;

namespace RevitSolutionTemplate.Core.Common.Navigation;

public interface INavigationService<TViewModel>
    where TViewModel : ViewModelBase
{
    void Navigate();
}
