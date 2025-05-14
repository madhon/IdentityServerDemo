namespace OpenIddictDemo.TokenServer;

using Microsoft.AspNetCore;
using OpenIddict.Abstractions;
using System.Diagnostics;
using System.Security.Claims;
using static OpenIddict.Abstractions.OpenIddictConstants;
using static OpenIddict.Server.AspNetCore.OpenIddictServerAspNetCoreHandlerFilters;
using static OpenIddict.Server.AspNetCore.OpenIddictServerAspNetCoreHandlers;
using static OpenIddict.Server.OpenIddictServerEvents;

internal static class OpenIddictServerExtensions
{
    public static OpenIddictServerBuilder AddCustomHandlers(this OpenIddictServerBuilder builder)
    {
        builder.RemoveEventHandler(ExtractPostRequest<ExtractTokenRequestContext>.Descriptor);
        
        
        
        builder.AddEventHandler<ExtractTokenRequestContext>(builder =>
        {
            builder.UseInlineHandler(async context =>
            {
                var request = context.Transaction.GetHttpRequest() ?? throw new InvalidOperationException();

                if (!HttpMethods.IsPost(request.Method) || string.IsNullOrEmpty(request.ContentType) ||
                    !request.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
                {
                    context.Reject(Errors.InvalidRequest);
                    return;
                }

                // Enable buffering and rewind the request body after extracting the JSON payload to ensure
                // the ASP.NET Core Identity API endpoint can also resolve the request parameters.

                request.EnableBuffering();

                try
                {
                    context.Request = await request.ReadFromJsonAsync<OpenIddictRequest>() ?? new();
                }

                finally
                {
                    request.Body.Position = 0L;
                }

                // Unlike a standard OAuth 2.0 implementation, ASP.NET Core Identity's login endpoint doesn't
                // specify the grant_type parameter. Since it's the only authentication method supported anyway,
                // assume all token requests are resource owner password credentials (ROPC) requests.
                context.Request.GrantType = GrantTypes.Password;

                // The latest version of the ASP.NET Core Identity API package uses "email" instead of the
                // standard OAuth 2.0 username parameter. To work around that, the email parameter is manually
                // mapped to the standard OAuth 2.0 username parameter.
                //context.Request.Username = (string?) context.Request["email"];
            });

            builder.AddFilter<RequireHttpRequest>();
            builder.SetOrder(ExtractPostRequest<ExtractTokenRequestContext>.Descriptor.Order);
        });


        return builder;
    }
    
    
}