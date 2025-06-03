using System.Reflection.Metadata.Ecma335;
using Back.Dtos;
using Back.DTOs;
using Back.Extensions;
using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Services;

public class MedicineService : IMedicineService
{
    private readonly Context context;
    public MedicineService(Context context)
    {
        this.context = context;
    }
    public async Task<List<GetMedicineDTO>> GetAll(int userId)
    {
        List<int> ids = await context.MedicalCards.Include(mc => mc.patientEntity).Where(mc => mc.patientEntity!.UserId == userId)
        .Select(mc => mc.Id).ToListAsync();
       List<GetMedicineDTO> list = await context.Receptions.Where(mc => ids.Contains(mc.MedicalCardId))
        .Include(r => r.receptionMedicineEntities).ThenInclude(rm => rm.medicineEntity)
        .SelectMany(r => r.receptionMedicineEntities.Select(rm => new GetMedicineDTO
        {
            Id = rm.Id,
            StartDate = r.DateOfAppointment,
            Lehgth = r.length,
            Name = rm.medicineEntity!.Name,
            Dose = rm.medicineEntity!.Dose,
            RulesOfTaking =rm.medicineEntity!.RulesOfTaking
        })).ToListAsync();
        return list;
    }

    public async Task<int> Create(PostMedicineDTO postMedicineDTO)
    {
        MedicineEntity entity = postMedicineDTO.ToEntity();
        await context.Medicines.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }
    public async Task<bool> Update(PutMedicineDTO putMedicineDTO)
    {
        MedicineEntity? entity = await context.Medicines.FindAsync(putMedicineDTO.Id);
        if (entity == null) return false;
        entity.Update(putMedicineDTO);
        await context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> Delete(DeleteMedicineDTO deleteMedicineDTO)
    {
        MedicineEntity? entity = await context.Medicines.FindAsync(deleteMedicineDTO.Id);
        if (entity == null) return false;
        context.Medicines.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
}