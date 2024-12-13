using System;
using Dapper;
using EspressoDataService.Dto;
using MySqlConnector;

namespace EspressoDataService.Api;

public static class GrinderApi
{
    public static WebApplication MapGrinderApiEndpoints(this WebApplication app)
    {
        #region Api Routes - Grinder
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
            var enumerable = await connection.QueryAsync<GrinderDto>(sql);
            return Results.Ok(enumerable);
        })
        .Produces<IEnumerable<GrinderDto>>(StatusCodes.Status200OK);

        // READ One Grinder API Route
        app.MapGet("/grinder/{id}", async (int id, MySqlConnection connection) =>
        {
            var sql = "SELECT * FROM Grinder WHERE Id = @id";
            var item = await connection.QueryFirstOrDefaultAsync<GrinderDto>(sql, new { id });
            return item is null ? Results.NotFound() : Results.Ok(item);
        });

        // UPDATE Grinder API Route
        app.MapPut("/grinder/{id}", async (int id, GrinderDtoBase grinder, MySqlConnection connection) =>
        {
            var sql = @"
                UPDATE Grinder 
                SET BrandName = @BrandName, Model = @Model
                WHERE Id = @id";
            var rowsAffected = await connection.ExecuteAsync(sql, new { id, grinder.BrandName, grinder.ModelName });
            return rowsAffected == 0 ? Results.NotFound() : Results.NoContent();
        });

        // DELETE Grinder API Route
        app.MapDelete("/grinder/{id}", async (int id, MySqlConnection connection) =>
        {
            var sql = "DELETE FROM Grinder WHERE Id = @id";
            var rowsAffected = await connection.ExecuteAsync(sql, new { id });
            return rowsAffected == 0 ? Results.NotFound() : Results.NoContent();
        });
        #endregion

        return app;
    }
}
