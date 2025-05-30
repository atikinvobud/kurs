using System.Data;
using Back.Dtos;
using Back.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers;

[ApiController]
[Route("specialization")]
public class SpecializationController : ControllerBase
{
    private readonly ISpecializationService specializationService;
    public SpecializationController(ISpecializationService specializationService)
    {
        this.specializationService = specializationService;
    }
    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await specializationService.GetAll());
    }

    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] PostSpecaializationDTO postSpecaializationDTO)
    {
        return Ok(await specializationService.Create(postSpecaializationDTO));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] PutSpecializationDTO putSpecializationDTO)
    {
        bool succes = await specializationService.Update(putSpecializationDTO);
        if (!succes) return NotFound();
        return Ok();
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteSpecializationDTO deleteSpecializationDTO)
    {
        bool success = await specializationService.Delete(deleteSpecializationDTO);
        if (!success) return NotFound();
        return NoContent();
    }
}