using Back.Models;
using Back.Services;
using Back.Dtos;
using System.Threading.Tasks;
namespace Back.Patterns;
public class CreateAppointmentCommand : IAppointmentCommand<int>
{
    private readonly IAppointmentService appointmentService;
    private readonly PostAppointmentDTO postAppointmentDTO;

    public CreateAppointmentCommand(IAppointmentService appointmentService, PostAppointmentDTO postAppointmentDTO)
    {
        this.appointmentService = appointmentService;
        this.postAppointmentDTO = postAppointmentDTO;
    }

    public async Task<int> Execute(int scheduleId)
    {
        return await appointmentService.Create(postAppointmentDTO, scheduleId);
    }
}
