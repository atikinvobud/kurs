namespace Back.Models;

public record MedicineEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Dose { get; set; }
    public required string RulesOfTaking { get; set; }
    public List<ReceptionMedicineEntity> receptionMedicineEntities { get; set; } = new List<ReceptionMedicineEntity>();
}