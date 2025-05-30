using System.Reflection.Metadata.Ecma335;
using Back.Dtos;
using Back.DTOs;
using Back.Extensions;
using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Services;

public class SpecializationService : ISpecializationService
{
    private readonly Context context;
    public SpecializationService(Context context)
    {
        this.context = context;
    }
    public async Task<List<GetSpecializationDTO>> GetAll()
    {
        List<SpecializationEntity> entities = await context.Specializations.ToListAsync();
        List<GetSpecializationDTO> result = new List<GetSpecializationDTO>();
        foreach (var entity in entities)
        {
            result.Add(entity.ToDTO());
        }
        return result;
    }
    public async Task<int> Create(PostSpecaializationDTO postSpecaializationDTO)
    {
        SpecializationEntity entity = postSpecaializationDTO.ToEntity();
        await context.Specializations.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }
    public async Task<bool> Update(PutSpecializationDTO putSpecializationDTO)
    {
        SpecializationEntity? entity = await context.Specializations.FindAsync(putSpecializationDTO.Id);
        if (entity == null) return false;
        entity.Update(putSpecializationDTO);
        await context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> Delete(DeleteSpecializationDTO deleteSpecializationDTO)
    {
        SpecializationEntity? entity = await context.Specializations.FindAsync(deleteSpecializationDTO.Id);
        if (entity == null) return false;
        context.Specializations.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
}