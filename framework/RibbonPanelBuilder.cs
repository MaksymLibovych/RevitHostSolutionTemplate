using Autodesk.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace RevitSolutionTemplate.Framework;

public class RibbonPanelBuilder
{
    private readonly RibbonPanel _ribbonPanel;
    private readonly IServiceProvider _serviceProvider;

    public RibbonPanelBuilder(RibbonPanel ribbonPanel, IServiceProvider serviceProvider)
    {
        _ribbonPanel = ribbonPanel;
        _serviceProvider = serviceProvider;
    }

    public Autodesk.Windows.RibbonButton AddRibbonButton<TCommandHandler>(
        string buttonName, string imageFilePath, string largeImageFilePath)
        where TCommandHandler : ICommand
    {
        var ribbonButton = new Autodesk.Windows.RibbonButton
        {
            Name = buttonName,
            Text = buttonName,
            ShowText = true,
            Orientation = System.Windows.Controls.Orientation.Vertical,
            Image = new BitmapImage(new Uri($@"pack://application:,,,/RevitSolutionTemplate.Application;component/{imageFilePath}")),
            LargeImage = new BitmapImage(new Uri($@"pack://application:,,,/RevitSolutionTemplate.Application;component/{largeImageFilePath}")),
            CommandHandler = _serviceProvider.GetRequiredService<TCommandHandler>(),
            Size = RibbonItemSize.Large
        };

        _ribbonPanel.Source.Items.Add(ribbonButton);

        return ribbonButton;
    }
}
