namespace IdentityServer4Demo.WeatherApi.Extensions;

internal static class JsonOptionsExtensions
{
    public static IServiceCollection ConfigureJsonOptions(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        
        services.ConfigureHttpJsonOptions(opts =>
        {
            opts.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
        });

        return services;
    }
}