namespace MyAPI.Entities;

public class Course
{
    public int id { get; set; }
    public required string courseCode { get; set; }
    public int departmentId { get; set; }
    public required Department department { get; set; }

    public string? courseDescription { get; set; }
    public int credits { get; set; }

    public int instructor { get; set; }
}
