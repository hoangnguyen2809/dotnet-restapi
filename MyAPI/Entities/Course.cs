namespace MyAPI.Entities;

public class Course
{
    public int id { get; set; }
    public required string courseCode { get; set; }
    public int facultyId { get; set; }
    public Faculty? faculty { get; set; }

    public string? courseDescription { get; set; }
    public int credits { get; set; }

    public string? instructor { get; set; }
}
