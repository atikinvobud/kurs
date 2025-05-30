namespace Back.Dtos;

public record RegistrationOfficeDTO
{
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }
    public string Address { get; set; } = null!;
}