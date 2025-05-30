namespace Back.Dtos;

public record LoginDTO
{
    public string Login { get; set; } = null!;
    public string Password { get; set;} = null!;
}