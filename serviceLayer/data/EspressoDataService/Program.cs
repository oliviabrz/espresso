using System.ComponentModel.DataAnnotations;
using MySqlConnector;
using Dapper;
using EspressoDataService.Dto;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// CREATE Grinder
app.MapPost("/grinder", async (GrinderDto grinder, MySqlConnection connection) =>
{
    var sql = "INSERT INTO Grinder (BrandName, Model) VALUES (@BrandName, @Model);";
    await connection.ExecuteAsync(sql, grinder);
    return Results.Created($"/grinder/{grinder.Id}", grinder);
});

// READ Grinder

// UPDATE Grinder

// DELETE Grinder


app.Run();
