using Back.Dtos;

namespace Back.Services;

public interface ITicketService
{
    string GeneratTicket(GetTicketDTO getTicketDTO);
}