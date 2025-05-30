using Back.DTOs;
using Back.Extensions;
using Back.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ess;

namespace Back.Services;
public class RegistraturaService : IRegistraturaService
{
    private readonly Context context;
    private readonly CancelationNotifier cancelationNotifier;
    public RegistraturaService(Context context, CancelationNotifier cancelationNotifier)
    {
        this.context = context;
        this.cancelationNotifier = cancelationNotifier;
    }

    public async Task DeleteDoctorSchedule(DeleteDoctorsAppointmentDTO deleteDoctorsAppointmentDTO)
    {
        List<ScheduleEntity> schedules = await context.Schedules.Where(s => s.Date == deleteDoctorsAppointmentDTO.Day && s.DoctorId == deleteDoctorsAppointmentDTO.DoctorId).ToListAsync();
        foreach (ScheduleEntity schedule in schedules)
        {
            if (!(schedule.AppointmentId == null))
            {
                AppointmentEntity? appointmentEntity = await context.Appointments.Include(a => a.medicalCardEntity).ThenInclude(mc => mc!.patientEntity).ThenInclude(p => p!.userEntity)
                .Include(a => a.scheduleEntity).ThenInclude(s => s!.doctorEntity).ThenInclude(d => d!.userEntity).FirstOrDefaultAsync(a => a.Id == schedule.AppointmentId);
                if (appointmentEntity is not null) await cancelationNotifier.SendAsync(appointmentEntity!, deleteDoctorsAppointmentDTO.Reason);
                schedule.DeleteAppoint();
            }
            context.Schedules.Remove(schedule);
            await context.SaveChangesAsync();
        }
    }
}