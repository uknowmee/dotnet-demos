namespace Demos.Database.App.Docker.Weather;

public interface IWeatherService
{
    public Task<WeatherForecast[]> GetForecastAsync();
}