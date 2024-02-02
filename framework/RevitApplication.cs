using Autodesk.Revit.UI;
using Autodesk.Windows;
using Microsoft.Extensions.Hosting;

namespace RevitSolutionTemplate.Framework;

public class RevitApplication : IDisposable
{
    private readonly IHost _host;
    private readonly RibbonTabCollection _ribbonTabCollection;
    private readonly RibbonTab _ribbonTab;

    public RevitApplication(IHost host, RibbonTabCollection ribbonTabCollection, RibbonTab ribbonTab)
    {
        _host = host;
        _ribbonTabCollection = ribbonTabCollection;
        _ribbonTab = ribbonTab;

        _host.Start();
    }

    public IServiceProvider Services => _host.Services;

    public void AddRibbonPanel(string title, Action<RibbonPanelBuilder> ribbonPanelConfiguration)
    {
        var ribbonPanel = new Autodesk.Windows.RibbonPanel
        {
            Source = new RibbonPanelSource
            {
                Title = title
            }
        };

        var ribbonPanelBuilder = new RibbonPanelBuilder(ribbonPanel, Services);
        ribbonPanelConfiguration?.Invoke(ribbonPanelBuilder);

        _ribbonTab.Panels.Add(ribbonPanel);
    }

    public static RevitApplicationBuilder CreateBuilder(
        UIControlledApplication uiControlledApplication, string tabName)
            => new(uiControlledApplication, tabName);

    public void Dispose()
    {
        _ribbonTabCollection.Remove(_ribbonTab);
        _host.Dispose();
    }
}
