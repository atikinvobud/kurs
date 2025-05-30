namespace Back.Dtos;

public class PutMedicalCardDTO
{
    public int Id { get; set; }
    public DateOnly DateOfStart { get; set; }
    public DateOnly DateOfEnd { get; set; }
    public int PassportNumber { get; set; }
    public int PassportSeria { get; set; }
    public string OMSPolicy { get; set; } = null!;
    public int PolyclinicId { get; set; }
    public int PatientId { get; set; }
}