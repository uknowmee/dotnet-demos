using Demos.Framework.Core.Serilog;
using Demos.Framework.Core.Swagger;
using Microsoft.AspNetCore.Builder;

namespace Demos.Framework.Core;

public static class Extensions
{
    public static WebApplicationBuilder AddFramework(this WebApplicationBuilder builder)
    {
        builder
            .AddLogging()
            .Services
            .AddSwagger()
            .AddLogger();

        return builder;
    }

    public static WebApplication UseFramework(this WebApplication app)
    {
        app
            .UseContextLogger()
            .UseSwagger();

        return app;
    }
}