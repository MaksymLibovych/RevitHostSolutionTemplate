using System.Windows.Input;

namespace RevitSolutionTemplate.Framework;

public abstract class CommandHandlerBase : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public virtual bool CanExecute(object parameter) => true;

    public abstract void Execute(object parameter);

    protected void OnCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
