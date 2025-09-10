namespace IdentityServer4Demo.WeatherApi.Extensions;

internal static class WeatherServiceExtensions
{
    public static WebApplicationBuilder AddWeatherForecastServices(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        
        builder.Services.AddScoped<IWeatherForeCastService, WeatherForecastService>();
        return builder;
    }
}