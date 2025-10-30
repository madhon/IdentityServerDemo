var builder = WebApplication.CreateBuilder(args);

builder.AddSerilog();

builder.Services.ConfigureJsonOptions();
builder.Services.ConfigureForwardedHeaders();

builder.AddJwtAuthentication();
builder.AddWeatherForecastServices();

builder.AddOpenApiServices();


var app = builder.Build();

app.UseForwardedHeaders();
app.UseExceptionHandler();
app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseRequestTimeouts();
app.UseOutputCache();

app.UseResponseCompression();
app.UseResponseCaching();

app.UseOpenApiServices();

app.MapGetWeatherForecast();

app.Run();
