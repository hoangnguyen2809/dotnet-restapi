using MyAPI.Data;
using MyAPI.DTOs;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MyAPI");
builder.Services.AddSqlite<Context>(connectionString);

var app = builder.Build();

app.MapCoursesEndpoints();

await app.MigrateDatabaseAsync();

app.Run();
