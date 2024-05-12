using Microsoft.EntityFrameworkCore;

namespace MyAPI.Data;

public static class DataExtensions
{
    public static void MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<Context>();
        context.Database.Migrate();
    }
}
