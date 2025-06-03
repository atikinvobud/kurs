using Back.Dtos;
namespace Back.Services;

public interface IAppointmentService
{
    Task<int> Create(PostAppointmentDTO postAppointmentDTO, int id);
    Task<bool> Delete(DaleteAppointmentDTO daleteAppointmentDTO, int id);
    Task <List<GetAppInfoDTO>> GetInfo(int userId);
    Task<List<GetAppointmentDTO>> GetAll();
    Task<GetAppointmentDTO> GetById(int id);
    Task<bool> Update(PutAppointmentDTO putAppointmentDTO, int id);
}