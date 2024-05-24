namespace Demos.Database.App.Weather;

public interface IWeatherService
{
    public Task<WeatherForecast[]> GetForecastAsync();
}