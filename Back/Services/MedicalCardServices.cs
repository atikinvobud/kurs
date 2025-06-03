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
    public async Task<List<GettFullInfoDTO>> FullInfo(int userId)
    {
        List<int> ids = await context.MedicalCards.Include(mc => mc.patientEntity).ThenInclude(p => p!.userEntity)
        .Where(mc => mc.patientEntity!.userEntity!.Id == userId).Select(mc => mc.PolyclinicId).ToListAsync();
        List<GettFullInfoDTO> list = await context.Polyclinics.Where(p => ids.Contains(p.Id)).Include(p => p.medicalCardEntities)
        .ThenInclude(mc => mc.sickLeaveEntities).ThenInclude(sl => sl.doctorEntity)
        .SelectMany(p => p.medicalCardEntities.SelectMany(mc => mc.sickLeaveEntities.Select(sl => new GettFullInfoDTO()
        {
            PolyclinicId = p.Id,
            Address = p.Address,
            Passport = mc.PassportNumber.ToString() + mc.PassportSeria.ToString(),
            Polis = mc.OMSPolicy,
            Snils = mc.OMSPolicy,
            StartDate = sl.StartDate,
            Length = sl.Length,
            Diagnos = sl.Diagnos,
            DoctorFIO = sl.doctorEntity!.FIO
        }))).ToListAsync();
        return list;
    }
}