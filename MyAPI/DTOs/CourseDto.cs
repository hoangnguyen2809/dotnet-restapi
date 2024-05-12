namespace MyAPI.DTOs;

public record class CourseDto(
    int id,
    string falcuty,
    string courseCode,
    string courseDescription,
    int credits,
    string instructor
);
