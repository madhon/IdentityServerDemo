namespace IdentityServer4Demo.WeatherApi.Services;

internal interface IWeatherForeCastService
{
    ValueTask<WeatherForecast[]> GetForecast();
}