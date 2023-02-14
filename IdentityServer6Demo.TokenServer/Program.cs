using IdentityServer6Demo.TokenServer;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

LoggerBootstrap.Configure();

builder.Host.UseSerilog();


builder.Services.AddIdentityServer(opts =>
    {
        opts.Events.RaiseErrorEvents = true;
        opts.Events.RaiseInformationEvents = true;
        opts.Events.RaiseFailureEvents = true;
        opts.Events.RaiseSuccessEvents = true;

        opts.EmitStaticAudienceClaim = false;
    })
    .AddDeveloperSigningCredential()
    .AddInMemoryApiResources(Config.ApiResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients);

var app = builder.Build();

app.UseIdentityServer();

app.Run();