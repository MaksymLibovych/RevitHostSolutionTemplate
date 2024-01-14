using System.Windows.Input;

namespace RevitSolutionTemplate.Framework.Wpf.Navigation;

public interface INavigationStore<TDelegateCommand>
    where TDelegateCommand : ICommand
{
}
