namespace Back.Dtos;

public record GetSickLeaveDTO
{
    public int Id { get; set; }
    public int MedicalCardId { get; set; }
    public int AmountOfPayments { get; set; }
    public int Length { get; set; }
    public DateOnly StartDate { get; set; }
    public string Diagnos { get; set; } = null!;
    public int DoctorId { get; set; }
}