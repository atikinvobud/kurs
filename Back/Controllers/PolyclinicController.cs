using Microsoft.AspNetCore.Mvc;
using Back.Services;
using Back.DTOs;
namespace Back.Controllers;

[ApiController]
[Route("policlinic")]
public class PolyclinicController : ControllerBase
{
    private readonly IPolyclinicService polyclinicService;
    public PolyclinicController(IPolyclinicService polyclinicService)
    {
        this.polyclinicService = polyclinicService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await polyclinicService.GetAll());
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] int Id)
    {
        GetPolyclinicDTO polyclinicDTO = await polyclinicService.GetById(Id);
        if (polyclinicDTO == null) return NotFound();
        return Ok(polyclinicDTO);
    }


    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] PostPolyclinicDTO postPolyclinicDTO)
    {
        return Ok(await polyclinicService.Create(postPolyclinicDTO));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] PutPolyclinicDTO putPolyclinicDTO)
    {
        bool succes = await polyclinicService.Update(putPolyclinicDTO);
        if (!succes) return NotFound();
        return Ok();
    }

    [HttpPut("Change")]
    public async Task<IActionResult> ChangePolyclinic([FromBody] PutChangePolyclinicDTO putChangePolyclinicDTO)
    {
        bool succes = await polyclinicService.ChangePolyclinic(putChangePolyclinicDTO);
        if (!succes) return NotFound();
        return Ok();
    }
    
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeletePolyclinicDTO deletePolyclinicDTO)
    {
        bool success = await polyclinicService.Delete(deletePolyclinicDTO);
        if (!success) return NotFound();
        return NoContent();
    }
}