using Autodesk.Revit.UI;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace RevitSolutionTemplate.Core.RibbonTab;

public class RibbonPanelBuilder
{
    private readonly RibbonPanel _ribbonPanel;

    public RibbonPanelBuilder(RibbonPanel ribbonPanel)
    {
        _ribbonPanel = ribbonPanel;
    }

    public RibbonPanelBuilder AddPushButton<TCommandType>(string buttonName)
    {
        Type? externalCommandType = typeof(TCommandType);
        PushButtonData? commandButton = new(externalCommandType.FullName,
                                            buttonName,
                                            Assembly.GetAssembly(externalCommandType).Location,
                                            externalCommandType.FullName);

        commandButton.Image = new BitmapImage(new Uri($"pack://application:,,,/RevitSolutionTemplate.Application;component/Resources/Icons/{externalCommandType.Name}16.png"));
        commandButton.LargeImage = new BitmapImage(new Uri($"pack://application:,,,/RevitSolutionTemplate.Application;component/Resources/Icons/{externalCommandType.Name}32.png"));
        _ribbonPanel.AddItem(commandButton);

        return this;
    }
}
