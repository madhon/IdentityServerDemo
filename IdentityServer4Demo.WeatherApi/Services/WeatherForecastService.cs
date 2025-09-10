namespace IdentityServer4Demo.WeatherApi.Services
{
    using System.Security.Cryptography;

    internal sealed class WeatherForecastService : IWeatherForeCastService
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        ];

        public async ValueTask<WeatherForecast[]> GetForecast()
        {
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = RandomNumberGenerator.GetInt32(-20, 55),
                Summary = Summaries[RandomNumberGenerator.GetInt32(Summaries.Length)],
            })
                .ToArray();

            return result;
        }

    }
}
