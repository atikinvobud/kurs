namespace Back.Models;

public record MedicalCardEntity
{
    public int Id { get; set; }
    public required DateOnly DateOfStart { get; set; }
    public required DateOnly DateOfEnd { get; set; }
    public required int PassportNumber { get; set; }
    public required int PassportSeria { get; set; }
    public required string Snils { get; set; }
    public required string OMSPolicy { get; set; }
    public required int PolyclinicId { get; set; }
    public required int PatientId { get; set; }

    public PolyclinicEntity? polyclinicEntity { get; set; }
    public PatientEntity? patientEntity { get; set; }
    public List<SickLeaveEntity> sickLeaveEntities { get; set; } = new List<SickLeaveEntity>();
    public List<ReceptionEntity> receptionEntities { get; set; } = new List<ReceptionEntity>();
    public List<AppointmentEntity> appointmentEntities{ get; set; } = new List<AppointmentEntity>();
}