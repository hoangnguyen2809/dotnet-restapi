using MyAPI.Data;
using MyAPI.Entities;
using MyAPI.Mapping;

namespace MyAPI.DTOs;

public static class CoursesEndpoints
{
    const string getCourseRouteName = "getCourse";

    private static readonly List<CourseSummaryDto> courses =
    [
        new(1, "Science", "MATH101", "Introduction to Mathematics", 3, "John Doe"),
        new(2, "Science", "SCI101", "Introduction to Science", 3, "Jane Doe"),
        new(3, "Art and Social Science", "HIST101", "Introduction to History", 3, "John Smith"),
        new(4, "Art and Social Science", "ENG101", "Introduction to English", 3, "Jane Smith")
    ];

    public static RouteGroupBuilder MapCoursesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("courses").WithParameterValidation();

        group.MapGet("/", () => courses);

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
            (int id) =>
            {
                courses.RemoveAll(course => course.id == id);

                return Results.NoContent();
            }
        );

        return group;
    }
}
