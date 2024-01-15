using Autodesk.Revit.DB;
using Serilog;
using System.Reflection;
using System.Windows.Input;

namespace RevitSolutionTemplate.Framework;

public class CommandHandler : ICommand
{
    private readonly Delegate _handler;
    private readonly RevitContextExecutor _revitContextExecutor;
    private readonly ILogger _logger;

    public CommandHandler(Delegate handler, RevitContextExecutor revitContextExecutor, ILogger logger)
    {
        _handler = handler;
        _revitContextExecutor = revitContextExecutor ?? throw new ArgumentNullException(nameof(revitContextExecutor));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public event EventHandler CanExecuteChanged;

    public async void Execute(object parameter)
    {
        var ribbonButton = (Autodesk.Windows.RibbonButton)parameter;

        _logger.Information($"Inside Execute");
        object result = await _revitContextExecutor.ExecuteAsync((uiApp, cancellationToken) =>
        {
            _logger.Information($"Inside Revit Context");
            var document = uiApp.ActiveUIDocument.Document;
            using var transaction = new Transaction(document, $"{ribbonButton.Name} creation.");
            transaction.Start();



            transaction.Commit();
            _logger.Information("Commited");

            return true;

        }, CancellationToken.None);
    }

    public bool CanExecute(object parameter) => true;
}
