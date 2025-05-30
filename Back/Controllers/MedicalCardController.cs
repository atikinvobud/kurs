using Microsoft.AspNetCore.Mvc;
using Back.Services;
using System.Reflection.Metadata.Ecma335;
using Back.Dtos;
using Back.DTOs;
namespace Back.Controllers;

[ApiController]
[Route("medicalcards")]
public class MedicalCardController : ControllerBase
{
    private readonly IMedicalCardService medicalCardService;
    public MedicalCardController(IMedicalCardService medicalCardService)
    {
        this.medicalCardService = medicalCardService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await medicalCardService.GetAll());
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] int Id)
    {
        GetMedicalCardDTO medicalCardDTO = await medicalCardService.GetById(Id);
        if (medicalCardDTO == null) return NotFound();
        return Ok(medicalCardDTO);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] PostMedicalCardDTO postMedicalCardDTO)
    {
        return Ok(await medicalCardService.Create(postMedicalCardDTO));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] PutMedicalCardDTO putMedicalCardDTO)
    {
        bool succes = await medicalCardService.Update(putMedicalCardDTO);
        if (!succes) return NotFound();
        return Ok();
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteMedicalCardDTO deleteMedicalCardDTO)
    {
        bool success = await medicalCardService.Delete(deleteMedicalCardDTO);
        if (!success) return NotFound();
        return NoContent();
    }
}