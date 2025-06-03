using Microsoft.AspNetCore.Mvc;
using Back.Services;
using System.Reflection.Metadata.Ecma335;
using Back.Dtos;
using Back.DTOs;
using System.Security.Claims;
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
    [HttpGet("FullInfo")]
    public async Task<IActionResult> GetFull()
    {
        int UserId = int.Parse(User.FindFirstValue("userId")!);
        return Ok(await medicalCardService.FullInfo(UserId));
    }
    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await medicalCardService.GetAll());
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