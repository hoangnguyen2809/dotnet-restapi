namespace MyAPI.DTOS;

public record class CourseDto(
    int id,
    string courseName,
    string courseCode,
    string courseDescription,
    int credits,
    string instructor
);
