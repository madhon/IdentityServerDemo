namespace IdentityServer4Demo.WeatherApi.Extensions
{
    using System.Text.Json.Serialization;
    using System.Text.Json;
    using Microsoft.AspNetCore.Http.Json;

    public static class JsonOptionsExtensions
    {
        public static WebApplicationBuilder ConfigureJsonOptions(this WebApplicationBuilder builder)
        {
            _ = builder.Services.Configure<JsonOptions>(opt =>
            {
                opt.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                opt.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                opt.SerializerOptions.PropertyNameCaseInsensitive = true;
                opt.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                opt.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            });

            return builder;
        }
    }
}
