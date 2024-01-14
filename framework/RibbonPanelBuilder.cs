using Autodesk.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace RevitSolutionTemplate.Framework;

public class RibbonPanelBuilder
{
    private readonly RibbonPanel _ribbonPanel;

    public RibbonPanelBuilder(RibbonPanel ribbonPanel)
    {
        _ribbonPanel = ribbonPanel;
    }

    public Autodesk.Windows.RibbonButton AddRibbonButton<TDelegateCommand>(string buttonName, string imagePath, string largeImagePath)
        where TDelegateCommand : ICommand
    {
        var ribbonButton = new Autodesk.Windows.RibbonButton
        {
            Id = nameof(TDelegateCommand),
            Name = buttonName,
            CommandParameter = typeof(TDelegateCommand),
            Image = new BitmapImage(new Uri(imagePath)),
            LargeImage = new BitmapImage(new Uri(largeImagePath))
        };

        _ribbonPanel.Source.Items.Add(ribbonButton);

        return ribbonButton;
    }
}
