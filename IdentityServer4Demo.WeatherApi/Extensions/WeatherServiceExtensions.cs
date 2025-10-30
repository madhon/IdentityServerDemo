namespace IdentityServer4Demo.WeatherApi.Extensions;

using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.ResponseCompression;

internal static class WeatherServiceExtensions
{

    public static IServiceCollection ConfigureForwardedHeaders(this IServiceCollection services)
    {
        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            options.KnownNetworks.Clear();
            options.KnownProxies.Clear();
        });
        
        return services;
    }
    
    public static WebApplicationBuilder AddWeatherForecastServices(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Services.AddProblemDetails();
        
        builder.Services.AddRequestTimeouts();
        builder.Services.AddOutputCache();
        
        builder.Services.AddResponseCaching();
        builder.Services.AddResponseCompression(opts =>
        {
            opts.EnableForHttps = true;
            opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                new[] { "application/json" });
            opts.Providers.Add<BrotliCompressionProvider>();
            opts.Providers.Add<GzipCompressionProvider>();
        });
        
        builder.Services.AddSingleton<TimeProvider>(TimeProvider.System);
        builder.Services.AddScoped<IWeatherForeCastService, WeatherForecastService>();
        return builder;
    }
}