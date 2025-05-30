using Back.Dtos;

namespace Back.Services;

public interface ISpecializationService
{
    Task<int> Create(PostSpecaializationDTO postSpecaializationDTO);
    Task<bool> Delete(DeleteSpecializationDTO deleteSpecializationDTO);
    Task<List<GetSpecializationDTO>> GetAll();
    Task<bool> Update(PutSpecializationDTO putSpecializationDTO);
}