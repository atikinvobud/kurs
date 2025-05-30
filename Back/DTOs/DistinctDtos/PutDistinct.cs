namespace Back.Dtos;

public record PutDistinctDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}