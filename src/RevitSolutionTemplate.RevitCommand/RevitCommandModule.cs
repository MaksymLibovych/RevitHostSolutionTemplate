using Autofac;
using RevitSolutionTemplate.RevitCommand.Navigation;
using RevitSolutionTemplate.RevitCommand.ViewModels;

namespace RevitSolutionTemplate.RevitCommand;

public sealed class RevitCommandModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register<NavigationStore>(c =>
        {
            return new NavigationStore
            {
                CurrentViewModel = new RevitCommandViewModel()
            };

        }).SingleInstance();

        builder.RegisterType<MainViewModel>()
            .SingleInstance();
    }
}
