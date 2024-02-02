using Autodesk.Revit.UI;
using Microsoft.Extensions.Configuration;
using RevitSolutionTemplate.Framework;
using RevitSolutionTemplate.Framework.Wpf.ViewModels;
using RevitSolutionTemplate.RevitCommand.Views;

namespace RevitSolutionTemplate.RevitCommand;

public class RevitCommandHandler : CommandHandlerBase
{
    private readonly MainViewModelBase<RevitCommandHandler> _mainViewModel;
    private readonly IConfiguration _configuration;

    public RevitCommandHandler(MainViewModelBase<RevitCommandHandler> mainViewModel, IConfiguration configuration)
    {
        _mainViewModel = mainViewModel;
        _configuration = configuration;
    }

    public override void Execute(object parameter)
    {
        var mainWindow = new MainWindow
        {
            DataContext = _mainViewModel
        };

        mainWindow.Show();
        TaskDialog.Show("Connection string", $"The Conection string is {_configuration.GetConnectionString("Default")}");
    }
}
