namespace MyAPI.DTOs;

public record class CourseSummaryDto(
    int id,
    string faculty,
    string courseCode,
    string? courseDescription,
    int credits,
    string? instructor
);
