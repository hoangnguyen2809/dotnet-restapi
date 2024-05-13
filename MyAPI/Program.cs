using MyAPI.Data;
using MyAPI.DTOs;
using MyAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MyAPI");
builder.Services.AddSqlite<Context>(connectionString);

var app = builder.Build();

app.MapCoursesEndpoints();
app.MapFacultiesEndpoints();

await app.MigrateDatabaseAsync();

app.Run();
