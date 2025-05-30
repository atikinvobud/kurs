using System.Data;

namespace Back.DTOs;

public record PutChangePolyclinicDTO
{
    public int Id { get; set; }
    public int RegistrationOfficeId { get; set; }
}