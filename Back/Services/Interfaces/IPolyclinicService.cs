using Back.DTOs;

namespace Back.Services;
public interface IPolyclinicService
{
    Task<bool> ChangePolyclinic(PutChangePolyclinicDTO putChangePolyclinicDTO);
    Task<int> Create(PostPolyclinicDTO postPolyclinicDTO);
    Task<bool> Delete(DeletePolyclinicDTO deletePolyclinicDTO);
    Task<List<GetPolyclinicDTO>> GetAll();
    Task<GetPolyclinicDTO> GetById(int id);
    Task<bool> Update(PutPolyclinicDTO putPolyclinicDTO);
}