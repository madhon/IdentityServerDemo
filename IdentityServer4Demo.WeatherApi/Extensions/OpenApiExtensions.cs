namespace IdentityServer4Demo.WeatherApi.Extensions;

using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

internal static class OpenApiExtensions
{
    public static WebApplicationBuilder AddOpenApiServices(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
            options.AddDocumentTransformer((document, context, cancellationToken) =>
            {
                document.Info = new OpenApiInfo
                {
                    Title = "Weather Forecast API",
                    Description = "An example Weather Forecast Minimal API in .NET 9.",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Weather Forecast API",
                        Email = "madhon@madhon.co.uk",
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "Weather Forecast API - License - MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT"),
                    },
                };
                    
                return Task.CompletedTask;
            }); 
        });

        return builder;
    }

    public static WebApplication UseOpenApiServices(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }
            
        return app;
    }
}