using Microsoft.EntityFrameworkCore;

namespace MyAPI.Data;

public static class DataExtensions
{
    public static async Task MigrateDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<Context>();
        await context.Database.MigrateAsync();
    }
}
