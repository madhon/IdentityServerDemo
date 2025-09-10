namespace IdentityServer4Demo.TokenServer;

using IdentityServer4.Models;

internal static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
    [
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
    ];

    public static IEnumerable<ApiScope> ApiScopes =>
    [
        new("api.weather.read", "Read Weather Data"),
        new("manage", "Administrative Access to Weather Data"),
    ];

    public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
        {
            new("api.weather", "Weather API")
            {
                Scopes = { "api.weather.read", "manage" },
            },
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new()
            {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "api.weather.read manage" },
            },
        };
}