using Back.Dtos;
using Back.Models;
using Back.Extensions;

namespace Back.Services;
public class ReceptionService : IReceptionService
{
    private readonly Context context;
    public ReceptionService(Context context)
    {
        this.context = context;
    }
    public async Task<int> CreateReception(PostReceptionDTO postReceptionDTO)
    {
        ReceptionEntity entity = postReceptionDTO.ToReception();
        await context.Receptions.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async void CreateExaminations(int specializationId, int receptionId)
    {
        ExaminationEntity entity = new ExaminationEntity()
        {
            SpecializationId = specializationId,
            ReceptionId = receptionId
        };
        await context.Examinations.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async void CreateMedicine(int medicineId, int receptionId)
    {
        ReceptionMedicineEntity entity = new ReceptionMedicineEntity()
        {
            ReceptionId = receptionId,
            MedicineId = medicineId
        };

        await context.ReceptionMedicines.AddAsync(entity);
        await context.SaveChangesAsync();
    }
}