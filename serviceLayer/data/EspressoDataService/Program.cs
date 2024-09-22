using System.ComponentModel.DataAnnotations;
using MySqlConnector;
using Dapper;

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

app.MapGet("/", () => "Hello Espressoooooooooo!!!!");

app.Run();
