using Dapper;
using MySqlConnector;

namespace EspressoDataService.Api;

public static class RoastTypeApi
{
    public static WebApplication MapRoastTypeApiEndpoints(this WebApplication app)
    {
        #region Api Routes - RoastType
        // CREATE RoastType API Route
        app.MapPost("/roastType", async (string roastTypeName, MySqlConnection connection) =>
        {
            var sql = @"
                INSERT INTO RoastType (Name) 
                VALUES (@Name);
                SELECT LAST_INSERT_ID();";
            var id = await connection.ExecuteScalarAsync<int>(sql, roastTypeName);
            return Results.Created($"/roastType/{id}", id);
        })
        .Produces<int>(StatusCodes.Status201Created);

        // READ All RoastType API Route
        app.MapGet("/roastType", async (MySqlConnection connection) =>
        {
            var sql = "SELECT * FROM RoastType";
            var enumerable = await connection.QueryAsync<RoastTypeDto>(sql);
            return Results.Ok(enumerable);
        })
        .Produces<IEnumerable<RoastTypeDto>>(StatusCodes.Status200OK);

        // READ One RoastType API Route
        app.MapGet("/roastType/{id}", async (int id, MySqlConnection connection) =>
        {
            var sql = "SELECT * FROM RoastType WHERE Id = @id";
            var item = await connection.QueryFirstOrDefaultAsync<RoastTypeDto>(sql, new { id });
            return item is null ? Results.NotFound() : Results.Ok(item);
        });

        // UPDATE RoastType API Route
        app.MapPut("/roastType/{id}", async (int id, RoastTypeDtoBase roastType, MySqlConnection connection) =>
        {
            var sql = @"
                UPDATE RoastType 
                SET RoastName = @RoastName
                WHERE Id = @id";
            var rowsAffected = await connection.ExecuteAsync(sql, new { id, roastType.RoastName });
            return rowsAffected == 0 ? Results.NotFound() : Results.NoContent();
        });

        // DELETE RoastType API Route
        app.MapDelete("/roastType/{id}", async (int id, MySqlConnection connection) =>
        {
            var sql = "DELETE FROM RoastType WHERE Id = @id";
            var rowsAffected = await connection.ExecuteAsync(sql, new { id });
            return rowsAffected == 0 ? Results.NotFound() : Results.NoContent();
        });
        #endregion

        return app;
    }
}