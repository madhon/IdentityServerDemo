namespace IdentityServer4Demo.WeatherApi.Services;

public interface IWeatherForeCastService
{
    Task<WeatherForecast[]> GetForecast();
}