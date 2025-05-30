using Back.Dtos;
using Back.Models;

namespace Back.Extensions;

public static class SickLeaveExtensions
{
    public static GetSickLeaveDTO ToDTO(this SickLeaveEntity sickLeaveEntity)
    {
        return new()
        {
            Id = sickLeaveEntity.Id,
            MedicalCardId = sickLeaveEntity.MedicalCardId,
            AmountOfPayments = sickLeaveEntity.AmountOfPayments,
            Length = sickLeaveEntity.Length,
            StartDate = sickLeaveEntity.StartDate,
            Diagnos = sickLeaveEntity.Diagnos,
            DoctorId = sickLeaveEntity.DoctorId,
        };
    }

    public static SickLeaveEntity ToEntity(this PostSickLeaveDTO postSickLeaveDTO)
    {
        return new()
        {
            MedicalCardId = postSickLeaveDTO.MedicalCardId,
            AmountOfPayments = postSickLeaveDTO.AmountOfPayments,
            Length = postSickLeaveDTO.Length,
            StartDate = postSickLeaveDTO.StartDate,
            Diagnos = postSickLeaveDTO.Diagnos,
            DoctorId = postSickLeaveDTO.DoctorId,
        };
    }

    public static void Update(this SickLeaveEntity sickLeaveEntity, PutSickLeaveDTO putSickLeaveDTO)
    {
        sickLeaveEntity.MedicalCardId = putSickLeaveDTO.MedicalCardId;
        sickLeaveEntity.AmountOfPayments = putSickLeaveDTO.AmountOfPayments;
        sickLeaveEntity.StartDate = putSickLeaveDTO.StartDate;
        sickLeaveEntity.Diagnos = putSickLeaveDTO.Diagnos;
        sickLeaveEntity.DoctorId = putSickLeaveDTO.DoctorId;
    }

    public static void ChangeLength(this SickLeaveEntity sickLeaveEntity, int length)
    {
        sickLeaveEntity.Length = length;
    }
}