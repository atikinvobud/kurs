using System.Reflection.Metadata.Ecma335;
using Back.Dtos;
using Back.Models;
using Back.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers;

[ApiController]
[Route("ticket")]
public class TicketController : ControllerBase
{
    private readonly ICollectionInfoService collectionInfoService;
    private readonly ITicketService ticketService;
    private readonly IPdfService pdfService;
    public TicketController(ICollectionInfoService collectionInfoService, ITicketService ticketService, IPdfService pdfService)
    {
        this.collectionInfoService = collectionInfoService;
        this.ticketService = ticketService;
        this.pdfService = pdfService;
    }

    [HttpGet("{appointmentId}")]
    public async Task<IActionResult> Show([FromRoute] int appointmentId)
    {
        GetTicketDTO getTicketDTO = await collectionInfoService.CollectTicket(appointmentId);
        if (getTicketDTO == null) return NotFound();
        string html = ticketService.GeneratTicket(getTicketDTO);
        return Content(html, "text/html");
    }
    [HttpGet("pdf/{appointmentId}")]
    public async Task<IActionResult> Print([FromRoute] int appointmentId)
    {
        GetTicketDTO getTicketDTO = await collectionInfoService.CollectTicket(appointmentId);
        if (getTicketDTO == null) return NotFound();
        var pdfBytes = pdfService.GeneratePdf(getTicketDTO);
        return File(pdfBytes, "application/pdf", "ticket.pdf");
    }
}