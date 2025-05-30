namespace Back.DTOs;

public record PatientRegistrationDto
{
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FIO { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }
}