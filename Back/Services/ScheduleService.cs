using System.Reflection.Metadata.Ecma335;
using Back.Dtos;
using Back.DTOs;
using Back.Extensions;
using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Services;

public class ScheduleService : IScheduleService
{
    private readonly Context context;
    public ScheduleService(Context context)
    {
        this.context = context;
    }
    public async Task<List<GetScheduleDTO>> GetAll()
    {
        List<ScheduleEntity> entities = await context.Schedules.ToListAsync();
        List<GetScheduleDTO> result = new List<GetScheduleDTO>();
        foreach (var entity in entities)
        {
            result.Add(entity.ToDTO());
        }
        return result;
    }
    public async Task<GetScheduleDTO> GetById(int id)
    {
        ScheduleEntity? entity = await context.Schedules.FindAsync(id);
        if (entity == null) return null!;
        return entity.ToDTO();
    }
    public async Task Create(int scheduleId, int appointId)
    {
        ScheduleEntity? entity = await context.Schedules.FindAsync(scheduleId);
        entity!.AddAppoint(appointId);
        await context.SaveChangesAsync();
    }
    public async Task Update(int newId, int oldId, int appointId)
    {
        ScheduleEntity? entitynew = await context.Schedules.FindAsync(newId);
        ScheduleEntity? entityold = await context.Schedules.FindAsync(oldId);
        entitynew!.ChangeAppoint(entityold!);
        await context.SaveChangesAsync();
    }
    public async Task Delete(int scheduleId)
    {
        ScheduleEntity? entity = await context.Schedules.FindAsync(scheduleId);
        entity!.DeleteAppoint();
        await context.SaveChangesAsync();
    }
}