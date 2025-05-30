namespace Back.Models;

public record ScheduleEntity
{
    public int Id { get; set; }
    public required int DoctorId { get; set; }
    public  int? AppointmentId { get; set; }
    public required int PolyclinicId { get; set; }
    public required TimeSpan StartTime { get; set; }
    public required DateOnly Date { get; set; }

    public DoctorEntity? doctorEntity { get; set; }
    public AppointmentEntity? appointmentEntity { get; set; } 
    public PolyclinicEntity? polyclinicEntity { get; set; }
}