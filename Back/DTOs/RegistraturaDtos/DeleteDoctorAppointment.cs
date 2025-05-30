namespace Back.DTOs;

public record DeleteDoctorsAppointmentDTO
{
    public int DoctorId { get; set; }
    public DateOnly Day { get; set; }
    public string Reason { get; set; } = null!;
}