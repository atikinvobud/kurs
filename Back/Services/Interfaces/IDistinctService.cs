using Back.Dtos;
using Back.DTOs;
namespace Back.Services;

public interface IDistinctService
{
    Task<int> Create(PostDistinctDTO postDistinctDTO);
    Task<bool> Delete(DeleteDistinctDTO deleteDistinctDTO);
    Task<List<GetDistinctDTO>> GetAll();
    Task<GetDistinctDTO> GetById(int id);
    Task<bool> Update(PutDistinctDTO putDistinctDTO);
}