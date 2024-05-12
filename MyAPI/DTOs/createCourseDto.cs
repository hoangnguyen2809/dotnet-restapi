namespace MyAPI.DTOs;

public record class createCourseDto(
    string falcuty,
    string courseCode,
    string courseDescription,
    int credits,
    string instructor
);
