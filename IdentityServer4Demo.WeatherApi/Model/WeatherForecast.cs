namespace IdentityServer4Demo.WeatherApi.Model;

internal readonly struct WeatherForecast
{
    public WeatherForecast(DateTimeOffset date, int temperatureC, string? summary)
    {
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }

    public DateTimeOffset Date { get; }

    public int TemperatureC { get; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; }
}