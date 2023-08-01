using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Api.Setting.MiddleWares;

namespace Api.Setting.Startup;

public static class SettingRegistration
{
    public static IServiceCollection RegisterSetting(this IServiceCollection services)
    {
        services.AddTransient<ExceptionHandlingMiddleware>();


        services.AddApiVersioning(opt =>
        {
            opt.DefaultApiVersion = new ApiVersion(1, 0);
            opt.ApiVersionReader = new HeaderApiVersionReader("api-version");
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.ReportApiVersions = true;
            opt.ApiVersionSelector = new CurrentImplementationApiVersionSelector(opt);
        });

        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("Customer", new OpenApiInfo
            {
                Title = "Customer",
                Version = "v1",

            });
            //-------------------------------------------------------------------------------------------------------------------------
            string fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
            option.IncludeXmlComments(filePath);
        });

        return services;
    }
}
