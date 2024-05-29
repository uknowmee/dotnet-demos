using Demos.Database.App.Docker.Weather;

namespace Demos.Database.App.Docker;

public static class Extensions
{
    public static WebApplicationBuilder AddCore(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IWeatherService, WeatherService>();
        builder.Services.AddSingleton<ISummariesService, SummariesService>();
        
        return builder;
    }
}