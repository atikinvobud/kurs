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
    public async Task<List<GetMedicineDTO>> GetAll()
    {
        List<MedicineEntity> entities = await context.Medicines.ToListAsync();
        List<GetMedicineDTO> result = new List<GetMedicineDTO>();
        foreach (var entity in entities)
        {
            result.Add(entity.ToDTO());
        }
        return result;
    }
    public async Task<GetMedicineDTO> GetById(int id)
    {
        MedicineEntity? entity = await context.Medicines.FindAsync(id);
        if (entity == null) return null!;
        return entity.ToDTO();
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