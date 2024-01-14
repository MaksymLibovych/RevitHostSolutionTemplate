using Autofac;
using RevitSolutionTemplate.Framework.Wpf.ViewModels;

namespace RevitSolutionTemplate.RevitCommand;

public sealed class RevitCommandModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MainViewModel>()
            .SingleInstance();
    }
}
