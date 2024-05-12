using Microsoft.EntityFrameworkCore;
using MyAPI.Entities;

namespace MyAPI.Data;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Falcuty> Departments => Set<Falcuty>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Falcuty>()
            .HasData(
                new { id = 1, name = "Applied Sciences" },
                new { id = 2, name = "Arts and Social Sciences" },
                new { id = 3, name = "Education" },
                new { id = 4, name = "Business" },
                new { id = 5, name = "Communication, Art and Technology" },
                new { id = 6, name = "Environment" },
                new { id = 7, name = "Health Sciences" },
                new { id = 8, name = "Science" }
            );
    }
}
