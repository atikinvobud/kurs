using Back.Models;

namespace Back.Dtos;

public static class MedicineExtensions
{


    public static MedicineEntity ToEntity(this PostMedicineDTO postMedicineDTO)
    {
        return new()
        {
            Name = postMedicineDTO.Name,
            Dose = postMedicineDTO.Dose,
            RulesOfTaking = postMedicineDTO.RulesOfTaking
        };
    }

    public static void Update(this MedicineEntity medicineEntity, PutMedicineDTO putMedicineDTO)
    {
        medicineEntity.Name = putMedicineDTO.Name;
        medicineEntity.Dose = putMedicineDTO.Dose;
        medicineEntity.RulesOfTaking = putMedicineDTO.RulesOfTaking;
    } 
}