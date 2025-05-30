using Microsoft.AspNetCore.Mvc;
using Back.Services;
using System.Reflection.Metadata.Ecma335;
using Back.Dtos;
using Back.DTOs;
namespace Back.Controllers;

[ApiController]
[Route("conclusion")]
public class ConclusionController : ControllerBase
{
    private readonly IConclusionService conclusionService;
    public ConclusionController(IConclusionService conclusionService)
    {
        this.conclusionService = conclusionService;
    }
    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await conclusionService.GetAll());
    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] int Id)
    {
        GetConclusionDTO conclusionDTO = await conclusionService.GetById(Id);
        if (conclusionDTO == null) return NotFound();
        return Ok(conclusionDTO);
    }


    [HttpPost("create/{AppointmentId}")]
    public async Task<IActionResult> Create([FromBody] PostConclusionDTO postConclusionDTO, [FromRoute] int AppointmentId)
    {
        return Ok(await conclusionService.Create(postConclusionDTO, AppointmentId));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] PutConclusionDTO putConclusionDTO)
    {
        bool succes = await conclusionService.Update(putConclusionDTO);
        if (!succes) return NotFound();
        return Ok();
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteConclusionDTO deleteConclusionDTO)
    {
        bool success = await conclusionService.Delete(deleteConclusionDTO);
        if (!success) return NotFound();
        return NoContent();
    }
}