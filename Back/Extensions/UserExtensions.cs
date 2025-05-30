using Back.Dtos;
using Back.Models;

namespace Back.Extensions;

public static class UserExtensions
{
    public static UserEntity ToEntity(this PostUserDTO postUserDTO)
    {
        return new()
        {
            Login = postUserDTO.Login,
            Password = postUserDTO.Password,
            DateOfBirth = postUserDTO.DateOfBirth
        };
    }

    public static PatientEntity ToPatientEntity(this PostPatientDTO postPatientDTO)
    {
        return new()
        {
            UserId = postPatientDTO.UserId,
            FIO = postPatientDTO.FIO
        };
    }

    public static DoctorEntity ToDoctorEntity(this PostDoctorDTO postDoctorDTO)
    {
        return new()
        {
            UserId = postDoctorDTO.UserId,
            SpecializationId = postDoctorDTO.SpecializationId,
            TimeOfTaking = postDoctorDTO.TimeOfTaking,
            FIO = postDoctorDTO.FIO
        };
    }

    public static RegistrationOfficeEntity ToOfficeEntity(this PostRegistrationOfficeDTO postRegistrationOfficeDTO)
    {
        return new()
        {
            UserId = postRegistrationOfficeDTO.UserId,
            Address = postRegistrationOfficeDTO.Address
        };
    }
}