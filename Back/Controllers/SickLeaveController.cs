using Back.Dtos;
using Back.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers;

[ApiController]
[Route("sickLeave")]
public class SickLeaveController : ControllerBase
{
    private readonly ISickLeaveService sickLeaveService;
    public SickLeaveController(ISickLeaveService sickLeaveService)
    {
        this.sickLeaveService = sickLeaveService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await sickLeaveService.GetAll());
    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] int Id)
    {
        GetSickLeaveDTO sickLeaveDTO = await sickLeaveService.GetById(Id);
        if (sickLeaveDTO == null) return NotFound();
        return Ok(sickLeaveDTO);
    }


    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] PostSickLeaveDTO postSickLeaveDTO)
    {
        return Ok(await sickLeaveService.Create(postSickLeaveDTO));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] PutSickLeaveDTO putSickLeaveDTO)
    {
        bool succes = await sickLeaveService.Update(putSickLeaveDTO);
        if (!succes) return NotFound();
        return Ok();
    }

    [HttpPut("Extend")]
    public async Task<IActionResult> Delete([FromBody] ExtendSickLeaveDTO extendSickLeaveDTO)
    {
        bool success = await sickLeaveService.Extend(extendSickLeaveDTO);
        if (!success) return NotFound();
        return Ok();
    }
}