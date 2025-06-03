namespace Back.Dtos;

public record GetAppInfoDTO
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public string DoctorFIO { get; set; } = null!;
    public string Diagnos { get; set; } = null!;
    public string Description { get; set; } = null!;
}