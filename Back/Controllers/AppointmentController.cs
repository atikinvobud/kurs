using System.Security.Claims;
using Back.Dtos;
using Back.Patterns;
using Back.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers;

[ApiController]
[Route("appointment")]
public class AppointmentController : ControllerBase
{
    private readonly CommandAppointmentInvoker commandAppointmentInvoker;
    private readonly IAppointmentService appointmentService;
    public AppointmentController(CommandAppointmentInvoker commandAppointmentInvoker, IAppointmentService appointmentService)
    {
        this.commandAppointmentInvoker = commandAppointmentInvoker;
        this.appointmentService = appointmentService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await appointmentService.GetAll());
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] int Id)
    {
        GetAppointmentDTO appointmentDTO = await appointmentService.GetById(Id);
        if (appointmentDTO == null) return NotFound();
        return Ok(appointmentDTO);
    }

    [HttpGet("history")]
    public async Task<IActionResult> GetHistory()
    {
        int UserId = int.Parse(User.FindFirstValue("userId")!);
        List<GetAppInfoDTO> list = await appointmentService.GetInfo(UserId);
        if (list.Count == 0) return NotFound();
        return Ok(list);
    }

    [HttpPost("create/{AppointmentId}")]
    public async Task<IActionResult> Create([FromBody] PostAppointmentDTO postAppointmentDTO, [FromRoute]int AppointmentId)
    {
        var command = new CreateAppointmentCommand(appointmentService, postAppointmentDTO);
        int id = await commandAppointmentInvoker.Invoke(command, AppointmentId);
        return Ok(new { id });
    }

    [HttpPut("update/{AppointmentId}")]
    public async Task<IActionResult> Update([FromBody] PutAppointmentDTO putAppointmentDTO, [FromRoute] int AppointmentId)
    {
        var command = new UpdateAppointmentCommand(appointmentService, putAppointmentDTO);
        bool success = await commandAppointmentInvoker.Invoke(command, AppointmentId);
        if (!success) return NotFound();
        return Ok();
    }

    [HttpDelete("delete/{AppointmentId}")]
    public async Task<IActionResult> Delete([FromBody] DaleteAppointmentDTO deleteAppointmentDTO, [FromRoute] int AppointmentId)
    {
        var command = new DeleteAppointmentCommand(appointmentService, deleteAppointmentDTO);
        bool success = await commandAppointmentInvoker.Invoke(command, AppointmentId);
        if (!success) return NotFound();
        return NoContent();
    }
}