namespace Back.Models;

public record SickLeaveEntity
{
    public int Id { get; set; }
    public required int MedicalCardId { get; set; }
    public required int AmountOfPayments { get; set; }
    public required int Length { get; set; }
    public required DateOnly StartDate { get; set; }
    public required string Diagnos { get; set; }
    public required int DoctorId { get; set; }
    public MedicalCardEntity? medicalCardEntity { get; set; }
    public DoctorEntity? doctorEntity{ get; set; }
}