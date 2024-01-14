using Autodesk.Revit.UI;
using Serilog;

namespace RevitSolutionTemplate.Framework;

internal class ExternalEventHandler : IExternalEventHandler
{
    private readonly ILogger _logger;
    private Func<UIApplication, object> _function;

    public ExternalEventHandler(ILogger logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void SetExecutionCommand(Func<UIApplication, object> function)
    {
        _function = function;
    }

    public void Execute(UIApplication app)
    {
        try
        {
            _logger.Information("Start executing external command.");
            _function.Invoke(app);
        }
        catch (Exception exception)
        {
            _logger.Error(exception.Message);
        }
    }

    public string GetName() => ToString();
}
