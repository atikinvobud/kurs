using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using Back.Models;
using Back.Dtos;

namespace Back.Services;

public class CollectionInfoService : ICollectionInfoService
{
    private readonly Context context;
    public CollectionInfoService(Context context)
    {
        this.context = context;
    }

    public async Task<GetTicketDTO> CollectTicket(int appointmentId)
    {
        List<GetTicketDTO>? appointmentEntity = await context.Appointments.Where(a => a.Id == appointmentId)
        .Include(a => a.scheduleEntity).ThenInclude(s => s!.doctorEntity).ThenInclude(d => d!.specializationEntity).Include(a => a.medicalCardEntity).ThenInclude(mc => mc!.patientEntity)
        .Select(a => new GetTicketDTO()
        {
            FIO = a.medicalCardEntity!.patientEntity!.FIO,
            Doctor = a.scheduleEntity!.doctorEntity!.FIO,
            SpecializationName = a.scheduleEntity!.doctorEntity!.specializationEntity!.Name,
            Date = a.scheduleEntity!.Date,
            Time = a.scheduleEntity!.StartTime,
            Cabinet = a.Cabinet
        }).ToListAsync();
        if (appointmentEntity.Count == 0) return null!;
        return appointmentEntity[0];

    }
}