using Dapper;
using MySqlConnector;
using EspressoDataService.Dto;

namespace EspressoDataService.Api;

public static class RoastTypeApi
{
    public static WebApplication MapRoastTypeApiEndpoints(this WebApplication app)
    {
        #region Api Routes - RoastType
        // CREATE RoastType API Route
        app.MapPost("/roastType", async (string roastTypeName, MySqlConnection connection) =>
        {
            var sql = @$"
                INSERT INTO RoastTypeLookup (Name) 
                VALUES (""{roastTypeName}"");
                SELECT LAST_INSERT_ID();";
            var id = await connection.ExecuteScalarAsync<int>(sql);
            return Results.Created($"/roastType/{id}", id);
        })
        .Produces<int>(StatusCodes.Status201Created);

        // READ All RoastType API Route
        app.MapGet("/roastType", async (MySqlConnection connection) =>
        {
            var sql = "SELECT * FROM RoastTypeLookup";
            var enumerable = await connection.QueryAsync<RoastTypeLookupDto>(sql);
            return Results.Ok(enumerable);
        })
        .Produces<IEnumerable<RoastTypeLookupDto>>(StatusCodes.Status200OK);

        // READ One RoastType API Route
        app.MapGet("/roastType/{id}", async (int id, MySqlConnection connection) =>
        {
            var sql = "SELECT * FROM RoastTypeLookup WHERE Id = @id";
            var item = await connection.QueryFirstOrDefaultAsync<RoastTypeLookupDto>(sql, new { id });
            return item is null ? Results.NotFound() : Results.Ok(item);
        });

        // UPDATE RoastType API Route
        app.MapPut("/roastType/{id}", async (int id, string roastTypeName, MySqlConnection connection) =>
        {
            var sql = @$"
                UPDATE RoastTypeLookup 
                SET Name = (""{roastTypeName}"")
                WHERE Id = @id";
            var rowsAffected = await connection.ExecuteAsync(sql, new { id, roastTypeName });
            return rowsAffected == 0 ? Results.NotFound() : Results.NoContent();
        });

        // DELETE RoastType API Route
        app.MapDelete("/roastType/{id}", async (int id, MySqlConnection connection) =>
        {
            var sql = "DELETE FROM RoastTypeLookup WHERE Id = @id";
            var rowsAffected = await connection.ExecuteAsync(sql, new { id });
            return rowsAffected == 0 ? Results.NotFound() : Results.NoContent();
        });
        #endregion

        return app;
    }
}