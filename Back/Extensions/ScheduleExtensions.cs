using Back.Dtos;
using Back.Models;
using Npgsql.Replication;

namespace Back.Extensions;

public static class ScheduleExtensions
{
    public static GetScheduleDTO ToDTO(this ScheduleEntity scheduleEntity)
    {
        return new()
        {
            Id = scheduleEntity.Id,
            DoctorId = scheduleEntity.DoctorId,
            AppointmentId = scheduleEntity.AppointmentId,
            StartTime = scheduleEntity.StartTime,
            Date = scheduleEntity.Date,
            PolyclinicId = scheduleEntity.PolyclinicId
        };
    }

    public static void AddAppoint(this ScheduleEntity scheduleEntity, int appointId)
    {
        scheduleEntity.AppointmentId = appointId;
    }

    public static void ChangeAppoint(this ScheduleEntity scheduleEntityappoint, ScheduleEntity schedulechange)
    {
        scheduleEntityappoint.AppointmentId = schedulechange.AppointmentId;
        schedulechange.AppointmentId = null;
    }
    public static void DeleteAppoint(this ScheduleEntity scheduleEntity)
    {
        scheduleEntity.AppointmentId = null;
    }
}