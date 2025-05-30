namespace Back.Models;

public record SpecializationEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public List<DoctorEntity> doctorEntities { get; set; } = new List<DoctorEntity>();
    public List<ExaminationEntity> examinationEntities { get; set;} = new List<ExaminationEntity>();
}