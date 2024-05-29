namespace Demos.Database.App.Docker.Weather;

public class SummariesService : ISummariesService
{
    private readonly string[] _summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];
    
    public string[] Summaries()
    {
        return _summaries;
    }
}