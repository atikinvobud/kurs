namespace Back.Dtos;

public record PutSpecializationDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}