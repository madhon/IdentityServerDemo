namespace IdentityServer6Demo.TokenServer;

using Duende.IdentityServer.Models;

internal static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
    [
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
    ];

    public static IEnumerable<ApiScope> ApiScopes =>
    [
        new()
        {
            Name = ApiConstants.ApiReadScope,
            DisplayName = "Read Weather Data",
            UserClaims = new List<string>
            {
                "readweather",
            },
        },
        new()
        {
            Name = ApiConstants.ApiManageScope,
            DisplayName = "Administrative Access to Weather Data",
            UserClaims = new List<string>
            {
                "manageweather",
            },
        },
    ];

    public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
        {
            new()
            {
                Name = ApiConstants.WeatherApiAudience,
                DisplayName = "Weather API",
                Scopes = { ApiConstants.ApiReadScope, ApiConstants.ApiManageScope },
            },
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new()
            {
                ClientId = "client",
                ClientName =  "WeatherClient",
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedGrantTypes = GrantTypes.ClientCredentials,

                AllowedScopes = { ApiConstants.ApiReadScope, ApiConstants.ApiManageScope },
                Enabled = true,
                AccessTokenLifetime = 3600 * 4,
            },
        };
}