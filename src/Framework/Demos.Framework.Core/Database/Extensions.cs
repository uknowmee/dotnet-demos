using Demos.Framework.Core.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Demos.Framework.Core.Database;

public static class Extensions
{
    public static WebApplicationBuilder AddDatabase<TDatabaseCtx>(this WebApplicationBuilder builder, string configurationSection) where TDatabaseCtx : DbContext
    {
        var dbOptions = ConfigurationBuilder.Build<DatabaseOptions>(builder.Configuration, configurationSection);

        builder.Services.AddDbContext<TDatabaseCtx>(options =>
            {
                _ = dbOptions.Type switch
                {
                    DatabaseType.Sqlite => UseSqlite(options, dbOptions),
                    DatabaseType.Postgres => options.UseNpgsql(dbOptions.ConnectionString),
                    _ => throw new InvalidOperationException($"Unsupported database type: {dbOptions.Type}")
                };
            }
        );

        return builder;
    }

    private static DbContextOptionsBuilder UseSqlite(DbContextOptionsBuilder options, DatabaseOptions dbOptions)
    {
        var connectionString = dbOptions.ConnectionString;
        var currentDirectory = Directory.GetCurrentDirectory();
        var relativePath = connectionString.Split('=')[1].Split('/').SkipLast(1).ToArray();
        var dbDirPath = Path.Combine(currentDirectory, Path.Combine(relativePath));
        
        if (Directory.Exists(dbDirPath) is false)
        {
            Directory.CreateDirectory(dbDirPath);
        }

        return options.UseSqlite(connectionString);
    }

    public static IApplicationBuilder CreateDatabase<TDatabase>(this IApplicationBuilder app) where TDatabase : DbContext
    {
        using var scope = app.ApplicationServices.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<TDatabase>();
        dbContext.Database.EnsureCreated();

        return app;
    }
}