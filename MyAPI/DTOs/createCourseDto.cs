using System.ComponentModel.DataAnnotations;

namespace MyAPI.DTOs;

public record class createCourseDto(
    int facultyId,
    [Required] [StringLength(10)] string courseCode,
    [Required] [StringLength(30)] string courseDescription,
    [Range(0, 5)] int credits,
    [Required] [StringLength(20)] string instructor
);
