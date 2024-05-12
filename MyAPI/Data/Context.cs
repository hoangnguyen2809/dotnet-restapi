using Microsoft.EntityFrameworkCore;
using MyAPI.Entities;

namespace MyAPI.Data;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Department> Departments => Set<Department>();
}
