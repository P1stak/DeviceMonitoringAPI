using DeviceMonitoring.Repository;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


// Подключил контроллеры
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Device Monitoring API", Version = "v1" });
});

// DI
builder.Services.AddSingleton<IDeviceRepository, DeviceRepository>();
builder.Services.AddLogging(configure => configure.AddConsole());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// angular cors
app.UseCors(x =>

    x.WithOrigins("http://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader());


app.Run();
