using Autodesk.Revit.UI;
using Autodesk.Windows;
using Autofac;
using RevitSolutionTemplate.Framework.Logging.Sinks;
using Serilog;

namespace RevitSolutionTemplate.Framework;

public class RevitApplicationBuilder
{
    private readonly UIControlledApplication _uiControlledApplication;
    private readonly RevitContextExecutor _revitContextExecutor;
    private readonly ContainerBuilder _containerBuilder;
    private IContainer _container;
    private RibbonTabCollection _ribbonTabCollection;
    private readonly RibbonTab _ribbonTab;

    public RevitApplicationBuilder(UIControlledApplication uiControlledApplication, string tabName)
    {
        _uiControlledApplication = uiControlledApplication;
        _containerBuilder = new ContainerBuilder();
        _ribbonTabCollection = ComponentManager.Ribbon.Tabs;
        _ribbonTab = new RibbonTab() { Title = tabName };
    }

    public RibbonTab RibbonTab => _ribbonTab;
    public ContainerBuilder Services => _containerBuilder;

    internal IContainer Container => _container;

    public RevitApplicationBuilder WithDelegateRibbonPanel(string panelName, Action<RibbonPanelBuilder> ribbonPanelConfiguration)
    {
        var ribbonPanel = new Autodesk.Windows.RibbonPanel
        {
            Id = panelName,
            Source = new RibbonPanelSource
            {
                Title = panelName
            }
        };

        RibbonPanelBuilder ribbonPanelBuilder = new(ribbonPanel);
        ribbonPanelConfiguration?.Invoke(ribbonPanelBuilder);

        _ribbonTab.Panels.Add(ribbonPanel);

        return this;
    }

    public RevitApplication Build()
    {
        _ribbonTabCollection.Add(_ribbonTab);

        _containerBuilder.Register<ILogger>(componentContext =>
        {
            // Todo
            string path = @"C:\Users\libovych\Desktop\AutofacTest\AutofacApplication\log.txt";

            return new LoggerConfiguration()
            .WriteTo.Sink(new RevitFileSink(path))
            .CreateLogger();
        }).SingleInstance();

        _containerBuilder.RegisterType<RevitContextExecutor>();

        using IContainer container = Services.Build();

        _container = container;

        return new RevitApplication(_revitContextExecutor);
    }
}
