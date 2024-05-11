using MyAPI.DTOS;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string getCourseRouteName = "getCourse";

List<CourseDto> courses =
[
    new(1, "Math", "MATH101", "Introduction to Mathematics", 3, "John Doe"),
    new(2, "Science", "SCI101", "Introduction to Science", 3, "Jane Doe"),
    new(3, "History", "HIST101", "Introduction to History", 3, "John Smith"),
    new(4, "English", "ENG101", "Introduction to English", 3, "Jane Smith")
];

app.MapGet("courses", () => courses);

app.MapGet("courses/{id}", (int id) => courses.Find(x => x.id == id)).WithName(getCourseRouteName);

app.MapPost(
    "courses",
    (createCourseDto newCourse) =>
    {
        CourseDto course =
            new(
                courses.Count + 1,
                newCourse.courseName,
                newCourse.courseCode,
                newCourse.courseDescription,
                newCourse.credits,
                newCourse.instructor
            );
        courses.Add(course);

        return Results.CreatedAtRoute(getCourseRouteName, new { id = course.id }, course);
    }
);

app.MapDelete(
    "courses/{id}",
    (int id) =>
    {
        CourseDto course = courses.Find(x => x.id == id);
        if (course is null)
        {
            return Results.NotFound();
        }

        courses.Remove(course);
        return Results.NoContent();
    }
);

app.Run();
