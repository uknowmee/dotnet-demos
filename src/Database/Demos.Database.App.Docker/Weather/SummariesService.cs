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
    
    private readonly string[] _extendedSummaries =
    [
        "Freezing cold", "Bracing wind", "Chilly breeze", "Cool air", "Mild weather", "Warm sun", "Balmy day", "Hot summer", "Sweltering heat", "Scorching sun"
    ];
    
    public string[] Summaries()
    {
        return _summaries.Concat(_extendedSummaries).ToArray();
    }
}