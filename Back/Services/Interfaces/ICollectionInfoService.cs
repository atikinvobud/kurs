using Back.Dtos;
namespace Back.Services;

public interface ICollectionInfoService
{
    Task<GetTicketDTO> CollectTicket(int appointmentId);
}
