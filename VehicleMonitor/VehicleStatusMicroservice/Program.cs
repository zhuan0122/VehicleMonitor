using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
using VehicleStatusMicroservice.Models;
using VehicleStatusMicroservice.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext to the DI container
builder.Configuration.GetConnectionString("VehicleStatus");
var connectionString = builder.Configuration.GetConnectionString("VehicleStatus");

///Hardcoded secret key for testing purposes only
var secretKey = "qwertyuiopasdfghjklzxcvbnm123456";
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key
        };
    });

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

builder.Services.AddScoped<IVehicleStatusService, VehicleStatusService>();

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