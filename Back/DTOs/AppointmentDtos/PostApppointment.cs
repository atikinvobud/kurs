namespace Back.Dtos;

public record PostAppointmentDTO
{
    public int Cabinet { get; set; }
    public string Status { get; set; } = null!;
    public int? ConclusionId { get; set; }
    public int MedicalCardId { get; set; }

}