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
            (Context dbContext) =>
                dbContext
                    .Courses.Include(course => course.faculty)
                    .Select(course => course.ToSummaryDto())
                    .AsNoTracking()
        );

        group
            .MapGet(
                "/{id}",
                (int id, Context dbContext) =>
                {
                    Course? course = dbContext.Courses.Find(id);
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
            (createCourseDto newCourse, Context dbContext) =>
            {
                Course course = newCourse.ToEntity();

                dbContext.Courses.Add(course);
                dbContext.SaveChanges();

                return Results.CreatedAtRoute(
                    getCourseRouteName,
                    new { id = course.id },
                    course.ToDetailsDto()
                );
            }
        );

        group.MapPut(
            "/{id}",
            (int id, updateCourseDto updatedCourse, Context dbContext) =>
            {
                var existingCourse = dbContext.Courses.Find(id);
                if (existingCourse is null)
                {
                    return Results.NotFound();
                }

                dbContext.Entry(existingCourse).CurrentValues.SetValues(updatedCourse.ToEntity(id));
                dbContext.SaveChanges();
                return Results.NoContent();
            }
        );

        group.MapDelete(
            "/{id}",
            (int id, Context dbContext) =>
            {
                dbContext.Courses.Where(course => course.id == id).ExecuteDelete();

                return Results.NoContent();
            }
        );

        return group;
    }
}
