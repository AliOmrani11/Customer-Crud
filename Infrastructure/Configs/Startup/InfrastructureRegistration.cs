using Application.Repositries;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configs.Startup;

public static class InfrastructureRegistration
{

    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseSqlServer("Server=.;Database=CustomerDb;User Id=sa;Password=@liSqlServer;Encrypt=false;");
        });

        services.AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IPhoneNumberValidator, PhoneNumberValidator>();

        return services;
    }

}
