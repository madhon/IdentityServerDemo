namespace IdentityServer4Demo.WeatherApi.Extensions;

interface IInterface
{
    
}

static class JwtAuthenticationExtensions
{
    public static WebApplicationBuilder AddJwtAuthentication(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        
        builder.Services.AddAuthorization();

        builder.Services.AddAuthentication(opts =>
        {
            opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opts =>
        {
            opts.Authority = "https://localhost:5150";
            opts.RequireHttpsMetadata = false;
            opts.Audience = "api://api.weather";
            opts.TokenValidationParameters.ValidTypes = ["at+jwt"];
            opts.MapInboundClaims = false;
        });

        return builder;
    }

}