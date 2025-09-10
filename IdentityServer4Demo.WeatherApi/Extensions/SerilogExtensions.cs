namespace IdentityServer4Demo.WeatherApi.Extensions;

using System.Globalization;
using Serilog;
using Serilog.Events;
using Serilog.Settings.Configuration;

internal static class SerilogExtensions
{
    public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder, string sectionName = "Serilog")
    {
        ArgumentNullException.ThrowIfNull(builder);
        
        var serilogOptions = new SerilogOptions();
        builder.Configuration.GetSection(sectionName).Bind(serilogOptions);

        builder.Services.AddSerilog(loggerConfiguration =>
        {
            var options = new ConfigurationReaderOptions { SectionName = "Serilog" };
            loggerConfiguration.ReadFrom.Configuration(builder.Configuration, options);

            loggerConfiguration
                .Enrich.WithProperty("Application", builder.Environment.ApplicationName)
                .Enrich.FromLogContext();

            loggerConfiguration.MinimumLevel.Override("Microsoft", LogEventLevel.Information);
            loggerConfiguration.MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning);

            if (serilogOptions.UseConsole)
            {
                loggerConfiguration.WriteTo.Async(writeTo =>
                {
                    writeTo.Console(outputTemplate: serilogOptions.LogTemplate, formatProvider: CultureInfo.InvariantCulture);
                });
            }
        });

        return builder;
    }

    internal sealed class SerilogOptions
    {
        public bool UseConsole { get; set; } = true;

        public string LogTemplate { get; set; } =
            "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} {Level:u3} - {Message:lj}{NewLine}{Exception}";
    }
}