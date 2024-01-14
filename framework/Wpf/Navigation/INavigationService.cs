using RevitSolutionTemplate.Framework.Wpf.ViewModels;

namespace RevitSolutionTemplate.Framework.Wpf.Navigation;

public interface INavigationService<TViewModel>
    where TViewModel : ViewModelBase
{
    void Navigate();
}
