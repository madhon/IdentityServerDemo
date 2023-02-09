namespace IdentityServer6Demo.TokenServer
{
    using Duende.IdentityServer;
    using Duende.IdentityServer.Models;

    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("api.weather.read", "Read Weather Data"),
                new ApiScope("manage", "Administrative Access to Weather Data")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("api://api.weather", "Weather API")
                {
                    Scopes = { "api.weather.read", "manage" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientName =  "WeatherClient",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    AllowedScopes = { "api.weather.read", "manage" },
                    Enabled = true,
                    AccessTokenLifetime = 3600 * 4
                }
            };
    }
}
