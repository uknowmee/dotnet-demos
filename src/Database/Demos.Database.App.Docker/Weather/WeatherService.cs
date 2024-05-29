namespace Demos.Database.App.Docker.Weather;

public class WeatherService : IWeatherService
{
    private readonly ILogger<WeatherService> _logger;

    private readonly string[] _summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];
    
    private readonly string[] _extendedSummaries =
    [
        "Freezing cold", "Bracing wind", "Chilly breeze", "Cool air", "Mild weather", "Warm sun", "Balmy day", "Hot summer", "Sweltering heat", "Scorching sun"
    ];

    public WeatherService(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<WeatherService>();
    }

    public Task<WeatherForecast[]> GetForecastAsync()
    {
        var summaries = _summaries.Concat(_extendedSummaries).Distinct().ToArray();
        
        var forecast = Enumerable.Range(1, 5)
            .Select(index => new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    _summaries[Random.Shared.Next(_summaries.Length)]
                )
            ).ToArray();


        _logger.LogInformation("Generated weather forecast for {Days} days", forecast.Length);
        return Task.FromResult(forecast);
    }
}