namespace IdentityServer4Demo.WeatherApi.Endpoints
{
    using IdentityServer4Demo.WeatherApi.Services;
    using Microsoft.AspNetCore.Mvc;

    public static class WeatherForecastEndpoint
    {
        public static IEndpointRouteBuilder MapGetWeatherForecast(this IEndpointRouteBuilder app)
        {
            app.MapGet("/weatherforecast", async ([FromServices] ILoggerFactory loggerFactory, [FromServices] IWeatherForeCastService weatherForeCastService) =>
                {
                    var logger = loggerFactory.CreateLogger("GetWeatherForecast"); 
                    logger.LogInformation("Executing GetWeatherForecast");
                    var result = await weatherForeCastService.GetForecast();

                    return TypedResults.Ok(result);
            }).RequireAuthorization()
                .WithName("GetWeatherForecast")
                .WithOpenApi()
                .Produces<WeatherForecast[]>();

            return app;
        }
    }
}
