using Application.Configs.Startup;
using Infrastructure.Configs.Startup;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;

namespace CrudTest.Test.Support;

public static class Dependencies
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();

        services.AddMediatR(s => s.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        services.RegisterApplication();
        services.RegisterInfrastructure();

        return services;
    }
}
