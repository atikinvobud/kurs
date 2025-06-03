using Back.Dtos;

namespace Back.Services;

public interface ISickLeaveService
{
    Task<int> Create(PostSickLeaveDTO postSickLeaveDTO);
    Task<bool> Extend(ExtendSickLeaveDTO extendSickLeaveDTO);
    Task<List<GetSickLeaveDTO>> GetAll();
    Task<GetSickLeaveDTO> GetById(int id);
    Task<List<GetShortSickLeaveDTO>> GetShorts(int Id);
    Task<bool> Update(PutSickLeaveDTO putSickLeaveDTO);
}