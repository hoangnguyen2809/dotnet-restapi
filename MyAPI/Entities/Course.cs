namespace MyAPI.Entities;

public class Course
{
    public int id { get; set; }
    public required string courseCode { get; set; }
    public int falcutyId { get; set; }
    public required Falcuty falcuty { get; set; }

    public string? courseDescription { get; set; }
    public int credits { get; set; }

    public int instructor { get; set; }
}
