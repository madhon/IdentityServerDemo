namespace IdentityServer4Demo.WeatherApi.Services;

using System.Security.Cryptography;

internal sealed class WeatherForecastService : IWeatherForeCastService
{
    private readonly TimeProvider timeProvider;
    
    public WeatherForecastService(TimeProvider timeProvider)
    {
        this.timeProvider = timeProvider;
    }
    
    
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
    ];

    public async ValueTask<WeatherForecast[]> GetForecast()
    {
        var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date =  timeProvider.GetUtcNow().Date.AddDays(index),
                TemperatureC = RandomNumberGenerator.GetInt32(-20, 55),
                Summary = Summaries[RandomNumberGenerator.GetInt32(Summaries.Length)],
            })
            .ToArray();

        return result;
    }
}