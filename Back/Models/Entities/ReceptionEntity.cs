namespace Back.Models;

public record ReceptionEntity
{
    public int Id { get; set; }
    public required int MedicalCardId { get; set; }
    public required DateTime DateOfAppointment { get; set; }
    public required TimeSpan length { get; set; }

    public MedicalCardEntity? medicalCardEntity { get; set; }
    public List<ExaminationEntity> examinationEntities { get; set; } = new List<ExaminationEntity>();
    public List<ReceptionMedicineEntity> receptionMedicineEntities { get; set; } = new List<ReceptionMedicineEntity>();
}