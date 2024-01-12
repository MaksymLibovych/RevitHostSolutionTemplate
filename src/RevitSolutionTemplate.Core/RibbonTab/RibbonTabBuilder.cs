using Autodesk.Revit.UI;

namespace RevitSolutionTemplate.Core.RibbonTab;

public class RibbonTabBuilder
{
    private readonly UIControlledApplication _uiControlledApplication;
    private readonly string _ribbonTabName;

    public RibbonTabBuilder(UIControlledApplication uiControlledApplication, string ribbonTabName)
    {
        _uiControlledApplication = uiControlledApplication;
        _ribbonTabName = ribbonTabName;
        _uiControlledApplication.CreateRibbonTab(_ribbonTabName);
    }

    public RibbonTabBuilder WithRibbonPanel(string ribbonPanelName, Action<RibbonPanelBuilder>? ribbonPanelConfiguration)
    {
        RibbonPanel ribbonPanel = _uiControlledApplication.CreateRibbonPanel(_ribbonTabName, ribbonPanelName);

        RibbonPanelBuilder ribbonPanelBuilder = new(ribbonPanel);
        ribbonPanelConfiguration?.Invoke(ribbonPanelBuilder);

        return this;
    }
}
