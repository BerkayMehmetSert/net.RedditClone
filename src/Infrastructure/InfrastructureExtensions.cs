using Infrastructure.EmailService;
using Infrastructure.EmailService.Builder;
using Infrastructure.EmailService.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureExtensions
{
    public static EmailOptions? EmailOptions { get; private set; }

    public static void AddInfrastructureExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        EmailOptions = configuration.GetSection("EmailOptions").Get<EmailOptions>();
        services.Configure<EmailOptions>(configuration.GetSection("EmailOptions"));
        services.AddScoped<IEmailService, EmailService.EmailService>();
        services.AddScoped<IEmailContentBuilder, EmailContentBuilder>();
    }
}