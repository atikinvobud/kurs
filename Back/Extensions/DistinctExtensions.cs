using Back.Dtos;
using Back.Models;

namespace Back.Extensions;

public static class DistinctExtensions
{
    public static GetDistinctDTO ToDTO(this DistinctEntity distinctEntity)
    {
        return new()
        {
            Id = distinctEntity.Id,
            Name = distinctEntity.Name
        };
    }

    public static DistinctEntity ToEntity(this PostDistinctDTO postDistinctDTO)
    {
        return new()
        {
            Name = postDistinctDTO.Name
        };
    }

    public static void Update(this DistinctEntity distinctEntity, PutDistinctDTO putDistinctDTO)
    {
        distinctEntity.Name = putDistinctDTO.Name;
    } 
}