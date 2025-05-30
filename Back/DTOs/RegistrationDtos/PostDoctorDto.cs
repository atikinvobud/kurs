namespace Back.Dtos;

public record PostDoctorDTO
{
    public int UserId { get; set; }
    public int SpecializationId { get; set; }
    public int TimeOfTaking { get; set; }
    public string FIO { get; set; } = null!;
}