using System.Windows.Input;

namespace RevitSolutionTemplate.Framework.Wpf.Commands;

public class CallbackCommand : ICommand
{
    private readonly Action _callback;
    private readonly Func<bool>? _canExecute;

    public CallbackCommand(Action callback, Func<bool>? canExecute = null)
    {
        _callback = callback;
        _canExecute = canExecute ?? (() => true);
    }

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter) => _canExecute!();

    public void Execute(object parameter)
    {
        _callback?.Invoke();
    }
}
