using System.Reflection.Metadata.Ecma335;
using Back.Dtos;
using Back.DTOs;
using Back.Extensions;
using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Services;

public class ConclusionService : IConclusionService
{
    private readonly Context context;
    public ConclusionService(Context context)
    {
        this.context = context;
    }
    public async Task<List<GetConclusionDTO>> GetAll()
    {
        List<ConclusionEntity> entities = await context.Conclusions.ToListAsync();
        List<GetConclusionDTO> result = new List<GetConclusionDTO>();
        foreach (var entity in entities)
        {
            result.Add(entity.ToDTO());
        }
        return result;
    }
    public async Task<GetConclusionDTO> GetById(int id)
    {
        ConclusionEntity? entity = await context.Conclusions.FindAsync(id);
        if (entity == null) return null!;
        return entity.ToDTO();
    }
    public async Task<int> Create(PostConclusionDTO postConclusionDTO, int appointmentId)
    {
        ConclusionEntity entity = postConclusionDTO.ToEntity();
        await context.Conclusions.AddAsync(entity);
        await context.SaveChangesAsync();
        AppointmentEntity? appointment = await context.Appointments.FindAsync(appointmentId);
        if (appointment != null)
        {
            appointment.AppointConclusion(entity.Id);
            await context.SaveChangesAsync();
        }
        return entity.Id;
    }
    public async Task<bool> Update(PutConclusionDTO putConclusionDTO)
    {
        ConclusionEntity? entity = await context.Conclusions.FindAsync(putConclusionDTO.Id);
        if (entity == null) return false;
        entity.Update(putConclusionDTO);
        await context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> Delete(DeleteConclusionDTO deleteConclusionDTO)
    {
        ConclusionEntity? entity = await context.Conclusions.FindAsync(deleteConclusionDTO.Id);
        if (entity == null) return false;
        context.Conclusions.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
}