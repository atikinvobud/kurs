namespace Back.Models;

public record ReceptionMedicineEntity
{
    public int Id { get; set; }
    public required int ReceptionId { get; set; }
    public required int MedicineId { get; set; }
    public ReceptionEntity? receptionEntity { get; set; }
    public MedicineEntity? medicineEntity{ get; set; }
}