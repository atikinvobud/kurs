using Back.Dtos;
using Back.Models;

namespace Back.Extensions;

public static class SpecializationExtensions
{
    public static GetSpecializationDTO ToDTO(this SpecializationEntity specializationEntity)
    {
        return new()
        {
            Id = specializationEntity.Id,
            Name = specializationEntity.Name
        };
    }

    public static SpecializationEntity ToEntity(this PostSpecaializationDTO postSpecaializationDTO)
    {
        return new()
        {
            Name = postSpecaializationDTO.Name
        };
    }

    public static void Update(this SpecializationEntity specializationEntity, PutSpecializationDTO putSpecializationDTO)
    {
        specializationEntity.Name = putSpecializationDTO.Name;
    } 
}