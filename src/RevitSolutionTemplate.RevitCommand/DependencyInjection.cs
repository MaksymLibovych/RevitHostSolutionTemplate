using Microsoft.Extensions.DependencyInjection;
using RevitSolutionTemplate.Framework.Wpf.Navigation;
using RevitSolutionTemplate.Framework.Wpf.ViewModels;
using RevitSolutionTemplate.RevitCommand.Navigation;
using RevitSolutionTemplate.RevitCommand.ViewModels;
using RevitSolutionTemplate.ViewModels.RevitCommand;

namespace RevitSolutionTemplate.RevitCommand;

public static class DependencyInjection
{
    public static IServiceCollection AddRevitCommand(this IServiceCollection services)
    {
        services.AddTransient<RevitCommandViewModel>();
        services.AddTransient<NavigationStoreBase<RevitCommandHandler>>(factory =>
        {
            return new NavigationStore { CurrentViewModel = factory.GetRequiredService<RevitCommandViewModel>() };
        });
        services.AddTransient<MainViewModelBase<RevitCommandHandler>>(
            factory => new MainViewModel(factory.GetRequiredService<NavigationStoreBase<RevitCommandHandler>>()));

        services.AddTransient<RevitCommandHandler>();

        return services;
    }
}
