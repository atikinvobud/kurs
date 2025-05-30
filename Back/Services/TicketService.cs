using System.Reflection.Metadata.Ecma335;
using Back.Dtos;
using Back.Models;

namespace Back.Services;

public class TicketService : ITicketService
{
    private readonly ITicketBuilder ticketBuilder;
    public TicketService(ITicketBuilder ticketbuilder)
    {
        this.ticketBuilder = ticketbuilder;
    }
    private Ticket CreateTicket(GetTicketDTO getTicketDTO)
    {
        ticketBuilder.SetPatient(getTicketDTO.FIO);
        ticketBuilder.SetDoctor(getTicketDTO.Doctor, getTicketDTO.SpecializationName);
        ticketBuilder.SetTime(getTicketDTO.Date, getTicketDTO.Time);
        ticketBuilder.SetCabinet(getTicketDTO.Cabinet);
        Ticket ticket = ticketBuilder.Build();
        return ticket;
    }
    public string GeneratTicket(GetTicketDTO getTicketDTO)
    {
        Ticket ticket = CreateTicket(getTicketDTO);
        return $@"
    <!DOCTYPE html>
    <html lang=""ru"">
    <head>
        <meta charset=""UTF-8"">
        <title>Талон на приём</title>
        <style>
            body {{
                background-color: #1e1e1e;
                font-family: Arial, sans-serif;
                display: flex;
                justify-content: center;
                align-items: center;
                height: 100vh;
                margin: 0;
            }}

            .ticket {{
                background-color: white;
                padding: 30px 50px;
                border-radius: 4px;
                text-align: center;
                font-size: 18px;
                line-height: 1.6;
                box-shadow: 0 0 15px rgba(0, 0, 0, 0.25);
            }}

            .ticket h1 {{
                font-size: 20px;
                margin-bottom: 20px;
            }}

            .ticket p {{
                margin: 8px 0;
            }}
        </style>
    </head>
    <body>
        <div class=""ticket"">
            <h1>Талон для записи к врачу</h1>
            <p><strong>ФИО пациента:</strong> {ticket.FIO}</p>
            <p><strong>Врач:</strong> {ticket.Doctor}</p>
            <p><strong>Специальность:</strong> {ticket.SpecializationName}</p>
            <p><strong>Дата:</strong> {ticket.Date:dd.MM.yyyy}</p>
            <p><strong>Время:</strong> {ticket.Time.ToString(@"hh\:mm")}</p>
            <p><strong>Кабинет:</strong> {ticket.Cabinet}</p>
        </div>
    </body>
    </html>";
    }

}