var builder = WebApplication.CreateBuilder(args);

builder.AddSerilog();

builder.ConfigureJsonOptions();

builder.AddJwtAuthentication();
builder.AddWeatherForecastServices();

builder.AddSwaggerServices();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.UseAuthentication();
app.UseAuthorization();

app.UseSwaggerServices();

app.MapGetWeatherForecast();

app.Run();
