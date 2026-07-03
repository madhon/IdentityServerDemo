namespace OpenIddictDemo.TokenServer;

using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;

[JsonSourceGenerationOptions(defaults: JsonSerializerDefaults.Web, GenerationMode = JsonSourceGenerationMode.Default)]
[JsonSerializable(typeof(LoginRequest))]
[JsonSerializable(typeof(SignInResult))]
[JsonSerializable(typeof(ChallengeResult))]
[JsonSerializable(typeof(UserInfoResponse))]

[JsonSerializable(typeof(OpenIddictRequest))]
[JsonSerializable(typeof(OpenIddictResponse))]

[JsonSerializable(typeof(ProblemDetails))]
[JsonSerializable(typeof(HttpValidationProblemDetails))]
[JsonSerializable(typeof(ValidationProblem))]
[JsonSerializable(typeof(ProblemHttpResult))]
internal sealed partial class AppJsonSerializerContext : JsonSerializerContext;