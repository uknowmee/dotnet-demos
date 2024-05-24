namespace Demos.Framework.Core.Database;

public class DatabaseOptions
{
    public DatabaseType Type { get; set; } = DatabaseType.Sqlite;
    public string ConnectionString { get; set; } = string.Empty;
}