namespace Back.Dtos;

public record PostPatientDTO
{
    public int UserId { get; set; }
    public string FIO { get; set; } = null!;
}