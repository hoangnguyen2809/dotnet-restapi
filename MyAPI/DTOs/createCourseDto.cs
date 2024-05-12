using System.ComponentModel.DataAnnotations;

namespace MyAPI.DTOs;

public record class createCourseDto(
    [Required] [StringLength(30)] string falcuty,
    [Required] [StringLength(10)] string courseCode,
    [Required] [StringLength(30)] string courseDescription,
    [Range(0, 5)] int credits,
    [Required] [StringLength(20)] string instructor
);
