namespace MyAPI.DTOs;

public record class updateCourseDto(
    string falcuty,
    string courseCode,
    string courseDescription,
    int credits,
    string instructor
);
