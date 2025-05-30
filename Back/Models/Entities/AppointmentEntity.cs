namespace Back.Models;

public record AppointmentEntity
{
    public int Id { get; set; }
    public required int Cabinet { get; set; }
    public required string Status { get; set; }
    public int? ConclusionId { get; set; }
    public required int MedicalCardId { get; set; }

    public ConclusionEntity? conclusionEntity { get; set; }
    public MedicalCardEntity? medicalCardEntity { get; set; }
    public ScheduleEntity? scheduleEntity { get; set; }
}