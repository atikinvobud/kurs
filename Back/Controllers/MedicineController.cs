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
        return Ok(await medicineService.GetAll());
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] int Id)
    {
        GetMedicineDTO medicineDTO= await medicineService.GetById(Id);
        if (medicineDTO == null) return NotFound();
        return Ok(medicineDTO);
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