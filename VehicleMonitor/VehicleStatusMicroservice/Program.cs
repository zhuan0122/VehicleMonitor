using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using VehicleStatusMicroservice.Models;
using VehicleStatusMicroService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext to the DI container
builder.Configuration.GetConnectionString("VehicleStatus");
var connectionString = builder.Configuration.GetConnectionString("VehicleStatus");

if (string.IsNullOrEmpty(connectionString))
{
    // Handle the null or empty connection string, log an error, or use a default connection string.
    // Example: Log.LogError("Connection string is null or empty.");
    // Or: connectionString = "DefaultConnectionStringHere";
}
else
{
    builder.Services.AddDbContext<VehicleStatusDbContext>(options => options.UseMySQL(connectionString));
}

builder.Services.AddScoped<VehicleStatusService>();

builder.Services.AddScoped<VehicleStatusDbContext>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddMvc();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vehicle's status information Web API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("v1/swagger.json", "Vehicle's status");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();