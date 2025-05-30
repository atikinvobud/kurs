using System.Reflection.Metadata.Ecma335;
using Back.Dtos;
using Back.DTOs;
using Back.Extensions;
using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Services;

public class MedicalCardService : IMedicalCardService
{
    private readonly Context context;
    public MedicalCardService(Context context)
    {
        this.context = context;
    }
    public async Task<List<GetMedicalCardDTO>> GetAll()
    {
        List<MedicalCardEntity> entities = await context.MedicalCards.ToListAsync();
        List<GetMedicalCardDTO> result = new List<GetMedicalCardDTO>();
        foreach (var entity in entities)
        {
            result.Add(entity.ToDTO());
        }
        return result;
    }
    public async Task<GetMedicalCardDTO> GetById(int id)
    {
        MedicalCardEntity? entity = await context.MedicalCards.FindAsync(id);
        if (entity == null) return null!;
        return entity.ToDTO();
    }
    public async Task<int> Create(PostMedicalCardDTO postMedicalCardDTO)
    {
        MedicalCardEntity entity = postMedicalCardDTO.ToEntity();
        await context.MedicalCards.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }
    public async Task<bool> Update(PutMedicalCardDTO putMedicalCardDTO)
    {
        MedicalCardEntity? entity = await context.MedicalCards.FindAsync(putMedicalCardDTO.Id);
        if (entity == null) return false;
        entity.Update(putMedicalCardDTO);
        await context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> Delete(DeleteMedicalCardDTO deleteMedicalCardDTO)
    {
        MedicalCardEntity? entity = await context.MedicalCards.FindAsync(deleteMedicalCardDTO.Id);
        if (entity == null) return false;
        context.MedicalCards.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
}