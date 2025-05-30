namespace Back.Dtos;

public record GetSpecializationDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}