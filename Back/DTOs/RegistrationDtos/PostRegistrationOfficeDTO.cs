namespace Back.Dtos;

public record PostRegistrationOfficeDTO
{
    public int UserId { get; set; }
    public string Address { get; set; } = null!;
}