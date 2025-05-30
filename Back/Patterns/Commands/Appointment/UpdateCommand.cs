using System.Threading.Tasks;
using Back.Dtos;
using Back.Models;
using Back.Services;
namespace Back.Patterns;
public class UpdateAppointmentCommand : IAppointmentCommand<bool>
{
    private readonly IAppointmentService appointmentService;
    private readonly PutAppointmentDTO putAppointmentDTO;

    public UpdateAppointmentCommand(IAppointmentService appointmentService, PutAppointmentDTO putAppointmentDTO)
    {
        this.appointmentService = appointmentService;
        this.putAppointmentDTO = putAppointmentDTO;
    }

    public async Task<bool> Execute(int scheduleId)
    {
         return await appointmentService.Update(putAppointmentDTO, scheduleId);
    }
}