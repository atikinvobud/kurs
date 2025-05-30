using Back.Dtos;
using Back.Models;

namespace Back.Extensions;

public static class AppointmentExtensions
{
    public static GetAppointmentDTO ToDTO(this AppointmentEntity appointmentEntity)
    {
        return new()
        {
            Id = appointmentEntity.Id,
            Cabinet = appointmentEntity.Cabinet,
            Status = appointmentEntity.Status,
            ConclusionId = -appointmentEntity.ConclusionId,
            MedicalCardId = appointmentEntity.MedicalCardId
        };
    }

    public static AppointmentEntity ToEntity(this PostAppointmentDTO postAppointmentDTO)
    {
        return new()
        {
            Cabinet = postAppointmentDTO.Cabinet,
            Status = postAppointmentDTO.Status,
            ConclusionId = postAppointmentDTO.ConclusionId,
            MedicalCardId = postAppointmentDTO.MedicalCardId
        };
    }

    public static void Update(this AppointmentEntity appointmentEntity, PutAppointmentDTO putAppointmentDTO)
    {
        appointmentEntity.Cabinet = putAppointmentDTO.Cabinet;
        appointmentEntity.Status = putAppointmentDTO.Status;
        appointmentEntity.MedicalCardId = putAppointmentDTO.MedicalCardId;
        appointmentEntity.ConclusionId = putAppointmentDTO.ConclusionId;
    }

    public static void AppointConclusion(this AppointmentEntity appointmentEntity, int conclusionId)
    {
        appointmentEntity.ConclusionId = conclusionId;
    }
}