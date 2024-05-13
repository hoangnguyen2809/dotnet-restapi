namespace MyAPI.DTOs;

public record class CourseDetailsDto(
    int id,
    int facultyId,
    string courseCode,
    string? courseDescription,
    int credits,
    string? instructor
);
