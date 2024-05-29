namespace Demos.Database.App.Docker.Weather;

public class WeatherService : IWeatherService
{
    private readonly ILogger<WeatherService> _logger;
    private readonly ISummariesService _summariesService;
    
    public WeatherService(ILoggerFactory loggerFactory, ISummariesService summariesService)
    {
        _logger = loggerFactory.CreateLogger<WeatherService>();
        _summariesService = summariesService;
    }

    public Task<WeatherForecast[]> GetForecastAsync()
    {
        var summaries = _summariesService.Summaries();
        
        var forecast = Enumerable.Range(1, 5)
            .Select(index => new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                )
            ).ToArray();


        _logger.LogInformation("Generated weather forecast for {Days} days", forecast.Length);
        return Task.FromResult(forecast);
    }
}