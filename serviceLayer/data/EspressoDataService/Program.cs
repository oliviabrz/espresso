using MySqlConnector;
using Dapper;
using EspressoDataService.Dto;
using Microsoft.OpenApi.Models;

// Create a new WebApplication
var builder = WebApplication.CreateBuilder(args);

// Add services to the application
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Espresso API", Version = "v1" });
});

// Configure MySQL connection
builder.Services.AddTransient<MySqlConnection>(_ => new MySqlConnection(builder.Configuration.GetConnectionString("ConnectionStrings.EspressoDatabase")));

// Build the application
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Espresso API v1"));

// CREATE Grinder API Route
app.MapPost("/grinder", async (GrinderDto grinder, MySqlConnection connection) =>
{
    var sql = "INSERT INTO Grinder (BrandName, Model) VALUES (@BrandName, @Model);";
    await connection.ExecuteAsync(sql, grinder);
    return Results.Created($"/grinder/{grinder.Id}", grinder);
});

// READ Grinder API Route

// UPDATE Grinder API Route

// DELETE Grinder API Route


app.Run();