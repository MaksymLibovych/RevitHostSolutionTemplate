using System.Windows.Input;

namespace RevitSolutionTemplate.Framework.Wpf.ViewModels;

public interface IMainViewModel<TDelegateCommand>
    where TDelegateCommand : ICommand
{
}
