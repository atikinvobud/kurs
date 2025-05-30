namespace Back.Dtos;

public record PostConclusionDTO
{
    public string Diagnos { get; set; } = null!;
    public string Description { get; set; } = null!;
}