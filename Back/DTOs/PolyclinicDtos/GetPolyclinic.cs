namespace Back.DTOs;

public record GetPolyclinicDTO
{
    public int Id { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int RegistrationOfficeId { get; set; }
    public int DistinctId { get; set; }
}