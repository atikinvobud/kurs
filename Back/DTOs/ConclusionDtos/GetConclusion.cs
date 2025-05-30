namespace Back.Dtos;

public record GetConclusionDTO
{
    public int Id { get; set; }
    public string Diagnos { get; set; } = null!;
    public string Description { get; set; } = null!;
}