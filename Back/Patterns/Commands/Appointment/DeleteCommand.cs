using Back.Models;
using Back.Services;

using Back.Dtos;
using Microsoft.Win32.SafeHandles;
namespace Back.Patterns;
public class DeleteAppointmentCommand : IAppointmentCommand<bool>
{
    private readonly IAppointmentService appointmentService;
    private readonly DaleteAppointmentDTO deleteAppointmentDTO;

    public DeleteAppointmentCommand(IAppointmentService appointmentService, DaleteAppointmentDTO deleteAppointmentDTO)
    {
        this.appointmentService = appointmentService;
        this.deleteAppointmentDTO = deleteAppointmentDTO;
    }

    public async Task<bool> Execute(int scheduleId)
    {
        return await appointmentService.Delete(deleteAppointmentDTO, scheduleId);
    }
}