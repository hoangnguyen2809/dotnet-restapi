namespace MyAPI.Mapping;

using Microsoft.OpenApi.Writers;
using MyAPI.DTOs;
using MyAPI.Entities;

public static class CourseMapping
{
    public static Course ToEntity(this createCourseDto course)
    {
        return new Course()
        {
            facultyId = course.facultyId,
            courseCode = course.courseCode,
            courseDescription = course.courseDescription,
            credits = course.credits,
            instructor = course.instructor
        };
    }

    public static Course ToEntity(this updateCourseDto course, int id)
    {
        return new Course()
        {
            id = id,
            facultyId = course.facultyId,
            courseCode = course.courseCode,
            courseDescription = course.courseDescription,
            credits = course.credits,
            instructor = course.instructor
        };
    }

    public static CourseSummaryDto ToSummaryDto(this Course course)
    {
        return new(
            course.id,
            course.faculty!.name,
            course.courseCode,
            course.courseDescription,
            course.credits,
            course.instructor
        );
    }

    public static CourseDetailsDto ToDetailsDto(this Course course)
    {
        return new(
            course.id,
            course.facultyId,
            course.courseCode,
            course.courseDescription,
            course.credits,
            course.instructor
        );
    }
}
