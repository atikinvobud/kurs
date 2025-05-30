using Microsoft.AspNetCore.Mvc;
using Back.Services;
using System.Reflection.Metadata.Ecma335;
using Back.Dtos;
using Back.DTOs;
namespace Back.Controllers;

[ApiController]
[Route("schedules")]
public class ScheduleController : ControllerBase
{
    private readonly IScheduleService scheduleService;
    public ScheduleController(IScheduleService scheduleService)
    {
        this.scheduleService = scheduleService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await scheduleService.GetAll());
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] int Id)
    {
        GetScheduleDTO scheduleDTO = await scheduleService.GetById(Id);
        if (scheduleDTO == null) return NotFound();
        return Ok(scheduleDTO);
    }
}