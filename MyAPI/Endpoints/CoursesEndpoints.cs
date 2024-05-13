using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.Entities;
using MyAPI.Mapping;

namespace MyAPI.DTOs;

public static class CoursesEndpoints
{
    const string getCourseRouteName = "getCourse";

    public static RouteGroupBuilder MapCoursesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("courses").WithParameterValidation();

        group.MapGet(
            "/",
            async (Context dbContext) =>
                await dbContext
                    .Courses.Include(course => course.faculty)
                    .Select(course => course.ToSummaryDto())
                    .AsNoTracking()
                    .ToListAsync()
        );

        group
            .MapGet(
                "/{id}",
                async (int id, Context dbContext) =>
                {
                    Course? course = await dbContext.Courses.FindAsync(id);
                    if (course == null)
                    {
                        return Results.NotFound();
                    }

                    return Results.Ok(course.ToDetailsDto());
                }
            )
            .WithName(getCourseRouteName);

        group.MapPost(
            "/",
            async (createCourseDto newCourse, Context dbContext) =>
            {
                Course course = newCourse.ToEntity();

                dbContext.Courses.Add(course);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute(
                    getCourseRouteName,
                    new { id = course.id },
                    course.ToDetailsDto()
                );
            }
        );

        group.MapPut(
            "/{id}",
            async (int id, updateCourseDto updatedCourse, Context dbContext) =>
            {
                var existingCourse = await dbContext.Courses.FindAsync(id);
                if (existingCourse is null)
                {
                    return Results.NotFound();
                }

                dbContext.Entry(existingCourse).CurrentValues.SetValues(updatedCourse.ToEntity(id));
                await dbContext.SaveChangesAsync();
                return Results.NoContent();
            }
        );

        group.MapDelete(
            "/{id}",
            async (int id, Context dbContext) =>
            {
                await dbContext.Courses.Where(course => course.id == id).ExecuteDeleteAsync();

                return Results.NoContent();
            }
        );

        return group;
    }
}
