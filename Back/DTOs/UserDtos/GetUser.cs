namespace Back.Dtos;

public record GetUserDTO
{
    public int Id { get; set; }
    public string Fio { get; set; } = null!;
    public DateOnly DateofBirth {get; set; }
}