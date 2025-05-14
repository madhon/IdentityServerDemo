namespace IdentityServer4Demo.WeatherApi.Services
{
    public class WeatherForeCastService : IWeatherForeCastService
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        ];

        public async Task<WeatherForecast[]> GetForecast()
        {
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            })
                .ToArray();

            return result;
        }

    }
}
