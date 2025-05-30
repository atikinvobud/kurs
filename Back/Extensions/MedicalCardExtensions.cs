using Back.Dtos;
using Back.Models;

namespace Back.Extensions;

public static class MedicalCardExtensions
{
    public static GetMedicalCardDTO ToDTO(this MedicalCardEntity medicalCardEntity)
    {
        return new()
        {
            Id = medicalCardEntity.Id,
            DateOfStart = medicalCardEntity.DateOfStart,
            DateOfEnd = medicalCardEntity.DateOfEnd,
            PassportNumber = medicalCardEntity.PassportNumber,
            PassportSeria = medicalCardEntity.PassportSeria,
            OMSPolicy = medicalCardEntity.OMSPolicy,
            PolyclinicId = medicalCardEntity.PolyclinicId,
            PatientId = medicalCardEntity.PatientId
        };
    }

    public static MedicalCardEntity ToEntity(this PostMedicalCardDTO postMedicalCardDTO)
    {
        return new()
        {
            DateOfStart = postMedicalCardDTO.DateOfStart,
            DateOfEnd = postMedicalCardDTO.DateOfEnd,
            PassportNumber = postMedicalCardDTO.PassportNumber,
            PassportSeria = postMedicalCardDTO.PassportSeria,
            OMSPolicy = postMedicalCardDTO.OMSPolicy,
            PolyclinicId = postMedicalCardDTO.PolyclinicId,
            PatientId = postMedicalCardDTO.PatientId
        };
    }

    public static void Update(this MedicalCardEntity medicalCardEntity, PutMedicalCardDTO putMedicalCardDTO)
    {
        medicalCardEntity.DateOfStart = putMedicalCardDTO.DateOfStart;
        medicalCardEntity.DateOfEnd = putMedicalCardDTO.DateOfEnd;
        medicalCardEntity.PassportNumber = putMedicalCardDTO.PassportNumber;
        medicalCardEntity.PassportSeria = putMedicalCardDTO.PassportSeria;
        medicalCardEntity.OMSPolicy = putMedicalCardDTO.OMSPolicy;
        medicalCardEntity.PolyclinicId = putMedicalCardDTO.PolyclinicId;
        medicalCardEntity.PatientId = putMedicalCardDTO.PatientId;
    } 
}