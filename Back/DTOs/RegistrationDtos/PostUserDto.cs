namespace Back.Dtos;

public record PostUserDTO
{
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateOnly DateOfBirth{ get; set; }
}