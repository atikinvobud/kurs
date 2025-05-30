using Back.DTOs;
using Back.Models;
using Microsoft.EntityFrameworkCore;
using Back.Extensions;

namespace Back.Services;

public class PolyclinicService : IPolyclinicService
{
    private readonly Context context;
    public PolyclinicService(Context context)
    {
        this.context = context;
    }
    public async Task<List<GetPolyclinicDTO>> GetAll()
    {
        List<PolyclinicEntity> entities = await context.Polyclinics.ToListAsync();
        List<GetPolyclinicDTO> result = new List<GetPolyclinicDTO>();
        foreach (var entity in entities)
        {
            result.Add(entity.ToDTO());
        }
        return result;
    }
    public async Task<GetPolyclinicDTO> GetById(int id)
    {
        PolyclinicEntity? entity = await context.Polyclinics.FindAsync(id);
        if (entity == null) return null!;
        return entity.ToDTO();
    }
    public async Task<int> Create(PostPolyclinicDTO postPolyclinicDTO)
    {
        PolyclinicEntity entity = postPolyclinicDTO.ToEntity();
        await context.Polyclinics.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }
    public async Task<bool> Update(PutPolyclinicDTO putPolyclinicDTO)
    {
        PolyclinicEntity? entity = await context.Polyclinics.FindAsync(putPolyclinicDTO.Id);
        if (entity == null) return false;
        entity.Update(putPolyclinicDTO);
        await context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> Delete(DeletePolyclinicDTO deletePolyclinicDTO)
    {
        PolyclinicEntity? entity = await context.Polyclinics.FindAsync(deletePolyclinicDTO.Id);
        if (entity == null) return false;
        context.Polyclinics.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ChangePolyclinic(PutChangePolyclinicDTO putChangePolyclinicDTO)
    {
        PolyclinicEntity? entity = await context.Polyclinics.FindAsync(putChangePolyclinicDTO.Id);
        if (entity == null) return false;
        entity.ChangeOffice(putChangePolyclinicDTO);
        await context.SaveChangesAsync();
        return true;
    }
}