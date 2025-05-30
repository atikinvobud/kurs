using System.Reflection.Metadata.Ecma335;
using Back.Dtos;
using Back.DTOs;
using Back.Extensions;
using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Services;

public class SickLeaveService : ISickLeaveService
{
    private readonly Context context;
    public SickLeaveService(Context context)
    {
        this.context = context;
    }
    public async Task<List<GetSickLeaveDTO>> GetAll()
    {
        List<SickLeaveEntity> entities = await context.SickLeaves.ToListAsync();
        List<GetSickLeaveDTO> result = new List<GetSickLeaveDTO>();
        foreach (var entity in entities)
        {
            result.Add(entity.ToDTO());
        }
        return result;
    }
    public async Task<GetSickLeaveDTO> GetById(int id)
    {
        SickLeaveEntity? entity = await context.SickLeaves.FindAsync(id);
        if (entity == null) return null!;
        return entity.ToDTO();
    }
    public async Task<int> Create(PostSickLeaveDTO postSickLeaveDTO)
    {
        SickLeaveEntity entity = postSickLeaveDTO.ToEntity();
        await context.SickLeaves.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }
    public async Task<bool> Update(PutSickLeaveDTO putSickLeaveDTO)
    {
        SickLeaveEntity? entity = await context.SickLeaves.FindAsync(putSickLeaveDTO.Id);
        if (entity == null) return false;
        entity.Update(putSickLeaveDTO);
        await context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> Extend(ExtendSickLeaveDTO extendSickLeaveDTO)
    {
        SickLeaveEntity? entity = await context.SickLeaves.FindAsync(extendSickLeaveDTO.Id);
        if (entity == null) return false;
        int days = extendSickLeaveDTO.newDateOfEnd.DayNumber - entity.StartDate.DayNumber;
        entity.ChangeLength(days);
        await context.SaveChangesAsync();
        return true;
    }
}