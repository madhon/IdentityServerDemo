namespace IdentityServer4Demo.WeatherApi.Extensions;

public static class WeatherServiceExtensions
{
    public static WebApplicationBuilder AddWeatherForecastServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IWeatherForeCastService, WeatherForeCastService>();
        return builder;
    }
}