using Back.Dtos;

namespace Back.Services;
public interface IMedicalCardService
{
    Task<int> Create(PostMedicalCardDTO postMedicalCardDTO);
    Task<bool> Delete(DeleteMedicalCardDTO deleteMedicalCardDTO);
    Task<List<GetMedicalCardDTO>> GetAll();
    Task<GetMedicalCardDTO> GetById(int id);
    Task<bool> Update(PutMedicalCardDTO putMedicalCardDTO);
}