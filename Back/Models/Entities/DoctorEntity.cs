namespace Back.Models;

public record DoctorEntity
{
    public int Id { get; set; }
    public required int UserId { get; set; }
    public required int SpecializationId { get; set; }
    public required int TimeOfTaking { get; set; }
    public required string FIO { get; set; }

    public List<ScheduleEntity> scheduleEntities { get; set; } = new List<ScheduleEntity>();
    public List<DoctorPolyclinicEntity> doctorPolyclinics { get; set; } = new List<DoctorPolyclinicEntity>();
    public UserEntity? userEntity { get; set; }
    public SpecializationEntity? specializationEntity { get; set; }
    public List<SickLeaveEntity> sickLeaveEntities { get; set; } = new List<SickLeaveEntity>();


}