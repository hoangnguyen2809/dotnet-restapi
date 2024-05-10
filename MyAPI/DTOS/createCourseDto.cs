namespace MyAPI.DTOS;

public record class createCourseDto(
    string courseName,
    string courseCode,
    string courseDescription,
    int credits,
    string instructor
);
