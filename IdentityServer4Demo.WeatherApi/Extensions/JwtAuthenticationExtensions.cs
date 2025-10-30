namespace IdentityServer4Demo.WeatherApi.Extensions;

using Microsoft.IdentityModel.Tokens;

internal static class JwtAuthenticationExtensions
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
            opts.TokenValidationParameters = new TokenValidationParameters
            {
                ValidTypes = ["at+jwt"],
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.FromMinutes(5)
            };
            opts.MapInboundClaims = false;
        });

        return builder;
    }
}