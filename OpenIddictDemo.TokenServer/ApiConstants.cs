namespace OpenIddictDemo.TokenServer;

internal static class ApiConstants
{
    public const string ApiReadScope = "api.weather.read";
    public const string ApiManageScope = "api.weather.manage";
    
    public const string WeatherApiAudience = "api://api.weather";
    public const string WeatherApiAuthority = "https://localhost:5150";
}