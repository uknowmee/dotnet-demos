using Demos.Database.App;
using Demos.Database.App.Weather;
using Demos.Database.Books;
using Demos.Database.Events;
using Demos.Framework.Core;
using Demos.Framework.Core.Database;

var builder = WebApplication.CreateBuilder(args)
    .AddFramework()
    .AddDatabase<BooksCtx>("DatabaseSettings:Books")
    .AddDatabase<EventsCtx>("DatabaseSettings:Events")
    .AddCore();

var app = builder.Build();
app.UseHttpsRedirection();

app.MapGet("/weatherforecast", async (IWeatherService weatherService) => await weatherService.GetForecastAsync())
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.UseFramework()
    .CreateDatabase<BooksCtx>()
    .CreateDatabase<EventsCtx>();

app.Run();