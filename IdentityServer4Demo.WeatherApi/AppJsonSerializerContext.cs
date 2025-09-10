namespace IdentityServer4Demo.WeatherApi;

using System.Text.Json;
using System.Text.Json.Serialization;

[JsonSerializable(typeof(WeatherForecast))]
[JsonSerializable(typeof(WeatherForecast[]))]
[JsonSourceGenerationOptions(defaults: JsonSerializerDefaults.Web, GenerationMode = JsonSourceGenerationMode.Default)]
internal sealed partial class AppJsonSerializerContext : JsonSerializerContext;