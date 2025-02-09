using System;
using Dapper;
using EspressoDataService.Dto;
using MySqlConnector;

namespace EspressoDataService.Api;

public static class JournalEntryApi
{
    public static WebApplication MapJournalEntryApiEndpoints(this WebApplication app)
    {
        // CREATE
        app.MapPost("/journalentry", async (JournalEntryDtoBase journalEntry, MySqlConnection connection) =>
        {
            journalEntry.DateCreate = DateTime.Now;
            var sql = @"
                INSERT INTO JournalEntry (
                    EspressoBeanId, 
                    GrinderId, 
                    GrindSetting, 
                    BeanWeightInGrams, 
                    PreExtractionTimeInSeconds, 
                    ExtractionTimeInSeconds, 
                    EspressoWeightInGrams, 
                    BitternessRank, 
                    AcidityRank, 
                    SourRank, 
                    CremaRank, 
                    SatisfactionRank, 
                    Comments, 
                    DateCreate, 
                    DateUpdate
                )
                VALUES (
                    @EspressoBeanId,
                    @GrinderId,
                    @GrindSetting,
                    @BeanWeightInGrams,
                    @PreExtractionTimeInSeconds,
                    @ExtractionTimeInSeconds,
                    @EspressoWeightInGrams,
                    @BitternessRank,
                    @AcidityRank,
                    @SourRank,
                    @CremaRank,
                    @SatisfactionRank,
                    @Comments,
                    @DateCreate,
                    @DateUpdate
                );
                SELECT LAST_INSERT_ID();";
            var id = await connection.ExecuteScalarAsync<int>(sql, journalEntry);
            return Results.Created($"/journalentry/{id}", id);
        })
        .Produces<int>(StatusCodes.Status201Created);

        // READ
        app.MapGet("/journalentry", async (MySqlConnection connection) =>
        {
            var sql = @"SELECT je.*,
                            eb.Name AS EspressoBeanName,
                            g.BrandName AS GrinderBrandName,
                            g.ModelName AS GrinderModelName
                        FROM 
                            JournalEntry je
                        JOIN
                            EspressoBean eb ON je.EspressoBeanId = eb.Id
                        JOIN
                            Grinder g ON je.GrinderId = g.Id";

            var enumerable = await connection.QueryAsync<JournalEntryDto>(sql);
            return Results.Ok(enumerable);
        })
        .Produces<IEnumerable<JournalEntryDto>>(StatusCodes.Status200OK);

        // READ by ID
        app.MapGet("/journalentry/{id}", async (int id, MySqlConnection connection) =>
        {
            var sql = @"SELECT je.*,
                            eb.Name AS EspressoBeanName,
                            g.BrandName AS GrinderBrandName,
                            g.ModelName AS GrinderModelName
                        FROM 
                            JournalEntry je
                        JOIN
                            EspressoBean eb ON je.EspressoBeanId = eb.Id
                        JOIN
                            Grinder g ON je.GrinderId = g.Id
                        WHERE Id = @id";
            var item = await connection.QueryFirstOrDefaultAsync<JournalEntryDto>(sql, new { id });
            return item is null ? Results.NotFound() : Results.Ok(item);
        });

        // UPDATE
        app.MapPut("/journalentry/{id}", async (int id, JournalEntryDtoBase journalEntry, MySqlConnection connection) =>
        {
            journalEntry.DateUpdate = DateTime.Now;
            var sql = @"
                UPDATE JournalEntry
                SET EspressoBeanId = @EspressoBeanId,
                    GrinderId = @GrinderId,
                    GrindSetting = @GrindSetting,
                    BeanWeightInGrams = @BeanWeightInGrams,
                    PreExtractionTimeInSeconds = @PreExtractionTimeInSeconds,
                    ExtractionTimeInSeconds = @ExtractionTimeInSeconds,
                    EspressoWeightInGrams = @EspressoWeightInGrams,
                    BitternessRank = @BitternessRank,
                    AcidityRank = @AcidityRank,
                    SourRank = @SourRank,
                    CremaRank = @CremaRank,
                    SatisfactionRank = @SatisfactionRank,
                    Comments = @Comments,
                    DateUpdate = @DateUpdate
                WHERE Id = @id";

            var x = new
            {
                id,
                journalEntry.EspressoBeanId,
                journalEntry.GrinderId,
                journalEntry.GrindSetting,
                journalEntry.BeanWeightInGrams,
                journalEntry.PreExtractionTimeInSeconds,
                journalEntry.ExtractionTimeInSeconds,
                journalEntry.EspressoWeightInGrams,
                journalEntry.BitternessRank,
                journalEntry.AcidityRank,
                journalEntry.SourRank,
                journalEntry.CremaRank,
                journalEntry.SatisfactionRank,
                journalEntry.Comments,
                journalEntry.DateUpdate
            };
            var rowsAffected = await connection.ExecuteAsync(sql, x);
            return rowsAffected == 0 ? Results.NotFound() : Results.NoContent();
        });

        // DELETE
        app.MapDelete("/journalentry/{id}", async (int id, MySqlConnection connection) =>
        {
            var sql = "DELETE FROM JournalEntry WHERE Id = @id";
            var rowsAffected = await connection.ExecuteAsync(sql, new { id });
            return rowsAffected == 0 ? Results.NotFound() : Results.NoContent();
        });

        return app;
    }
}
