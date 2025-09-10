namespace IdentityServer6Demo.TokenServer;

using System.Globalization;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

internal static class LoggerBootstrap
{
    public static void Configure()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
            .MinimumLevel.Override("System", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Async(x=> x.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}  {Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Code, formatProvider: CultureInfo.InvariantCulture))
            .CreateLogger();
    }
}