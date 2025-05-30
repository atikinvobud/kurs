using Back.Dtos;
namespace Back.Services;

public interface IConclusionService
{
    Task<int> Create(PostConclusionDTO postConclusionDTO, int appointmentId);
    Task<bool> Delete(DeleteConclusionDTO deleteConclusionDTO);
    Task<List<GetConclusionDTO>> GetAll();
    Task<GetConclusionDTO> GetById(int id);
    Task<bool> Update(PutConclusionDTO putConclusionDTO);
}