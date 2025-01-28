using Dapper;
using EspressoDataService.Dto;
using MySqlConnector;

namespace EspressoDataService.Api;

public class MyClass1 : IMyInterface
{
    public void MyMethod()
    {
        Console.WriteLine("Hello from MyClass1");
    }
};
public class MyClass2 : IMyInterface
{
    public void MyMethod()
    {
        Console.WriteLine("Hello from MyClass2");
    }
};
public interface IMyInterface
{
    public void MyMethod();
}

public static class EspressoBeanApi
{
    public static WebApplication MapEspressoBeanApiEndpoints(this WebApplication app)
    {
        // CREATE
        app.MapPost("/espressobean", async (EspressoBeanDtoBase espressoBean, MySqlConnection connection) =>
        {
            var sql = @"
                INSERT INTO EspressoBean (Name, RoastDate, PurchasedDate, PurchasedFrom, RoastTypeId) 
                VALUES (@Name, @RoastDate, @PurchasedDate, @PurchasedFrom, @RoastTypeId);
                SELECT LAST_INSERT_ID();";
            var id = await connection.ExecuteScalarAsync<int>(sql, espressoBean);
            return Results.Created($"/espressobean/{id}", id);
        })
        .Produces<int>(StatusCodes.Status201Created);

        // READ
        app.MapGet("/espressobean", async (MySqlConnection connection, IMyInterface myClass) =>
        {
            // IMyInterface myClass = new MyClass2();
            myClass.MyMethod();

            var sql = @"SELECT 
                            eb.Id,
                            eb.Name,
                            eb.RoastDate,
                            eb.PurchasedDate,
                            eb.PurchasedFrom,
                            eb.RoastTypeId,
                            rt.Name AS RoastTypeName
                        FROM 
                            EspressoBean eb
                        JOIN 
                            RoastTypeLookup rt ON eb.RoastTypeId = rt.Id";
            var enumerable = await connection.QueryAsync<EspressoBeanResponseDto>(sql);
            return Results.Ok(enumerable);
        })
        .Produces<IEnumerable<EspressoBeanResponseDto>>(StatusCodes.Status200OK);

        // READ by ID
        app.MapGet("/espressobean/{id}", async (int id, MySqlConnection connection) =>
        {
            var sql = @"SELECT 
                            eb.Id,
                            eb.Name,
                            eb.RoastDate,
                            eb.PurchasedDate,
                            eb.PurchasedFrom,
                            eb.RoastTypeId,
                            rt.Name AS RoastTypeName
                        FROM 
                            EspressoBean eb
                        JOIN 
                            RoastTypeLookup rt ON eb.RoastTypeId = rt.Id
                        WHERE eb.Id = @id";
            var item = await connection.QueryFirstOrDefaultAsync<EspressoBeanResponseDto>(sql, new { id });
            return item is null ? Results.NotFound() : Results.Ok(item);
        });

        // UPDATE
        app.MapPut("/espressobean/{id}", async (int id, EspressoBeanDtoBase espressoBean, MySqlConnection connection) =>
        {
            var sql = @"
                UPDATE EspressoBean
                SET Name = @Name, 
                    RoastDate = @RoastDate, 
                    PurchasedDate = @PurchasedDate, 
                    PurchasedFrom = @PurchasedFrom, 
                    RoastTypeId = @RoastTypeId
                WHERE Id = @id";
            var rowsAffected = await connection.ExecuteAsync(sql,
                new
                {
                    id,
                    espressoBean.Name,
                    espressoBean.RoastDate,
                    espressoBean.PurchasedDate,
                    espressoBean.PurchasedFrom,
                    espressoBean.RoastTypeId
                });
            return rowsAffected == 0 ? Results.NotFound() : Results.NoContent();
        });

        // DELETE
        app.MapDelete("/espressobean/{id}", async (int id, MySqlConnection connection) =>
        {
            var sql = "DELETE FROM EspressoBean WHERE Id = @id";
            var rowsAffected = await connection.ExecuteAsync(sql, new { id });
            return rowsAffected == 0 ? Results.NotFound() : Results.NoContent();
        });

        return app;
    }
}
