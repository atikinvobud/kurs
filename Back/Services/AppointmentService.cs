using System.Reflection.Metadata.Ecma335;
using Back.Dtos;
using Back.DTOs;
using Back.Extensions;
using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Services;

public class AppointmentService : IAppointmentService
{
    private readonly Context context;
    private readonly ScheduleService scheduleService;
    public AppointmentService(Context context, ScheduleService scheduleService)
    {
        this.context = context;
        this.scheduleService = scheduleService;
    }
    public async Task<List<GetAppointmentDTO>> GetAll()
    {
        List<AppointmentEntity> entities = await context.Appointments.ToListAsync();
        List<GetAppointmentDTO> result = new List<GetAppointmentDTO>();
        foreach (var entity in entities)
        {
            result.Add(entity.ToDTO());
        }
        return result;
    }
    public async Task<GetAppointmentDTO> GetById(int id)
    {
        AppointmentEntity? entity = await context.Appointments.FindAsync(id);
        if (entity == null) return null!;
        return entity.ToDTO();
    }
    public async Task<int> Create(PostAppointmentDTO postAppointmentDTO, int id)
    {
        AppointmentEntity entity = postAppointmentDTO.ToEntity();
        await context.Appointments.AddAsync(entity);
        await context.SaveChangesAsync();
        ScheduleEntity? scheduleEntity = await context.Schedules.FindAsync(id);
        if (scheduleEntity != null)
        {
            scheduleEntity.AddAppoint(entity.Id);
            await context.SaveChangesAsync();
        }
        return entity.Id;
    }
    public async Task<bool> Update(PutAppointmentDTO putAppointmentDTO, int id)
    {
        AppointmentEntity? entity = await context.Appointments.FindAsync(putAppointmentDTO.Id);
        if (entity == null) return false;
        entity.Update(putAppointmentDTO);
        await context.SaveChangesAsync();
        ScheduleEntity? entitynew = await context.Schedules.FindAsync(id);
        ScheduleEntity? entityold = await context.Schedules.Where(s => s.AppointmentId == putAppointmentDTO.Id).FirstOrDefaultAsync();
        entitynew!.ChangeAppoint(entityold!);
        await context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> Delete(DaleteAppointmentDTO daleteAppointmentDTO, int id)
    {
        AppointmentEntity? entity = await context.Appointments.FindAsync(daleteAppointmentDTO.Id);
        ScheduleEntity? scheduleEntity = await context.Schedules.FindAsync(id);
        scheduleEntity!.DeleteAppoint();
        await context.SaveChangesAsync();
        if (entity == null) return false;
        context.Appointments.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
}