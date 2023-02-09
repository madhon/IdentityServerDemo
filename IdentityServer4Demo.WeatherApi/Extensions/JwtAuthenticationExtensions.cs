﻿namespace IdentityServer4Demo.WeatherApi.Extensions
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
                opts.Authority = "http://localhost:5156";
                opts.RequireHttpsMetadata = false;
                opts.Audience = "api://api.weather";
                opts.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
            });

            return builder;
        }

    }
}
