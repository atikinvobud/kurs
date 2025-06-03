using System.Security.Claims;
using Back.Dtos;
using Back.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers;

[ApiController]
[Route("medicine")]
public class MedicineController : ControllerBase
{
    private readonly IMedicineService medicineService;
    public MedicineController(IMedicineService medicineService)
    {
        this.medicineService = medicineService;
    }

     [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
       int UserId = int.Parse(User.FindFirstValue("userId")!);
        return Ok(await medicineService.GetAll(UserId));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] PostMedicineDTO postMedicineDTO)
    {
        return Ok(await medicineService.Create(postMedicineDTO));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] PutMedicineDTO putMedicineDTO)
    {
        bool succes = await medicineService.Update(putMedicineDTO);
        if (!succes) return NotFound();
        return Ok();
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteMedicineDTO deleteMedicineDTO)
    {
        bool success = await medicineService.Delete(deleteMedicineDTO);
        if (!success) return NotFound();
        return NoContent();
    }
}