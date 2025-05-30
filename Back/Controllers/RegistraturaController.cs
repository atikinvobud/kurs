using System.Reflection.Metadata.Ecma335;
using Back.DTOs;
using Back.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers;

[ApiController]
[Route("registraturs")]
public class RegistraturaController : ControllerBase
{
    private readonly IRegistraturaService registraturaService;
    public RegistraturaController(IRegistraturaService registraturaService)
    {
        this.registraturaService = registraturaService;
    }

    [HttpPost("all")]
    public async Task<IActionResult> Delete([FromBody] DeleteDoctorsAppointmentDTO deleteDoctorsAppointmentDTO)
    {
        await registraturaService.DeleteDoctorSchedule(deleteDoctorsAppointmentDTO);
        return Ok();
    }
}