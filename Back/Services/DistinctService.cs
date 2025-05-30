using System.Reflection.Metadata.Ecma335;
using Back.Dtos;
using Back.DTOs;
using Back.Extensions;
using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Services;

public class DistinctService : IDistinctService
{
    private readonly Context context;
    public DistinctService(Context context)
    {
        this.context = context;
    }
    public async Task<List<GetDistinctDTO>> GetAll()
    {
        List<DistinctEntity> entities = await context.Distincts.ToListAsync();
        List<GetDistinctDTO> result = new List<GetDistinctDTO>();
        foreach (var entity in entities)
        {
            result.Add(entity.ToDTO());
        }
        return result;
    }
    public async Task<GetDistinctDTO> GetById(int id)
    {
        DistinctEntity? entity = await context.Distincts.FindAsync(id);
        if (entity == null) return null!;
        return entity.ToDTO();
    }
    public async Task<int> Create(PostDistinctDTO postDistinctDTO)
    {
        DistinctEntity entity = postDistinctDTO.ToEntity();
        await context.Distincts.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }
    public async Task<bool> Update(PutDistinctDTO putDistinctDTO)
    {
        DistinctEntity? entity = await context.Distincts.FindAsync(putDistinctDTO.Id);
        if (entity == null) return false;
        entity.Update(putDistinctDTO);
        await context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> Delete(DeleteDistinctDTO deleteDistinctDTO)
    {
        DistinctEntity? entity = await context.Distincts.FindAsync(deleteDistinctDTO.Id);
        if (entity == null) return false;
        context.Distincts.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
}