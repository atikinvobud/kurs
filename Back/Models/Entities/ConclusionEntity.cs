namespace Back.Models;

public record ConclusionEntity
{
    public int Id { get; set; }
    public required string Diagnos { get; set; }
    public required string Description { get; set; }

    public AppointmentEntity? appointmentEntity { get; set; }
}