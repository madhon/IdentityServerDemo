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
                new ApiScope()
                {
                    Name = ApiConstants.ApiReadScope,
                    DisplayName = "Read Weather Data",
                    UserClaims = new List<string>()
                    {
                        "readweather"
                    }
                },
                new ApiScope()
                {
                    Name = ApiConstants.ApiManageScope,
                    DisplayName = "Administrative Access to Weather Data",
                    UserClaims = new List<string>()
                    {
                        "manageweather"
                    }
                },
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource()
                {
                    Name = ApiConstants.WeatherApiAudience,
                    DisplayName = "Weather API",
                    Scopes = { ApiConstants.ApiReadScope, ApiConstants.ApiManageScope }
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

                    AllowedScopes = { ApiConstants.ApiReadScope, ApiConstants.ApiManageScope },
                    Enabled = true,
                    AccessTokenLifetime = 3600 * 4
                }
            };
    }
}
