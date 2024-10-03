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
builder.Services.AddTransient<MySqlConnection>(_ => new MySqlConnection(builder.Configuration.GetConnectionString("EspressoDatabase")));

// Build the application
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Espresso API v1"));

// CREATE Grinder API Route
app.MapPost("/grinder", async (GrinderDtoBase grinder, MySqlConnection connection) =>
{
    var sql = @"
        INSERT INTO Grinder (BrandName, Model) 
        VALUES (@BrandName, @Model);
        SELECT LAST_INSERT_ID();";
    var id = await connection.ExecuteScalarAsync<int>(sql, grinder);
    return Results.Created($"/grinder/{id}", id);
})
.Produces<int>(StatusCodes.Status201Created);

// READ All Grinder API Route
app.MapGet("/grinder", async (MySqlConnection connection) =>
{
    var sql = "SELECT * FROM Grinder";
    var grinders = await connection.QueryAsync<GrinderDto>(sql);
    return Results.Ok(grinders);
})
.Produces<IEnumerable<GrinderDto>>(StatusCodes.Status200OK);

// READ One Grinder API Route
app.MapGet("/grinder/{id}", async (int id, MySqlConnection connection) =>
{
    var sql = "SELECT * FROM Grinder WHERE Id = @id";
    var grinder = await connection.QueryFirstOrDefaultAsync<GrinderDto>(sql, new { id });
    return grinder is null ? Results.NotFound() : Results.Ok(grinder);
});

// UPDATE Grinder API Route
app.MapPut("/grinder/{id}", async (int id, GrinderDtoBase grinder, MySqlConnection connection) =>
{
    var sql = @"
        UPDATE Grinder 
        SET BrandName = @BrandName, Model = @Model
        WHERE Id = @id";
    var rowsAffected = await connection.ExecuteAsync(sql, new { id, grinder.BrandName, grinder.Model });
    return rowsAffected == 0 ? Results.NotFound() : Results.NoContent();
});

// DELETE Grinder API Route
app.MapDelete("/grinder/{id}", async (int id, MySqlConnection connection) =>
{
    var sql = "DELETE FROM Grinder WHERE Id = @id";
    var rowsAffected = await connection.ExecuteAsync(sql, new { id });
    return rowsAffected == 0 ? Results.NotFound() : Results.NoContent();
});


app.Run();
