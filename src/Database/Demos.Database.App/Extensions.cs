using Demos.Database.App.Weather;

namespace Demos.Database.App;

public static class Extensions
{
    public static WebApplicationBuilder AddCore(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IWeatherService, WeatherService>();
        
        return builder;
    }
}