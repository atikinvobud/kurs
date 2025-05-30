using Microsoft.AspNetCore.Mvc;
using Back.Services;
using System.Reflection.Metadata.Ecma335;
using Back.Dtos;
using Back.DTOs;
namespace Back.Controllers;

[ApiController]
[Route("distincts")]
public class DistinctController : ControllerBase
{
    private readonly IDistinctService distinctService;
    public DistinctController(IDistinctService distinctService)
    {
        this.distinctService = distinctService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await distinctService.GetAll());
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] int Id)
    {
        GetDistinctDTO distinctDTO = await distinctService.GetById(Id);
        if (distinctDTO == null) return NotFound();
        return Ok(distinctDTO);
    }


    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] PostDistinctDTO postDistinctDTO)
    {
        return Ok(await distinctService.Create(postDistinctDTO));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] PutDistinctDTO putDistinctDTO)
    {
        bool succes = await distinctService.Update(putDistinctDTO);
        if (!succes) return NotFound();
        return Ok();
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteDistinctDTO deleteDistinctDTO)
    {
        bool success = await distinctService.Delete(deleteDistinctDTO);
        if (!success) return NotFound();
        return NoContent();
    }
}