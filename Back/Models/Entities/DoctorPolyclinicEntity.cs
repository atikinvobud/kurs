namespace Back.Models;

public record DoctorPolyclinicEntity
{
    public int Id { get; set; }
    public required int PolyclinicId { get; set; }
    public required int DoctorId { get; set; }
    public required List<int> WorkingDays { get; set; }

    public PolyclinicEntity? polyclinicEntity { get; set; }
    public DoctorEntity? doctorEntity { get; set; }
}