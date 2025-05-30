namespace Back.Models;

public record ExaminationEntity
{
    public int Id { get; set; }
    public required int ReceptionId { get; set; }
    public required int SpecializationId { get; set; }
    public ReceptionEntity? receptionEntity { get; set; }
    public SpecializationEntity? specializationEntity { get; set; }
}