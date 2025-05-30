using Back.Dtos;

namespace Back.Services;

public interface IReceptionService
{
    void CreateExaminations(int specializationId, int receptionId);
    void CreateMedicine(int medicineId, int receptionId);
    Task<int> CreateReception(PostReceptionDTO postReceptionDTO);
}