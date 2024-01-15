using Autodesk.Revit.UI;
using Autodesk.Windows;
using Autofac;
using Serilog;
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

    public void MapDelegateRibbonButton<TDelegateCommand>()
        where TDelegateCommand : class, ICommand
    {
        Autodesk.Windows.RibbonItem ribbonItem = _builder.RibbonTab.FindItem(nameof(TDelegateCommand));

        if (ribbonItem.GetType() != typeof(Autodesk.Windows.RibbonButton))
        {
            throw new ArgumentException($"\"{nameof(TDelegateCommand)}\" is not of type {nameof(Autodesk.Windows.RibbonButton)}");
        }

        var ribbonButton = (Autodesk.Windows.RibbonButton)ribbonItem;

        using ILifetimeScope scope = _builder.Container.BeginLifetimeScope(ribbonButton);

        var isResolved = scope.TryResolve<TDelegateCommand>(out TDelegateCommand? delegateCommand);
        // Todo
        ribbonButton.CommandHandler = isResolved ? delegateCommand : null;
    }

    public void MapDelegateRibbonButton(string ribbonButtonName, Delegate handler)
    {
        Autodesk.Windows.RibbonItem ribbonItem = _builder.RibbonTab.FindItem(ribbonButtonName);

        if (ribbonItem.GetType() != typeof(Autodesk.Windows.RibbonButton))
        {
            throw new ArgumentException($"\"{ribbonButtonName}\" is not of type {nameof(Autodesk.Windows.RibbonButton)}");
        }

        var ribbonButton = (Autodesk.Windows.RibbonButton)ribbonItem;

        using ILifetimeScope scope = _builder.Container.BeginLifetimeScope();
        var commandHandler = new CommandHandler(
            handler, scope.Resolve<RevitContextExecutor>(), scope.Resolve<ILogger>());

        ribbonButton.CommandHandler = commandHandler;
    }
}
