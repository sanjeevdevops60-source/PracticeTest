//using DotnetApiPostgres.Api;
//using DotnetApiPostgres.Api.Extensions;
//using DotnetApiPostgres.Api.Services;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();

//string connectionString = builder.Configuration.GetConnectionString("default");
//builder.Services.AddDbContext<ApplicationDbContext>(op => op.UseNpgsql(connectionString));

//builder.Services.AddTransient<IPersonService, PersonService>();

//var app = builder.Build();
//app.MapControllers();

//app.MapGet("/", () =>
//{
//    return Results.Ok("Hello...");
//}
//);

//// seeding the database
//await app.InitializedAsync();

//app.Run();






using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("default");

// 🔹 Optional: test connection at startup
using (var conn = new NpgsqlConnection(connectionString))
{
    conn.Open();
    Console.WriteLine("PostgreSQL connected successfully");
}

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
