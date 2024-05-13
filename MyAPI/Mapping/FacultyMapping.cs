using MyAPI.DTOs;
using MyAPI.Entities;

namespace MyAPI.Mapping;

public static class FacultyMapping
{
    public static FacultyDto ToDto(this Faculty faculty)
    {
        return new FacultyDto(faculty.id, faculty.name);
    }
}
