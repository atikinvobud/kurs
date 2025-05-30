using Back.Dtos;

namespace Back.Services;
public interface IMedicineService
{
    Task<int> Create(PostMedicineDTO postMedicineDTO);
    Task<bool> Delete(DeleteMedicineDTO deleteMedicineDTO);
    Task<List<GetMedicineDTO>> GetAll();
    Task<GetMedicineDTO> GetById(int id);
    Task<bool> Update(PutMedicineDTO putMedicineDTO);
}