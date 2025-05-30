using Back.Dtos;

namespace Back.Services;

public interface IScheduleService
{
    Task Create(int scheduleId, int appointId);
    Task Delete(int scheduleId);
    Task<List<GetScheduleDTO>> GetAll();
    Task<GetScheduleDTO> GetById(int id);
    Task Update(int newId, int oldId, int appointId);
}