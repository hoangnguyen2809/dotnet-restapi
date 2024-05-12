﻿namespace MyAPI.DTOs;

public static class CoursesEndpoints
{
    const string getCourseRouteName = "getCourse";

    private static readonly List<CourseDto> courses =
    [
        new(1, "Science", "MATH101", "Introduction to Mathematics", 3, "John Doe"),
        new(2, "Science", "SCI101", "Introduction to Science", 3, "Jane Doe"),
        new(3, "Arts and Social Sciences", "HIST101", "Introduction to History", 3, "John Smith"),
        new(4, "Arts and Social Sciences", "ENG101", "Introduction to English", 3, "Jane Smith")
    ];

    public static RouteGroupBuilder MapCoursesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("courses");

        group.MapGet("/", () => courses);

        group
            .MapGet(
                "/{id}",
                (int id) =>
                {
                    CourseDto? course = courses.Find(course => course.id == id);
                    if (course == null)
                    {
                        return Results.NotFound();
                    }

                    return Results.Ok(course);
                }
            )
            .WithName(getCourseRouteName);

        group.MapPost(
            "/",
            (createCourseDto newCourse) =>
            {
                CourseDto course =
                    new(
                        courses.Count + 1,
                        newCourse.falcuty,
                        newCourse.courseCode,
                        newCourse.courseDescription,
                        newCourse.credits,
                        newCourse.instructor
                    );
                courses.Add(course);

                return Results.CreatedAtRoute(getCourseRouteName, new { id = course.id }, course);
            }
        );

        group.MapPut(
            "/{id}",
            (int id, CourseDto updatedCourse) =>
            {
                int index = courses.FindIndex(x => x.id == id);
                if (index == -1)
                {
                    return Results.NotFound();
                }

                courses[index] = new CourseDto(
                    id,
                    updatedCourse.falcuty,
                    updatedCourse.courseCode,
                    updatedCourse.courseDescription,
                    updatedCourse.credits,
                    updatedCourse.instructor
                );

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