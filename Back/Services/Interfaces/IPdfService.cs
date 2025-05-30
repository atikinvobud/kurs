using Back.Dtos;

namespace Back.Services;
public interface IPdfService
{
    byte[] GeneratePdf(GetTicketDTO ticket);
}
