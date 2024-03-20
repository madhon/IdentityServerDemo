namespace IdentityServer4Demo.WeatherApi.Extensions;

public static class JsonOptionsExtensions
{
    public static WebApplicationBuilder ConfigureJsonOptions(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureHttpJsonOptions(opts =>
        {
            opts.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
        });

        return builder;
    }
}