using Autodesk.Revit.UI;
using System.Windows.Input;

namespace RevitSolutionTemplate.Core.Common.Commands;

//public abstract class CommandBase<TExternalCommand> : ICommand
//    where TExternalCommand : IExternalCommand
public abstract class CommandBase : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public virtual bool CanExecute(object parameter) => true;

    public abstract void Execute(object parameter);

    protected void OnCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
