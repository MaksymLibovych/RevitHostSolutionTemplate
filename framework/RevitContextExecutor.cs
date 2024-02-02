using Autodesk.Revit.UI;
using Serilog;

namespace RevitSolutionTemplate.Framework;

public class RevitContextExecutor
{
    private readonly ILogger _logger;
    private readonly ExternalEventHandler _externalEventHandler;
    private readonly ExternalEvent _externalEvent;
    private TaskCompletionSource<object>? _taskCompletionSource;

    public RevitContextExecutor(ILogger logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _externalEventHandler = new ExternalEventHandler(logger);
        _externalEvent = ExternalEvent.Create(_externalEventHandler);
    }

    public TResult Execute<TResult>(Func<UIApplication, TResult> function)
    {
        Task<TResult> result = ExecuteAsync((app, _) => function(app), CancellationToken.None);
        return result.Result;
    }

    public async Task<TResult> ExecuteAsync<TResult>(
        Func<UIApplication, CancellationToken, TResult> function,
        CancellationToken cancellationToken)
    {
        _logger.Information("Executing asynchronous operation");
        _taskCompletionSource = new TaskCompletionSource<object>();
        _externalEventHandler.SetExecutionCommand((uiApp) =>
        {
            TResult? result = function(uiApp, cancellationToken)
                ?? throw new InvalidOperationException();
            return result;
        });

        _externalEvent.Raise();

        try
        {
            TResult result = (TResult)await _taskCompletionSource.Task;
            _logger.Information($"Result of type : {result.GetType().Name} was awaited ");
            return result;
        }
        catch (Exception exception)
        {
            _logger.Error(exception, "Error occurred during asynchronous execution");
            throw;
        }
    }
}
