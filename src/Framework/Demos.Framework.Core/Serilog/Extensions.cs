using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;

namespace Demos.Framework.Core.Serilog;

internal static class Extensions
{
    public static WebApplicationBuilder AddLogging(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog();
        return builder;
    }

    public static IServiceCollection AddLogger(this IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        var factory = new LoggerFactory(new ILoggerProvider[]
            {
                new SerilogLoggerProvider(Log.Logger)
            }
        );

        services.AddSingleton(factory);
        return services;
    }

    public static IApplicationBuilder UseContextLogger(this IApplicationBuilder app) => app.UseSerilogRequestLogging();
}