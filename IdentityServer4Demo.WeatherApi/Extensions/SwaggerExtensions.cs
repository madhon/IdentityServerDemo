namespace IdentityServer4Demo.WeatherApi.Extensions
{
    using Microsoft.OpenApi.Models;
    using System.Globalization;
    using System.Reflection;

    public static class SwaggerExtensions
    {
        public static WebApplicationBuilder AddSwaggerServices(this WebApplicationBuilder builder)
        {
            var ti = CultureInfo.CurrentCulture.TextInfo;

            _ = builder.Services.AddEndpointsApiExplorer();
            _ = builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Version = "v1",
                        Title = $"Weather Forecast API - {ti.ToTitleCase(builder.Environment.EnvironmentName)} ",
                        Description = "An example Weather Forecast Minimal API in .NET 7.",
                        Contact = new OpenApiContact
                        {
                            Name = "Weather Forecast API",
                            Email = "madhon@madhon.co.uk"
                        },
                        License = new OpenApiLicense()
                        {
                            Name = "Weather Forecast API - License - MIT",
                            Url = new Uri("https://opensource.org/licenses/MIT")
                        }
                    });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

                options.EnableAnnotations();
                options.DocInclusionPredicate((name, api) => true);

            });

            return builder;
        }


        public static WebApplication UseSwaggerServices(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                var ti = CultureInfo.CurrentCulture.TextInfo;
                _ = app.UseSwagger();
                _ = app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"Weather Forecast API - {ti.ToTitleCase(app.Environment.EnvironmentName)} - V1"));

            }
            
            return app;
        }
    }
}
