using Autodesk.Revit.UI;
using System.Windows.Input;

namespace RevitSolutionTemplate.RevitCommand;

public class RevitCommandDelegateCommand : ICommand
{
    private readonly MainViewModel _mainViewModel;

    public RevitCommandDelegateCommand(MainViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }

    public event EventHandler CanExecuteChanged;

    public void Execute(object parameter)
    {
        TaskDialog.Show("Success", "Hello world");
    }

    public bool CanExecute(object parameter) => true;
}
