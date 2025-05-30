namespace Back.Dtos;

public record DoctorRegistrationDTO
{
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }
    public int SpecializationId { get; set; }
    public int TimeOfTaking { get; set; }
    public string FIO { get; set; } = null!;
}