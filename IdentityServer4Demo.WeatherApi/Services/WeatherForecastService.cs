namespace IdentityServer4Demo.WeatherApi.Services;

using System.Security.Cryptography;

internal sealed class WeatherForecastService(TimeProvider timeProvider) : IWeatherForeCastService
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
    ];

    public ValueTask<WeatherForecast[]> GetForecast()
    {
        var result = new WeatherForecast[5];
        for (var i = 0; i < result.Length; i++)
        {
            result[i] = new WeatherForecast(
                timeProvider.GetUtcNow().AddDays(i + 1),
                RandomNumberGenerator.GetInt32(-20, 55),
                Summaries[RandomNumberGenerator.GetInt32(Summaries.Length)]);
        }

        return ValueTask.FromResult(result);
    }
}