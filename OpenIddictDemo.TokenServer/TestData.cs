namespace OpenIddictDemo.TokenServer;

using OpenIddict.Abstractions;

internal sealed class TestData : IHostedService
{
    private readonly IServiceProvider serviceProvider;

    public TestData(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }
    
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await using var scope = serviceProvider.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await context.Database.EnsureCreatedAsync(cancellationToken);

        var manager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();

        if (await manager.FindByClientIdAsync("client", cancellationToken) is null)
        {
            var appDescriptor = new OpenIddictApplicationDescriptor
            {
                ClientId = "client",
                ClientSecret = "secret",
                DisplayName = "client",
                Permissions =
                {
                    OpenIddictConstants.Permissions.Endpoints.Authorization,
                    OpenIddictConstants.Permissions.Endpoints.Token,
                    OpenIddictConstants.Permissions.Endpoints.Introspection,
                    OpenIddictConstants.Permissions.Endpoints.Revocation,
                    
                    OpenIddictConstants.Permissions.GrantTypes.AuthorizationCode,
                    OpenIddictConstants.Permissions.GrantTypes.ClientCredentials,
                    OpenIddictConstants.Permissions.GrantTypes.RefreshToken,
                    OpenIddictConstants.Permissions.GrantTypes.Password,
                    
                    OpenIddictConstants.Permissions.Prefixes.Scope + ApiConstants.ApiReadScope,
                    OpenIddictConstants.Permissions.Prefixes.Scope + ApiConstants.ApiManageScope,
                    OpenIddictConstants.Permissions.ResponseTypes.Code,
                }
            };

            appDescriptor.AddAudiencePermissions(ApiConstants.WeatherApiAudience);
            
            await manager.CreateAsync(appDescriptor, cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}