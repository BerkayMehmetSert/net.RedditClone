using Core.CrossCuttingConcerns.Exceptions.Middlewares;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Core;

public static class CoreExtensions
{
    public static void AddCoreExtensions(this IServiceCollection services)
    {
        var config = new ConfigurationBuilder().AddJsonFile("serilog.json").Build();
        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();

        services.AddHttpContextAccessor();
        services.AddSingleton<ILoggerService, LoggerService>();
        services.AddScoped<ILogModelCreatorService, LogModelCreatorService>();
    }

    public static void UseCoreMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<LoggerMiddleware>();
        app.UseMiddleware<ExceptionMiddleware>();
    }
}