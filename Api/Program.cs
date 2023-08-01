using Api.Setting.Filters;
using Api.Setting.MiddleWares;
using Api.Setting.Startup;
using Application.Configs.Startup;
using Infrastructure.Configs.Startup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(config =>
{
    config.Filters.Add(new ResultFilter());
});
builder.Services.RegisterApplication();
builder.Services.RegisterInfrastructure();
builder.Services.RegisterSetting();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/Customer/swagger.json", "Customer");
    });
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
