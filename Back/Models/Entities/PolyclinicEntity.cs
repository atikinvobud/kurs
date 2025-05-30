namespace Back.Models;

public record PolyclinicEntity
{
    public int Id { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
    public required int RegistrationOfficeId { get; set; }
    public required int DistinctId { get; set; }

    public RegistrationOfficeEntity? registrationOffice { get; set; }
    public DistinctEntity? distinctEntity { get; set; }
    public List<MedicalCardEntity> medicalCardEntities { get; set; } = new List<MedicalCardEntity>();
    public List<DoctorPolyclinicEntity> doctorPolyclinicEntities { get; set; } = new List<DoctorPolyclinicEntity>();
    public List<ScheduleEntity> scheduleEntities { get; set; } = new List<ScheduleEntity>();
}