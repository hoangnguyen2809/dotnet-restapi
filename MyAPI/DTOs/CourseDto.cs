namespace MyAPI.DTOs;

public record class CourseDto(
    int id,
    string department,
    string courseCode,
    string courseDescription,
    int credits,
    string instructor
);
