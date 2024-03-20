namespace IdentityServer4Demo.WeatherApi.Extensions
{
    public static class JwtAuthenticationExtensions
    {
        public static WebApplicationBuilder AddJwtAuthentication(this WebApplicationBuilder builder)
        {
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
                opts.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
                opts.MapInboundClaims = false;
            });

            return builder;
        }

    }
}
