namespace Demos.Database.App.Docker.Weather;

public interface ISummariesService
{
    public string[] Summaries();
}

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