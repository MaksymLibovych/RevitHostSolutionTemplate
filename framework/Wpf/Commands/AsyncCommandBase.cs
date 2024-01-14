using System.Windows.Input;

namespace RevitSolutionTemplate.Framework.Wpf.Commands;

public abstract class AsyncCommandBase : ICommand
{
    private readonly Action<Exception> _onException;
    private bool _isExecuting;

    public AsyncCommandBase(Action<Exception> onException)
    {
        _onException = onException;
    }

    public bool IsExecuting
    {
        get => _isExecuting;
        set
        {
            _isExecuting = value;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        return !IsExecuting;
    }

    public async void Execute(object parameter)
    {
        IsExecuting = true;
        try
        {
            await ExecuteAsync(parameter);
        }
        catch (Exception exception)
        {
            _onException?.Invoke(exception);
        }
        finally
        {
            IsExecuting = false;
        }
    }

    protected abstract Task ExecuteAsync(object parameter);

}
