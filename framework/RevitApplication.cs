using Autodesk.Revit.UI;
using System.Reflection;
using System.Windows.Input;

namespace RevitSolutionTemplate.Framework;

public sealed class RevitApplication
{
    private static RevitApplicationBuilder _builder;
    private readonly RevitContextExecutor _revitContextExecutor;

    public RevitApplication(RevitContextExecutor revitContextExecutor)
    {
        _revitContextExecutor = revitContextExecutor;
    }

    public static RevitApplicationBuilder CreateBuilder(UIControlledApplication uiControlledApplication, string tabName)
    {
        _builder = new RevitApplicationBuilder(uiControlledApplication, tabName);
        return _builder;
    }

    public void MapRibbonButton<TDelegateCommand>()
        where TDelegateCommand : ICommand
    {
        Autodesk.Windows.RibbonItem ribbonItem = _builder.RibbonTab.FindItem(nameof(TDelegateCommand));

        if (ribbonItem.GetType() != typeof(Autodesk.Windows.RibbonButton))
        {
            throw new ArgumentException($"\"{nameof(TDelegateCommand)}\" is not of type {nameof(RibbonButton)}");
        }

        var ribbonButton = (Autodesk.Windows.RibbonButton)ribbonItem;


        var revitDelegateCommand = new DelegateCommand(_revitContextExecutor, _builder.Logger);

        ribbonButton.CommandHandler = revitDelegateCommand;
    }
}
