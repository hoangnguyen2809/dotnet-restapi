using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.Mapping;

namespace MyAPI.Endpoints;

public static class FacultyEndpoints
{
    public static RouteGroupBuilder MapFacultiesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("faculties").WithParameterValidation();

        group.MapGet(
            "/",
            async (Context dbContext) =>
                await dbContext
                    .Faculties.Select(faculty => faculty.ToDto())
                    .AsNoTracking()
                    .ToListAsync()
        );

        return group;
    }
}
