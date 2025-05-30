using Back.Dtos;
using Back.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers;

[ApiController]
[Route("reception")]
public class ReceptionController : ControllerBase
{
    private readonly IReceptionService receptionService;
    public ReceptionController(IReceptionService receptionService)
    {
        this.receptionService = receptionService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] PostReceptionDTO postReceptionDTO)
    {
        int receptionId = await receptionService.CreateReception(postReceptionDTO);

        foreach (var examinationId in postReceptionDTO.ExaminationIds)
        {
            receptionService.CreateExaminations(examinationId, receptionId);
        }

        foreach (var medicineId in postReceptionDTO.MedicineIds)
        {
            receptionService.CreateMedicine(medicineId, receptionId);
        }

        return Ok(new {receptionId});
    }

}