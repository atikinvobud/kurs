namespace Back.Dtos;

public record PutScheduleDTO
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public int? AppointmentId { get; set; }
    public int PolyclinicId { get; set; }
    public TimeSpan StartTime { get; set; }
    public DateOnly Date { get; set; }
}