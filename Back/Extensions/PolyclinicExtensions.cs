using Back.DTOs;
using Back.Models;

namespace Back.Extensions;

public static class PoliclinicExtensions
{
    public static GetPolyclinicDTO ToDTO(this PolyclinicEntity polyclinicEntity)
    {
        return new()
        {
            Id = polyclinicEntity.Id,
            PhoneNumber = polyclinicEntity.PhoneNumber,
            Address = polyclinicEntity.Address,
            RegistrationOfficeId = polyclinicEntity.RegistrationOfficeId,
            DistinctId = polyclinicEntity.DistinctId
        };
    }

    public static PolyclinicEntity ToEntity(this PostPolyclinicDTO postPolyclinicEntity)
    {
        return new()
        {
            PhoneNumber = postPolyclinicEntity.PhoneNumber,
            Address = postPolyclinicEntity.Address,
            RegistrationOfficeId = postPolyclinicEntity.RegistrationOfficeId,
            DistinctId = postPolyclinicEntity.DistinctId
        };
    }

    public static void Update(this PolyclinicEntity polyclinicEntity, PutPolyclinicDTO putPolyclinicDTO)
    {
        polyclinicEntity.PhoneNumber = putPolyclinicDTO.PhoneNumber;
        polyclinicEntity.Address = putPolyclinicDTO.Address;
        polyclinicEntity.DistinctId = putPolyclinicDTO.DistinctId;
    }

    public static void ChangeOffice(this PolyclinicEntity polyclinicEntity, PutChangePolyclinicDTO changePolyclinicDTO)
    {
        polyclinicEntity.RegistrationOfficeId = changePolyclinicDTO.RegistrationOfficeId;
    }
}