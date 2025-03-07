var builder = WebApplication.CreateBuilder(args);

builder.AddSerilog();

builder.ConfigureJsonOptions();

builder.AddJwtAuthentication();
builder.AddWeatherForecastServices();

builder.AddOpenApiServices();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.UseAuthentication();
app.UseAuthorization();

app.UseOpenApiServices();

app.MapGetWeatherForecast();

app.Run();
