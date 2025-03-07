using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase(nameof(ApplicationDbContext));
    options.UseOpenIddict();
});

builder.Services.AddHostedService<TestData>();

builder.Services.AddControllers();
builder.Services.AddProblemDetails();

builder.Services.AddRouting();

builder.Services.AddOpenIddict()
    .AddCore(options =>
    {
        options.UseEntityFrameworkCore().UseDbContext<ApplicationDbContext>();
    })
    .AddServer(options =>
    {
        //options.AddCustomHandlers();
        
        options.AllowAuthorizationCodeFlow()
            .RequireProofKeyForCodeExchange()
            .AllowClientCredentialsFlow()
            .AllowRefreshTokenFlow();
        
        options
            .SetAuthorizationEndpointUris("/connect/authorize")
            .SetTokenEndpointUris("/connect/token")
            .SetUserInfoEndpointUris("/connect/userinfo")
            .SetIntrospectionEndpointUris("/connect/introspect")
            .SetRevocationEndpointUris("/connect/revoke");

        options
            .AddDevelopmentEncryptionCertificate()
            .AddDevelopmentSigningCertificate()
            .DisableAccessTokenEncryption();

        options.RegisterScopes(ApiConstants.ApiReadScope, ApiConstants.ApiManageScope);
        
        options
            .UseAspNetCore()
            .EnableStatusCodePagesIntegration()
            .EnableTokenEndpointPassthrough()
            .EnableAuthorizationEndpointPassthrough()
            .EnableUserInfoEndpointPassthrough();  
    })
    .AddValidation(o =>
    {
        o.SetIssuer(ApiConstants.WeatherApiAuthority);
        o.AddAudiences(ApiConstants.WeatherApiAudience);
        o.UseLocalServer();
        o.UseAspNetCore();
        o.EnableTokenEntryValidation();
    });;

var app = builder.Build();

app.UseStatusCodePages();
app.UseExceptionHandler();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapDefaultControllerRoute();

app.MapGet("/", () => "Hello World!");

app.Run();