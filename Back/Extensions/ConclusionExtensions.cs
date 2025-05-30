using Back.Dtos;
using Back.Models;

namespace Back.Extensions;

public static class ConclusionExtensions
{
    public static GetConclusionDTO ToDTO(this ConclusionEntity conclusionEntity)
    {
        return new()
        {
            Id = conclusionEntity.Id,
            Diagnos = conclusionEntity.Diagnos,
            Description = conclusionEntity.Description
        };
    }

    public static ConclusionEntity ToEntity(this PostConclusionDTO postConclusionDTO)
    {
        return new()
        {
            Diagnos = postConclusionDTO.Diagnos,
            Description = postConclusionDTO.Description
        };
    }

    public static void Update(this ConclusionEntity conclusionEntity, PutConclusionDTO putConclusionDTO)
    {
        conclusionEntity.Diagnos = putConclusionDTO.Diagnos;
        conclusionEntity.Description = putConclusionDTO.Description;
    } 
}