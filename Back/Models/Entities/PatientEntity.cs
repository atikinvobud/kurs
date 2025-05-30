using System.Data;

namespace Back.Models;

public record PatientEntity
{
    public int Id { get; set; }
    public required int UserId { get; set; }
    public required string FIO { get; set; }

    public UserEntity? userEntity { get; set; }
    public List<MedicalCardEntity> medicalCardEntities{ get; set; } =new List<MedicalCardEntity>();
}