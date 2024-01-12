namespace RevitSolutionTemplate.Core.Common.Commands;

public class AsyncCallbackCommand : AsyncCommandBase
{
    private readonly Func<Task> _callBack;

    public AsyncCallbackCommand(Func<Task> callBack, Action<Exception> onException)
        : base(onException)
    {
        _callBack = callBack;
    }

    protected override async Task ExecuteAsync(object parameter)
    {
        await _callBack();
    }
}
